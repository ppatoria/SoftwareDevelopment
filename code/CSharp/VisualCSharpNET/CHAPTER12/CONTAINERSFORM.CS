using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for ContainersForm.
	/// </summary>
	public class ContainersForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RadioButton colorRadio;
        private System.Windows.Forms.RadioButton bwRadio;
        private System.Windows.Forms.RadioButton walkRadio;
        private System.Windows.Forms.RadioButton driveRadio;
        private System.Windows.Forms.RadioButton flyRadio;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ContainersForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorRadio = new System.Windows.Forms.RadioButton();
            this.bwRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.walkRadio = new System.Windows.Forms.RadioButton();
            this.driveRadio = new System.Windows.Forms.RadioButton();
            this.flyRadio = new System.Windows.Forms.RadioButton();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    this.colorRadio,
                                                                                    this.bwRadio});
            this.groupBox1.Location = new System.Drawing.Point(8, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Show Colors";
            // 
            // colorRadio
            // 
            this.colorRadio.Location = new System.Drawing.Point(24, 56);
            this.colorRadio.Name = "colorRadio";
            this.colorRadio.TabIndex = 1;
            this.colorRadio.Text = "Colors";
            // 
            // bwRadio
            // 
            this.bwRadio.Location = new System.Drawing.Point(24, 24);
            this.bwRadio.Name = "bwRadio";
            this.bwRadio.TabIndex = 0;
            this.bwRadio.Text = "Black and White";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.walkRadio,
                                                                                 this.driveRadio,
                                                                                 this.flyRadio});
            this.panel1.Location = new System.Drawing.Point(8, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 104);
            this.panel1.TabIndex = 1;
            // 
            // walkRadio
            // 
            this.walkRadio.Location = new System.Drawing.Point(24, 88);
            this.walkRadio.Name = "walkRadio";
            this.walkRadio.TabIndex = 2;
            this.walkRadio.Text = "Walk";
            // 
            // driveRadio
            // 
            this.driveRadio.Location = new System.Drawing.Point(24, 48);
            this.driveRadio.Name = "driveRadio";
            this.driveRadio.TabIndex = 1;
            this.driveRadio.Text = "Drive";
            // 
            // flyRadio
            // 
            this.flyRadio.Location = new System.Drawing.Point(24, 16);
            this.flyRadio.Name = "flyRadio";
            this.flyRadio.TabIndex = 0;
            this.flyRadio.Text = "Fly";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(224, 32);
            this.closeButton.Name = "closeButton";
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ContainersForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(312, 272);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.closeButton,
                                                                          this.panel1,
                                                                          this.groupBox1});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ContainersForm";
            this.Text = "Containers Demo Form";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
	}
}
