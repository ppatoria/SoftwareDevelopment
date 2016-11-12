using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

public class Program
{
    public static void Main() {
        // Put some data into the Main thread's logical call context
        CallContext.LogicalSetData("Name", "Jeffrey");

        // Initiate some work to be done by a thread pool thread
        // The thread pool thread can access the logical call context data
        ThreadPool.QueueUserWorkItem(
            state => Console.WriteLine("Name={0}", 
                                       CallContext.LogicalGetData("Name")));

        Thread.Sleep(1000);

        // Now, suppress the flowing of the Main thread's execution context
        ExecutionContext.SuppressFlow();

        // Initiate some work to be done by a thread pool thread
        // The thread pool thread CANNOT access the logical call context data
        ThreadPool.QueueUserWorkItem(
            state => Console.WriteLine("Name={0}", 
                                       CallContext.LogicalGetData("Name")));
        Thread.Sleep(1000);

        // Restore the flowing of the Main thread's execution context in case
        // it employs more thread pool threads in the future
        ExecutionContext.RestoreFlow();

                // Initiate some work to be done by a thread pool thread
        // The thread pool thread can access the logical call context data
        ThreadPool.QueueUserWorkItem(
            state => Console.WriteLine("Name={0}", 
                                       CallContext.LogicalGetData("Name")));

        //Console.ReadLine();
    }
}