namespace AccessControlMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            DB.Init();
            new CommandShell("skynet").Start();
        }
    }
}
