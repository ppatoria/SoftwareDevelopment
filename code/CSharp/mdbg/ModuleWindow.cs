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

using Microsoft.Samples.Debugging.CorDebug;

namespace gui
{
    partial class ModuleWindow : DebuggerToolWindow
    {
        public ModuleWindow(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
        }

        // Populate the module window with the current list.
        protected override void RefreshToolWindowInternal()
        {
            ListView.ListViewItemCollection items = this.listView1.Items;
            items.Clear();

            MDbgProcess proc = this.CurrentProcess;
            if ((proc == null) || proc.IsRunning)
            {
                return;
            }

            
            foreach (MDbgModule m in proc.Modules)
            {
                string stFlags = "";

                if (m.SymReader == null)
                {
                    stFlags += "[No symbols]";
                }
                else
                {
                    stFlags += "[Symbols]";
                }

                string fullname = m.CorModule.Name;
                string directory = System.IO.Path.GetDirectoryName(fullname);
                string name = System.IO.Path.GetFileName(fullname);

                bool fIsDynamic = m.CorModule.IsDynamic;
                if (fIsDynamic)
                {
                    stFlags += "[Dynamic] ";
                }

                CorDebugJITCompilerFlags flags = m.CorModule.JITCompilerFlags;

                bool fNotOptimized = (flags & CorDebugJITCompilerFlags.CORDEBUG_JIT_DISABLE_OPTIMIZATION) == CorDebugJITCompilerFlags.CORDEBUG_JIT_DISABLE_OPTIMIZATION;
                if (fNotOptimized)
                {
                    stFlags += "[Not-optimized] ";
                }
                else
                {
                    stFlags += "[Optimized] ";
                }

                // Columns: Id, Name, Path, Flags
                ListViewItem x = new ListViewItem(
                   new string[] { m.Number.ToString(), name, directory, stFlags }
                   );
                
                items.Add(x);
            }
        }
    }
}