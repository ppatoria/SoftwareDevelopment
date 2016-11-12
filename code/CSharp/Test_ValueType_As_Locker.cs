using System;
using System.Threading;
using System.Threading.Tasks;


class TestValueTypeAsLocker
{
    public static void Main ()
	{	    	
	    int locker = 0;
	    Task t1 = new Task ( () => 
		{
		    lock ((object)locker)
			Console.WriteLine (string.Format("Task1: {0}",++locker));
		});  
	}
}