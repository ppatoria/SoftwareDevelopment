using System;
class MyClass<T> {
    public int Foo(int i) { 
        Console.WriteLine("Specialied method called");
        return i;  
    }
    public T Foo<T>(T val) { 
        Console.WriteLine("Generalized method called");
        return val;  
    }
    public T Foo<T>(ref T val) { 
        Console.WriteLine("Generalized method with condition called");
        return val;  
    }
}
static class MyClassSpecialization {
    public static int Bar(this MyClass<int> cls, int val) {
        Console.WriteLine("Specialied extension called");
        return cls.Foo(val) ;
    }    
    public static T Bar<T>(this MyClass<T> cls, T val) {
        Console.WriteLine("Generalized extension called");
        return cls.Foo<T>(val);
    }
}
public class Program{
    public static void Main(){
        int i = 99;
        somefunc(i);
    }
    public static void somefunc<T>(T t){       
        // var cls = new MyClass<T>();
        // Console.WriteLine(cls.Bar(t));

        var cls1 = new MyClass<T>();
        Console.WriteLine(cls1.Foo(ref t));
    }
}

