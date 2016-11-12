using System;
using System.Threading;
internal sealed class SimpleWaitLock : IDisposable {
    private readonly AutoResetEvent m_available;

    public SimpleWaitLock() {
        m_available = new AutoResetEvent(true); // Initially free
    }

    public void Enter() {      
        m_available.WaitOne();                  // Block in kernel until resource available
    }

    public void Leave() {      
        m_available.Set();                     // Let another thread access the resource
    }

    public void Dispose() { m_available.Dispose(); }
}

public class Program{
	public static void Main(){
			Console.WriteLine("test");
			while(Console.ReadLine() != "q"){
			}
			Console.ReadLine();
	}
}