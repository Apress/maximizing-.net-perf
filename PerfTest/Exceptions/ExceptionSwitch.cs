using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Exceptions {
	/// <summary>
	/// Summary description for ExceptionSwitch.
	/// </summary>
	public class ExceptionSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button TryCatchBlockBtn;
		private System.Windows.Forms.Button FilterTypesBtn;
		private System.Windows.Forms.Button OnErrorBtn;
		private System.Windows.Forms.Button RethrowBtn;
		private System.Windows.Forms.Button CastVsAsBtn;
		private System.Windows.Forms.Button CastVsAsFailBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ExceptionSwitch() {
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
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.TryCatchBlockBtn = new System.Windows.Forms.Button();
			this.FilterTypesBtn = new System.Windows.Forms.Button();
			this.OnErrorBtn = new System.Windows.Forms.Button();
			this.RethrowBtn = new System.Windows.Forms.Button();
			this.CastVsAsBtn = new System.Windows.Forms.Button();
			this.CastVsAsFailBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TryCatchBlockBtn
			// 
			this.TryCatchBlockBtn.Location = new System.Drawing.Point(8, 80);
			this.TryCatchBlockBtn.Name = "TryCatchBlockBtn";
			this.TryCatchBlockBtn.Size = new System.Drawing.Size(192, 23);
			this.TryCatchBlockBtn.TabIndex = 0;
			this.TryCatchBlockBtn.Text = "03 - Try Catch Block";
			this.TryCatchBlockBtn.Click += new System.EventHandler(this.TryCatchBlockBtn_Click);
			// 
			// FilterTypesBtn
			// 
			this.FilterTypesBtn.Location = new System.Drawing.Point(8, 16);
			this.FilterTypesBtn.Name = "FilterTypesBtn";
			this.FilterTypesBtn.Size = new System.Drawing.Size(192, 23);
			this.FilterTypesBtn.TabIndex = 0;
			this.FilterTypesBtn.Text = "01 - Filter Types";
			this.FilterTypesBtn.Click += new System.EventHandler(this.FilterTypesBtn_Click);
			// 
			// OnErrorBtn
			// 
			this.OnErrorBtn.Location = new System.Drawing.Point(8, 48);
			this.OnErrorBtn.Name = "OnErrorBtn";
			this.OnErrorBtn.Size = new System.Drawing.Size(192, 23);
			this.OnErrorBtn.TabIndex = 0;
			this.OnErrorBtn.Text = "02 - On Error Handling";
			this.OnErrorBtn.Click += new System.EventHandler(this.OnErrorBtn_Click);
			// 
			// RethrowBtn
			// 
			this.RethrowBtn.Location = new System.Drawing.Point(8, 112);
			this.RethrowBtn.Name = "RethrowBtn";
			this.RethrowBtn.Size = new System.Drawing.Size(192, 23);
			this.RethrowBtn.TabIndex = 0;
			this.RethrowBtn.Text = "04 - Rethrow";
			this.RethrowBtn.Click += new System.EventHandler(this.RethrowBtn_Click);
			// 
			// CastVsAsBtn
			// 
			this.CastVsAsBtn.Location = new System.Drawing.Point(8, 144);
			this.CastVsAsBtn.Name = "CastVsAsBtn";
			this.CastVsAsBtn.Size = new System.Drawing.Size(192, 23);
			this.CastVsAsBtn.TabIndex = 0;
			this.CastVsAsBtn.Text = "05 - Cast vs As (Succeed)";
			this.CastVsAsBtn.Click += new System.EventHandler(this.CastVsAsBtn_Click);
			// 
			// CastVsAsFailBtn
			// 
			this.CastVsAsFailBtn.Location = new System.Drawing.Point(8, 176);
			this.CastVsAsFailBtn.Name = "CastVsAsFailBtn";
			this.CastVsAsFailBtn.Size = new System.Drawing.Size(192, 23);
			this.CastVsAsFailBtn.TabIndex = 1;
			this.CastVsAsFailBtn.Text = "06 - Cast vs As (Fail)";
			this.CastVsAsFailBtn.Click += new System.EventHandler(this.CastVsAsFailBtn_Click);
			// 
			// ExceptionSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(216, 214);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CastVsAsFailBtn,
																		  this.TryCatchBlockBtn,
																		  this.FilterTypesBtn,
																		  this.OnErrorBtn,
																		  this.RethrowBtn,
																		  this.CastVsAsBtn});
			this.Name = "ExceptionSwitch";
			this.ShowInTaskbar = false;
			this.Text = "ExceptionSwitch";
			this.ResumeLayout(false);

		}
		#endregion

		private void TryCatchBlockBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(TryBlock.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void FilterTypesBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(FilterTypes.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void OnErrorBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(OnErrorResume.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StackTraceBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(StackTrace.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void RethrowBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(ThrowEx.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void CastVsAsBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CastvsAsNoFail()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void CastVsAsFailBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(CastVsAs.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}
	}
}
