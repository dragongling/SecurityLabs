using System;

namespace AccessControlMatrix
{
    class Permission : NamedObject, IEquatable<Permission>
    {
        public Permission(String name) : base(name){}        

        public bool Equals(Permission other)
        {
            return name == other.name;
        }
    }
}
