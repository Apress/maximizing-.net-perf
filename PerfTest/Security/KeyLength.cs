using System;
using System.Security;
using System.Security.Cryptography;
using DotNetPerformance;

namespace PerfTest.Security {
	public class KeyLength {
		private byte[] _testData = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09};
		
		//TEST 09.06
		[Benchmark("Looks at effect of key length on data encryption speed.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 100000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(_40);
			testCases += new TestRunner.TestCase(_128);
			testCases += new TestRunner.TestCase(_192);
			testCases += new TestRunner.TestCase(_256);
			return tr.RunTests(testCases);
		}

		public void _40(Int32 numberIterations){
			RC2CryptoServiceProvider rm = new RC2CryptoServiceProvider();
			rm.KeySize = 128;
			rm.GenerateIV();
			rm.GenerateKey();
			ICryptoTransform enc =  rm.CreateEncryptor();
			ICryptoTransform dec =  rm.CreateDecryptor();
			for (int i = 0;i < numberIterations;++i) {
				byte[] enrytped = enc.TransformFinalBlock(_testData, 0, 10);
				dec.TransformFinalBlock(enrytped, 0, enrytped.Length);
			}
		}

		public void _128(Int32 numberIterations){
			RijndaelManaged rm = new RijndaelManaged();
			rm.KeySize = 128;
			rm.GenerateIV();
			rm.GenerateKey();
			ICryptoTransform enc =  rm.CreateEncryptor();
			ICryptoTransform dec =  rm.CreateDecryptor();
			for (int i = 0;i < numberIterations;++i) {
				byte[] enrytped = enc.TransformFinalBlock(_testData, 0, 10);
				dec.TransformFinalBlock(enrytped, 0, enrytped.Length);
			}
		}

		public void _192(Int32 numberIterations){
			RijndaelManaged rm = new RijndaelManaged();
			rm.KeySize = 192;
			rm.GenerateIV();
			rm.GenerateKey();
			ICryptoTransform enc =  rm.CreateEncryptor();
			ICryptoTransform dec =  rm.CreateDecryptor();
			for (int i = 0;i < numberIterations;++i) {
				byte[] enrytped = enc.TransformFinalBlock(_testData, 0, 10);
				dec.TransformFinalBlock(enrytped, 0, enrytped.Length);
			}
		}

		public void _256(Int32 numberIterations){
			RijndaelManaged rm = new RijndaelManaged();
			rm.KeySize = 256;
			rm.GenerateIV();
			rm.GenerateKey();
			ICryptoTransform enc =  rm.CreateEncryptor();
			ICryptoTransform dec =  rm.CreateDecryptor();
			for (int i = 0;i < numberIterations;++i) {
				byte[] enrytped = enc.TransformFinalBlock(_testData, 0, 10);
				dec.TransformFinalBlock(enrytped, 0, enrytped.Length);
			}
		}
	}
}
