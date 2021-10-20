using System;
using System.Runtime.InteropServices;

namespace OSHandleTest
{
    class Program
    {
        [DllImport(
            "kernel32.dll",
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        static int STD_OUTPUT_HANDLE = -11;
        static int STD_INPUT_HANDLE = -10;
        static void Main(string[] args)
        {
            OSHandle handle = new OSHandle(GetStdHandle(STD_INPUT_HANDLE));
            Console.WriteLine("Closing handle...");
            handle.Dispose();
            Console.WriteLine("Hadle is closed");
            //Console.ReadLine();
        }
    }
}
