using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace RemotingPerfLibrary
{
		public class DataManager: MarshalByRefObject{
			static string _10chars = "0123456789";
			static string _100chars = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
			static string _1000chars;
			static string _5000chars;

			static DataManager(){
				System.Text.StringBuilder sb1000 = new System.Text.StringBuilder(1000);
				System.Text.StringBuilder sb5000 = new System.Text.StringBuilder(5000);
				for (int i = 0; i < 10; ++i)
					sb1000.Append(_100chars);
				_1000chars = sb1000.ToString();

				for (int i = 0; i < 50; ++i)
					sb5000.Append(_100chars);
				_5000chars = sb5000.ToString();
			}

			public string Get10CharacterString(){
				return _10chars;
			}

			public string Get100CharacterString(){
				return _100chars;
			}

			public string Get1000CharacterString(){
				return _1000chars;
			}

			public string Get5000CharacterString(){
				return _5000chars;
			}

			public void InfiniteMethod(){
				while(true){
					System.Threading.Thread.Sleep(1000);
				}
			}

			public void SlowMethod(){
				System.Threading.Thread.Sleep(100);
			}

			[OneWay]
			public void SlowMethodOneWay(){
				System.Threading.Thread.Sleep(100);
			}
		}
}
