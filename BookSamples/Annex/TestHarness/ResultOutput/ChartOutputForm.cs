using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DotNetPerformance.ResultOutput
{
	/// <summary>
	/// Summary description for ChartOutputForm.
	/// </summary>
	public class ChartOutputForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox ChartStyleCmbo;
		private System.Windows.Forms.Label label1;

		private int _currentIndex = 1;
		private AxMSChart20Lib.AxMSChart axMSChart1;
		private DotNetPerformance.TestResult[] _results;
		public DotNetPerformance.TestResult[] TestResults {get {return _results;}}

		public ChartOutputForm(DotNetPerformance.TestResult[] Results)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_results = Results;

			ChartStyleCmbo.SelectedIndex = 1;
			SetDisplayData(true);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ChartOutputForm));
			this.ChartStyleCmbo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.axMSChart1 = new AxMSChart20Lib.AxMSChart();
			((System.ComponentModel.ISupportInitialize)(this.axMSChart1)).BeginInit();
			this.SuspendLayout();
			// 
			// ChartStyleCmbo
			// 
			this.ChartStyleCmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ChartStyleCmbo.Items.AddRange(new object[] {
																"Summay",
																"Detailed"});
			this.ChartStyleCmbo.Location = new System.Drawing.Point(8, 8);
			this.ChartStyleCmbo.Name = "ChartStyleCmbo";
			this.ChartStyleCmbo.Size = new System.Drawing.Size(121, 21);
			this.ChartStyleCmbo.TabIndex = 1;
			this.ChartStyleCmbo.SelectedIndexChanged += new System.EventHandler(this.ChartStyleCmbo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(336, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Hold down Ctrl to Rotate.  Click on a bar to display value.";
			// 
			// axMSChart1
			// 
			this.axMSChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.axMSChart1.DataSource = null;
			this.axMSChart1.Location = new System.Drawing.Point(0, 32);
			this.axMSChart1.Name = "axMSChart1";
			this.axMSChart1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMSChart1.OcxState")));
			this.axMSChart1.Size = new System.Drawing.Size(680, 496);
			this.axMSChart1.TabIndex = 3;
			this.axMSChart1.PointSelected += new AxMSChart20Lib._DMSChartEvents_PointSelectedEventHandler(this.axMSChart1_PointSelected);
			// 
			// ChartOutputForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 533);
			this.Controls.Add(this.axMSChart1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ChartStyleCmbo);
			this.Name = "ChartOutputForm";
			this.ShowInTaskbar = false;
			this.Text = "ChartOutputForm";
			this.Load += new System.EventHandler(this.ChartOutputForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.axMSChart1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ChartOutputForm_Load(object sender, System.EventArgs e) {
			ChartStyleCmbo.SelectedIndex = 1;
			SetDisplayData(true);
		}

		private void ChartStyleCmbo_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (_currentIndex == ChartStyleCmbo.SelectedIndex)
				return;
			_currentIndex = ChartStyleCmbo.SelectedIndex;
			axMSChart1.ToDefaults();
			SetDisplayData(ChartStyleCmbo.SelectedIndex == 1);
		}

		private void SetDisplayData(bool DetailedResults){
			if (DetailedResults){
				this.label1.Visible = true;
				axMSChart1.chartType = MSChart20Lib.VtChChartType.VtChChartType3dBar;
				axMSChart1.AllowDynamicRotation = true;
				object[,] displayData = new object[_results.Length, 5];
				for (int cnt = 0; cnt < _results.Length; ++cnt){
					displayData[cnt, 0] = _results[cnt].TestName;
					displayData[cnt, 1] = _results[cnt].Min.TotalSeconds;
					displayData[cnt, 2] = _results[cnt].Median.TotalSeconds;
					displayData[cnt, 3] = _results[cnt].Max.TotalSeconds;
					displayData[cnt, 4] = _results[cnt].NormalizedTestDuration;
				}
				axMSChart1.ChartData = displayData;
				axMSChart1.ColumnCount = 4;
				axMSChart1.ColumnLabelCount = 4;

				axMSChart1.Column = 1;
				axMSChart1.ColumnLabel = "Min";
				axMSChart1.Column = 2;
				axMSChart1.ColumnLabel = "Median";
				axMSChart1.Column = 3;
				axMSChart1.ColumnLabel = "Max";
				axMSChart1.Column = 4;
				axMSChart1.ColumnLabel = "Normalised Median";

				axMSChart1.Plot.SeriesCollection[4].SecondaryAxis = true; //NormalisedTimeSpan on second y axis 

				axMSChart1.ShowLegend = true;
				axMSChart1.Plot.get_Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX, 1).AxisTitle.Text = "Tests Run";
				axMSChart1.Plot.get_Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY, 1).AxisTitle.Text = "Run Time (s)";
				axMSChart1.Plot.get_Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY2, 1).AxisTitle.Text = "Normalised Median";
			}
			else{
				this.label1.Visible = false;
				axMSChart1.ShowLegend = false;
				axMSChart1.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar;
				object[,] displayData = new object[_results.Length, 2];
				for (int cnt = 0; cnt < _results.Length; ++cnt){
					displayData[cnt, 0] = _results[cnt].TestName;
					displayData[cnt, 1] = _results[cnt].NormalizedTestDuration;
				}
				axMSChart1.ChartData = displayData;
				axMSChart1.ColumnCount = 1;
				axMSChart1.ColumnLabelCount = 1;
				axMSChart1.Title.Text = "Normalised Median";
				axMSChart1.Refresh();
			}
		}

		private void axMSChart1_PointSelected(object sender, AxMSChart20Lib._DMSChartEvents_PointSelectedEvent e) {
			this.label1.Visible = true;
			axMSChart1.Column = e.series;
			axMSChart1.Row = e.dataPoint;
			this.label1.Text = axMSChart1.RowLabel + ":\t" + axMSChart1.Data.ToString();
		}

	}
}
