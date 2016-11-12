using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace RegistryTree
{
	/// <summary>
	/// Summary description for RegistryBrowser.
	/// </summary>
	public class RegistryBrowser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView tvRegistry;
		private System.Windows.Forms.ImageList ilTreeImages;
		private System.ComponentModel.IContainer components;

		public RegistryBrowser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			RootNodes();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RegistryBrowser));
			this.tvRegistry = new System.Windows.Forms.TreeView();
			this.ilTreeImages = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// tvRegistry
			// 
			this.tvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvRegistry.ImageList = this.ilTreeImages;
			this.tvRegistry.Name = "tvRegistry";
			this.tvRegistry.Size = new System.Drawing.Size(392, 333);
			this.tvRegistry.TabIndex = 0;
			this.tvRegistry.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistry_BeforeExpand);
			// 
			// ilTreeImages
			// 
			this.ilTreeImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilTreeImages.ImageSize = new System.Drawing.Size(13, 13);
			this.ilTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeImages.ImageStream")));
			this.ilTreeImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// RegistryBrowser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tvRegistry});
			this.Name = "RegistryBrowser";
			this.Text = "Registry Browser";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new RegistryBrowser());
		}

		private void tvRegistry_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			tvRegistry.BeginUpdate();
			foreach (TreeNode tn in e.Node.Nodes)
			{
				AddBranch(tn);
			}
			tvRegistry.EndUpdate();
		}

		public void AddBranch(TreeNode tn)
		{
			tn.Nodes.Clear();
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
					int nPosPathSeparator = strRegistryPath.IndexOf(this.tvRegistry.PathSeparator);
					string strSubkey = strRegistryPath.Substring(nPosPathSeparator+1);
					regSubKey = regBranch.OpenSubKey(strSubkey);
				}
				else
					regSubKey = regBranch;
			}
			catch
			{
				return;
			}

			string[] astrSubkeyNames = regSubKey.GetSubKeyNames();
			for (int i=0; i < astrSubkeyNames.Length; i++)
			{
				TreeNode tnBranch = new TreeNode(astrSubkeyNames[i],0,1);
				tn.Nodes.Add(tnBranch);
			}
		}

		public void RootNodes()
		{
			tvRegistry.BeginUpdate();

			TreeNode tnHKCR = new TreeNode("HKEY_CLASSES_ROOT",0,1);
			tvRegistry.Nodes.Add(tnHKCR);
			AddBranch(tnHKCR);

			TreeNode tnHKCU = new TreeNode("HKEY_CURRENT_USER",0,1);
			tvRegistry.Nodes.Add(tnHKCU);
			AddBranch(tnHKCU);

			TreeNode tnHKLM = new TreeNode("HKEY_LOCAL_MACHINE",0,1);
			tvRegistry.Nodes.Add(tnHKLM);
			AddBranch(tnHKLM);

			TreeNode tnHKU = new TreeNode("HKEY_USERS",0,1);
			tvRegistry.Nodes.Add(tnHKU);
			AddBranch(tnHKU);

			tvRegistry.SelectedNode = tnHKLM;
			tvRegistry.EndUpdate();
		}
	}
}
