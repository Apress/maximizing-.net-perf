using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Collections
{
	/// <summary>
	/// Summary description for CollectionSwitch.
	/// </summary>
	public class CollectionSwitch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button StrongTypedValueTypeBtn;
		private System.Windows.Forms.Button StrongTypedValueTypeEnumBtn;
		private System.Windows.Forms.Button StrongTypedIntEnum;
		private System.Windows.Forms.Button JaggedArrayBtn;
		private System.Windows.Forms.Button ArrayInitialisationBtn;
		private System.Windows.Forms.Button StrongTypedIntBtn;
		private System.Windows.Forms.Button ReferenceTypeEnum;
		private System.Windows.Forms.Button ReferenceTypeEnumCol;
		private System.Windows.Forms.Button LoopTermination;
		private System.Windows.Forms.Button LoopInvariants;
		private System.Windows.Forms.Button Synchronized;
		private System.Windows.Forms.Button HashCode;
		private System.Windows.Forms.Button UnsafeBtn;
		private System.Windows.Forms.Button UnsafeCopyBtn;
		private System.Windows.Forms.Button JaggedArrayNonprimitiveBtn;
		private System.Windows.Forms.Button StackAllocationBtn;
		private System.Windows.Forms.Button UnsafeStructBtn;
		private System.Windows.Forms.Button WrappedValueTypeBtn;
		private System.Windows.Forms.Button StrongTypedStringEnumBtn;
		private System.Windows.Forms.Button StrongTypedStringBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CollectionSwitch()
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
			this.StrongTypedValueTypeBtn = new System.Windows.Forms.Button();
			this.StrongTypedValueTypeEnumBtn = new System.Windows.Forms.Button();
			this.StrongTypedIntEnum = new System.Windows.Forms.Button();
			this.JaggedArrayBtn = new System.Windows.Forms.Button();
			this.ArrayInitialisationBtn = new System.Windows.Forms.Button();
			this.StrongTypedIntBtn = new System.Windows.Forms.Button();
			this.ReferenceTypeEnum = new System.Windows.Forms.Button();
			this.ReferenceTypeEnumCol = new System.Windows.Forms.Button();
			this.LoopTermination = new System.Windows.Forms.Button();
			this.LoopInvariants = new System.Windows.Forms.Button();
			this.Synchronized = new System.Windows.Forms.Button();
			this.HashCode = new System.Windows.Forms.Button();
			this.UnsafeBtn = new System.Windows.Forms.Button();
			this.UnsafeCopyBtn = new System.Windows.Forms.Button();
			this.JaggedArrayNonprimitiveBtn = new System.Windows.Forms.Button();
			this.StackAllocationBtn = new System.Windows.Forms.Button();
			this.UnsafeStructBtn = new System.Windows.Forms.Button();
			this.WrappedValueTypeBtn = new System.Windows.Forms.Button();
			this.StrongTypedStringEnumBtn = new System.Windows.Forms.Button();
			this.StrongTypedStringBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StrongTypedValueTypeBtn
			// 
			this.StrongTypedValueTypeBtn.Location = new System.Drawing.Point(8, 296);
			this.StrongTypedValueTypeBtn.Name = "StrongTypedValueTypeBtn";
			this.StrongTypedValueTypeBtn.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedValueTypeBtn.TabIndex = 0;
			this.StrongTypedValueTypeBtn.Text = "10 - Strong Typed Double - Basic";
			this.StrongTypedValueTypeBtn.Click += new System.EventHandler(this.StrongTypedValueTypeBtn_Click);
			// 
			// StrongTypedValueTypeEnumBtn
			// 
			this.StrongTypedValueTypeEnumBtn.Location = new System.Drawing.Point(248, 8);
			this.StrongTypedValueTypeEnumBtn.Name = "StrongTypedValueTypeEnumBtn";
			this.StrongTypedValueTypeEnumBtn.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedValueTypeEnumBtn.TabIndex = 0;
			this.StrongTypedValueTypeEnumBtn.Text = "11 - Strong Typed Double - Enum";
			this.StrongTypedValueTypeEnumBtn.Click += new System.EventHandler(this.StrongTypedValueTypeEnumBtn_Click);
			// 
			// StrongTypedIntEnum
			// 
			this.StrongTypedIntEnum.Location = new System.Drawing.Point(8, 264);
			this.StrongTypedIntEnum.Name = "StrongTypedIntEnum";
			this.StrongTypedIntEnum.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedIntEnum.TabIndex = 0;
			this.StrongTypedIntEnum.Text = "09 - Strong Typed Int - Enum";
			this.StrongTypedIntEnum.Click += new System.EventHandler(this.StrongTypedIntEnum_Click);
			// 
			// JaggedArrayBtn
			// 
			this.JaggedArrayBtn.Location = new System.Drawing.Point(8, 8);
			this.JaggedArrayBtn.Name = "JaggedArrayBtn";
			this.JaggedArrayBtn.Size = new System.Drawing.Size(216, 23);
			this.JaggedArrayBtn.TabIndex = 0;
			this.JaggedArrayBtn.Text = "01 - Jagged Arrays (Value Types)";
			this.JaggedArrayBtn.Click += new System.EventHandler(this.JaggedArrayBtn_Click);
			// 
			// ArrayInitialisationBtn
			// 
			this.ArrayInitialisationBtn.Location = new System.Drawing.Point(8, 72);
			this.ArrayInitialisationBtn.Name = "ArrayInitialisationBtn";
			this.ArrayInitialisationBtn.Size = new System.Drawing.Size(216, 23);
			this.ArrayInitialisationBtn.TabIndex = 1;
			this.ArrayInitialisationBtn.Text = "03 - Array Initialisation";
			this.ArrayInitialisationBtn.Click += new System.EventHandler(this.ArrayInitialisationBtn_Click);
			// 
			// StrongTypedIntBtn
			// 
			this.StrongTypedIntBtn.Location = new System.Drawing.Point(8, 232);
			this.StrongTypedIntBtn.Name = "StrongTypedIntBtn";
			this.StrongTypedIntBtn.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedIntBtn.TabIndex = 0;
			this.StrongTypedIntBtn.Text = "08 - Strong Typed Int - Basic";
			this.StrongTypedIntBtn.Click += new System.EventHandler(this.StrongTypedIntBtn_Click);
			// 
			// ReferenceTypeEnum
			// 
			this.ReferenceTypeEnum.Location = new System.Drawing.Point(248, 104);
			this.ReferenceTypeEnum.Name = "ReferenceTypeEnum";
			this.ReferenceTypeEnum.Size = new System.Drawing.Size(216, 23);
			this.ReferenceTypeEnum.TabIndex = 0;
			this.ReferenceTypeEnum.Text = "14 - ForEach Array";
			this.ReferenceTypeEnum.Click += new System.EventHandler(this.ReferenceTypeEnum_Click);
			// 
			// ReferenceTypeEnumCol
			// 
			this.ReferenceTypeEnumCol.Location = new System.Drawing.Point(248, 136);
			this.ReferenceTypeEnumCol.Name = "ReferenceTypeEnumCol";
			this.ReferenceTypeEnumCol.Size = new System.Drawing.Size(216, 23);
			this.ReferenceTypeEnumCol.TabIndex = 0;
			this.ReferenceTypeEnumCol.Text = "15 - ForEach ArrayList";
			this.ReferenceTypeEnumCol.Click += new System.EventHandler(this.ReferenceTypeEnumCol_Click);
			// 
			// LoopTermination
			// 
			this.LoopTermination.Location = new System.Drawing.Point(248, 168);
			this.LoopTermination.Name = "LoopTermination";
			this.LoopTermination.Size = new System.Drawing.Size(216, 23);
			this.LoopTermination.TabIndex = 0;
			this.LoopTermination.Text = "16 - Loop Termination";
			this.LoopTermination.Click += new System.EventHandler(this.LoopTermination_Click);
			// 
			// LoopInvariants
			// 
			this.LoopInvariants.Location = new System.Drawing.Point(248, 200);
			this.LoopInvariants.Name = "LoopInvariants";
			this.LoopInvariants.Size = new System.Drawing.Size(216, 23);
			this.LoopInvariants.TabIndex = 0;
			this.LoopInvariants.Text = "17 - Loop Invariants";
			this.LoopInvariants.Click += new System.EventHandler(this.LoopInvariants_Click);
			// 
			// Synchronized
			// 
			this.Synchronized.Location = new System.Drawing.Point(248, 232);
			this.Synchronized.Name = "Synchronized";
			this.Synchronized.Size = new System.Drawing.Size(216, 23);
			this.Synchronized.TabIndex = 0;
			this.Synchronized.Text = "18 - Synchronized";
			this.Synchronized.Click += new System.EventHandler(this.Synchronized_Click);
			// 
			// HashCode
			// 
			this.HashCode.Location = new System.Drawing.Point(248, 264);
			this.HashCode.Name = "HashCode";
			this.HashCode.Size = new System.Drawing.Size(216, 23);
			this.HashCode.TabIndex = 0;
			this.HashCode.Text = "19 - HashCode";
			this.HashCode.Click += new System.EventHandler(this.HashCode_Click);
			// 
			// UnsafeBtn
			// 
			this.UnsafeBtn.Location = new System.Drawing.Point(8, 104);
			this.UnsafeBtn.Name = "UnsafeBtn";
			this.UnsafeBtn.Size = new System.Drawing.Size(216, 23);
			this.UnsafeBtn.TabIndex = 0;
			this.UnsafeBtn.Text = "04 - Unsafe array - Long";
			this.UnsafeBtn.Click += new System.EventHandler(this.UnsafeBtn_Click);
			// 
			// UnsafeCopyBtn
			// 
			this.UnsafeCopyBtn.Location = new System.Drawing.Point(8, 168);
			this.UnsafeCopyBtn.Name = "UnsafeCopyBtn";
			this.UnsafeCopyBtn.Size = new System.Drawing.Size(216, 23);
			this.UnsafeCopyBtn.TabIndex = 0;
			this.UnsafeCopyBtn.Text = "06 - Unsafe element copying";
			this.UnsafeCopyBtn.Click += new System.EventHandler(this.UnsafeCopyBtn_Click);
			// 
			// JaggedArrayNonprimitiveBtn
			// 
			this.JaggedArrayNonprimitiveBtn.Location = new System.Drawing.Point(8, 40);
			this.JaggedArrayNonprimitiveBtn.Name = "JaggedArrayNonprimitiveBtn";
			this.JaggedArrayNonprimitiveBtn.Size = new System.Drawing.Size(216, 23);
			this.JaggedArrayNonprimitiveBtn.TabIndex = 1;
			this.JaggedArrayNonprimitiveBtn.Text = "02 - Jagged Array (Reference types)";
			this.JaggedArrayNonprimitiveBtn.Click += new System.EventHandler(this.JaggedArrayNonprimitiveBtn_Click);
			// 
			// StackAllocationBtn
			// 
			this.StackAllocationBtn.Location = new System.Drawing.Point(248, 296);
			this.StackAllocationBtn.Name = "StackAllocationBtn";
			this.StackAllocationBtn.Size = new System.Drawing.Size(216, 23);
			this.StackAllocationBtn.TabIndex = 0;
			this.StackAllocationBtn.Text = "20 - Stack Allocation";
			this.StackAllocationBtn.Click += new System.EventHandler(this.StackAllocationBtn_Click);
			// 
			// UnsafeStructBtn
			// 
			this.UnsafeStructBtn.Location = new System.Drawing.Point(8, 136);
			this.UnsafeStructBtn.Name = "UnsafeStructBtn";
			this.UnsafeStructBtn.Size = new System.Drawing.Size(216, 23);
			this.UnsafeStructBtn.TabIndex = 0;
			this.UnsafeStructBtn.Text = "05 - Unsafe element access - Struct";
			this.UnsafeStructBtn.Click += new System.EventHandler(this.UnsafeStructBtn_Click);
			// 
			// WrappedValueTypeBtn
			// 
			this.WrappedValueTypeBtn.Location = new System.Drawing.Point(8, 200);
			this.WrappedValueTypeBtn.Name = "WrappedValueTypeBtn";
			this.WrappedValueTypeBtn.Size = new System.Drawing.Size(216, 23);
			this.WrappedValueTypeBtn.TabIndex = 0;
			this.WrappedValueTypeBtn.Text = "07 - Wrapped Value Type";
			this.WrappedValueTypeBtn.Click += new System.EventHandler(this.WrappedValueTypeBtn_Click);
			// 
			// StrongTypedStringEnumBtn
			// 
			this.StrongTypedStringEnumBtn.Location = new System.Drawing.Point(248, 72);
			this.StrongTypedStringEnumBtn.Name = "StrongTypedStringEnumBtn";
			this.StrongTypedStringEnumBtn.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedStringEnumBtn.TabIndex = 0;
			this.StrongTypedStringEnumBtn.Text = "13 - Strong Typed String - Enum";
			this.StrongTypedStringEnumBtn.Click += new System.EventHandler(this.StrongTypedStringEnumBtn_Click);
			// 
			// StrongTypedStringBtn
			// 
			this.StrongTypedStringBtn.Location = new System.Drawing.Point(248, 40);
			this.StrongTypedStringBtn.Name = "StrongTypedStringBtn";
			this.StrongTypedStringBtn.Size = new System.Drawing.Size(216, 23);
			this.StrongTypedStringBtn.TabIndex = 0;
			this.StrongTypedStringBtn.Text = "12 - Strong Typed String - Basic";
			this.StrongTypedStringBtn.Click += new System.EventHandler(this.StrongTypedStringBtn_Click);
			// 
			// CollectionSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 358);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ArrayInitialisationBtn,
																		  this.StrongTypedValueTypeBtn,
																		  this.StrongTypedValueTypeEnumBtn,
																		  this.StrongTypedIntEnum,
																		  this.JaggedArrayBtn,
																		  this.StrongTypedIntBtn,
																		  this.ReferenceTypeEnum,
																		  this.ReferenceTypeEnumCol,
																		  this.LoopTermination,
																		  this.LoopInvariants,
																		  this.Synchronized,
																		  this.HashCode,
																		  this.UnsafeBtn,
																		  this.UnsafeCopyBtn,
																		  this.JaggedArrayNonprimitiveBtn,
																		  this.StackAllocationBtn,
																		  this.UnsafeStructBtn,
																		  this.WrappedValueTypeBtn,
																		  this.StrongTypedStringEnumBtn,
																		  this.StrongTypedStringBtn});
			this.Name = "CollectionSwitch";
			this.ShowInTaskbar = false;
			this.Text = "Collections";
			this.ResumeLayout(false);

		}
		#endregion

		private void StrongTypedValueTypeBtn_Click(object sender, System.EventArgs e) {
			StronglyTypedTests bm = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.BasicManipulationDouble(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StrongTypedValueTypeEnumBtn_Click(object sender, System.EventArgs e) {
			StronglyTypedTests enumTest = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(enumTest.EnumerationDouble(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StrongTypedIntBtn_Click(object sender, System.EventArgs e) {
			StronglyTypedTests bm = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.BasicManipulationInt(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StrongTypedIntEnum_Click(object sender, System.EventArgs e) {
			StronglyTypedTests enumTest = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(enumTest.EnumerationInt(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StrongTypedStringBtn_Click(object sender, System.EventArgs e) {
			StronglyTypedTests bm = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.BasicManipulationString(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StrongTypedStringEnumBtn_Click(object sender, System.EventArgs e) {
			StronglyTypedTests enumTest = new StronglyTypedTests();
			DotNetPerformance.ResultOutput.Output.DisplayResults(enumTest.EnumerationString(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}


		private void JaggedArrayBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(JaggedArray.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void JaggedArrayNonprimitiveBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(JaggedArrayNonPrimitive.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ArrayInitialisationBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(ArrayInitialisation.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}


		private void ReferenceTypeEnum_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new Enumeration()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ReferenceTypeEnumCol_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new Enumeration()).ArrayListTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void LoopTermination_Click(object sender, System.EventArgs e) {
			LoopTermination bm = new LoopTermination();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void LoopInvariants_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new LoopInvariants()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void Synchronized_Click(object sender, System.EventArgs e) {
			Synchronized bm = new Synchronized();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void HashCode_Click(object sender, System.EventArgs e) {
			HashCode bm = new HashCode();
			DotNetPerformance.ResultOutput.Output.DisplayResults(bm.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void UnsafeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new UnsafeLong()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void UnsafeCopyBtn_Click(object sender, System.EventArgs e) {
			UnsafeCopy usc = new UnsafeCopy();
			DotNetPerformance.ResultOutput.Output.DisplayResults(usc.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void ArrayListBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new ArrayListTest().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void StackAllocationBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new StackAllocation().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void UnsafeStructBtn_Click(object sender, System.EventArgs e) {
			Unsafe us = new Unsafe();
			DotNetPerformance.ResultOutput.Output.DisplayResults(us.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void WrappedValueTypeBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new WrappedValueType()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}
	}
}
