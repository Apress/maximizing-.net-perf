using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Remoting {
	/// <summary>
	/// Summary description for RemotingSwitch.
	/// </summary>
	public class RemotingSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button CallGranularity;
		private System.Windows.Forms.Button ChannelSelection;
		private System.Windows.Forms.Button ChannelSelectionBinary;
		private System.Windows.Forms.Button ChannelSelectionSOAP;
		private System.Windows.Forms.Button OnWayAttribute;
		private System.Windows.Forms.Button IISHosted;
		private System.Windows.Forms.Button SingletonSingleCall;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RemotingSwitch() {
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
			this.CallGranularity = new System.Windows.Forms.Button();
			this.ChannelSelection = new System.Windows.Forms.Button();
			this.ChannelSelectionBinary = new System.Windows.Forms.Button();
			this.ChannelSelectionSOAP = new System.Windows.Forms.Button();
			this.OnWayAttribute = new System.Windows.Forms.Button();
			this.IISHosted = new System.Windows.Forms.Button();
			this.SingletonSingleCall = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CallGranularity
			// 
			this.CallGranularity.Location = new System.Drawing.Point(8, 16);
			this.CallGranularity.Name = "CallGranularity";
			this.CallGranularity.Size = new System.Drawing.Size(296, 24);
			this.CallGranularity.TabIndex = 0;
			this.CallGranularity.Text = "01 - Call Granularity";
			this.CallGranularity.Click += new System.EventHandler(this.CallGranularity_Click);
			// 
			// ChannelSelection
			// 
			this.ChannelSelection.Location = new System.Drawing.Point(8, 56);
			this.ChannelSelection.Name = "ChannelSelection";
			this.ChannelSelection.Size = new System.Drawing.Size(296, 24);
			this.ChannelSelection.TabIndex = 0;
			this.ChannelSelection.Text = "02 - Channel Selection (Default Formatters)";
			this.ChannelSelection.Click += new System.EventHandler(this.ChannelSelection_Click);
			// 
			// ChannelSelectionBinary
			// 
			this.ChannelSelectionBinary.Location = new System.Drawing.Point(8, 96);
			this.ChannelSelectionBinary.Name = "ChannelSelectionBinary";
			this.ChannelSelectionBinary.Size = new System.Drawing.Size(296, 24);
			this.ChannelSelectionBinary.TabIndex = 0;
			this.ChannelSelectionBinary.Text = "03 - Channel Selection (Binary Formatters)";
			this.ChannelSelectionBinary.Click += new System.EventHandler(this.ChannelSelectionBinary_Click);
			// 
			// ChannelSelectionSOAP
			// 
			this.ChannelSelectionSOAP.Location = new System.Drawing.Point(8, 136);
			this.ChannelSelectionSOAP.Name = "ChannelSelectionSOAP";
			this.ChannelSelectionSOAP.Size = new System.Drawing.Size(296, 24);
			this.ChannelSelectionSOAP.TabIndex = 0;
			this.ChannelSelectionSOAP.Text = "04 - Channel Selection (SOAP Formatters)";
			this.ChannelSelectionSOAP.Click += new System.EventHandler(this.ChannelSelectionSOAP_Click);
			// 
			// OnWayAttribute
			// 
			this.OnWayAttribute.Location = new System.Drawing.Point(8, 216);
			this.OnWayAttribute.Name = "OnWayAttribute";
			this.OnWayAttribute.Size = new System.Drawing.Size(296, 24);
			this.OnWayAttribute.TabIndex = 0;
			this.OnWayAttribute.Text = "06 - OnWay Attribute";
			this.OnWayAttribute.Click += new System.EventHandler(this.OnWayAttribute_Click);
			// 
			// IISHosted
			// 
			this.IISHosted.Location = new System.Drawing.Point(8, 256);
			this.IISHosted.Name = "IISHosted";
			this.IISHosted.Size = new System.Drawing.Size(296, 24);
			this.IISHosted.TabIndex = 0;
			this.IISHosted.Text = "07 - IIS Hosted Objects";
			this.IISHosted.Click += new System.EventHandler(this.IISHosted_Click);
			// 
			// SingletonSingleCall
			// 
			this.SingletonSingleCall.Location = new System.Drawing.Point(8, 176);
			this.SingletonSingleCall.Name = "SingletonSingleCall";
			this.SingletonSingleCall.Size = new System.Drawing.Size(296, 24);
			this.SingletonSingleCall.TabIndex = 0;
			this.SingletonSingleCall.Text = "05 - Singleton vs SingleCall";
			this.SingletonSingleCall.Click += new System.EventHandler(this.SingletonSingleCall_Click);
			// 
			// RemotingSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CallGranularity,
																		  this.ChannelSelection,
																		  this.ChannelSelectionBinary,
																		  this.ChannelSelectionSOAP,
																		  this.OnWayAttribute,
																		  this.IISHosted,
																		  this.SingletonSingleCall});
			this.Name = "RemotingSwitch";
			this.ShowInTaskbar = false;
			this.Text = "Remoting";
			this.Load += new System.EventHandler(this.RemotingSwitch_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CallGranularity_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CallGranularity()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void RemotingSwitch_Load(object sender, System.EventArgs e) {
		}

		private void ChannelSelection_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new ChannelSelection()).RunTestDefault(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ChannelSelectionBinary_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new ChannelSelection()).RunTestBinary(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ChannelSelectionSOAP_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new ChannelSelection()).RunTestSoap(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void OnWayAttribute_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new OneWay()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);	
		}

		private void IISHosted_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.Remoting.IISHosted()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void SingletonSingleCall_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.Remoting.SingletonSingleCall()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}
	}
}
