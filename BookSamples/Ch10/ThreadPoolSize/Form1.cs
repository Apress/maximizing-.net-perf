using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

[
// IID_ICorThreadpool
Guid("84680D3A-B2C1-46e8-ACC2-DBC0A359159A"),
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
]
interface ICorThreadPool {
	void CorRegisterWaitForSingleObject(); 
	void CorUnregisterWait(); 
	void CorQueueUserWorkItem(); 
	void CorCreateTimer(); 
	void CorChangeTimer(); 
	void CorDeleteTimer(); 
	void CorBindIoCompletionCallback(); 
	void CorCallOrQueueUserWorkItem();
	void CorSetMaxThreads( uint MaxWorkerThreads, uint MaxIOCompletionThreads );
	void CorGetMaxThreads( out uint MaxWorkerThreads, out uint MaxIOCompletionThreads );
	void CorGetAvailableThreads( out uint AvailableWorkerThreads, out uint AvailableIOCompletionThreads );
}


namespace ThreadPoolSize
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button GetSize;
		private System.Windows.Forms.Button SetSize;
		private System.Windows.Forms.TextBox ThreadPoolSize;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.GetSize = new System.Windows.Forms.Button();
			this.SetSize = new System.Windows.Forms.Button();
			this.ThreadPoolSize = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// GetSize
			// 
			this.GetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GetSize.Location = new System.Drawing.Point(0, 16);
			this.GetSize.Name = "GetSize";
			this.GetSize.Size = new System.Drawing.Size(216, 32);
			this.GetSize.TabIndex = 0;
			this.GetSize.Text = "Get Thread Pool Size";
			this.GetSize.Click += new System.EventHandler(this.GetSize_Click);
			// 
			// SetSize
			// 
			this.SetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SetSize.Location = new System.Drawing.Point(0, 64);
			this.SetSize.Name = "SetSize";
			this.SetSize.Size = new System.Drawing.Size(216, 32);
			this.SetSize.TabIndex = 1;
			this.SetSize.Text = "Set Thread Pool Size";
			this.SetSize.Click += new System.EventHandler(this.SetSize_Click);
			// 
			// ThreadPoolSize
			// 
			this.ThreadPoolSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ThreadPoolSize.Location = new System.Drawing.Point(232, 64);
			this.ThreadPoolSize.Name = "ThreadPoolSize";
			this.ThreadPoolSize.TabIndex = 2;
			this.ThreadPoolSize.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ThreadPoolSize,
																		  this.SetSize,
																		  this.GetSize});
			this.Name = "Form1";
			this.Text = "Thread Pool Size";
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

		private void GetSize_Click(object sender, System.EventArgs e) {
			int maxWorkerThreads, maxIOThreads;
			System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxIOThreads);
			MessageBox.Show(this, "Maximum worker threads: " + maxWorkerThreads.ToString());
		}
	
		private void SetSize_Click(object sender, System.EventArgs e) {
			ICorThreadPool tp = (ICorThreadPool)new mscoree.CorRuntimeHostClass();
			tp.CorSetMaxThreads(System.Convert.ToUInt32(ThreadPoolSize.Text), 25);
			MessageBox.Show(this, "New pool size set");
		}
	}
}
