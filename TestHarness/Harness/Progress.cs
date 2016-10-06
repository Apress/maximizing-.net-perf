using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DotNetPerformance{
	internal class Progress : System.Windows.Forms.Form{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button CancelBtn;
		private System.ComponentModel.Container components = null;
		TestRunner _tr;

		public Progress(TestRunner tr){
			_tr = tr;
			InitializeComponent();
			if (tr != null)
				tr.OnPercentageDoneChangeHandler += new TestRunner.PercentageDoneEventHandler(OnPercentageChange);
			
			timer.Tick += new EventHandler(OnTimerEvent);
			timer.Interval = 500;
			timer.Start();

		}

		void OnPercentageChange(object source, PercentageDoneChangeEventArgs e){
			if (e.PercentageDone == 100)
				try{
					Close();
				}
				catch(Exception){}
			else
				progressBar1.Value = e.PercentageDone;
		}

		void OnTimerEvent(Object myObject,EventArgs myEventArgs) { //deal with missed test finishes
			if (_tr.TestsDone)
				Close();
		}


		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(109, 56);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 16);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(272, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// Progress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 78);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CancelBtn,
																		  this.progressBar1});
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(300, 112);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 112);
			this.Name = "Progress";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Progress";
			this.Load += new System.EventHandler(this.Progress_Load);
			this.Closed += new System.EventHandler(this.Progress_Close);
			this.ResumeLayout(false);

		}
		#endregion

		private void CancelBtn_Click(object sender, System.EventArgs e){
			_tr.TestsStoppedEvent.Set();
			Close();
		}

		private void Progress_Close(object sender, System.EventArgs e) {
			_tr.TestsStoppedEvent.Set();
		}

		private void Progress_Load(object sender, System.EventArgs e) {
			if (_tr.TestsDone)
				Close();
		}
	}
}
