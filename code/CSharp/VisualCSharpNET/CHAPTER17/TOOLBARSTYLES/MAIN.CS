using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ToolbarStyles
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ToolbarStylesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar tbMain;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuAppearanceNormal;
		private System.Windows.Forms.MenuItem mnuAppearanceFlat;
		private System.Windows.Forms.MenuItem mnuTextAlignUnderneath;
		private System.Windows.Forms.MenuItem mnuTextAlignRight;
		private System.Windows.Forms.MenuItem mnuDivider;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		string[] astrTBarButtons = { "New", "Open", "Save",
									   "Cut", "Copy", "Paste", "Print", "Help"};

		public ToolbarStylesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Initialize the ImageList
			tbMain.ImageList = new ImageList();
			Bitmap bmpImageStrip = new Bitmap(GetType(), "Toolbar.bmp");
			bmpImageStrip.MakeTransparent(Color.FromArgb(0xff, 0x00, 0xff));
			tbMain.ImageList.ImageSize = new Size(16, 15);
			tbMain.ImageList.Images.AddStrip(bmpImageStrip);
			
			// Create the toolbar buttons
			for (int i=0; i < astrTBarButtons.Length; i++)
			{
				ToolBarButton tbb = new ToolBarButton();
				tbb.ImageIndex = i;
				tbb.ToolTipText = astrTBarButtons[i];
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
			this.tbMain = new System.Windows.Forms.ToolBar();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuAppearanceNormal = new System.Windows.Forms.MenuItem();
			this.mnuAppearanceFlat = new System.Windows.Forms.MenuItem();
			this.mnuTextAlignUnderneath = new System.Windows.Forms.MenuItem();
			this.mnuTextAlignRight = new System.Windows.Forms.MenuItem();
			this.mnuDivider = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// tbMain
			// 
			this.tbMain.DropDownArrows = true;
			this.tbMain.Name = "tbMain";
			this.tbMain.ShowToolTips = true;
			this.tbMain.Size = new System.Drawing.Size(292, 39);
			this.tbMain.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuAppearanceNormal,
																					  this.mnuAppearanceFlat,
																					  this.mnuDivider,
																					  this.mnuTextAlignUnderneath,
																					  this.mnuTextAlignRight});
			this.menuItem1.Text = "Styles";
			// 
			// mnuAppearanceNormal
			// 
			this.mnuAppearanceNormal.Index = 0;
			this.mnuAppearanceNormal.Text = "Normal";
			this.mnuAppearanceNormal.Click += new System.EventHandler(this.OnAppearanceNormal);
			// 
			// mnuAppearanceFlat
			// 
			this.mnuAppearanceFlat.Index = 1;
			this.mnuAppearanceFlat.Text = "Flat";
			this.mnuAppearanceFlat.Click += new System.EventHandler(this.OnAppearanceFlat);
			// 
			// mnuTextAlignUnderneath
			// 
			this.mnuTextAlignUnderneath.Index = 3;
			this.mnuTextAlignUnderneath.Text = "Text underneath";
			this.mnuTextAlignUnderneath.Click += new System.EventHandler(this.OnTextAlignUnderneath);
			// 
			// mnuTextAlignRight
			// 
			this.mnuTextAlignRight.Index = 4;
			this.mnuTextAlignRight.Text = "Text right";
			this.mnuTextAlignRight.Click += new System.EventHandler(this.OnTextAlignRight);
			// 
			// mnuDivider
			// 
			this.mnuDivider.Index = 2;
			this.mnuDivider.Text = "Divider";
			this.mnuDivider.Click += new System.EventHandler(this.OnDivider);
			// 
			// ToolbarStylesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbMain});
			this.Menu = this.mainMenu1;
			this.Name = "ToolbarStylesForm";
			this.Text = "Toolbar Styles";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ToolbarStylesForm());
		}

		private void OnAppearanceNormal(object sender, System.EventArgs e)
		{
			tbMain.Appearance = ToolBarAppearance.Normal;
		}

		private void OnAppearanceFlat(object sender, System.EventArgs e)
		{
			tbMain.Appearance = ToolBarAppearance.Flat;
		}

		private void OnDivider(object sender, System.EventArgs e)
		{
			tbMain.Divider = !tbMain.Divider;
		}

		private void OnTextAlignUnderneath(object sender, System.EventArgs e)
		{
			AddTextToToolBarButtons();
			tbMain.TextAlign = ToolBarTextAlign.Underneath;
		}

		private void OnTextAlignRight(object sender, System.EventArgs e)
		{
			AddTextToToolBarButtons();
			tbMain.TextAlign = ToolBarTextAlign.Right;
		}

		private void AddTextToToolBarButtons()
		{
			for (int i=0; i < astrTBarButtons.Length; i++)
			{
				tbMain.Buttons[i].Text = astrTBarButtons[i];
			}
		}

		private void RemoveTextFromToolBarButtons()
		{
			for (int i=0; i < astrTBarButtons.Length; i++)
			{
				tbMain.Buttons[i].Text = "";
			}
			tbMain.Refresh();
		}
	}
}
