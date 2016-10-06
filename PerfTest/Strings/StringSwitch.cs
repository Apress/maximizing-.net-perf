using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.Strings
{
	/// <summary>
	/// Summary description for StringSwitch.
	/// </summary>
	public class StringSwitch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button EqualsBtn;
		private System.Windows.Forms.Button CompareBtn;
		private System.Windows.Forms.Button SBuilderBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOpNumber;
		private System.Windows.Forms.Button EnumButton;
		private System.Windows.Forms.Button InternCompareBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox CompareTxt;
		private System.Windows.Forms.Button FormatingBtn;
		private System.Windows.Forms.Button EmptyTestBtn;
		private System.Windows.Forms.Button RegExCompiled;
		private System.Windows.Forms.Button RegExExpressions;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textA;
		private System.Windows.Forms.Button RegExCase;
		private System.Windows.Forms.Button ReverseBtn;
		private System.Windows.Forms.Button EqualsAndComapreBtn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxOrgString;
		private System.Windows.Forms.TextBox txtBoxAppendString;
		private System.Windows.Forms.TextBox textBoxNumberCompareOps;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button CultureInfoCompareBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StringSwitch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.EqualsBtn = new System.Windows.Forms.Button();
			this.SBuilderBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxOpNumber = new System.Windows.Forms.TextBox();
			this.CompareBtn = new System.Windows.Forms.Button();
			this.EnumButton = new System.Windows.Forms.Button();
			this.InternCompareBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.CompareTxt = new System.Windows.Forms.TextBox();
			this.FormatingBtn = new System.Windows.Forms.Button();
			this.EmptyTestBtn = new System.Windows.Forms.Button();
			this.RegExCompiled = new System.Windows.Forms.Button();
			this.RegExExpressions = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textB = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textA = new System.Windows.Forms.TextBox();
			this.RegExCase = new System.Windows.Forms.Button();
			this.ReverseBtn = new System.Windows.Forms.Button();
			this.EqualsAndComapreBtn = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxOrgString = new System.Windows.Forms.TextBox();
			this.txtBoxAppendString = new System.Windows.Forms.TextBox();
			this.textBoxNumberCompareOps = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CultureInfoCompareBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// EqualsBtn
			// 
			this.EqualsBtn.Location = new System.Drawing.Point(8, 0);
			this.EqualsBtn.Name = "EqualsBtn";
			this.EqualsBtn.Size = new System.Drawing.Size(200, 23);
			this.EqualsBtn.TabIndex = 0;
			this.EqualsBtn.Text = "01 - Equality";
			this.EqualsBtn.Click += new System.EventHandler(this.EqualsBtn_Click);
			// 
			// SBuilderBtn
			// 
			this.SBuilderBtn.Location = new System.Drawing.Point(8, 256);
			this.SBuilderBtn.Name = "SBuilderBtn";
			this.SBuilderBtn.Size = new System.Drawing.Size(200, 23);
			this.SBuilderBtn.TabIndex = 2;
			this.SBuilderBtn.Text = "09 - String Builder";
			this.SBuilderBtn.Click += new System.EventHandler(this.SBuilderBtn_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(216, 256);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Number Operations";
			// 
			// textBoxOpNumber
			// 
			this.textBoxOpNumber.Location = new System.Drawing.Point(336, 256);
			this.textBoxOpNumber.Name = "textBoxOpNumber";
			this.textBoxOpNumber.TabIndex = 4;
			this.textBoxOpNumber.Text = "4";
			// 
			// CompareBtn
			// 
			this.CompareBtn.Location = new System.Drawing.Point(8, 96);
			this.CompareBtn.Name = "CompareBtn";
			this.CompareBtn.Size = new System.Drawing.Size(200, 23);
			this.CompareBtn.TabIndex = 1;
			this.CompareBtn.Text = "04 - Compare vs ToUpper.Equals";
			this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
			// 
			// EnumButton
			// 
			this.EnumButton.Location = new System.Drawing.Point(8, 160);
			this.EnumButton.Name = "EnumButton";
			this.EnumButton.Size = new System.Drawing.Size(200, 23);
			this.EnumButton.TabIndex = 5;
			this.EnumButton.Text = "06 - Enumeration";
			this.EnumButton.Click += new System.EventHandler(this.EnumButton_Click);
			// 
			// InternCompareBtn
			// 
			this.InternCompareBtn.Location = new System.Drawing.Point(8, 224);
			this.InternCompareBtn.Name = "InternCompareBtn";
			this.InternCompareBtn.Size = new System.Drawing.Size(200, 23);
			this.InternCompareBtn.TabIndex = 6;
			this.InternCompareBtn.Text = "08 - Intern Compare";
			this.InternCompareBtn.Click += new System.EventHandler(this.InternCompareBtn_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(216, 224);
			this.label2.Name = "label2";
			this.label2.TabIndex = 7;
			this.label2.Text = "Compare To:";
			// 
			// CompareTxt
			// 
			this.CompareTxt.Location = new System.Drawing.Point(336, 224);
			this.CompareTxt.Name = "CompareTxt";
			this.CompareTxt.TabIndex = 8;
			this.CompareTxt.Text = "";
			// 
			// FormatingBtn
			// 
			this.FormatingBtn.Location = new System.Drawing.Point(8, 128);
			this.FormatingBtn.Name = "FormatingBtn";
			this.FormatingBtn.Size = new System.Drawing.Size(200, 23);
			this.FormatingBtn.TabIndex = 9;
			this.FormatingBtn.Text = "05 - Formating";
			this.FormatingBtn.Click += new System.EventHandler(this.FormatingBtn_Click);
			// 
			// EmptyTestBtn
			// 
			this.EmptyTestBtn.Location = new System.Drawing.Point(8, 192);
			this.EmptyTestBtn.Name = "EmptyTestBtn";
			this.EmptyTestBtn.Size = new System.Drawing.Size(200, 23);
			this.EmptyTestBtn.TabIndex = 9;
			this.EmptyTestBtn.Text = "07 - Empty Test";
			this.EmptyTestBtn.Click += new System.EventHandler(this.EmptyTestBtn_Click);
			// 
			// RegExCompiled
			// 
			this.RegExCompiled.Location = new System.Drawing.Point(8, 320);
			this.RegExCompiled.Name = "RegExCompiled";
			this.RegExCompiled.Size = new System.Drawing.Size(200, 23);
			this.RegExCompiled.TabIndex = 9;
			this.RegExCompiled.Text = "11 - RegEx Compiled";
			this.RegExCompiled.Click += new System.EventHandler(this.RegExCompiled_Click);
			// 
			// RegExExpressions
			// 
			this.RegExExpressions.Location = new System.Drawing.Point(8, 384);
			this.RegExExpressions.Name = "RegExExpressions";
			this.RegExExpressions.Size = new System.Drawing.Size(200, 23);
			this.RegExExpressions.TabIndex = 9;
			this.RegExExpressions.Text = "13 - RegEx Expressions";
			this.RegExExpressions.Click += new System.EventHandler(this.RegExExpressions_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(208, 384);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "A";
			// 
			// textB
			// 
			this.textB.Location = new System.Drawing.Point(392, 384);
			this.textB.Name = "textB";
			this.textB.TabIndex = 8;
			this.textB.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(360, 384);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "B";
			// 
			// textA
			// 
			this.textA.Location = new System.Drawing.Point(256, 384);
			this.textA.Name = "textA";
			this.textA.TabIndex = 8;
			this.textA.Text = "";
			// 
			// RegExCase
			// 
			this.RegExCase.Location = new System.Drawing.Point(8, 352);
			this.RegExCase.Name = "RegExCase";
			this.RegExCase.Size = new System.Drawing.Size(200, 23);
			this.RegExCase.TabIndex = 9;
			this.RegExCase.Text = "12- RegEx Case";
			this.RegExCase.Click += new System.EventHandler(this.RegExCase_Click);
			// 
			// ReverseBtn
			// 
			this.ReverseBtn.Location = new System.Drawing.Point(8, 288);
			this.ReverseBtn.Name = "ReverseBtn";
			this.ReverseBtn.Size = new System.Drawing.Size(200, 23);
			this.ReverseBtn.TabIndex = 9;
			this.ReverseBtn.Text = "10 - Reverse";
			this.ReverseBtn.Click += new System.EventHandler(this.Reverse_Click);
			// 
			// EqualsAndComapreBtn
			// 
			this.EqualsAndComapreBtn.Location = new System.Drawing.Point(8, 64);
			this.EqualsAndComapreBtn.Name = "EqualsAndComapreBtn";
			this.EqualsAndComapreBtn.Size = new System.Drawing.Size(200, 23);
			this.EqualsAndComapreBtn.TabIndex = 11;
			this.EqualsAndComapreBtn.Text = " 03 - Equality and Compare";
			this.EqualsAndComapreBtn.Click += new System.EventHandler(this.EqualsAndComapreBtn_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(448, 256);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "Original String";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(664, 256);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "Append String";
			// 
			// textBoxOrgString
			// 
			this.textBoxOrgString.Location = new System.Drawing.Point(560, 256);
			this.textBoxOrgString.Name = "textBoxOrgString";
			this.textBoxOrgString.TabIndex = 12;
			this.textBoxOrgString.Text = "";
			// 
			// txtBoxAppendString
			// 
			this.txtBoxAppendString.Location = new System.Drawing.Point(784, 256);
			this.txtBoxAppendString.Name = "txtBoxAppendString";
			this.txtBoxAppendString.TabIndex = 12;
			this.txtBoxAppendString.Text = "";
			// 
			// textBoxNumberCompareOps
			// 
			this.textBoxNumberCompareOps.Location = new System.Drawing.Point(336, 96);
			this.textBoxNumberCompareOps.Name = "textBoxNumberCompareOps";
			this.textBoxNumberCompareOps.TabIndex = 4;
			this.textBoxNumberCompareOps.Text = "4";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(216, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "Number Operations";
			// 
			// CultureInfoCompareBtn
			// 
			this.CultureInfoCompareBtn.Location = new System.Drawing.Point(8, 32);
			this.CultureInfoCompareBtn.Name = "CultureInfoCompareBtn";
			this.CultureInfoCompareBtn.Size = new System.Drawing.Size(200, 23);
			this.CultureInfoCompareBtn.TabIndex = 9;
			this.CultureInfoCompareBtn.Text = "02 - CultureInfo Compare";
			this.CultureInfoCompareBtn.Click += new System.EventHandler(this.CultureInfoCompareBtn_Click);
			// 
			// StringSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 438);
			this.Controls.Add(this.textBoxOrgString);
			this.Controls.Add(this.EqualsAndComapreBtn);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.CompareTxt);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.InternCompareBtn);
			this.Controls.Add(this.EnumButton);
			this.Controls.Add(this.textBoxOpNumber);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SBuilderBtn);
			this.Controls.Add(this.CompareBtn);
			this.Controls.Add(this.EqualsBtn);
			this.Controls.Add(this.FormatingBtn);
			this.Controls.Add(this.EmptyTestBtn);
			this.Controls.Add(this.RegExCompiled);
			this.Controls.Add(this.RegExExpressions);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textB);
			this.Controls.Add(this.textA);
			this.Controls.Add(this.RegExCase);
			this.Controls.Add(this.ReverseBtn);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtBoxAppendString);
			this.Controls.Add(this.textBoxNumberCompareOps);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.CultureInfoCompareBtn);
			this.Name = "StringSwitch";
			this.ShowInTaskbar = false;
			this.Text = "Strings and Text";
			this.ResumeLayout(false);

		}
		#endregion

		private void EqualsBtn_Click(object sender, System.EventArgs e)
		{
			DotNetPerformance.ResultOutput.Output.DisplayResults(ValueRefTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void CompareBtn_Click(object sender, System.EventArgs e)
		{
			int noOps = Convert.ToInt32(textBoxNumberCompareOps.Text);
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CompareTest(noOps)).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void SBuilderBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				StringBuilderTest sbt = new StringBuilderTest(Int32.Parse(textBoxOpNumber.Text), textBoxOrgString.Text, txtBoxAppendString.Text);
				DotNetPerformance.ResultOutput.Output.DisplayResults(sbt.RunTest(),
					PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
			}
			catch(Exception ex){MessageBox.Show("Please enter a valid number");System.Diagnostics.Trace.WriteLine(ex.Message);}
		}

		private void EnumButton_Click(object sender, System.EventArgs e)
		{
			DotNetPerformance.ResultOutput.Output.DisplayResults(EnumTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void InternCompareBtn_Click(object sender, System.EventArgs e)
		{
			InternCompareTest ict = new InternCompareTest(CompareTxt.Text);
			DotNetPerformance.ResultOutput.Output.DisplayResults(ict.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void FormatingBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(Formatting.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void EmptyTestBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(EmptyTest.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void StringBuilderBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new StringBuilderSize().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void RegExCompiled_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new RegExCompiled().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void RegExExpressions_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new RegExCompare(textA.Text, textB.Text).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void RegExCase_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(new RegExCase().RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);				
		}

		private void Reverse_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(Reverse.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void EqualsAndComapreBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new EqualsAndCompare()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}

		private void CultureInfoCompareBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CultureInfoCompare()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);		
		}
	}
}
