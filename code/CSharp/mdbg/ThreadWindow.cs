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
using Microsoft.Samples.Debugging.CorDebug.NativeApi;

namespace gui
{
    // Tool window to display thread list.
    // Deriving from a Generic class seems to confuse the Designer in VS2005 Beta 1. One workaround is to
    // switch the derived class to "Form", use the designer, and then restore the derived class so we can build.
    partial class ThreadWindow : 
        DebuggerListWindow<MDbgThread>
        //Form
    {
        public ThreadWindow(MainForm mainForm)
            : base(mainForm, "Threads not available while process is running")
        {
            InitializeComponent();

            // Prep the context menu that we use to Freeze / Thaw threads.
            m_menu = new ContextMenu();
            m_menu.Popup += new EventHandler(this.Popup);                        
            this.ContextMenu = m_menu;


            this.listBox1.DoubleClick += new EventHandler(this.OnSelectionChanged);


            this.Text = "Thread List";
        }

        #region Context Menu to Freeze / Thaw Threads
        ContextMenu m_menu;

        // Called when ContextMenu is about to popup
        void Popup(object sender, EventArgs args)
        {
            // Don't process UI events if process is running.
            if (this.CurrentProcess == null)
            {
                return;
            }

            // Get selection.
            MDbgThread t = this.SelectedItem;
            if (t == null)
            {
                return;
            }

            m_menu.MenuItems.Clear();


            string st = IsFrozen(t) ? "Thaw" : "Freeze";
            st += " thread=" + t.Number;
            m_menu.MenuItems.Add(st, new EventHandler(this.OnThreadFrozenToggled));

        }

        // Invoked when ContextMenu item is selected to toggle Frozen/Thawed status.
        // This is invoked on the currently selected thread, and that can't change while the ContextMenu is up.
        void OnThreadFrozenToggled(Object sender, EventArgs args)
        {
            MDbgThread t = this.SelectedItem;
            
            CorDebugThreadState state = t.CorThread.DebugState;
            bool fFrozen = (state & CorDebugThreadState.THREAD_SUSPEND) == CorDebugThreadState.THREAD_SUSPEND;
            if (fFrozen)
            {
                // Thaw the thread
                state &= ~CorDebugThreadState.THREAD_SUSPEND;
            }
            else
            {
                // Freeze the thread
                state |= CorDebugThreadState.THREAD_SUSPEND;
            }
            t.CorThread.DebugState = state;

            // Need to redraw the window.
            this.RefreshToolWindow();
        }

        // Is the MDbgThread frozen?
        bool IsFrozen(MDbgThread t)
        {
            CorDebugThreadState state = t.CorThread.DebugState;
            bool fFrozen = (state & CorDebugThreadState.THREAD_SUSPEND) == CorDebugThreadState.THREAD_SUSPEND;
            return fFrozen;
        }

        #endregion Context Menu to Freeze / Thaw Threads

        protected override ListBox ListBox
        {
            get { return this.listBox1; }
        }

        void OnSelectionChanged(Object sender, EventArgs args)
        {
            MDbgThread t = this.SelectedItem;
            if (t == null)
            {
                return;
            }
            // If we have an threads in the list, then we must have an active process and 
            // valid thread collection.
            if (this.CurrentProcess != null)
            {
                this.CurrentProcess.Threads.Active = t;
            }

            this.RefreshMainWindow();
        }

        // Refresh the Threads window.
        public override void RefreshWhenStopped()
        {
            ListBox.ObjectCollection items = this.Items;
            items.Clear();

            MDbgProcess proc = this.CurrentProcess;

            MDbgThread tActive = proc.Threads.HaveActive ? (proc.Threads.Active) : null;
            foreach(MDbgThread t in proc.Threads)
            {
                string stFrame = "<unknown>";
                
                if (t.BottomFrame != null)
                {
                    stFrame = t.BottomFrame.Function.FullName;
                }
                string stActive = (t == tActive) ? "*" : " ";
                
                string stFrozen = IsFrozen(t) ? "(FROZEN) " : "";

                string s = stActive + "(" + t.Number + ") TID=" + t.Id + ", " + stFrozen + stFrame;
                this.AddItem(s, t);
            }
        }

    } // end class ThreadWindow

} // end GUI namespace