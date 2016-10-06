using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.IO {
	public class SerializationTechniquesSoap {
		//TEST 11.04
		[Benchmark("Compares Serializable attribute to ISerializable interface for SOAP formatter", "SOAPSerializationTest")]
		public TestResultGrp SerializationTest() {	
			const int numberIterations = 3000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ISerializable);
			testCases += new TestRunner.TestCase(SerializableAttribute);
			
			return tr.RunTests(testCases);
		}

		//TEST 11.05
		[Benchmark("Compares Serializable attribute to ISerializable interface for SOAP formatter for deserialization", "SOAPDeserializationTest")]
		public TestResultGrp DeserializationTest() {	
			const int numberIterations = 3000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			ISerializable(numberIterations);
			SerializableAttribute(numberIterations);
			testCases += new TestRunner.TestCase(DeserialiseISerializable);
			testCases += new TestRunner.TestCase(DeserialiseSerializableAttribute);
			
			return tr.RunTests(testCases);
		}

		private MemoryStream _is;
		private MemoryStream _sa;

		public void ISerializable(Int32 numberIterations) {
			MemoryStream ms = new MemoryStream(numberIterations * 1000);
			SoapFormatter bf = new SoapFormatter();
			ISerializableImpl[] arr = new ISerializableImpl[numberIterations];
			for (int i = 0;i < numberIterations;++i) {
				arr[i] = new ISerializableImpl(i, "i");
			}
			bf.Serialize(ms, arr);
			_is = ms;
		}

		public void DeserialiseISerializable(Int32 numberIterations) {
			_is.Position = 0;
			SoapFormatter bf = new SoapFormatter();
			ISerializableImpl[] arr = (ISerializableImpl[])bf.Deserialize(_is);
			for (int i = 0;i < numberIterations;++i) {
				ISerializableImpl isi = (ISerializableImpl)arr[i];
			}
		}

		public void SerializableAttribute(Int32 numberIterations) {	
			MemoryStream ms = new MemoryStream(numberIterations * 1000);
			SoapFormatter bf = new SoapFormatter();
			SerializableAttributeType[] arr = new SerializableAttributeType[numberIterations];
			for (int i = 0;i < numberIterations;++i) {
				arr[i] = new SerializableAttributeType(i, "i");
			}
			bf.Serialize(ms, arr);
			_sa = ms;
		}

		public void DeserialiseSerializableAttribute(Int32 numberIterations) {	
			_sa.Position = 0;
			SoapFormatter bf = new SoapFormatter();
			SerializableAttributeType[] arr = (SerializableAttributeType[])bf.Deserialize(_sa);
			for (int i = 0;i < numberIterations;++i) {
				SerializableAttributeType sat = arr[i];
			}
		}
	}

}
