using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
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

        CancellationTokenSource cancelTokenSrc = new CancellationTokenSource();
        
        Task<Int32> t = new Task<Int32>( 
            () => { return Sum(100000000, cancelTokenSrc.Token);},
            cancelTokenSrc.Token);       
        
        t.Start();
        
        cancelTokenSrc.Cancel();
        
        Thread.Sleep(1000);
        
        try{
            Console.WriteLine("Waiting...............");
            t.Wait(); 
        }catch(AggregateException ex){        
            ex.Handle(x=> { Console.WriteLine(x.ToString()); return true;});
        } 
        try{
            Console.WriteLine("Extracting Result");
            Console.WriteLine("The Sum is: " + t.Result); // An Int32 value            
        }catch(AggregateException ex){        
            ex.Handle(x=> { Console.WriteLine(x.ToString()); return true;});
        }
    }
}