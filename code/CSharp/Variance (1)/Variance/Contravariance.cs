using System;

class Auto 
{ 
    public override string ToString() {
	return "Auto.ToString()";
    }
}
	
class Sedan: Auto 
{	
    public override string ToString() {
	return "Sedan.ToString()";
    }
}


interface IEqual <T>
{
    bool IsEqual(T x, T y);
}

class Comparer <T> : IEqual <T>
{
    public bool IsEqual(T x, T y)
	{
	    return true;
	}
}
class GenericContravariance
{
    void Example ()
	{
	    Comparer <Auto> comparer = new Comparer <Auto>();
	    //Comparer <Sedan> comparer = new Comparer <Sedan>();
	    TestEquality(comparer);
	}
    // void TestEquality(IEqual <Auto> equalizer)    
    // 	{
    // 	    Auto a1 = new Auto ();
    // 	    Auto a2 = new Sedan ();
    // 	    Console.WriteLine (equalizer.IsEqual (a1 , a2));
    // 	}

    
    void TestEquality (IEqual <Sedan> equalizer)
	{
	    Sedan a1 = new Sedan ();
	    Sedan a2 = new Sedan ();
	    Console.WriteLine (equalizer.IsEqual (a1 , a2));
	}
    public static void Main ()
	{
	    GenericContravariance c = new GenericContravariance ();
	    c.Example ();
	}
}

