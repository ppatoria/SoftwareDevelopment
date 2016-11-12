using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

namespace DatagridXml
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class XmlDataGridForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgLateXmlBound;
		private System.Windows.Forms.Button cmdLoad;
		private System.Windows.Forms.Button cmdSave;
		private XmlDataDocument xdocSnowReports;
		private System.Windows.Forms.DataGridTableStyle dgsResorts;
		private System.Windows.Forms.DataGridTextBoxColumn tbcResort;
		private System.Windows.Forms.DataGridTextBoxColumn tbcSnowMin;
		private System.Windows.Forms.DataGridTextBoxColumn tbcSnowHigh;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XmlDataGridForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			xdocSnowReports = new XmlDataDocument();
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
			this.dgLateXmlBound = new System.Windows.Forms.DataGrid();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.dgsResorts = new System.Windows.Forms.DataGridTableStyle();
			this.tbcResort = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbcSnowMin = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbcSnowHigh = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgLateXmlBound)).BeginInit();
			this.SuspendLayout();
			// 
			// dgLateXmlBound
			// 
			this.dgLateXmlBound.DataMember = "";
			this.dgLateXmlBound.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgLateXmlBound.Name = "dgLateXmlBound";
			this.dgLateXmlBound.Size = new System.Drawing.Size(432, 264);
			this.dgLateXmlBound.TabIndex = 0;
			this.dgLateXmlBound.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dgsResorts});
			// 
			// cmdLoad
			// 
			this.cmdLoad.Location = new System.Drawing.Point(8, 280);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.TabIndex = 1;
			this.cmdLoad.Text = "load";
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			// 
			// cmdSave
			// 
			this.cmdSave.Location = new System.Drawing.Point(96, 280);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 2;
			this.cmdSave.Text = "save";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// dgsResorts
			// 
			this.dgsResorts.DataGrid = this.dgLateXmlBound;
			this.dgsResorts.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.tbcResort,
																										 this.tbcSnowMin,
																										 this.tbcSnowHigh});
			this.dgsResorts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgsResorts.MappingName = "Resort";
			// 
			// tbcResort
			// 
			this.tbcResort.Format = "";
			this.tbcResort.FormatInfo = null;
			this.tbcResort.HeaderText = "Resort name";
			this.tbcResort.MappingName = "Name";
			this.tbcResort.Width = 75;
			// 
			// tbcSnowMin
			// 
			this.tbcSnowMin.Format = "";
			this.tbcSnowMin.FormatInfo = null;
			this.tbcSnowMin.HeaderText = "Min snow";
			this.tbcSnowMin.MappingName = "SnowLow";
			this.tbcSnowMin.Width = 75;
			// 
			// tbcSnowHigh
			// 
			this.tbcSnowHigh.Format = "";
			this.tbcSnowHigh.FormatInfo = null;
			this.tbcSnowHigh.HeaderText = "Max snow";
			this.tbcSnowHigh.MappingName = "SnowHigh";
			this.tbcSnowHigh.Width = 75;
			// 
			// XmlDataGridForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 309);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdSave,
																		  this.cmdLoad,
																		  this.dgLateXmlBound});
			this.Name = "XmlDataGridForm";
			this.Text = "XML in DataGrid";
			((System.ComponentModel.ISupportInitialize)(this.dgLateXmlBound)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new XmlDataGridForm());
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			// Infer the DataSet schema from the XML data and load the XML Data
			xdocSnowReports.DataSet.ReadXml(new StreamReader("SampleData.xml"), XmlReadMode.InferSchema);
			dgLateXmlBound.SetDataBinding(xdocSnowReports.DataSet, "Resort");

			// get the date of the snow report, and show as caption of DataGrid
			DataRow dr = xdocSnowReports.DataSet.Tables["SnowReports"].Rows[0];
			string strCaption = dr["Date"].ToString();
			this.dgLateXmlBound.CaptionText = "Snow report on " + strCaption;
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			xdocSnowReports.DataSet.WriteXml("hardcodedfilename.xml");
		}
	}
}
