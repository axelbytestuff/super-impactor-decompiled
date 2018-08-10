Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class UpdateCydia
		Inherits Form
		Private components As IContainer

		Private bComplete As Boolean

		Private bAsync As Boolean

		Private CrrLoadCydiaId As Integer

		Friend Overridable Property BackgroundWorker1 As BackgroundWorker
			Get
				stackVariable1 = Me._BackgroundWorker1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.ComponentModel.BackgroundWorker)
				Dim doWorkEventHandler As System.ComponentModel.DoWorkEventHandler = New System.ComponentModel.DoWorkEventHandler(AddressOf Me.BackgroundWorker1_DoWork)
				Dim backgroundWorker As System.ComponentModel.BackgroundWorker = Me._BackgroundWorker1
				If (backgroundWorker IsNot Nothing) Then
					RemoveHandler backgroundWorker.DoWork,  doWorkEventHandler
				End If
				Me._BackgroundWorker1 = value
				backgroundWorker = Me._BackgroundWorker1
				If (backgroundWorker IsNot Nothing) Then
					AddHandler backgroundWorker.DoWork,  doWorkEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdCancel As Button
			Get
				stackVariable1 = Me._cmdCancel
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdCancel_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdCancel
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdCancel = value
				button = Me._cmdCancel
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property lblCydia As Label

		Friend Overridable Property lblFileSize As Label

		Friend Overridable Property lblSpeed As Label

		Friend Overridable Property ProgressBar1 As ProgressBar
			Get
				stackVariable1 = Me._ProgressBar1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ProgressBar)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ProgressBar1_Click)
				Dim progressBar As System.Windows.Forms.ProgressBar = Me._ProgressBar1
				If (progressBar IsNot Nothing) Then
					RemoveHandler progressBar.Click,  eventHandler
				End If
				Me._ProgressBar1 = value
				progressBar = Me._ProgressBar1
				If (progressBar IsNot Nothing) Then
					AddHandler progressBar.Click,  eventHandler
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.bComplete = False
			Me.bAsync = False
			Me.CrrLoadCydiaId = -1
			Me.InitializeComponent()
		End Sub

		Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
			Dim enumerator As Dictionary(Of Integer, String).Enumerator = New Dictionary(Of Integer, String).Enumerator()
			Thread.Sleep(2000)
			Dim changeTextsSafe As UpdateCydia.ChangeTextsSafe = New UpdateCydia.ChangeTextsSafe(AddressOf Me.ChangeTexts)
			Dim completeSafe As UpdateCydia.CompleteSafe = New UpdateCydia.CompleteSafe(AddressOf Me.Complete)
			Dim cydiaRepos As Dictionary(Of Integer, String) = Database.GetCydiaRepos(False)
			Try
				enumerator = cydiaRepos.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As KeyValuePair(Of Integer, String) = enumerator.Current
					If (Me.CrrLoadCydiaId <> -1) Then
						If (Me.CrrLoadCydiaId <> current.Key) Then
							GoTo Label1
						End If
					End If
					If (Not Me.bAsync) Then
						MyBase.Invoke(changeTextsSafe, New Object() { current.Value, 0 })
					End If
					File.Delete("Packages")
					CydiaRepoManager.LoadPackages(current.Value)
					If (File.Exists("Packages")) Then
						Dim str As String = String.Concat("DELETE FROM list_app WHERE cydia_repos=", Conversions.ToString(current.Key))
						Dim num As Integer = (New SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery()
						If (Not Me.bAsync) Then
							CydiaRepoManager.ParsePackages(current.Key, Me, changeTextsSafe, current.Value)
						Else
							CydiaRepoManager.ParsePackages(current.Key, Nothing, Nothing, current.Value)
						End If
					End If
					If (Me.BackgroundWorker1.CancellationPending) Then
						If (Not Me.bAsync) Then
							MyBase.Invoke(completeSafe, New Object() { True })
						End If
						Return
					End If
				Label1:
				End While
			Finally
				DirectCast(enumerator, IDisposable).Dispose()
			End Try
			If (Not Me.bAsync) Then
				MyBase.Invoke(completeSafe, New Object() { False })
			End If
		End Sub

		Private Sub ChangeTexts(ByVal cydia As String, ByVal percent As Long)
			If (Operators.CompareString(cydia, "", False) <> 0) Then
				Me.lblCydia.Text = String.Concat("Repos: ", cydia)
			End If
			Me.ProgressBar1.Value = CInt(percent)
		End Sub

		Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.BackgroundWorker1.CancelAsync()
		End Sub

		Private Sub Complete(ByVal cancelled As Boolean)
			If (Not cancelled) Then
				Me.bComplete = True
				If (Me.CrrLoadCydiaId <> -1) Then
					Interaction.MsgBox("Add Repos completed!", MsgBoxStyle.OkOnly, Nothing)
				Else
					Interaction.MsgBox("Update all Repos completed!", MsgBoxStyle.OkOnly, Nothing)
				End If
				MyBase.Close()
			Else
				MyBase.Close()
			End If
		End Sub

		<DebuggerNonUserCode>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If (If(Not disposing, False, Me.components IsNot Nothing)) Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.lblSpeed = New Label()
			Me.lblFileSize = New Label()
			Me.ProgressBar1 = New ProgressBar()
			Me.Label1 = New Label()
			Me.cmdCancel = New Button()
			Me.BackgroundWorker1 = New BackgroundWorker()
			Me.lblCydia = New Label()
			MyBase.SuspendLayout()
			Me.lblSpeed.AutoSize = True
			Me.lblSpeed.Location = New Point(219, 38)
			Me.lblSpeed.Name = "lblSpeed"
			Me.lblSpeed.Size = New System.Drawing.Size(0, 13)
			Me.lblSpeed.TabIndex = 15
			Me.lblFileSize.AutoSize = True
			Me.lblFileSize.Location = New Point(62, 38)
			Me.lblFileSize.Name = "lblFileSize"
			Me.lblFileSize.Size = New System.Drawing.Size(0, 13)
			Me.lblFileSize.TabIndex = 14
			Me.ProgressBar1.Location = New Point(13, 53)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New System.Drawing.Size(414, 23)
			Me.ProgressBar1.TabIndex = 13
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(10, 34)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(111, 13)
			Me.Label1.TabIndex = 11
			Me.Label1.Text = "Update apps progress"
			Me.cmdCancel.Location = New Point(352, 11)
			Me.cmdCancel.Name = "cmdCancel"
			Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
			Me.cmdCancel.TabIndex = 10
			Me.cmdCancel.Text = "Cancel"
			Me.cmdCancel.UseVisualStyleBackColor = True
			Me.lblCydia.AutoSize = True
			Me.lblCydia.Location = New Point(10, 10)
			Me.lblCydia.Name = "lblCydia"
			Me.lblCydia.Size = New System.Drawing.Size(41, 13)
			Me.lblCydia.TabIndex = 16
			Me.lblCydia.Text = "Repos:"
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(439, 85)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.lblSpeed)
			MyBase.Controls.Add(Me.lblFileSize)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.cmdCancel)
			MyBase.Controls.Add(Me.lblCydia)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "UpdateCydia"
			Me.Text = "Update Reposes"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Public Function LoadApp(ByVal cydiaId As Integer) As Boolean
			Me.CrrLoadCydiaId = cydiaId
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.BackgroundWorker1.RunWorkerAsync()
			MyBase.ShowDialog()
			Return Me.bComplete
		End Function

		Private Sub ProgressBar1_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Public Function UpdateApp() As Boolean
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.BackgroundWorker1.RunWorkerAsync()
			MyBase.Show()
			Return Me.bComplete
		End Function

		Public Sub UpdateAppAsync()
			Me.bAsync = True
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.BackgroundWorker1.RunWorkerAsync()
		End Sub

		Public Delegate Sub ChangeTextsSafe(ByVal cydia As String, ByVal percent As Long)

		Public Delegate Sub CompleteSafe(ByVal cancelled As Boolean)
	End Class
End Namespace