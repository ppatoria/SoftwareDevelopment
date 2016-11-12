using System;
public class program
{
    delegate TResult IsGreaterThanDel<out TResult,in TInput> (TInput val);

    // public bool IsGreaterThan (int val){
    //     return val > 10;
    // }

    public TResult IsGreaterThan<TResult,TInput> (TInput val1, TInput val2){
        return val1.Equals(val2);
    }

    public static void Main(){
        program p = new program();
        
        Console.WriteLine(p.IsGreaterThan(10,20));
        Console.WriteLine(p.IsGreaterThan(20,10));
        Console.WriteLine(p.IsGreaterThan(20,20));
        
        //IsGreaterThanDel<bool,int> igt = p.IsGreaterThan;
        //IsGreaterThanDel<bool,int> igt = x => x > 10;
        //Console.WriteLine(igt(11));
        //Console.WriteLine(igt(10));
    }
}