using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DotNetPerformance.ResultOutput;

namespace Test_Example
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;

//		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox FileNameTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button FileNameBtn;
		private System.Windows.Forms.CheckBox SummaryChk;

		private DotNetPerformance.ResultOutput.DisplayOption currentDisplay = DisplayOption.Chart;
		private object[] dislayConfigSettings;
		private System.Windows.Forms.Button BoxingTestBtn;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SummaryChk = new System.Windows.Forms.CheckBox();
			this.FileNameBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.FileNameTxt = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.BoxingTestBtn = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(16, 88);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(72, 24);
			this.radioButton3.TabIndex = 5;
			this.radioButton3.Text = "File";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Text = "Message Box";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Checked = true;
			this.radioButton2.Location = new System.Drawing.Point(16, 56);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 4;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Chart";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SummaryChk);
			this.groupBox2.Controls.Add(this.FileNameBtn);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.FileNameTxt);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(8, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 120);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Display Options";
			// 
			// SummaryChk
			// 
			this.SummaryChk.Location = new System.Drawing.Point(120, 24);
			this.SummaryChk.Name = "SummaryChk";
			this.SummaryChk.TabIndex = 9;
			this.SummaryChk.Text = "Summary";
			this.SummaryChk.Visible = false;
			// 
			// FileNameBtn
			// 
			this.FileNameBtn.Location = new System.Drawing.Point(352, 89);
			this.FileNameBtn.Name = "FileNameBtn";
			this.FileNameBtn.Size = new System.Drawing.Size(32, 23);
			this.FileNameBtn.TabIndex = 8;
			this.FileNameBtn.Text = "...";
			this.FileNameBtn.Visible = false;
			this.FileNameBtn.Click += new System.EventHandler(this.FileNameBtn_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(104, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "File Name:";
			this.label1.Visible = false;
			// 
			// FileNameTxt
			// 
			this.FileNameTxt.Location = new System.Drawing.Point(176, 90);
			this.FileNameTxt.Name = "FileNameTxt";
			this.FileNameTxt.Size = new System.Drawing.Size(160, 20);
			this.FileNameTxt.TabIndex = 6;
			this.FileNameTxt.Text = "";
			this.FileNameTxt.Visible = false;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			// 
			// BoxingTestBtn
			// 
			this.BoxingTestBtn.Location = new System.Drawing.Point(24, 8);
			this.BoxingTestBtn.Name = "BoxingTestBtn";
			this.BoxingTestBtn.TabIndex = 4;
			this.BoxingTestBtn.Tag = "";
			this.BoxingTestBtn.Text = "Boxing Test";
			this.BoxingTestBtn.Click += new System.EventHandler(this.BoxingTestBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 182);
			this.Controls.Add(this.BoxingTestBtn);
			this.Controls.Add(this.groupBox2);
			this.Name = "Form1";
			this.Text = "Test Harness Example";
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e) {
			if		(radioButton1.Checked){currentDisplay = DisplayOption.MessageBox;}
			else if (radioButton2.Checked){currentDisplay = DisplayOption.Chart;}
			else if (radioButton3.Checked){currentDisplay = DisplayOption.File;}
			
			label1.Visible = (currentDisplay == DisplayOption.File);
			FileNameBtn.Visible = (currentDisplay == DisplayOption.File);
			FileNameTxt.Visible = (currentDisplay == DisplayOption.File);
			SummaryChk.Visible = (currentDisplay == DisplayOption.MessageBox);

		}

		private void FileNameBtn_Click(object sender, System.EventArgs e) {
			this.saveFileDialog1.AddExtension = true;
			this.saveFileDialog1.DefaultExt = "xml";
			this.saveFileDialog1.Title = "Save test results to..";
			this.saveFileDialog1.FileName = "Test Results";
			this.saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
			this.saveFileDialog1.ShowDialog(this);
			this.FileNameTxt.Text =  this.saveFileDialog1.FileName;
		}

		protected void GetDisplaySetting(){
			dislayConfigSettings = new object[1];
			switch (currentDisplay){
				case DisplayOption.MessageBox:
					dislayConfigSettings[0] = SummaryChk.Checked;
					break;
				case DisplayOption.Chart:
					break;
				case DisplayOption.File:
					dislayConfigSettings[0] = FileNameTxt.Text;
					break;
			}
		}

		private void BoxingTestBtn_Click(object sender, System.EventArgs e) {
			GetDisplaySetting();
			BoxingTest bt =  new BoxingTest();
			DotNetPerformance.ResultOutput.Output.DisplayResults
				(bt.RunTest(), currentDisplay , dislayConfigSettings);
		}


	}
}
