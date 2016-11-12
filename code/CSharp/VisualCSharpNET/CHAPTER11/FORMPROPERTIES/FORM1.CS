using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormProperties
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox borderCombo;
        private System.Windows.Forms.RadioButton colorControlRadio;
        private System.Windows.Forms.RadioButton colorWhiteRadio;
        private System.Windows.Forms.RadioButton colorSeaGreenRadio;
        private System.Windows.Forms.RadioButton colorWheatRadio;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
            borderCombo.SelectedIndex = 0;
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorWheatRadio = new System.Windows.Forms.RadioButton();
            this.colorSeaGreenRadio = new System.Windows.Forms.RadioButton();
            this.colorWhiteRadio = new System.Windows.Forms.RadioButton();
            this.colorControlRadio = new System.Windows.Forms.RadioButton();
            this.borderCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    this.colorWheatRadio,
                                                                                    this.colorSeaGreenRadio,
                                                                                    this.colorWhiteRadio,
                                                                                    this.colorControlRadio});
            this.groupBox2.Location = new System.Drawing.Point(16, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 112);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Form &Colors";
            // 
            // colorWheatRadio
            // 
            this.colorWheatRadio.Location = new System.Drawing.Point(144, 72);
            this.colorWheatRadio.Name = "colorWheatRadio";
            this.colorWheatRadio.Size = new System.Drawing.Size(64, 24);
            this.colorWheatRadio.TabIndex = 3;
            this.colorWheatRadio.Text = "Wheat";
            this.colorWheatRadio.CheckedChanged += new System.EventHandler(this.colorWheatRadio_CheckedChanged);
            // 
            // colorSeaGreenRadio
            // 
            this.colorSeaGreenRadio.Location = new System.Drawing.Point(40, 72);
            this.colorSeaGreenRadio.Name = "colorSeaGreenRadio";
            this.colorSeaGreenRadio.Size = new System.Drawing.Size(80, 24);
            this.colorSeaGreenRadio.TabIndex = 2;
            this.colorSeaGreenRadio.Text = "Sea Green";
            this.colorSeaGreenRadio.CheckedChanged += new System.EventHandler(this.colorSeaGreenRadio_CheckedChanged);
            // 
            // colorWhiteRadio
            // 
            this.colorWhiteRadio.Location = new System.Drawing.Point(144, 32);
            this.colorWhiteRadio.Name = "colorWhiteRadio";
            this.colorWhiteRadio.Size = new System.Drawing.Size(64, 24);
            this.colorWhiteRadio.TabIndex = 1;
            this.colorWhiteRadio.Text = "White";
            this.colorWhiteRadio.CheckedChanged += new System.EventHandler(this.colorWhiteRadio_CheckedChanged);
            // 
            // colorControlRadio
            // 
            this.colorControlRadio.Checked = true;
            this.colorControlRadio.Location = new System.Drawing.Point(40, 32);
            this.colorControlRadio.Name = "colorControlRadio";
            this.colorControlRadio.Size = new System.Drawing.Size(80, 24);
            this.colorControlRadio.TabIndex = 0;
            this.colorControlRadio.TabStop = true;
            this.colorControlRadio.Text = "Control";
            this.colorControlRadio.CheckedChanged += new System.EventHandler(this.colorControlRadio_CheckedChanged);
            // 
            // borderCombo
            // 
            this.borderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderCombo.Items.AddRange(new object[] {
                                                             "Fixed 3-D",
                                                             "Fixed Dialog",
                                                             "Fixed Single",
                                                             "Fixed Tool Window",
                                                             "None",
                                                             "Sizable",
                                                             "Sizable Tool Window"});
            this.borderCombo.Location = new System.Drawing.Point(144, 40);
            this.borderCombo.Name = "borderCombo";
            this.borderCombo.Size = new System.Drawing.Size(121, 21);
            this.borderCombo.TabIndex = 2;
            this.borderCombo.SelectionChangeCommitted += new System.EventHandler(this.borderCombo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.TabIndex = 3;
            this.label1.Text = "Border Style:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.label1,
                                                                          this.borderCombo,
                                                                          this.groupBox2});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private void borderCombo_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            string newStyleName = borderCombo.SelectedItem.ToString();
            switch(newStyleName)
            {
                case "Fixed 3-D":
                    FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;

                case "Fixed Dialog":
                    FormBorderStyle = FormBorderStyle.FixedDialog;
                    break;

                case "Fixed Single":
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    break;

                case "Fixed Tool Window":
                    FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    break;

                case "None":
                    FormBorderStyle = FormBorderStyle.None;
                    break;

                case "Sizable":
                    FormBorderStyle = FormBorderStyle.Sizable;
                    break;

                case "Sizable Tool Window":
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    break;
            }
        }

        private void colorControlRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.Checked == true)
            {
                BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void colorWhiteRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.Checked == true)
            {
                BackColor = Color.White;
            }
        }

        private void colorWheatRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.Checked == true)
            {
                BackColor = Color.Wheat;
            }
        }

        private void colorSeaGreenRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.Checked == true)
            {
                BackColor = Color.SeaGreen;
            }
        }
	}
}
