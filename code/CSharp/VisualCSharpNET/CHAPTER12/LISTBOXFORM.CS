using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Diagnostics;

namespace MSPress.CSharpCoreRef.Controls
{
    class ListBoxItem
    {
        private string _name;
        public ListBoxItem(string name)
        {
            _name = name;
        }
        public string Name
        {
            get {return _name;}
            set {_name = value;}
        }
        public override string ToString()
        {
            return _name;
        }
    }
	/// <summary>
	/// Summary description for ListBoxForm.
	/// </summary>
	public class ListBoxForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button newItemButtonLeft;
        private System.Windows.Forms.Button newItemButtonRight;
        private System.Windows.Forms.Button removeItemButtonRight;
        private System.Windows.Forms.Button removeItemButtonLeft;
        private System.Windows.Forms.CheckBox removeCheckBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListBoxForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox = new System.Windows.Forms.ListBox();
			this.checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.CloseButton = new System.Windows.Forms.Button();
			this.newItemButtonLeft = new System.Windows.Forms.Button();
			this.newItemButtonRight = new System.Windows.Forms.Button();
			this.removeItemButtonRight = new System.Windows.Forms.Button();
			this.removeItemButtonLeft = new System.Windows.Forms.Button();
			this.removeCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// listBox
			// 
			this.listBox.Location = new System.Drawing.Point(16, 24);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(152, 121);
			this.listBox.TabIndex = 0;
			this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			// 
			// checkedListBox
			// 
			this.checkedListBox.CheckOnClick = true;
			this.checkedListBox.Location = new System.Drawing.Point(184, 24);
			this.checkedListBox.Name = "checkedListBox";
			this.checkedListBox.Size = new System.Drawing.Size(152, 124);
			this.checkedListBox.TabIndex = 3;
			this.checkedListBox.ThreeDCheckBoxes = true;
			// 
			// CloseButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(376, 24);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.TabIndex = 7;
			this.CloseButton.Text = "Close";
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// newItemButtonLeft
			// 
			this.newItemButtonLeft.Location = new System.Drawing.Point(16, 176);
			this.newItemButtonLeft.Name = "newItemButtonLeft";
			this.newItemButtonLeft.TabIndex = 1;
			this.newItemButtonLeft.Text = "Add";
			this.newItemButtonLeft.Click += new System.EventHandler(this.newItemButtonLeft_Click);
			// 
			// newItemButtonRight
			// 
			this.newItemButtonRight.Location = new System.Drawing.Point(184, 176);
			this.newItemButtonRight.Name = "newItemButtonRight";
			this.newItemButtonRight.TabIndex = 4;
			this.newItemButtonRight.Text = "Add";
			this.newItemButtonRight.Click += new System.EventHandler(this.NewItemButtonRight_Click);
			// 
			// removeItemButtonRight
			// 
			this.removeItemButtonRight.Location = new System.Drawing.Point(184, 208);
			this.removeItemButtonRight.Name = "removeItemButtonRight";
			this.removeItemButtonRight.TabIndex = 5;
			this.removeItemButtonRight.Text = "Remove";
			this.removeItemButtonRight.Click += new System.EventHandler(this.removeItemButtonRight_Click);
			// 
			// removeItemButtonLeft
			// 
			this.removeItemButtonLeft.Location = new System.Drawing.Point(16, 208);
			this.removeItemButtonLeft.Name = "removeItemButtonLeft";
			this.removeItemButtonLeft.TabIndex = 2;
			this.removeItemButtonLeft.Text = "Remove";
			this.removeItemButtonLeft.Click += new System.EventHandler(this.removeItemButtonLeft_Click);
			// 
			// removeCheckBox
			// 
			this.removeCheckBox.Location = new System.Drawing.Point(280, 208);
			this.removeCheckBox.Name = "removeCheckBox";
			this.removeCheckBox.Size = new System.Drawing.Size(144, 24);
			this.removeCheckBox.TabIndex = 6;
			this.removeCheckBox.Text = "Remove Checked Only";
			// 
			// ListBoxForm
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 254);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.removeCheckBox,
																		  this.removeItemButtonLeft,
																		  this.removeItemButtonRight,
																		  this.newItemButtonRight,
																		  this.newItemButtonLeft,
																		  this.CloseButton,
																		  this.checkedListBox,
																		  this.listBox});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ListBoxForm";
			this.Text = "ListBoxForm";
			this.Load += new System.EventHandler(this.ListBoxForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

        private void NewItemButtonRight_Click(object sender, System.EventArgs e)
        {
            AddListBoxItemForm dlg = new AddListBoxItemForm();
            DialogResult result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                string newItem = dlg.NewItem;
                Sailboat item = new Sailboat(newItem, 45);
                checkedListBox.Items.Add(item, CheckState.Unchecked);
            }
        }

        private void removeItemButtonRight_Click(object sender, System.EventArgs e)
        {
            if(checkedListBox.Items.Count != 0)
            {
                if(removeCheckBox.Checked == true)
                {
                    int checkedCount = checkedListBox.CheckedIndices.Count;
                    for(int index = checkedCount; index > 0; index--)
                    {
                        checkedListBox.Items.RemoveAt(checkedListBox.CheckedIndices[index-1]);
                    }
                }
                else
                {
                    int index = checkedListBox.SelectedIndex;
                    if(index != -1)
                    {
                        checkedListBox.Items.RemoveAt(index);
                    }
                    else
                    {
                        MessageBox.Show("You must select an item to remove", "Can't remove item", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else
            {
                MessageBox.Show("The list box is empty", "Nothing to remove", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void newItemButtonLeft_Click(object sender, System.EventArgs e)
        {
            AddListBoxItemForm dlg = new AddListBoxItemForm();
            DialogResult result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                string newItem = dlg.NewItem;
                ListBoxItem item = new ListBoxItem(newItem);
                listBox.Items.Add(item);
            }
        }

        private void removeItemButtonLeft_Click(object sender, System.EventArgs e)
        {
            int index = listBox.SelectedIndex;
            
            if(listBox.Items.Count != 0)
            {
                if(index != -1)
                {
                    listBox.Items.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("You must select an item to remove", "Can't remove item", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("The list box is empty", "Nothing to remove", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Trace.WriteLine("listBox_SelectedIndexChanged");
        }

        private void listBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            Trace.WriteLine("listBox_SelectedValueChanged");
        }

		private void ListBoxForm_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
