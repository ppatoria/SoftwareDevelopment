#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

using System.Globalization;
using Microsoft.Samples.Tools.Mdbg;
using Microsoft.Samples.Debugging.MdbgEngine;  
using Microsoft.Samples.Tools.Mdbg.Extension;

namespace gui
{
    partial class Callstack : DebuggerToolWindow
    {
        public Callstack(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();            
        }

        
        
        class FramePair
        {
            public FramePair(MDbgFrame f, String s)
            {
                m_frame = f;
                m_displayString = s;
            }

            public override string ToString()
            {
                return m_displayString;
            }

            internal MDbgFrame m_frame;
            String m_displayString;
        }
        
        
        // Add item to list
        // 'stText' is what we display in the list box.
        // 'frame' is the underlying frame associated with the text. Can be null if there's no frame.
        void AddItem(string stText, MDbgFrame frame)
        {
            ListBox.ObjectCollection list = this.listBoxCallstack.Items;
            list.Add(new FramePair(frame, stText));
        }

        // Clear callstack for running
        public void MarkCallstackAsRunning()
        {
            ListBox.ObjectCollection list = this.listBoxCallstack.Items;
            list.Clear();
            AddItem("Callstack unavailable because process is either running or not available.", null);
        }

        // Update list w/ current callstack
        public void RefreshCallstack(MDbgThread thread)
        {
            ListBox.ObjectCollection list = this.listBoxCallstack.Items;
            list.Clear();

            // Set Title.
            this.Text = "Callstack on Thread #" + thread.Number + " (tid=" + thread.Id + ")";

            // Populate listbox with frames.
            MDbgFrame f = thread.BottomFrame;
            MDbgFrame af = thread.HaveCurrentFrame ? thread.CurrentFrame : null;

            int i = 0;
            int depth = 20;
            bool verboseOutput = true;

            while (f != null && (depth == 0 || i < depth))
            {
                string line;
                if (f.IsInfoOnly)
                {
                    line = string.Format(CultureInfo.InvariantCulture, "[{0}]", f.ToString());
                }
                else
                {
                    string frameDescription =  "<unknown>";
                    try
                    {
                        // This may actually do a ton of work, including evaluating parameters.
                        frameDescription = f.ToString(verboseOutput ? "v" : null);
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        if (f.Function != null)
                        {
                            frameDescription = f.Function.FullName;
                        }                        
                    }

                    line = string.Format(CultureInfo.InvariantCulture, "{0}{1}. {2}", f.Equals(af) ? "*" : " ", i, frameDescription);
                    ++i;
                }
                AddItem(line, f);
                f = f.NextUp;
            }
            if (f != null && depth != 0) // means we still have some frames to show....
            {
                AddItem(
                    string.Format(CultureInfo.InvariantCulture, "displayed only first {0} frames. For more frames use -c switch", depth), 
                    null);
            }
        }

        // Refresh the callstack window.
        protected override void RefreshToolWindowInternal()
        {
            MDbgProcess proc = this.MainForm.ActiveProcess;
                        
            if ((proc == null) || proc.IsRunning)
            {
                MarkCallstackAsRunning();
            }
            else
            {
                try
                {
                    // This may throw in certain exit-process scenarios.
                    MDbgThread thread = proc.Threads.Active;
                    this.RefreshCallstack(thread);
                }
                catch (Exception)
                {
                    MarkCallstackAsRunning();
                }
            }

        }

        // Invoked when we change the selection on the list box.
        // This will change the current active frame in the debugger and refresh.
        private void listBoxCallstack_DoubleClicked(object sender, EventArgs e)
        {
            object o = this.listBoxCallstack.SelectedItem;
            FramePair pair = (FramePair)o;

            MDbgFrame f = pair.m_frame;
            if (f == null)
            {
                return;
            }


            if (this.MainForm.ActiveProcess != null)
            {

                // Update callstack
                MDbgThread t = this.MainForm.ActiveProcess.Threads.Active;

                try
                {
                    t.CurrentFrame = f;
                }
                catch(InvalidOperationException)
                {
                    // if it throws an invalid op, then that means our frames somehow got out of sync
                    // and we weren't fully refreshed.
                    return;
                }


                // Need to refresh UI to show update.
                this.MainForm.ShowCurrentLocation();
                this.MainForm.Invalidate();
            }
        }

        private void Callstack_Load(object sender, EventArgs e)
        {
        
        } // end SelectedIndexChanged
    }
}