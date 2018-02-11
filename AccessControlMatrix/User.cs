using System;

namespace AccessControlMatrix
{
    public class User : NamedObject
    {
        public User(String name, String password = "123", bool isAdmin = false) : base(name)
        {
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public bool CheckPassword(String password)
        {
            return this.password == password;
        }

        private String password;
        public bool isAdmin { get; }
    }
}
