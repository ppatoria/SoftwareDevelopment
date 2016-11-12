using System;
public class program
{
    public delegate 
    TResult MyFunc<in  T, out TResult>  (T t);
    
    public static 
    string FuncImpl(int i){
        return i.ToString();        
    }

    public static 
    void func(MyFunc<int,string> myfunc, int val){
        Console.WriteLine(myfunc(val));
    }

    public static 
    void Main(){        
        func( x => {return x.ToString();}, 
              20);
        //MyFunc<int,string> func = FuncImpl;
        //Console.WriteLine(func(10));
    }

}