using System;
using System.IO;

namespace DotNetPerformance.IO {
	/// <summary>
	/// Supports data compression on a stream
	/// </summary>
	public class CompressedStream: Stream {
		private Stream _stream;
		private DotNetPerformance.IO.LZW _compressor;
		private byte[] readRemainder = new byte[0];
		private bool _hasWrittenBytes = false;

		public CompressedStream(Stream stream) {
			_stream = stream;
			_compressor = new DotNetPerformance.IO.LZW();
		}

		public override void Close(){
			if (_hasWrittenBytes){
				byte[] lastBytes = _compressor.GetCompressRemainder();
				_stream.Write(lastBytes, 0, lastBytes.Length);
			}
			if (_stream != null) {
				Flush();
				_stream.Close();
			}
			_stream = null;
			_compressor = null;
		}

		public override void Flush() {
			if (_stream == null)
				throw new System.ObjectDisposedException("Stream", "Underlying stream is already closed");
			_stream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count) {
			if (offset != 0)
				throw new ArgumentOutOfRangeException("offset", offset, "Non-zero offset not supported");
			if (buffer.Length < count){
				throw new ArgumentOutOfRangeException("count", count, "count is greater than buffer length");
			}

			if (readRemainder.Length >= count){
				Array.Copy(readRemainder, 0, buffer, 0, count);
				byte[] newRemained = new byte[readRemainder.Length - count];
				Array.Copy(readRemainder, count, newRemained, 0, readRemainder.Length - count);
				readRemainder = newRemained;
				return count;
			}
			else{
				int bytesRead = 1;
				byte[] expandedBytes = new byte[0];
				while ((expandedBytes.Length + readRemainder.Length) < count && bytesRead != 0){
					bytesRead = _stream.Read(buffer, 0, count);
					if (bytesRead != 0){
						byte[] moreBytes = _compressor.Expand(buffer);
						byte[] newExpandedBytes = new byte[expandedBytes.Length + moreBytes.Length];
						Array.Copy(expandedBytes, 0, newExpandedBytes, 0, expandedBytes.Length);
						Array.Copy(moreBytes, 0, newExpandedBytes, expandedBytes.Length, moreBytes.Length);
						expandedBytes = newExpandedBytes;
					}
				}

				byte[] totalReadBlock = new byte[readRemainder.Length + expandedBytes.Length];
				Array.Copy(readRemainder, 0, totalReadBlock, 0, readRemainder.Length);
				Array.Copy(expandedBytes, 0, totalReadBlock, readRemainder.Length, expandedBytes.Length);
				if (totalReadBlock.Length > count){
					Array.Copy(totalReadBlock, 0, buffer, 0, count);
					readRemainder = new byte[totalReadBlock.Length - count];
					Array.Copy(totalReadBlock, count, readRemainder, 0, totalReadBlock.Length - count);
					return buffer.Length;
				}
				else{
					Array.Copy(totalReadBlock, 0, buffer, 0, totalReadBlock.Length);
					return totalReadBlock.Length;
				}
			}
		}

		public override void Write(byte[] buffer, int offset, int count) {
			if (offset != 0)
				throw new ArgumentOutOfRangeException("offset", offset, "Non-zero offset not supported");
			if (buffer.Length < count){
				throw new ArgumentOutOfRangeException("count", count, "count is greater than buffer length");
			}

			_hasWrittenBytes = true;

			byte[] temp = new byte[count];
			Array.Copy(buffer, 0, temp, 0, count);
			byte[] compressedBytes = _compressor.Compress(temp);
			_stream.Write(compressedBytes, 0, compressedBytes.Length);
		}

		public override bool CanRead{
			get{return _stream.CanRead;}
		}

		public override bool CanSeek{
			get{return false;}
		}

		public override bool CanWrite{
			get{return _stream.CanWrite;}
		}

		public override void SetLength(long value) {
			throw new NotSupportedException("SetLength not supported");
		}

		public override long Seek(long offset, SeekOrigin origin){
			throw new NotSupportedException("Seek not supported");
		}

		public override long Length{
			get{throw new NotSupportedException("Length property not supported");}
		}

		public override long Position{
			get{throw new NotSupportedException("Position property not supported");}
			set{throw new NotSupportedException("Position property not supported");}
		}
	}
}
