using System;
using System.Threading;

public static class Program {
   public static void Main() {
      Boolean createdNew;

      // Try to create a kernel object with the specified name
      using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out createdNew)) {
         if (createdNew) {
             Console.WriteLine("Launched application");
             Console.ReadKey();
         } else {
             Console.WriteLine("Instance already running");
         }
      }
   }
}