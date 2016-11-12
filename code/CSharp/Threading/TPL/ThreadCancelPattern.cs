class RulyCanceler
{
  object _cancelLocker = new object();
  bool _cancelRequest;
  public bool IsCancellationRequested
  {
    get { lock (_cancelLocker) return _cancelRequest; }
  }
 
  public void Cancel() { lock (_cancelLocker) _cancelRequest = true; } 
 
  public void ThrowIfCancellationRequested()
  {
    if (IsCancellationRequested) throw new OperationCanceledException();
  }
}

class Test
{
  static void Main()
  {
    var canceler = new RulyCanceler();
    new Thread (() => {
                        try { Work (canceler); }
                        catch (OperationCanceledException)
                        {
                          Console.WriteLine ("Canceled!");
                        }
                      }).Start();
    Thread.Sleep (1000);
    canceler.Cancel();               // Safely cancel worker.
  }
 
  static void Work (RulyCanceler c)
  {
    while (true)
    {
      c.ThrowIfCancellationRequested();
      // ...
      try      { OtherMethod (c); }
      finally  { /* any required cleanup */ }
    }
  }
 
  static void OtherMethod (RulyCanceler c)
  {
    // Do stuff...
    c.ThrowIfCancellationRequested();
  }
}