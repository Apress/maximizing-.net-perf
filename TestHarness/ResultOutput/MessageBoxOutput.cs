using System;
using DotNetPerformance;

namespace DotNetPerformance.ResultOutput
{
	public class MessageBoxOutput: Output
	{
		protected override void OutputResults(TestResultGrp resultGrp, object[] ConfigSettings){
			if (resultGrp.Results == null)
				return;

			if ((bool)ConfigSettings[0])
				System.Windows.Forms.MessageBox.Show(TestResultFormatter.SummaryResults(resultGrp, "\t", "\n"));
			else
				System.Windows.Forms.MessageBox.Show(TestResultFormatter.DetailedResults(resultGrp, "\t", "\n"));
		}
	}

	public class TestResultFormatter {
		public static string DetailedResults(TestResultGrp resultGrp, string fieldSep, string recordSep) {
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			
			//header stuff
			sb.Append(resultGrp.TestName);
			sb.Append(recordSep);
			sb.Append(resultGrp.Motivation);
			sb.Append(recordSep);
			sb.Append(recordSep);

			//results
			TestResult[] Results = resultGrp.Results;
			foreach (TestResult tr in Results) {
				sb.Append(tr.TestName);	sb.Append(fieldSep);
				sb.Append("Normalised:");	sb.Append(fieldSep);	sb.Append(tr.NormalizedTestDuration);	sb.Append(fieldSep);
				sb.Append("Median:");		sb.Append(fieldSep);	sb.Append(tr.Median);				sb.Append(fieldSep);
				sb.Append("Mean:");			sb.Append(fieldSep);	sb.Append(tr.Mean);					sb.Append(fieldSep);
				sb.Append("Min:");			sb.Append(fieldSep);	sb.Append(tr.Min);					sb.Append(fieldSep);
				sb.Append("Max:");			sb.Append(fieldSep);	sb.Append(tr.Max);					sb.Append(fieldSep);
				sb.Append("StdDev:");		sb.Append(fieldSep);	sb.Append(tr.StdDev);				sb.Append(fieldSep);
				sb.Append("Results:");
				foreach (TimeSpan res in tr.TestResults) {
					sb.Append(res);		sb.Append(fieldSep);
				}
				sb.Append(recordSep);
			}
			return sb.ToString();
		}
		public static string SummaryResults(TestResultGrp resultGrp, string fieldSep, string recordSep) {
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			TestResult[] Results = resultGrp.Results;
			foreach (TestResult tr in Results) {
				sb.Append(tr.TestName);
				sb.Append(" Median: ");
				sb.Append(tr.Median);
				sb.Append(recordSep);
			}
			return sb.ToString();
		}
	}
}
