using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DatagridDbconnSimple
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class SimpleDbForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgData;
		private System.Data.SqlClient.SqlConnection sqlcnNetSDK;
		private System.Data.SqlClient.SqlDataAdapter sqldaCustomers;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private DatagridDbconnSimple.dsCustomers dsCustomers1;
		private System.Windows.Forms.Button cmdLoad;
		private System.Windows.Forms.Button cmdUpdateDatabase;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SimpleDbForm()
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
			this.dgData = new System.Windows.Forms.DataGrid();
			this.dsCustomers1 = new DatagridDbconnSimple.dsCustomers();
			this.sqlcnNetSDK = new System.Data.SqlClient.SqlConnection();
			this.sqldaCustomers = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.cmdUpdateDatabase = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCustomers1)).BeginInit();
			this.SuspendLayout();
			// 
			// dgData
			// 
			this.dgData.DataMember = "Customers";
			this.dgData.DataSource = this.dsCustomers1;
			this.dgData.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgData.Name = "dgData";
			this.dgData.Size = new System.Drawing.Size(552, 304);
			this.dgData.TabIndex = 0;
			// 
			// dsCustomers1
			// 
			this.dsCustomers1.DataSetName = "dsCustomers";
			this.dsCustomers1.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsCustomers1.Namespace = "http://www.tempuri.org/dsCustomers.xsd";
			// 
			// sqlcnNetSDK
			// 
			this.sqlcnNetSDK.ConnectionString = "data source=(local)\\NetSDK;initial catalog=Northwind;integrated security=SSPI;per" +
				"sist security info=False;workstation id=DOTTIE;packet size=4096";
			// 
			// sqldaCustomers
			// 
			this.sqldaCustomers.DeleteCommand = this.sqlDeleteCommand1;
			this.sqldaCustomers.InsertCommand = this.sqlInsertCommand1;
			this.sqldaCustomers.SelectCommand = this.sqlSelectCommand1;
			this.sqldaCustomers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "Customers", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
																																																				  new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
																																																				  new System.Data.Common.DataColumnMapping("Address", "Address"),
																																																				  new System.Data.Common.DataColumnMapping("City", "City"),
																																																				  new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
																																																				  new System.Data.Common.DataColumnMapping("Country", "Country")})});
			this.sqldaCustomers.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM Customers WHERE (CustomerID = @Original_CustomerID) AND (Address = @Original_Address OR @Original_Address IS NULL AND Address IS NULL) AND (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Original_CompanyName) AND (Country = @Original_Country OR @Original_Country IS NULL AND Country IS NULL) AND (PostalCode = @Original_PostalCode OR @Original_PostalCode IS NULL AND PostalCode IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlcnNetSDK;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Address", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "City", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Country", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PostalCode", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO Customers(CustomerID, CompanyName, Address, City, PostalCode, Country) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country); SELECT CustomerID, CompanyName, Address, City, PostalCode, Country FROM Customers WHERE (CustomerID = @CustomerID)";
			this.sqlInsertCommand1.Connection = this.sqlcnNetSDK;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT CustomerID, CompanyName, Address, City, PostalCode, Country FROM Customers" +
				"";
			this.sqlSelectCommand1.Connection = this.sqlcnNetSDK;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName, Address = @Address, City = @City, PostalCode = @PostalCode, Country = @Country WHERE (CustomerID = @Original_CustomerID) AND (Address = @Original_Address OR @Original_Address IS NULL AND Address IS NULL) AND (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Original_CompanyName) AND (Country = @Original_Country OR @Original_Country IS NULL AND Country IS NULL) AND (PostalCode = @Original_PostalCode OR @Original_PostalCode IS NULL AND PostalCode IS NULL); SELECT CustomerID, CompanyName, Address, City, PostalCode, Country FROM Customers WHERE (CustomerID = @CustomerID)";
			this.sqlUpdateCommand1.Connection = this.sqlcnNetSDK;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Address", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "City", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Country", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PostalCode", System.Data.DataRowVersion.Original, null));
			// 
			// cmdLoad
			// 
			this.cmdLoad.Location = new System.Drawing.Point(8, 312);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.Size = new System.Drawing.Size(96, 24);
			this.cmdLoad.TabIndex = 1;
			this.cmdLoad.Text = "load";
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			// 
			// cmdUpdateDatabase
			// 
			this.cmdUpdateDatabase.Location = new System.Drawing.Point(112, 312);
			this.cmdUpdateDatabase.Name = "cmdUpdateDatabase";
			this.cmdUpdateDatabase.Size = new System.Drawing.Size(112, 24);
			this.cmdUpdateDatabase.TabIndex = 2;
			this.cmdUpdateDatabase.Text = "update db";
			this.cmdUpdateDatabase.Click += new System.EventHandler(this.cmdUpdateDatabase_Click);
			// 
			// SimpleDbForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdUpdateDatabase,
																		  this.cmdLoad,
																		  this.dgData});
			this.Name = "SimpleDbForm";
			this.Text = "Simple database connectivity";
			((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCustomers1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SimpleDbForm());
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			dsCustomers1.Clear();
			sqldaCustomers.Fill(dsCustomers1);		
		}

		private void cmdUpdateDatabase_Click(object sender, System.EventArgs e)
		{
			sqldaCustomers.Update(dsCustomers1);
			MessageBox.Show("Database updated!");
		}
	}
}
