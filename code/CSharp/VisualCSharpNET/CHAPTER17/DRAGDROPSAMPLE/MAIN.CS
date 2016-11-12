using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DragDropSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class DragDropForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lbDragDropSource;
		private System.Windows.Forms.Splitter splitterCentral;
		private System.Windows.Forms.TextBox txtMain;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DragDropForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.lbDragDropSource.Items.Add("<html>");
			this.lbDragDropSource.Items.Add("<head>");
			this.lbDragDropSource.Items.Add("<title>");
			this.lbDragDropSource.Items.Add("</title>");
			this.lbDragDropSource.Items.Add("</head>");
			this.lbDragDropSource.Items.Add("<body>");
			this.lbDragDropSource.Items.Add("</body>");
			this.lbDragDropSource.Items.Add("</html>");
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
			this.lbDragDropSource = new System.Windows.Forms.ListBox();
			this.splitterCentral = new System.Windows.Forms.Splitter();
			this.txtMain = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbDragDropSource
			// 
			this.lbDragDropSource.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbDragDropSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbDragDropSource.IntegralHeight = false;
			this.lbDragDropSource.ItemHeight = 20;
			this.lbDragDropSource.Name = "lbDragDropSource";
			this.lbDragDropSource.Size = new System.Drawing.Size(152, 301);
			this.lbDragDropSource.TabIndex = 0;
			this.lbDragDropSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDragDropSource_MouseDown);
			this.lbDragDropSource.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.lbDragDropSource_QueryContinueDrag);
			// 
			// splitterCentral
			// 
			this.splitterCentral.Location = new System.Drawing.Point(152, 0);
			this.splitterCentral.Name = "splitterCentral";
			this.splitterCentral.Size = new System.Drawing.Size(3, 301);
			this.splitterCentral.TabIndex = 1;
			this.splitterCentral.TabStop = false;
			// 
			// txtMain
			// 
			this.txtMain.AcceptsReturn = true;
			this.txtMain.AcceptsTab = true;
			this.txtMain.AllowDrop = true;
			this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMain.Location = new System.Drawing.Point(155, 0);
			this.txtMain.Multiline = true;
			this.txtMain.Name = "txtMain";
			this.txtMain.Size = new System.Drawing.Size(333, 301);
			this.txtMain.TabIndex = 2;
			this.txtMain.Text = "";
			this.txtMain.DragOver += new System.Windows.Forms.DragEventHandler(this.txtMain_DragOver);
			this.txtMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMain_DragDrop);
			this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
			// 
			// DragDropForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtMain,
																		  this.splitterCentral,
																		  this.lbDragDropSource});
			this.Name = "DragDropForm";
			this.Text = "Drag and Drop Sample";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new DragDropForm());
		}

		private void lbDragDropSource_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int nSelectedIndex = lbDragDropSource.SelectedIndex;
			string strItem = (string)lbDragDropSource.Items[nSelectedIndex];

			DragDropEffects dde = lbDragDropSource.DoDragDrop(strItem,
				DragDropEffects.Copy);

			if (DragDropEffects.None == dde)
				MessageBox.Show("Our drag and drop offer was not accepted.");
		}

		private void txtMain_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(string)))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void txtMain_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(string)))
			{
				string strData = (string)e.Data.GetData(typeof(string));
				// really simple - usually at cursor position
				txtMain.AppendText(strData);
			}
		}

		private void lbDragDropSource_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
		{
			// DO NOT DO THIS
			// e.Action = DragAction.Continue;
		}

		private void txtMain_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
