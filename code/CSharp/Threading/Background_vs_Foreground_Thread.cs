using System;
using System.Threading;

class Program
{
    /*
     * Thread will run even after main goes out of control. 
     * The application will not terminate.
     */
    public static void ForegroundThreadSample () {
	    try{	
		AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler (
		    (sender, args) => 
		    {	
			Console.WriteLine (args.ExceptionObject);
		    });		

		Thread foregroundThread = new Thread( () => {
			Console.WriteLine ("Entering Thread");
			try {
			    for (int i=0; i<int.MaxValue; i++)			    
				Console.WriteLine (i);			    
			} catch (Exception ex) {
			    Console.WriteLine (ex.ToString());
			}
			Console.WriteLine ("Exiting Thread");
		    });

		foregroundThread.Start();

		Thread.Sleep (1000);
	    }catch(Exception ex){
		Console.WriteLine (ex);
	    }
        }


    /*
     * The thread will terminated once main goes out of scope. 
     * The application will terminate and not wait for the foreground thread to complete.
     * There will be no exception even if it terminates unexpectedly in-between when main finishes. 
     */
    public static void BackgroundThreadSample () {
	    try{	
		AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler ( 
		    (sender, args) =>
		    {
			Console.WriteLine (args.ExceptionObject);
		    });		

		Thread backgroundThread = new Thread( () => {
			Console.WriteLine ("Entering Thread");
			try {
			    for (int i=0; i<int.MaxValue; i++)			    
				Console.WriteLine (i);
			    
			} catch (Exception ex) {
			    Console.WriteLine (ex.ToString());
			}
			Console.WriteLine ("Exiting Thread");
		    });

		backgroundThread.IsBackground = true;

		backgroundThread.Start();

		Thread.Sleep (1000);
	    }catch(Exception ex){
		Console.WriteLine (ex);
	    }
        }

    public static void Main ()
	{
	    BackgroundThreadSample ();
	}
}