// This class is used by the LinkedList class
public class Node 
{
   internal Node m_next; // Other members not shown
}

public sealed class LinkedList 
{
   private Node m_head;

   public void Add(Node newNode) {      
      newNode.m_next = m_head; // The following two lines perform very fast reference assignments
      m_head = newNode;
   }
}

public sealed class LinkedList 
{
   private SomeKindOfLock m_lock = new SomeKindOfLock();
   private Node m_head;

   public void Add(Node newNode) {
      m_lock.Enter();  
          newNode.m_next = m_head;// The following two lines perform very fast reference assignments
          m_head = newNode;
      m_lock.Leave();
   }
}

internal static class SomeType 
{
    public static Int32 x = 0;
}

private static void OptimizedAway() 
{   
    Int32 value = (1 * 100) - (50 * 2);   // Constant expression is computed at compile time resulting in zero    
    for (Int32 x = 0; x < value; x++)     // If value is 0, the loop never executes        
        Console.WriteLine("Jeff");        // There is no need to compile the code in the loop because it can never execute    
}

internal static class StrangeBehavior 
{    
    private static Boolean s_stopWorker = false;// As you'll see later, mark this field as volatile to fix the problem

    public static void Main () {
        Console.WriteLine     ("Main: letting worker run for 5 seconds");
        Thread t              = new Thread (Worker);
        t.Start               ();
        Thread.Sleep          (5000);
        s_stopWorker          = true;
        Console.WriteLine     ("Main: waiting for worker to stop");
        t.Join                ();
    }
    
    private static void Worker (Object o) {
        Int32 x           = 0;
        while             (!s_stopWorker) x++;
        Console.WriteLine ("Worker: stopped when x={0}", x);
    }
}