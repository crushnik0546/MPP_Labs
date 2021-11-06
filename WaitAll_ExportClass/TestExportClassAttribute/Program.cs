using System;
using ExportClassAttributeProg;

namespace TestExportClassAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    [ExportClass(Description = "First class with Export Attribute")]
    public class Writer
    {

    }

    [ExportClass()]
    public class Reader
    {

    }

    public class Copier
    {

    }

    [ExportClass(Description = "Third class with Export Attribute")]
    public class Monitor
    {

    }
}
