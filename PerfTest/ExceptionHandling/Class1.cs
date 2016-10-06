using System;

namespace ExceptionHandling
{
	public class GenerateAndCatchException
	{
		private Array GetArray(){
			return null;
		}
		public void FaultHandler(){
			try{
				System.Array a;
				a = GetArray();
				int cnt = a.GetLength(1);
				++cnt;
			}
			catch(Exception){
			}
		}
		public void TypeFiltered(){
			try{
				System.Array a;
				a = GetArray();
				int cnt = a.GetLength(1);
				++cnt;
			}
			catch(Exception){
			}
		}
		public void UserFiltered(){
			try{
				System.Array a;
				a = GetArray();
				int cnt = a.GetLength(1);
				++cnt;
			}
			catch(Exception){
			}
		}
	}
}
