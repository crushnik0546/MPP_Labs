using System;
using System.Collections.Generic;
using System.Text;

namespace ExportClassAttributeProg
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExportClassAttribute: Attribute
    {
        public string Description;
        public ExportClassAttribute() { }

        public ExportClassAttribute(string Description)
        {
            this.Description = Description;
        }
    }
}
