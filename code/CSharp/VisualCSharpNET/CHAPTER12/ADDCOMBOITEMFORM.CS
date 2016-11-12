using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for AddComboItem.
	/// </summary>
	public class AddComboItemForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox itemTextBox;
        private string _newItem;
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddComboItemForm()
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
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.TabIndex = 7;
            this.label1.Text = "New Item:";
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(184, 56);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(184, 16);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            this.okButton.Validating += new System.ComponentModel.CancelEventHandler(this.okButton_Validating);
            // 
            // itemTextBox
            // 
            this.itemTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemTextBox.CausesValidation = false;
            this.itemTextBox.Location = new System.Drawing.Point(16, 56);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.TabIndex = 4;
            this.itemTextBox.Text = "";
            // 
            // AddComboItemForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(292, 118);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.label1,
                                                                          this.cancelButton,
                                                                          this.okButton,
                                                                          this.itemTextBox});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddComboItemForm";
            this.Text = "Add Item for Combo Box";
            this.ResumeLayout(false);

        }
		#endregion

        private void okButton_Click(object sender, System.EventArgs e)
        {
            _newItem = itemTextBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public string NewItem
        {
            get { return _newItem; }
        }


        private void okButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(itemTextBox.Text.Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("You must provide a value for the new item.", "Validation failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                _newItem = itemTextBox.Text;
            }
        }

	}
}
