using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace StatusBars
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel helpPanel;
        private System.Windows.Forms.StatusBarPanel timePanel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem fileMenuItem;
        private System.Windows.Forms.MenuItem openMenuItem;
        private System.Windows.Forms.MenuItem closeMenuItem;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.MenuItem viewMenuItem;
        private System.Windows.Forms.MenuItem statusBarMenuItem;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.ComponentModel.IContainer components;

		public MainForm()
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
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.helpPanel = new System.Windows.Forms.StatusBarPanel();
            this.timePanel = new System.Windows.Forms.StatusBarPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.openMenuItem = new System.Windows.Forms.MenuItem();
            this.closeMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.statusBarMenuItem = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.helpPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.Location = new System.Drawing.Point(0, 244);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                         this.helpPanel,
                                                                                         this.timePanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(322, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar1";
            // 
            // helpPanel
            // 
            this.helpPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.helpPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.helpPanel.MinWidth = 100;
            this.helpPanel.Text = "Help Text";
            this.helpPanel.Width = 286;
            // 
            // timePanel
            // 
            this.timePanel.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.timePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.timePanel.Text = "time";
            this.timePanel.ToolTipText = "Current Time";
            this.timePanel.Width = 36;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.fileMenuItem,
                                                                                     this.viewMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.openMenuItem,
                                                                                         this.closeMenuItem,
                                                                                         this.menuItem4,
                                                                                         this.exitMenuItem});
            this.fileMenuItem.Text = "&File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Index = 0;
            this.openMenuItem.Text = "&Open...";
            this.openMenuItem.Select += new System.EventHandler(this.openMenuItem_Select);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Index = 1;
            this.closeMenuItem.Text = "&Close";
            this.closeMenuItem.Select += new System.EventHandler(this.closeMenuItem_Select);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 3;
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            this.exitMenuItem.Select += new System.EventHandler(this.exitMenuItem_Select);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.Index = 1;
            this.viewMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.statusBarMenuItem});
            this.viewMenuItem.Text = "&View";
            // 
            // statusBarMenuItem
            // 
            this.statusBarMenuItem.Index = 0;
            this.statusBarMenuItem.Text = "&Status Bar";
            this.statusBarMenuItem.Click += new System.EventHandler(this.statusBarMenuItem_Click);
            this.statusBarMenuItem.Select += new System.EventHandler(this.statusBarMenuItem_Select);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(322, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.statusBar});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Status Bar Demo";
            this.MenuComplete += new System.EventHandler(this.MainForm_MenuComplete);
            ((System.ComponentModel.ISupportInitialize)(this.helpPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePanel)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timePanel.Text = DateTime.Now.ToShortTimeString();
        }

        private void statusBarMenuItem_Click(object sender, System.EventArgs e)
        {
            if(statusBarMenuItem.Checked == false)
            {
                statusBar.Visible = true;
                statusBarMenuItem.Checked = true;
            }
            else
            {
                statusBar.Visible = false;
                statusBarMenuItem.Checked = false;
            }
        }

        private void fileMenuItem_Select(object sender, System.EventArgs e)
        {
            helpPanel.Text = "File Menu";
        }

        private void openMenuItem_Select(object sender, System.EventArgs e)
        {
            helpPanel.Text = "Open file for editing";
        }

        private void closeMenuItem_Select(object sender, System.EventArgs e)
        {
            helpPanel.Text = "Close the current file";
        }

        private void exitMenuItem_Select(object sender, System.EventArgs e)
        {
            helpPanel.Text = "Exit the application";
        }

        private void statusBarMenuItem_Select(object sender, System.EventArgs e)
        {
            helpPanel.Text = "Toggle the status bar";
        }

        private void exitMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

		private void MainForm_MenuComplete(object sender, System.EventArgs e)
		{
			helpPanel.Text = "";
		}
	}
}
