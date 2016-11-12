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
using System.Diagnostics;
using System.Threading;
using System.Text;


using Microsoft.Samples.Tools.Mdbg;
using Microsoft.Samples.Debugging.MdbgEngine;  

namespace Microsoft.Samples.Tools.Mdbg.Extension
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form,IMDbgIO
    {
        private IContainer components;

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem QuitUICmd;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem windowsTileCmd;
        private System.Windows.Forms.MenuItem windowCascadeCmd;
        private System.Windows.Forms.MenuItem testNewCmd;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox cmdInput;
        private System.Windows.Forms.RichTextBox cmdHistory;
        private System.Windows.Forms.MenuItem AboutCmd;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuItem menuItem2;
        private MenuItem menuItemView;
        private MenuItem menuItemViewOpen;
        private MenuItem menuItemViewClose;
        private MenuItem menuItem7;
        private MenuItem menuItemCommands;
        private MenuItem menuItemLaunch;
        private MenuItem menuItem6;
        private MenuItem menuItemAttach;
        private MenuItem menuItemDetach;
        private MenuItem menuItemKill;
        private System.Windows.Forms.MenuItem breakCmd;

        public MainForm(IMDbgShell ui)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Debug.Assert(ui!=null);
            m_ui = ui;
            
            cmdHistory.Text=" ";
            SourceViewerForm.ClearSourceFiles();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.testNewCmd = new System.Windows.Forms.MenuItem();
            this.QuitUICmd = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.breakCmd = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemViewOpen = new System.Windows.Forms.MenuItem();
            this.menuItemViewClose = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.windowsTileCmd = new System.Windows.Forms.MenuItem();
            this.windowCascadeCmd = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.AboutCmd = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdHistory = new System.Windows.Forms.RichTextBox();
            this.cmdInput = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuItemCommands = new System.Windows.Forms.MenuItem();
            this.menuItemLaunch = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemAttach = new System.Windows.Forms.MenuItem();
            this.menuItemDetach = new System.Windows.Forms.MenuItem();
            this.menuItemKill = new System.Windows.Forms.MenuItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
// 
// mainMenu1
// 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItemView,
            this.menuItem5,
            this.menuItem3});
            this.mainMenu1.Name = "mainMenu1";
// 
// menuItem1
// 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.testNewCmd,
            this.QuitUICmd});
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Text = "&File";
// 
// testNewCmd
// 
            this.testNewCmd.Index = 0;
            this.testNewCmd.Name = "testNewCmd";
            this.testNewCmd.Text = "&Open Source ...";
            this.testNewCmd.Click += new System.EventHandler(this.testNewCmd_Click);
// 
// QuitUICmd
// 
            this.QuitUICmd.Index = 1;
            this.QuitUICmd.Name = "QuitUICmd";
            this.QuitUICmd.Text = "&Quit";
            this.QuitUICmd.Click += new System.EventHandler(this.QuitUICmd_Click);
// 
// menuItem2
// 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.breakCmd,
            this.menuItem6,
            this.menuItemLaunch,
            this.menuItemAttach,
            this.menuItemDetach,
            this.menuItemKill});
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Text = "&Debug";
// 
// breakCmd
// 
            this.breakCmd.Index = 0;
            this.breakCmd.Name = "breakCmd";
            this.breakCmd.Text = "&Break";
            this.breakCmd.Click += new System.EventHandler(this.breakCmd_Click);
// 
// menuItemView
// 
            this.menuItemView.Index = 2;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemViewOpen,
            this.menuItemViewClose,
            this.menuItem7});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Text = "View";
            this.menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
// 
// menuItemViewOpen
// 
            this.menuItemViewOpen.Index = 0;
            this.menuItemViewOpen.Name = "menuItemViewOpen";
            this.menuItemViewOpen.Text = "Open &All";
            this.menuItemViewOpen.Click += new System.EventHandler(this.menuItemViewOpen_Click);
