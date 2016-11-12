using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public sealed class Win32
{
	public const uint DRIVE_UNKNOWN     = 0;
	public const uint DRIVE_NO_ROOT_DIR = 1;
	public const uint DRIVE_REMOVABLE   = 2;
	public const uint DRIVE_FIXED       = 3;
	public const uint DRIVE_REMOTE      = 4;
	public const uint DRIVE_CDROM       = 5;
	public const uint DRIVE_RAMDISK     = 6;

	[DllImport("kernel32.dll")]
	public static extern uint GetDriveType(
		string lpRootPathName   // root directory
		);

	[DllImport("kernel32.dll")]
	private static extern bool GetVolumeInformation(
		string lpRootPathName,					// Root directory
		StringBuilder lpVolumeNameBuffer,		// Volume name buffer
		int nVolumeNameSize,					// Length of name buffer
		ref int lpVolumeSerialNumber,			// Volume serial number
		ref int lpMaximumComponentLength,		// Maximum file name length
		ref int lpFileSystemFlags,				// File system options
		StringBuilder lpFileSystemNameBuffer,	// File system name buffer
		int nFileSystemNameSize					// Length of file system name buffer
		);

	public static string GetVolumeName(string strRootPath)
	{
		StringBuilder sbVolumeName = new StringBuilder(256);
		StringBuilder sbFileSystemName = new StringBuilder(256);
		int nVolSerial = 0;
		int nMaxCompLength = 0;
		int nFSFlags = 0;
		bool bResult = GetVolumeInformation(strRootPath,sbVolumeName,256,
			ref nVolSerial, ref nMaxCompLength, ref nFSFlags, sbFileSystemName, 256);
		if (true == bResult)
		{
			return sbVolumeName.ToString();
		}
		else
		{
			return "";
		}
	}
}
namespace ListviewDrives
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DrivesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView lvDrives;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuLargeIcons;
		private System.Windows.Forms.MenuItem mnuSmallIcons;
		private System.Windows.Forms.MenuItem mnuList;
		private System.Windows.Forms.MenuItem mnuDetails;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DrivesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Small and large image lists
			lvDrives.SmallImageList = new ImageList();
			Bitmap icoSmall = new Bitmap(GetType(), "LvIcons.bmp");
			icoSmall.MakeTransparent(Color.FromArgb(0xff, 0x00, 0xff));
			lvDrives.SmallImageList.Images.AddStrip(icoSmall);

			lvDrives.LargeImageList = new ImageList();
			Bitmap icoLarge = new Bitmap(GetType(), "LvIconsLarge.bmp");
			icoLarge.MakeTransparent(Color.FromArgb(0xff, 0x00, 0xff));
			Size sizeImages = new Size(32,32);
			lvDrives.LargeImageList.ImageSize = sizeImages;
			lvDrives.LargeImageList.Images.AddStrip(icoLarge);

			lvDrives.Columns.Add("Drive", 100, HorizontalAlignment.Left);
			lvDrives.Columns.Add("Type", 150, HorizontalAlignment.Left);

			ListDrives();
		}

		protected void ListDrives() 
		{
			string[] drives = Directory.GetLogicalDrives();
			string strDriveType = "";
			for (int i=0; i < drives.Length; i++)
			{
				string strDriveName = Win32.GetVolumeName(drives[i]);
				ListViewItem lvi = new ListViewItem();

				// Note: Network drives show up as local.
				switch(Win32.GetDriveType(drives[i])) 
				{
					case Win32.DRIVE_CDROM:
						strDriveType = "Compact Disc";
						lvi.ImageIndex = 1;
						break;
					case Win32.DRIVE_FIXED:
						strDriveType = "Local Disc";
						lvi.ImageIndex = 0;
						break;
					case Win32.DRIVE_REMOVABLE:
						strDriveType = "Floppy";
						lvi.ImageIndex = 2;
						break;
					default:
						goto case Win32.DRIVE_FIXED;
				}
				if (0 == strDriveName.Length) strDriveName = strDriveType;
				lvi.Text = strDriveName + " (" + drives[i].Substring(0, 2) + ")";
				lvi.SubItems.Add(strDriveType);
				this.lvDrives.Items.Add(lvi);
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
			this.lvDrives = new System.Windows.Forms.ListView();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuLargeIcons = new System.Windows.Forms.MenuItem();
			this.mnuSmallIcons = new System.Windows.Forms.MenuItem();
			this.mnuList = new System.Windows.Forms.MenuItem();
			this.mnuDetails = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// lvDrives
			// 
			this.lvDrives.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvDrives.Name = "lvDrives";
			this.lvDrives.Size = new System.Drawing.Size(336, 277);
			this.lvDrives.TabIndex = 0;
			this.lvDrives.View = System.Windows.Forms.View.List;
			this.lvDrives.ItemActivate += new System.EventHandler(this.ItemActivated);
			this.lvDrives.SelectedIndexChanged += new System.EventHandler(this.OnSelItemChanged);
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuLargeIcons,
																					  this.mnuSmallIcons,
																					  this.mnuList,
																					  this.mnuDetails});
			this.menuItem1.Text = "Style";
			// 
			// mnuLargeIcons
			// 
			this.mnuLargeIcons.Index = 0;
			this.mnuLargeIcons.Text = "Large Icons";
			this.mnuLargeIcons.Click += new System.EventHandler(this.OnMenuClick);
			// 
			// mnuSmallIcons
			// 
			this.mnuSmallIcons.Index = 1;
			this.mnuSmallIcons.Text = "Small Icons";
			this.mnuSmallIcons.Click += new System.EventHandler(this.OnMenuClick);
			// 
			// mnuList
			// 
			this.mnuList.Index = 2;
			this.mnuList.Text = "List";
			this.mnuList.Click += new System.EventHandler(this.OnMenuClick);
			// 
			// mnuDetails
			// 
			this.mnuDetails.Index = 3;
			this.mnuDetails.Text = "Details";
			this.mnuDetails.Click += new System.EventHandler(this.OnMenuClick);
			// 
			// DrivesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lvDrives});
			this.Menu = this.mnuMain;
			this.Name = "DrivesForm";
			this.Text = "Drives on computer";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new DrivesForm());
		}

		private void OnMenuClick(object sender, System.EventArgs e)
		{
			MenuItem mnu = (MenuItem)sender;
			switch(mnu.Text) 
			{
				case "Large Icons": lvDrives.View = View.LargeIcon; break;
				case "Small Icons": lvDrives.View = View.SmallIcon; break;
				case "List": lvDrives.View = View.List; break;
				default: lvDrives.View = View.Details; break;
			}
		}

		private void OnSelItemChanged(object sender, System.EventArgs e)
		{
			string strSelected = "";
			foreach (ListViewItem lvi in lvDrives.SelectedItems)
			{
				strSelected += " " + lvi.Text;
			}
			MessageBox.Show(strSelected);
		}

		private void ItemActivated(object sender, System.EventArgs e)
		{
			MessageBox.Show("Item activated");
		}
	}
}
