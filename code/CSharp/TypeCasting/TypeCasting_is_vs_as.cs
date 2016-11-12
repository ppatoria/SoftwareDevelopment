using System;

class Program
{
    public Static void Main()
	{

	    Function(new object);

	    string str = null;
	    Function (str); 

	}

    static void Function(object o)
	{
	    // I swear o is a string
	    string s = (string)o; // 1
	    //-OR-
	    string s = o as string; // 2
	    // -OR-
	    string s = o.ToString(); // 3
	}
}
/*
 * 1.Throws InvalidCastException if o is not a string. Otherwise, assigns o to s, even if o is null.
 * 2.Assigns null to s if o is not a string or if o is null. For this reason, you cannot use it with value types (the operator could never return null in that case). Otherwise, assigns o to s.
 * 3.Causes a NullReferenceException of o is null. Assigns whatever o.ToString() returns to s, no matter what type o is.
*/