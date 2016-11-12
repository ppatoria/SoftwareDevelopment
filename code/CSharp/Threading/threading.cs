using System;
using System.Threading;

public static class Program 
{
   public static void Main() {
      Console.WriteLine            ("Main thread: queuing an asynchronous operation");
      ThreadPool.QueueUserWorkItem (ComputeBoundOp, 5);
      Console.WriteLine            ("Main thread: Doing other work here...");
      Thread.Sleep                 (10000);  // Simulating other work (10 seconds)
      Console.WriteLine            ("Hit <Enter> to end this program...");
      Console.ReadLine             ();
   }

    /** 
     * This method's signature must match the WaitCallback delegate
     * This method is executed by a thread pool thread   
     * When this method returns, the thread goes back
     * to the pool and waits for another task
     **/
    private static void ComputeBoundOp(Object state) {
      Console.WriteLine ("In ComputeBoundOp: state={0}", state);
      Thread.Sleep      (1000);  // Simulates other work (1 second)
   }
   
}