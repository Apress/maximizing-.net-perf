using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EnvDTE;

namespace SynchAdd
{
	/// <summary>
	/// Summary description for TagetClassSelect.
	/// </summary>
	public class TagetClassSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox ClassList;
		private System.Windows.Forms.Button Generate;
		private EnvDTE._DTE _applicationObject;

		public TagetClassSelect(EnvDTE._DTE applicationObject)
		{
			InitializeComponent();
			_applicationObject = applicationObject;
			PopulateDialog();
		}

		private System.Collections.Hashtable stringToCEMap = new System.Collections.Hashtable();
		protected CodeClass _targetClass;
		public CodeClass TargetClass{get{return _targetClass;}}

		protected void AddClass(CodeElement ce){
			CodeClass cc = ce as CodeClass;
			if (cc != null &&
				cc.IsAbstract == false &&
				(cc.Access == EnvDTE.vsCMAccess.vsCMAccessProject || cc.Access == EnvDTE.vsCMAccess.vsCMAccessPublic) &&
				((CodeType)ce).InfoLocation == EnvDTE.vsCMInfoLocation.vsCMInfoLocationProject){
				stringToCEMap[cc.FullName] = cc;
				ClassList.Items.Add(cc.FullName);
			}
			
			CodeNamespace cn = ce as CodeNamespace;
			if (cn != null){
				foreach(CodeElement ceChild in cn.Members){
					AddClass(ceChild);
				}
			}
		}

		protected virtual void PopulateDialog(){
			try{
				foreach(Project p in (System.Array)_applicationObject.ActiveSolutionProjects){
					foreach(CodeElement ce in p.CodeModel.CodeElements){
						AddClass(ce);
					}
				}
			}
			catch (Exception e){
				string m = e.Message;
				System.Windows.Forms.MessageBox.Show("Could not display class list");
				throw e;
			}
			ClassList.Sorted = true;
			if (ClassList.Items.Count != 0)
				ClassList.SelectedIndex = 0;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.ClassList = new System.Windows.Forms.ListBox();
			this.Generate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ClassList
			// 
			this.ClassList.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.ClassList.Location = new System.Drawing.Point(8, 56);
			this.ClassList.Name = "ClassList";
			this.ClassList.Size = new System.Drawing.Size(456, 225);
			this.ClassList.TabIndex = 0;
			// 
			// Generate
			// 
			this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.Generate.Location = new System.Drawing.Point(8, 296);
			this.Generate.Name = "Generate";
			this.Generate.Size = new System.Drawing.Size(456, 32);
			this.Generate.TabIndex = 1;
			this.Generate.Text = "Generate Synch. Wrapper";
			this.Generate.Click += new System.EventHandler(this.Generate_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Classes in project:";
			// 
			// TagetClassSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.Generate,
																		  this.ClassList});
			this.Name = "TagetClassSelect";
			this.ShowInTaskbar = false;
			this.Text = "Select a class to generate a synch. wrapper for ...";
			this.ResumeLayout(false);

		}
		#endregion

		private void Generate_Click(object sender, System.EventArgs e) {
			_targetClass = (CodeClass)stringToCEMap[ClassList.Text];
			Close();
		}
	}
}
