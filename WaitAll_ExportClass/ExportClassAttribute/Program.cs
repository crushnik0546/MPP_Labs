using System;
using System.Reflection;

namespace ExportClassAttributeProg
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (!LoadExportClasses(args[0]))
                {
                    Console.WriteLine("AssemblyInfo.Load failed");
                }
            }
            else
            {
                Console.WriteLine("Invalid argument");
            }
        }

        static bool LoadExportClasses(string path)
        {
            Assembly asm;
            try
            {
                asm = Assembly.LoadFile(path);
                Type[] types = asm.GetTypes();

                Console.WriteLine("Classes with ExportClassAttribute:");

                foreach(Type type in types)
                {
                    if (type.IsClass && Attribute.IsDefined(type, typeof(ExportClassAttribute)))
                    {
                        Console.WriteLine($" Class {type.Name}");

                        ExportClassAttribute exportClass = (ExportClassAttribute)Attribute.GetCustomAttribute(type, 
                            typeof(ExportClassAttribute));

                        if (exportClass != null)
                        {
                            Console.WriteLine($"   Description = \"{exportClass.Description}\"");
                        }

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