// 
// menuItemViewClose
// 
            this.menuItemViewClose.Index = 1;
            this.menuItemViewClose.Name = "menuItemViewClose";
            this.menuItemViewClose.Text = "Close All";
            this.menuItemViewClose.Click += new System.EventHandler(this.menuItemViewClose_Click);
// 
// menuItem7
// 
            this.menuItem7.Index = 2;
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Text = "-";
// 
// menuItem5
// 
            this.menuItem5.Index = 3;
            this.menuItem5.MdiList = true;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.windowsTileCmd,
            this.windowCascadeCmd});
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Text = "&Window";
// 
// windowsTileCmd
// 
            this.windowsTileCmd.Index = 0;
            this.windowsTileCmd.Name = "windowsTileCmd";
            this.windowsTileCmd.Text = "&Tile";
// 
// windowCascadeCmd
// 
            this.windowCascadeCmd.Index = 1;
            this.windowCascadeCmd.Name = "windowCascadeCmd";
            this.windowCascadeCmd.Text = "&Cascade";
// 
// menuItem3
// 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCommands,
            this.AboutCmd});
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Text = "&Help";
// 
// AboutCmd
// 
            this.AboutCmd.Index = 1;
            this.AboutCmd.Name = "AboutCmd";
            this.AboutCmd.Text = "About...";
            this.AboutCmd.Click += new System.EventHandler(this.AboutCmd_Click);
// 
// statusBar1
// 
            this.statusBar1.Location = new System.Drawing.Point(0, 411);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(568, 22);
            this.statusBar1.TabIndex = 3;
// 
// panel1
// 
            this.panel1.Controls.Add(this.cmdHistory);
            this.panel1.Controls.Add(this.cmdInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 195);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panel1.Size = new System.Drawing.Size(568, 216);
            this.panel1.TabIndex = 4;
// 
// cmdHistory
// 
            this.cmdHistory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdHistory.Location = new System.Drawing.Point(10, 10);
            this.cmdHistory.Name = "cmdHistory";
            this.cmdHistory.ReadOnly = true;
            this.cmdHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.cmdHistory.Size = new System.Drawing.Size(548, 186);
            this.cmdHistory.TabIndex = 9;
            this.cmdHistory.TabStop = false;
            this.cmdHistory.Text = "";
// 
// cmdInput
// 
            this.cmdInput.AcceptsReturn = true;
            this.cmdInput.AcceptsTab = true;
            this.cmdInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdInput.Location = new System.Drawing.Point(10, 196);
            this.cmdInput.Name = "cmdInput";
            this.cmdInput.Size = new System.Drawing.Size(548, 20);
            this.cmdInput.TabIndex = 8;
            this.cmdInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdInput_KeyDown);
            this.cmdInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmdInput_KeyPress);
// 
// splitter1
// 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 189);
            this.splitter1.Name = "splitter1";
            this.splitter1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitter1.Size = new System.Drawing.Size(568, 6);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
// 
// menuItemCommands
// 
            this.menuItemCommands.Index = 0;
            this.menuItemCommands.Name = "menuItemCommands";
            this.menuItemCommands.Text = "Commands";
            this.menuItemCommands.Click += new System.EventHandler(this.menuItemCommands_Click);
// 
// menuItemLaunch
// 
            this.menuItemLaunch.Index = 2;
            this.menuItemLaunch.Name = "menuItemLaunch";
            this.menuItemLaunch.Text = "Launch ...";
            this.menuItemLaunch.Click += new System.EventHandler(this.menuItemLaunch_Click);
// 
// menuItem6
// 
            this.menuItem6.Index = 1;
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Text = "-";
// 
// menuItemAttach
// 
            this.menuItemAttach.Index = 3;
            this.menuItemAttach.Name = "menuItemAttach";
            this.menuItemAttach.Text = "Attach ...";
            this.menuItemAttach.Click += new System.EventHandler(this.menuItemAttach_Click);
// 
// menuItemDetach
// 
            this.menuItemDetach.Index = 4;
            this.menuItemDetach.Name = "menuItemDetach";
            this.menuItemDetach.Text = "Detach";
            this.menuItemDetach.Click += new System.EventHandler(this.menuItemDetach_Click);
