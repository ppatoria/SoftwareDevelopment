using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace FileDropTarget
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FileDropTargetForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtMain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FileDropTargetForm()
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
			this.txtMain = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtMain
			// 
			this.txtMain.AcceptsReturn = true;
			this.txtMain.AcceptsTab = true;
			this.txtMain.AllowDrop = true;
			this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMain.Multiline = true;
			this.txtMain.Name = "txtMain";
			this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMain.Size = new System.Drawing.Size(292, 273);
			this.txtMain.TabIndex = 0;
			this.txtMain.Text = "";
			this.txtMain.DragOver += new System.Windows.Forms.DragEventHandler(this.txtMain_DragOver);
			this.txtMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMain_DragDrop);
			this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
			// 
			// FileDropTargetForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtMain});
			this.Name = "FileDropTargetForm";
			this.Text = "FileDrop Target";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FileDropTargetForm());
		}

		private void txtMain_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void txtMain_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
				StreamReader reader = new StreamReader(strFiles[0]);
				this.txtMain.Clear();
				this.txtMain.Text = reader.ReadToEnd();
				reader.Close();
			}
		}

		private void txtMain_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
