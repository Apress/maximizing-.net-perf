using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.Interop {
	/// <summary>
	/// Summary description for InteropSwitch.
	/// </summary>
	public class InteropSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button ParameterTypes;
		private System.Windows.Forms.Button ParameterDeclarations;
		private System.Windows.Forms.Button HeapStackAlloc;
		private System.Windows.Forms.Button CharSetStringLengthBtn;
		private System.Windows.Forms.Button SuppressSecurityAttributeBtn;
		private System.Windows.Forms.Button ThrowCheckBtn;
		private System.Windows.Forms.Button SuppressSecurityCOMBtn;
		private System.Windows.Forms.Button COMvsPInvoke;
		private System.Windows.Forms.Button ParameterDeclarationsBi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InteropSwitch() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			System.Runtime.InteropServices.Marshal.PrelinkAll(typeof(CharSetTest));
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
			this.ParameterTypes = new System.Windows.Forms.Button();
			this.ParameterDeclarations = new System.Windows.Forms.Button();
			this.HeapStackAlloc = new System.Windows.Forms.Button();
			this.CharSetStringLengthBtn = new System.Windows.Forms.Button();
			this.SuppressSecurityAttributeBtn = new System.Windows.Forms.Button();
			this.ThrowCheckBtn = new System.Windows.Forms.Button();
			this.SuppressSecurityCOMBtn = new System.Windows.Forms.Button();
			this.COMvsPInvoke = new System.Windows.Forms.Button();
			this.ParameterDeclarationsBi = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ParameterTypes
			// 
			this.ParameterTypes.Location = new System.Drawing.Point(8, 8);
			this.ParameterTypes.Name = "ParameterTypes";
			this.ParameterTypes.Size = new System.Drawing.Size(280, 24);
			this.ParameterTypes.TabIndex = 0;
			this.ParameterTypes.Text = "01 - Parameter Types";
			this.ParameterTypes.Click += new System.EventHandler(this.ParameterTypes_Click);
			// 
			// ParameterDeclarations
			// 
			this.ParameterDeclarations.Location = new System.Drawing.Point(8, 72);
			this.ParameterDeclarations.Name = "ParameterDeclarations";
			this.ParameterDeclarations.Size = new System.Drawing.Size(280, 24);
			this.ParameterDeclarations.TabIndex = 0;
			this.ParameterDeclarations.Text = "03 - Parameter Declarations";
			this.ParameterDeclarations.Click += new System.EventHandler(this.ParameterDeclarations_Click);
			// 
			// HeapStackAlloc
			// 
			this.HeapStackAlloc.Location = new System.Drawing.Point(8, 40);
			this.HeapStackAlloc.Name = "HeapStackAlloc";
			this.HeapStackAlloc.Size = new System.Drawing.Size(280, 24);
			this.HeapStackAlloc.TabIndex = 0;
			this.HeapStackAlloc.Text = "02 - Stack vs heap allocation";
			this.HeapStackAlloc.Click += new System.EventHandler(this.HeapStackAlloc_Click);
			// 
			// CharSetStringLengthBtn
			// 
			this.CharSetStringLengthBtn.Location = new System.Drawing.Point(8, 136);
			this.CharSetStringLengthBtn.Name = "CharSetStringLengthBtn";
			this.CharSetStringLengthBtn.Size = new System.Drawing.Size(280, 24);
			this.CharSetStringLengthBtn.TabIndex = 0;
			this.CharSetStringLengthBtn.Text = "05 - CharSet - String Length";
			this.CharSetStringLengthBtn.Click += new System.EventHandler(this.CharSetStringLengthBtn_Click);
			// 
			// SuppressSecurityAttributeBtn
			// 
			this.SuppressSecurityAttributeBtn.Location = new System.Drawing.Point(8, 168);
			this.SuppressSecurityAttributeBtn.Name = "SuppressSecurityAttributeBtn";
			this.SuppressSecurityAttributeBtn.Size = new System.Drawing.Size(280, 24);
			this.SuppressSecurityAttributeBtn.TabIndex = 0;
			this.SuppressSecurityAttributeBtn.Text = "06 - Suppress Security Attribute";
			this.SuppressSecurityAttributeBtn.Click += new System.EventHandler(this.SuppressSecurityAttributeBtn_Click);
			// 
			// ThrowCheckBtn
			// 
			this.ThrowCheckBtn.Location = new System.Drawing.Point(8, 264);
			this.ThrowCheckBtn.Name = "ThrowCheckBtn";
			this.ThrowCheckBtn.Size = new System.Drawing.Size(280, 24);
			this.ThrowCheckBtn.TabIndex = 0;
			this.ThrowCheckBtn.Text = "09 - Throw vs check HR";
			this.ThrowCheckBtn.Click += new System.EventHandler(this.ThrowCheckBtn_Click);
			// 
			// SuppressSecurityCOMBtn
			// 
			this.SuppressSecurityCOMBtn.Location = new System.Drawing.Point(8, 200);
			this.SuppressSecurityCOMBtn.Name = "SuppressSecurityCOMBtn";
			this.SuppressSecurityCOMBtn.Size = new System.Drawing.Size(280, 24);
			this.SuppressSecurityCOMBtn.TabIndex = 0;
			this.SuppressSecurityCOMBtn.Text = "07 - Suppress Security Attribute - COM";
			this.SuppressSecurityCOMBtn.Click += new System.EventHandler(this.SuppressSecurityCOMBtn_Click);
			// 
			// COMvsPInvoke
			// 
			this.COMvsPInvoke.Location = new System.Drawing.Point(8, 232);
			this.COMvsPInvoke.Name = "COMvsPInvoke";
			this.COMvsPInvoke.Size = new System.Drawing.Size(280, 24);
			this.COMvsPInvoke.TabIndex = 0;
			this.COMvsPInvoke.Text = "08 - COM call vs PInvoke Call";
			this.COMvsPInvoke.Click += new System.EventHandler(this.COMvsPInvoke_Click);
			// 
			// ParameterDeclarationsBi
			// 
			this.ParameterDeclarationsBi.Location = new System.Drawing.Point(8, 104);
			this.ParameterDeclarationsBi.Name = "ParameterDeclarationsBi";
			this.ParameterDeclarationsBi.Size = new System.Drawing.Size(280, 24);
			this.ParameterDeclarationsBi.TabIndex = 0;
			this.ParameterDeclarationsBi.Text = "04 - Parameter Declarations (bi-directional)";
			this.ParameterDeclarationsBi.Click += new System.EventHandler(this.ParameterDeclarationsBi_Click);
			// 
			// InteropSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 294);
			this.Controls.Add(this.ParameterTypes);
			this.Controls.Add(this.ParameterDeclarations);
			this.Controls.Add(this.HeapStackAlloc);
			this.Controls.Add(this.CharSetStringLengthBtn);
			this.Controls.Add(this.SuppressSecurityAttributeBtn);
			this.Controls.Add(this.ThrowCheckBtn);
			this.Controls.Add(this.SuppressSecurityCOMBtn);
			this.Controls.Add(this.COMvsPInvoke);
			this.Controls.Add(this.ParameterDeclarationsBi);
			this.Name = "InteropSwitch";
			this.ShowInTaskbar = false;
			this.Text = "InteropSwitch";
			this.ResumeLayout(false);

		}
		#endregion

		private void ParameterTypes_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ParameterTypesTest().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ParameterDeclarations_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ParameterTypesTest().RunTestParamDec(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void ParameterDeclarationsBi_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ParameterTypesTest().RunTestParamDecBi(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void HeapStackAlloc_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new AllocationLocations().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void CharSetBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new CharSetTest().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void CharSetStringLengthBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new CharSetTest().RunTestStringLength(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void SuppressSecurityAttributeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new SuppressSecurity().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void ThrowCheckBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ThrowVsCheck().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);						
		}

		private void SuppressSecurityCOMBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new SuppressSecurityCOM().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void COMvsPInvoke_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new COMvsPInvoke().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void SafeArrayMarshalling_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new SafeArrayMarshalling().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}


	}
}
