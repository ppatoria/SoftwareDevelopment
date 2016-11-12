internal static class TimerDemo {
   private static Timer s_timer;

   public static void Main() {
      Console.WriteLine("Checking status every 2 seconds");

      // Create the Timer ensuring that it never fires. This ensures that
      // s_timer refers to it BEFORE Status is invoked by a thread pool thread
      s_timer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);

      // Now that s_timer is assigned to, we can let the timer fire knowing
      // that calling Change in Status will not throw a NullReferenceException
      s_timer.Change(0, Timeout.Infinite);

      Console.ReadLine();   // Prevent the process from terminating
   }

   // This method's signature must match the TimerCallback delegate
   private static void Status(Object state) {
      // This method is executed by a thread pool thread
      Console.WriteLine("In Status at {0}", DateTime.Now);
      Thread.Sleep(1000);  // Simulates other work (1 second)

      // Just before returning, have the Timer fire again in 2 seconds
      s_timer.Change(2000, Timeout.Infinite);

      // When this method returns, the thread goes back
      // to the pool and waits for another work item
   }
}