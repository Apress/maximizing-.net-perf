using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Test
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Compress;
		private System.Windows.Forms.Button Expand;
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
			this.Compress = new System.Windows.Forms.Button();
			this.Expand = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Compress
			// 
			this.Compress.Location = new System.Drawing.Point(8, 16);
			this.Compress.Name = "Compress";
			this.Compress.Size = new System.Drawing.Size(112, 23);
			this.Compress.TabIndex = 0;
			this.Compress.Text = "Compress";
			this.Compress.Click += new System.EventHandler(this.Compress_Click);
			// 
			// Expand
			// 
			this.Expand.Location = new System.Drawing.Point(8, 56);
			this.Expand.Name = "Expand";
			this.Expand.Size = new System.Drawing.Size(112, 23);
			this.Expand.TabIndex = 0;
			this.Expand.Text = "Expand";
			this.Expand.Click += new System.EventHandler(this.Expand_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Compress,
																		  this.Expand});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Compress_Click(object sender, System.EventArgs e) {
			string fileName = @"C:\Nick\DOT_NET_PERF_VOL_1\articles\Compress Stream\Reference\CLZW\Debug\wrnpc10.txt";
			string fileOut = @"C:\Nick\DOT_NET_PERF_VOL_1\articles\Compress Stream\Reference\CLZW\Debug\wrnpc10.out2";
			//in
			System.IO.FileStream fs = System.IO.File.OpenRead(fileName);
			byte[] buff = new byte[new System.IO.FileInfo(fileName).Length];
			fs.Read(buff, 0, buff.Length);
			//out
			System.IO.FileStream fsOut = System.IO.File.OpenWrite(fileOut);
			DotNetPerformance.IO.CompressedStream cs = new DotNetPerformance.IO.CompressedStream(fsOut);
			for (int i = 0; i < buff.Length; ++i){
				byte[] data = new byte[1];
				data[0] = buff[i];
				cs.Write(data, 0, 1);
			}
			cs.Close();
		}

		private void Expand_Click(object sender, System.EventArgs e) {
			string fileName = @"C:\Nick\DOT_NET_PERF_VOL_1\articles\Compress Stream\Reference\CLZW\Debug\wrnpc10.lzw";
			string fileOut = @"C:\Nick\DOT_NET_PERF_VOL_1\articles\Compress Stream\Reference\CLZW\Debug\wrnpc10.txt2";
			//in
			System.IO.FileStream fs = System.IO.File.OpenRead(fileName);
			DotNetPerformance.IO.CompressedStream cs = new DotNetPerformance.IO.CompressedStream(fs);
			//out
			System.IO.FileStream fsOut = System.IO.File.OpenWrite(fileOut);

			const int buffSize = 1;
			int lengthRead = 0;
			byte[] buff = new byte[buffSize];
			do{
				//read
				lengthRead = cs.Read(buff, 0, buff.Length);
				//write
				fsOut.Write(buff, 0, lengthRead);
			}while (lengthRead == buffSize);

			cs.Close();
			fsOut.Close();
		}

		private void Form1_Load(object sender, System.EventArgs e) {
		
		}
	}
}
