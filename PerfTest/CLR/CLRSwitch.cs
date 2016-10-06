using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.CLR
{
	/// <summary>
	/// Summary description for CLRSwitch.
	/// </summary>
	public class CLRSwitch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CheckedCodeBtn;
		private System.Windows.Forms.Button DomainLoadingBtn;
		private System.Windows.Forms.Button CreateInstance;
		private System.Windows.Forms.Button InvokeBtn;
		private System.Windows.Forms.Button MarkerInterfacesBtn;
		private System.Windows.Forms.Button MarkerInterfacesCreationBtn;
		private System.Windows.Forms.Button ConvertvsCast;
		private System.Windows.Forms.Button JIT;
		private System.Windows.Forms.Button DecimalBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CLRSwitch()
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
			this.CheckedCodeBtn = new System.Windows.Forms.Button();
			this.DomainLoadingBtn = new System.Windows.Forms.Button();
			this.CreateInstance = new System.Windows.Forms.Button();
			this.InvokeBtn = new System.Windows.Forms.Button();
			this.MarkerInterfacesBtn = new System.Windows.Forms.Button();
			this.MarkerInterfacesCreationBtn = new System.Windows.Forms.Button();
			this.ConvertvsCast = new System.Windows.Forms.Button();
			this.JIT = new System.Windows.Forms.Button();
			this.DecimalBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CheckedCodeBtn
			// 
			this.CheckedCodeBtn.Location = new System.Drawing.Point(8, 144);
			this.CheckedCodeBtn.Name = "CheckedCodeBtn";
			this.CheckedCodeBtn.Size = new System.Drawing.Size(240, 23);
			this.CheckedCodeBtn.TabIndex = 0;
			this.CheckedCodeBtn.Text = "05 - Checked Code";
			this.CheckedCodeBtn.Click += new System.EventHandler(this.CheckedCodeBtn_Click);
			// 
			// DomainLoadingBtn
			// 
			this.DomainLoadingBtn.Location = new System.Drawing.Point(8, 16);
			this.DomainLoadingBtn.Name = "DomainLoadingBtn";
			this.DomainLoadingBtn.Size = new System.Drawing.Size(240, 23);
			this.DomainLoadingBtn.TabIndex = 0;
			this.DomainLoadingBtn.Text = "01 - Domain Loading";
			this.DomainLoadingBtn.Click += new System.EventHandler(this.DomainLoadingBtn_Click);
			// 
			// CreateInstance
			// 
			this.CreateInstance.Location = new System.Drawing.Point(8, 240);
			this.CreateInstance.Name = "CreateInstance";
			this.CreateInstance.Size = new System.Drawing.Size(240, 23);
			this.CreateInstance.TabIndex = 0;
			this.CreateInstance.Text = "08 - CreateInstance";
			this.CreateInstance.Click += new System.EventHandler(this.CreateInstance_Click);
			// 
			// InvokeBtn
			// 
			this.InvokeBtn.Location = new System.Drawing.Point(8, 208);
			this.InvokeBtn.Name = "InvokeBtn";
			this.InvokeBtn.Size = new System.Drawing.Size(240, 23);
			this.InvokeBtn.TabIndex = 0;
			this.InvokeBtn.Text = "07 - Invoke";
			this.InvokeBtn.Click += new System.EventHandler(this.InvokeBtn_Click);
			// 
			// MarkerInterfacesBtn
			// 
			this.MarkerInterfacesBtn.Location = new System.Drawing.Point(8, 112);
			this.MarkerInterfacesBtn.Name = "MarkerInterfacesBtn";
			this.MarkerInterfacesBtn.Size = new System.Drawing.Size(240, 23);
			this.MarkerInterfacesBtn.TabIndex = 0;
			this.MarkerInterfacesBtn.Text = "04 - Marker Interfaces";
			this.MarkerInterfacesBtn.Click += new System.EventHandler(this.MarkerInterfacesBtn_Click);
			// 
			// MarkerInterfacesCreationBtn
			// 
			this.MarkerInterfacesCreationBtn.Location = new System.Drawing.Point(8, 80);
			this.MarkerInterfacesCreationBtn.Name = "MarkerInterfacesCreationBtn";
			this.MarkerInterfacesCreationBtn.Size = new System.Drawing.Size(240, 23);
			this.MarkerInterfacesCreationBtn.TabIndex = 0;
			this.MarkerInterfacesCreationBtn.Text = "03 - Marker Interfaces Creation";
			this.MarkerInterfacesCreationBtn.Click += new System.EventHandler(this.MarkerInterfacesCreationBtn_Click);
			// 
			// ConvertvsCast
			// 
			this.ConvertvsCast.Location = new System.Drawing.Point(8, 272);
			this.ConvertvsCast.Name = "ConvertvsCast";
			this.ConvertvsCast.Size = new System.Drawing.Size(240, 23);
			this.ConvertvsCast.TabIndex = 0;
			this.ConvertvsCast.Text = "09 Convert vs Cast";
			this.ConvertvsCast.Click += new System.EventHandler(this.ConvertvsCast_Click);
			// 
			// JIT
			// 
			this.JIT.Location = new System.Drawing.Point(8, 48);
			this.JIT.Name = "JIT";
			this.JIT.Size = new System.Drawing.Size(240, 23);
			this.JIT.TabIndex = 0;
			this.JIT.Text = "02 - NGEN vs JIT";
			this.JIT.Click += new System.EventHandler(this.JIT_Click);
			// 
			// DecimalBtn
			// 
			this.DecimalBtn.Location = new System.Drawing.Point(8, 176);
			this.DecimalBtn.Name = "DecimalBtn";
			this.DecimalBtn.Size = new System.Drawing.Size(240, 23);
			this.DecimalBtn.TabIndex = 0;
			this.DecimalBtn.Text = "06 - Decimal";
			this.DecimalBtn.Click += new System.EventHandler(this.DecimalBtn_Click);
			// 
			// CLRSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 350);
			this.Controls.Add(this.CheckedCodeBtn);
			this.Controls.Add(this.DomainLoadingBtn);
			this.Controls.Add(this.CreateInstance);
			this.Controls.Add(this.InvokeBtn);
			this.Controls.Add(this.MarkerInterfacesBtn);
			this.Controls.Add(this.MarkerInterfacesCreationBtn);
			this.Controls.Add(this.ConvertvsCast);
			this.Controls.Add(this.JIT);
			this.Controls.Add(this.DecimalBtn);
			this.Name = "CLRSwitch";
			this.ShowInTaskbar = false;
			this.Text = "CLR";
			this.ResumeLayout(false);

		}
		#endregion

		private void CheckedCodeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new CheckedCode().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void DomainLoadingBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new DomainLoading().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void CreateInstance_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new CreateInstanceTest().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void MarkerInterfacesBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new MarkerInterfaces().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void MarkerInterfacesCreationBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new MarkerInterfacesCreation().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void InvokeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new Invoke().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);				
		}

		private void ConvertvsCast_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ConvertvsCast().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void JIT_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new JIT().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);				
		}

		private void SqlTypesBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new Paging().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void DecimalBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new DecimalTestCase().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);				
		}
	}
}
