using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
namespace ThreadMonitorUtility
{
    public class ThreadLock : IDisposable
    {
        internal static string threadActivityTracingLocation;
        //
        
        internal static bool enableIndividualThreadActivityScaning = true;
        static ThreadLock()
        {
            threadActivityTracingLocation = AppDomain.CurrentDomain.BaseDirectory + "log\\";

            if (Directory.Exists(threadActivityTracingLocation) == false)
                Directory.CreateDirectory(threadActivityTracingLocation);
            
        }
        public ThreadLock()
        {
        }
        [XmlIgnore]
        public static object LOCKOBJECT = new object();
        
        [XmlIgnore]
        public object objLock;

        public int objectHash;

        //public DateTime acquiringLockStartedTime;
        //public DateTime acquiredLockTime;
        //public DateTime exitingTime;

        public int id;
        public int ThreadId;
        public bool IsBackgroundThread;

        [XmlIgnore]
        public Status status = Status.Waiting;

        [XmlIgnore]
        public Thread t1;

        public string ThreadStack;
        StackTrace stkTrace;

        bool b = true;
        [XmlIgnore]
        public string stackTrace
        {
            get
            {
                string _stackTrace = null;
                
                try
                {
                    if(b)
                        t1.Suspend();
                }
                catch { b = false; }
                try
                {
                    _stackTrace = new StackTrace(t1, true).ToString();                
                }
                catch (Exception exp)
                {
                }
                if(b)
                t1.Resume();
                
                return _stackTrace;
            }
        }

        public int nStart;
        public int nAcquired;
        public int nEnd;
        public static ThreadLock Lock(object objLock)
        {         
           return new ThreadLock(objLock);         
        }

        public ThreadLock(object objLock)
        {          
            this.objLock = objLock;
            objectHash = objLock.GetHashCode();

            nStart = Environment.TickCount;
            
            if (enableIndividualThreadActivityScaning == true)
                stkTrace = new StackTrace();

            //this.acquiringLockStartedTime = DateTime.UtcNow;            
            this.ThreadId = Thread.CurrentThread.ManagedThreadId;
            this.IsBackgroundThread = Thread.CurrentThread.IsBackground;
            
            if (enableIndividualThreadActivityScaning == true)
                t1 = Thread.CurrentThread;           
            
            id = LockController.PutLock(this, objLock);
            
            Monitor.Enter(objLock);
            nAcquired = Environment.TickCount;
            //this.acquiredLockTime = DateTime.UtcNow;

            this.status = Status.Acquired;
            
        }


        public void Dispose()
        {
           
            
           // lock (ThreadLock.LOCKOBJECT)
            {
                this.b = false;
               

                Monitor.Exit(objLock);               
                LockController.RemoveLock(this);
                //exitingTime = DateTime.UtcNow;

                nEnd = Environment.TickCount;

                if (enableIndividualThreadActivityScaning == true)
                {
                    //this.ThreadStack = this.stackTrace;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(SerializeMe), null);
                }
                //SerializeMe(null);
            }
        }       

        void SerializeMe(object obj)
        {
            FileStream fs = null;
            try
            {
                this.ThreadStack = stkTrace.ToString();
                XmlSerializer xmlSr = new XmlSerializer(this.GetType());
                fs = new FileStream(threadActivityTracingLocation + id.ToString() + ".txt", FileMode.Create);
                xmlSr.Serialize(fs, this);
            }
            catch 
            {            
            }
            finally
            {
                fs.Close();
            }
        }
    }



}
