using System;
using System.IO;
using System.Diagnostics;
using Interactive;
/*
 * Created by SharpDevelop.
 * User: Pralay
 * Date: 08-06-2013
 * Time: 10:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RedirectOutput
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.input = new System.Windows.Forms.TextBox();
			this.output = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// input
			// 
			this.input.Location = new System.Drawing.Point(7, 4);
			this.input.Name = "input";
			this.input.Size = new System.Drawing.Size(280, 22);
			this.input.TabIndex = 0;
			// 
			// output
			// 
			this.output.Location = new System.Drawing.Point(15, 53);
			this.output.Name = "output";
			this.output.Size = new System.Drawing.Size(254, 164);
			this.output.TabIndex = 1;
			this.output.Text = "label1";
			this.output.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OutputPreviewKeyDown);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 268);
			this.Controls.Add(this.output);
			this.Controls.Add(this.input);
			this.Name = "MainForm";
			this.Text = "RedirectOutput";
			this.ResumeLayout(false);
			this.PerformLayout();
			
			
			//Process.Start(@"c:\Users\Pralay\Documents\Projects\CSharp\Interactive.exe");
			
			
			stringReader = new StringReader(_input);
			streamWriter = new StreamWriter(@"c:\temp\test.txt");
			
			//Console.SetIn(stringReader);
			Console.SetOut(streamWriter);
			System.Threading.Thread th = new System.Threading.Thread(
				new System.Threading.ThreadStart(Interactive.Interactive.Run));
			th.Start();
			
			input.KeyDown+= delegate (object sender, System.Windows.Forms.KeyEventArgs e)
			{ 
			//if (e.KeyValue.ToString()=="Enter")
			{
				_input = input.Text;
				//output.Text = 
				//_output = _input;
			} };
		}
		string _input="", _output="";
		StringReader stringReader = null;
			StreamWriter streamWriter = null;
		private System.Windows.Forms.Label output;
		private System.Windows.Forms.TextBox input;
		
		void OutputPreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
		{
			if (e.KeyValue.ToString()=="Enter")
			{
				_input = input.Text;
				_output = _input;
			}
		}
	}
}
