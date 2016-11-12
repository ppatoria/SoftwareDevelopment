using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSPress.CSharpCoreRef.Controls
{
    /// <summary>
    /// Summary description for TextBoxForm.
    /// </summary>
    public class TextBoxForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox multilineTextBox;
        private System.Windows.Forms.TextBox flatTextBox;
        private System.Windows.Forms.TextBox normalTextBox;
        private System.Windows.Forms.Label normalContents;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public TextBoxForm()
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
            this.normalTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.multilineTextBox = new System.Windows.Forms.TextBox();
            this.flatTextBox = new System.Windows.Forms.TextBox();
            this.normalContents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // normalTextBox
            // 
            this.normalTextBox.Location = new System.Drawing.Point(32, 56);
            this.normalTextBox.Name = "normalTextBox";
            this.normalTextBox.TabIndex = 0;
            this.normalTextBox.Text = "";
            this.normalTextBox.TextChanged += new System.EventHandler(this.normalTextBox_TextChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(296, 24);
            this.closeButton.Name = "closeButton";
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.TabIndex = 2;
            this.label1.Text = "Normal";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(32, 120);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Name = "label2";
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 96);
            this.label3.Name = "label3";
            this.label3.TabIndex = 5;
            this.label3.Text = "Multiple Lines";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 160);
            this.label4.Name = "label4";
            this.label4.TabIndex = 6;
            this.label4.Text = "Flat";
            // 
            // multilineTextBox
            // 
            this.multilineTextBox.Location = new System.Drawing.Point(184, 120);
            this.multilineTextBox.Multiline = true;
            this.multilineTextBox.Name = "multilineTextBox";
            this.multilineTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.multilineTextBox.Size = new System.Drawing.Size(176, 88);
            this.multilineTextBox.TabIndex = 7;
            this.multilineTextBox.Text = "";
            this.multilineTextBox.WordWrap = false;
            // 
            // flatTextBox
            // 
            this.flatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flatTextBox.Location = new System.Drawing.Point(32, 184);
            this.flatTextBox.Name = "flatTextBox";
            this.flatTextBox.TabIndex = 8;
            this.flatTextBox.Text = "";
            // 
            // normalContents
            // 
            this.normalContents.Location = new System.Drawing.Point(144, 24);
            this.normalContents.Name = "normalContents";
            this.normalContents.Size = new System.Drawing.Size(136, 56);
            this.normalContents.TabIndex = 10;
            // 
            // TextBoxForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 232);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.normalContents,
                                                                          this.flatTextBox,
                                                                          this.multilineTextBox,
                                                                          this.label4,
                                                                          this.label3,
                                                                          this.label2,
                                                                          this.passwordTextBox,
                                                                          this.label1,
                                                                          this.closeButton,
                                                                          this.normalTextBox});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TextBoxForm";
            this.Text = "TextBox Demo Form";
            this.ResumeLayout(false);

        }
        #endregion

        private void getContents_Click(object sender, System.EventArgs e)
        {
            string [] strs = multilineTextBox.Lines;
            foreach(string line in strs)
            {
                MessageBox.Show(line, "Line by line display");
            }
        }

        private void normalTextBox_TextChanged(object sender, System.EventArgs e)
        {
            normalContents.Text = "Contents: " + normalTextBox.Text;
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

    }
}
