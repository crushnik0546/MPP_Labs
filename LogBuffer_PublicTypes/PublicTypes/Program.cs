using System;

namespace PublicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string ret = AssemblyInfo.Load(args[0]);
                if (ret == "")
                {
                    var publicTypes = AssemblyInfo.nsTypes;
                    string res = AssemblyInfo.GetPublicTypesInfo();
                    Console.WriteLine(res);
                }
                else
                {
                    Console.WriteLine($"AssemblyInfo.Load Failed with ex: {ret}");
                }
            } 
            else
            {
                Console.WriteLine("Invalid argument");
            }
        }
    }
}
