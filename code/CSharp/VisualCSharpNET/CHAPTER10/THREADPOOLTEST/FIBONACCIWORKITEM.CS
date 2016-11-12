using System;
using System.Threading;

namespace MSPress.CSharpCoreRef.ThreadPoolTest
{
    /// <summary>
    /// Summary description for FibonacciWorkItem.
    /// </summary>
    public class FibonacciWorkItem
    {
        int _maxIterations;
        public FibonacciWorkItem(int maxIterations)
        {
            _maxIterations = maxIterations;
        }

        public void Calculate(object obj)
        {
            int x = 0;
            int y = 0;
            int fib = 0;
            for(int n = 0; n < _maxIterations; ++n)
            {
                Console.WriteLine(fib);
                x = y;
                if(fib == 0)
                    y = 1;
                else
                    y = fib;
                fib = x + y;
            }
        }
    }
}
