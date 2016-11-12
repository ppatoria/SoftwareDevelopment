namespace ThreadMonitorUtility
{
    partial class ShowThreadActivity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlThreadActivity1 = new ctrlThreadActivity();
            this.SuspendLayout();
            // 
            // ctrlThreadActivity1
            // 
            this.ctrlThreadActivity1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ctrlThreadActivity1.Dock = System.Windows.Forms.DockStyle.Fill;
            
            this.ctrlThreadActivity1.Location = new System.Drawing.Point(0, 0);
            this.ctrlThreadActivity1.Name = "ctrlThreadActivity1";
            this.ctrlThreadActivity1.Size = new System.Drawing.Size(813, 700);
            this.ctrlThreadActivity1.TabIndex = 0;
            // 
            // ShowThreadActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 700);
            this.Controls.Add(this.ctrlThreadActivity1);
            this.Name = "ShowThreadActivity";
            this.Text = "ShowThreadActivity";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlThreadActivity ctrlThreadActivity1;
    }
}