using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PerfTest.Languages {
	/// <summary>
	/// Summary description for LanguageSwitch.
	/// </summary>
	public class LanguageSwitch : System.Windows.Forms.Form {
		private System.Windows.Forms.Button LateBound;
		private System.Windows.Forms.Button IsKeyword;
		private System.Windows.Forms.Button VBCollVsHT;
		private System.Windows.Forms.Button VBColVsAL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LanguageSwitch() {
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
			this.LateBound = new System.Windows.Forms.Button();
			this.IsKeyword = new System.Windows.Forms.Button();
			this.VBCollVsHT = new System.Windows.Forms.Button();
			this.VBColVsAL = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LateBound
			// 
			this.LateBound.Location = new System.Drawing.Point(8, 72);
			this.LateBound.Name = "LateBound";
			this.LateBound.Size = new System.Drawing.Size(232, 24);
			this.LateBound.TabIndex = 0;
			this.LateBound.Text = "03 - VB - Late Bound";
			this.LateBound.Click += new System.EventHandler(this.LateBound_Click);
			// 
			// IsKeyword
			// 
			this.IsKeyword.Location = new System.Drawing.Point(8, 104);
			this.IsKeyword.Name = "IsKeyword";
			this.IsKeyword.Size = new System.Drawing.Size(232, 24);
			this.IsKeyword.TabIndex = 0;
			this.IsKeyword.Text = "04 - C# - Is Keyword";
			this.IsKeyword.Click += new System.EventHandler(this.IsKeyword_Click);
			// 
			// VBCollVsHT
			// 
			this.VBCollVsHT.Location = new System.Drawing.Point(8, 8);
			this.VBCollVsHT.Name = "VBCollVsHT";
			this.VBCollVsHT.Size = new System.Drawing.Size(232, 24);
			this.VBCollVsHT.TabIndex = 0;
			this.VBCollVsHT.Text = "01 - VB - Collection vs Hashtable";
			this.VBCollVsHT.Click += new System.EventHandler(this.VBColl_Click);
			// 
			// VBColVsAL
			// 
			this.VBColVsAL.Location = new System.Drawing.Point(8, 40);
			this.VBColVsAL.Name = "VBColVsAL";
			this.VBColVsAL.Size = new System.Drawing.Size(232, 24);
			this.VBColVsAL.TabIndex = 0;
			this.VBColVsAL.Text = "02 - VB - Collection Vs ArrayList";
			this.VBColVsAL.Click += new System.EventHandler(this.VBColVsAL_Click);
			// 
			// LanguageSwitch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 142);
			this.Controls.Add(this.LateBound);
			this.Controls.Add(this.IsKeyword);
			this.Controls.Add(this.VBCollVsHT);
			this.Controls.Add(this.VBColVsAL);
			this.Name = "LanguageSwitch";
			this.ShowInTaskbar = false;
			this.Text = "LanguageSwitch";
			this.ResumeLayout(false);

		}
		#endregion

		private void LateBound_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new LateBound()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void IsKeyword_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new IsKeyword()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void VBColl_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new VBCollectionVsHashtable()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);			
		}

		private void VBColVsAL_Click(object sender, System.EventArgs e) {
			DotNetPerformance.ResultOutput.Output.DisplayResults((new VBCollectionVsArrayList()).RunTest(),
				PerfTest.FormMain.CurrentDisplay ,PerfTest.FormMain.DisplayConfigSetting);					
		}
	}
}
