using System;
using System.Collections.Generic;

// A partially specified open type
internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue> 
{
}

public static class Program 
{
    public static 
    void Main () {
        Object o = null;
        
        Type t   = typeof (Dictionary<,>);         // Dictionary<,> is open type having 2 type parameters
        o        = CreateInstance (t);             // Try to create an instance of this type (fails)
        Console.WriteLine ("--");

        t        = typeof (DictionaryStringKey<>); //DictionaryStringKey<> is open type having 1 type parameter
        o        = CreateInstance (t);             // Try to create an instance of this type (fails)
        Console.WriteLine ("--");

        t        = typeof (DictionaryStringKey<Guid>);     //DictionaryStringKey<Guid> is a closed type
        o        = CreateInstance (t);                     // Try to create an instance of this type (succeeds)
        Console.WriteLine ("Object type =" + o.GetType()); // Prove it actually worked
        Console.WriteLine ("--");
    }

    private static Object CreateInstance (Type t) {
        Object o = null;
        try {
            o = Activator.CreateInstance (t);
            Console.Write ("Created instance of {0}", t.ToString());   
        }catch (ArgumentException e) {
            Console.WriteLine (e.Message);
        }
        return o;
    }
}