using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ThreadMonitorUtility;
using System.Diagnostics;

namespace ThreadLockTracerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        object obj1 = new object();
        object obj2 = new object();
        object obj3 = new object();       

        
        void DoLock1()
        {
            /*  Equivalent code
            lock (obj1)
            {
                Thread.Sleep(3000);
                lock(obj2)
                {
                }
            }
            */
            using (ThreadLock.Lock(obj1))
            {
                Thread.Sleep(3000);
                using (ThreadLock.Lock(obj2))
                {
                }
            }
        }


        void DoLock2(object obj)
        {
            /*  Equivalent code
            lock (obj2)
            {
                Thread.Sleep(3000);
                lock(obj3)
                {
                }
            }
            */

            using (ThreadLock.Lock(obj2))
            {
                Thread.Sleep(3000);

                using (ThreadLock.Lock(obj3))
                {
                }
            }

        }

        void DoLock3()
        {
            /*  Equivalent code
           lock (obj3)
           {
               Thread.Sleep(3000);
               lock(obj1)
               {
               }
           }
           */
            using (ThreadLock.Lock(obj3))
            {
                Thread.Sleep(3000);
                using (ThreadLock.Lock(obj1))
                {
                }
            }
        }

        object obj4 = new object();
        object obj5 = new object();
        private void DoLock4()
        {
            /*  Equivalent code
           lock (obj4)
           {
               Thread.Sleep(3000);
               lock(obj5)
               {
               }
           }
           */
            using (ThreadLock.Lock(obj4))
            {
                Thread.Sleep(3000);
                using (ThreadLock.Lock(obj5))
                {
                }
            }
        }


        
        private void DoLock5()
        {
            /*  Equivalent code
           lock (obj5)
           {
               Thread.Sleep(3000);
               lock(obj4)
               {
               }
           }
           */
            using (ThreadLock.Lock(obj5))
            {
                Thread.Sleep(3000);
                using (ThreadLock.Lock(obj4))
                {
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //Dead
            Thread t1 = new Thread(DoLock1);
            t1.Start();

            ThreadPool.QueueUserWorkItem(new WaitCallback(DoLock2), null);

            Thread t3 = new Thread(DoLock3);
            t3.Start();

            
            
            Thread t4 = new Thread(DoLock4);
            t4.Start();

            Thread t5 = new Thread(DoLock5);
            t5.Start();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LockController.GenerateReport();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowThreadActivity threadActivity = new ShowThreadActivity();
            threadActivity.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(Execute1);
            t1.Start();

            Thread t2 = new Thread(Execute2);
            t2.Start();
        }

        object objExecute1 = new object();
        private void Execute1()
        {

            using (ThreadLock.Lock(objExecute1))
            {
                Thread.Sleep(3000);                
            }
        }
        object objExecute2 = new object();
        private void Execute2()
        {            
            using (ThreadLock.Lock(objExecute1))
            {
                Thread.Sleep(1000);
                using (ThreadLock.Lock(objExecute2))
                {
                    Thread.Sleep(2000);
                }
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Thread t3 = new Thread(Execute3);
            t3.Start();

            Thread t4 = new Thread(Execute4);
            t4.Start();

            Thread t4_ = new Thread(Execute2);
            t4_.Start();
        }
        object objExecute3 = new object();
        private void Execute3()
        {
            using (ThreadLock.Lock(objExecute3))
            {
                Thread.Sleep(2500);
                using (ThreadLock.Lock(objExecute4))
                {
                    Thread.Sleep(1500);
                }
            }
        }
        object objExecute4 = new object();
        private void Execute4()
        {
            using (ThreadLock.Lock(objExecute3))
            {
                Thread.Sleep(500);
                using (ThreadLock.Lock(objExecute4))
                {
                    Thread.Sleep(1000);
                }
            }
        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPerformanceTest frmTest = new frmPerformanceTest();
            frmTest.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", ThreadLock.threadActivityTracingLocation);
        }



    }
}