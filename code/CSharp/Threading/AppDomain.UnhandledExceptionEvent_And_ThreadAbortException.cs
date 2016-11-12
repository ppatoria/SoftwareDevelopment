using System;
using System.Threading;

class Program {

    private static void thread() {
	while (true){}
    }

    static void Main(string[] args) {
	AppDomain.CurrentDomain.UnhandledException 
	    += new UnhandledExceptionEventHandler(handler);
	Thread th = new Thread(new ThreadStart(thread));
	th.Start();
	Thread.Sleep(1000);
        
         /* 
	 *ThreadAbortException is thrown and although  it is unhandled 
	 * but it is not propogated to AppDomain.UnhandledExceptionEventHandler.
	 */
	th.Abort();   
	Thread.Join();
    }

    static void handler(object sender, UnhandledExceptionEventArgs e) {
	System.Console.WriteLine("Unhandled exception.");
    }
}
