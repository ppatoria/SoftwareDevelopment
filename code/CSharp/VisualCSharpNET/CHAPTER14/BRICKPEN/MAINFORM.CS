using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BrickPen
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
public class MainForm : System.Windows.Forms.Form
{
    HatchBrush _horizontalBrickBrush = null;
    HatchBrush _diagonalBrickBrush = null;
    Pen _diagonalThinBricks = null;
    Pen _horizontalThinBricks = null;
    Pen _diagonalThickBricks = null;
    Pen _horizontalThickBricks = null;
    private System.ComponentModel.Container components = null;

    public MainForm()
    {
        InitializeComponent();
        _horizontalBrickBrush = new HatchBrush(HatchStyle.HorizontalBrick,
            Color.Gray,
            Color.Firebrick);
        _diagonalBrickBrush = new HatchBrush(HatchStyle.DiagonalBrick,
            Color.Gray,
            Color.Firebrick);
        _diagonalThinBricks = new Pen(_diagonalBrickBrush);
        _diagonalThickBricks = new Pen(_diagonalBrickBrush, 10.0f);
        _horizontalThinBricks = new Pen(_horizontalBrickBrush);
        _horizontalThickBricks = new Pen(_horizontalBrickBrush, 10.0f);
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
            _horizontalBrickBrush.Dispose();
            _diagonalBrickBrush.Dispose();
            _diagonalThinBricks.Dispose();
            _diagonalThickBricks.Dispose();
            _horizontalThinBricks.Dispose();
            _horizontalThickBricks.Dispose();
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
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Name = "MainForm";
        this.Text = "Pens with brush pattern";
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);

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

    private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        // Wash form client area with Windows client color.
        e.Graphics.FillRectangle(SystemBrushes.Window, ClientRectangle);
        // Display labels
        e.Graphics.DrawString("Thin horizontal bricks:",
                                Font,
                                SystemBrushes.WindowText,
                                10.0f,
                                10.0f);
        e.Graphics.DrawString("Thin diagonal bricks:",
                                Font,
                                SystemBrushes.WindowText,
                                10.0f, 
                                60.0f);
        e.Graphics.DrawString("Thick horizontal bricks:",
                                Font,
                                SystemBrushes.WindowText,
                                10.0f,
                                110.0f);
        e.Graphics.DrawString("Thick diagonal bricks:",
                                Font,
                                SystemBrushes.WindowText,
                                10.0f,
                                160.0f);
        // Draw lines with pens
        e.Graphics.DrawLine(_horizontalThinBricks, 10.0f, 30.0f, 200.0f, 30.0f);
        e.Graphics.DrawLine(_diagonalThinBricks, 10.0f, 80.0f, 200.0f, 80.0f);
        e.Graphics.DrawLine(_horizontalThickBricks, 10.0f, 130.0f, 200.0f, 130.0f);
        e.Graphics.DrawLine(_diagonalThickBricks, 10.0f, 180.0f, 200.0f, 180.0f);
    }

}
}
