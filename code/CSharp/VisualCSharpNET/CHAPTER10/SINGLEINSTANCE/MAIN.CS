using System;
using System.Threading;

namespace MSPress.CSharpCoreRef.SingleInstance
{
    class SingleInstanceApp
    {
        [STAThread]
        static void Main(string[] args)
        {
            string mutexName = "MSPress.CSharpCoreRef.SingleInstance";
            using(Mutex instanceMutex = new Mutex(false, mutexName))
            {
                if(instanceMutex.WaitOne(1, true) == false)
                {
                    Console.WriteLine("Another instance is executing");
                    return;
                }
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Hello, {0}.", name);
            }
        }
    }
}
