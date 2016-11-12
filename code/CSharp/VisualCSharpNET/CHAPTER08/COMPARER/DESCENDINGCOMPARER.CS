using System;
using System.Collections;

namespace MSPress.CSharpCoreRef.ch08Comparer
{
    public class DescendingComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            int result = 0;
            if(x == null && y == null)
                result = 0;
            else if(y == null)
                result = -1;
            else if(x == null)
                result = 1;
            else
            {
                if(x.GetType() != y.GetType())
                    throw new ArgumentException("Invalid comparison");

                IComparable comp = y as IComparable;
                if(comp == null)
                    throw new ArgumentException("Invalid comparison");
                result = comp.CompareTo(x);
            }
            return result;
        }
    }
}
