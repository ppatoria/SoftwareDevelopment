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
	/// Summary description for WebForm1.
	/// </summary>
	public class Calculator2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSubtract;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnMultiply;
		protected System.Web.UI.WebControls.Button btnDivide;
		protected System.Web.UI.WebControls.TextBox txtNumber1;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;

		private double storedvalue;
		private bool newcalculationflag;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(this.IsPostBack)
			{
				storedvalue = double.Parse(this.ViewState["total"].ToString());
				newcalculationflag = bool.Parse(this.ViewState["newcalculationflag"].ToString());
			}
			else
			{
				//newcalculationflag = true;
				this.ViewState["total"] = 0;
				//this.ViewState["newcalculationflag"] = newcalculationflag.ToString();
				this.ViewState["newcalculationflag"] = true;
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
			this.btnDivide.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Calculate);
			this.btnMultiply.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Calculate);
			this.btnAdd.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Calculate);
			this.btnSubtract.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Calculate);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Calculate(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			if(newcalculationflag)
			{
				this.ViewState["newcalculationflag"] = false;
				this.ViewState["total"] = this.txtNumber1.Text;
			}
			else
			{
				switch(e.CommandName)
				{
					case("Subtract"):
					{
							storedvalue -= double.Parse(this.txtNumber1.Text);
						break;
					}
					case("Add"):
					{
							storedvalue += double.Parse(this.txtNumber1.Text);
						break;
					}
					case("Multiply"):
					{
							storedvalue *= double.Parse(this.txtNumber1.Text);
						break;
					}

					case("Divide"):
					{
						if((double.Parse(this.txtNumber1.Text) != 0)) 
							storedvalue /= double.Parse(this.txtNumber1.Text);
						break;
					}
				}
				this.txtNumber1.Text = storedvalue.ToString();
				this.ViewState["total"] = storedvalue;
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.txtNumber1.Text = "";
			this.ViewState["total"] = 0;
			this.ViewState["newcalculationflag"] = true;
		}
	}
}
