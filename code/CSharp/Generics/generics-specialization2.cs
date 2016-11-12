using System;
using System.Collections.Generic;
public class SomeClass<T>{
    private readonly List<T> items = new List<T>(); 
    internal void AddInternal(T item){
        items.Add(item);
    }
}

public static class SomeClassExtensions{
    public static void Add<T>(this SomeClass<T> c, T item){
        Console.WriteLine("Default generic Add called");
        c.AddInternal(item);
    } 
    public static void Add(this SomeClass<int> c, int item){
        Console.WriteLine("Specialized Add called");
        if (item <= 0){
            throw new ArgumentOutOfRangeException(
                "item", "Value must be a positive integer.");
        }
        c.AddInternal(item);
    }
}
class program{  
    static void Main(){
        int i = 10;
        SomeFunction<int>(i);
    }
    public static void SomeFunction<T>( T t){
        var cc = new SomeClass<T>();
        cc.Add(t);
    }
}