// 
// menuItemKill
// 
            this.menuItemKill.Index = 5;
            this.menuItemKill.Name = "menuItemKill";
            this.menuItemKill.Text = "Kill";
            this.menuItemKill.Click += new System.EventHandler(this.menuItemKill_Click);
// 
// MainForm
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 433);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "GUI: Simple MDbg Extension";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        //#endregion

        // Set title for main form.
        // This also displays key status.
        // The mainform is an MDI window, source viewers are the children windows. WinForms will
        // automatically append the parent window (us) with the active MDI child.
        void SetTitle(bool fStopped)
        {
            string stState = "";
            if (GuiExtension.Shell.Debugger.Processes.HaveActive)
            {
                if (!fStopped)
                {
                    stState = "(RUNNING) ";
                }
                else 
                {
                    stState = "(STOPPED) ";
                }
            }

            this.Text = stState + "GUI: Simple MDbg Extension";
        }

        private class HistoryList
        {
            public HistoryList(int size)
            {
                Debug.Assert(size>1);
                m_historySize = size;
                m_history = new string[m_historySize];
                m_currPointer = 0;
                m_historyPointer = 0;
            }

            public void Add(string text)
            {
                Debug.Assert(text!=null);
                m_currPointer = NextPosition(m_currPointer,1);
                m_history[m_currPointer]=text;
                m_historyPointer=0;
            }

            public string GetPreviousText()
            {
                string res = m_history[NextPosition(m_currPointer,-m_historyPointer)];
                if(res!=null)
                    m_historyPointer = NextPosition(m_historyPointer,+1);
                return res;
            }

            public string GetNextText()
            {
                string res=null;
                if(m_historyPointer>0)
                {
                    m_historyPointer--;
                    res = m_history[NextPosition(m_currPointer,-m_historyPointer)];
                    Debug.Assert(res!=null);
                }
                return res;
            }

            private int NextPosition(int counter,int add)
            {
                
                int r = (counter+add)%m_historySize;
                if(r<0)
                    r+=m_historySize;
                
                Debug.Assert(r>=0 && r<m_historySize);
                return r;
            }

            private string[] m_history;
            private int m_historySize;
            private int m_currPointer;
            private int m_historyPointer;
        }

        HistoryList m_historyList = new HistoryList(15);

        // Trap input to the command window so that we can keep the GUI updated.
        private void cmdInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                e.Handled=true;
                m_historyList.Add(cmdInput.Text);
                ProcessEnteredText(cmdInput.Text);
                cmdInput.Text="";
            }
        }

        private void cmdInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string historyText = null;
            switch(e.KeyCode)
            {
            case Keys.Up:
                historyText = m_historyList.GetPreviousText();
                break;
            case Keys.Down:
                historyText = m_historyList.GetNextText();
                break;
            default:
                return;
            }
            e.Handled=true;
            if(historyText!=null)
                cmdInput.Text=historyText;

        }


        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.KeyPreview = true;
            Activate();


            this.InitHelperWindows();
        }
        
        private void MainForm_Activated(object sender, System.EventArgs e)
        {
            if(m_savedIO!=null) 
                return;         //this needs to be executed only when we initialize the form first time.
            
            Debug.Assert(m_savedIO==null);
            m_savedIO = m_ui.IO;
            Debug.Assert(m_savedIO!=null);
            m_ui.IO=this;
            
            m_initComplete.Set();
        }

        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
            case Keys.F5:
                ProcessEnteredText("go");
                break;
            case Keys.F10:
                ProcessEnteredText("next");
                break;
            case Keys.F11:
                if (e.Shift)
                {
                    ProcessEnteredText("out");
                }
                else
                {
                    ProcessEnteredText("step");
                }
                break;
            default:
                return;
            }

            
            e.Handled=true;
        }

        private void AboutCmd_Click(object sender, System.EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void testNewCmd_Click(object sender, System.EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog(this);
            if(res == DialogResult.OK)
            {
                SourceViewerForm.GetSourceFile(this,openFileDialog.FileName);
            }   
        }

        private void QuitUICmd_Click(object sender, System.EventArgs e)
        {
            Visible=false;
        }

        private void breakCmd_Click(object sender, System.EventArgs e)
        {
            DoBreak();
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try 
            {
                CloseGui();
            } 
            catch(Exception ex)
            {
                MessageBoxOptions mbo = new MessageBoxOptions();
                if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                    mbo = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                MessageBox.Show(this,ex.Message,null,MessageBoxButtons.OK,MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1, mbo);
                e.Cancel = true;
                return;
            }
        }

        // CloseGui closes GUI and returns control back to the shell
        public void CloseGui()
        {
            if (m_ui.IO != this)
            {
                throw new Exception("Cannot close GUI. IO stream has changed. ");
            }

            m_ui.IO=m_savedIO;
            
            // we need to kick-off input-loop (RunInputLoop) from blocking ReadCommand call.
            // so the trick is we issue a replace IO and issue harmless command "echo" which will
            // just print a message to new IO.
            m_cmdTxt = "echo GUI closed";
            m_inputEvent.Set();
        }


        #region Debugger Helper Windows
        // Open all helper windows.
        private void menuItemViewOpen_Click(object sender, EventArgs e)
        {
            foreach (HelperWindowMenuItem i in this.m_HelperWindows)
            {
                i.Show();
            }
        }

        // Close all helper windows.
        private void menuItemViewClose_Click(object sender, EventArgs e)
        {
            foreach (HelperWindowMenuItem i in this.m_HelperWindows)
            {
                Form f = i.CurrentForm;
                if (f != null)
                {
                    f.Close();
                }
            }
        }

        // Initial all the helper windows (eg, the various debugging windows like callstack, module-list, thread-list, etc
        // that help us inspect the process).
        // This will also populate the MainForm's "View" menu.
        void InitHelperWindows()
        {
            // ViewMenu already contains OpenAll + CloseAll entries.
            // Now we add the menu items for the actual tool windows.

            this.m_HelperWindows = new HelperWindowMenuItem[] {
                new HelperWindowMenuItem(this, "&Callstack", typeof(gui.Callstack)),
                new HelperWindowMenuItem(this, "&Locals",    typeof(gui.AutoWatchWindow)),
                new HelperWindowMenuItem(this, "&Modules",   typeof(gui.ModuleWindow)),
                new HelperWindowMenuItem(this, "&Threads",   typeof(gui.ThreadWindow)),
                new HelperWindowMenuItem(this, "&QuickWatch",typeof(gui.QuickViewWindow))
            };
        }

        // Refresh all live helper windows.
        void RefreshHelperWindows()
        {
            foreach (HelperWindowMenuItem item in this.m_HelperWindows)
            {
                gui.DebuggerToolWindow w = item.CurrentForm;
                if (w != null)
                {
                    w.RefreshToolWindow();
                }
            } // foreach
        }

        // List of all possible helper windows. This includes both active + inactive helper windows.
        HelperWindowMenuItem[] m_HelperWindows;

        // Add a menuitem to the view menu. This lets helper windows register on the "View" menu.
        public void AddToViewMenu(MenuItem item)
        {
            this.menuItemView.MenuItems.Add(item);
        }

        // Helper class for menu items for helper windows.
        // This contains the View Menu Item's OnClick handler and associates it to 
        // a helper window type. This contains enough information to create new instances of helper
        // windows (in case the old instance get closed)
        class HelperWindowMenuItem
        {
            // We pass in a type of the form to create rather than encode it as a generic parameter
            // so that we can have an array of the HelperWindowMenuItem.
            public HelperWindowMenuItem(MainForm mainForm, string name, System.Type tForm)
            {
                Debug.Assert(tForm.IsSubclassOf(typeof(gui.DebuggerToolWindow)));
                this.m_mainForm = mainForm;
                this.m_typeHelperForm = tForm;

                EventHandler handler = new EventHandler(this.OnClick);
                MenuItem item = new MenuItem(name, handler);
                this.m_mainForm.AddToViewMenu(item);
            }

            // Handler for when menu item is clicked
            void OnClick(object sender, EventArgs e)
            {
                Show();
            }

            public void Show()
            {
                // If they closed the window, create a new instance of it..
                if ((m_helperForm == null) || m_helperForm.IsDisposed)
                {
                    CreateNewForm();
                }
                // Show as a *modeless* dialog. This means this call will return immediately
                // and the helper dialog will be open as a separate window.
                m_helperForm.Show();
                m_helperForm.Activate();
                m_helperForm.RefreshToolWindow();

            }

            void CreateNewForm()
            {
                // Generics (via the new() constraint) only lets us invoke a default ctor.
                m_helperForm = (gui.DebuggerToolWindow)System.Activator.CreateInstance(this.m_typeHelperForm, new object[] { m_mainForm });
            }

            MainForm m_mainForm;

            // Type of helper to create. If the helper window gets closed, this lets us recreate it.
            System.Type m_typeHelperForm;

            // Dialog for this menu item.
            gui.DebuggerToolWindow m_helperForm;

            // Get current instantation of a form. This may be null if the form is closed.
            // This instance may get recycled.
            public gui.DebuggerToolWindow CurrentForm
            {
                get
                {
                    if (m_helperForm == null) return null;
                    if (m_helperForm.IsDisposed) return null;
                    return m_helperForm;
                }
            }
        } // end HelperWindowMenuItem

        #endregion Debugger Helper Windows


        #region Plumbing For Input / Output
        //-----------------------------------------------------------------------------
        // This contains plumbing to connect the MDbg Shell Input + Output streams
        // to the Gui. This is done by having the GUI implement the IMDbgIO interface.
        // The GUI also ensures that operations occur on the thread that owns the 
        // underlying handle for the main window.
        //-----------------------------------------------------------------------------

        #region Plumbing for Input

        //////////////////////////////////////////////////////////////////////////////////
        //
        // Implementation part
        //
        //////////////////////////////////////////////////////////////////////////////////


        // We have 2 threads that need to access MDbg objects.
        // 1) UI thread - This is hte thread that all UI events come on. It's also
        //                the only thread that can update any portion of the UI.
        //                It must never block else the UI will hang.
        //                This will access Mdbg objects to update the UI.
        // 2) Command Thread - this issues the debugging commands, since the GUI 
        //                is built on top of a command line shell.
        //
        // While ICorDebug is thread-safe, the MDbg objects built on top of them are not.
        // So we need to coordinate access to the objects between both threads.
        // Iff ActiveProcess is set, then the UI thread can access Mdbg objects.
        // Else the UI thread should assume there is no process available (or it's running),
        // and not inspect any MDbg objects.
        // This is only set and read by the UI thread, and so it's thread-safe.
        MDbgProcess m_process;
        public MDbgProcess ActiveProcess
        {
            get
            {
                return m_process;
            }
        }

        // Implements IMDbgIO.
        // Put the GUI in "input" mode and block waiting for a command to be entered.
        // This gets called by the MDbg main loop.
        // This is on the Command-thread.
        bool IMDbgIO.ReadCommand(out string cmdTxt)
        {            
            // Update the UI to let it know that we're ready for input.
            Invoke(new MethodInvoker(PreReadCommand));

            // Now actually wait until a command is entered.
            // This is set by either:
            // - the UI sends the MDbg engine commands (via ProcessEnteredText)
            //     this may come from UI elements (such as menu commands), or from edit input control.
            //     representing the console.
            // - closing the GUI 
            m_inputEvent.WaitOne();

            // Returning from here will resume the Shell's message loop. It will then execute the command.
            cmdTxt = m_cmdTxt;
            return !(m_cmdTxt==null);
        }


        // This must be called on the thread that owns the MainForm control's underlying window handle. (UI Thread)
        // This will put the GUI in "Break" (aka Input) mode. 
        private void PreReadCommand()
        {
            try 
            {
                SetCommandInputState(true);
            } 
            catch(Exception e)
            {
                WriteOutput(MDbgOutputConstants.StdError,e.GetBaseException().Message);
            }
        }

        // Coordinates between the mdbg shell input and the gui.
        // This also let GUI components send string commands to the underlying shell.
        // This corresponds to ReadCommand.  ReadCommand will block waiting for a command
        // to be entered here.
        //
        // This must be called on the UI thread.
        //
        // This call WILL NOT BLOCK waiting for the command to execute. 
        // Thus do not assume the command has executed when we return.        
        // Ideally, this should be the last thing a UI thread calls in an event handler.         
        //         
        // When the command completes, the command thread will reping the UI to update.
        public void ProcessEnteredText(string input)
        {
            // @todo - this doesn't queue. But the UI could send multiple requests here
            // which would trash the input with just the latest request.
            m_cmdTxt = input;
            WriteOutput(MDbgOutputConstants.StdOutput, input);

            // Tell the UI that we're about to start running.
            SetCommandInputState(false);

            // The MDbg main loop's ReadCommand is waiting on this event.
            m_inputEvent.Set();
        }

        #endregion Plumbing for Input

        #region Plumbing for Output

        //////////////////////////////////////////////////////////////////////////////////
        //
        // Input Output Functions
        //
        //////////////////////////////////////////////////////////////////////////////////


        private void WritePrompt()
        {
            string s;

            try
            {
                s = "[t#:" + GuiExtension.Shell.Debugger.Processes.Active.Threads.Active.Number + "] ";
            }
            catch (MDbgException)
            {
                s = "";
            }
            WriteOutputNoNewLine(MDbgOutputConstants.StdOutput, s + TEXT_PROMPT_STRING);
        }

        private void WriteOutputNoNewLine(string outputType, string txt)
        {
            // we need to add (char)13(char)10 when '\n' occurs in text (this is richText box)
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt)
            {
                if (c == '\n')
                    sb.Append((char)13).Append((char)10);
                else
                    sb.Append(c);
            }
            SyncWriter sw = new SyncWriter(this, sb.ToString());

            Invoke(new MethodInvoker(sw.InternalWriteOutput));
        }

        // Implements IMDbgIO.
        // Writes output to the shell output window.
        public void WriteOutput(string outputType, string txt)
        {
            WriteOutputNoNewLine(outputType, txt + "\n");
        }

        // Helper class to ensure output gets called on correct thread.
        private class SyncWriter
        {
            public SyncWriter(MainForm form, string txt)
            {
                Debug.Assert(txt != null && form != null);
                m_txt = txt;
                m_form = form;
            }

            // Must be called on the thread that owns the main window's underlying window handle.
            public void InternalWriteOutput()
            {
                m_form.cmdHistory.Focus(); // we need to focus, so the caret get set
                m_form.cmdHistory.AppendText(m_txt);
            }
            private string m_txt;
            private MainForm m_form;
        }

        #endregion Plumbing for Output

        #endregion Plumbing For Input / Output

        // Set whether the GUI is in "Run-mode" or "Break-mode"
        // OnOff = true if we're stopping; false if we're going to start running
        // This must be called on the UI thread.
        // This will also set the ActiveProcess property so that other events on the 
        // UI thread can see if it's safe to access Mdbg objects.
        private void SetCommandInputState(bool OnOff)
        {
            // Enable / disable UI elements.
            cmdInput.Enabled = OnOff;
            breakCmd.Enabled=!OnOff;

            // Although the underlying MDbg engine supports multiple processes,
            // We'll only support 1 process from the UI to keep things simple.             
            bool fHasProcess = GuiExtension.Debugger.Processes.HaveActive;

            // If we're stopped, and we don't already have a process, then allow creating one.
            bool fAllowCreate = OnOff && !fHasProcess;
            menuItemLaunch.Enabled = fAllowCreate;
            menuItemAttach.Enabled = fAllowCreate;

            // If we're stopped, and we do have a process, allow killing it.
            bool fAllowKill = OnOff && fHasProcess;
            menuItemDetach.Enabled = fAllowKill;
            menuItemKill.Enabled = fAllowKill;

           
            SetTitle(OnOff);

            if(OnOff)
            {
                // Enter "Break" Mode
                if (fHasProcess)
                {
                    m_process = GuiExtension.Debugger.Processes.Active;
                }
                else
                {
                    m_process = null;
                }

                Activate();                                 // bring GUI up when we e.g. hit breakpoint 
                this.Cursor = Cursors.Default;

                ShowCurrentLocation(); // calculate current source location.
                SourceViewerForm.OnBreak();

                WritePrompt();
                cmdInput.Focus();
            }
            else
            {
                m_process = null;
                
                // Enter "Run" mode
                m_CurrentSourcePosition = null;
                SourceViewerForm.OnRun();

                this.Cursor = Cursors.AppStarting;
            }            
        }


        #region Tracking Current Source Position
        // Track the current source location for the currently selected frame.  
        // This may or may-not be the leafmost frame. (IsCurrentSourceActive tracks this)
        // Null if we don't have one (such as if we're stopped in place without any symbols or running).
        public MDbgSourcePosition CurrentSource
        {
            get { return m_CurrentSourcePosition; }
        }

        // Returns true if CurrentSource property represents source at the leafmost (active) frame.
        // This parameter is meaningless is CurrentSource is null.
        public bool IsCurrentSourceActive
        {
            get { return m_fCurrentIsActive; }
        }

        bool m_fCurrentIsActive;
        MDbgSourcePosition m_CurrentSourcePosition;

        #endregion Tracking Current Source Position

        // Update windows (source, callstack,etc) to show our current source location.
        // This must be called on the UI thread.
        public void ShowCurrentLocation()
        {
            m_CurrentSourcePosition = null;

            // Update tool windows. If we don't have an active process / threads, they'll update accordingly.
            RefreshHelperWindows();

            MDbgProcess proc = this.ActiveProcess;

            if((proc != null)
               && GuiExtension.Shell.Debugger.Processes.Active.Threads.HaveActive)
            {
                // Show source file.
                MDbgThreadCollection tc = proc.Threads;
                MDbgThread thread = tc.Active;
                if (!thread.HaveCurrentFrame)
                {
                    WriteOutput(MDbgOutputConstants.StdError, "No source for current thread #" + thread.Number);
                    return;
                }

                // Looks like a bug in MDbg where Thread's aren't getting refreshed. 
                // Thus APIs fail with CORDBG_E_OBJECT_NEUTERED. So we forcifully
                // refresh them.
                {
                    // @todo - RefreshStack() will reset the frame to the bottom most.                    
                    //MDbgFrame fOld = thread.CurrentFrame;
                    //tc.RefreshStack();
                    //thread.CurrentFrame = fOld;
                }

                MDbgFrame fCurrent = thread.CurrentFrame;

                MDbgSourcePosition pos = fCurrent.SourcePosition;

                bool fActive = (fCurrent == thread.BottomFrame);

                // Update current cached location
                m_CurrentSourcePosition = pos;
                this.m_fCurrentIsActive = fActive;

                // Try to display source.
                bool fOk = false;
                if (pos != null)
                {
                    fOk = OpenSourceFile(pos.Path);
                }

                // Must always refresh the existing source forms. Even if we don't have a current source form,
                // we'll need to let our previous source know that it's lost focus.
                SourceViewerForm.OnBreak();
                if (fOk)
                {
                    return;
                }

                if (pos != null)
                {
                    WriteOutput(MDbgOutputConstants.StdError, "Cannot display position in file: " + pos.Path);
                }
                else
                {
                    WriteOutput(MDbgOutputConstants.StdError, "No source for current frame: " + fCurrent.ToString());
                }


            }

            //SourceViewerForm.ClearCurrentSelection();
        }

        // this is called on the UI thread.
        bool OpenSourceFile(string fname)
        {
            // Update source viewer
            SourceViewerForm f = SourceViewerForm.GetSourceFile(this, fname);

            if (f == null)
            {
                return false;
            }


            f.Focus();
            cmdInput.Focus();
            return true;
        }


        // Do an Async Break.
        // This is used to asynchronously get the program from a Run state to a stopped state.
        private void DoBreak()
        {
            try 
            {
                GuiExtension.Shell.Debugger.Processes.Active.AsyncStop().WaitOne();
            }
            catch(Exception e)
            {
                WriteOutput(MDbgOutputConstants.StdError,e.Message);
            }
        }
       

        public AutoResetEvent InitComplete
        {
            get
            {
                return m_initComplete;
            }
        }
        
        const string TEXT_ERROR="Error: ";
        const string TEXT_PROMPT_STRING="mdbg> ";

        // Event used to block the shell waiting for input
        private AutoResetEvent m_inputEvent = new AutoResetEvent(false);

        private AutoResetEvent m_initComplete = new AutoResetEvent(false);
        private string m_cmdTxt;

        // The GUI form implements IMDbgIO. It will redirect the Shell's IO interface to the GUI.
        // We remeber the old IO instance so that we can restore it once the GUI gets closed.
        private IMDbgIO m_savedIO;

        // Hold onto the underlying shell object so that we can redirect some of its subojects (like the IMdbgIO)
        // to the GUI.
        private IMDbgShell m_ui;

        private void menuItemView_Click(object sender, EventArgs e)
        {
        
        }

        private void menuItemCommands_Click(object sender, EventArgs e)
        {
            this.ProcessEnteredText("help");
        }

        // Prompt the user to stop debugging (via the given Mdbg command).
        // This is shared by detach + kill commands.
        // Returns True if it stops debugging the current process, else false.
        private bool StopDebugging(string command, string desc)
        {
            if (this.ActiveProcess == null)
            {
                // Nothing to do. Not sure how we'd ever get here because the 
                // UI should have disabled us, but just in case ...
                return false; 
            }

            // Kill the current process.
            string caption = "Stop debugging ('" + command + "')?";
            string text = "Do you want to " + desc +" and stop debugging?";
            DialogResult x = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                // This will execute the command asynchronously on another thread.
                this.ProcessEnteredText(command);
            }

            return false;
        }

        private void menuItemKill_Click(object sender, EventArgs e)
        {
            StopDebugging("kill", "terminate the debuggee");
        }

        private void menuItemDetach_Click(object sender, EventArgs e)
        {
            StopDebugging("detach", "detach from the debuggee");
        }

        // Kick off menu to launch a process.
        private void menuItemLaunch_Click(object sender, EventArgs e)
        {
            if (GuiExtension.Debugger.Processes.HaveActive)
            {
                // Nothing to do. Not sure how we'd ever get here because the 
                // UI shoul dhave disabled us, but just in case ...
                return;
            }

            gui.LaunchProcess form = new gui.LaunchProcess();
            form.ShowDialog();

            // If null, then they cancelled.
            if (form.ProcessName == null)
            {
                return;
            }

            System.IO.Directory.SetCurrentDirectory(form.WorkingDir);
            string cmd = "run " + form.ProcessName + " " + form.Arguments;

            // We want console apps to have their own console.
            this.ProcessEnteredText("mo nc on");

            // Run the app.
            this.ProcessEnteredText(cmd);
        }

        private void menuItemAttach_Click(object sender, EventArgs e)
        {
            if (GuiExtension.Debugger.Processes.HaveActive)
            {
                // Nothing to do. Not sure how we'd ever get here because the 
                // UI shoul dhave disabled us, but just in case ...
                return;
            }

            gui.AttachProcess form = new gui.AttachProcess();
            form.ShowDialog();
            int pid = form.SelectedPid;

            if (pid == 0)
            {
                return;
            }

            string cmd = "attach " + pid;

            // Run the app.
            this.ProcessEnteredText(cmd);
        }

    } // end MainForm
}
