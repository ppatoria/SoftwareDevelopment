/*
 * The Difference Between The Two
 *********************************

 * The main difference between a "factory method" and an "abstract factory" is that 
 * - the factory method is a single method, 
 * - and an abstract factory is an object. 

 * Because the factory method is just a method, it can be overridden in a subclass, hence 
 * the Factory Method pattern uses inheritance and relies on a subclass to handle the desired object instantiation.
 * The quote assumes that an object is calling it's own factory method here. 
 * Therefor the only thing that could change the return value would be a subclass.

 * The abstract factory is an object that has multiple factory methods on it.
 * With the Abstract Factory pattern, a class delegates the responsibility of object instantiation to another object via composition ...
 * What they're saying is that there is an object A, who wants to make a Foo object. 
 * Instead of making Foo object itself (e.g. with a factory method), it's going get a different object (the abstract factory) to create the Foo object.*/


/************************************************
 *            factory method                    *
 ***********************************************/

class A 
{
    public void doSomething() 
	{
	    Foo f = makeFoo();
	    f.whatever();   
	}

    protected Foo makeFoo() 
	{
	    return new RegularFoo();
	}
}

class B extends A 
{
    protected Foo makeFoo() 
    {
        //subclass is overriding the factory method to return something different
        return new SuperFoo();
    }
}

/************************************************
 *             abstract factory                 *
 ***********************************************/

class A 
{
    private Factory factory;

    public A(Factory factory) 
	{
	    this.factory = factory;
	}

    public void doSomething() 
	{
	    //The concrete class of "f" depends on the concrete class
	    //of the factory passed into the constructor. If you provide a
	    //different factory, you get a different Foo object.
	    Foo f = factory.makeFoo();
	    f.whatever();
	}
}

interface Factory 
{
    Foo makeFoo();
    Bar makeBar();
    Aycufcn makeAmbiguousYetCommonlyUsedFakeClassName();
}

//need to make concrete factories that implement the "Factory" interface here

