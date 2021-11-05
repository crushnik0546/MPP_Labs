using System;
using System.Collections.Generic;

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
    }
}
