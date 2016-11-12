using System;
using System.Threading;

namespace MSPress.CSharpCoreRef.Threads
{
    public class Worker
    {
        protected string _message;
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        public void PrintMessage()
        {
            Console.WriteLine("Message from worker: {0}.", _message);
        }
    }
}
