using System;
using System.IO;
using System.Runtime.InteropServices;


public class FileIOHints {
  [DllImport("kernel32.dll")]
  static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
    uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
    uint dwFlagsAndAttributes, IntPtr hTemplateFile);

  const uint GENERIC_READ              = 0x80000000;
  const uint FILE_SHARE_READ           = 0x00000001;
  const uint FILE_ATTRIBUTE_NORMAL     = 0x00000080;
  const uint FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000;
  const uint OPEN_EXISTING             = 3;

  public void CreateFileObjectWithHints(){
    //open file handle with FILE_FLAG_SEQUENTIAL_SCAN hint
    IntPtr fileHandle = CreateFile(@"c:\myFile.txt", GENERIC_READ, 
      FILE_SHARE_READ, IntPtr.Zero, 
      OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN,
      IntPtr.Zero);
    //create file stream based on this handle
    using (FileStream fs = new FileStream(fileHandle, 
    FileAccess.Read, true)){
      //use fs;
    }
  }
}

