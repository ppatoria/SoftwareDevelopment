using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MSPress.CSharpCoreRef.ContextMenuDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.MenuItem sortMenuItem;
        private System.Windows.Forms.MenuItem addMenuItem;
        private System.Windows.Forms.MenuItem removeMenuItem;
        private System.Windows.Forms.ContextMenu listBoxMenu;
        private System.Windows.Forms.MenuItem clearMenuItem;

        /// <summary>
        /// 
        /// </summary>
		public MainForm()
		{
			InitializeComponent();
        }
        private void hello_Click(object sender, EventArgs e){}
        private void goodbye_Click(object sender, EventArgs e){}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.listBox = new System.Windows.Forms.ListBox();
            this.listBoxMenu = new System.Windows.Forms.ContextMenu();
            this.sortMenuItem = new System.Windows.Forms.MenuItem();
            this.addMenuItem = new System.Windows.Forms.MenuItem();
            this.removeMenuItem = new System.Windows.Forms.MenuItem();
            this.clearMenuItem = new System.Windows.Forms.MenuItem();
            this.okButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.ContextMenu = this.listBoxMenu;
            this.listBox.Location = new System.Drawing.Point(16, 24);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(176, 160);
            this.listBox.TabIndex = 0;
            // 
            // listBoxMenu
            // 
            this.listBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                        this.sortMenuItem,
                                                                                        this.addMenuItem,
                                                                                        this.removeMenuItem,
                                                                                        this.clearMenuItem});
            this.listBoxMenu.Popup += new System.EventHandler(this.listBoxMenu_Popup);
            // 
            // sortMenuItem
            // 
            this.sortMenuItem.Index = 0;
            this.sortMenuItem.Text = "&Sort";
            this.sortMenuItem.Click += new System.EventHandler(this.sortMenuItem_Click);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Index = 1;
            this.addMenuItem.Text = "&Add...";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.Index = 2;
            this.removeMenuItem.Text = "&Remove";
            this.removeMenuItem.Click += new System.EventHandler(this.removeMenuItem_Click);
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Index = 3;
            this.clearMenuItem.Text = "&Clear All";
            this.clearMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(208, 24);
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(16, 200);
            this.addButton.Name = "addButton";
            this.addButton.TabIndex = 2;
            this.addButton.Text = "&Add...";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(16, 232);
            this.removeButton.Name = "removeButton";
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "&Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 278);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.removeButton,
                                                                          this.addButton,
                                                                          this.okButton,
                                                                          this.listBox});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Context Menu Demo";
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

        private void addButton_Click(object sender, System.EventArgs e)
        {
            AddItem();
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            RemoveItem(listBox.SelectedIndex);
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void sortMenuItem_Click(object sender, System.EventArgs e)
        {
            listBox.Sorted = !listBox.Sorted;
        }

        private void addMenuItem_Click(object sender, System.EventArgs e)
        {
            AddItem();
        }

        private void removeMenuItem_Click(object sender, System.EventArgs e)
        {
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private void clearMenuItem_Click(object sender, System.EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void listBoxMenu_Popup(object sender, System.EventArgs e)
        {
            sortMenuItem.Checked = listBox.Sorted;
            if(listBox.Items.Count == 0)
            {
                sortMenuItem.Enabled = false;
                removeMenuItem.Enabled = false;
                clearMenuItem.Enabled = false;
            }
            else
            {
                if(listBox.SelectedIndex == -1)
                    removeMenuItem.Enabled = false;
                else
                    removeMenuItem.Enabled = true;

                sortMenuItem.Enabled = true;
                clearMenuItem.Enabled = true;
            }
        }

        private void RemoveItem(int index)
        {
            if(listBox.Items.Count != 0)
            {
                if(index != -1)
                {
                    listBox.Items.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("You must select an item to remove",
                                    "Can't remove item",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("The list box is empty",
                                "Nothing to remove",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
            }
        }

        private void AddItem()
        {
            AddListBoxItemForm dlg = new AddListBoxItemForm();
            DialogResult result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                string newItem = dlg.NewItem;
                listBox.Items.Add(newItem);
            }
        }
	}
}
