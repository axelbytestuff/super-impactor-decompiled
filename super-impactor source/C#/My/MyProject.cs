using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using SuperImpactor;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SuperImpactor.My
{
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	[HideModuleName]
	internal static class MyProject
	{
		private readonly static MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider;

		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider;

		private readonly static MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider;

		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.User")]
		internal static Microsoft.VisualBasic.ApplicationServices.User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		static MyProject()
		{
			MyProject.m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();
			MyProject.m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();
			MyProject.m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();
			MyProject.m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();
			MyProject.m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class MyForms
		{
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public AppDetail m_AppDetail;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public AppIdDelete m_AppIdDelete;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public AppleAccounts m_AppleAccounts;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public AutoResign m_AutoResign;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CertificateDelete m_CertificateDelete;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CydiaRepoManager m_CydiaRepoManager;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public DownloadFiles m_DownloadFiles;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public DownloadProgress m_DownloadProgress;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmSuperImpactor m_frmSuperImpactor;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Install m_Install;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public InstallResult m_InstallResult;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public Main m_Main;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public ReportBug m_ReportBug;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public UpdateCydia m_UpdateCydia;

			[EditorBrowsable(EditorBrowsableState.Never)]
			public URLInstall m_URLInstall;

			public AppDetail AppDetail
			{
				[DebuggerHidden]
				get
				{
					this.m_AppDetail = MyProject.MyForms.Create__Instance__<AppDetail>(this.m_AppDetail);
					return this.m_AppDetail;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_AppDetail)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<AppDetail>(ref this.m_AppDetail);
					}
				}
			}

			public AppIdDelete AppIdDelete
			{
				[DebuggerHidden]
				get
				{
					this.m_AppIdDelete = MyProject.MyForms.Create__Instance__<AppIdDelete>(this.m_AppIdDelete);
					return this.m_AppIdDelete;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_AppIdDelete)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<AppIdDelete>(ref this.m_AppIdDelete);
					}
				}
			}

			public AppleAccounts AppleAccounts
			{
				[DebuggerHidden]
				get
				{
					this.m_AppleAccounts = MyProject.MyForms.Create__Instance__<AppleAccounts>(this.m_AppleAccounts);
					return this.m_AppleAccounts;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_AppleAccounts)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<AppleAccounts>(ref this.m_AppleAccounts);
					}
				}
			}

			public AutoResign AutoResign
			{
				[DebuggerHidden]
				get
				{
					this.m_AutoResign = MyProject.MyForms.Create__Instance__<AutoResign>(this.m_AutoResign);
					return this.m_AutoResign;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_AutoResign)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<AutoResign>(ref this.m_AutoResign);
					}
				}
			}

			public CertificateDelete CertificateDelete
			{
				[DebuggerHidden]
				get
				{
					this.m_CertificateDelete = MyProject.MyForms.Create__Instance__<CertificateDelete>(this.m_CertificateDelete);
					return this.m_CertificateDelete;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_CertificateDelete)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<CertificateDelete>(ref this.m_CertificateDelete);
					}
				}
			}

			public CydiaRepoManager CydiaRepoManager
			{
				[DebuggerHidden]
				get
				{
					this.m_CydiaRepoManager = MyProject.MyForms.Create__Instance__<CydiaRepoManager>(this.m_CydiaRepoManager);
					return this.m_CydiaRepoManager;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_CydiaRepoManager)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<CydiaRepoManager>(ref this.m_CydiaRepoManager);
					}
				}
			}

			public DownloadFiles DownloadFiles
			{
				[DebuggerHidden]
				get
				{
					this.m_DownloadFiles = MyProject.MyForms.Create__Instance__<DownloadFiles>(this.m_DownloadFiles);
					return this.m_DownloadFiles;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_DownloadFiles)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<DownloadFiles>(ref this.m_DownloadFiles);
					}
				}
			}

			public DownloadProgress DownloadProgress
			{
				[DebuggerHidden]
				get
				{
					this.m_DownloadProgress = MyProject.MyForms.Create__Instance__<DownloadProgress>(this.m_DownloadProgress);
					return this.m_DownloadProgress;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_DownloadProgress)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<DownloadProgress>(ref this.m_DownloadProgress);
					}
				}
			}

			public frmSuperImpactor frmSuperImpactor
			{
				[DebuggerHidden]
				get
				{
					this.m_frmSuperImpactor = MyProject.MyForms.Create__Instance__<frmSuperImpactor>(this.m_frmSuperImpactor);
					return this.m_frmSuperImpactor;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmSuperImpactor)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmSuperImpactor>(ref this.m_frmSuperImpactor);
					}
				}
			}

			public Install Install
			{
				[DebuggerHidden]
				get
				{
					this.m_Install = MyProject.MyForms.Create__Instance__<Install>(this.m_Install);
					return this.m_Install;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_Install)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Install>(ref this.m_Install);
					}
				}
			}

			public InstallResult InstallResult
			{
				[DebuggerHidden]
				get
				{
					this.m_InstallResult = MyProject.MyForms.Create__Instance__<InstallResult>(this.m_InstallResult);
					return this.m_InstallResult;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_InstallResult)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<InstallResult>(ref this.m_InstallResult);
					}
				}
			}

			public Main Main
			{
				[DebuggerHidden]
				get
				{
					this.m_Main = MyProject.MyForms.Create__Instance__<Main>(this.m_Main);
					return this.m_Main;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_Main)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Main>(ref this.m_Main);
					}
				}
			}

			public ReportBug ReportBug
			{
				[DebuggerHidden]
				get
				{
					this.m_ReportBug = MyProject.MyForms.Create__Instance__<ReportBug>(this.m_ReportBug);
					return this.m_ReportBug;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_ReportBug)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<ReportBug>(ref this.m_ReportBug);
					}
				}
			}

			public UpdateCydia UpdateCydia
			{
				[DebuggerHidden]
				get
				{
					this.m_UpdateCydia = MyProject.MyForms.Create__Instance__<UpdateCydia>(this.m_UpdateCydia);
					return this.m_UpdateCydia;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_UpdateCydia)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<UpdateCydia>(ref this.m_UpdateCydia);
					}
				}
			}

			public URLInstall URLInstall
			{
				[DebuggerHidden]
				get
				{
					this.m_URLInstall = MyProject.MyForms.Create__Instance__<URLInstall>(this.m_URLInstall);
					return this.m_URLInstall;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_URLInstall)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<URLInstall>(ref this.m_URLInstall);
					}
				}
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance)
			where T : Form, new()
			{
				T instance;
				if ((Instance == null ? false : !Instance.IsDisposed))
				{
					instance = Instance;
				}
				else
				{
					if (MyProject.MyForms.m_FormBeingCreated == null)
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					else if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						try
						{
							instance = Activator.CreateInstance<T>();
						}
						catch (TargetInvocationException targetInvocationException) when (targetInvocationException.InnerException != null)
						{
							string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[] { targetInvocationException.InnerException.Message });
							throw new InvalidOperationException(resourceString, targetInvocationException.InnerException);
						}
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return instance;
			}

			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return this.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return this.GetHashCode();
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return this.ToString();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}

			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance)
			where T : new()
			{
				T t;
				t = (instance != null ? instance : Activator.CreateInstance<T>());
				return t;
			}

			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return this.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return this.GetHashCode();
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return this.ToString();
			}
		}

		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal sealed class ThreadSafeObjectProvider<T>
		where T : new()
		{
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;

			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}
		}
	}
}