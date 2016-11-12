using System;

static class Base
{
    static Base ()
	{
	    Console.WriteLine ("Base constructor called");
	}   
    
}

static class Derived : object
{
    static Derived ()
	{
	    Console.WriteLine ("Derived constructor called");	
	}

    public static void Method ()
	{
	    Console.WriteLine ("method called");	
	}
}

class Program
{
    public static void Main ()
	{
	    Derived.Method ();
	}
}


