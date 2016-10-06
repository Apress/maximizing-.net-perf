using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Security {
	/// <summary>
	/// Summary description for SecuritySwitch.
	/// </summary>
	public class SecuritySwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button StackWalk;
		private System.Windows.Forms.Button PermissionSet;
		private System.Windows.Forms.Button Demands;
		private System.Windows.Forms.Button Asserts;
		private System.Windows.Forms.Button PublicPrivate;
		private System.Windows.Forms.Button KeyLength;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SecuritySwitch() {
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
			this.StackWalk = new System.Windows.Forms.Button();
			this.PermissionSet = new System.Windows.Forms.Button();
			this.Demands = new System.Windows.Forms.Button();
			this.Asserts = new System.Windows.Forms.Button();
			this.PublicPrivate = new System.Windows.Forms.Button();
			this.KeyLength = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StackWalk
			// 
			this.StackWalk.Location = new System.Drawing.Point(8, 16);
			this.StackWalk.Name = "StackWalk";
			this.StackWalk.Size = new System.Drawing.Size(160, 23);
			this.StackWalk.TabIndex = 0;
			this.StackWalk.Text = "01 - StackWalk";
			this.StackWalk.Click += new System.EventHandler(this.StackWalk_Click);
			// 
			// PermissionSet
			// 
			this.PermissionSet.Location = new System.Drawing.Point(8, 54);
			this.PermissionSet.Name = "PermissionSet";
			this.PermissionSet.Size = new System.Drawing.Size(160, 23);
			this.PermissionSet.TabIndex = 0;
			this.PermissionSet.Text = "02 -Permission Set";
			this.PermissionSet.Click += new System.EventHandler(this.PermissionSet_Click);
			// 
			// Demands
			// 
			this.Demands.Location = new System.Drawing.Point(8, 88);
			this.Demands.Name = "Demands";
			this.Demands.Size = new System.Drawing.Size(160, 23);
			this.Demands.TabIndex = 0;
			this.Demands.Text = "03 - Demands";
			this.Demands.Click += new System.EventHandler(this.Demands_Click);
			// 
			// Asserts
			// 
			this.Asserts.Location = new System.Drawing.Point(8, 120);
			this.Asserts.Name = "Asserts";
			this.Asserts.Size = new System.Drawing.Size(160, 23);
			this.Asserts.TabIndex = 0;
			this.Asserts.Text = "04 - Asserts";
			this.Asserts.Click += new System.EventHandler(this.Asserts_Click);
			// 
			// PublicPrivate
			// 
			this.PublicPrivate.Location = new System.Drawing.Point(8, 152);
			this.PublicPrivate.Name = "PublicPrivate";
			this.PublicPrivate.Size = new System.Drawing.Size(160, 23);
			this.PublicPrivate.TabIndex = 0;
			this.PublicPrivate.Text = "05 - Public vs Private";
			this.PublicPrivate.Click += new System.EventHandler(this.PublicPrivate_Click);
			// 
			// KeyLength
			// 
			this.KeyLength.Location = new System.Drawing.Point(8, 184);
			this.KeyLength.Name = "KeyLength";
			this.KeyLength.Size = new System.Drawing.Size(160, 23);
			this.KeyLength.TabIndex = 0;
			this.KeyLength.Text = "06 - Key Length";
			this.KeyLength.Click += new System.EventHandler(this.KeyLength_Click);
			// 
			// SecuritySwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(184, 230);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.StackWalk,
																		  this.PermissionSet,
																		  this.Demands,
																		  this.Asserts,
																		  this.PublicPrivate,
																		  this.KeyLength});
			this.Name = "SecuritySwitch";
			this.ShowInTaskbar = false;
			this.Text = "SecuritySwitch";
			this.ResumeLayout(false);

		}
		#endregion

		private void StackWalk_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new StackWalk()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void PermissionSet_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PermissionSet()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void Demands_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new Demands()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void Asserts_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new Asserts()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void PublicPrivate_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PublicPrivate()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);				
		}

		private void KeyLength_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new KeyLength()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}
	}
}
