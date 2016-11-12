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
	/// Summary description for Calculator1.
	/// </summary>
	public class Calculator1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Number1TextBox;
		protected System.Web.UI.WebControls.Label ResultLabel;
		protected System.Web.UI.WebControls.Button AddButton;
		protected System.Web.UI.WebControls.Button SubtractButton;
		protected System.Web.UI.WebControls.Button MultiplyButton;
		protected System.Web.UI.WebControls.Button DivideButton;
		protected System.Web.UI.WebControls.TextBox Number2TextBox;
		protected System.Web.UI.WebControls.Label OpLabel;
		protected System.Web.UI.WebControls.Button ClearButton;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			this.SubtractButton.Click += new System.EventHandler(this.SubtractButton_Click);
			this.MultiplyButton.Click += new System.EventHandler(this.MultiplyButton_Click);
			this.DivideButton.Click += new System.EventHandler(this.DivideButton_Click);
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddButton_Click(object sender, System.EventArgs e)
		{
			ResultLabel.Text = (double.Parse(Number1TextBox.Text) + 
				double.Parse(Number2TextBox.Text)).ToString();
			OpLabel.Text = "+";

		}

		private void SubtractButton_Click(object sender, System.EventArgs e)
		{
			ResultLabel.Text = (double.Parse(this.Number1TextBox.Text) - double.Parse(Number2TextBox.Text)).ToString();
			OpLabel.Text = "-";

		}

		private void MultiplyButton_Click(object sender, System.EventArgs e)
		{
			ResultLabel.Text = (double.Parse(Number1TextBox.Text) * double.Parse(Number2TextBox.Text)).ToString();
			OpLabel.Text = "x";

		}

		private void DivideButton_Click(object sender, System.EventArgs e)
		{
			if((double.Parse(Number2TextBox.Text) != 0) ) 
			{
				ResultLabel.Text = (double.Parse(Number1TextBox.Text) / double.Parse(Number2TextBox.Text)).ToString();
				OpLabel.Text = "/";
			}
			else
			{
				ResultLabel.Text = "Can't divide by zero!";
			}

		}

		private void ClearButton_Click(object sender, System.EventArgs e)
		{
			Number1TextBox.Text = "";
			Number2TextBox.Text = "";
			OpLabel.Text = "";
		}
	}
}
