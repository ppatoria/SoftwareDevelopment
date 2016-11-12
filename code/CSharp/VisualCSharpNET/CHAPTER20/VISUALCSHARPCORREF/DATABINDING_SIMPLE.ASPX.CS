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
	/// Summary description for DataBinding_Simple.
	/// </summary>
	public class DataBinding_Simple : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button SubmitButton;
		protected System.Web.UI.WebControls.ListBox ListBox1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ArrayList animals = new ArrayList();
				animals.Add("Dog");
				animals.Add("Cat");
				animals.Add("Goldfish");
				ListBox1.DataSource = animals;
				ListBox1.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
