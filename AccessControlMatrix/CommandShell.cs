using System;
using System.Linq;

namespace AccessControlMatrix
{
    class CommandShell
    {
        public CommandShell(String hostname)
        {
            prompt = defaultPrompt = hostname + ":";
            path = "/";
        }

        public void SetUser(User user)
        {
            currentUser = user;
            prompt = user.name.ToLower() + "@" + defaultPrompt + path + (user.isAdmin ? "#" : "$");
        }

        public void ResetUser()
        {
            currentUser = null;
            prompt = defaultPrompt;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Cyberdine Systems Inc.\n" +
                "Use \"login\" command to log in into the system, \"exit\" command to quit");
            while (!quit)
            {
                Console.Write(prompt);
                String input = Console.ReadLine();
                if (input == "")
                    continue;
                String[] commandInput = input.Split(new[] { ' ' }, 2);
                String commandName = commandInput.First(),
                    arguments = (commandInput.Length > 1 ? commandInput[1] : String.Empty);
                Command command = Array.Find(availableCommands, (Command c) => c.name == commandName);
                if (command == null)
                    Console.WriteLine(commandName + ": command not found");
                else
                    try
                    {
                        command.Execute(this, arguments);
                    }
                    catch (Command.ParseArgsError)
                    {
                        Console.WriteLine("Wrong command format");
                        Console.WriteLine(command.GetUsage());
                    }
                    catch (NotLoggedInError)
                    {
                        Console.WriteLine("You must be logged in to use this command");
                    }
                    catch (ApplicationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }
        }

        public void CheckLoggedIn()
        {
            if (currentUser == null)
                throw new NotLoggedInError();
        }

        private Command[] availableCommands = {
            new Command("exit", delegate(CommandShell cl, String args){
                if(args != String.Empty)
                    throw new Command.ParseArgsError();
                if(cl.currentUser != null)
                    cl.ResetUser();
                else
                    cl.quit = true;
            }, "Exits the system"),
            new LoginCommand("login"),
            new Command("ls", delegate(CommandShell sh, String args)
            {
                sh.CheckLoggedIn();
                DB.GetListOfFiles(sh.currentUser);
            }, "Shows list of files in current directory"),
            new FileCommand("read", delegate(CommandShell sh, String args)
            {
                String[] parsedArgs = args.Split(' ');
                if(parsedArgs.Length > 1)
                    throw new Command.ParseArgsError();
                String filename = parsedArgs[0];
                DB.Read(sh.currentUser, filename);
            }, "Reads content of the specific file"),
            new SilentFileCommand("write", delegate(CommandShell sh, String args)
            {
                String[] parsedArgs = args.Split(new[]{' ' }, 2);
                String filename = parsedArgs[0];
                String content = parsedArgs[1];
                DB.Write(sh.currentUser, filename, content);
            }, "Writes content to the specific file"),            
            new SilentFileCommand("grant", delegate(CommandShell sh, String args)
            {
                String[] parsedArgs = args.Split(' ');
                if(parsedArgs.Length < 3)
                    throw new Command.ParseArgsError();
                String username = parsedArgs.First();
                String filename = parsedArgs.Last();
                DB.Grant(sh.currentUser, username, parsedArgs.Skip(1).Take(parsedArgs.Length - 2), filename);
            }, "Grants selected permissions to the specific user")
        };

        private String path, prompt, defaultPrompt;
        private User currentUser;
        public bool quit = false;

        public class NotLoggedInError : ApplicationException { }
    }
}
