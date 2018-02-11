using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlMatrix
{
    class FileCommand : Command
    {
        public FileCommand(String name, Action<CommandShell, String> function, String usageDescription)
            : base(name, function, usageDescription) { }

        public override void Execute(CommandShell shell, string args)
        {
            shell.CheckLoggedIn();
            if (args == String.Empty)
                throw new ParseArgsError();
            base.Execute(shell, args);
        }
    }

    class SilentFileCommand : FileCommand
    {
        public SilentFileCommand(String name, Action<CommandShell, String> function, String usageDescription)
            : base(name, function, usageDescription) { }

        public override void Execute(CommandShell shell, string args)
        {
            base.Execute(shell, args);
            Console.WriteLine("Success!!");
        }
    }
}
