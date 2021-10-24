using System;

namespace PublicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                AssemblyInfo.Load(args[0]);
                var publicTypes = AssemblyInfo.nsTypes;
                string res = AssemblyInfo.GetPublicTypesInfo();
                Console.WriteLine(res);

            } 
            else
            {
                Console.WriteLine("Invalid argument");
            }
        }
    }
}
