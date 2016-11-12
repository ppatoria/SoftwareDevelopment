using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace MSPress.CSharpCoreRef.Controls
{
    /// <summary>
    /// Summary description for WebLookForm.
    /// </summary>
    public class WebLookForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox printerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.LinkLabel linkLabel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public WebLookForm()
        {
            InitializeComponent();

            //LinkArea range = new LinkArea(8, 4);
            //linkLabel.LinkArea = range;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.closeButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.printerTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox1.Location = new System.Drawing.Point(184, 208);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Set as default";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.closeButton,
																				 this.label1,
																				 this.radioButton2,
																				 this.radioButton1,
																				 this.linkLabel});
			this.panel1.Location = new System.Drawing.Point(-16, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 136);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// closeButton
			// 
			this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeButton.Location = new System.Drawing.Point(224, 16);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 4;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(40, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Print Pages";
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton2.Location = new System.Drawing.Point(152, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "Current Page";
			// 
			// radioButton1
			// 
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton1.Location = new System.Drawing.Point(40, 48);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 1;
			this.radioButton1.Text = "All Pages";
			// 
			// linkLabel
			// 
			this.linkLabel.ActiveLinkColor = System.Drawing.Color.Lime;
			this.linkLabel.DisabledLinkColor = System.Drawing.Color.DarkOrange;
			this.linkLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.linkLabel.LinkColor = System.Drawing.Color.DarkGreen;
			this.linkLabel.Location = new System.Drawing.Point(40, 104);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.TabIndex = 3;
			this.linkLabel.TabStop = true;
			this.linkLabel.Text = "Support Page";
			this.linkLabel.VisitedLinkColor = System.Drawing.Color.DarkOliveGreen;
			this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
			// 
			// printerTextBox
			// 
			this.printerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.printerTextBox.Location = new System.Drawing.Point(16, 208);
			this.printerTextBox.Name = "printerTextBox";
			this.printerTextBox.Size = new System.Drawing.Size(152, 20);
			this.printerTextBox.TabIndex = 3;
			this.printerTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SeaGreen;
			this.label2.Location = new System.Drawing.Point(16, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Printer Information";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SeaGreen;
			this.label3.Location = new System.Drawing.Point(16, 184);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Printer name:";
			// 
			// WebLookForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(292, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label3,
																		  this.label2,
																		  this.printerTextBox,
																		  this.panel1,
																		  this.checkBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "WebLookForm";
			this.Text = "WebLookForm";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
        #endregion

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            Process.Start("http://www.microsoft.com");
        }

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
    }
}
