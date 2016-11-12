using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TBBStyle
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class TBBStylesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar tbMain;
		private System.Windows.Forms.ImageList imgListDefault;
		private System.Windows.Forms.ContextMenu ddmDemo;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.ComponentModel.IContainer components;

		public TBBStylesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			string[] astrTBB = {"Cut", "Copy", "Paste", "", "Messages", "", "Help"};
			ToolBarButtonStyle[] atbbStyles = {ToolBarButtonStyle.PushButton,
				ToolBarButtonStyle.PushButton, ToolBarButtonStyle.PushButton,
				ToolBarButtonStyle.Separator, ToolBarButtonStyle.ToggleButton,
				ToolBarButtonStyle.Separator, ToolBarButtonStyle.DropDownButton };
			int[] anImageIndex = { 0, 1, 2, 0, 4, 0, 3 };

			for (int i=0; i < astrTBB.Length; i++)
			{
				ToolBarButton tbb = new ToolBarButton();
				tbb.ImageIndex = anImageIndex[i];
				tbb.Style = atbbStyles[i];
				tbb.ToolTipText = astrTBB[i];
				if (tbb.Style == ToolBarButtonStyle.DropDownButton)
				{
					tbb.DropDownMenu = ddmDemo;
				}
				tbMain.Buttons.Add(tbb);
			}
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TBBStylesForm));
			this.tbMain = new System.Windows.Forms.ToolBar();
			this.imgListDefault = new System.Windows.Forms.ImageList(this.components);
			this.ddmDemo = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// tbMain
			// 
			this.tbMain.DropDownArrows = true;
			this.tbMain.ImageList = this.imgListDefault;
			this.tbMain.Name = "tbMain";
			this.tbMain.ShowToolTips = true;
			this.tbMain.Size = new System.Drawing.Size(292, 39);
			this.tbMain.TabIndex = 0;
			this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.OnButtonClick);
			// 
			// imgListDefault
			// 
			this.imgListDefault.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgListDefault.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListDefault.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListDefault.ImageStream")));
			this.imgListDefault.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ddmDemo
			// 
			this.ddmDemo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1,
																					this.menuItem2,
																					this.menuItem3});
			this.ddmDemo.Popup += new System.EventHandler(this.ddmDemo_Popup);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "SDK Help";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Visual Studio .NET Help";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "About";
			// 
			// TBBStylesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbMain});
			this.Name = "TBBStylesForm";
			this.Text = "ToolBarButtonStyles Sample";
			this.Load += new System.EventHandler(this.TBBStylesForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TBBStylesForm());
		}

		private void OnButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			bool bShowMessages = tbMain.Buttons[4].Pushed;
			if (true == bShowMessages)
			{
				MessageBox.Show("Button " + e.Button.ToolTipText + " was clicked");
			}
		}

		private void TBBStylesForm_Load(object sender, System.EventArgs e)
		{
		
		}

		private void ddmDemo_Popup(object sender, System.EventArgs e)
		{
		
		}
	}
}
