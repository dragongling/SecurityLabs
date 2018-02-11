using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlMatrix
{
    class LoginCommand : Command
    {
        public LoginCommand(String name) : base(name, null, "Logs into the system") { }

        public override void Execute(CommandShell shell, String args)
        {
            String[] parsedArgs = args.Split(' ');

            if (args == String.Empty)
            {
                AskLogin();
                AskPassword();
            }
            else switch (parsedArgs.Length)
                {
                    case 1:
                        login = parsedArgs[0];
                        AskPassword();
                        break;
                    case 2:
                        login = parsedArgs[0];
                        password = parsedArgs[1];
                        break;
                    default:
                        throw new ParseArgsError();
                }
            shell.SetUser(DB.GetUserByLoginPass(login, password));
        }

        private void AskLogin()
        {
            Console.Write("Login: ");
            login = Console.ReadLine();
        }

        private void AskPassword()
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
        }

        private String login, password;
    }
}
