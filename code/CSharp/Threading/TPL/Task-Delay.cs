internal static class DelayDemo {
   public static void Main() {
      Console.WriteLine("Checking status every 2 seconds");
      Status();
      Console.ReadLine();   // Prevent the process from terminating
   }

   // This method can take whatever parameters you desire
   private static async void Status() {
      while (true) {
         Console.WriteLine("Checking status at {0}", DateTime.Now);
         // Put code to check status here...

         // At end of loop, delay 2 seconds without blocking a thread
         await Task.Delay(2000); // await allows thread to return
         // After 2 seconds, some thread will continue after await to loop around
      }
   }
}