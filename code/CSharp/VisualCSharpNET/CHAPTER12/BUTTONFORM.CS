using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for ButtonForm.
	/// </summary>
	public class ButtonForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RadioButton standardRadio;
        private System.Windows.Forms.RadioButton popupRadio;
        private System.Windows.Forms.RadioButton flatRadio;
        private System.Windows.Forms.RadioButton buttonRadio;
        private System.Windows.Forms.CheckBox standardCheckBox;
        private System.Windows.Forms.CheckBox popupCheckBox;
        private System.Windows.Forms.CheckBox flatCheckBox;
        private System.Windows.Forms.CheckBox buttonCheckBox;
        private System.Windows.Forms.Button standardButton;
        private System.Windows.Forms.Button popupButton;
        private System.Windows.Forms.Button flatButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ButtonForm()
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
			this.standardRadio = new System.Windows.Forms.RadioButton();
			this.popupRadio = new System.Windows.Forms.RadioButton();
			this.flatRadio = new System.Windows.Forms.RadioButton();
			this.buttonRadio = new System.Windows.Forms.RadioButton();
			this.closeButton = new System.Windows.Forms.Button();
			this.standardCheckBox = new System.Windows.Forms.CheckBox();
			this.popupCheckBox = new System.Windows.Forms.CheckBox();
			this.flatCheckBox = new System.Windows.Forms.CheckBox();
			this.buttonCheckBox = new System.Windows.Forms.CheckBox();
			this.standardButton = new System.Windows.Forms.Button();
			this.popupButton = new System.Windows.Forms.Button();
			this.flatButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// standardRadio
			// 
			this.standardRadio.Location = new System.Drawing.Point(160, 136);
			this.standardRadio.Name = "standardRadio";
			this.standardRadio.TabIndex = 7;
			this.standardRadio.Text = "Standard";
			// 
			// popupRadio
			// 
			this.popupRadio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.popupRadio.Location = new System.Drawing.Point(160, 165);
			this.popupRadio.Name = "popupRadio";
			this.popupRadio.TabIndex = 8;
			this.popupRadio.Text = "Popup";
			// 
			// flatRadio
			// 
			this.flatRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatRadio.Location = new System.Drawing.Point(160, 194);
			this.flatRadio.Name = "flatRadio";
			this.flatRadio.TabIndex = 9;
			this.flatRadio.Text = "Flat";
			// 
			// buttonRadio
			// 
			this.buttonRadio.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonRadio.Location = new System.Drawing.Point(160, 223);
			this.buttonRadio.Name = "buttonRadio";
			this.buttonRadio.TabIndex = 10;
			this.buttonRadio.Text = "Button Look";
			// 
			// closeButton
			// 
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.closeButton.Location = new System.Drawing.Point(200, 24);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 11;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// standardCheckBox
			// 
			this.standardCheckBox.Location = new System.Drawing.Point(24, 136);
			this.standardCheckBox.Name = "standardCheckBox";
			this.standardCheckBox.TabIndex = 3;
			this.standardCheckBox.Text = "Standard";
			// 
			// popupCheckBox
			// 
			this.popupCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.popupCheckBox.Location = new System.Drawing.Point(24, 165);
			this.popupCheckBox.Name = "popupCheckBox";
			this.popupCheckBox.TabIndex = 4;
			this.popupCheckBox.Text = "Popup";
			// 
			// flatCheckBox
			// 
			this.flatCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatCheckBox.Location = new System.Drawing.Point(24, 194);
			this.flatCheckBox.Name = "flatCheckBox";
			this.flatCheckBox.TabIndex = 5;
			this.flatCheckBox.Text = "Flat";
			// 
			// buttonCheckBox
			// 
			this.buttonCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonCheckBox.Location = new System.Drawing.Point(32, 224);
			this.buttonCheckBox.Name = "buttonCheckBox";
			this.buttonCheckBox.TabIndex = 6;
			this.buttonCheckBox.Text = "Button Look";
			// 
			// standardButton
			// 
			this.standardButton.Location = new System.Drawing.Point(32, 16);
			this.standardButton.Name = "standardButton";
			this.standardButton.TabIndex = 0;
			this.standardButton.Text = "Standard";
			this.standardButton.Click += new System.EventHandler(this.OnClick);
			// 
			// popupButton
			// 
			this.popupButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.popupButton.Location = new System.Drawing.Point(32, 48);
			this.popupButton.Name = "popupButton";
			this.popupButton.TabIndex = 1;
			this.popupButton.Text = "Popup";
			this.popupButton.Click += new System.EventHandler(this.OnClick);
			// 
			// flatButton
			// 
			this.flatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButton.Location = new System.Drawing.Point(32, 88);
			this.flatButton.Name = "flatButton";
			this.flatButton.TabIndex = 2;
			this.flatButton.Text = "Flat";
			this.flatButton.Click += new System.EventHandler(this.OnClick);
			// 
			// ButtonForm
			// 
			this.AcceptButton = this.closeButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 272);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.flatButton,
																		  this.popupButton,
																		  this.standardButton,
																		  this.buttonCheckBox,
																		  this.flatCheckBox,
																		  this.popupCheckBox,
																		  this.standardCheckBox,
																		  this.closeButton,
																		  this.buttonRadio,
																		  this.flatRadio,
																		  this.popupRadio,
																		  this.standardRadio});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ButtonForm";
			this.Text = "Button Demo Form";
			this.ResumeLayout(false);

		}
		#endregion

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
			
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            Button clickedButton = (Button)sender;
            switch(clickedButton.Name)
            {
                case "standardButton":
                    MessageBox.Show("Standard button clicked");
                    break;
                case "popupButton":
                    MessageBox.Show("Popup button clicked");
                    break;
                case "flatButton":
                    MessageBox.Show("Flat button clicked");
                    break;
                default:
                    MessageBox.Show("Unknown button clicked");
                    break;
            }
        }
	}
}
