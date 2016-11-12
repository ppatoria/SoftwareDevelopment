using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ClickRects
{
    public class MainForm : System.Windows.Forms.Form
    {
        ArrayList _points = new ArrayList();
        readonly Size _rectSize = new Size(100, 100);
        Brush [] _brushes = new Brush[] { Brushes.Red,
                                          Brushes.Green,
                                          Brushes.Blue };
        Pen _edgePen = Pens.Black;

        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(368, 326);
            this.Name = "MainForm";
            this.Text = "Click to add rectangles";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        private void MainForm_Paint(object sender, 
                                    System.Windows.Forms.PaintEventArgs e)
        {
            int index = 0;
            foreach(Point pt in _points)
            {
                e.Graphics.FillRectangle(_brushes[index],
                                         pt.X,
                                         pt.Y,
                                         _rectSize.Width,
                                         _rectSize.Height);
                e.Graphics.DrawRectangle(_edgePen,
                                         pt.X,
                                         pt.Y,
                                         _rectSize.Width,
                                         _rectSize.Height);
                if(++index == 3)
                    index = 0;
            }
        }

        private void MainForm_Click(object sender, System.EventArgs e)
        {
            _points.Add(PointToClient(MousePosition));
            Invalidate();
        }
    }
}
