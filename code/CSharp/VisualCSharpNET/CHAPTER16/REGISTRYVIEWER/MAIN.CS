using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace RegistryViewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class RegistryViewerForm : System.Windows.Forms.Form
	{
		private RegistryTreeClass tvKeys;
		private System.Windows.Forms.Splitter splitterTvLv;
		private System.Windows.Forms.ListView lvValues;
		private System.Windows.Forms.ImageList imgListTv;
		private System.Windows.Forms.ColumnHeader chdrName;
		private System.Windows.Forms.ColumnHeader chdrData;
		private System.ComponentModel.IContainer components;

		public RegistryViewerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			tvKeys.ImageList = this.imgListTv;
			tvKeys.RootNodes();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RegistryViewerForm));
			this.tvKeys = new RegistryTreeClass();
			this.splitterTvLv = new System.Windows.Forms.Splitter();
			this.lvValues = new System.Windows.Forms.ListView();
			this.chdrName = new System.Windows.Forms.ColumnHeader();
			this.chdrData = new System.Windows.Forms.ColumnHeader();
			this.imgListTv = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// tvKeys
			// 
			this.tvKeys.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvKeys.ImageIndex = -1;
			this.tvKeys.Name = "tvKeys";
			this.tvKeys.SelectedImageIndex = -1;
			this.tvKeys.Size = new System.Drawing.Size(200, 405);
			this.tvKeys.TabIndex = 0;
			this.tvKeys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelect);
			// 
			// splitterTvLv
			// 
			this.splitterTvLv.Location = new System.Drawing.Point(200, 0);
			this.splitterTvLv.Name = "splitterTvLv";
			this.splitterTvLv.Size = new System.Drawing.Size(3, 405);
			this.splitterTvLv.TabIndex = 1;
			this.splitterTvLv.TabStop = false;
			// 
			// lvValues
			// 
			this.lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.chdrName,
																					   this.chdrData});
			this.lvValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvValues.Location = new System.Drawing.Point(203, 0);
			this.lvValues.Name = "lvValues";
			this.lvValues.Size = new System.Drawing.Size(381, 405);
			this.lvValues.TabIndex = 2;
			this.lvValues.View = System.Windows.Forms.View.Details;
			// 
			// chdrName
			// 
			this.chdrName.Text = "Name";
			this.chdrName.Width = 120;
			// 
			// chdrData
			// 
			this.chdrData.Text = "Data";
			this.chdrData.Width = 200;
			// 
			// imgListTv
			// 
			this.imgListTv.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgListTv.ImageSize = new System.Drawing.Size(13, 13);
			this.imgListTv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTv.ImageStream")));
			this.imgListTv.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// RegistryViewerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 405);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lvValues,
																		  this.splitterTvLv,
																		  this.tvKeys});
			this.Name = "RegistryViewerForm";
			this.Text = "Registry Viewer";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new RegistryViewerForm());
		}

		private void AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode tn = tvKeys.SelectedNode;
			if (null == tn) return;
			string strRegistryPath = tn.FullPath;

			RegistryKey regBranch = null;
			if (strRegistryPath.StartsWith("HKEY_CLASSES_ROOT"))
				regBranch = Registry.ClassesRoot;
			else if (strRegistryPath.StartsWith("HKEY_CURRENT_USER"))
				regBranch = Registry.CurrentUser;
			else if (strRegistryPath.StartsWith("HKEY_LOCAL_MACHINE"))
				regBranch = Registry.LocalMachine;
			else if (strRegistryPath.StartsWith("HKEY_USERS"))
				regBranch = Registry.Users;

			RegistryKey regSubKey = null;
			try
			{
				if (null != tn.Parent)
				{
					// we need the path minus the top level tree
					int nPosPathSeparator = strRegistryPath.IndexOf(tvKeys.PathSeparator);
					string strSubkey = strRegistryPath.Substring(nPosPathSeparator+1);
					regSubKey = regBranch.OpenSubKey(strSubkey);
				}
				else
				{
					regSubKey = regBranch;
				}
			}
			catch
			{
				return;
			}
			string[] astrValueNames = regSubKey.GetValueNames();
			lvValues.Items.Clear();
			for (int j=0; j < astrValueNames.Length; j++)
			{
				object val = regSubKey.GetValue(astrValueNames[j]);
				ListViewItem lvi = new ListViewItem(astrValueNames[j]);
				lvi.SubItems.Add(val.ToString());
				lvValues.Items.Add(lvi);
			}
		}
	}
}
