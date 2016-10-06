using System;
using System.Management;
using System.Xml;

namespace DotNetPerformance.ResultOutput {
	public class FileOutput: Output {
		protected override void OutputResults(TestResultGrp resultGrp, object[] ConfigSettings){
			TestResult[] Results = resultGrp.Results;

			string procName = "";
			uint L2CacheSize  = 0;
			uint L2CacheSpeed  = 0;
			int procNo = 0;
			ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Name, L2CacheSize, L2CacheSpeed FROM  Win32_Processor");
			ManagementObjectCollection moc = mos.Get();
			foreach(ManagementObject mob in moc){
				++procNo;
				procName = mob.Properties["Name"].Value.ToString();
				L2CacheSize = Convert.ToUInt32(mob.Properties["L2CacheSize"].Value);
				L2CacheSpeed = Convert.ToUInt32(mob.Properties["L2CacheSpeed"].Value);
			}


			if (Results == null) return;

			string xmlFileName = (string)ConfigSettings[0];
			if (xmlFileName == String.Empty)
				xmlFileName = "c:\\" + resultGrp.TestName + ".xml";
			System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(xmlFileName, System.Text.Encoding.UTF8);
			writer.WriteStartElement("testresults");
			writer.WriteAttributeString("Name", resultGrp.TestName);
			if (resultGrp.Motivation != String.Empty)
				writer.WriteAttributeString("Motivation",resultGrp.Motivation);
			writer.WriteAttributeString("TestTime", DateTime.UtcNow.ToString("r"));
			writer.WriteAttributeString("MachineName", System.Environment.MachineName);
			writer.WriteAttributeString("CLR_Version", System.Environment.Version.ToString());
			writer.WriteAttributeString("OS", System.Environment.OSVersion.ToString());
			writer.WriteAttributeString("NoProcessors", procNo.ToString());
			writer.WriteAttributeString("ProcName", procName);
			writer.WriteAttributeString("L2CacheSize_Kilobytes", L2CacheSize.ToString());
			writer.WriteAttributeString("L2CacheSpeed_MegaHertz", L2CacheSpeed.ToString());
			foreach (DotNetPerformance.TestResult tr in Results){
				writer.WriteStartElement("testresult");
				writer.WriteAttributeString("Name", tr.TestName);
				writer.WriteAttributeString("Min", tr.Min.TotalMilliseconds.ToString());
				writer.WriteAttributeString("Median", tr.Median.TotalMilliseconds.ToString());
				writer.WriteAttributeString("Max", tr.Max.TotalMilliseconds.ToString());
				writer.WriteAttributeString("NormalizedTestDuration", tr.NormalizedTestDuration.ToString());
				foreach (TimeSpan ts in tr.TestResults){
					writer.WriteElementString("testrun", ts.TotalMilliseconds.ToString());
				}
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.Close();
			System.Diagnostics.Process.Start(xmlFileName);
		}
	}
}
