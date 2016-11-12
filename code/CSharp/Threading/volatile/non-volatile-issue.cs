using System;
using System.Threading;
using System.Threading.Tasks;
class Worker
{
    private bool stop = false;
    private Task task;

    public void Start()
    {
        task = Task.Run(new Action(Loop));
    }

    private void Loop()
    {
        while (!stop)
            ;
    }

    public void Stop()
    {
        stop = true;
        task.Wait();
    }
}

class Program
{
    public static void Main()
	{
	    var worker = new Worker();
	    worker.Start();
	    Thread.Sleep(1000);
	    worker.Stop();	   
	}
}