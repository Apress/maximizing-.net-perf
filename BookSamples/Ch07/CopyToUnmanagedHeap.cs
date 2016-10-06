using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class DataHolder{
	public int i = 3;
	public int j = 4;
}

public unsafe class InteropUser {
	//unmanaged function expecting some raw memory block
	[DllImport("MyWin32DLL.dll")]
	public static extern void UnmanagedFunction(IntPtr pMem);

	public void CopyToUnmanagedHeap(){
		DataHolder dh = new DataHolder();
		IntPtr mem = Marshal.AllocHGlobal(sizeof(int)*2);
		Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*0), dh.i);
		Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*1), dh.j);
		UnmanagedFunction(mem);
		Marshal.FreeHGlobal(mem);
	}

	public void PinAndPassOut(){
		DataHolder dh = new DataHolder();
		GCHandle handle = GCHandle.Alloc(dh, GCHandleType.Pinned);
		UnmanagedFunction(handle.AddrOfPinnedObject());
		handle.Free();
	}
}

