using System;

namespace DotNetPerformance.IO{

	public interface ICompress{
		byte[] Compress(byte[] input); 
		byte[] Expand(byte[] input);
		byte[] GetCompressRemainder();
	}
}

