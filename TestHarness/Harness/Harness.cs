using System;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace DotNetPerformance{
	public class TestResultGrp{
		public TestResultGrp(TestResult[] results, string testName, string motivation){
			_results = results;
			_testName = testName;
			_motivation = motivation;
		}

		public TestResultGrp(TestResult[] results, string testName){
			_results = results;
			_testName = testName;
		}

		private TestResult[] _results;
		public TestResult[] Results{get {return _results;}}

		private string _testName;
		public string TestName{get {return _testName;}}

		private string _motivation;
		public string Motivation{get {return _motivation;}}
	}

	public class TestResult{
		private string _testName;
		public string TestName{get {return _testName;} set {_testName = value;}}

		private string[] _errorDescription;
		public string[] ErrorDescription{get {return _errorDescription;} set {_errorDescription = value;}}

		private TimeSpan[] _testResults;
		public TimeSpan[] TestResults{get {return _testResults;} set {_testResults = value;}}

		private TimeSpan _min;
		public TimeSpan Min{get {return _min;} set {_min = value;}}

		private TimeSpan _max;
		public TimeSpan Max{get {return _max;} set {_max = value;}}

		private TimeSpan _mean;
		public TimeSpan Mean{get {return _mean;} set {_mean = value;}}

		private TimeSpan _median;
		public TimeSpan Median{get {return _median;} set {_median = value;}}

		private TimeSpan _stdDev;
		public TimeSpan StdDev{get {return _stdDev;} set {_stdDev = value;}}

		private float _NormalizedTestDuration;
		public float NormalizedTestDuration{get {return _NormalizedTestDuration;} set {_NormalizedTestDuration = value;}}
	}


	public class PercentageDoneChangeEventArgs : EventArgs{
		private int percentageDone;
		public PercentageDoneChangeEventArgs(int percentageDone){this.percentageDone = percentageDone;}
		public int PercentageDone{get{return percentageDone;}}
	}

	public struct TestGroup{
		private TestRunner.TestCleanup _preTestCleanup;
		public TestRunner.TestCleanup PreTestCleanup{get {return _preTestCleanup;}}
		private TestRunner.TestCase _testRun;
		public TestRunner.TestCase TestRun{get {return _testRun;}}
		private TestRunner.TestCleanup _postTestCleanup;
		public TestRunner.TestCleanup PostTestCleanup{get {return _postTestCleanup;}}
		private TestRunner.TestValidity _testValidityCheck;
		public TestRunner.TestValidity TestValidityCheck{get {return _testValidityCheck;}}

		public TestGroup(TestRunner.TestCase Test, TestRunner.TestCleanup Pre, 
			TestRunner.TestCleanup Post, TestRunner.TestValidity Val){
			if (Pre == null || Test == null || Post == null || Val == null)
				throw new ArgumentException("Null delegates not permitted");
			_preTestCleanup = Pre; _testRun = Test; _postTestCleanup = Post; _testValidityCheck = Val;
		}
	}

	public class TestRunner{
		public TestRunner(Int32 numberIterations, Int32 numberRuns){
			_numberIterations = numberIterations;
			_numberRuns = numberRuns;
			_percentageDone = 0;
			_testsStoppedEvent = new AutoResetEvent(false);
		}

		public delegate void TestCase(Int32 NumberIterations);
		public delegate void TestCleanup();
		public delegate bool TestValidity(out string ErrorDescription);
		public delegate void PercentageDoneEventHandler (object source, PercentageDoneChangeEventArgs e);

		public static void NoOp(){}
		public static void GCCollect(){System.GC.Collect();}
		public static bool TestOK(out string ErrorDescription){ErrorDescription = String.Empty; return true;}

		public void AddTestGroup(TestGroup tg){
			_preClean +=		tg.PreTestCleanup;
			_testCaseDel +=		tg.TestRun;
			_postClean +=		tg.PostTestCleanup;
			_testValidity +=	tg.TestValidityCheck;
		}

		public event PercentageDoneEventHandler OnPercentageDoneChangeHandler;

		private AutoResetEvent _testsStoppedEvent;
		private readonly Int32 _numberIterations, _numberRuns;
		private TestResult[] _results;
		private bool _testsDone;
		private int _percentageDone;
		private TestCase _testCaseDel;
		private TestCleanup _preClean;
		private TestCleanup _postClean;
		private TestValidity _testValidity;

		protected int _testReReuns = 3;
		public int ReRunLimit{ get {{return _testReReuns;}} set {{_testReReuns = value;}}}

		public AutoResetEvent TestsStoppedEvent{get {return _testsStoppedEvent;}}
		private int PercentageDone{
			get {lock(this){return _percentageDone;}}
			set {
				lock(this){_percentageDone = value;}
				PercentageDoneChangeEventArgs arg = new PercentageDoneChangeEventArgs(_percentageDone);
				if (OnPercentageDoneChangeHandler != null) OnPercentageDoneChangeHandler(this, arg);
			}
		}
		internal bool TestsDone{
			get {lock(this){return _testsDone;}}
			set {lock(this){_testsDone = value;}}
		}

		public void ThreadMethod(){
			Delegate[] preCleanupFunctions = _preClean.GetInvocationList();
			Delegate[] testCases = _testCaseDel.GetInvocationList();
			Delegate[] postCleanupFunctions = _postClean.GetInvocationList();
			Delegate[] checkFunctions = _testValidity.GetInvocationList();

			//get run ordering and initialise
			Int32 numberTestCases = testCases.GetLength(0);
			Int32 totalNumberRuns = numberTestCases*_numberRuns;
			TestResult[] results = new TestResult[numberTestCases];
			TimeSpan[,] runTimes = new TimeSpan[numberTestCases,_numberRuns];
			string[,] errTxt = new string[numberTestCases,_numberRuns];
			Int32[] runsSoFar = new Int32[numberTestCases];
			Int32[] runNumberOrder = GetRandomSequence(numberTestCases, totalNumberRuns);

			//run tests
			for (Int32 i = 0; i < totalNumberRuns; ++i){
				PercentageDone = i*100/totalNumberRuns;
				Int32 testCaseToRun = runNumberOrder[i];
				TestCleanup preClean = (TestCleanup)preCleanupFunctions[testCaseToRun];
				if (preClean != null)
					preClean();
				TestCase tc = (TestCase)testCases[testCaseToRun];
				
				bool testOK = false;
				string testError;

				if (tc == null){
					throw new ArgumentException("Null test case delegates are not allowed");
				}
				HiResTimer hrt = new HiResTimer();
				for (int count = 0; count < _testReReuns && !testOK; ++count){
					hrt.Start();
					try{
						tc(_numberIterations);
					}
					catch(Exception e){
						if (e is ThreadAbortException) return; //this exception occurs when test cancelled
						System.Windows.Forms.MessageBox.Show(String.Format("Exception caught: {0}", e.Message));
						PercentageDone = 100;
						_testsStoppedEvent.Set();
						return;
					}
					hrt.Stop();

					TestCleanup postClean = (TestCleanup)postCleanupFunctions[testCaseToRun];
					if (postClean != null)
						postClean();

					TestValidity tv = (TestValidity)checkFunctions[testCaseToRun];
					if (tv != null)
						testOK = tv(out testError);
					else
						testError = String.Empty;
					runTimes[testCaseToRun, runsSoFar[testCaseToRun]] = hrt.ElapsedTimeSpan;
					errTxt[testCaseToRun, runsSoFar[testCaseToRun]] = testError;
				}
				++runsSoFar[testCaseToRun];
			}

			//post-process
			_results = PostProcessResults(testCases, runTimes, errTxt);
			TestsDone = true;
			_testsStoppedEvent.Set();
			PercentageDone = 100;
		}
		
		private int _testMethodDepth = 1;
		public TestResultGrp RunTests(TestCase TestCaseDel){
			_testMethodDepth = 2;
			return RunTests(TestCaseDel, System.Threading.ThreadPriority.Highest, true);
		}

		public TestResultGrp RunTests(TestCase TestCaseDel, System.Threading.ThreadPriority threadPriorty,
			bool ShowProgress){
			Progress display = null;
			if (ShowProgress)
				display = new Progress(this);

			_testCaseDel += TestCaseDel;
			if (TestCaseDel != null){//add no-op cleanup functions
				for (int i = 0; i < TestCaseDel.GetInvocationList().Length; ++i){
					_preClean += new TestCleanup(TestRunner.NoOp);
					_postClean += new TestCleanup(TestRunner.NoOp);
					_testValidity += new TestValidity(TestRunner.TestOK);
				}
			}

			ThreadStart ts = new ThreadStart(ThreadMethod);
			Thread t = new Thread(ts);
			t.Priority = threadPriorty;
			_testsStoppedEvent.Reset();
			t.Start();

			if (ShowProgress)
				display.ShowDialog();

			_testsStoppedEvent.WaitOne();
			if (TestsDone){
				StackFrame sf = new StackFrame(_testMethodDepth, false);
				MethodBase caller = sf.GetMethod();
				object[] motivationsAtts = caller.GetCustomAttributes(typeof(DotNetPerformance.BenchmarkAttribute), true);
				string motivation = "";
				string testName = caller.DeclaringType.Name;
				if (motivationsAtts != null && motivationsAtts.Length != 0){
					BenchmarkAttribute ma = (BenchmarkAttribute)motivationsAtts[0];
					motivation = ma.Motivation;
					if (ma.TestName != String.Empty)
						testName = ma.TestName;
				}
				return new TestResultGrp(_results, testName, motivation);
			}
			else{
				t.Abort();
				return new TestResultGrp(null, "", "");
			}
		}

		protected virtual Int32[] GetRandomSequence(Int32 numberTestCases, Int32 totalNumberRuns){
			ArrayList al = new ArrayList(totalNumberRuns);
			Int32[] retSequence = new Int32[totalNumberRuns];
			for (int i = 0; i < totalNumberRuns; ++i){
				al.Add(i);
			}
			Random rand = new Random();
			for (int j = totalNumberRuns - 1; j != -1; --j){
				Int32 index = rand.Next(0, j+1);
				retSequence[totalNumberRuns-j-1] = (int)al[index] / _numberRuns;
				al.RemoveAt(index);
			}
			return retSequence;
		}

		protected virtual TestResult[] PostProcessResults(Delegate[] testCases, TimeSpan[,] results, string[,] ErrTxt){
			Int32 numberTestCases = results.GetLength(0);
			TestResult[] retVal = new TestResult[numberTestCases];
			TimeSpan lowestMedian = TimeSpan.MaxValue;
			for (int i = 0; i < numberTestCases; ++i){
				retVal[i] = new TestResult();
				retVal[i].TestResults = new TimeSpan[_numberRuns];
				retVal[i].ErrorDescription = new string[_numberRuns];
				for (int j = 0; j < _numberRuns; ++j){
					retVal[i].TestResults[j] = results[i,j];
					retVal[i].ErrorDescription[j] = ErrTxt[i,j];
				}
				retVal[i].TestName = testCases[i].Method.Name;
				TimeSpan min, max;
				TimeSpan cumTotal = TimeSpan.Zero;
				double cumTotalSqred = 0.0;
				min = max = results[i,0];
				for (int j = 0; j < _numberRuns; ++j){
					min = min > results[i,j]? results[i,j] : min;
					max = max < results[i,j]? results[i,j] : max;
					cumTotal += results[i,j];
					cumTotalSqred += (results[i,j].TotalMilliseconds)*(results[i,j].TotalMilliseconds);
				}
				retVal[i].Mean = TimeSpan.FromMilliseconds(cumTotal.TotalMilliseconds / _numberRuns);
				retVal[i].Min = min;
				retVal[i].Max = max;

				TimeSpan[] sortedResults = new TimeSpan[_numberRuns];
				retVal[i].TestResults.CopyTo(sortedResults, 0);
				Array.Sort(sortedResults);
				if (_numberRuns == 1)
					retVal[i].Median = sortedResults[0];
				else if (_numberRuns == 2)
					retVal[i].Median = TimeSpan.FromMilliseconds(sortedResults[0].TotalMilliseconds/2
						+ sortedResults[1].TotalMilliseconds/2);
				else if(_numberRuns % 2 == 0)
					retVal[i].Median = TimeSpan.FromMilliseconds(sortedResults[_numberRuns/2].TotalMilliseconds/2
						+ sortedResults[_numberRuns/2+1].TotalMilliseconds/2);
				else
					retVal[i].Median = sortedResults[_numberRuns/2];
				if (lowestMedian > retVal[i].Median) lowestMedian = retVal[i].Median;

				double stddevSqrd = ((_numberRuns*cumTotalSqred - 
					((cumTotal.TotalMilliseconds)*(cumTotal.TotalMilliseconds)))/(_numberRuns*(_numberRuns-1)));
				retVal[i].StdDev = TimeSpan.FromMilliseconds(Math.Sqrt(stddevSqrd));
			}
			for (int i = 0; i < numberTestCases; ++i){
				retVal[i].NormalizedTestDuration = (float)(retVal[i].Median.TotalMilliseconds)/(float)(lowestMedian.TotalMilliseconds);
			}
			return retVal;
		}
	}
}
 