using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ThreadMonitorUtility
{
   
    public partial class Activity : UserControl
    {
        ctrlThreadActivity ctrlParent;

        ThreadLock objLockInfo;
        int nHeight =0;
        Color inactive;
        Color active;
        public Activity()
        {
            InitializeComponent();
            
            inactive = label1.BackColor;
            active = label2.BackColor;

            nHeight = this.Height;
        }
        public void SetThreadLock(ThreadLock objLockInfo, ctrlThreadActivity ctrlParent)
        {
            this.objLockInfo = objLockInfo;
            this.ctrlParent = ctrlParent;
            ctrlParent.DisplaySimilarRecordsEvent += new ctrlThreadActivity.DisplaySimilarRecordsByObject(ctrlParent_DisplaySimilarRecordsEvent);
            int totalTime = objLockInfo.nEnd - objLockInfo.nStart;

         

            float oneMSEquals = ctrlThreadActivity.pixel / ctrlThreadActivity.millisecond;

            label1.Width = (int)((objLockInfo.nAcquired - objLockInfo.nStart) * oneMSEquals);
            label2.Width = (int)((objLockInfo.nEnd - objLockInfo.nAcquired) * oneMSEquals);

            label1.Location = new Point(0, 0);
            label2.Location = new Point(label1.Width, 0);
            this.Size = new Size(label2.Location.X + label2.Width, this.Height);

           // toolTip1.InitialDelay = 0;
            
           // toolTip1.IsBalloon = true;
           // toolTip1.SetToolTip(label1, (objLockInfo.nAcquired - objLockInfo.nStart).ToString());
          //  toolTip1.SetToolTip(label2, "Hi");
            

        }

        void ctrlParent_DisplaySimilarRecordsEvent(int objectHashCode)
        {
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.Height = nHeight;
            //if (objLockInfo.objectHash == objectHashCode)
            //{
            //    this.BorderStyle = BorderStyle.Fixed3D;
            //    this.Height = 20;
            //}


            label1.BackColor = inactive;
            label2.BackColor = active;

            if (objLockInfo.objectHash == objectHashCode)
            {
                //label1.BackColor = Color.FromArgb(192, 192, 255);
                label1.BackColor = Color.FromArgb(192, 192, 240);
                label2.BackColor = Color.Blue;
            }
        }        
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ctrlParent.ShowSimilarRecords(this.objLockInfo);
        }
        
        int lastTick = 0;
        private void label1_Click(object sender, EventArgs e)
        {
            
            ctrlParent.ShowSimilarRecords(this.objLockInfo);
            
        }
        string stackTraceInfo = "";
        StringBuilder sbStackInfo = null;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (sbStackInfo == null)
            {
                sbStackInfo = new StringBuilder();
                sbStackInfo.Append("Total Activity= " + (objLockInfo.nEnd - objLockInfo.nStart).ToString());
                sbStackInfo.Append(" (Waiting: " + (objLockInfo.nAcquired - objLockInfo.nStart).ToString());
                sbStackInfo.Append(" Active: " + (objLockInfo.nEnd - objLockInfo.nAcquired).ToString() + " )");
                
                sbStackInfo.Append(Environment.NewLine + "ThreadId: " + objLockInfo.ThreadId.ToString() + ", IsBackground:" + objLockInfo.IsBackgroundThread.ToString());
                sbStackInfo.Append(Environment.NewLine + Environment.NewLine + "StackTrace Info: ");
                
                string[] stackArray = objLockInfo.ThreadStack.Split(new string[] { "\n" }, StringSplitOptions.None);

                for (int i = 0; i < stackArray.Length; i++)
                {
                    if (i <= 1) continue;
                    //if(stackArray[i].Trim().StartsWith("at System.") == false)
                    sbStackInfo.Append(Environment.NewLine + stackArray[i]);
                }

            }
            
            if ((Environment.TickCount - lastTick) > 10)
            {
                toolTip1.Show(sbStackInfo.ToString(), label1, e.X + 15, e.Y + 14);
            }
            lastTick = Environment.TickCount;
            
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (sbStackInfo == null)
            {
                sbStackInfo = new StringBuilder();
                sbStackInfo.Append("Total Activity: " + (objLockInfo.nEnd - objLockInfo.nStart).ToString());
                sbStackInfo.Append(" [Waiting: " + (objLockInfo.nAcquired - objLockInfo.nStart).ToString());
                sbStackInfo.Append(" Active: " + (objLockInfo.nEnd - objLockInfo.nAcquired).ToString() + " ]");

                sbStackInfo.Append(Environment.NewLine + "ThreadId: " + objLockInfo.ThreadId.ToString() + " IsBackground:" + objLockInfo.IsBackgroundThread.ToString());
                sbStackInfo.Append(Environment.NewLine + "StackTrace Info: ");

                string[] stackArray = objLockInfo.ThreadStack.Split(new string[] { "\n" }, StringSplitOptions.None);

                for (int i = 0; i < stackArray.Length; i++)
                {
                    if (i <= 1) continue;
                    //if(stackArray[i].Trim().StartsWith("at System.") == false)
                    sbStackInfo.Append(Environment.NewLine + stackArray[i]);
                }

            }

            if ((Environment.TickCount - lastTick) > 10)
            {
                toolTip1.Show(sbStackInfo.ToString(), label2, e.X + 15, e.Y + 14);
            }
            lastTick = Environment.TickCount;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
        }
    }
}
