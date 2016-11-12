using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace VisualCSharpCorRef
{
	/// <summary>
	/// Summary description for DataBinding_DataReader.
	/// </summary>
	public class DataBinding_DataReader : System.Web.UI.Page
	{
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected System.Data.OleDb.OleDbCommand oleDbCommand1;
		protected System.Web.UI.WebControls.ListBox ListBox1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				System.Data.OleDb.OleDbDataReader dreader;
				oleDbConnection1.Open();
				oleDbCommand1.CommandText = "Select CategoryId, CategoryName From Categories";
				dreader = oleDbCommand1.ExecuteReader();
				while(dreader.Read())
				{
					ListItem li = new ListItem();
					li.Text = dreader[1].ToString();
					li.Value = dreader[0].ToString();
					ListBox1.Items.Add(li);
				}
				dreader.Close();
				oleDbConnection1.Close();
			}

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=C:\Inetpub\wwwroot\CSharpBook\nwind.mdb;Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
