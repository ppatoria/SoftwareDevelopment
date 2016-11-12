using System;

//delegate T Plus<T>(T t1, T t2); 
//delegate TResult Plus<in T, out TResult>(T t1, T t2); 

class Plus<T>
{
    T operator () (T t1, T t2)
        {
            return t1 + t2;
        }
}

class Program
{
    public static void Main()
        {
            //Plus<int> myplus = (x,y) => { return x + y; };
            Plus<int> myplus;
            Console.WriteLine(myplus(10,20));
        }
}