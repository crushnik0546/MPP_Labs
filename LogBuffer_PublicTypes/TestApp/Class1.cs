using System;
using System.Collections.Generic;
using System.Text;

namespace Class1Space
{
    public class Class1 : Interface1
    {
        public string Field1 = "12";
        public string Property1 { get; set; }

        public string InterfacePropery1 { get; set; }

        public void InterfaceMethod1()
        {
            Console.WriteLine("Метод1 Интерфейса1");
        }

        public Class1()
        {
            Property1 = "Property1 value";
            InterfacePropery1 = "InterfacePropery1 value";
        }

        public void Method1()
        {
            Console.WriteLine("Метод1 Класса1");
        }
    }
}
