using System;
using System.Text;
using DotNetPerformance;
using System.Data;
using System.Data.SqlClient;

namespace PerfTest.CLR {
	public class Paging {
		private const int orderTableSizeInNorthwind = 830;
		private const int pageSize = 10;
		private const int numberPages = orderTableSizeInNorthwind /  pageSize;
		private const string connString = "Initial Catalog=Northwind;Data Source=(local);User ID=sa;Pwd=consortium";

		private Random rnd = new Random();

		[Benchmark("Not used.")]
		public TestResultGrp RunTest() {	
			const int numberIterations  = 100;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StoredProc);
			testCases += new TestRunner.TestCase(InlineSQL);

			return tr.RunTests(testCases);
		}

		public void StoredProc(Int32 numberIterations){
			using (SqlConnection conn = new SqlConnection(connString)){
				conn.Open();
				for (int i = 0; i < numberIterations; ++i){
					int pageToGet = rnd.Next(numberPages);
					SqlCommand cmd = new SqlCommand("OrderPaging", conn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@RecsPerPage", pageSize);
					cmd.Parameters.Add("@PageNumber", pageToGet);
					using (SqlDataReader rdr = cmd.ExecuteReader()){
						while (rdr.NextResult())
							;
					}
				}
			}
		}

		public void InlineSQL(Int32 numberIterations){
			using (SqlConnection conn = new SqlConnection(connString)){
				conn.Open();
				for (int i = 0; i < numberIterations; ++i){
					int pageToGet = rnd.Next(numberPages);

					//build cmd
					StringBuilder sb = new StringBuilder(128);
					sb.Append("Select TOP {0} [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], " +
						"[ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity]," +
						"[ShipRegion], [ShipPostalCode], [ShipCountry] From ");
					sb.Append("(Select TOP {0} [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], " +
						"[ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity]," +
						"[ShipRegion], [ShipPostalCode], [ShipCountry] ");
					sb.Append("From ");
					sb.Append("(Select top {2} * From [Orders] Order by {1}) as temp2 ");
					sb.Append("Order by {1} desc) as tmp ");
					sb.Append("Order by {1}");
					string cmdStr = sb.ToString();
					cmdStr = String.Format(cmdStr, pageSize, "[CustomerID]", pageSize * pageToGet);

					SqlCommand cmd = new SqlCommand(cmdStr, conn);
					cmd.CommandType = CommandType.Text;
					using (SqlDataReader rdr = cmd.ExecuteReader()){
						while (rdr.NextResult())
							;
					}
				}
			}
		}
	}
}
