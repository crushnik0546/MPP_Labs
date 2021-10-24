using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PublicTypes
{
    public class NamespaceInfo
    {
        public List<Type> interfaces;
        public List<Type> classes;

        public NamespaceInfo()
        {
            interfaces = new List<Type>();
            classes = new List<Type>();
        }

        //public List<>
    }
}
