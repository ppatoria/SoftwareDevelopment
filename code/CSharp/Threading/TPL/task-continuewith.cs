using System;
using System.Threading;
using System.Threading.Tasks;

class program
{
    private static Int32 Sum(Int32 n, CancellationToken cancelToken) {

        Int32 sum = 0;

        for (; n > 0; n--){
            cancelToken.ThrowIfCancellationRequested();
            checked{ sum += n; }            
        }

        return sum;
    }

    public static void Main(){
        

        CancellationTokenSource clsTokenSrc = new CancellationTokenSource();

        Task<Int32> task = new Task<Int32>( () =>{ return Sum(100000000, clsTokenSrc.Token); } , clsTokenSrc.Token);

        task.Start();

        clsTokenSrc.Cancel();

       
        task.ContinueWith(t => { Console.WriteLine(t.Result); },  
                          TaskContinuationOptions.OnlyOnRanToCompletion);        

        task.ContinueWith( 
            t => 
            { 
                AggregateException ex = (t.Exception as AggregateException);
                ex.Handle( x => 
                    { 
                        Console.WriteLine("Exception catched in Main:{0}", x.ToString());
                        return true;
                    });
            },
            TaskContinuationOptions.OnlyOnFaulted);    
        
        task.ContinueWith(t => 
            { 
                Console.WriteLine("Task Cancelled ");
            },
            TaskContinuationOptions.OnlyOnCanceled);
        
        while(task.IsCompleted)
        {            
            Thread.Sleep(1);
        }
    }
    
}