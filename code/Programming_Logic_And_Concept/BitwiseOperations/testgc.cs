using System;

namespace TestXOR
{
    class MyGCCollectClass
    {
        private const int maxGarbage = 1000;

        public static void Test()
        {
            // Put some objects in memory.
            MyGCCollectClass.MakeSomeGarbage();
            Console.WriteLine("Memory used before collection: {0}", GC.GetTotalMemory(false));

            // Collect all generations of memory.
            GC.Collect();
            Console.WriteLine("Memory used after full collection: {0}", GC.GetTotalMemory(true));
        }

        static void MakeSomeGarbage()
        {
            Version vt;

            for (int i = 0; i < maxGarbage; i++)
            {
                // Create objects and release them to fill up memory
                // with unused objects.
                vt = new Version();
            }
        }
    }
}
