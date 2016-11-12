using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class mainForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonsButton;
        private System.Windows.Forms.Button listBoxesButton;
        private System.Windows.Forms.Button textBoxesButton;
        private System.Windows.Forms.Button combosButton;
        private System.Windows.Forms.Button scrollbarsButton;
        private System.Windows.Forms.Button containersButton;
        private System.Windows.Forms.Button webLookButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public mainForm()
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
            this.buttonsButton = new System.Windows.Forms.Button();
            this.listBoxesButton = new System.Windows.Forms.Button();
            this.textBoxesButton = new System.Windows.Forms.Button();
            this.combosButton = new System.Windows.Forms.Button();
            this.scrollbarsButton = new System.Windows.Forms.Button();
            this.containersButton = new System.Windows.Forms.Button();
            this.webLookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonsButton
            // 
            this.buttonsButton.Location = new System.Drawing.Point(64, 32);
            this.buttonsButton.Name = "buttonsButton";
            this.buttonsButton.TabIndex = 0;
            this.buttonsButton.Text = "Buttons";
            this.buttonsButton.Click += new System.EventHandler(this.buttonsButton_Click);
            // 
            // listBoxesButton
            // 
            this.listBoxesButton.Location = new System.Drawing.Point(152, 32);
            this.listBoxesButton.Name = "listBoxesButton";
            this.listBoxesButton.TabIndex = 1;
            this.listBoxesButton.Text = "List Boxes";
            this.listBoxesButton.Click += new System.EventHandler(this.ListBoxesButton_Click);
            // 
            // textBoxesButton
            // 
            this.textBoxesButton.Location = new System.Drawing.Point(64, 64);
            this.textBoxesButton.Name = "textBoxesButton";
            this.textBoxesButton.TabIndex = 2;
            this.textBoxesButton.Text = "Text Boxes";
            this.textBoxesButton.Click += new System.EventHandler(this.TextBoxesButton_Click);
            // 
            // combosButton
            // 
            this.combosButton.Location = new System.Drawing.Point(64, 96);
            this.combosButton.Name = "combosButton";
            this.combosButton.TabIndex = 4;
            this.combosButton.Text = "Combos";
            this.combosButton.Click += new System.EventHandler(this.CombosButton_Click);
            // 
            // scrollbarsButton
            // 
            this.scrollbarsButton.Location = new System.Drawing.Point(152, 96);
            this.scrollbarsButton.Name = "scrollbarsButton";
            this.scrollbarsButton.TabIndex = 5;
            this.scrollbarsButton.Text = "Scroll Bars";
            this.scrollbarsButton.Click += new System.EventHandler(this.scrollbarsButton_Click);
            // 
            // containersButton
            // 
            this.containersButton.Location = new System.Drawing.Point(152, 64);
            this.containersButton.Name = "containersButton";
            this.containersButton.TabIndex = 6;
            this.containersButton.Text = "Containers";
            this.containersButton.Click += new System.EventHandler(this.containersButton_Click);
            // 
            // webLookButton
            // 
            this.webLookButton.Location = new System.Drawing.Point(104, 136);
            this.webLookButton.Name = "webLookButton";
            this.webLookButton.TabIndex = 7;
            this.webLookButton.Text = "Web Look";
            this.webLookButton.Click += new System.EventHandler(this.webLookButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 198);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.webLookButton,
                                                                          this.containersButton,
                                                                          this.scrollbarsButton,
                                                                          this.combosButton,
                                                                          this.textBoxesButton,
                                                                          this.listBoxesButton,
                                                                          this.buttonsButton});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mainForm";
            this.Text = "Basic Controls Demo";
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new mainForm());
		}

        private void ListBoxesButton_Click(object sender, System.EventArgs e)
        {
            Form f = new ListBoxForm();
            f.Show();
        }

        private void CombosButton_Click(object sender, System.EventArgs e)
        {
            Form f = new ComobBoxForm();
            f.ShowDialog();
        }

        private void TextBoxesButton_Click(object sender, System.EventArgs e)
        {
            Form f = new TextBoxForm();
            f.ShowDialog();
        }

        private void scrollbarsButton_Click(object sender, System.EventArgs e)
        {
            Form f = new ScrollbarsForm();
            f.ShowDialog();
        }

        private void containersButton_Click(object sender, System.EventArgs e)
        {
            Form f = new ContainersForm();
            f.ShowDialog();
        }

        private void buttonsButton_Click(object sender, System.EventArgs e)
        {
            Form f = new ButtonForm();
            f.Show();
        }

        private void webLookButton_Click(object sender, System.EventArgs e)
        {
            Form f = new WebLookForm();
            f.Show();
        }
	}
}
