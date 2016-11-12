using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DesignedToolbar
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DesignedToolbarForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar tbDefault;
		private System.Windows.Forms.ImageList imgListToolbar;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbSeparator;
		private System.Windows.Forms.ToolBarButton tbbCut;
		private System.Windows.Forms.ToolBarButton tbbCopy;
		private System.Windows.Forms.ToolBarButton tbbPaste;
		private System.Windows.Forms.ToolBarButton tbbHelp;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu mnuDemo;
		private System.ComponentModel.IContainer components;

		public DesignedToolbarForm()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DesignedToolbarForm));
			this.tbDefault = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbOpen = new System.Windows.Forms.ToolBarButton();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.tbbSeparator = new System.Windows.Forms.ToolBarButton();
			this.tbbCut = new System.Windows.Forms.ToolBarButton();
			this.tbbCopy = new System.Windows.Forms.ToolBarButton();
			this.tbbPaste = new System.Windows.Forms.ToolBarButton();
			this.tbbHelp = new System.Windows.Forms.ToolBarButton();
			this.imgListToolbar = new System.Windows.Forms.ImageList(this.components);
			this.mnuDemo = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// tbDefault
			// 
			this.tbDefault.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						 this.tbbNew,
																						 this.tbbOpen,
																						 this.tbbSave,
																						 this.tbbSeparator,
																						 this.tbbCut,
																						 this.tbbCopy,
																						 this.tbbPaste,
																						 this.tbbHelp});
			this.tbDefault.DropDownArrows = true;
			this.tbDefault.ImageList = this.imgListToolbar;
			this.tbDefault.Name = "tbDefault";
			this.tbDefault.ShowToolTips = true;
			this.tbDefault.Size = new System.Drawing.Size(360, 39);
			this.tbDefault.TabIndex = 0;
			this.tbDefault.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.OnButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "New";
			this.tbbNew.ToolTipText = "Create a new file";
			// 
			// tbbOpen
			// 
			this.tbbOpen.ImageIndex = 1;
			this.tbbOpen.Text = "Open";
			this.tbbOpen.ToolTipText = "Open an existing file";
			// 
			// tbbSave
			// 
			this.tbbSave.ImageIndex = 2;
			this.tbbSave.Text = "Save";
			this.tbbSave.ToolTipText = "Save active document";
			// 
			// tbbSeparator
			// 
			this.tbbSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbCut
			// 
			this.tbbCut.ImageIndex = 3;
			this.tbbCut.Text = "Cut";
			this.tbbCut.ToolTipText = "Cut selection";
			// 
			// tbbCopy
			// 
			this.tbbCopy.ImageIndex = 4;
			this.tbbCopy.Text = "Copy";
			this.tbbCopy.ToolTipText = "Copy selection";
			// 
			// tbbPaste
			// 
			this.tbbPaste.ImageIndex = 5;
			this.tbbPaste.Text = "Paste";
			this.tbbPaste.ToolTipText = "Paste from clipboard";
			// 
			// tbbHelp
			// 
			this.tbbHelp.ImageIndex = 6;
			this.tbbHelp.Text = "Help";
			this.tbbHelp.ToolTipText = "Help";
			// 
			// imgListToolbar
			// 
			this.imgListToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgListToolbar.ImageSize = new System.Drawing.Size(16, 16);
			this.imgListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListToolbar.ImageStream")));
			this.imgListToolbar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mnuDemo
			// 
			this.mnuDemo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "File";
			// 
			// DesignedToolbarForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbDefault});
			this.Menu = this.mnuDemo;
			this.Name = "DesignedToolbarForm";
			this.Text = "Designed Toolbar";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new DesignedToolbarForm());
		}

		private void OnButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ToolBarButton tbCurrent = e.Button;
			MessageBox.Show("You clicked button " + tbCurrent.Text);
		}
	}
}
