using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	/// <summary>
	/// Summary description for ClassDesignSwitch.
	/// </summary>
	public class ClassDesignSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button StructVsClassBtn;
		private System.Windows.Forms.Button StructVsClassParamBtn;
		private System.Windows.Forms.Button PropertiesBtn;
		private System.Windows.Forms.Button AllocationAndParamBtn;
		private System.Windows.Forms.Button TypeConversionBtn;
		private System.Windows.Forms.Button TypeWrapperCostBtn;
		private System.Windows.Forms.Button InitializationBtn;
		private System.Windows.Forms.Button DoubleInitialiseBtn;
		private System.Windows.Forms.Button MethodTypesBtn;
		private System.Windows.Forms.Button BoxingBtn;
		private System.Windows.Forms.Button ValueTypeEqualsBtn;
		private System.Windows.Forms.Button JITInterfaceBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClassDesignSwitch() {
			InitializeComponent();
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
			this.StructVsClassParamBtn = new System.Windows.Forms.Button();
			this.TypeConversionBtn = new System.Windows.Forms.Button();
			this.PropertiesBtn = new System.Windows.Forms.Button();
			this.InitializationBtn = new System.Windows.Forms.Button();
			this.AllocationAndParamBtn = new System.Windows.Forms.Button();
			this.BoxingBtn = new System.Windows.Forms.Button();
			this.StructVsClassBtn = new System.Windows.Forms.Button();
			this.DoubleInitialiseBtn = new System.Windows.Forms.Button();
			this.MethodTypesBtn = new System.Windows.Forms.Button();
			this.ValueTypeEqualsBtn = new System.Windows.Forms.Button();
			this.TypeWrapperCostBtn = new System.Windows.Forms.Button();
			this.JITInterfaceBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StructVsClassParamBtn
			// 
			this.StructVsClassParamBtn.Location = new System.Drawing.Point(8, 48);
			this.StructVsClassParamBtn.Name = "StructVsClassParamBtn";
			this.StructVsClassParamBtn.Size = new System.Drawing.Size(184, 24);
			this.StructVsClassParamBtn.TabIndex = 1;
			this.StructVsClassParamBtn.Text = "02 - Struct vs Class Parameters";
			this.StructVsClassParamBtn.Click += new System.EventHandler(this.StructVsClassParamBtn_Click);
			// 
			// TypeConversionBtn
			// 
			this.TypeConversionBtn.Location = new System.Drawing.Point(216, 48);
			this.TypeConversionBtn.Name = "TypeConversionBtn";
			this.TypeConversionBtn.Size = new System.Drawing.Size(184, 24);
			this.TypeConversionBtn.TabIndex = 5;
			this.TypeConversionBtn.Text = "08 - Explicit vs Implicit conversion";
			this.TypeConversionBtn.Click += new System.EventHandler(this.TypeConversionBtn_Click);
			// 
			// PropertiesBtn
			// 
			this.PropertiesBtn.Location = new System.Drawing.Point(8, 176);
			this.PropertiesBtn.Name = "PropertiesBtn";
			this.PropertiesBtn.Size = new System.Drawing.Size(184, 24);
			this.PropertiesBtn.TabIndex = 2;
			this.PropertiesBtn.Text = "06 - Properties";
			this.PropertiesBtn.Click += new System.EventHandler(this.PropertiesBtn_Click);
			// 
			// InitializationBtn
			// 
			this.InitializationBtn.Location = new System.Drawing.Point(8, 112);
			this.InitializationBtn.Name = "InitializationBtn";
			this.InitializationBtn.Size = new System.Drawing.Size(184, 24);
			this.InitializationBtn.TabIndex = 7;
			this.InitializationBtn.Text = "04 - Initialization";
			this.InitializationBtn.Click += new System.EventHandler(this.InitializationBtn_Click);
			// 
			// AllocationAndParamBtn
			// 
			this.AllocationAndParamBtn.Location = new System.Drawing.Point(8, 80);
			this.AllocationAndParamBtn.Name = "AllocationAndParamBtn";
			this.AllocationAndParamBtn.Size = new System.Drawing.Size(184, 24);
			this.AllocationAndParamBtn.TabIndex = 3;
			this.AllocationAndParamBtn.Text = "03 - Allocation And Params";
			this.AllocationAndParamBtn.Click += new System.EventHandler(this.AllocationAndParamBtn_Click);
			// 
			// BoxingBtn
			// 
			this.BoxingBtn.Location = new System.Drawing.Point(216, 176);
			this.BoxingBtn.Name = "BoxingBtn";
			this.BoxingBtn.Size = new System.Drawing.Size(184, 24);
			this.BoxingBtn.TabIndex = 11;
			this.BoxingBtn.Text = "12 - Primitive Overloads";
			this.BoxingBtn.Click += new System.EventHandler(this.BoxingBtn_Click);
			// 
			// StructVsClassBtn
			// 
			this.StructVsClassBtn.Location = new System.Drawing.Point(8, 16);
			this.StructVsClassBtn.Name = "StructVsClassBtn";
			this.StructVsClassBtn.Size = new System.Drawing.Size(184, 24);
			this.StructVsClassBtn.TabIndex = 0;
			this.StructVsClassBtn.Text = "01 - Struct vs Class Allocation";
			this.StructVsClassBtn.Click += new System.EventHandler(this.StructVsClassBtn_Click);
			// 
			// DoubleInitialiseBtn
			// 
			this.DoubleInitialiseBtn.Location = new System.Drawing.Point(8, 144);
			this.DoubleInitialiseBtn.Name = "DoubleInitialiseBtn";
			this.DoubleInitialiseBtn.Size = new System.Drawing.Size(184, 24);
			this.DoubleInitialiseBtn.TabIndex = 8;
			this.DoubleInitialiseBtn.Text = "05 - Double Initialise";
			this.DoubleInitialiseBtn.Click += new System.EventHandler(this.DoubleInitialiseBtn_Click);
			// 
			// MethodTypesBtn
			// 
			this.MethodTypesBtn.Location = new System.Drawing.Point(216, 112);
			this.MethodTypesBtn.Name = "MethodTypesBtn";
			this.MethodTypesBtn.Size = new System.Drawing.Size(184, 24);
			this.MethodTypesBtn.TabIndex = 9;
			this.MethodTypesBtn.Text = "10 - Method Types";
			this.MethodTypesBtn.Click += new System.EventHandler(this.MethodTypesBtn_Click);
			// 
			// ValueTypeEqualsBtn
			// 
			this.ValueTypeEqualsBtn.Location = new System.Drawing.Point(216, 144);
			this.ValueTypeEqualsBtn.Name = "ValueTypeEqualsBtn";
			this.ValueTypeEqualsBtn.Size = new System.Drawing.Size(184, 24);
			this.ValueTypeEqualsBtn.TabIndex = 13;
			this.ValueTypeEqualsBtn.Text = "11 - Value Type Equals";
			this.ValueTypeEqualsBtn.Click += new System.EventHandler(this.ValueTypeEqualsBtn_Click);
			// 
			// TypeWrapperCostBtn
			// 
			this.TypeWrapperCostBtn.Location = new System.Drawing.Point(216, 80);
			this.TypeWrapperCostBtn.Name = "TypeWrapperCostBtn";
			this.TypeWrapperCostBtn.Size = new System.Drawing.Size(184, 24);
			this.TypeWrapperCostBtn.TabIndex = 6;
			this.TypeWrapperCostBtn.Text = "09- Type Wrapper Cost";
			this.TypeWrapperCostBtn.Click += new System.EventHandler(this.TypeWrapperCostBtn_Click);
			// 
			// JITInterfaceBtn
			// 
			this.JITInterfaceBtn.Location = new System.Drawing.Point(216, 16);
			this.JITInterfaceBtn.Name = "JITInterfaceBtn";
			this.JITInterfaceBtn.Size = new System.Drawing.Size(184, 24);
			this.JITInterfaceBtn.TabIndex = 14;
			this.JITInterfaceBtn.Text = "07 - JIT Interface Implementation";
			this.JITInterfaceBtn.Click += new System.EventHandler(this.JITInterfaceBtn_Click);
			// 
			// ClassDesignSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 213);
			this.Controls.Add(this.JITInterfaceBtn);
			this.Controls.Add(this.ValueTypeEqualsBtn);
			this.Controls.Add(this.BoxingBtn);
			this.Controls.Add(this.MethodTypesBtn);
			this.Controls.Add(this.DoubleInitialiseBtn);
			this.Controls.Add(this.InitializationBtn);
			this.Controls.Add(this.TypeWrapperCostBtn);
			this.Controls.Add(this.TypeConversionBtn);
			this.Controls.Add(this.AllocationAndParamBtn);
			this.Controls.Add(this.PropertiesBtn);
			this.Controls.Add(this.StructVsClassParamBtn);
			this.Controls.Add(this.StructVsClassBtn);
			this.Name = "ClassDesignSwitch";
			this.ShowInTaskbar = false;
			this.Text = "Type Design";
			this.Load += new System.EventHandler(this.ClassDesignSwitch_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void StructVsClassBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(StructVsClassAllocation.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StructVsClassParamBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(StructVsClassParams.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void AllocationAndParamBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(StructVsClassAllocationAndParam.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void InitializationBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(VariableInitializers.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void DoubleInitialiseBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(DoubleInitialise.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void PropertiesBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(Properties.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void JITInterfaceBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(JITInterfaceTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void SealedClassAllocationBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(ClassModifiers.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void TypeConversionBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(TypeConversion.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void TypeWrapperCostBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(TypeWrapper.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void MethodTypesBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(MethodTypes.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void BoxingBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(Boxing.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ValueTypeEqualsBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(ValueTypeEquals.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ClassDesignSwitch_Load(object sender, System.EventArgs e) {
		
		}
	}
}
