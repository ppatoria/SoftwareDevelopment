using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppContext
{
    public class QueryApplicationContext: ApplicationContext
    {
        private string _saveMessage = "Exit and discard changes?";
        private string _caption = "Application Exit";

        public QueryApplicationContext(MainForm form)
        {
            form.Show();
            form.Closing += new CancelEventHandler(FormClosing);
        }

        private void FormClosing(object sender, CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show(_saveMessage,
                                                    _caption,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1);
            if(result == DialogResult.Yes)
            {
                ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
