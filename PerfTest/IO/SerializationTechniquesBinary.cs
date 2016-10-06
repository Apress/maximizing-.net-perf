using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.IO {
	[Serializable]	
	public class ISerializableImpl: ISerializable{
		public ISerializableImpl(int x, string y){this.x = x; this.y = y;}
		public ISerializableImpl(SerializationInfo info, StreamingContext context){
			x = info.GetInt32("x");
			y = info.GetString("y");
		}
		public void GetObjectData(SerializationInfo info, StreamingContext context){
			info.AddValue("x", x);
			info.AddValue("y", y);
		}
		public int x;
		public string y;
	}

	[Serializable]
	public class SerializableAttributeType{
		public SerializableAttributeType(int x, string y){this.x = x; this.y = y;}
		public int x;
		public string y;
	}

	//TEST 11.02
	public class SerializationTechniquesBinary {
		[Benchmark("Compares Serializable attribute to ISerializable interface for binary formatter", "BinarySerializationTest")]
		public TestResultGrp SerializationTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ISerializable);
			testCases += new TestRunner.TestCase(SerializableAttribute);
			
			return tr.RunTests(testCases);
		}


		//TEST 11.03
		[Benchmark("Compares Serializable attribute to ISerializable interface for binary formatter for deserialization", "BinaryDeserializationTest")]
		public TestResultGrp DeserializationTest() {	
			const int numberIterations = 100000;
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
			MemoryStream ms = new MemoryStream(numberIterations * 10);
			BinaryFormatter bf = new BinaryFormatter();
			for (int i = 0;i < numberIterations;++i) {
				bf.Serialize(ms, new ISerializableImpl(i, "i"));
			}
			_is = ms;
		}

		public void DeserialiseISerializable(Int32 numberIterations) {
			_is.Position = 0;
			BinaryFormatter bf = new BinaryFormatter();
			for (int i = 0;i < numberIterations;++i) {
				ISerializableImpl isi = (ISerializableImpl)bf.Deserialize(_is);
			}
		}

		public void SerializableAttribute(Int32 numberIterations) {	
			MemoryStream ms = new MemoryStream(numberIterations * 10);
			BinaryFormatter bf = new BinaryFormatter();
			for (int i = 0;i < numberIterations;++i) {
				bf.Serialize(ms, new SerializableAttributeType(i, "i"));
			}
			_sa = ms;
		}

		public void DeserialiseSerializableAttribute(Int32 numberIterations) {	
			_sa.Position = 0;
			BinaryFormatter bf = new BinaryFormatter();
			for (int i = 0;i < numberIterations;++i) {
				SerializableAttributeType sat = (SerializableAttributeType)bf.Deserialize(_sa);
			}
		}
	}

}
