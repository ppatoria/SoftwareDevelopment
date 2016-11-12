using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.ch08Comparer
{
    /// <summary>
    /// Summary description for AscendingComparer.
    /// </summary>
    public class AscendingComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            // Simplified version using built-in Comparer class:
            // return Comparer.Default.Compare(x, y);
            int result = 0;
            if(x == null && y == null)
                result = 0;
            else if(x == null)
                result = -1;
            else if(y == null)
                result = 1;
            else
            {
                if(x.GetType() != y.GetType())
                    throw new ArgumentException("Invalid comparison");

                IComparable comp = x as IComparable;
                if(comp == null)
                    throw new ArgumentException("Invalid comparison");
                result = comp.CompareTo(y);
            }
            return result;
        }

    }
}
