using System;
using System.Threading;

public class CancellationTokenSourceSample
{
    public static 
    void Main(){

        Console.WriteLine("Starting Main Thread");

        CancellationTokenSource clsTokenSrc = new CancellationTokenSource();

        ThreadPool.QueueUserWorkItem(
            x=>AsyncOperation1(clsTokenSrc.Token, 10000000));

        Thread.Sleep(5);
        Console.WriteLine("Cancelling AsyncOperation from Main Thread");
        clsTokenSrc.Cancel();
        Thread.Sleep(1);

        Console.WriteLine("AsyncOperation is cancelled from Main Thread");
        Thread.Sleep(1000);

        Console.WriteLine("Exiting Main Thread");
    }

    public static 
    void AsyncOperation (CancellationToken cancellationToken, object state){

        Console.WriteLine("Starting AsyncOperation Thread");

        int count = (int)state;

        for(int i=0; i<count; i++)
        {
            if(cancellationToken.IsCancellationRequested){
                Console.WriteLine("Cancelling the operation");
                break;
            }else{
                Console.WriteLine(i);                 
            }            
        }            
    }   

    public static 
    void AsyncOperation1 (CancellationToken cancellationToken, object state){

        Console.WriteLine("Starting AsyncOperation Thread");

        int count = (int)state;

        for(int i=0; i<count; i++)
        {
            if(cancellationToken.IsCancellationRequested){
                Console.WriteLine("Cancelling the operation");
                cancellationToken.ThrowIfCancellationRequested();
            }else{
                Console.WriteLine(i);                 
            }            
        }            
    }
}