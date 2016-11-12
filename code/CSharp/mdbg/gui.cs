//---------------------------------------------------------------------
//  This file is part of the CLR Managed Debugger (mdbg) Sample.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//---------------------------------------------------------------------
using System;
using Microsoft.Samples.Tools.Mdbg;
using Microsoft.Samples.Debugging.MdbgEngine;
using System.Threading;
using System.Windows.Forms;
using System.Security.Permissions;

[assembly:CLSCompliant(true)]
[assembly:System.Runtime.InteropServices.ComVisible(false)]
[assembly:SecurityPermission(SecurityAction.RequestMinimum, Unrestricted=true)]

namespace Microsoft.Samples.Tools.Mdbg.Extension
{
    public abstract class GuiExtension : CommandBase
    {
        public static void LoadExtension()
        {
            try 
            {
                MDbgAttributeDefinedCommand.AddCommandsFromType(Shell.Commands,typeof(GuiExtension));
            } 
            catch
            {
                // we'll ignore errors about multiple defined gui command in case gui is loaded
                // multiple times.
            }

            // and also load gui directly.
            Gui("");
        }
        
        [
         CommandDescription(
           CommandName="gui",
           ShortHelp="gui [close] - starts/closes a gui interface",
           LongHelp=
             "Usage: gui [close]"
         )
        ]
        public static void Gui(string args)
        {
            // just do the check that gui is not already loaded,
            // strange things are happening else:
            ArgParser ap = new ArgParser(args);
            if( ap.Exists(0) )
            {
                if( ap.AsString(0) == "close" )
                {
                    if( m_mainForm!=null )
                    {
                        m_mainForm.CloseGui();
                        Application.Exit(); // this line will cause the message pump on other thread to quit.
                        return;
                    }
                    else
                        throw new MDbgShellException("GUI not started.");
                }
                else
                    throw new MDbgShellException("invalid argument");
            }
            
            if(Shell.IO == m_mainForm)
            {
                WriteOutput("GUI already started. Cannot start second instance.");
                return;
            }

            WriteOutput("starting gui");

            m_mainForm = new MainForm(Shell);

            Thread t = new Thread(new ThreadStart(RunMessageLoop));

            // Only MTA Threads can access CorDebug interfaces because mscordbi doesn't provide marshalling to make them accessable from STA Threads
            t.SetApartmentState(ApartmentState.MTA);
            t.IsBackground = true;

            t.Start();
            m_mainForm.InitComplete.WaitOne(); // wait till form is fully displayed.
            
            WriteOutput("GUI: Simple Extension for Managed debugger (Mdbg) started");
            WriteOutput("\nfor information on how to use the extension select in menu bar help->Info\n");
        }

        public static void RunMessageLoop()
        {
            // if we have following code here and close the dialog the we cannot break into debugger.
            //m_mainForm.Show();
            //Application.Run(m_mainForm);//new ApplicationContext(m_mainForm));
            m_mainForm.ShowDialog();
        }
        private static MainForm m_mainForm;
    }
}

        
