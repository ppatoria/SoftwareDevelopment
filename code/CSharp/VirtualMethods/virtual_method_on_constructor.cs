using System;

class Base
{
    public Base ()
	{
	    Console.WriteLine ("Base:Ctor");
	    virtual_method ();
	}

    public virtual void virtual_method ()
	{	    
	    Console.WriteLine ("base virtual method called");
	}
}

class Derived : Base
{
    public Derived ()
	{
	    Console.WriteLine ("derived class constructor");
	}

    public override void virtual_method ()
	{
	    Console.WriteLine ("derived virtual method called");
	}
}

class program
{   
    public static void Main()
	{
	    Base b = new Derived ();	    
	}
}