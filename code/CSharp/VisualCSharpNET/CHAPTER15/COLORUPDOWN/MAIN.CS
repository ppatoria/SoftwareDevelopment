using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ColorUpDown
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.DomainUpDown knownColorUpDown;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			string [] colorNames = Enum.GetNames(typeof(KnownColor));
			knownColorUpDown.Items.AddRange(colorNames);
			knownColorUpDown.SelectedIndex = 0;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.knownColorUpDown = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // knownColorUpDown
            // 
            this.knownColorUpDown.Location = new System.Drawing.Point(112, 56);
            this.knownColorUpDown.Name = "knownColorUpDown";
            this.knownColorUpDown.Size = new System.Drawing.Size(152, 20);
            this.knownColorUpDown.TabIndex = 0;
            this.knownColorUpDown.SelectedItemChanged += new System.EventHandler(this.knownColorUpDown_SelectedItemChanged);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(376, 150);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.knownColorUpDown});
            this.Name = "MainForm";
            this.Text = "ColorUpDown Example";
            this.ResumeLayout(false);

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

		private void knownColorUpDown_SelectedItemChanged(object sender, System.EventArgs e)
		{
			string currentColorName = (string)knownColorUpDown.SelectedItem;
			try
			{
				BackColor = Color.FromName(currentColorName);
			}
			catch(ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
