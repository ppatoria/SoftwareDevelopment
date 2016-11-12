using System;
using System.Threading;

namespace MSPress.CSharpCoreRef.ThreadPoolTest
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class ThreadPoolTestApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SimpleThread();
			FibonacciWorkItem fwi = new FibonacciWorkItem(25);
			ThreadPool.QueueUserWorkItem(new WaitCallback(fwi.Calculate), 25);
			Thread.Sleep(3000);
        }

        static void SimpleThread()
        {
            Calculate calc = new Calculate(2.0d);
            Thread worker = new Thread(new ThreadStart(calc.Circumference));
            worker.Start();
            worker.Join();
            Console.WriteLine("{0}", calc.Result);
        }
    }
}
