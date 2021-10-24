using System;
using Class1Space;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 cl = new Class1();
            Console.WriteLine(cl.Property1);
            Console.WriteLine(cl.InterfacePropery1);
            cl.Property1 = "Property1 new value";
            cl.InterfacePropery1 = "InterfacePropery1 new value";
            Console.WriteLine(cl.Property1);
            Console.WriteLine(cl.InterfacePropery1);
            cl.InterfaceMethod1();
            cl.Method1();

        }
    }
}
