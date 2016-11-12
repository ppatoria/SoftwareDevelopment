using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SimpleClipboard
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ClipboardTestForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdString2Clipboard;
		private System.Windows.Forms.Button cmdImage2Clipboard;
		private System.Windows.Forms.Button cmdGetAsString;
		private System.Windows.Forms.Button cmdGetImage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClipboardTestForm()
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
			this.cmdString2Clipboard = new System.Windows.Forms.Button();
			this.cmdImage2Clipboard = new System.Windows.Forms.Button();
			this.cmdGetAsString = new System.Windows.Forms.Button();
			this.cmdGetImage = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdString2Clipboard
			// 
			this.cmdString2Clipboard.Location = new System.Drawing.Point(8, 16);
			this.cmdString2Clipboard.Name = "cmdString2Clipboard";
			this.cmdString2Clipboard.Size = new System.Drawing.Size(136, 23);
			this.cmdString2Clipboard.TabIndex = 0;
			this.cmdString2Clipboard.Text = "put string in clipboard";
			this.cmdString2Clipboard.Click += new System.EventHandler(this.cmdString2Clipboard_Click);
			// 
			// cmdImage2Clipboard
			// 
			this.cmdImage2Clipboard.Location = new System.Drawing.Point(8, 48);
			this.cmdImage2Clipboard.Name = "cmdImage2Clipboard";
			this.cmdImage2Clipboard.Size = new System.Drawing.Size(136, 23);
			this.cmdImage2Clipboard.TabIndex = 1;
			this.cmdImage2Clipboard.Text = "put image in clipboard";
			this.cmdImage2Clipboard.Click += new System.EventHandler(this.cmdImage2Clipboard_Click);
			// 
			// cmdGetAsString
			// 
			this.cmdGetAsString.Location = new System.Drawing.Point(176, 16);
			this.cmdGetAsString.Name = "cmdGetAsString";
			this.cmdGetAsString.Size = new System.Drawing.Size(136, 23);
			this.cmdGetAsString.TabIndex = 2;
			this.cmdGetAsString.Text = "get as string";
			this.cmdGetAsString.Click += new System.EventHandler(this.cmdGetAsString_Click);
			// 
			// cmdGetImage
			// 
			this.cmdGetImage.Location = new System.Drawing.Point(176, 48);
			this.cmdGetImage.Name = "cmdGetImage";
			this.cmdGetImage.Size = new System.Drawing.Size(136, 23);
			this.cmdGetImage.TabIndex = 3;
			this.cmdGetImage.Text = "get image";
			this.cmdGetImage.Click += new System.EventHandler(this.cmdGetImage_Click);
			// 
			// ClipboardTestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 149);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdGetImage,
																		  this.cmdGetAsString,
																		  this.cmdImage2Clipboard,
																		  this.cmdString2Clipboard});
			this.Name = "ClipboardTestForm";
			this.Text = "Clipboard Test";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClipboardTestForm());
		}

		private void cmdString2Clipboard_Click(object sender, System.EventArgs e)
		{
			string strText = "Hello World";
			Clipboard.SetDataObject(strText, true);
		}

		private void cmdImage2Clipboard_Click(object sender, System.EventArgs e)
		{
			Bitmap bmp2Clipboard = new Bitmap("pinz.jpg");
			Clipboard.SetDataObject(bmp2Clipboard, true);
		}

		private void cmdGetAsString_Click(object sender, System.EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();
			if (data.GetDataPresent(typeof(string)))
			{
				string strData = (string)data.GetData(typeof(string));
				MessageBox.Show(strData);
			}
			else
			{
				MessageBox.Show("Data not retrievable as string");
			}
		}

		private void cmdGetImage_Click(object sender, System.EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();
			if (data.GetDataPresent(typeof(Bitmap)))
			{
				Bitmap bmp = (Bitmap)data.GetData(typeof(Bitmap));
				bmp.Save(@"c:\cliptest.bmp");
				MessageBox.Show("Saved to c:\\cliptest.bmp");
			}
			else
			{
				MessageBox.Show("Data not retrievable as bitmap");
			}
		}
	}
}
