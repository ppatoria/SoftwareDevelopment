using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.ContextMenuDemo
{
    /// <summary>
    /// Summary description for AddListBoxItemForm.
    /// </summary>
    public class AddListBoxItemForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        
        private string _newItem;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public AddListBoxItemForm()
        {
            InitializeComponent();
            _newItem = "";
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
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemTextBox
            // 
            this.itemTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemTextBox.CausesValidation = false;
            this.itemTextBox.Location = new System.Drawing.Point(32, 64);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.TabIndex = 0;
            this.itemTextBox.Text = "";
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(200, 24);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            this.okButton.Validating += new System.ComponentModel.CancelEventHandler(this.okButton_Validating);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(200, 64);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.TabIndex = 3;
            this.label1.Text = "New Item:";
            // 
            // AddListBoxItemForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(292, 134);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.label1,
                                                                          this.cancelButton,
                                                                          this.okButton,
                                                                          this.itemTextBox});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddListBoxItemForm";
            this.Text = "Add Item for List Box";
            this.ResumeLayout(false);

        }
        #endregion

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            _newItem = itemTextBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
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

        public string NewItem
        {
            get { return _newItem; }
        }
    }
}
