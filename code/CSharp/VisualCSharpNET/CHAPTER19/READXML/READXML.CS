using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Text;

namespace ReadXML
{
	public class frmReadXML : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtNode;
		private System.Windows.Forms.Label lblNode;
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

        private XmlTextReader xtr = null;

		public frmReadXML()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

            // Create XmlTextReader object.
            xtr = new XmlTextReader(@"C:\Videos.xml");
			// Don't ignore white space.
			xtr.WhitespaceHandling = WhitespaceHandling.All;
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
			this.txtNode = new System.Windows.Forms.TextBox();
			this.lblNode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNode
			// 
			this.txtNode.Location = new System.Drawing.Point(104, 36);
			this.txtNode.Name = "txtNode";
			this.txtNode.ReadOnly = true;
			this.txtNode.Size = new System.Drawing.Size(144, 20);
			this.txtNode.TabIndex = 0;
			this.txtNode.Text = "";
			// 
			// lblNode
			// 
			this.lblNode.Location = new System.Drawing.Point(24, 40);
			this.lblNode.Name = "lblNode";
			this.lblNode.Size = new System.Drawing.Size(48, 16);
			this.lblNode.TabIndex = 1;
			this.lblNode.Text = "Node:";
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
			this.label2.Location = new System.Drawing.Point(24, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Name:";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(104, 80);
			this.txtValue.Name = "txtValue";
			this.txtValue.ReadOnly = true;
			this.txtValue.Size = new System.Drawing.Size(144, 20);
			this.txtValue.TabIndex = 4;
			this.txtValue.Text = "";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(104, 128);
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
			this.btnExit.Click += new System.EventHandler(this.button1_Click);
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
			this.txtDisplay.Location = new System.Drawing.Point(24, 160);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(232, 24);
			this.txtDisplay.TabIndex = 8;
			this.txtDisplay.Text = "Click Next for first item.";
			// 
			// frmReadXML
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 262);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtDisplay,
																		  this.btnNext,
																		  this.btnExit,
																		  this.txtName,
																		  this.txtValue,
																		  this.label2,
																		  this.label1,
																		  this.lblNode,
																		  this.txtNode});
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( xtr != null)
				xtr.Close();

			Application.Exit();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            StringBuilder str = new StringBuilder("Formatted: ");

			if (xtr.Read() == true)
			{
				txtNode.Text	= xtr.NodeType.ToString();
				txtName.Text	= xtr.Name.ToString();
				txtValue.Text	= xtr.Value.ToString();

				switch (xtr.NodeType)
				{
					case XmlNodeType.Element:
						str.AppendFormat("<{0}>",xtr.Name);
						break;
					case XmlNodeType.Text:
						break;
					case XmlNodeType.CDATA:
						str.AppendFormat("<![CDATA[{0}]]>", xtr.Value);
						break;
					case XmlNodeType.ProcessingInstruction:
						str.AppendFormat("<?{0} {1}?>", xtr.Name, xtr.Value);
						break;
					case XmlNodeType.Comment:
						str.AppendFormat("<!--{0}-->", xtr.Value);
						break;
					case XmlNodeType.XmlDeclaration:
						//Console.Write("<?xml version='1.0'?>");
						break;
					case XmlNodeType.DocumentType:
						str.AppendFormat("<!DOCTYPE {0} [{1}]", xtr.Name, xtr.Value);
						break;
					case XmlNodeType.EntityReference:
						str.Append(xtr.Name);
						break;
					case XmlNodeType.EndElement:
						str.AppendFormat("</{0}>", xtr.Name);
						break;
					case XmlNodeType.Whitespace:
						//Console.Write("{0}", xtr.Value );
						break;
				}

				txtDisplay.Text = str.ToString();
			}
			else
			{
				// End of file
				txtValue.Text = "EoF";
				txtName.Text  = "EoF";
				txtNode.Text  = "Eof";
			}
		}
	}
}
