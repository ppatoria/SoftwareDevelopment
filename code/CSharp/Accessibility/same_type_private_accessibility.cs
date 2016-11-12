using System;
class cls {
    private int i;
    public int I {
	get { return i;	 } 
	set { i = value; }
    }
    public cls() {}
    public cls (cls right) { 
	i = right.i;	    // No Error: Private member of same type is accessible
    }
}

class program {
    public static void Main () {
	cls a = new cls ();
	a.I = 10;
	cls b = new cls (a);
	Console.WriteLine (b.I);	    
    }
}