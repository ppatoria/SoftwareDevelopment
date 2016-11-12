using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryTreeWithClass
{
	/// <summary>
	/// Summary description for RegistryTreeClass.
	/// </summary>
	public class RegistryTreeClass: TreeView
	{
		public RegistryTreeClass()
		{
			ImageList = new ImageList();
			// Both images are embedded resources.
			ImageList.Images.Add(new Bitmap(GetType(), "CLOSED.BMP"));
			ImageList.Images.Add(new Bitmap(GetType(), "OPEN.BMP"));
			RootNodes();
		}

		protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
		{
			base.OnBeforeExpand(e);
			BeginUpdate();

			foreach (TreeNode tn in e.Node.Nodes)
			{
				AddBranch(tn);
			}
			EndUpdate();
		}
		
		public void RootNodes()
		{
			BeginUpdate();

			TreeNode tnHKCR = new TreeNode("HKEY_CLASSES_ROOT",0,1);
			Nodes.Add(tnHKCR);
			AddBranch(tnHKCR);

			TreeNode tnHKCU = new TreeNode("HKEY_CURRENT_USER",0,1);
			Nodes.Add(tnHKCU);
			AddBranch(tnHKCU);

			TreeNode tnHKLM = new TreeNode("HKEY_LOCAL_MACHINE",0,1);
			Nodes.Add(tnHKLM);
			AddBranch(tnHKLM);

			TreeNode tnHKU = new TreeNode("HKEY_USERS",0,1);
			Nodes.Add(tnHKU);
			AddBranch(tnHKU);

			SelectedNode = tnHKLM;
			EndUpdate();
		}

		public void AddBranch(TreeNode tn)
		{
			// Note: The following speeds up collapsing/re-expanding.
			// However, it could lead to stale data.
			if (tn.Nodes.Count > 0) return;
			// tn.Nodes.Clear();
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
					// We need the path minus the top level tree.
					int nPosPathSeparator = strRegistryPath.IndexOf(this.PathSeparator);
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
	}
}
