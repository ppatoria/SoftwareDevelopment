using System;
using System.Threading;
using System.Threading.Tasks;

internal sealed class SimpleHybridLock : IDisposable {
    
    private Int32 m_waiters = 0;    

    private readonly AutoResetEvent m_waiterLock = new AutoResetEvent(false);

    public void Enter() {        
        if (Interlocked.Increment(ref m_waiters) == 1){
            Console.WriteLine("SimpleHybridLock:Enter");
            return; 
        }
        Console.WriteLine("AutoResetEvent:WaitOne Enter");
        m_waiterLock.WaitOne();  // Bad performance hit here        
        Console.WriteLine("AutoResetEvent:WaitOne Leave");
    }

    public void Leave() {        
        if (Interlocked.Decrement(ref m_waiters) == 0){
            Console.WriteLine("SimpleHybridLock:Leave");
            return; // No other threads are waiting, just return        
        }
        Console.WriteLine("AutoResetEvent:Set Enter");
        m_waiterLock.Set();  // Bad performance hit here
        Console.WriteLine("AutoResetEvent:Set Leave");
    }

    public void Dispose() { m_waiterLock.Dispose(); }
}

public class program
{
    static int value = 10;
    public static void Main(){
        SimpleHybridLock simpleLock = new SimpleHybridLock();        
        Task.Run(() => {
                Console.WriteLine("Entered ThreadOne");
                Console.WriteLine("ThreadOne.SimpleHybridLock.Enter");
                simpleLock.Enter();
                for(int i=0; i<10; i++){
                    value = i;
                    Thread.Sleep(100);
                }                
                Console.WriteLine(value);
                simpleLock.Leave();
                Console.WriteLine("ThreadOne.SimpleHybridLock.Leave");
            });
        // Task.Run(() => {
        //         Console.WriteLine("Entered ThreadTwo");
        //         Console.WriteLine("ThreadTwo.SimpleHybridLock.Enter");
        //         simpleLock.Enter();
        //         for(int i=10; i<20; i++){
        //             value = i;
        //             Thread.Sleep(100);
        //         }
        //         Console.WriteLine(value);
        //         simpleLock.Leave();
        //         Console.WriteLine("ThreadTwo.SimpleHybridLock.Leave");
        //     });

        Thread.Sleep(60000);
    }
}