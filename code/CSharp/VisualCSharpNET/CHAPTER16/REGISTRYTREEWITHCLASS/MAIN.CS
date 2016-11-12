using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RegistryTreeWithClass
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private RegistryTreeClass rtvRegistry;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.rtvRegistry = new RegistryTreeClass();
			this.SuspendLayout();
			this.rtvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtvRegistry.ImageIndex = -1;
			this.rtvRegistry.Name = "rtvRegistry";
			this.rtvRegistry.SelectedImageIndex = -1;
			this.rtvRegistry.Size = new System.Drawing.Size(292, 273);
			this.rtvRegistry.TabIndex = 0;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.rtvRegistry});
			this.ResumeLayout(false);
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
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "MainForm";
			this.Text = "Registry with class";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
