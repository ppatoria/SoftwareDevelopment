using System;

class MyClass<T> 
{
    public int Foo(int i) { 
        Console.WriteLine("Specialied method called");
        return i;  
    }

    public T Foo<T>(T val) { 
        Console.WriteLine("Generalized method called");
        return val;  
    }
}

static class MyClassSpecialization 
{
    public static int Bar(this MyClass<int> cls, int val) {
        Console.WriteLine("Specialied extension called");
        return cls.Foo(val) ;
    }
    
    public static T Bar<T>(this MyClass<T> cls, T val) {
        Console.WriteLine("Generalized extension called");
        return cls.Foo<T>(val);
    }
}

public class Program
{
    public static void Main(){

        int i = 10;
        somefunc(i);

        // //Now you can write this:
        // var clsInt = new MyClass<int>();
        // int i = 10;
        // Console.WriteLine(clsInt.Foo(i));
        // //Console.WriteLine(clsInt.Bar(i));
        
        
        // var clsDbl = new MyClass<double>();
        // double d = 10;
        // Console.WriteLine(clsDbl.Foo(d));
        // //Console.WriteLine(clsDbl.Bar(d));
    }

    public static void somefunc<T>(T t){       
        var cls = new MyClass<T>();
        Console.WriteLine(cls.Foo(t));
    }
}

