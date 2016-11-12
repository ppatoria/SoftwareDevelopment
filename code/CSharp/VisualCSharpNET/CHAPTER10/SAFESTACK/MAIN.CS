using System;
using System.Threading;
using System.Collections;

namespace MSPress.CSharpCoreRef.SafeStack
{
	class StackTestApp
	{
		[STAThread]
		static void Main(string[] args)
		{
            // Stack causes failures when multithreaded
            //_numberStack = new Stack();

            // SafeStack okay for multithreaded use.
            //_numberStack = new SafeStack();

            // Synchronized stack okay for multithreaded use
            _numberStack = Stack.Synchronized(new Stack());

            Thread t1 = new Thread(new ThreadStart(ThreadProc));
            Thread t2 = new Thread(new ThreadStart(ThreadProc));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
		}


        const int MaxIterations = 2000; //20
        const int MaxSmallLoop = 500; //50

        protected static Stack _numberStack;

        public static void ThreadProc()
        {
            for(int loop = 0; loop < MaxIterations; ++loop)
            {
                for(int n = 0; n < MaxSmallLoop; ++n)
                {
                    Console.Write(" push {0}", n);
                    _numberStack.Push(n);
                    Console.WriteLine("-");
                }
                int j = MaxSmallLoop;
                while(j-- > 0)
                    Console.Write(" pop {0}", _numberStack.Pop());
                Console.WriteLine("\nstack depth - {0}", _numberStack.Count);
            }
        }
	}
}
