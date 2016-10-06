using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblMem;
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
			this.button1 = new System.Windows.Forms.Button();
			this.lblMem = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Allocate";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblMem
			// 
			this.lblMem.Location = new System.Drawing.Point(16, 56);
			this.lblMem.Name = "lblMem";
			this.lblMem.Size = new System.Drawing.Size(152, 23);
			this.lblMem.TabIndex = 1;
			this.lblMem.Text = "label1";
			this.lblMem.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 102);
			this.Controls.Add(this.lblMem);
			this.Controls.Add(this.button1);
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

		ArrayList _al = new ArrayList();
		private void button1_Click(object sender, System.EventArgs e) {
			try{
				for (int ix = 0; ix < 100; ++ix){
					int[] arr = new int[1000];
					_al.Add(arr);
				}
			}
			catch(OutOfMemoryException){
				MessageBox.Show("Out of memory");
			}

			this.lblMem.Visible = true;
			lblMem.Text = "Memory usage: " + System.Diagnostics.Process.GetCurrentProcess().WorkingSet.ToString();
		}

		private void Form1_Load(object sender, System.EventArgs e) {
		}
	}
}
