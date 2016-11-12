//---------------------------------------------------------------------
//  This file is part of the CLR Managed Debugger (mdbg) Sample.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//---------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Globalization;

using System.Reflection;

using Microsoft.Samples.Debugging.MdbgEngine;

namespace Microsoft.Samples.Tools.Mdbg.Extension
{
    /// <summary>
    /// SourceViwerForm
    /// One of these for each source-file.
    /// </summary>
    public class SourceViewerForm : System.Windows.Forms.Form
    {
        private IContainer components;

        private SourceViewerForm(Form parent,string path,ArrayList lines)
        {
            if (m_glyphs == null)
            {
                m_glyphs = new Glyphs();
            }

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            m_lineOffset=new int[lines.Count];
            int index=0;
            int c=0;
            StringBuilder sb = new StringBuilder();
            foreach(string line in lines)
            {
                m_lineOffset[c++] = index;
                string lineNoStr = String.Format(CultureInfo.InvariantCulture, "{0,4}:",c);
                sb.Append(lineNoStr);
                sb.Append(line).Append((char)13).Append((char)10);
                index += lineNoStr.Length+line.Length+1;
            }
            richText.Text = sb.ToString();
            MdiParent = parent;
            Visible=true;

            Text = path;
            Debug.Assert(!m_sourceList.Contains(path));
            m_sourceList.Add(path,this);
        }

