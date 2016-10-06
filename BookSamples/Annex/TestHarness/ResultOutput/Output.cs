using System;
using DotNetPerformance;

namespace DotNetPerformance.ResultOutput {
	public enum DisplayOption {
		MessageBox,
		Chart,
		File,
		DynamicallyRegistered
	}

	public abstract class Output {
		protected abstract void OutputResults(TestResultGrp Results,
			object[] ConfigSettings);

		static public void DisplayResults(TestResultGrp Results, DisplayOption Display,
			object[] ConfigSettings) {
			Output outPut;
			switch (Display){
				case DisplayOption.MessageBox:
					outPut = new MessageBoxOutput();
					break;
				case DisplayOption.Chart:
					outPut = new ChartOutput();
					break;
				case DisplayOption.File:
					outPut = new FileOutput();
					break;
				default:
					goto case DisplayOption.MessageBox;
			}
			outPut.OutputResults(Results, ConfigSettings);
		}

		static public void DisplayResults(TestResultGrp Results, Output Display, object[] ConfigSettings) {
			if (Display == null) throw new ArgumentException("Null Output object is not allowed");
			Output outPut = Display;
			outPut.OutputResults(Results, ConfigSettings);
		}
	}
}
