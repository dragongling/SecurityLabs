using System;

namespace AccessControlMatrix
{
    class Command : NamedObject
    {
        public Command(String name, Action<CommandShell, String> function, String usageDescription) : base(name)
        {
            this.function = function;
            this.usageDescription = usageDescription;
        }

        public virtual void Execute(CommandShell shell, String args)
        {
            function(shell, args);
        }
        
        protected String usageDescription;
        private Action<CommandShell, String> function;

        public String GetUsage()
        {
            return "Usage: " + name + "\n" + usageDescription;
        }

        public override String ToString()
        {
            return name;
        }

        public class ParseArgsError : ApplicationException { }
    }    
}
