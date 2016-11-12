using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for ScrollbarsForm.
	/// </summary>
	public class ScrollbarsForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox autoScrollCheck;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ScrollbarsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            autoScrollCheck.Checked = AutoScroll;
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.autoScrollCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(208, 32);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(208, 64);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(8, 32);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(184, 216);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // autoScrollCheck
            // 
            this.autoScrollCheck.Location = new System.Drawing.Point(208, 96);
            this.autoScrollCheck.Name = "autoScrollCheck";
            this.autoScrollCheck.Size = new System.Drawing.Size(80, 24);
            this.autoScrollCheck.TabIndex = 3;
            this.autoScrollCheck.Text = "Auto Scroll";
            this.autoScrollCheck.CheckedChanged += new System.EventHandler(this.autoScrollCheck_CheckedChanged);
            // 
            // ScrollbarsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(50, 50);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(304, 301);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.autoScrollCheck,
                                                                          this.textBox,
                                                                          this.cancelButton,
                                                                          this.okButton});
            this.Name = "ScrollbarsForm";
            this.Text = "Scroll Bars Form";
            this.ResumeLayout(false);

        }
		#endregion

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void autoScrollCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            AutoScroll = autoScrollCheck.Checked;
        }
	}
}
