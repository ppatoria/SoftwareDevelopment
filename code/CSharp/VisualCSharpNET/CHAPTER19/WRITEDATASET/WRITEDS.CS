using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WriteDataSet
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmXMLWrite : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.Button btnWriteSchema;

		DataSet myDataSet = null;

		public frmXMLWrite()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// TODO: Add any constructor code after InitializeComponent call
			
			// Create the data set object 
			myDataSet = new DataSet();

			// Load XML data into a dataset:
			myDataSet.ReadXml(@"c:\Videos.xml");
		}

		/// <summary>
		/// Clean up any resources being used.
		// </summary>
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
			this.btnWrite = new System.Windows.Forms.Button();
			this.btnWriteSchema = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnWrite
			// 
			this.btnWrite.Location = new System.Drawing.Point(24, 112);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(296, 40);
			this.btnWrite.TabIndex = 0;
			this.btnWrite.Text = "Write XML File";
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// btnWriteSchema
			// 
			this.btnWriteSchema.Location = new System.Drawing.Point(24, 168);
			this.btnWriteSchema.Name = "btnWriteSchema";
			this.btnWriteSchema.Size = new System.Drawing.Size(296, 40);
			this.btnWriteSchema.TabIndex = 1;
			this.btnWriteSchema.Text = "Write XML Schema";
			this.btnWriteSchema.Click += new System.EventHandler(this.btnWriteSchema_Click);
			// 
			// frmXMLWrite
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnWriteSchema,
																		  this.btnWrite});
			this.Name = "frmXMLWrite";
			this.Text = "Write Data Set";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmXMLWrite());
		}

		private void btnWrite_Click(object sender, System.EventArgs e)
		{
			myDataSet.WriteXml(@"c:\NewFile.xml");
			btnWrite.Text += " *";
		}

		private void btnWriteSchema_Click(object sender, System.EventArgs e)
		{
			myDataSet.WriteXmlSchema(@"c:\NewSchema.xsl");
			btnWriteSchema.Text += " *";
		}

	}
}
