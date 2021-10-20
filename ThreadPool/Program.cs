using System;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments");
            }
            else
            {
                try
                {
                    Copy copier = new Copy(30);
                    copier.Run(args[0], args[1]);
                    copier.WaitAll();
                    copier.PrintInfo();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
