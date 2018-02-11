using System;

namespace AccessControlMatrix
{
    class File : NamedObject
    {
        public File(String name, String content) : base(name)
        {
            this.content = content;
        }

        public String Read()
        {
            return content;
        }

        public void Write(String content)
        {
            this.content = content;
        }

        private String content;
    }
}
