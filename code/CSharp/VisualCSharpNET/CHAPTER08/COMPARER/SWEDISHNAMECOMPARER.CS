using System;
using System.Collections;
using System.Globalization;

namespace MSPress.CSharpCoreRef.ch08Comparer
{
	public class SwedishNameComparer: IComparer
	{
        public int Compare(object x, object y)
        {
            CultureInfo ci = new CultureInfo("sv");
            CaseInsensitiveComparer aComparer = null;
			aComparer = new CaseInsensitiveComparer(ci);
            return aComparer.Compare(x, y);
        }
	}
}
