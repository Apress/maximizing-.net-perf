using System;
using EnvDTE;

namespace SynchAdd {
	class CodeProcessor{
		private CodeClass _cc;
		protected bool _baseModificationOK = false;
		static readonly EnvDTE.vsCMFunction FunctionsThatCantBeAnnotatedAsVirtual = 
			EnvDTE.vsCMFunction.vsCMFunctionConstructor |
			EnvDTE.vsCMFunction.vsCMFunctionShared |
			EnvDTE.vsCMFunction.vsCMFunctionDestructor;

		public CodeProcessor(CodeClass cc){
			_cc = cc;
		}

		public bool MakeBaseClassCompatiableWithSyncPattern(){
			CodeType ct = (CodeType)_cc;

			bool isSynchronizedFound = false;
			bool syncRootFound = false;
			bool synchronizedFound = false;

			//check base class for non-virtual functions
			for(CodeElements baseClasses = _cc.Bases; baseClasses != null;){
				if (baseClasses.Count == 0)
					break;
				CodeClass baseClass = baseClasses.Item(1) as CodeClass;
				if (baseClass.Name == "Object")
					break;

				foreach(CodeElement ceBase in baseClass.Members){
					CodeFunction cfBase = ceBase as CodeFunction;
					if (cfBase != null){
						if (!cfBase.IsShared && !cfBase.CanOverride && 
							cfBase.FunctionKind != EnvDTE.vsCMFunction.vsCMFunctionConstructor
							&& cfBase.Name != "Finalize"){
							System.Windows.Forms.MessageBox.Show("The selected class contains base classes with non-virtual member functions." +
								"  Please change these to virtual to allow synchronized wrapper creation.");
							return false;
						}
					}
					CodeProperty cpBase = ceBase as CodeProperty;
					if (cpBase != null){
						try{
							if (!cpBase.Getter.IsShared && !cpBase.Getter.CanOverride){
								System.Windows.Forms.MessageBox.Show("The selected class contains base classes with non-virtual member properties." +
									"  Please change these to virtual to allow synchronized wrapper creation.");
								return false;
							}
						}catch(Exception){}
						try{
							if (!cpBase.Setter.IsShared && !cpBase.Setter.CanOverride){
								System.Windows.Forms.MessageBox.Show("The selected class contains base classes with non-virtual member properties." +
									"  Please change these to virtual to allow synchronized wrapper creation.");
								return false;
							}
						}catch(Exception){}
					}
				}
				baseClasses = baseClass.Bases;
			}

			//check current clas
			foreach(CodeElement member in ct.Members){
				CodeFunction cf = member as CodeFunction;
				if (!CheckFunctionIsVirtualAndFixIfOK(cf))
					return false;

				if (cf != null && cf.Name == "Synchronized"){
					synchronizedFound = true;
				}
				
				CodeProperty cp = member as CodeProperty;
				if (cp != null){
					if (cp.Name == "SyncRoot"){
						syncRootFound = true;
					}
					if (cp.Name == "IsSynchronized")
						isSynchronizedFound = true;
					//Getter and Setter throw if property lacks these methods
					try{
						if (!CheckFunctionIsVirtualAndFixIfOK(cp.Getter)) return false;
					}catch(Exception){}
					try{
						if (!CheckFunctionIsVirtualAndFixIfOK(cp.Setter)) return false;
					}catch(Exception){}
				}
			}

			if (!isSynchronizedFound){
				 CodeProperty isSynchProp =
					 _cc.AddProperty("IsSynchronized", "", EnvDTE.vsCMTypeRef.vsCMTypeRefBool, -1, EnvDTE.vsCMAccess.vsCMAccessPublic, null);
				CodeFunction isSynchPropGetter = isSynchProp.Getter;
				isSynchPropGetter.CanOverride = true;
				AddOneLineImpl("return false;", isSynchPropGetter, true);
			}
			if (!syncRootFound){
				CodeProperty syncRootProp =
					_cc.AddProperty("SyncRoot", "", EnvDTE.vsCMTypeRef.vsCMTypeRefObject, -1, EnvDTE.vsCMAccess.vsCMAccessPublic, null);
				CodeFunction syncRootGetter = syncRootProp.Getter;
				syncRootGetter.CanOverride = true;
				AddOneLineImpl("return this;", syncRootGetter, true);
			}
			if (!synchronizedFound){
				CodeFunction synchronizedStatic = _cc.AddFunction("Synchronized", EnvDTE.vsCMFunction.vsCMFunctionFunction,
					_cc.FullName, -1, EnvDTE.vsCMAccess.vsCMAccessPublic, null);
				synchronizedStatic.IsShared = true;
				synchronizedStatic.AddParameter("inst", _cc.FullName, -1);
				AddOneLineImpl("return new Synch" + _cc.Name + "(inst);", synchronizedStatic, true);
			}

			_cc.StartPoint.CreateEditPoint().SmartFormat(_cc.EndPoint);

			return true;
		}

