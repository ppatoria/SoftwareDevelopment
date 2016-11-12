using System;
using System.Threading;
using System.Collections;

namespace MSPress.CSharpCoreRef.Threads
{
    public class Broken
    {
        const int MaxLoops = 20000;
        protected long dangerousVariable = 0;

        protected void UpdateMethod()
        {
            //Monitor.Enter(this);
            dangerousVariable++;
            //Monitor.Exit(this);
        }

        public long Result
        {
            get { return dangerousVariable; }
        }

        public void ThreadProc()
        {
            for(int n = 0; n < MaxLoops; ++n)
            {
                UpdateMethod();
                Console.Write(".");
            }
        }

        public void TakeALock()
        {
            try
            {
                Monitor.Enter(this);
                ThrowAnException();
                Monitor.Exit(this);
            }
            catch
            {
                Console.WriteLine("Caught an exception");
            }
        }

        public void SimpleLock()
        {
            lock(this)
            {
                ThrowAnException();
            }
        }

        public void ImprovedTakeALock()
        {
            try
            {
                Monitor.Enter(this);
                ThrowAnException();
            }
            catch
            {
                Console.WriteLine("Caught an exception");
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void TryToPrintMessage()
        {
            Monitor.Enter(this);
            Console.WriteLine("Can you see this");
            Monitor.Exit(this);
        }

        private void ThrowAnException()
        {
            throw new InvalidOperationException("Bypass monitor code");
        }

    }
}
