using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ClipboardFormatsAvailable
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormatsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lbFormats;
		private System.Windows.Forms.Button cmdCheckClipboard;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormatsForm()
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
			this.lbFormats = new System.Windows.Forms.ListBox();
			this.cmdCheckClipboard = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbFormats
			// 
			this.lbFormats.Location = new System.Drawing.Point(8, 8);
			this.lbFormats.Name = "lbFormats";
			this.lbFormats.Size = new System.Drawing.Size(272, 199);
			this.lbFormats.TabIndex = 0;
			// 
			// cmdCheckClipboard
			// 
			this.cmdCheckClipboard.Location = new System.Drawing.Point(8, 216);
			this.cmdCheckClipboard.Name = "cmdCheckClipboard";
			this.cmdCheckClipboard.Size = new System.Drawing.Size(104, 23);
			this.cmdCheckClipboard.TabIndex = 1;
			this.cmdCheckClipboard.Text = "check clipboard";
			this.cmdCheckClipboard.Click += new System.EventHandler(this.cmdCheckClipboard_Click);
			// 
			// FormatsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCheckClipboard,
																		  this.lbFormats});
			this.Name = "FormatsForm";
			this.Text = "View Formats";
			this.Load += new System.EventHandler(this.FormatsForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormatsForm());
		}

		private void cmdCheckClipboard_Click(object sender, System.EventArgs e)
		{
			lbFormats.Items.Clear();
			IDataObject data = Clipboard.GetDataObject();
			// get the native formats only
			string[] astrFormats = data.GetFormats(true);
			for (int i=0; i < astrFormats.Length; i++)
				lbFormats.Items.Add(astrFormats[i]);
		}

		private void FormatsForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
