using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Text;

namespace ReadDataSet
{
	public class frmReadXML : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnNext;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label txtDisplay;
		// Counter to loop through elements
		private int ctr = 0;
		private System.Windows.Forms.Button btnUpdate; 

		XmlDocument myDoc = null;  // For XmlDocument object

		public frmReadXML()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// TODO: Add any constructor code 
			// after InitializeComponent call.
			
			// Allocate XmlDocument object.
			myDoc = new XmlDocument();

			// Load XML data.
			myDoc.Load(@"C:\Videos.xml");
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.Label();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Value:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Name:";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(104, 80);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(144, 20);
			this.txtValue.TabIndex = 4;
			this.txtValue.Text = "";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(104, 40);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(144, 20);
			this.txtName.TabIndex = 5;
			this.txtName.Text = "";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(200, 216);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(56, 24);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(104, 192);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 48);
			this.btnNext.TabIndex = 7;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(24, 136);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(232, 24);
			this.txtDisplay.TabIndex = 8;
			this.txtDisplay.Text = "Click Next for first item.";
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(16, 192);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 48);
			this.btnUpdate.TabIndex = 9;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// frmReadXML
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 262);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnUpdate,
																		  this.txtDisplay,
																		  this.btnNext,
																		  this.btnExit,
																		  this.txtName,
																		  this.txtValue,
																		  this.label2,
																		  this.label1});
			this.Name = "frmReadXML";
			this.Text = "Read XML";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmReadXML());
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			myDoc.Save(@"C:\NewVideos.xml");
			Application.Exit();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{	
			XmlNode aNode = myDoc.DocumentElement
				.ChildNodes[0].ChildNodes[ctr];

			if (++ctr >= myDoc.DocumentElement
				.ChildNodes[0].ChildNodes.Count)
				ctr = 0;

			txtName.Text	= aNode.Name;
			txtValue.Text	= aNode.ChildNodes[0].Value;
			txtDisplay.Text = aNode.InnerText;
		}

		private void btnUpdate_Click(object sender, 
			System.EventArgs e)
		{
			int tmp = 0;
         // Need the previous value of the ctr variable.
			if (ctr == 0) 
         {
            // Set tmp to the last element in the array (count – 1).
            tmp = myDoc.DocumentElement
				.ChildNodes[0].ChildNodes.Count - 1;
         }
         else 
				tmp = ctr - 1;

         // If Name of node is blank, skip update.
         // Name of node will be blank when program starts.
			if( myDoc.DocumentElement
				.ChildNodes[0].ChildNodes[tmp].Name != "" )
			{
				myDoc.DocumentElement.ChildNodes[0]
					.ChildNodes[tmp].ChildNodes[0].Value = 
					txtValue.Text;
				txtDisplay.Text = "Updated: " 
					+ myDoc.DocumentElement.ChildNodes[0]
					.ChildNodes[tmp].ChildNodes[0].Value;
			}
		}
	}
}
