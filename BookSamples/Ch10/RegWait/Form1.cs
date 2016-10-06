using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace RegWait
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Win32Imports
		public const int READ_CONTROL = 0x20000;
		public const int STANDARD_RIGHTS_READ = (READ_CONTROL);
		public const int KEY_QUERY_VALUE = 0x1;
		public const int KEY_ENUMERATE_SUB_KEYS = 0x8;
		public const int KEY_NOTIFY = 0x10;
		public const int SYNCHRONIZE = 0x100000;
		public const int KEY_READ = ((STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY)
			& (~ SYNCHRONIZE));

		public const int REG_NOTIFY_CHANGE_NAME = 0x1;                      // Create or delete (child);
		public const int REG_NOTIFY_CHANGE_ATTRIBUTES = 0x2;
		public const int REG_NOTIFY_CHANGE_LAST_SET = 0x4;
		private System.Windows.Forms.Button AddWait;
		private System.Windows.Forms.TextBox KeyName;
		public const int REG_NOTIFY_CHANGE_SECURITY = 0x8;

		[StructLayout(LayoutKind.Sequential)] 
			public  class SECURITY_ATTRIBUTES{
			public int  nLength;
			public int  lpSecurityDescriptor;
			public int  bInheritHandle;
		}

		[DllImport("advapi32.dll")]
		public  static extern int  RegNotifyChangeKeyValue(int  hKey,int  bWatchSubtree,int  
			dwNotifyFilter,int  hEvent,int  fAsynchronus);
		[DllImport("advapi32.dll")]
		public  static extern int  RegCloseKey(int  hKey);
		[DllImport("advapi32.dll")]
		public  static extern int  RegOpenKeyEx(int  hKey,string  lpSubKey,int  ulOptions,
			int  samDesired,out int  phkResult);
		[DllImport("advapi32.dll")]
		public  static extern int RegQueryValueEx(int  hKey,string  lpValueName,int  lpReserved,out int  lpType,System.Text.StringBuilder lpData,ref int  lpcbData);
		[DllImport("kernel32.dll")]
		public  static extern int  CreateEvent([MarshalAs(UnmanagedType.Struct)] SECURITY_ATTRIBUTES lpEventAttributes,int  bManualReset,int  bInitialState,string  lpName);

		#endregion

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AddWait = new System.Windows.Forms.Button();
			this.KeyName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// AddWait
			// 
			this.AddWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AddWait.Location = new System.Drawing.Point(8, 16);
			this.AddWait.Name = "AddWait";
			this.AddWait.Size = new System.Drawing.Size(160, 32);
			this.AddWait.TabIndex = 0;
			this.AddWait.Text = "Wait on Key";
			this.AddWait.Click += new System.EventHandler(this.AddWait_Click);
			// 
			// KeyName
			// 
			this.KeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.KeyName.Location = new System.Drawing.Point(184, 16);
			this.KeyName.Name = "KeyName";
			this.KeyName.Size = new System.Drawing.Size(640, 29);
			this.KeyName.TabIndex = 1;
			this.KeyName.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 69);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.KeyName,
																		  this.AddWait});
			this.Name = "Form1";
			this.Text = "Registry Waiter";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void AddWait_Click(object sender, System.EventArgs e) {
			int keyHandle;
			string registryKeyName = KeyName.Text;
			//create wait handle
			System.Threading.WaitHandle regWaitHandle = new System.Threading.AutoResetEvent(false);
			//open key
			RegOpenKeyEx((int)Microsoft.Win32.RegistryHive.LocalMachine, registryKeyName,
				0, KEY_READ, out keyHandle);
			if (keyHandle != 0){
				//ask for notification
				RegNotifyChangeKeyValue(keyHandle, 1, REG_NOTIFY_CHANGE_LAST_SET, regWaitHandle.Handle.ToInt32(), 1);
				//let thread pool handle the rest
				System.Threading.ThreadPool.RegisterWaitForSingleObject(regWaitHandle, 
					new System.Threading.WaitOrTimerCallback(RegistrKeyChanged), registryKeyName, -1, false);
				MessageBox.Show(this, "Key watch added");
			}
			else{
				MessageBox.Show(this, "Could not open key");
			}
		}

		public void RegistrKeyChanged(object state, bool timedOut){
			if (!timedOut)
				System.Windows.Forms.MessageBox.Show(this, (string)state + " Changed");
		}
	}
}
