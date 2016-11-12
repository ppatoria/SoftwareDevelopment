using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace SimpleEdit
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.MenuItem fileMenuItem;
        private System.Windows.Forms.MenuItem fileOpenMenuItem;
        private System.Windows.Forms.MenuItem fileExitMenuItem;
        private System.Windows.Forms.MenuItem editMenuItem;
        private System.Windows.Forms.MenuItem editClearMenuItem;
        private System.Windows.Forms.MenuItem editWordWrapMenuItem;
        private System.Windows.Forms.MenuItem viewMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem viewScrollBarMenuItem;
        private System.Windows.Forms.MenuItem hScrollMenuItem;
        private System.Windows.Forms.MenuItem vScrollMenuItem;
        private System.Windows.Forms.MenuItem fileSaveMenuItem;
        private System.Windows.Forms.MenuItem fileSaveAsMenuItem;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        const string _fileFilter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        const string _overwriteWarning = "File already exists, OK to overwrite?";
        const string _appName = "Mini Editor";

        string _fileName = "";
        private System.Windows.Forms.MenuItem editFontMenuItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem editBoldMenuItem;
        private System.Windows.Forms.MenuItem editItalicMenuItem;
        private System.Windows.Forms.MenuItem editUnderlineMenuItem;
        string _pathName = "";

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
            this.textBox = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSaveMenuItem = new System.Windows.Forms.MenuItem();
            this.fileSaveAsMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.fileExitMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.viewScrollBarMenuItem = new System.Windows.Forms.MenuItem();
            this.hScrollMenuItem = new System.Windows.Forms.MenuItem();
            this.vScrollMenuItem = new System.Windows.Forms.MenuItem();
            this.editMenuItem = new System.Windows.Forms.MenuItem();
            this.editClearMenuItem = new System.Windows.Forms.MenuItem();
            this.editWordWrapMenuItem = new System.Windows.Forms.MenuItem();
            this.editFontMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.editBoldMenuItem = new System.Windows.Forms.MenuItem();
            this.editItalicMenuItem = new System.Windows.Forms.MenuItem();
            this.editUnderlineMenuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(292, 201);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.fileMenuItem,
                                                                                      this.viewMenuItem,
                                                                                      this.editMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.fileOpenMenuItem,
                                                                                         this.fileSaveMenuItem,
                                                                                         this.fileSaveAsMenuItem,
                                                                                         this.menuItem2,
                                                                                         this.fileExitMenuItem});
            this.fileMenuItem.Text = "&File";
            this.fileMenuItem.Popup += new System.EventHandler(this.fileMenuItem_Popup);
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Index = 0;
            this.fileOpenMenuItem.Text = "&Open...";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Index = 1;
            this.fileSaveMenuItem.Text = "&Save";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // fileSaveAsMenuItem
            // 
            this.fileSaveAsMenuItem.Index = 2;
            this.fileSaveAsMenuItem.Text = "Save &As...";
            this.fileSaveAsMenuItem.Click += new System.EventHandler(this.fileSaveAsMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Index = 4;
            this.fileExitMenuItem.Text = "E&xit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.Index = 1;
            this.viewMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.viewScrollBarMenuItem});
            this.viewMenuItem.Text = "&View";
            // 
            // viewScrollBarMenuItem
            // 
            this.viewScrollBarMenuItem.Index = 0;
            this.viewScrollBarMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                  this.hScrollMenuItem,
                                                                                                  this.vScrollMenuItem});
            this.viewScrollBarMenuItem.Text = "&Scroll bars";
            this.viewScrollBarMenuItem.Popup += new System.EventHandler(this.viewScrollBarMenuItem_Popup);
            // 
            // hScrollMenuItem
            // 
            this.hScrollMenuItem.Index = 0;
            this.hScrollMenuItem.Text = "&Horizontal";
            this.hScrollMenuItem.Click += new System.EventHandler(this.hScrollMenuItem_Click);
            // 
            // vScrollMenuItem
            // 
            this.vScrollMenuItem.Index = 1;
            this.vScrollMenuItem.Text = "&Vertical";
            this.vScrollMenuItem.Click += new System.EventHandler(this.vScrollMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Index = 2;
            this.editMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.editClearMenuItem,
                                                                                         this.editWordWrapMenuItem,
                                                                                         this.menuItem3,
                                                                                         this.editFontMenuItem,
                                                                                         this.editBoldMenuItem,
                                                                                         this.editItalicMenuItem,
                                                                                         this.editUnderlineMenuItem});
            this.editMenuItem.Text = "&Edit";
            this.editMenuItem.Popup += new System.EventHandler(this.editMenuItem_Popup);
            // 
            // editClearMenuItem
            // 
            this.editClearMenuItem.Index = 0;
            this.editClearMenuItem.Text = "&Clear";
            this.editClearMenuItem.Click += new System.EventHandler(this.editClearMenuItem_Click);
            // 
            // editWordWrapMenuItem
            // 
            this.editWordWrapMenuItem.Index = 1;
            this.editWordWrapMenuItem.Text = "&Word Wrap";
            this.editWordWrapMenuItem.Click += new System.EventHandler(this.editWordWrapMenuItem_Click);
            // 
            // editFontMenuItem
            // 
            this.editFontMenuItem.Index = 3;
            this.editFontMenuItem.Text = "&Font...";
            this.editFontMenuItem.Click += new System.EventHandler(this.editFontMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // editBoldMenuItem
            // 
            this.editBoldMenuItem.Index = 4;
            this.editBoldMenuItem.Text = "&Bold";
            this.editBoldMenuItem.Click += new System.EventHandler(this.editBoldMenuItem_Click);
            // 
            // editItalicMenuItem
            // 
            this.editItalicMenuItem.Index = 5;
            this.editItalicMenuItem.Text = "&Italic";
            this.editItalicMenuItem.Click += new System.EventHandler(this.editItalicMenuItem_Click);
            // 
            // editUnderlineMenuItem
            // 
            this.editUnderlineMenuItem.Index = 6;
            this.editUnderlineMenuItem.Text = "&Underline";
            this.editUnderlineMenuItem.Click += new System.EventHandler(this.editUnderlineMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(292, 201);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox});
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Mini Editor";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.MenuStart += new System.EventHandler(this.mainForm_MenuStart);
            this.MenuComplete += new System.EventHandler(this.mainForm_MenuComplete);
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

        private void mainForm_Load(object sender, System.EventArgs e)
        {
            // Set the caption for a new session
            Text = _appName + " - " + "[empty]";
        }

        private void fileOpenMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = _fileFilter;
            dlg.InitialDirectory = Application.CommonAppDataPath;
            dlg.CheckFileExists = false;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                if(File.Exists(path) != true)
                {
                    StreamWriter writer = File.CreateText(path);
                    writer.Close();
                }
                _fileName = Path.GetFileName(path);
                _pathName = path;
                Text = _appName + " - " +  _fileName;
                StreamReader reader = new StreamReader(path);
                textBox.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void editClearMenuItem_Click(object sender, System.EventArgs e)
        {
            _fileName = "";
            _pathName = "";
            Text = _appName + " - " + "[Empty]";
            textBox.Clear();
        }

        private void editWordWrapMenuItem_Click(object sender, System.EventArgs e)
        {
            textBox.WordWrap = !textBox.WordWrap;
        }

        private void fileExitMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void SaveTextToPath(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Write(textBox.Text);
            writer.Close();
            textBox.Modified = false;
        }

        private void SaveTextToNewPath()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = _fileFilter;
            dlg.InitialDirectory = Application.CommonAppDataPath;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                if(File.Exists(path) == true)
                {
                    DialogResult result = MessageBox.Show(_overwriteWarning,
                        _appName,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                    if(result == DialogResult.Cancel)
                        return;
                }
                _fileName = Path.GetFileName(path);
                _pathName = path;
                Text = _appName + " - " +  _fileName;
                SaveTextToPath(path);
            }
        }

        private void fileSaveMenuItem_Click(object sender, System.EventArgs e)
        {
            if(_fileName != null && _fileName != "")
                SaveTextToPath(_pathName);
            else
                SaveTextToNewPath();
        }

        private void fileSaveAsMenuItem_Click(object sender, System.EventArgs e)
        {
            SaveTextToNewPath();
        }

        private void hScrollMenuItem_Click(object sender, System.EventArgs e)
        {
            if(hScrollMenuItem.Checked)
            {
                // Clear horizontal scroll bars
                if(textBox.ScrollBars == ScrollBars.Both)
                    textBox.ScrollBars = ScrollBars.Vertical;
                else
                    textBox.ScrollBars = ScrollBars.None;
            }
            else
            {
                // Set horizontal scroll bars
                if(textBox.ScrollBars == ScrollBars.Vertical)
                    textBox.ScrollBars = ScrollBars.Both;
                else
                    textBox.ScrollBars = ScrollBars.Horizontal;
            }
        }

        private void vScrollMenuItem_Click(object sender, System.EventArgs e)
        {
            if(vScrollMenuItem.Checked)
            {
                // Clear vertical scroll bars
                if(textBox.ScrollBars == ScrollBars.Both)
                    textBox.ScrollBars = ScrollBars.Horizontal;
                else
                    textBox.ScrollBars = ScrollBars.None;
            }
            else
            {
                // Set vertical scroll bars
                if(textBox.ScrollBars == ScrollBars.Horizontal)
                    textBox.ScrollBars = ScrollBars.Both;
                else
                    textBox.ScrollBars = ScrollBars.Vertical;
            }
        }

        // --- Menu Update Handlers --//
        private void editMenuItem_Popup(object sender, System.EventArgs e)
        {
            editWordWrapMenuItem.Checked = textBox.WordWrap;

            editBoldMenuItem.Checked = Font.Bold;
            editItalicMenuItem.Checked = Font.Italic;
            editUnderlineMenuItem.Checked = Font.Underline;
        }

        private void viewScrollBarMenuItem_Popup(object sender, System.EventArgs e)
        {
            // Horizontal scrolling is n/a if the text box control
            // has word-wrapping enabled.
            hScrollMenuItem.Enabled = !textBox.WordWrap;

            switch(textBox.ScrollBars)
            {
                case ScrollBars.Both:
                    hScrollMenuItem.Checked = true;
                    vScrollMenuItem.Checked = true;
                    break;

                case ScrollBars.Vertical:
                    hScrollMenuItem.Checked = false;
                    vScrollMenuItem.Checked = true;
                    break;

                case ScrollBars.Horizontal:
                    hScrollMenuItem.Checked = true;
                    vScrollMenuItem.Checked = false;
                    break;

                default:
                    hScrollMenuItem.Checked = false;
                    vScrollMenuItem.Checked = false;
                    break;
            }
        }

        private void mainForm_MenuComplete(object sender, System.EventArgs e)
        {
            Trace.WriteLine("MenuComplete event");
        }

        private void mainForm_MenuStart(object sender, System.EventArgs e)
        {
            Trace.WriteLine("MenuStart event");
        }

        private void fileMenuItem_Popup(object sender, System.EventArgs e)
        {
            fileSaveMenuItem.Enabled = textBox.Modified;
        }

        private void editFontMenuItem_Click(object sender, System.EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = Font;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Font = dialog.Font;
                Invalidate();
            }
        }

        private void FlipFontStyleBit(FontStyle style)
        {
            // Get the current font and style.
            Font oldFont = Font;
            // Flip the Bold style flag.
            FontStyle newStyle = Font.Style ^ style;
            // Use the old font and the new style to create a new Font object.
            Font = new Font(oldFont, newStyle);
            // Clean up.
            oldFont.Dispose();
            Invalidate();
        }

private void editBoldMenuItem_Click(object sender, System.EventArgs e)
{
    // Get the current font and style.
    Font oldFont = Font;
    // Flip the Bold style flag.
    FontStyle newStyle = Font.Style ^ FontStyle.Bold;
    // Use the old font and the new style to create a new Font object.
    Font = new Font(oldFont, newStyle);
    // Clean up.
    oldFont.Dispose();
    Invalidate();
}

        private void editItalicMenuItem_Click(object sender, System.EventArgs e)
        {
            // Get the current font and style.
            Font oldFont = Font;
            // Flip the Bold style flag.
            FontStyle newStyle = Font.Style ^ FontStyle.Italic;
            // Use the old font and the new style to create a new Font object.
            Font = new Font(oldFont, newStyle);
            // Clean up.
            oldFont.Dispose();
            Invalidate();
        }

        private void editUnderlineMenuItem_Click(object sender, System.EventArgs e)
        {
        
        }
    }
}
