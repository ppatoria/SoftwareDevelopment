using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace ThreadMonitorUtility
{
    public partial class ctrlThreadActivity : UserControl
    {
        public delegate void DisplaySimilarRecordsByObject(int objectHashCode);
        public event DisplaySimilarRecordsByObject DisplaySimilarRecordsEvent;

        internal void ShowSimilarRecords(ThreadLock objLockInfo)
        {
            DisplaySimilarRecordsEvent(objLockInfo.objectHash);
        }
        public ctrlThreadActivity()
        {
            InitializeComponent();
        }

        public static float pixel = 1;
        public static float millisecond = 10;
        int nMaxWidth = 0;
        int nMaxY = 0;

        Label l = new Label(); //X
        Label YLabel = new Label();

        public bool LoadData()
        {
            panel1.Controls.Clear();
            
            //panel1.Controls.Add(button1);
            //panel1.Controls.Add(button3);
            //panel1.Controls.Add(label1);
            
            panel1.Controls.Add(panel2);

            label1.Text = "Scale" + Environment.NewLine + pixel.ToString() + "Pixel = " + millisecond.ToString() + " ms";


            threadLockList.Clear();
            DeSerializeThreadLock();

            if (threadLockList.Count == 0)
            {
                MessageBox.Show("No Files found at '" + ThreadLock.threadActivityTracingLocation + "' for tracing thread-activity");
                return false;
            }
            nMaxWidth = 0;
            nMaxY = 0;

            float oneMSEquals = ctrlThreadActivity.pixel / ctrlThreadActivity.millisecond;

            for (int i = 0; i < threadLockList.Count; i++)
            {
                Activity ac = new Activity();
                ac.Name = i.ToString();
                ac.SetThreadLock(threadLockList[i], this);
                int X = (int)((threadLockList[i].nStart - threadLockList[0].nStart) * oneMSEquals) + 100;
                ac.Location = new Point(X, i * 30 + 20);
                if ( (X + ac.Width) > nMaxWidth)
                    nMaxWidth = X + ac.Width;
                if(ac.Location.Y > nMaxY)
                    nMaxY = ac.Location.Y;

                this.panel1.Controls.Add(ac);
            }

            l = new Label();
            l.Size = new Size(nMaxWidth + 5, 1);
            l.Location = new Point(100, nMaxY+50);
            l.BackColor = Color.Black;
            l.TextAlign = ContentAlignment.TopLeft;
            this.panel1.Controls.Add(l);


            YLabel = new Label();
            YLabel.Size = new Size(1, nMaxY + 50);
            YLabel.Location = new Point(l.Location.X,0);
            YLabel.BackColor = Color.Black;
            YLabel.TextAlign = ContentAlignment.TopLeft;
            this.panel1.Controls.Add(YLabel);
            

            float nCount = 0;
            while (true)
            {
               

                if ((l.Location.X + nCount * 100) > l.Width + l.Location.X) break;
                Label lblMarking = new Label();
                lblMarking.Location = new Point(l.Location.X + (int)nCount * 100, l.Location.Y + 5);
                lblMarking.AutoSize = true;
                
                lblMarking.Size = new Size(25, 25);
                lblMarking.Text = "|" + Environment.NewLine + (  (nCount * 100) * millisecond/pixel ).ToString();
                lblMarking.TextAlign = ContentAlignment.TopLeft;
                this.panel1.Controls.Add(lblMarking);


                Label verticalLine = new Label();
                verticalLine.Size = YLabel.Size;
                verticalLine.Location = new Point(lblMarking.Location.X, 0);
                verticalLine.BackColor = Color.FromArgb(224,224,224);
                verticalLine.TextAlign = ContentAlignment.TopLeft;
                this.panel1.Controls.Add(verticalLine);

                //if(nCount >10)
                //break;
            nCount++;

            }
            Label lblDummy = new Label();
            lblDummy.Location = new Point(l.Location.X + l.Size.Width + 50, l.Location.Y + 50);
            this.panel1.Controls.Add(lblDummy);

            return true;
        }


        List<ThreadLock> threadLockList = new List<ThreadLock>();
        private void DeSerializeThreadLock()
        {
            string[] files = Directory.GetFiles(ThreadLock.threadActivityTracingLocation);
            FileStream fs = null;
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        XmlSerializer xmlSr = new XmlSerializer(typeof(ThreadLock));                        
                        fs = new FileStream(ThreadLock.threadActivityTracingLocation + i.ToString() + ".txt", FileMode.Open);
                        object obj = xmlSr.Deserialize(fs);
                        threadLockList.Add((ThreadLock)obj);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                exp = exp;
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((millisecond - 10) > 0)
            {
                pixel = 1;
                millisecond = millisecond - 10;
            }
            else
            {
                //if (pixel == 1) pixel = 0;

                pixel = pixel + 0.2f;
                //millisecond = millisecond - 10;
            }
            LoadData();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pixel == 1)
            {
                millisecond = millisecond + 10;                
            }
            else
            {
                pixel -= 0.2f;
            }

            LoadData();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            DisplaySimilarRecordsEvent(-1);
        }
        int lastTick = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= l.Location.X && e.Y <= l.Location.Y)
            {
                if ((Environment.TickCount - lastTick) > 10)
                {                    
                    toolTip1.Show( "Time: " + (((e.X - l.Location.X) * millisecond) / pixel).ToString() + " ms", panel1, e.X + 10, e.Y);                    
                }
            }
            else
            {
                toolTip1.RemoveAll();
            }
            lastTick = Environment.TickCount;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();            
        }
    }
}
