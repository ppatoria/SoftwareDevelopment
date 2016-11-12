using System;
using System.Threading;

namespace MSPress.CSharpCoreRef.Threads
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class ThreadsApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*
            Thread currentThread = Thread.CurrentThread;
            Thread workThread = new Thread(new ThreadStart(Work));
            workThread.Start();
            workThread.Join();

            Worker w = new Worker();
            w.Message = "Hello from the worker thread";
            Thread workerThread = new Thread(new ThreadStart(w.PrintMessage));
            workerThread.Priority = ThreadPriority.BelowNormal;
            workerThread.IsBackground = true;
            workerThread.Start();
            bool stoppable = IsThreadStarted(workerThread);
            workerThread.Suspend();
            workerThread.Join();
*/
            for(int n = 0; n < 20; ++n)
            {
                Broken broken = new Broken();
                Thread bw1 = new Thread(new ThreadStart(broken.ThreadProc));
                Thread bw2 = new Thread(new ThreadStart(broken.ThreadProc));
                bw1.Start();
                bw2.Start();
                bw1.Join();
                bw2.Join();
                Console.WriteLine("Total = {0}.", broken.Result);
            }
        }

        static bool IsThreadStarted(Thread aThread)
        {
            bool result = ((aThread.ThreadState & ThreadState.Unstarted) != 0 &&
                            (aThread.ThreadState & ThreadState.Stopped) != 0);
            return result;
        }
        
        static void Work()
        {
            Console.WriteLine("Hello");
        }
    }
}
