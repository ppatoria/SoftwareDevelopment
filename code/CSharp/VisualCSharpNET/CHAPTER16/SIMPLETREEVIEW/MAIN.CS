using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SimpleTreeview
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class SimpleTvForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView tvSimple;
		private System.Windows.Forms.Button cmdExpandAll;
		private System.Windows.Forms.Button cmdCollapseAll;
		private System.Windows.Forms.ContextMenu ctxmTvNodes;
		private System.Windows.Forms.MenuItem mnuExpandNode;
		private System.Windows.Forms.MenuItem mnuCollapseNode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SimpleTvForm()
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
			this.tvSimple = new System.Windows.Forms.TreeView();
			this.ctxmTvNodes = new System.Windows.Forms.ContextMenu();
			this.mnuExpandNode = new System.Windows.Forms.MenuItem();
			this.mnuCollapseNode = new System.Windows.Forms.MenuItem();
			this.cmdExpandAll = new System.Windows.Forms.Button();
			this.cmdCollapseAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tvSimple
			// 
			this.tvSimple.ContextMenu = this.ctxmTvNodes;
			this.tvSimple.ImageIndex = -1;
			this.tvSimple.Location = new System.Drawing.Point(8, 8);
			this.tvSimple.Name = "tvSimple";
			this.tvSimple.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				 new System.Windows.Forms.TreeNode("Continents", new System.Windows.Forms.TreeNode[] {
																																										 new System.Windows.Forms.TreeNode("Africa"),
																																										 new System.Windows.Forms.TreeNode("America"),
																																										 new System.Windows.Forms.TreeNode("Europe"),
																																										 new System.Windows.Forms.TreeNode("Asia"),
																																										 new System.Windows.Forms.TreeNode("Australia")}),
																				 new System.Windows.Forms.TreeNode("SUV\'s", new System.Windows.Forms.TreeNode[] {
																																									 new System.Windows.Forms.TreeNode("Hummer"),
																																									 new System.Windows.Forms.TreeNode("Pinzgauer")})});
			this.tvSimple.SelectedImageIndex = -1;
			this.tvSimple.Size = new System.Drawing.Size(272, 232);
			this.tvSimple.TabIndex = 0;
			this.tvSimple.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelect);
			// 
			// ctxmTvNodes
			// 
			this.ctxmTvNodes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuExpandNode,
																						this.mnuCollapseNode});
			// 
			// mnuExpandNode
			// 
			this.mnuExpandNode.Index = 0;
			this.mnuExpandNode.Text = "Expand node";
			this.mnuExpandNode.Click += new System.EventHandler(this.OnExpandNode);
			// 
			// mnuCollapseNode
			// 
			this.mnuCollapseNode.Index = 1;
			this.mnuCollapseNode.Text = "Collapse node";
			this.mnuCollapseNode.Click += new System.EventHandler(this.OnCollapseNode);
			// 
			// cmdExpandAll
			// 
			this.cmdExpandAll.Location = new System.Drawing.Point(8, 256);
			this.cmdExpandAll.Name = "cmdExpandAll";
			this.cmdExpandAll.TabIndex = 1;
			this.cmdExpandAll.Text = "expand all";
			this.cmdExpandAll.Click += new System.EventHandler(this.cmdExpandAll_Click);
			// 
			// cmdCollapseAll
			// 
			this.cmdCollapseAll.Location = new System.Drawing.Point(96, 256);
			this.cmdCollapseAll.Name = "cmdCollapseAll";
			this.cmdCollapseAll.TabIndex = 2;
			this.cmdCollapseAll.Text = "collapse all";
			this.cmdCollapseAll.Click += new System.EventHandler(this.cmdCollapseAll_Click);
			// 
			// SimpleTvForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCollapseAll,
																		  this.cmdExpandAll,
																		  this.tvSimple});
			this.Name = "SimpleTvForm";
			this.Text = "Simple";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SimpleTvForm());
		}

		private void AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			// MessageBox.Show("Node " +  e.Node.FullPath + " was selected");
		}

		private void cmdExpandAll_Click(object sender, System.EventArgs e)
		{
			tvSimple.ExpandAll();
		}

		private void cmdCollapseAll_Click(object sender, System.EventArgs e)
		{
			tvSimple.CollapseAll();
		}

		private void OnExpandNode(object sender, System.EventArgs e)
		{
			TreeNode tn = tvSimple.SelectedNode;
			if (null == tn) return;
			tn.ExpandAll();
		}

		private void OnCollapseNode(object sender, System.EventArgs e)
		{
			TreeNode tn = tvSimple.SelectedNode;
			if (null == tn) return;
			tn.Collapse();
		}
	}
}
