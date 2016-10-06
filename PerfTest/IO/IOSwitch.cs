using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.IO {
	/// <summary>
	/// Summary description for IOSwitch.
	/// </summary>
	public class IOSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button BufferSize;
		private System.Windows.Forms.Button FormattersBtn;
		private System.Windows.Forms.Button SerializationTechniquesBF;
		private System.Windows.Forms.Button DeserializationTechniquesBF;
		private System.Windows.Forms.Button SerializationTechniquesSF;
		private System.Windows.Forms.Button DeserializationTechniquesSF;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IOSwitch() {
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
			this.BufferSize = new System.Windows.Forms.Button();
			this.SerializationTechniquesBF = new System.Windows.Forms.Button();
			this.DeserializationTechniquesBF = new System.Windows.Forms.Button();
			this.FormattersBtn = new System.Windows.Forms.Button();
			this.SerializationTechniquesSF = new System.Windows.Forms.Button();
			this.DeserializationTechniquesSF = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BufferSize
			// 
			this.BufferSize.Location = new System.Drawing.Point(8, 16);
			this.BufferSize.Name = "BufferSize";
			this.BufferSize.Size = new System.Drawing.Size(296, 23);
			this.BufferSize.TabIndex = 0;
			this.BufferSize.Text = "01 - Buffer Size";
			this.BufferSize.Click += new System.EventHandler(this.BufferSize_Click);
			// 
			// SerializationTechniquesBF
			// 
			this.SerializationTechniquesBF.Location = new System.Drawing.Point(8, 48);
			this.SerializationTechniquesBF.Name = "SerializationTechniquesBF";
			this.SerializationTechniquesBF.Size = new System.Drawing.Size(296, 23);
			this.SerializationTechniquesBF.TabIndex = 0;
			this.SerializationTechniquesBF.Text = "02 - Serialization Techniques with binary formatter";
			this.SerializationTechniquesBF.Click += new System.EventHandler(this.SerializationTechniques_Click);
			// 
			// DeserializationTechniquesBF
			// 
			this.DeserializationTechniquesBF.Location = new System.Drawing.Point(8, 80);
			this.DeserializationTechniquesBF.Name = "DeserializationTechniquesBF";
			this.DeserializationTechniquesBF.Size = new System.Drawing.Size(296, 23);
			this.DeserializationTechniquesBF.TabIndex = 0;
			this.DeserializationTechniquesBF.Text = "03 - Deserialization Techniques with binary formatter";
			this.DeserializationTechniquesBF.Click += new System.EventHandler(this.DeserializationTechniques_Click);
			// 
			// FormattersBtn
			// 
			this.FormattersBtn.Location = new System.Drawing.Point(8, 176);
			this.FormattersBtn.Name = "FormattersBtn";
			this.FormattersBtn.Size = new System.Drawing.Size(296, 23);
			this.FormattersBtn.TabIndex = 0;
			this.FormattersBtn.Text = "06 - Soap vs Binary Formatter";
			this.FormattersBtn.Click += new System.EventHandler(this.FormattersBtn_Click);
			// 
			// SerializationTechniquesSF
			// 
			this.SerializationTechniquesSF.Location = new System.Drawing.Point(8, 112);
			this.SerializationTechniquesSF.Name = "SerializationTechniquesSF";
			this.SerializationTechniquesSF.Size = new System.Drawing.Size(296, 23);
			this.SerializationTechniquesSF.TabIndex = 0;
			this.SerializationTechniquesSF.Text = "04 - Serialization Techniques with soap formatter";
			this.SerializationTechniquesSF.Click += new System.EventHandler(this.SerializationTechniquesSF_Click);
			// 
			// DeserializationTechniquesSF
			// 
			this.DeserializationTechniquesSF.Location = new System.Drawing.Point(8, 144);
			this.DeserializationTechniquesSF.Name = "DeserializationTechniquesSF";
			this.DeserializationTechniquesSF.Size = new System.Drawing.Size(296, 23);
			this.DeserializationTechniquesSF.TabIndex = 0;
			this.DeserializationTechniquesSF.Text = "05 - Deserialization Techniques with soap formatter";
			this.DeserializationTechniquesSF.Click += new System.EventHandler(this.DeserializationTechniquesSF_Click);
			// 
			// IOSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BufferSize,
																		  this.SerializationTechniquesBF,
																		  this.DeserializationTechniquesBF,
																		  this.FormattersBtn,
																		  this.SerializationTechniquesSF,
																		  this.DeserializationTechniquesSF});
			this.Name = "IOSwitch";
			this.ShowInTaskbar = false;
			this.Text = "IOSwitch";
			this.ResumeLayout(false);

		}
		#endregion

		private void CompressedStreamWrite_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CompressedStream()).WriteTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void CompressedStreamRead_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new CompressedStream()).ReadTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void BufferSize_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new BufferSizeTest()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void SerializationTechniques_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.IO.SerializationTechniquesBinary()).SerializationTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void DeserializationTechniques_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.IO.SerializationTechniquesBinary()).DeserializationTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void FormattersBtn_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults(FormatterType.RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void SerializationTechniquesSF_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.IO.SerializationTechniquesSoap()).SerializationTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}

		private void DeserializationTechniquesSF_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new PerfTest.IO.SerializationTechniquesSoap()).DeserializationTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);
		}
	}
}
