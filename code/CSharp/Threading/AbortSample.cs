using System;
using System.Threading;
using System.Threading.Tasks;
class AbortSample
{
    public static void Main ()
	{
	    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler (
		(object sender, UnhandledExceptionEventArgs args) =>
		{
		    Console.WriteLine ("AppDomain.UnhandledExceptionHandler:");
		    Console.WriteLine (args.ExceptionObject);
		});

	    Thread task = new Thread( () => 
		{  
		    // try
		    // {		
		    // 	try
		    // 	{
			
			    Console.WriteLine("Worker thread started"); 
			    while(1>0)
				Thread.Sleep (1000);
		    // 	}
		    // 	catch (Exception ex)
		    // 	{
		    // 	    Console.WriteLine ("Inner catch");
		    // 	    Console.WriteLine (ex);
		    // 	}
		    // 	finally
		    // 	{
		    // 	    Console.WriteLine ("Finally");
		    // 	}
		    // }
                    // catch( Exception e)
		    // {
		    // 	Console.WriteLine ("Outer catch");
		    // 	Console.WriteLine (e);
		    // }
		    // finally
		    // {
		    // 	Console.WriteLine ("Finally Finally");
		    // }
		});
	    task.Start ();
	    Thread.Sleep (1000);
	    task.Abort ();	
	    //task.Interrupt ();
	    //task.Join ();
	    Console.WriteLine ("Main is ending");
	    // while(1>0)
	    // 	Thread.Sleep (1000);	 
	    
	}
}


