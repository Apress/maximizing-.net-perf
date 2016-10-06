using System;
using System.Security;
using System.Security.Cryptography;
using DotNetPerformance;

namespace PerfTest.Security {
	public class PublicPrivate {
		private byte[] _testData = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09};
		
		//TEST 09.05
		[Benchmark("Compares public and private key encyption speed")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 10000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Public);
			testCases += new TestRunner.TestCase(Private);
			return tr.RunTests(testCases);
		}

		public void Public(Int32 numberIterations){
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(384);
			for (int i = 0;i < numberIterations;++i) {
				rsa.Decrypt(rsa.Encrypt(_testData, false), false);
			}
		}

		public void Private(Int32 numberIterations){
			RijndaelManaged rm = new RijndaelManaged();
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
