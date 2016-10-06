using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.GC {
	/// <summary>
	/// Summary description for GCSwitch.
	/// </summary>
	public class GCSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button FinalizeBtn;
		private System.Windows.Forms.Button BlockPinBtn;
		private System.Windows.Forms.Button ObjectPoolBtn;

		private System.ComponentModel.Container components = null;

		public GCSwitch() {
			InitializeComponent();
		}

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
			this.FinalizeBtn = new System.Windows.Forms.Button();
			this.BlockPinBtn = new System.Windows.Forms.Button();
			this.ObjectPoolBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// FinalizeBtn
			// 
			this.FinalizeBtn.Location = new System.Drawing.Point(8, 16);
			this.FinalizeBtn.Name = "FinalizeBtn";
			this.FinalizeBtn.Size = new System.Drawing.Size(208, 23);
			this.FinalizeBtn.TabIndex = 0;
			this.FinalizeBtn.Text = "01 - Finalize";
			this.FinalizeBtn.Click += new System.EventHandler(this.FinalizeBtn_Click);
			// 
			// BlockPinBtn
			// 
			this.BlockPinBtn.Location = new System.Drawing.Point(8, 80);
			this.BlockPinBtn.Name = "BlockPinBtn";
			this.BlockPinBtn.Size = new System.Drawing.Size(208, 23);
			this.BlockPinBtn.TabIndex = 0;
			this.BlockPinBtn.Text = "03 - Block Pin";
			this.BlockPinBtn.Click += new System.EventHandler(this.BlockPinBtn_Click);
			// 
			// ObjectPoolBtn
			// 
			this.ObjectPoolBtn.Location = new System.Drawing.Point(8, 48);
			this.ObjectPoolBtn.Name = "ObjectPoolBtn";
			this.ObjectPoolBtn.Size = new System.Drawing.Size(208, 23);
			this.ObjectPoolBtn.TabIndex = 2;
			this.ObjectPoolBtn.Text = "02 - Object Pool";
			this.ObjectPoolBtn.Click += new System.EventHandler(this.ObjectPoolBtn_Click);
			// 
			// GCSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ObjectPoolBtn,
																		  this.BlockPinBtn,
																		  this.FinalizeBtn});
			this.Name = "GCSwitch";
			this.ShowInTaskbar = false;
			this.Text = "Garbage Collection";
			this.ResumeLayout(false);

		}
		#endregion

		private void FinalizeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(FinalizeTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void HandleCollectorBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(HandleCollector.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void BlockPinBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(BlockPin.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ObjectPoolBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(ObjectPoolTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

	}
}
