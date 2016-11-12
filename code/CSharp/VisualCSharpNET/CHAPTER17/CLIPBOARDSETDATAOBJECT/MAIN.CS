using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ClipboardSetDataObject
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MultipleFormatsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdSet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MultipleFormatsForm()
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
			this.cmdSet = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdSet
			// 
			this.cmdSet.Location = new System.Drawing.Point(56, 40);
			this.cmdSet.Name = "cmdSet";
			this.cmdSet.Size = new System.Drawing.Size(160, 23);
			this.cmdSet.TabIndex = 0;
			this.cmdSet.Text = "set multiple formats";
			this.cmdSet.Click += new System.EventHandler(this.cmdSet_Click);
			// 
			// MultipleFormatsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdSet});
			this.Name = "MultipleFormatsForm";
			this.Text = "Set multiple formats";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MultipleFormatsForm());
		}

		private void cmdSet_Click(object sender, System.EventArgs e)
		{
			string strText = "Hello World";
			string strHtml = "<h1>Hello World</h1>";
			DataObject data = new DataObject();
			data.SetData(strText);
			data.SetData(DataFormats.Html, strHtml);
			data.SetData("My.Internal.Format","Some internal data");
			Clipboard.SetDataObject(data, true);
		}
	}
}
