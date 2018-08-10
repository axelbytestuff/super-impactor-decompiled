Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports SuperImpactor
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace SuperImpactor.My
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	<HideModuleName>
	Friend Module MyProject
		Private ReadOnly m_ComputerObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyComputer)

		Private ReadOnly m_AppObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyApplication)

		Private ReadOnly m_UserObjectProvider As MyProject.ThreadSafeObjectProvider(Of Microsoft.VisualBasic.ApplicationServices.User)

		Private m_MyFormsObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms)

		Private ReadOnly m_MyWebServicesObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices)

		<HelpKeyword("My.Application")>
		Friend ReadOnly Property Application As MyApplication
			<DebuggerHidden>
			Get
				Return MyProject.m_AppObjectProvider.GetInstance
			End Get
		End Property

		<HelpKeyword("My.Computer")>
		Friend ReadOnly Property Computer As MyComputer
			<DebuggerHidden>
			Get
				Return MyProject.m_ComputerObjectProvider.GetInstance
			End Get
		End Property

		<HelpKeyword("My.Forms")>
		Friend ReadOnly Property Forms As MyProject.MyForms
			<DebuggerHidden>
			Get
				Return MyProject.m_MyFormsObjectProvider.GetInstance
			End Get
		End Property

		<HelpKeyword("My.User")>
		Friend ReadOnly Property User As Microsoft.VisualBasic.ApplicationServices.User
			<DebuggerHidden>
			Get
				Return MyProject.m_UserObjectProvider.GetInstance
			End Get
		End Property

		<HelpKeyword("My.WebServices")>
		Friend ReadOnly Property WebServices As MyProject.MyWebServices
			<DebuggerHidden>
			Get
				Return MyProject.m_MyWebServicesObjectProvider.GetInstance
			End Get
		End Property

		Sub New()
			MyProject.m_ComputerObjectProvider = New MyProject.ThreadSafeObjectProvider(Of MyComputer)()
			MyProject.m_AppObjectProvider = New MyProject.ThreadSafeObjectProvider(Of MyApplication)()
			MyProject.m_UserObjectProvider = New MyProject.ThreadSafeObjectProvider(Of Microsoft.VisualBasic.ApplicationServices.User)()
			MyProject.m_MyFormsObjectProvider = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms)()
			MyProject.m_MyWebServicesObjectProvider = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices)()
		End Sub

		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")>
		Friend NotInheritable Class MyForms
			<ThreadStatic>
			Private Shared m_FormBeingCreated As Hashtable

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_AppDetail As AppDetail

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_AppIdDelete As AppIdDelete

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_AppleAccounts As AppleAccounts

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_AutoResign As AutoResign

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_CertificateDelete As CertificateDelete

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_CydiaRepoManager As CydiaRepoManager

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_DownloadFiles As DownloadFiles

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_DownloadProgress As DownloadProgress

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmSuperImpactor As frmSuperImpactor

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Install As Install

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_InstallResult As InstallResult

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_Main As Main

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_ReportBug As ReportBug

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_UpdateCydia As UpdateCydia

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_URLInstall As URLInstall

			Public Property AppDetail As AppDetail
				<DebuggerHidden>
				Get
					Me.m_AppDetail = MyProject.MyForms.Create__Instance__(Of AppDetail)(Me.m_AppDetail)
					Return Me.m_AppDetail
				End Get
				<DebuggerHidden>
				Set(ByVal value As AppDetail)
					If (value <> Me.m_AppDetail) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of AppDetail)(Me.m_AppDetail)
					End If
				End Set
			End Property

			Public Property AppIdDelete As AppIdDelete
				<DebuggerHidden>
				Get
					Me.m_AppIdDelete = MyProject.MyForms.Create__Instance__(Of AppIdDelete)(Me.m_AppIdDelete)
					Return Me.m_AppIdDelete
				End Get
				<DebuggerHidden>
				Set(ByVal value As AppIdDelete)
					If (value <> Me.m_AppIdDelete) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of AppIdDelete)(Me.m_AppIdDelete)
					End If
				End Set
			End Property

			Public Property AppleAccounts As AppleAccounts
				<DebuggerHidden>
				Get
					Me.m_AppleAccounts = MyProject.MyForms.Create__Instance__(Of AppleAccounts)(Me.m_AppleAccounts)
					Return Me.m_AppleAccounts
				End Get
				<DebuggerHidden>
				Set(ByVal value As AppleAccounts)
					If (value <> Me.m_AppleAccounts) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of AppleAccounts)(Me.m_AppleAccounts)
					End If
				End Set
			End Property

			Public Property AutoResign As AutoResign
				<DebuggerHidden>
				Get
					Me.m_AutoResign = MyProject.MyForms.Create__Instance__(Of AutoResign)(Me.m_AutoResign)
					Return Me.m_AutoResign
				End Get
				<DebuggerHidden>
				Set(ByVal value As AutoResign)
					If (value <> Me.m_AutoResign) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of AutoResign)(Me.m_AutoResign)
					End If
				End Set
			End Property

			Public Property CertificateDelete As CertificateDelete
				<DebuggerHidden>
				Get
					Me.m_CertificateDelete = MyProject.MyForms.Create__Instance__(Of CertificateDelete)(Me.m_CertificateDelete)
					Return Me.m_CertificateDelete
				End Get
				<DebuggerHidden>
				Set(ByVal value As CertificateDelete)
					If (value <> Me.m_CertificateDelete) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of CertificateDelete)(Me.m_CertificateDelete)
					End If
				End Set
			End Property

			Public Property CydiaRepoManager As CydiaRepoManager
				<DebuggerHidden>
				Get
					Me.m_CydiaRepoManager = MyProject.MyForms.Create__Instance__(Of CydiaRepoManager)(Me.m_CydiaRepoManager)
					Return Me.m_CydiaRepoManager
				End Get
				<DebuggerHidden>
				Set(ByVal value As CydiaRepoManager)
					If (value <> Me.m_CydiaRepoManager) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of CydiaRepoManager)(Me.m_CydiaRepoManager)
					End If
				End Set
			End Property

			Public Property DownloadFiles As DownloadFiles
				<DebuggerHidden>
				Get
					Me.m_DownloadFiles = MyProject.MyForms.Create__Instance__(Of DownloadFiles)(Me.m_DownloadFiles)
					Return Me.m_DownloadFiles
				End Get
				<DebuggerHidden>
				Set(ByVal value As DownloadFiles)
					If (value <> Me.m_DownloadFiles) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of DownloadFiles)(Me.m_DownloadFiles)
					End If
				End Set
			End Property

			Public Property DownloadProgress As DownloadProgress
				<DebuggerHidden>
				Get
					Me.m_DownloadProgress = MyProject.MyForms.Create__Instance__(Of DownloadProgress)(Me.m_DownloadProgress)
					Return Me.m_DownloadProgress
				End Get
				<DebuggerHidden>
				Set(ByVal value As DownloadProgress)
					If (value <> Me.m_DownloadProgress) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of DownloadProgress)(Me.m_DownloadProgress)
					End If
				End Set
			End Property

			Public Property frmSuperImpactor As frmSuperImpactor
				<DebuggerHidden>
				Get
					Me.m_frmSuperImpactor = MyProject.MyForms.Create__Instance__(Of frmSuperImpactor)(Me.m_frmSuperImpactor)
					Return Me.m_frmSuperImpactor
				End Get
				<DebuggerHidden>
				Set(ByVal value As frmSuperImpactor)
					If (value <> Me.m_frmSuperImpactor) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmSuperImpactor)(Me.m_frmSuperImpactor)
					End If
				End Set
			End Property

			Public Property Install As Install
				<DebuggerHidden>
				Get
					Me.m_Install = MyProject.MyForms.Create__Instance__(Of Install)(Me.m_Install)
					Return Me.m_Install
				End Get
				<DebuggerHidden>
				Set(ByVal value As Install)
					If (value <> Me.m_Install) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Install)(Me.m_Install)
					End If
				End Set
			End Property

			Public Property InstallResult As InstallResult
				<DebuggerHidden>
				Get
					Me.m_InstallResult = MyProject.MyForms.Create__Instance__(Of InstallResult)(Me.m_InstallResult)
					Return Me.m_InstallResult
				End Get
				<DebuggerHidden>
				Set(ByVal value As InstallResult)
					If (value <> Me.m_InstallResult) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of InstallResult)(Me.m_InstallResult)
					End If
				End Set
			End Property

			Public Property Main As Main
				<DebuggerHidden>
				Get
					Me.m_Main = MyProject.MyForms.Create__Instance__(Of Main)(Me.m_Main)
					Return Me.m_Main
				End Get
				<DebuggerHidden>
				Set(ByVal value As Main)
					If (value <> Me.m_Main) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of Main)(Me.m_Main)
					End If
				End Set
			End Property

			Public Property ReportBug As ReportBug
				<DebuggerHidden>
				Get
					Me.m_ReportBug = MyProject.MyForms.Create__Instance__(Of ReportBug)(Me.m_ReportBug)
					Return Me.m_ReportBug
				End Get
				<DebuggerHidden>
				Set(ByVal value As ReportBug)
					If (value <> Me.m_ReportBug) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of ReportBug)(Me.m_ReportBug)
					End If
				End Set
			End Property

			Public Property UpdateCydia As UpdateCydia
				<DebuggerHidden>
				Get
					Me.m_UpdateCydia = MyProject.MyForms.Create__Instance__(Of UpdateCydia)(Me.m_UpdateCydia)
					Return Me.m_UpdateCydia
				End Get
				<DebuggerHidden>
				Set(ByVal value As UpdateCydia)
					If (value <> Me.m_UpdateCydia) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of UpdateCydia)(Me.m_UpdateCydia)
					End If
				End Set
			End Property

			Public Property URLInstall As URLInstall
				<DebuggerHidden>
				Get
					Me.m_URLInstall = MyProject.MyForms.Create__Instance__(Of URLInstall)(Me.m_URLInstall)
					Return Me.m_URLInstall
				End Get
				<DebuggerHidden>
				Set(ByVal value As URLInstall)
					If (value <> Me.m_URLInstall) Then
						If (value IsNot Nothing) Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of URLInstall)(Me.m_URLInstall)
					End If
				End Set
			End Property

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
				MyBase.New()
			End Sub

			<DebuggerHidden>
			Private Shared Function Create__Instance__(Of T As {Form, New})(ByVal Instance As T) As T
				Dim t1 As T
				If (If(Instance Is Nothing, False, Not Instance.IsDisposed)) Then
					t1 = Instance
				Else
					If (MyProject.MyForms.m_FormBeingCreated Is Nothing) Then
						MyProject.MyForms.m_FormBeingCreated = New Hashtable()
					ElseIf (MyProject.MyForms.m_FormBeingCreated.ContainsKey(GetType(T))) Then
						Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(-1) {}))
					End If
					MyProject.MyForms.m_FormBeingCreated.Add(GetType(T), Nothing)
					Try
						Try
							t1 = Activator.CreateInstance(Of T)()
						Catch targetInvocationException As System.Reflection.TargetInvocationException When targetInvocationException.InnerException IsNot Nothing
							Dim resourceString As String = Utils.GetResourceString("WinForms_SeeInnerException", New String() { targetInvocationException.InnerException.Message })
							Throw New InvalidOperationException(resourceString, targetInvocationException.InnerException)
						End Try
					Finally
						MyProject.MyForms.m_FormBeingCreated.Remove(GetType(T))
					End Try
				End If
				Return t1
			End Function

			<DebuggerHidden>
			Private Sub Dispose__Instance__(Of T As Form)(ByRef instance As T)
				instance.Dispose()
				instance = Nothing
			End Sub

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function Equals(ByVal o As Object) As Boolean
				Return Me.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function GetHashCode() As Integer
				Return Me.GetHashCode()
			End Function

			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Shadows Function [GetType]() As Type
				Return GetType(MyProject.MyForms)
			End Function

			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function ToString() As String
				Return Me.ToString()
			End Function
		End Class

		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
		Friend NotInheritable Class MyWebServices
			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
				MyBase.New()
			End Sub

			<DebuggerHidden>
			Private Shared Function Create__Instance__(Of T As New)(ByVal instance As T) As T
				Dim t1 As T
				t1 = If(instance IsNot Nothing, instance, Activator.CreateInstance(Of T)())
				Return t1
			End Function

			<DebuggerHidden>
			Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
				instance = Nothing
			End Sub

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function Equals(ByVal o As Object) As Boolean
				Return Me.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function GetHashCode() As Integer
				Return Me.GetHashCode()
			End Function

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Shadows Function [GetType]() As Type
				Return GetType(MyProject.MyWebServices)
			End Function

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function ToString() As String
				Return Me.ToString()
			End Function
		End Class

		<ComVisible(False)>
		<EditorBrowsable(EditorBrowsableState.Never)>
		Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
			<CompilerGenerated>
			<ThreadStatic>
			Private Shared m_ThreadStaticValue As T

			Friend ReadOnly Property GetInstance As T
				<DebuggerHidden>
				Get
					If (MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue Is Nothing) Then
						MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue = Activator.CreateInstance(Of T)()
					End If
					Return MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue
				End Get
			End Property

			<DebuggerHidden>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
				MyBase.New()
			End Sub
		End Class
	End Module
End Namespace