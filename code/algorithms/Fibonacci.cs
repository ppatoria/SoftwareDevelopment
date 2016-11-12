using System;
class FibonacciSequence
{
    public int RecursiveFibonacci (int n)
	{	    
	    if (n == 0 || n == 1) return n;
	    return RecursiveFibonacci (n-1) + RecursiveFibonacci (n-2);
	}

    public int Fibonacci (int n)
	{
	    int first  = 0;
	    int second = 1;
	    for (int i=0; i<n; i++)
	    {
		int temp = first;
		first = second;
		second += temp;
	    }
	    return first;
	}

    public static void Main ()
	{
	    FibonacciSequence f = new FibonacciSequence ();
	    //Console.WriteLine (f.RecursiveFibonacci (47));
	    Console.WriteLine (f.Fibonacci (47));
	}
}

6

f(5)                      +  f(4)
f(4)               + f(3)
f(3)        + f(2) 
f(2) + F(1)  