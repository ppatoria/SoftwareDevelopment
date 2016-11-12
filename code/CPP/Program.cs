using System;
using System.Collections.Generic;
using System.Text;

namespace LockLeveling {

    class Program {

        static void Main(string[] args)
        {
            TryTest(Test0);
            TryTest(Test1);
            TryTest(Test2);
            TryTest(Test3);
            TryTest(Test4);
        }

        delegate void TryDelegate();
        static void TryTest(TryDelegate d)
        {
            try
            {
                d();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        static LeveledLock a = new LeveledLock(10, false, "A");
        static LeveledLock b = new LeveledLock(5, true, "B");
        static LeveledLock c = new LeveledLock(5, true, "C");
        static LeveledLock d = new LeveledLock(5, false, "D");

        static void Test0()
        {
            Console.WriteLine("Test0...");
            using (a.Enter())
            {
                Console.WriteLine("  Got A");
                using (b.Enter())
                {
                    Console.WriteLine("  Got B");
                }
                Console.WriteLine("  Released B");
            }
            Console.WriteLine("  Released A");
        }

        static void Test1()
        {
            Console.WriteLine("Test1...");
            using (b.Enter())
            {
                Console.WriteLine("  Got B");
                using (a.Enter())
                {
                    Console.WriteLine("  Got A");
                }
                Console.WriteLine("  Released A");
            }
            Console.WriteLine("  Released B");
        }

        static void Test2()
        {
            Console.WriteLine("Test2...");
            using (b.Enter())
            {
                Console.WriteLine("  Got B");
                using (c.Enter(true))
                {
                    Console.WriteLine("  Got C");
                }
                Console.WriteLine("  Released C");
            }
            Console.WriteLine("  Released B");
        }

        static void Test3()
        {
            Console.WriteLine("Test2...");
            using (b.Enter())
            {
                Console.WriteLine("  Got B");
                using (d.Enter())
                {
                    Console.WriteLine("  Got D");
                }
                Console.WriteLine("  Released D");
            }
            Console.WriteLine("  Released B");
        }

        static void Test4()
        {
            LeveledLock la = new LeveledLock(10, false, "A");

            Console.WriteLine("Test4...");
            using (la.Enter())
            {
                Console.WriteLine("  Got A");
                using (la.Enter())
                {
                    Console.WriteLine("  Got A");
                }
                Console.WriteLine("  Released A");
            }
            Console.WriteLine("  Released A");
        }

    }
}
