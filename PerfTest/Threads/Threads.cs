using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Threads
{
	/// <summary>
	/// Summary description for Threads.
	/// </summary>
	public class Threads : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button SynchPatternsBtn;
		private System.Windows.Forms.Button InterlockedBtn;
		private System.Windows.Forms.Button AddInSynchBtn;
		private System.Windows.Forms.Button PulseAndWaitBtn;
		private System.Windows.Forms.Button MutexMonitorBtn;
		private System.Windows.Forms.Button ReaderWriterVsMonitor;
		private System.Windows.Forms.Button ReaderWriterVsMonitorMulti;
		private System.Windows.Forms.TextBox ItemInQueueTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ThreadLocal;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Threads()
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
			this.SynchPatternsBtn = new System.Windows.Forms.Button();
			this.InterlockedBtn = new System.Windows.Forms.Button();
			this.AddInSynchBtn = new System.Windows.Forms.Button();
			this.PulseAndWaitBtn = new System.Windows.Forms.Button();
			this.MutexMonitorBtn = new System.Windows.Forms.Button();
			this.ReaderWriterVsMonitor = new System.Windows.Forms.Button();
			this.ReaderWriterVsMonitorMulti = new System.Windows.Forms.Button();
			this.ItemInQueueTxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ThreadLocal = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SynchPatternsBtn
			// 
			this.SynchPatternsBtn.Location = new System.Drawing.Point(8, 16);
			this.SynchPatternsBtn.Name = "SynchPatternsBtn";
			this.SynchPatternsBtn.Size = new System.Drawing.Size(248, 23);
			this.SynchPatternsBtn.TabIndex = 0;
			this.SynchPatternsBtn.Text = "01 - Synch. Patterns";
			this.SynchPatternsBtn.Click += new System.EventHandler(this.SynchPatternsBtn_Click);
			// 
			// InterlockedBtn
			// 
			this.InterlockedBtn.Location = new System.Drawing.Point(8, 112);
			this.InterlockedBtn.Name = "InterlockedBtn";
			this.InterlockedBtn.Size = new System.Drawing.Size(248, 23);
			this.InterlockedBtn.TabIndex = 0;
			this.InterlockedBtn.Text = "04 - Interlocked";
			this.InterlockedBtn.Click += new System.EventHandler(this.InterlockedBtn_Click);
			// 
			// AddInSynchBtn
			// 
			this.AddInSynchBtn.Location = new System.Drawing.Point(8, 48);
			this.AddInSynchBtn.Name = "AddInSynchBtn";
			this.AddInSynchBtn.Size = new System.Drawing.Size(248, 23);
			this.AddInSynchBtn.TabIndex = 0;
			this.AddInSynchBtn.Text = "02 - Add-in Synch Test";
			this.AddInSynchBtn.Click += new System.EventHandler(this.AddInSynchBtn_Click);
			// 
			// PulseAndWaitBtn
			// 
			this.PulseAndWaitBtn.Location = new System.Drawing.Point(8, 144);
			this.PulseAndWaitBtn.Name = "PulseAndWaitBtn";
			this.PulseAndWaitBtn.Size = new System.Drawing.Size(248, 23);
			this.PulseAndWaitBtn.TabIndex = 0;
			this.PulseAndWaitBtn.Text = "05 - Pulse and Wait";
			this.PulseAndWaitBtn.Click += new System.EventHandler(this.PulseAndWaitBtn_Click);
			// 
			// MutexMonitorBtn
			// 
			this.MutexMonitorBtn.Location = new System.Drawing.Point(8, 80);
			this.MutexMonitorBtn.Name = "MutexMonitorBtn";
			this.MutexMonitorBtn.Size = new System.Drawing.Size(248, 23);
			this.MutexMonitorBtn.TabIndex = 0;
			this.MutexMonitorBtn.Text = "03 - Mutex vs Monitor";
			this.MutexMonitorBtn.Click += new System.EventHandler(this.MutexMonitorBtn_Click);
			// 
			// ReaderWriterVsMonitor
			// 
			this.ReaderWriterVsMonitor.Location = new System.Drawing.Point(8, 176);
			this.ReaderWriterVsMonitor.Name = "ReaderWriterVsMonitor";
			this.ReaderWriterVsMonitor.Size = new System.Drawing.Size(248, 23);
			this.ReaderWriterVsMonitor.TabIndex = 0;
			this.ReaderWriterVsMonitor.Text = "06 - ReaderWriterVsMonitor";
			this.ReaderWriterVsMonitor.Click += new System.EventHandler(this.ReaderWriterVsMonitor_Click);
			// 
			// ReaderWriterVsMonitorMulti
			// 
			this.ReaderWriterVsMonitorMulti.Location = new System.Drawing.Point(8, 208);
			this.ReaderWriterVsMonitorMulti.Name = "ReaderWriterVsMonitorMulti";
			this.ReaderWriterVsMonitorMulti.Size = new System.Drawing.Size(248, 23);
			this.ReaderWriterVsMonitorMulti.TabIndex = 0;
			this.ReaderWriterVsMonitorMulti.Text = "07 - ReaderWriterVsMonitor - MultiThreaded";
			this.ReaderWriterVsMonitorMulti.Click += new System.EventHandler(this.ReaderWriterVsMonitorMulti_Click);
			// 
			// ItemInQueueTxt
			// 
			this.ItemInQueueTxt.Location = new System.Drawing.Point(392, 144);
			this.ItemInQueueTxt.Name = "ItemInQueueTxt";
			this.ItemInQueueTxt.TabIndex = 1;
			this.ItemInQueueTxt.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 144);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Item in queue %";
			// 
			// ThreadLocal
			// 
			this.ThreadLocal.Location = new System.Drawing.Point(8, 240);
			this.ThreadLocal.Name = "ThreadLocal";
			this.ThreadLocal.Size = new System.Drawing.Size(248, 23);
			this.ThreadLocal.TabIndex = 0;
			this.ThreadLocal.Text = "Thread Local Storage";
			this.ThreadLocal.Click += new System.EventHandler(this.ThreadLocal_Click);
			// 
			// Threads
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 270);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ItemInQueueTxt);
			this.Controls.Add(this.SynchPatternsBtn);
			this.Controls.Add(this.InterlockedBtn);
			this.Controls.Add(this.AddInSynchBtn);
			this.Controls.Add(this.PulseAndWaitBtn);
			this.Controls.Add(this.MutexMonitorBtn);
			this.Controls.Add(this.ReaderWriterVsMonitor);
			this.Controls.Add(this.ReaderWriterVsMonitorMulti);
			this.Controls.Add(this.ThreadLocal);
			this.Name = "Threads";
			this.ShowInTaskbar = false;
			this.Text = "Threads";
			this.ResumeLayout(false);

		}
		#endregion

		private void SynchPatternsBtn_Click(object sender, System.EventArgs e) {
			Synchronized test = new Synchronized();
			DotNetPerformance.ResultOutput.Output.DisplayResults(test.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void InterlockedBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(InterlockedTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void AddInSynchBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(AddInSynch.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void PulseAndWaitBtn_Click(object sender, System.EventArgs e) {
			PulseAndWait test = new PulseAndWait(double.Parse(ItemInQueueTxt.Text));
			DotNetPerformance.ResultOutput.Output.DisplayResults(test.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void MutexMonitorBtn_Click(object sender, System.EventArgs e) {
			MutexMonitor test = new MutexMonitor();
			DotNetPerformance.ResultOutput.Output.DisplayResults(test.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void LockGranularityBtn_Click(object sender, System.EventArgs e) {
			SynchronizedTwoThreads test = new SynchronizedTwoThreads();
			DotNetPerformance.ResultOutput.Output.DisplayResults(test.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ReaderWriterVsMonitor_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ReaderWriterVsMonitor().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ReaderWriterVsMonitorMulti_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ReaderWriterVsMonitorMultiThreaded().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ThreadLocal_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(TLS.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}
	}
}
