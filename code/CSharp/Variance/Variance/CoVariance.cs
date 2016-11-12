using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
namespace Variance
{
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
	
    interface IFirstItem <in T>	
    {
	//T GetFirstItem();
	void InsertFirstItem (T item);	
    }	
	
    class MyList <T> : List <T>, IFirstItem <T>	
    {	
	public T GetFirstItem() {
	    return this[0];
	}

	public void InsertFirstItem (T item) {
	    Add (item);
	}
    }

    class TestCovariance
    {
	public TestCovariance(){
	    MyList <Sedan> sedans = new MyList <Sedan> ();
	    sedans.Add (new Sedan());
	    IFirstItem <Auto> f = sedans;
	    f.InsertFirstItem (new Sedan());
	    PerformService (sedans);

            // Process (sedans);
	}

	// void PerformService<T> (IFirstItem <T> autos) {
	//     Console.WriteLine("generic");
	//     Console.WriteLine (autos.GetFirstItem().ToString());
	// }
		
	// void PerformService (IFirstItem <Auto> autos) {
	//     Console.WriteLine("specialized");
	//     Console.WriteLine (autos.GetFirstItem().ToString());
	// }

	void PerformService (IEnumerable<Auto> autos) {
	    Console.WriteLine("specific");
	    foreach (var auto in autos)
		Console.WriteLine (auto.ToString());
	}
		
        // void Process (IList<Auto> autos)
        // {
        //	foreach (var auto in autos)
        //	Console.WriteLine (autos);
        //}

	// void PerformService (IFirstItem <Auto> autos) {
	//     Console.WriteLine("specific");
	//     foreach (var auto in autos)
	// 	Console.WriteLine (auto.ToString());
	// }
    }

    class Program
    {
	public static void Main (string[] args) {
	    TestCovariance covariance = new TestCovariance();			
	}
    }
}
