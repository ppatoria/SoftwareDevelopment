using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ThreadMonitorUtility
{
    public partial class ShowThreadActivity : Form
    {
        public ShowThreadActivity()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {       
            base.OnLoad(e);
            ctrlThreadActivity1.LoadData();         
        }
    }
}