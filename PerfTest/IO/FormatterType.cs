using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using DotNetPerformance;
using System.Runtime.Serialization;

namespace PerfTest.IO {
	public class FormatterType {

		//TEST 11.06
		[Benchmark("Compares binary and SOAP formatters")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(FormatterType.Binary);
			testCases += new TestRunner.TestCase(FormatterType.Soap);

			return tr.RunTests(testCases);
		}

		public static void Binary(Int32 numberIterations){
			MemoryStream ms = new MemoryStream(numberIterations * 10);
			BinaryFormatter bf = new BinaryFormatter();
			for (int i = 0;i < numberIterations;++i) {
				bf.Serialize(ms, i);
			}
		}

		public static void Soap(Int32 numberIterations){
			MemoryStream ms = new MemoryStream(numberIterations * 10);
			SoapFormatter sf = new SoapFormatter();
			for (int i = 0;i < numberIterations;++i) {
				sf.Serialize(ms, i);
			}
		}
	}

	public class LargeDataStructureHolder: ISerializable{
		object _lotsOfData;
		public LargeDataStructureHolder(){}
		public LargeDataStructureHolder(SerializationInfo info, StreamingContext context){
			if (info.GetBoolean("compressed")){
				object compressedData = info.GetValue("data", typeof(object));
				_lotsOfData = compressedData; //expand
			}
			else
				_lotsOfData = info.GetValue("data", typeof(object));
		}
		public void GetObjectData(SerializationInfo info, StreamingContext context){
			if (context.State  == StreamingContextStates.CrossMachine){
				info.AddValue("compressed", true);
				object compressedData = _lotsOfData;//compress
				info.AddValue("data", compressedData);
			}
			else{
				info.AddValue("compressed", false);
				//compress _lotsOfData
				info.AddValue("data", _lotsOfData);
			}
		}
	}
}
