using System;

namespace AccessControlMatrix
{
    public class NamedObject
    {
        public NamedObject(String name)
        {
            this.name = name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public String name { get; }
    }
}
