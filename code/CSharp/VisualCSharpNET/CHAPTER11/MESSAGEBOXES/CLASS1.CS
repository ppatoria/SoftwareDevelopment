using System;
using System.Windows.Forms;
namespace MessageBoxes
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class MessageBoxDemo
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            // The most basic message box.
            MessageBox.Show("A simple message box");

            // A message box with a caption.
            MessageBox.Show("A simple message box", "MessageBox demo");

            // A message box with some buttons for user input.
            DialogResult result = MessageBox.Show("A message box with 3 buttons",
                                                  "MessageBox demo",
                                                  MessageBoxButtons.YesNoCancel);
            string message = "Nothing";
            switch(result)
            {
                case DialogResult.Yes:
                    message = "Yes";
                    break;

                case DialogResult.No:
                    message = "No";
                    break;

                case DialogResult.Cancel:
                    message = "Cancel";
                    break;

                default:
                    message = "Unknown";
                    break;
            }
            MessageBox.Show("You clicked " + message + ".");

            // A message box with an icon
            DialogResult result1 = MessageBox.Show("A message box with an icon",
                                                  "MessageBox demo",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Asterisk);
            switch(result1)
            {
                case DialogResult.Yes:
                    message = "Yes";
                    break;

                case DialogResult.No:
                    message = "No";
                    break;

                case DialogResult.Cancel:
                    message = "Cancel";
                    break;

                default:
                    message = "Unknown";
                    break;
            } 
            MessageBox.Show("You clicked " + message + ".");

            // A message box with a specific default button.
            DialogResult res = MessageBox.Show("The default button is Ignore",
                                               "MessageBox demo",
                                               MessageBoxButtons.AbortRetryIgnore,
                                               MessageBoxIcon.Asterisk,
                                               MessageBoxDefaultButton.Button3);
            switch(res)
            {
                case DialogResult.Abort:
                    message = "Abort";
                    break;

                case DialogResult.Retry:
                    message = "Retry";
                    break;

                case DialogResult.Ignore:
                    message = "Ignore";
                    break;

                default:
                    message = "Unknown";
                    break;
            } 
            MessageBox.Show("You clicked " + message + ".");

            // A message box that will work if used in a Windows service.
            DialogResult res1 = MessageBox.Show("The service has not\nstarted\n.",
                                               "Service demo",
                                               MessageBoxButtons.AbortRetryIgnore,
                                               MessageBoxIcon.Exclamation,
                                               MessageBoxDefaultButton.Button3,
                                               MessageBoxOptions.RightAlign | 
                                               MessageBoxOptions.DefaultDesktopOnly);
            switch(res1)
            {
                case DialogResult.Abort:
                    message = "Abort";
                    break;

                case DialogResult.Retry:
                    message = "Retry";
                    break;

                case DialogResult.Ignore:
                    message = "Ignore";
                    break;

                default:
                    message = "Unknown";
                    break;
            } 
            MessageBox.Show("You clicked " + message + ".");


        }
	}
}
