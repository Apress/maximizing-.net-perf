using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

namespace DotNetPerformance.ResultOutput {
	public class ChartOutput: Output {
		protected override void OutputResults(TestResultGrp resultGrp, object[] ConfigSettings){
			TestResult[] Results = resultGrp.Results;
			if (Results == null)
				return;

			ChartOutputForm cd = new ChartOutputForm(Results);
			cd.ShowDialog();
		}
	}
}
