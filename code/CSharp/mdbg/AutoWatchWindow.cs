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
    partial class AutoWatchWindow : DebuggerToolWindow
    {
        public AutoWatchWindow(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
        }

        protected override void RefreshToolWindowInternal()
        {
            MDbgFrame frame = this.CurrentFrame;
            if (frame == null)
            {
                return;
            }

            // Reset
            TreeView t = this.treeView1;
            t.BeginUpdate();
            t.Nodes.Clear();

            // Add Vars to window.            
            MDbgFunction f = frame.Function;

            MDbgValue[] vals = f.GetActiveLocalVars(frame);
            if (vals != null)
            {
                foreach (MDbgValue v in vals)
                {
                    Util.PrintInternal(v, t.Nodes, 0);
                }
            }

            vals = f.GetArguments(frame);
            if (vals != null)
            {
                foreach (MDbgValue v in vals)
                {
                    Util.PrintInternal(v, t.Nodes, 0);
                }
            }

            t.EndUpdate();


        } // refresh


    } // AutoWatchWindow
}