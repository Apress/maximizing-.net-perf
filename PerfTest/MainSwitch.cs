using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DotNetPerformance.ResultOutput;

namespace PerfTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button StringBtn;
		private System.Windows.Forms.Button ClassDesignBtn;
		private System.Windows.Forms.Button GCBtn;
		private System.Windows.Forms.TextBox FileNameTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button FileNameBtn;
		private System.Windows.Forms.CheckBox SummaryChk;

		private static DisplayOption currentDisplay = DisplayOption.Chart;
		private System.Windows.Forms.Button CollectionsBtn;
		private System.Windows.Forms.Button Threads;
		private System.Windows.Forms.Button ThreadBtn;
		private System.Windows.Forms.Button IOBtn;
		private System.Windows.Forms.Button RemotingBtn;
		private System.Windows.Forms.Button InteropBtn;
		private System.Windows.Forms.Button CLRBtn;
		private System.Windows.Forms.Button SecurityBtn;
		private System.Windows.Forms.Button LanguageBtn;
		private static object[] dislayConfigSettings;

		public FormMain()
		{
			InitializeComponent();
			object[] atts = System.Reflection.Assembly.GetCallingAssembly().GetCustomAttributes(typeof(System.Diagnostics.DebuggableAttribute), true);
			if (atts.Length == 0){
				return;
			}
			//visually warning for debug tests
			this.BackColor = System.Drawing.Color.Red;
		}

		public static DisplayOption CurrentDisplay{get{return currentDisplay;}}
		public static object[] DisplayConfigSetting{get{return dislayConfigSettings;}}

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
			this.ClassDesignBtn = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.GCBtn = new System.Windows.Forms.Button();
			this.StringBtn = new System.Windows.Forms.Button();
			this.CollectionsBtn = new System.Windows.Forms.Button();
			this.Threads = new System.Windows.Forms.Button();
			this.ThreadBtn = new System.Windows.Forms.Button();
			this.IOBtn = new System.Windows.Forms.Button();
			this.RemotingBtn = new System.Windows.Forms.Button();
			this.InteropBtn = new System.Windows.Forms.Button();
			this.CLRBtn = new System.Windows.Forms.Button();
			this.SecurityBtn = new System.Windows.Forms.Button();
			this.LanguageBtn = new System.Windows.Forms.Button();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SummaryChk = new System.Windows.Forms.CheckBox();
			this.FileNameBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.FileNameTxt = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
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
			// ClassDesignBtn
			// 
			this.ClassDesignBtn.Location = new System.Drawing.Point(8, 24);
			this.ClassDesignBtn.Name = "ClassDesignBtn";
			this.ClassDesignBtn.Size = new System.Drawing.Size(104, 24);
			this.ClassDesignBtn.TabIndex = 1;
			this.ClassDesignBtn.Text = "03 - Class Design";
			this.ClassDesignBtn.Click += new System.EventHandler(this.ClassDesignBtn_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Text = "Message Box";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.GCBtn);
			this.groupBox1.Controls.Add(this.ClassDesignBtn);
			this.groupBox1.Controls.Add(this.StringBtn);
			this.groupBox1.Controls.Add(this.CollectionsBtn);
			this.groupBox1.Controls.Add(this.Threads);
			this.groupBox1.Controls.Add(this.ThreadBtn);
			this.groupBox1.Controls.Add(this.IOBtn);
			this.groupBox1.Controls.Add(this.RemotingBtn);
			this.groupBox1.Controls.Add(this.InteropBtn);
			this.groupBox1.Controls.Add(this.CLRBtn);
			this.groupBox1.Controls.Add(this.SecurityBtn);
			this.groupBox1.Controls.Add(this.LanguageBtn);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 240);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tests";
			// 
			// GCBtn
			// 
			this.GCBtn.Location = new System.Drawing.Point(8, 152);
			this.GCBtn.Name = "GCBtn";
			this.GCBtn.Size = new System.Drawing.Size(104, 24);
			this.GCBtn.TabIndex = 2;
			this.GCBtn.Text = "07 - GC";
			this.GCBtn.Click += new System.EventHandler(this.GCBtn_Click);
			// 
			// StringBtn
			// 
			this.StringBtn.Location = new System.Drawing.Point(8, 56);
			this.StringBtn.Name = "StringBtn";
			this.StringBtn.Size = new System.Drawing.Size(104, 23);
			this.StringBtn.TabIndex = 0;
			this.StringBtn.Text = "04 - Strings";
			this.StringBtn.Click += new System.EventHandler(this.StringBtn_Click);
			// 
			// CollectionsBtn
			// 
			this.CollectionsBtn.Location = new System.Drawing.Point(8, 88);
			this.CollectionsBtn.Name = "CollectionsBtn";
			this.CollectionsBtn.Size = new System.Drawing.Size(104, 24);
			this.CollectionsBtn.TabIndex = 2;
			this.CollectionsBtn.Text = "05 - Collections";
			this.CollectionsBtn.Click += new System.EventHandler(this.CollectionsBtn_Click);
			// 
			// Threads
			// 
			this.Threads.Location = new System.Drawing.Point(136, 56);
			this.Threads.Name = "Threads";
			this.Threads.Size = new System.Drawing.Size(104, 24);
			this.Threads.TabIndex = 2;
			this.Threads.Text = "10 - Threads";
			this.Threads.Click += new System.EventHandler(this.Threads_Click);
			// 
			// ThreadBtn
			// 
			this.ThreadBtn.Location = new System.Drawing.Point(8, 184);
			this.ThreadBtn.Name = "ThreadBtn";
			this.ThreadBtn.Size = new System.Drawing.Size(104, 24);
			this.ThreadBtn.TabIndex = 2;
			this.ThreadBtn.Text = "08 - Exceptions";
			this.ThreadBtn.Click += new System.EventHandler(this.ThreadBtn_Click);
			// 
			// IOBtn
			// 
			this.IOBtn.Location = new System.Drawing.Point(136, 88);
			this.IOBtn.Name = "IOBtn";
			this.IOBtn.Size = new System.Drawing.Size(104, 24);
			this.IOBtn.TabIndex = 2;
			this.IOBtn.Text = "11 - IO";
			this.IOBtn.Click += new System.EventHandler(this.IOBtn_Click);
			// 
			// RemotingBtn
			// 
			this.RemotingBtn.Location = new System.Drawing.Point(136, 120);
			this.RemotingBtn.Name = "RemotingBtn";
			this.RemotingBtn.Size = new System.Drawing.Size(104, 24);
			this.RemotingBtn.TabIndex = 2;
			this.RemotingBtn.Text = "12 -Remoting";
			this.RemotingBtn.Click += new System.EventHandler(this.RemotingBtn_Click);
			// 
			// InteropBtn
			// 
			this.InteropBtn.Location = new System.Drawing.Point(136, 152);
			this.InteropBtn.Name = "InteropBtn";
			this.InteropBtn.Size = new System.Drawing.Size(104, 24);
			this.InteropBtn.TabIndex = 2;
			this.InteropBtn.Text = "13 - Interop";
			this.InteropBtn.Click += new System.EventHandler(this.InteropBtn_Click);
			// 
			// CLRBtn
			// 
			this.CLRBtn.Location = new System.Drawing.Point(136, 184);
			this.CLRBtn.Name = "CLRBtn";
			this.CLRBtn.Size = new System.Drawing.Size(104, 24);
			this.CLRBtn.TabIndex = 2;
			this.CLRBtn.Text = "14 - CLR";
			this.CLRBtn.Click += new System.EventHandler(this.CLRBtn_Click);
			// 
			// SecurityBtn
			// 
			this.SecurityBtn.Location = new System.Drawing.Point(136, 24);
			this.SecurityBtn.Name = "SecurityBtn";
			this.SecurityBtn.Size = new System.Drawing.Size(104, 24);
			this.SecurityBtn.TabIndex = 2;
			this.SecurityBtn.Text = "09 - Security";
			this.SecurityBtn.Click += new System.EventHandler(this.SecurityBtn_Click);
			// 
			// LanguageBtn
			// 
			this.LanguageBtn.Location = new System.Drawing.Point(8, 120);
			this.LanguageBtn.Name = "LanguageBtn";
			this.LanguageBtn.Size = new System.Drawing.Size(104, 24);
			this.LanguageBtn.TabIndex = 2;
			this.LanguageBtn.Text = "06 - Languages";
			this.LanguageBtn.Click += new System.EventHandler(this.LanguageBtn_Click);
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
			this.groupBox2.Location = new System.Drawing.Point(8, 264);
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
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 413);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormMain";
			this.Text = "DotNetPerformance";
			this.Leave += new System.EventHandler(this.FormMain_Leave);
			this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		//[LoaderOptimization(LoaderOptimization.MultiDomain)]
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
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

		private void StringBtn_Click(object sender, System.EventArgs e)
		{
			PerfTest.Strings.StringSwitch stringFrm = new PerfTest.Strings.StringSwitch();
			stringFrm.ShowDialog(this);
		}

		private void ClassDesignBtn_Click(object sender, System.EventArgs e)
		{
			PerfTest.ClassDesign.ClassDesignSwitch classFrm = new PerfTest.ClassDesign.ClassDesignSwitch();
			classFrm.ShowDialog(this);
		}

		private void GCBtn_Click(object sender, System.EventArgs e)
		{
			PerfTest.GC.GCSwitch gcFrm = new PerfTest.GC.GCSwitch();
			gcFrm.ShowDialog(this);
		}

		private void CollectionsBtn_Click(object sender, System.EventArgs e) {
			PerfTest.Collections.CollectionSwitch sw = new PerfTest.Collections.CollectionSwitch();
			sw.ShowDialog(this);
		}

		private void Threads_Click(object sender, System.EventArgs e) {
			PerfTest.Threads.Threads sw = new PerfTest.Threads.Threads();
			sw.ShowDialog(this);
		}

		private void ThreadBtn_Click(object sender, System.EventArgs e) {
			PerfTest.Exceptions.ExceptionSwitch sw = new PerfTest.Exceptions.ExceptionSwitch();
			sw.ShowDialog(this);
		}

		private void IOBtn_Click(object sender, System.EventArgs e) {
			PerfTest.IO.IOSwitch sw = new PerfTest.IO.IOSwitch();
			sw.ShowDialog(this);
		}

		private void RemotingBtn_Click(object sender, System.EventArgs e) {
			new PerfTest.Remoting.RemotingSwitch().ShowDialog(this);
		}

		private void InteropBtn_Click(object sender, System.EventArgs e) {
			new PerfTest.Interop.InteropSwitch().ShowDialog(this);
		}

		private void CLRBtn_Click(object sender, System.EventArgs e) {
			new PerfTest.CLR.CLRSwitch().ShowDialog(this);
		}

		private void SecurityBtn_Click(object sender, System.EventArgs e) {
			new PerfTest.Security.SecuritySwitch().ShowDialog(this);
		}

		private void LanguageBtn_Click(object sender, System.EventArgs e) {
			new PerfTest.Languages.LanguageSwitch().ShowDialog(this);
		}

		private void FormMain_Leave(object sender, System.EventArgs e) {
		}

		private void FormMain_Deactivate(object sender, System.EventArgs e) {
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
	}
}
