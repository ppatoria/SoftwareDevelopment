using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ThreadMonitorUtility;

namespace ThreadLockTracerSample
{
    public partial class frmPerformanceTest : Form
    {
        public frmPerformanceTest()
        {
            InitializeComponent();
        }

        int nCounter = 100000;
        object objLockTest = new object();

        private void button1_Click(object sender, EventArgs e)
        {
            nCounter = Convert.ToInt32(textBox1.Text);
            int n1 = Environment.TickCount;
            for (int i = 0; i < nCounter; i++)
            {
                lock (objLockTest)
                {
                }
            }
            int n2 = Environment.TickCount;
            label1.Text = "Time: " + (n2 - n1).ToString() + " ms";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nCounter = Convert.ToInt32(textBox1.Text);
            ThreadLock.enableIndividualThreadActivityScaning = false;
            int n1 = Environment.TickCount;
            for (int i = 0; i < nCounter; i++)
            {
                using (ThreadLock.Lock(objLockTest))
                {
                }
            }
            int n2 = Environment.TickCount;
            label2.Text = "Time: " + (n2 - n1).ToString() + " ms";
            ThreadLock.enableIndividualThreadActivityScaning = true;


            
        }
    }
}