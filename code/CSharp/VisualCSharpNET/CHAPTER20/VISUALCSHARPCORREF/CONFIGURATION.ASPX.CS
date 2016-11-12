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
	/// Summary description for Configuration.
	/// </summary>
	public class Configuration : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.RadioButton rbSmall;
		protected System.Web.UI.WebControls.RadioButton rbMedium;
		protected System.Web.UI.WebControls.RadioButton rbLarge;
		protected System.Web.UI.WebControls.Label lblSampleText;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
	
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
			this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
			this.rbSmall.CheckedChanged += new System.EventHandler(this.ResetFontSize);
			this.rbMedium.CheckedChanged += new System.EventHandler(this.ResetFontSize);
			this.rbLarge.CheckedChanged += new System.EventHandler(this.ResetFontSize);
			this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

			private void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				this.lblSampleText.Font.Name = this.ListBox1.SelectedItem.Text;
			}

		private void ResetFontSize(object sender, System.EventArgs e)
		{
			if(this.rbSmall.Checked)
				this.lblSampleText.Font.Size = new FontUnit("Small");
			else if (this.rbMedium.Checked)
				this.lblSampleText.Font.Size = new FontUnit("Medium");
			else if (this.rbLarge.Checked)
				this.lblSampleText.Font.Size = new FontUnit("Large");	
		}

	
		private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.CheckBox1.Checked == true)
				this.lblSampleText.BackColor = System.Drawing.Color.LightGray;
			else
				this.lblSampleText.BackColor = System.Drawing.Color.White;
		}
	}
}
