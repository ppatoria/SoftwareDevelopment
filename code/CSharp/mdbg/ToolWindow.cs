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
    // Base class for Tool (aka Helper) Windows in the debugger GUI.
    abstract class DebuggerToolWindow : Form
    {
        protected DebuggerToolWindow(MainForm f)
        {
            this.m_MainForm = f;

            // Get this form to act as a "sub form" of the parent form.
            this.Owner = f;
            this.ShowInTaskbar = false;
            this.MinimizeBox = false;
        }

        MainForm m_MainForm;
        public MainForm MainForm
        {
            get { return this.m_MainForm; }
        }

        // Refresh the tool window. This is useful at debugging stopping events.

        public void RefreshToolWindow()
        {
            try
            {
                // Refreshing may extensively access the ICorDebug API,and that
                // may throw in lots of ways (such as if the process exited).                
                RefreshToolWindowInternal();
            }
            catch (Exception)
            {
                // If we threw, we should still be ok.
                // The tool window wasn't updating global state, so 
                // in a worst case, the UI state  may be invalid, so just close the window.
                // The ICorDebug state should still be ok, so nothing to worry about there.
                this.Close();
            }
        }

        protected abstract void RefreshToolWindowInternal();


        // Helpers

        public MDbgProcess CurrentProcess
        {
            get
            {
                return this.MainForm.ActiveProcess;
            }
        }

        // return current Frame, else null if there isn't one.
        public MDbgFrame CurrentFrame
        {
            get
            {
                MDbgProcess proc = this.MainForm.ActiveProcess;
                if (proc == null)
                {
                    return null;
                }

                if (!proc.Threads.HaveActive)
                {
                    return null;
                }

                MDbgThread thread = proc.Threads.Active;
                if (!thread.HaveCurrentFrame)
                {
                    return null;
                }

                MDbgFrame frame = thread.CurrentFrame;
                return frame;
            }
        } // end property CurrentFrame.

    }

    // Helper base class for tool windows that just list items.
    // TObject is the MDbg objects that this window lists.
    abstract class DebuggerListWindow<TObject>
        : DebuggerToolWindow
        where TObject : MarshalByRefObject // Need constraint so we know TObject is not a value-type.
    {
        // mainForm - main form that this window should be hosted in.
        // stUnavailable - string to display in list if the process is running.
        public DebuggerListWindow(MainForm mainForm, string stUnavailable)
            : base(mainForm)
        {
            m_stUnavailable = stUnavailable;
        }

        string m_stUnavailable;

        // Associate MDbg rich object with string for placing into listbox.
        // Thje list box will display the string, and then when selected
        // we can obtain the real backing item.
        class ListPair<T>
        {
            public ListPair(T item, String s)
            {
                m_item = item;
                m_displayString = s;
            }

            public override string ToString()
            {
                return m_displayString;
            }

            internal T m_item;
            String m_displayString;
        }

        // Add item to list
        // 'stText' is what we display in the list box.
        // 'frame' is the underlying frame associated with the text. Can be null if there's no frame.
        protected void AddItem(string stText, TObject item)
        {
            Items.Add(new ListPair<TObject>(item, stText));
        }

        // We get the Item collection from the derived class
        // It would probably be better to just be in the base class, but having a generic class seems
        // to confuse the designers.
        protected abstract ListBox ListBox
        {
            get;
        }
        protected ListBox.ObjectCollection Items
        {
            get { return this.ListBox.Items; }
        }

        // Get the Object for the currently selected Item.
        // May return null if no selected item, or if item does not have an object associated with it.
        protected TObject SelectedItem
        {
            get
            {

                object o = this.ListBox.SelectedItem;
                ListPair<TObject> pair = (ListPair<TObject>)o;
                if (pair == null)
                {
                    return null;
                }

                TObject f = pair.m_item;
                return f;
            }
        }

        // Helper for refresh.
        protected override void RefreshToolWindowInternal()
        {
            if (this.CurrentProcess == null)
            {
                Items.Clear();
                AddItem(this.m_stUnavailable, null);
            }
            else
            {
                this.RefreshWhenStopped();
            }
        }

        // Let derived classes handle.
        // Guaranteed to have a process and be stopped.
        public abstract void RefreshWhenStopped();

        // Derived tool windows can call this if they make some change that requires refreshing everything
        // (Such as changing the active thread / frame).
        protected void RefreshMainWindow()
        {
            // Need to refresh UI to show update.
            this.MainForm.ShowCurrentLocation();
            this.MainForm.Invalidate();
        }

    } // end DebuggerListWindow


    //-----------------------------------------------------------------------------
    // Utility functions.
    //-----------------------------------------------------------------------------
    class Util
    {
        #region Print MDbgValue to TreeView

        //-----------------------------------------------------------------------------
        // Print the value to the treeview
        // This will clear out the TreeView and repopulate it with the Value.
        //-----------------------------------------------------------------------------
        static public void Print(MDbgValue val, TreeView t)
        {
            t.BeginUpdate();

            t.Nodes.Clear();

            if (val == null)
            {
                t.Nodes.Add("(Error:Expression not valid in this scope)");
            }
            else
            {
                PrintInternal(val, t.Nodes, 0);
            }

            t.EndUpdate();
        }

        //-----------------------------------------------------------------------------
        // Recursive helper to populate tree view.
        // val - value to print
        // c - node collection to add to.
        // iDepth - track how far we are to avoid infinite recursion.
        //-----------------------------------------------------------------------------
        static public void PrintInternal(MDbgValue val, TreeNodeCollection c, int iDepth)
        {
            if (iDepth > 10)
            {
                return;
            }

            string name = val.Name;

            try
            {
                if (val.IsArrayType)
                {
                    TreeNode n = new TreeNode(name + " (type='" + val.TypeName + "') array:");
                    foreach (MDbgValue vField in val.GetArrayItems())
                    {
                        PrintInternal(vField, n.Nodes, iDepth + 1);
                    }
                    c.Add(n);
                }
                else if (val.IsComplexType)
                {
                    // This will include both instance and static fields
                    // It will also include all base class fields.
                    TreeNode n = new TreeNode(name + " (type='" + val.TypeName + "') fields:");
                    foreach (MDbgValue vField in val.GetFields())
                    {
                        PrintInternal(vField, n.Nodes, iDepth + 1);
                    }
                    c.Add(n);
                }
                else
                {
                    // This is a ctach-call for primitives.
                    string stValue = val.GetStringValue(false);
                    c.Add(name + " (type='" + val.TypeName + "') value=" + stValue);

                }

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // Inspecting the vars may fail at the ICorDebug level.
                c.Add(name + "= <unavailable>");
            }

        }

        #endregion Print MDbgValue to TreeView
    }

} // namespace Gui