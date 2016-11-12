using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace MSPress.CSharpCoreRef.CursorSwap
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm: System.Windows.Forms.Form
    {
        Cursor _handCursor;
        Cursor _embeddedCursor;
        Cursor _smileyCursor;

        private System.Windows.Forms.RadioButton arrowRadioButton;
        private System.Windows.Forms.RadioButton crossRadioButton;
        private System.Windows.Forms.RadioButton defaultRadioButton;
        private System.Windows.Forms.RadioButton handRadioButton;
        private System.Windows.Forms.RadioButton ibeamRadioButton;
        private System.Windows.Forms.RadioButton waitRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton smileyRadioButton;
        private System.Windows.Forms.RadioButton externalRadioButton;
        private System.Windows.Forms.RadioButton embeddedRadioButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        
		// Platform Invoke method to load 
		// a standard mouse pointer using Win32
        [DllImport("user32.dll", EntryPoint="LoadCursor")]
        private static extern IntPtr InteropLoadCursor(int instance,
            int resource);

        // From the Plaform SDK winuser.h header file
        const int IDC_HAND = 32649;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            // Allocate custom cursor objects
            IntPtr externalHand = InteropLoadCursor(0, IDC_HAND);
            _handCursor = new Cursor(externalHand);
            _embeddedCursor = new Cursor(this.GetType(), "Smiley2.cur");
            _smileyCursor = new Cursor("..\\..\\smiley.cur");
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
                _handCursor.Dispose();
                _embeddedCursor.Dispose();
                _smileyCursor.Dispose();
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
            this.arrowRadioButton = new System.Windows.Forms.RadioButton();
            this.crossRadioButton = new System.Windows.Forms.RadioButton();
            this.defaultRadioButton = new System.Windows.Forms.RadioButton();
            this.handRadioButton = new System.Windows.Forms.RadioButton();
            this.ibeamRadioButton = new System.Windows.Forms.RadioButton();
            this.waitRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.smileyRadioButton = new System.Windows.Forms.RadioButton();
            this.externalRadioButton = new System.Windows.Forms.RadioButton();
            this.embeddedRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // arrowRadioButton
            // 
            this.arrowRadioButton.Location = new System.Drawing.Point(24, 64);
            this.arrowRadioButton.Name = "arrowRadioButton";
            this.arrowRadioButton.TabIndex = 0;
            this.arrowRadioButton.Text = "Arrow";
            this.arrowRadioButton.CheckedChanged += new System.EventHandler(this.arrowRadioButton_CheckedChanged);
            // 
            // crossRadioButton
            // 
            this.crossRadioButton.Location = new System.Drawing.Point(24, 96);
            this.crossRadioButton.Name = "crossRadioButton";
            this.crossRadioButton.TabIndex = 1;
            this.crossRadioButton.Text = "Cross";
            this.crossRadioButton.CheckedChanged += new System.EventHandler(this.crossRadioButton_CheckedChanged);
            // 
            // defaultRadioButton
            // 
            this.defaultRadioButton.Location = new System.Drawing.Point(24, 128);
            this.defaultRadioButton.Name = "defaultRadioButton";
            this.defaultRadioButton.TabIndex = 2;
            this.defaultRadioButton.Text = "Default";
            this.defaultRadioButton.CheckedChanged += new System.EventHandler(this.defaultRadioButton_CheckedChanged);
            // 
            // handRadioButton
            // 
            this.handRadioButton.Location = new System.Drawing.Point(160, 64);
            this.handRadioButton.Name = "handRadioButton";
            this.handRadioButton.TabIndex = 4;
            this.handRadioButton.Text = "Hand";
            this.handRadioButton.CheckedChanged += new System.EventHandler(this.handRadioButton_CheckedChanged);
            // 
            // ibeamRadioButton
            // 
            this.ibeamRadioButton.Location = new System.Drawing.Point(160, 96);
            this.ibeamRadioButton.Name = "ibeamRadioButton";
            this.ibeamRadioButton.TabIndex = 5;
            this.ibeamRadioButton.Text = "I-Beam";
            this.ibeamRadioButton.CheckedChanged += new System.EventHandler(this.ibeamRadioButton_CheckedChanged);
            // 
            // waitRadioButton
            // 
            this.waitRadioButton.Location = new System.Drawing.Point(160, 128);
            this.waitRadioButton.Name = "waitRadioButton";
            this.waitRadioButton.TabIndex = 6;
            this.waitRadioButton.Text = "Wait Cursor";
            this.waitRadioButton.CheckedChanged += new System.EventHandler(this.waitRadioButton_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(192, 16);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // smileyRadioButton
            // 
            this.smileyRadioButton.Location = new System.Drawing.Point(24, 160);
            this.smileyRadioButton.Name = "smileyRadioButton";
            this.smileyRadioButton.TabIndex = 3;
            this.smileyRadioButton.Text = "Custom- Smiley";
            this.smileyRadioButton.CheckedChanged += new System.EventHandler(this.smileyRadioButton_CheckedChanged);
            // 
            // externalRadioButton
            // 
            this.externalRadioButton.Location = new System.Drawing.Point(160, 160);
            this.externalRadioButton.Name = "externalRadioButton";
            this.externalRadioButton.TabIndex = 8;
            this.externalRadioButton.Text = "External - Hand";
            this.externalRadioButton.CheckedChanged += new System.EventHandler(this.externalRadioButton_CheckedChanged);
            // 
            // embeddedRadioButton
            // 
            this.embeddedRadioButton.Location = new System.Drawing.Point(24, 192);
            this.embeddedRadioButton.Name = "embeddedRadioButton";
            this.embeddedRadioButton.Size = new System.Drawing.Size(168, 24);
            this.embeddedRadioButton.TabIndex = 9;
            this.embeddedRadioButton.Text = "Custom- Embedded Smiley";
            this.embeddedRadioButton.CheckedChanged += new System.EventHandler(this.embeddedRadioButton_CheckedChanged);
            // 
            // mainForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 254);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.embeddedRadioButton,
                                                                          this.externalRadioButton,
                                                                          this.smileyRadioButton,
                                                                          this.okButton,
                                                                          this.waitRadioButton,
                                                                          this.ibeamRadioButton,
                                                                          this.handRadioButton,
                                                                          this.defaultRadioButton,
                                                                          this.crossRadioButton,
                                                                          this.arrowRadioButton});
            this.Name = "mainForm";
            this.Text = "Cursor Demo";
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        private void arrowRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void crossRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void defaultRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void handRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void ibeamRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.IBeam;
        }

        private void waitRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void smileyRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = _smileyCursor;
        }

        private void externalRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = _handCursor;
        }

        private void embeddedRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Cursor = _embeddedCursor;
        }
    }
}