		protected void AddOneLineImpl(string NewLine, CodeFunction Target, bool ReplaceExisingLine){
			//Target.GetEndPoint(EnvDTE.vsCMPart.vsCMPartBody);
			EditPoint startOfLastLine = Target.GetEndPoint(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter).CreateEditPoint();
			startOfLastLine.LineUp(1);
			startOfLastLine.StartOfLine();
			EditPoint endOfLastLine = Target.GetEndPoint(EnvDTE.vsCMPart.vsCMPartBodyWithDelimiter).CreateEditPoint();
			endOfLastLine.LineUp(1);
			endOfLastLine.EndOfLine();
			if (ReplaceExisingLine){
				startOfLastLine.Delete(endOfLastLine);
			}
			else
				startOfLastLine.EndOfLine();
			startOfLastLine.Insert(NewLine);
		}

		protected bool CheckFunctionIsVirtualAndFixIfOK(CodeFunction cf){
			if (cf != null && (cf.FunctionKind & FunctionsThatCantBeAnnotatedAsVirtual) == 0
				&& cf.CanOverride == false && cf.IsShared == false){
				if (!_baseModificationOK){
					System.Windows.Forms.DialogResult dr =
						System.Windows.Forms.MessageBox.Show("The member functions of the synchronized class must be virtual.  Is it OK to make these modifications?",
						"Modify type", System.Windows.Forms.MessageBoxButtons.YesNo);
					if (dr ==  System.Windows.Forms.DialogResult.Yes)
						_baseModificationOK = true;
					else
						return false;
				}
				cf.CanOverride = true;
			}
			return true;
		}

		public bool CreateSynchClass(){
			CodeClass synchClass = _cc.AddClass("Synch" + _cc.Name, -1, 0, 
				0, EnvDTE.vsCMAccess.vsCMAccessPrivate);
			synchClass.AddBase(_cc, -1);

			//member variables
			synchClass.AddVariable("_root", "System.Object", -1, EnvDTE.vsCMAccess.vsCMAccessPrivate, null);
			synchClass.AddVariable("_parent", _cc.FullName, -1, EnvDTE.vsCMAccess.vsCMAccessPrivate, null);

			//constructor - add function can't handle this at the moment
			EditPoint classEndPt = synchClass.EndPoint.CreateEditPoint();
			classEndPt.StartOfLine();
			classEndPt.Insert("\n");

			EditPoint editPt = synchClass.StartPoint.CreateEditPoint();
			editPt.LineDown(3);
			editPt.EndOfLine();
			editPt.Insert("\ninternal " + synchClass.Name + "(" + _cc.Name + 
				" parent){\n_parent = parent;\n_root = parent.SyncRoot;\n}\n");
			editPt.MoveToPoint(synchClass.StartPoint);
			editPt.SmartFormat(synchClass.EndPoint);

			//functions, properties and indexers
			for (CodeType ct = (CodeType)_cc; ct != null;){ 
				if (!AddMemberElementsFromType(ct, synchClass))
					return false;
				if (ct.Bases.Count != 0){
					ct = (CodeType)(ct.Bases.Item(1));
					if (ct.Name == "Object")
						break;
				}
			}			

			synchClass.StartPoint.CreateEditPoint().SmartFormat(synchClass.EndPoint);

			return true;
		}

