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
    // Tool window to evaluate simple expressions.
    partial class QuickViewWindow : DebuggerToolWindow
    {
        public QuickViewWindow(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
        }


        protected override void RefreshToolWindowInternal()
        {
            // Nothing to do in refresh since we only respond to 
            // the user entering a value.
        }

        // Trap "Enter" key on dialog input.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                string arg = this.textBox1.Text;
                MDbgValue val = Resolve(arg);
                Util.Print(val, this.treeView1);                
            }
        }

        // Resolve the expression to a value.
        // Returns "Null" if we can't resolve the arg.
        MDbgValue Resolve(string arg)
        {
            MDbgFrame frame = this.CurrentFrame;
            if (frame == null)
            {
                return null;
            }
            MDbgValue var = this.CurrentProcess.ResolveVariable(arg, frame);
           

            return var;
        }

        #region Print MDbgValue to TreeView

        //-----------------------------------------------------------------------------
        // Print the value to the treeview
        // This will clear out the TreeView and repopulate it with the Value.
        //-----------------------------------------------------------------------------
        void Print(MDbgValue val, TreeView t)
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
        void PrintInternal(MDbgValue val, TreeNodeCollection c, int iDepth)
        {
            if (iDepth > 10)
            {
                return;
            }

            if (val.IsArrayType)
            {                
                TreeNode n = new TreeNode(val.TypeName + " array:");
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
                TreeNode n = new TreeNode(val.TypeName + " fields:");
                foreach (MDbgValue vField in val.GetFields())
                {                    
                    PrintInternal(vField, n.Nodes, iDepth + 1);
                }
                c.Add(n);
            }
            else
            {
                // This is a ctach-call for primitives.
                string st = val.GetStringValue(false);
                c.Add(val.Name + "=" + st + " (type='" + val.TypeName + "')");

            }
        }

        #endregion Print MDbgValue to TreeView

    }      // end QuickViewWindow
}