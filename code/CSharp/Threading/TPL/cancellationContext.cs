public sealed class CancellationTokenSource : IDisposable 
{  
    public CancellationTokenSource();

    public Boolean           
    IsCancellationRequested { get; }

    public CancellationToken 
    Token                   { get; }

    public void 
    Cancel ();  // Internally, calls Cancel passing false
    
    public void 
    Cancel (Boolean throwOnFirstException);
    //...
}

public struct CancellationToken 
{  
    public static 
    CancellationToken None { get; } // Very convenient
    
    public Boolean    
    IsCancellationRequested { get; }// Called by non-Task invoked operations
    
    public void       
    ThrowIfCancellationRequested(); // Called by Task-invoked operations

    // WaitHandle is signaled when the CancellationTokenSource is canceled
    public WaitHandle 
    WaitHandle { get; }
    // GetHashCode, Equals, operator== and operator!= members are not shown

    public Boolean 
    CanBeCanceled { get; } // Rarely used

    public CancellationTokenRegistration 
    Register(Action<Object> callback, 
             Object state,
             Boolean useSynchronizationContext);// Simpler overloads not shown
}