		protected bool AddMemberElementsFromType(CodeType ct, CodeClass synchClass){
			string indexerParamList = "";
			foreach(CodeElement member in ct.Members){
				CodeFunction cf = member as CodeFunction;
				if (!AddSynchWrapperMember(synchClass, cf))
					return false;
					
				CodeProperty cp = member as CodeProperty;
				if (cp != null){
					string getter = "";
					string setter = "";
					//Getter and Setter throw if property lacks these methods
					try{
						if (cp.Getter != null) getter = cp.Name;
					}catch(Exception){}
					try{
						if (cp.Setter != null) setter = cp.Name;
					}catch(Exception){}

					CodeFunction spSetter = null;
					if (cp.Name != "SyncRoot"){
						CodeProperty sp = synchClass.AddProperty(getter, setter, cp.Type, -1, cp.Access, null);
						TextRanges tr = null;
						bool hasGetter = false;
						sp.StartPoint.CreateEditPoint().ReplacePattern(sp.EndPoint, sp.Type.AsString, "override " + sp.Type.AsString, 
							(int)EnvDTE.vsFindOptions.vsFindOptionsMatchWholeWord, ref tr);
						if (getter != ""){
							hasGetter = true;
							if (cp.Name != "IsSynchronized"){
								AddOneLineImpl(sp.Type.AsString + " ret;\nSystem.Threading.Monitor.Enter(_root);" +
									"\ntry{\nret = _parent." + getter + ";\n}\nfinally{System.Threading.Monitor.Exit(_root);}" +
									"\nreturn ret;", sp.Getter, true);
							}
							else
								AddOneLineImpl("return true;", sp.Getter, true);
						}
						if (setter != ""){
							//bug work-around
							foreach(CodeElement codeElm in synchClass.Members){
								if (codeElm.Name == sp.Name){
									spSetter = ((CodeProperty)codeElm).Setter;
								}
							}
								
							AddOneLineImpl("\nSystem.Threading.Monitor.Enter(_root);" +
								"\ntry{\n _parent." + setter + " = value;\n}\nfinally{System.Threading.Monitor.Exit(_root);}",
								spSetter, false);
						}

						if (cp.Name == "this"){//fix up indexer override
							//add parameters
							CodeFunction getterOrSetter;
							if (hasGetter){
								getterOrSetter = cp.Getter;
							}
							else{
								getterOrSetter = cp.Setter;
							}

							System.Text.StringBuilder paramList = new System.Text.StringBuilder();
							System.Text.StringBuilder paramListNoTypes = new System.Text.StringBuilder();
							bool first = true;
							foreach(CodeParameter p in cp.Getter.Parameters){
								if (!first){
									paramListNoTypes.Append(", ");
									paramList.Append(", ");
								}
								first = false;
								paramList.Append(p.Type.AsString);
								paramList.Append(" ");
								paramList.Append(p.Name);
								paramListNoTypes.Append(p.Name);
							}

							EditPoint firstLine = sp.StartPoint.CreateEditPoint();
							EditPoint secondLine = sp.StartPoint.CreateEditPoint();
							TextPoint endPt = sp.EndPoint;
							secondLine.LineDown(1); secondLine.StartOfLine();
							TextRanges tr1 = null;
							firstLine.ReplacePattern(secondLine, "this", "this[" + paramList.ToString() + "]", 
								(int)EnvDTE.vsFindOptions.vsFindOptionsMatchWholeWord, ref tr1);
								
							//calls - replace .this with [param1, param2]
							paramListNoTypes.Insert(0, '[');
							paramListNoTypes.Append("]");
							indexerParamList = paramListNoTypes.ToString();
						}
					}
				}
				if (indexerParamList != ""){
					TextRanges tr = null;
					synchClass.StartPoint.CreateEditPoint().ReplacePattern(
						synchClass.EndPoint, ".this", indexerParamList,
						(int)EnvDTE.vsFindOptions.vsFindOptionsMatchCase, ref tr);
				}
			}
			return true;
		}

		protected bool AddSynchWrapperMember(CodeClass synch, CodeFunction cf){
			if (cf != null && (cf.FunctionKind & FunctionsThatCantBeAnnotatedAsVirtual) == 0
				&& cf.CanOverride == true && cf.IsShared == false){
				//add prototype and parameters
				CodeFunction synchFunction = synch.AddFunction(cf.Name, cf.FunctionKind, cf.Type, -1 , cf.Access, null);
				foreach(CodeParameter param in cf.Parameters)
					synchFunction.AddParameter(param.Name, param.Type, -1);
				synchFunction.CanOverride = true;
				EditPoint replaceVirtual = synchFunction.StartPoint.CreateEditPoint();
				TextRanges tr = null;
				replaceVirtual.ReplacePattern(synchFunction.EndPoint, "virtual", "override", 
					(int)EnvDTE.vsFindOptions.vsFindOptionsMatchWholeWord, ref tr);

				//remove default return
				EditPoint editPt = synchFunction.EndPoint.CreateEditPoint();
				editPt.LineUp(1);
				editPt.StartOfLine();
				string returnType = cf.Type.AsString;
				if (returnType != "void"){
					EditPoint startOfLastLine = synchFunction.EndPoint.CreateEditPoint();
					startOfLastLine.LineUp(1);
					startOfLastLine.EndOfLine();
					editPt.Delete(startOfLastLine);
				}

				//generate method body
				System.Text.StringBuilder methodBody = new System.Text.StringBuilder(100);
				if (returnType != "void")
					methodBody.Append(cf.Type.AsString +  " ret;\n");
				methodBody.Append( 	
					"System.Threading.Monitor.Enter(_root);" +
					"\ntry{");
				if (returnType != "void")
					methodBody.Append("\nret = _parent." + cf.Name + "(");
				else
					methodBody.Append("\n_parent." + cf.Name + "(");
				bool first = true;
				foreach(CodeParameter p in cf.Parameters){
					if (!first)
						methodBody.Append(", ");
					first = false;
					int typeSpaceLocation = p.Type.AsString.IndexOf(' ');
					if (typeSpaceLocation != -1)//append out or ref to parameter
						methodBody.Append(p.Type.AsString.Substring(0, typeSpaceLocation+1));
					methodBody.Append(p.Name);
				}
				methodBody.Append(");");
				methodBody.Append(
					"\n}"+
					"\nfinally{System.Threading.Monitor.Exit(_root);}");
				if (returnType != "void")
					methodBody.Append("\nreturn ret;");

				//add new body to method
				editPt.Insert(methodBody.ToString());
				editPt.MoveToPoint(synchFunction.StartPoint);
				editPt.SmartFormat(synchFunction.EndPoint);
			}
			return true;
		}
	}
}