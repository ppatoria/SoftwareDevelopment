using System;
using System.Threading;

internal static class StrangeBehavior 
{    
    // As you'll see later, mark this field as volatile to fix the problem
    private static Boolean s_stopWorker = false;

    public static void Main () {
        Console.WriteLine ("Main: letting worker run for 5 seconds");
        Thread t = new Thread (Worker);
        t.Start ();
        Thread.Sleep (10);
        Console.WriteLine("Stopping worker");
        s_stopWorker = true;
        Thread.Sleep(1);
        Console.WriteLine ("Main: waiting for worker to stop");
        t.Join ();
    }
    
    private static void Worker (Object o) {
        Int32 x = 0;
        while (!s_stopWorker) Console.Write(" {0} ", x++);
        Console.WriteLine ("Worker: stopped when x={0}", x);
    }
}