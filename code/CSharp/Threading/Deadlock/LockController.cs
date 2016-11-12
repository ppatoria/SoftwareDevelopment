using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace ThreadMonitorUtility
{
    public class LockController
    {
        
        static Dictionary<ThreadLock, object> lockTable = new Dictionary<ThreadLock, object>();
        //static Hashtable lockTable = new Hashtable();
        static int id = 0;
        public static int PutLock(ThreadLock objThreadLock, object objLock)
        {
            lock (ThreadLock.LOCKOBJECT)
            {
                lockTable[objThreadLock] = objLock;
                if (ThreadLock.enableIndividualThreadActivityScaning)
                    return id++;
                else return 0;
            }
        }
        public static void RemoveLock(ThreadLock objThreadLock)
        {
            lock (ThreadLock.LOCKOBJECT)
            {
                lockTable.Remove(objThreadLock);
            }
        }

        static StringBuilder sb = new StringBuilder();
        public static void GenerateReport()
        {
            IsThreadDeadLock();

            ThreadDeadLockInfo f2 = new ThreadDeadLockInfo();
            f2.Show();
            f2.textBox1.Text = sb.ToString();
        }

        private static bool _IsThreadDeadLock(List<ThreadLock> list)
        {
            if (list.Count > 0)
            {
                bool bExitOuter = false;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (bExitOuter == true) break;
                    ArrayList aList = new ArrayList();
                    ArrayList aListObject = new ArrayList();

                    bool bContinue = true;
                    ThreadLock tLock = list[i];
                    aList.Add(tLock.ThreadId); //TL1
                    aListObject.Add(tLock);


                    while (bContinue)
                    {
                        bContinue = false;


                        if (objectThreadIdTable.ContainsKey(tLock.objLock)) //O2
                        {
                            int nThreadId = objectThreadIdTable[tLock.objLock]; //2
                            for (int j = list.Count - 1; j >= 0; j--)
                            {
                                if (tLock.Equals(list[j]) == false)
                                {
                                    if (list[j].ThreadId == nThreadId)
                                    {
                                        if (aList.Contains(nThreadId))
                                        {
                                            sb.Append("-----------------------------------------------------" + Environment.NewLine);
                                            sb.Append("Thread Deadlock Information:" + Environment.NewLine);
                                            sb.Append(Environment.NewLine);
                                            //for (int ii = list.Count - 1; ii >= 0; ii--)
                                            //{
                                            //    sb.Append("IsBackgroundThread: " + list[ii].IsBackgroundThread.ToString());
                                            //    sb.Append(Environment.NewLine);
                                            //    sb.Append("ThreadId: " + list[ii].ThreadId.ToString());
                                            //    sb.Append(Environment.NewLine);

                                            //    sb.Append(list[ii].stackTrace.ToString());
                                            //    sb.Append(Environment.NewLine);
                                            //    sb.Append(Environment.NewLine);
                                            //}

                                            for (int ii = aListObject.Count - 1; ii >= 0; ii--)
                                            {
                                                sb.Append("IsBackgroundThread: " + ((ThreadLock)aListObject[ii]).IsBackgroundThread.ToString());
                                                sb.Append(Environment.NewLine);
                                                sb.Append("ThreadId: " + ((ThreadLock)aListObject[ii]).ThreadId.ToString());
                                                sb.Append(Environment.NewLine);

                                                sb.Append(((ThreadLock)aListObject[ii]).stackTrace.ToString());
                                                sb.Append(Environment.NewLine);
                                                sb.Append(Environment.NewLine);
                                            }

                                            MessageBox.Show("DeadLock");
                                            for (int ii = 0; ii < aListObject.Count; ii++)
                                            {
                                                list.Remove((ThreadLock)aListObject[ii]);
                                            }
                                            bExitOuter = true;
                                            return true;
                                            break;
                                        }
                                        aList.Add(list[j].ThreadId); //TL2
                                        aListObject.Add(list[j]);
                                        tLock = list[j];
                                        bContinue = true;
                                        break;
                                    }
                                }
                            }

                        }
                    }

                }
            }
            return false;
        }

        public static bool IsThreadDeadLock()
        {
            StringBuilder sb = new StringBuilder();
            List<ThreadLock> list = GetWaitingThreadLockList();

            while(_IsThreadDeadLock(list) == true)
            {

            }
            return true;
           
        }
        static Dictionary<object, int> objectThreadIdTable = null;
        public static List<ThreadLock> GetWaitingThreadLockList()
        {
            List<ThreadLock> list = new List<ThreadLock>();
            objectThreadIdTable = new Dictionary<object, int>();

            Dictionary<ThreadLock, object>.Enumerator iEnum = lockTable.GetEnumerator();
            while (iEnum.MoveNext())
            {
                if (iEnum.Current.Key.status == Status.Waiting)
                {
                    list.Add(iEnum.Current.Key);
                }
                else
                    objectThreadIdTable[iEnum.Current.Key.objLock] = iEnum.Current.Key.ThreadId;
            }
            return list;
        }
    }

    public enum Status
    {
        Waiting = 0,
        Acquired = 1
    }
    
}
