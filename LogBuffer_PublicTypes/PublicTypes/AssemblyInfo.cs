using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PublicTypes
{
    public static class AssemblyInfo
    {
        private static Assembly asm = null;
        private static List<Type> publicTypes= null;
        public static SortedDictionary<string, NamespaceInfo> nsTypes = new SortedDictionary<string, NamespaceInfo>();

        public static bool Load(string assemblyPath)
        {
            try
            {
                asm = Assembly.LoadFile(assemblyPath);
                GetPublicTtypes();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private static void GetPublicTtypes()
        {
            Type[] allTypes = asm.GetTypes();
            publicTypes = new List<Type>();

            foreach(Type type in allTypes)
            {
                if (type.IsPublic)
                {
                    publicTypes.Add(type);
                    if (!nsTypes.ContainsKey(type.Namespace))
                    {
                        nsTypes.Add(type.Namespace, new NamespaceInfo());
                    }

                    if (type.IsInterface)
                    {
                        nsTypes[type.Namespace].interfaces.Add(type);
                    }
                    else if (type.IsClass)
                    {
                        nsTypes[type.Namespace].classes.Add(type);
                    }
                }
            }
        }

        private static StringBuilder GetClassMembers(Type cl)
        {
            MemberInfo[] members = cl.GetMembers();
            List<MemberInfo> fields = new List<MemberInfo>();
            List<MemberInfo> properties = new List<MemberInfo>();
            List<ConstructorInfo> constructors = new List<ConstructorInfo>();
            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (var member in members)
            {
                if (member.MemberType == MemberTypes.Field)
                {
                    fields.Add(member);
                }
                if (member.MemberType == MemberTypes.Property)
                {
                    properties.Add(member);
                }
                if (member.MemberType == MemberTypes.Constructor)
                {
                    constructors.Add((ConstructorInfo)member);
                }
                if (member.MemberType == MemberTypes.Method)
                {
                    methods.Add((MethodInfo)member);
                }
            }

            fields.Sort(delegate (MemberInfo x, MemberInfo y)
            {
                return x.Name.CompareTo(y.Name);
            });

            properties.Sort(delegate (MemberInfo x, MemberInfo y)
            {
                return x.Name.CompareTo(y.Name);
            });

            constructors.Sort(delegate (ConstructorInfo x, ConstructorInfo y)
            {
                return x.Name.CompareTo(y.Name);
            });

            methods.Sort(delegate (MethodInfo x, MethodInfo y)
            {
                return x.Name.CompareTo(y.Name);
            });

            StringBuilder result = new StringBuilder();

            if (fields.Count != 0)
            {
                result.AppendLine("  |  | Fields: ");
                foreach(var field in fields)
                {
                    result.AppendLine($"  |  |  | {field.Name}");
                }
            }

            if (properties.Count != 0)
            {
                result.AppendLine("  |  | Properties: ");
                foreach (var property in properties)
                {
                    result.AppendLine($"  |  |  | {property.Name}");
                }
            }

            if (constructors.Count != 0)
            {
                result.AppendLine("  |  | Constructors: ");
                foreach (var constructor in constructors)
                {
                    result.AppendLine($"  |  |  | {constructor.Name}");
                    if (constructor.GetParameters().Length != 0)
                    {
                        result.AppendLine($"  |  |  |  | Parameters:");
                        foreach (ParameterInfo pi in constructor.GetParameters())
                        {
                            result.AppendLine($"  |  |  |  |  | Parameter: Type = {pi.ParameterType}, Name = {pi.Name}");
                        }
                    }
                }
            }

            if (methods.Count != 0)
            {
                result.AppendLine("  |  | Methods: ");
                foreach (var method in methods)
                {
                    result.AppendLine($"  |  |  | {method.Name}");
                    if (method.GetParameters().Length != 0)
                    {
                        result.AppendLine($"  |  |  |  | Parameters:");
                        foreach (ParameterInfo pi in method.GetParameters())
                        {
                            result.AppendLine($"  |  |  |  |  | Parameter: Type = {pi.ParameterType}, Name = {pi.Name}");
                        }
                    }
                }
            }

            return result;
        }

        public static string GetPublicTypesInfo()
        {
            StringBuilder result = new StringBuilder();

            foreach(var ns in nsTypes)
            {
                ns.Value.classes.Sort(delegate (Type x, Type y)
                {
                    return x.Name.CompareTo(y.Name);
                });

                ns.Value.interfaces.Sort(delegate (Type x, Type y)
                {
                    return x.Name.CompareTo(y.Name);
                });

                result.AppendLine($"NAMESPACE: {ns.Key}");

                if (ns.Value.interfaces.Count != 0)
                {
                    result.AppendLine("Interfaces: ");
                    foreach (var inf in ns.Value.interfaces)
                    {
                        result.AppendLine($"  | {inf.Name}");
                        result.Append(GetClassMembers(inf));
                    }
                }
                
                if (ns.Value.classes.Count != 0)
                {
                    result.AppendLine("Classes:");
                    foreach (var cl in ns.Value.classes)
                    {
                        result.AppendLine($"  | {cl.Name}");
                        result.Append(GetClassMembers(cl));
                    }
                }
               
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
