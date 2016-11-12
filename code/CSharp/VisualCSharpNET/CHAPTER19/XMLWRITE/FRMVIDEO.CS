using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Text;

namespace MyXMLApplication
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmVideo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtVideo;
		private System.Windows.Forms.TextBox txtLength;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox txtStar;
		private System.Windows.Forms.ComboBox cmbRating;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;

        // Define an XmlTextWriter object.
        private XmlTextWriter xtw;

		public FrmVideo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Create an XmlTextWriter object and initialize a few 
			// properties.
            xtw = new XmlTextWriter(@"c:\Videos.xml", null);

            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 3;

			// Start the XML document.
            xtw.WriteStartDocument();  
    
            xtw.WriteComment("Video Library");
			xtw.WriteComment(
				"This is a file containing a number of videos.");
			// Create the root element.
            xtw.WriteStartElement("VideoLibrary");
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
			this.components = new System.ComponentModel.Container();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtVideo = new System.Windows.Forms.TextBox();
			this.txtLength = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtStar = new System.Windows.Forms.TextBox();
			this.cmbRating = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(32, 232);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(184, 40);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(288, 232);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(48, 40);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtVideo
			// 
			this.txtVideo.Location = new System.Drawing.Point(80, 40);
			this.txtVideo.Name = "txtVideo";
			this.txtVideo.Size = new System.Drawing.Size(256, 20);
			this.txtVideo.TabIndex = 2;
			this.txtVideo.Text = "";
			// 
			// txtLength
			// 
			this.txtLength.Location = new System.Drawing.Point(80, 80);
			this.txtLength.Name = "txtLength";
			this.txtLength.Size = new System.Drawing.Size(88, 20);
			this.txtLength.TabIndex = 3;
			this.txtLength.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Length";
			// 
			// txtStar
			// 
			this.txtStar.Location = new System.Drawing.Point(80, 120);
			this.txtStar.Name = "txtStar";
			this.txtStar.Size = new System.Drawing.Size(256, 20);
			this.txtStar.TabIndex = 6;
			this.txtStar.Text = "";
			// 
			// cmbRating
			// 
			this.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRating.Items.AddRange(new object[] {
														   "G",
														   "PG",
														   "PG-13",
														   "R",
														   "NC-17",
														   "X"});
			this.cmbRating.Location = new System.Drawing.Point(80, 160);
			this.cmbRating.Name = "cmbRating";
			this.cmbRating.Size = new System.Drawing.Size(64, 21);
			this.cmbRating.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Star";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Rating:";
			// 
			// FrmVideo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 286);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label4,
																		  this.label3,
																		  this.cmbRating,
																		  this.txtStar,
																		  this.label2,
																		  this.label1,
																		  this.txtLength,
																		  this.txtVideo,
																		  this.btnExit,
																		  this.btnAdd});
			this.Name = "FrmVideo";
			this.Text = "My XML Program";
			this.Load += new System.EventHandler(this.FrmVideo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			// Create the form to gather input.
			Application.Run(new FrmVideo());  
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			// Close the root element, and close the file.
            xtw.WriteEndElement();
			xtw.WriteEndDocument();
            xtw.Flush();  // Flush the stream.
            xtw.Close();  // Close the XmlTextWriter object.

            Application.Exit();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			// Add the data on the screen to the XML file.
			// Start a Video element.
            xtw.WriteStartElement("Video");  
			// Add a Title element.
            xtw.WriteElementString("Title", txtVideo.Text ); 
			// Start a Length element.
            xtw.WriteStartElement("Length");
			// Add the Measurement attribute to the Length element.
			xtw.WriteAttributeString("Measurement", "minutes");
			// Add the data to the Length element. 
			xtw.WriteString(txtLength.Text );
			xtw.WriteEndElement();  // End Length element.
			xtw.WriteElementString("star", txtStar.Text);
			xtw.WriteElementString("rating", cmbRating.Text);
            xtw.WriteEndElement(); // End Video element
			// Put insertion point back in first field.
			txtVideo.Focus();  
			// Clear the fields on the screen.
			txtVideo.Text = ""; 
			txtLength.Text = "";
			txtStar.Text = "";
			cmbRating.Text = "";
		}

		private void FrmVideo_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
