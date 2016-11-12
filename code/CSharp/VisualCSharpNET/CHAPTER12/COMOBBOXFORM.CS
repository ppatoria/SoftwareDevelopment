using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
	/// <summary>
	/// Summary description for ComobBoxForm.
	/// </summary>
	public class ComobBoxForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button removeItem;
        private System.Windows.Forms.Button newItem;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.RadioButton dropDownRadio;
        private System.Windows.Forms.RadioButton dropDownListRadio;
        private System.Windows.Forms.RadioButton simpleRadio;
        private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComobBoxForm()
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
			this.removeItem = new System.Windows.Forms.Button();
			this.newItem = new System.Windows.Forms.Button();
			this.CloseButton = new System.Windows.Forms.Button();
			this.combo = new System.Windows.Forms.ComboBox();
			this.dropDownRadio = new System.Windows.Forms.RadioButton();
			this.dropDownListRadio = new System.Windows.Forms.RadioButton();
			this.simpleRadio = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// removeItem
			// 
			this.removeItem.Location = new System.Drawing.Point(176, 120);
			this.removeItem.Name = "removeItem";
			this.removeItem.TabIndex = 5;
			this.removeItem.Text = "&Remove";
			this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
			// 
			// newItem
			// 
			this.newItem.Location = new System.Drawing.Point(64, 120);
			this.newItem.Name = "newItem";
			this.newItem.TabIndex = 4;
			this.newItem.Text = "&Add";
			this.newItem.Click += new System.EventHandler(this.newItem_Click);
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseButton.Location = new System.Drawing.Point(296, 24);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.TabIndex = 7;
			this.CloseButton.Text = "Close";
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// combo
			// 
			this.combo.Items.AddRange(new object[] {
													   "Red",
													   "Green",
													   "Blue",
													   "Yellow"});
			this.combo.Location = new System.Drawing.Point(24, 24);
			this.combo.Name = "combo";
			this.combo.Size = new System.Drawing.Size(121, 21);
			this.combo.TabIndex = 0;
			this.combo.SelectionChangeCommitted += new System.EventHandler(this.OnCommitted);
			// 
			// dropDownRadio
			// 
			this.dropDownRadio.Location = new System.Drawing.Point(176, 24);
			this.dropDownRadio.Name = "dropDownRadio";
			this.dropDownRadio.TabIndex = 1;
			this.dropDownRadio.Text = "Drop Down";
			this.dropDownRadio.CheckedChanged += new System.EventHandler(this.dropDownRadio_CheckedChanged);
			// 
			// dropDownListRadio
			// 
			this.dropDownListRadio.Location = new System.Drawing.Point(176, 56);
			this.dropDownListRadio.Name = "dropDownListRadio";
			this.dropDownListRadio.TabIndex = 2;
			this.dropDownListRadio.Text = "Drop Down List";
			this.dropDownListRadio.CheckedChanged += new System.EventHandler(this.dropDownListRadio_CheckedChanged);
			// 
			// simpleRadio
			// 
			this.simpleRadio.Location = new System.Drawing.Point(176, 88);
			this.simpleRadio.Name = "simpleRadio";
			this.simpleRadio.TabIndex = 3;
			this.simpleRadio.Text = "Simple";
			this.simpleRadio.CheckedChanged += new System.EventHandler(this.simpleRadio_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(296, 120);
			this.button1.Name = "button1";
			this.button1.TabIndex = 6;
			this.button1.Text = "&Trace";
			// 
			// ComobBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 168);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.simpleRadio,
																		  this.dropDownListRadio,
																		  this.dropDownRadio,
																		  this.combo,
																		  this.removeItem,
																		  this.newItem,
																		  this.CloseButton});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ComobBoxForm";
			this.Text = "ComobBox Demo";
			this.Load += new System.EventHandler(this.ComobBoxForm_Load);
			this.ResumeLayout(false);

		}
		#endregion


        private void dropDownRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void dropDownListRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void simpleRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            combo.DropDownStyle = ComboBoxStyle.Simple;
            combo.Height = 80;
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void newItem_Click(object sender, System.EventArgs e)
        {
            AddComboItemForm dlg = new AddComboItemForm();
            DialogResult result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                string newItem = dlg.NewItem;
                combo.Items.Add(newItem);
            }
        }

        private void removeItem_Click(object sender, System.EventArgs e)
        {
            int index = combo.SelectedIndex;
            if(index != -1)
            {
                combo.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("You must select an item to remove",
                                "Can't remove item",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
            }
        }

        private void OnCommitted(object sender, System.EventArgs e)
        {
            string message = string.Format("The new selection is {0}",
                                           combo.SelectedItem.ToString());
            MessageBox.Show(message);
        }

		private void ComobBoxForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