        // Get the MainForm that this source file is docked in.
        MainForm MainForm
        {
            get { return (MainForm)MdiParent; }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                m_sourceList.Remove(Text);

                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        //#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
// 
// richText
// 
            this.richText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.richText.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richText.HideSelection = false;
            this.richText.Location = new System.Drawing.Point(37, 0);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Courier New" +
                ";}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs24 richText\\par\r\n}\r\n";
            this.richText.Size = new System.Drawing.Size(255, 273);
            this.richText.TabIndex = 0;
            this.richText.WordWrap = false;
            this.richText.VScroll += new System.EventHandler(this.richText_VScroll);
            this.richText.Invalidated += new System.Windows.Forms.InvalidateEventHandler(this.richText_VScroll);
            this.richText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richText_KeyDown);
            this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
// 
// timer1
// 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
// 
// SourceViewerForm
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.richText);
            this.Name = "SourceViewerForm";
            this.Text = "SourceViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SourceViewerForm_Paint);
            this.Resize += new System.EventHandler(this.SourceViewerForm_Resize);
            this.ResumeLayout(false);

        }
        //#endregion

        private System.Windows.Forms.RichTextBox richText;

        private static Hashtable m_sourceList = new Hashtable();

        // Mapping of where each line starts.
        private int[] m_lineOffset;
        private Timer timer1;

        static Glyphs m_glyphs = null;

        public static void ClearSourceFiles()
        {
            m_sourceList.Clear();
        }
        
        // There's one SourceViewerForm instance for each source-file
        // Get the instance for the new source file.
        public static SourceViewerForm GetSourceFile(Form parent,string path)
        {
            String s = String.Intern(path);
            SourceViewerForm source = (SourceViewerForm) m_sourceList[path];
            if(source==null)
            {
                string realLocation = CommandBase.Shell.FileLocator.GetFileLocation(path);
                if(realLocation==null)
                    return null;
                
                string fileLoc = String.Intern(realLocation);
                if(fileLoc==null)
                    return null;
                
                ArrayList lines = LoadLinesFromFile(fileLoc);
                if(lines!=null)
                    source = new SourceViewerForm(parent,path,lines);
            }
            return source;
        }

        #region Mark current source
        // Called when shell is breaking. This lets all source files update 
        // to mark the current stopping location.
        // This may be called multiple times in a row to refresh the source window
        // (such as if the current frame / thread changes).
        public static void OnBreak()
        {
            foreach(SourceViewerForm s in m_sourceList.Values)
            {
                s.ClearHighlight();

                s.m_pos = s.MainForm.CurrentSource;
                if (s.m_pos == null)
                {
                    continue;
                }
                if (s.m_pos.Path != s.Text)
                {
                    s.m_pos = null;
                }

                // Hilight in current source
                if (s.m_pos != null)
                {
                    s.HighlightStatementAtPos(s.m_pos);
                }
            }
        }

        // Called when the shell is about to run again. This lets all source files
        // clear any markings about break state.
        public static void OnRun()
        {
            foreach (SourceViewerForm s in m_sourceList.Values)
            {
                s.ClearHighlight();
                s.m_pos = null;
            }
        }

        // Track if current source-position is in this doc.
        // Null if no current source, or if it's  in another doc.
        MDbgSourcePosition m_pos;

        #region Raw Highlighting
        // Support for highlighting the current source line

        // Track most recent hilight so that we can clear it when source moves.
        // line = -1 if not set.
        int m_iHighlightStartOffset = -1;
        int m_iHiglightLength;

        // Clear the previous highlight set by HighlightStatement.
        void ClearHighlight()
        {
            if (this.m_iHighlightStartOffset != -1)
            {
                int oldIdx = richText.SelectionStart;

                // Restore to default
                richText.Select(this.m_iHighlightStartOffset, this.m_iHiglightLength);
                richText.SelectionBackColor = Color.White;
                richText.SelectionColor = Color.Black;

                richText.SelectionLength = 0;

                this.m_iHighlightStartOffset = -1;
            }
        }
        
        // Highlight the statement at the current character (index, len).
        // Clears previous highlight.
        void HighlightStatement(int index, int len)
        {
            ClearHighlight();

            int oldIdx = richText.SelectionStart;

            this.m_iHighlightStartOffset = index;
            this.m_iHiglightLength = len;

            richText.Select(index, len);
            richText.SelectionBackColor = this.MainForm.IsCurrentSourceActive ? Color.Yellow : Color.LightGreen;
            richText.SelectionColor = Color.Black;

            richText.SelectionLength = 0;
        }

        #endregion Raw Highlighting

        // Highlight the statement for the given Source Position
        void HighlightStatementAtPos(MDbgSourcePosition pos)
        {
            HighlightRangeWorker(
                pos.StartLine,pos.StartColumn,pos.EndLine,pos.EndColumn, 
                this.MainForm.IsCurrentSourceActive);
        }

        void HighlightRangeWorker(int startLine, int startCol, int endLine, int endCol, bool fActive)
        {
            if (!(
                  startLine >= 1 && startLine <= endLine && endLine <= m_lineOffset.Length)
               )
            {
                throw new ArgumentException();
            }

            // scroll to center.
            const int RANGE=3;
            richText.Select(GetOffsetFromPos(startLine-RANGE,0),0);
            richText.Select(GetOffsetFromPos(endLine+RANGE,0),0);

            // handle special case, where col==0 -- the compiler didn't emit line information.
            if(startCol==0)
                startCol = 1;
            if(endCol==0)
                endCol = startCol;

            int startOff = GetOffsetFromPos(startLine,startCol);
            int startLineOff = GetOffsetFromPos(startLine,0);
            int endOff = GetOffsetFromPos(endLine,endCol);

            this.HighlightStatement(startOff, endOff - startOff);

            // Update IP markers
            InvalideGlyphBar();
        }

        #endregion Mark current source

        // Get the adjusted character indext from a (line, col) pair into the real document. 
        // This adjusts for the line numbers we added to the left margin of the document.
        // This is useful because many RichText operations require character indexes.
        private int GetOffsetFromPos(int line,int col)
        {
            if(col>1)
                col = col+5-1;                                      // if col is specified >0 (but is 1based)
            
            if(line<1)
                return 0;

            if(line>m_lineOffset.Length)
                return richText.TextLength;

            int lineOffset = m_lineOffset[line-1];
            int nextLineOfffset = (line==m_lineOffset.Length)?richText.TextLength:m_lineOffset[line];
            return (lineOffset+col>nextLineOfffset)?nextLineOfffset:lineOffset+col;
        }


        private static ArrayList LoadLinesFromFile(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                try
                {
                    ArrayList lines = new ArrayList();

                    string s = sr.ReadLine();
                    while(s!=null)
                    {
                        lines.Add(s);
                        s = sr.ReadLine();
                    }
                    return lines;
                } 
                catch (Exception)
                {
                    return null;
                }
            }
        }


        #region Breakpoint support 
        // Unsorted List of the MDbgBreakpoint objects in this file.
        ArrayList m_Breakpoints = new ArrayList();

        // We don't have a good way of getting the line number from an MDbgBreakpoint, 
        // so we have to store it in a pair.
        class BreakpointPair
        {
            public BreakpointPair(MDbgBreakpoint bp, int iLine)
            {
                m_bp = bp;
                m_iLine = iLine;
            }
            public MDbgBreakpoint m_bp;
            public int m_iLine;
        }
        
        // Toggle a breakpoint at the given line.
        void ToggleBreakpointAtLine(int iLine)
        {
            // Currently, we require an active process. 
            // An alternative is if the source file remembered the unbound breakpoints and then bound them
            // when the process started (and modules got loaded).
            if (!GuiExtension.Shell.Debugger.Processes.HaveActive)
            {
                return;
            }
            MDbgBreakpointCollection c = GuiExtension.Shell.Debugger.Processes.Active.Breakpoints;
            

            // See if we have anything to remove.
            foreach (BreakpointPair p in m_Breakpoints)
            {
                if (p.m_iLine == iLine)
                {
                    p.m_bp.Delete();
                    m_Breakpoints.Remove(p);
                    return;
                }
            }
            
            // Nothing to remove, so must be adding.
            {            
                MDbgBreakpoint b = c.CreateBreakpoint(this.Text, iLine);

                // @todo - we have no way of validating if the line was valid or not.
                // We want to get at ResolveLocation::BpFunctionLocation
                m_Breakpoints.Add(new BreakpointPair(b, iLine));                
            }
        }

        #endregion Breakpoint support

        // Handle key input to the source document.
        // The Main Form also handles key input for most non-source specific commands (such as stepping)
        private void richText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
            case Keys.F9:
                int lineNo = 1+richText.GetLineFromCharIndex(richText.SelectionStart);
                this.ToggleBreakpointAtLine(lineNo);
                break;
            default:
                return;
            }
            e.Handled=true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);

            // Draw current source-line arrows in the glyph bar.
            MDbgSourcePosition pos = this.m_pos;
            if (pos != null)
            {                
                {
                    int iLine = pos.Line;

                    Bitmap bmp = this.MainForm.IsCurrentSourceActive ? m_glyphs.CurrentLineArrow : m_glyphs.NotCurrentLineArrow;
                    this.DrawGlyphAtLine(e, bmp, iLine);
                }
            }

            DrawBreakpoints(e);
        }
        void DrawBreakpoints(PaintEventArgs e)
        {
            foreach (BreakpointPair p in m_Breakpoints)                
            {
                int iLine = p.m_iLine;
                Bitmap bmp = p.m_bp.IsBound ? m_glyphs.Breakpoint : m_glyphs.UnboundBreakpoint;
                this.DrawGlyphAtLine(e, bmp, iLine);
            }
        }

        
        // Invalidate the Glyph Bar.
        public void InvalideGlyphBar()
        {
            this.Invalidate(new Rectangle(0, 0, MARGIN_X, this.Height));
        }

        
        // Draw a glyph at the current source line.
        void DrawGlyphAtLine(PaintEventArgs e, Bitmap bmp, int line)
        {
            if (line <= 0) return;

            Graphics g = e.Graphics;


            int index = m_lineOffset[line - 1];

            Point p = this.richText.GetPositionFromCharIndex(index);

            p.X = MARGIN_X - bmp.Width - 1;

            int FontHeight = 20;
            p.Y += ((FontHeight - bmp.Height) / 2);

            g.DrawImage(bmp, p);
        }

    

        private void SourceViewerForm_Paint(object sender, PaintEventArgs e)
        {            
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {
        
        }

        // Width of the glyph bar in pixels
        const int MARGIN_X = 40;

        // Resize to maintain the glyph bar on the left.
        private void SourceViewerForm_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Size sizeParent = control.ClientSize;

            this.richText.Location = new System.Drawing.Point(MARGIN_X, 0);
            this.richText.Size = new System.Drawing.Size(sizeParent.Width - MARGIN_X, sizeParent.Height);
        }

        // We want to scroll the glyph bar when we scroll the text box.
        // We don't always get this event (eg, when the scroll bar is dragged), so we have a timer backstop as well.
        private void richText_VScroll(object sender, EventArgs e)
        {            
            this.InvalideGlyphBar();            
        }

        // Have a timer to forcibly update the glyph bar.
        // This guarantees we'll refresh the glyph bar even if we miss other notifications.
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.InvalideGlyphBar();
        } 


        // Class to hold resources for glyphs.
        // Singleton, shared by multiple SourceViewerForms.
        internal class Glyphs : IDisposable
        {
            public Glyphs()
            {
                Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();

                string stName = "gui.CurrentLineArrow.bmp";
                m_curLine = new Bitmap(thisAssembly.GetManifestResourceStream(
                        stName));

                stName = "gui.Breakpoint.bmp";
                m_breakpoint = new Bitmap(thisAssembly.GetManifestResourceStream(
                        stName));

                stName = "gui.NotCurrentLineArrow.bmp";
                this.m_notCurLine = new Bitmap(thisAssembly.GetManifestResourceStream(
                        stName));

                stName = "gui.UnboundBreakpoint.bmp";
                this.m_unboundBreakpoint = new Bitmap(thisAssembly.GetManifestResourceStream(
                        stName));
            }

            public void Dispose()
            {
                m_curLine.Dispose();
                m_notCurLine.Dispose();
                m_breakpoint.Dispose();
            }

            Bitmap m_curLine;            
            public Bitmap CurrentLineArrow
            {
                get { return m_curLine; }
            }

            Bitmap m_notCurLine;
            public Bitmap NotCurrentLineArrow
            {
                get { return m_notCurLine; }
            }

            Bitmap m_breakpoint;
            public Bitmap Breakpoint
            {
                get { return m_breakpoint; }
            }

            Bitmap m_unboundBreakpoint;
            public Bitmap UnboundBreakpoint
            {
                get { return m_unboundBreakpoint; }
            }
        } // end class Glyphs



    } // end SourceViewerForm



} // end namespace
