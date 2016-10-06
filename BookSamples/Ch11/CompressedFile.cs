using System;
using System.IO;
using System.Runtime.InteropServices;


public class CompressedFile {
  [DllImport("kernel32.dll")]
  static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
    uint dwShareMode, IntPtr lpSecurityAttributes, 
    uint dwCreationDisposition,
    uint dwFlagsAndAttributes, IntPtr hTemplateFile);

  [DllImport("kernel32.dll")]
  static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, 
    ref ushort lpInBuffer, uint nInBufferSize, [Out] byte [] lpOutBuffer, 
    uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

  static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access) {
    return ((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method);
  }

  static readonly uint FSCTL_SET_COMPRESSION = CTL_CODE(FILE_DEVICE_FILE_SYSTEM,
    16, METHOD_BUFFERED, FILE_READ_DATA | FILE_WRITE_DATA);
  const uint METHOD_BUFFERED            = 0;
  const uint FILE_DEVICE_FILE_SYSTEM    = 0x00000009;
  const uint FILE_READ_DATA             = 0x0001;
  const uint FILE_WRITE_DATA            = 0x0002;
  const uint GENERIC_ALL                = 0x10000000;
  const uint FILE_SHARE_WRITE           = 0x00000002;
  const uint FILE_ATTRIBUTE_COMPRESSED  = 0x00000080;
  const uint CREATE_ALWAYS              = 2;
  
  public unsafe static void CreateCompressedFile(){
    //open file handle
    IntPtr fileHandle = CreateFile(@"c:\myFile.txt", GENERIC_ALL, 
      FILE_SHARE_WRITE, IntPtr.Zero, 
      CREATE_ALWAYS, FILE_ATTRIBUTE_COMPRESSED, IntPtr.Zero);
    //compress file
    uint retBytes;
    ushort COMPRESSION_FORMAT_DEFAULT = 0x0001;
    bool res = DeviceIoControl(fileHandle, FSCTL_SET_COMPRESSION,
      ref COMPRESSION_FORMAT_DEFAULT, sizeof(ushort), null, 0,
      out retBytes, IntPtr.Zero); 
    //create file stream based on this handle
    using (FileStream fs = new FileStream(fileHandle, 
           FileAccess.Write, true)){
      fs.WriteByte(0x45);  //write upper case E to file
    }
  }
}

