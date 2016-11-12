using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HatchSelection
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
        HatchBrush _panelBrush = null;
        private System.Windows.Forms.ComboBox hatchStyleCombo;
        private System.Windows.Forms.Panel panel;
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
            hatchStyleCombo.SelectedIndex = 0;

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
            this.hatchStyleCombo = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // hatchStyleCombo
            // 
            this.hatchStyleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hatchStyleCombo.Items.AddRange(new object[] {
                                                                 "BackwardDiagonal",
                                                                 "Cross",
                                                                 "DarkDownwardDiagonal",
                                                                 "DarkHorizontal",
                                                                 "DarkUpwardDiagonal",
                                                                 "DarkVertical",
                                                                 "DashedDownwardDiagonal",
                                                                 "DashedHorizontal",
                                                                 "DashedUpwardDiagonal",
                                                                 "DashedVertical",
                                                                 "DiagonalBrick",
                                                                 "DiagonalCross",
                                                                 "Divot",
                                                                 "DottedDiamond",
                                                                 "DottedGrid",
                                                                 "ForwardDiagonal",
                                                                 "Horizontal",
                                                                 "HorizontalBrick",
                                                                 "LargeCheckerBoard",
                                                                 "LargeConfetti",
                                                                 "LargeGrid",
                                                                 "LightDownwardDiagonal",
                                                                 "LightHorizontal",
                                                                 "LightUpwardDiagonal",
                                                                 "LightVertical",
                                                                 "Max",
                                                                 "Min",
                                                                 "NarrowHorizontal",
                                                                 "NarrowVertical",
                                                                 "OutlinedDiamond",
                                                                 "Percent05",
                                                                 "Percent10",
                                                                 "Percent20",
                                                                 "Percent25",
                                                                 "Percent30",
                                                                 "Percent40",
                                                                 "Percent50",
                                                                 "Percent60",
                                                                 "Percent70",
                                                                 "Percent75",
                                                                 "Percent80",
                                                                 "Percent90",
                                                                 "Plaid",
                                                                 "Shingle",
                                                                 "SmallCheckerBoard",
                                                                 "SmallConfetti",
                                                                 "SmallGrid",
                                                                 "SolidDiamond",
                                                                 "Sphere",
                                                                 "Trellis",
                                                                 "Vertical",
                                                                 "Wave",
                                                                 "Weave",
                                                                 "WideDownwardDiagonal",
                                                                 "WideUpwardDiagonal",
                                                                 "ZigZag"});
            this.hatchStyleCombo.Location = new System.Drawing.Point(40, 32);
            this.hatchStyleCombo.MaxDropDownItems = 28;
            this.hatchStyleCombo.Name = "hatchStyleCombo";
            this.hatchStyleCombo.Size = new System.Drawing.Size(208, 21);
            this.hatchStyleCombo.TabIndex = 1;
            this.hatchStyleCombo.SelectionChangeCommitted += new System.EventHandler(this.hatchStyleCombo_SelectionChangeCommitted);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.panel.Location = new System.Drawing.Point(0, 88);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(296, 224);
            this.panel.TabIndex = 2;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 310);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.panel,
                                                                          this.hatchStyleCombo});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "HatchBrush Example";
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

        private void hatchStyleCombo_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if(_panelBrush != null)
                _panelBrush.Dispose();
            switch((string)hatchStyleCombo.SelectedItem)
            {
                case "BackwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.White, Color.Black);
                    break;

                case "Cross":
                   _panelBrush = new HatchBrush(HatchStyle.Cross, Color.White, Color.Black);
                    break;

                case "DarkDownwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.White, Color.Black);
                    break;

                case "DarkHorizontal":
                   _panelBrush = new HatchBrush(HatchStyle.DarkHorizontal, Color.White, Color.Black);
                    break;

                case "DarkUpwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.White, Color.Black);
                    break;

                case "DarkVertical":
                   _panelBrush = new HatchBrush(HatchStyle.DarkVertical, Color.White, Color.Black);
                    break;

                case "DashedDownwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.White, Color.Black);
                    break;

                case "DashedHorizontal":
                   _panelBrush = new HatchBrush(HatchStyle.DashedHorizontal, Color.White, Color.Black);
                    break;

                case "DashedUpwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.DashedUpwardDiagonal, Color.White, Color.Black);
                    break;

                case "DashedVertical":
                   _panelBrush = new HatchBrush(HatchStyle.DashedVertical, Color.White, Color.Black);
                    break;

                case "DiagonalBrick":
                   _panelBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.White, Color.Black);
                    break;

                case "DiagonalCross":
                   _panelBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.White, Color.Black);
                    break;

                case "Divot":
                   _panelBrush = new HatchBrush(HatchStyle.Divot, Color.White, Color.Black);
                    break;

                case "DottedDiamond":
                   _panelBrush = new HatchBrush(HatchStyle.DottedDiamond, Color.White, Color.Black);
                    break;

                case "DottedGrid":
                   _panelBrush = new HatchBrush(HatchStyle.DottedGrid, Color.White, Color.Black);
                    break;

                case "ForwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.White, Color.Black);
                    break;

                case "Horizontal":
                   _panelBrush = new HatchBrush(HatchStyle.Horizontal, Color.White, Color.Black);
                    break;

                case "HorizontalBrick":
                   _panelBrush = new HatchBrush(HatchStyle.HorizontalBrick, Color.White, Color.Black);
                    break;

                case "LargeCheckerBoard":
                   _panelBrush = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Black);
                    break;

                case "LargeConfetti":
                   _panelBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.White, Color.Black);
                    break;

                case "LargeGrid":
                   _panelBrush = new HatchBrush(HatchStyle.LargeGrid, Color.White, Color.Black);
                    break;

                case "LightDownwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.White, Color.Black);
                    break;

                case "LightHorizontal":
                   _panelBrush = new HatchBrush(HatchStyle.LightHorizontal, Color.White, Color.Black);
                    break;

                case "LightUpwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.LightUpwardDiagonal, Color.White, Color.Black);
                    break;

                case "LightVertical":
                   _panelBrush = new HatchBrush(HatchStyle.LightVertical, Color.White, Color.Black);
                    break;

                case "Max":
                   _panelBrush = new HatchBrush(HatchStyle.Max, Color.White, Color.Black);
                    break;

                case "Min":
                   _panelBrush = new HatchBrush(HatchStyle.Min, Color.White, Color.Black);
                    break;

                case "NarrowHorizontal":
                   _panelBrush = new HatchBrush(HatchStyle.NarrowHorizontal, Color.White, Color.Black);
                    break;

                case "NarrowVertical":
                   _panelBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.White, Color.Black);
                    break;

                case "OutlinedDiamond":
                   _panelBrush = new HatchBrush(HatchStyle.OutlinedDiamond, Color.White, Color.Black);
                    break;

                case "Percent05":
                   _panelBrush = new HatchBrush(HatchStyle.Percent05, Color.White, Color.Black);
                    break;

                case "Percent10":
                   _panelBrush = new HatchBrush(HatchStyle.Percent10, Color.White, Color.Black);
                    break;

                case "Percent20":
                   _panelBrush = new HatchBrush(HatchStyle.Percent20, Color.White, Color.Black);
                    break;

                case "Percent25":
                   _panelBrush = new HatchBrush(HatchStyle.Percent25, Color.White, Color.Black);
                    break;

                case "Percent30":
                   _panelBrush = new HatchBrush(HatchStyle.Percent30, Color.White, Color.Black);
                    break;

                case "Percent40":
                   _panelBrush = new HatchBrush(HatchStyle.Percent40, Color.White, Color.Black);
                    break;

                case "Percent50":
                   _panelBrush = new HatchBrush(HatchStyle.Percent50, Color.White, Color.Black);
                    break;

                case "Percent60":
                   _panelBrush = new HatchBrush(HatchStyle.Percent60, Color.White, Color.Black);
                    break;

                case "Percent70":
                   _panelBrush = new HatchBrush(HatchStyle.Percent70, Color.White, Color.Black);
                    break;

                case "Percent75":
                   _panelBrush = new HatchBrush(HatchStyle.Percent75, Color.White, Color.Black);
                    break;

                case "Percent80":
                   _panelBrush = new HatchBrush(HatchStyle.Percent80, Color.White, Color.Black);
                    break;

                case "Percent90":
                   _panelBrush = new HatchBrush(HatchStyle.Percent90, Color.White, Color.Black);
                    break;

                case "Plaid":
                   _panelBrush = new HatchBrush(HatchStyle.Plaid, Color.White, Color.Black);
                    break;

                case "Shingle":
                   _panelBrush = new HatchBrush(HatchStyle.Shingle, Color.White, Color.Black);
                    break;

                case "SmallCheckerBoard":
                   _panelBrush = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.White, Color.Black);
                    break;

                case "SmallConfetti":
                   _panelBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.White, Color.Black);
                    break;

                case "SmallGrid":
                   _panelBrush = new HatchBrush(HatchStyle.SmallGrid, Color.White, Color.Black);
                    break;

                case "SolidDiamond":
                   _panelBrush = new HatchBrush(HatchStyle.SolidDiamond, Color.White, Color.Black);
                    break;

                case "Sphere":
                   _panelBrush = new HatchBrush(HatchStyle.Sphere, Color.White, Color.Black);
                    break;

                case "Trellis":
                   _panelBrush = new HatchBrush(HatchStyle.Trellis, Color.White, Color.Black);
                    break;

                case "Vertical":
                   _panelBrush = new HatchBrush(HatchStyle.Vertical, Color.White, Color.Black);
                    break;

                case "Wave":
                   _panelBrush = new HatchBrush(HatchStyle.Wave, Color.White, Color.Black);
                    break;

                case "Weave":
                   _panelBrush = new HatchBrush(HatchStyle.Weave, Color.White, Color.Black);
                    break;

                case "WideDownwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.White, Color.Black);
                    break;

                case "WideUpwardDiagonal":
                   _panelBrush = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.White, Color.Black);
                    break;

                case "ZigZag":
                   _panelBrush = new HatchBrush(HatchStyle.ZigZag, Color.White, Color.Black);
                    break;
            }
            panel.Invalidate();
        }

        private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if(_panelBrush != null)
                e.Graphics.FillRectangle(_panelBrush, panel.ClientRectangle);
        }
	}
}
