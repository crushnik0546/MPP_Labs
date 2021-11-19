using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DynamicListGeneric
{
    public class BookComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return 1;
            else if (y == null)
                return -1;
            else
                return ((Book)x).Year.CompareTo(((Book)y).Year);
        }
    }
}
