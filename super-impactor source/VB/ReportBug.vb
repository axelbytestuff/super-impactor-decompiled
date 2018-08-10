Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net.Http
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class ReportBug
		Inherits Form
		Private components As IContainer

		Friend Overridable Property cmdClose As Button
			Get
				stackVariable1 = Me._cmdClose
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdClose_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdClose
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdClose = value
				button = Me._cmdClose
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdSend As Button
			Get
				stackVariable1 = Me._cmdSend
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdSend_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdSend
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdSend = value
				button = Me._cmdSend
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property Label2 As Label

		Friend Overridable Property Label3 As Label

		Friend Overridable Property lblLoading As Label

		Friend Overridable Property picLoading As PictureBox

		Friend Overridable Property txtEmail As TextBox

		Friend Overridable Property txtMessage As TextBox

		Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Async Sub cmdSend_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.cmdSend.Enabled = False
			Me.picLoading.Visible = True
			Me.lblLoading.Visible = True
			Dim str As String = Await ReportBug.sendLog(Me.txtEmail.Text, Me.txtMessage.Text)
			Dim str1 As String = str
			If (Operators.CompareString(str1, "", False) <> 0) Then
				Me.cmdSend.Enabled = True
				Me.picLoading.Visible = False
				Me.lblLoading.Visible = False
				Interaction.MsgBox(str1, MsgBoxStyle.OkOnly, Nothing)
			Else
				Interaction.MsgBox("Send successfully. We will contact you after processing your request", MsgBoxStyle.OkOnly, Nothing)
				Me.Close()
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
			Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportBug))
			Me.Label1 = New Label()
			Me.txtEmail = New TextBox()
			Me.txtMessage = New TextBox()
			Me.Label2 = New Label()
			Me.cmdSend = New Button()
			Me.cmdClose = New Button()
			Me.Label3 = New Label()
			Me.lblLoading = New Label()
			Me.picLoading = New PictureBox()
			DirectCast(Me.picLoading, ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(13, 22)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(32, 13)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Email"
			Me.txtEmail.Location = New Point(65, 19)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.Size = New System.Drawing.Size(214, 20)
			Me.txtEmail.TabIndex = 1
			Me.txtMessage.Location = New Point(65, 59)
			Me.txtMessage.Multiline = True
			Me.txtMessage.Name = "txtMessage"
			Me.txtMessage.Size = New System.Drawing.Size(214, 223)
			Me.txtMessage.TabIndex = 3
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Point(13, 62)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(50, 13)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "Message"
			Me.cmdSend.Location = New Point(304, 19)
			Me.cmdSend.Name = "cmdSend"
			Me.cmdSend.Size = New System.Drawing.Size(75, 23)
			Me.cmdSend.TabIndex = 4
			Me.cmdSend.Text = "Send"
			Me.cmdSend.UseVisualStyleBackColor = True
			Me.cmdClose.Location = New Point(304, 59)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(75, 23)
			Me.cmdClose.TabIndex = 5
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.Label3.AutoSize = True
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label3.Location = New Point(62, 40)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(236, 13)
			Me.Label3.TabIndex = 6
			Me.Label3.Text = "Optional (we will support by email ASAP)"
			Me.lblLoading.AutoSize = True
			Me.lblLoading.Location = New Point(314, 200)
			Me.lblLoading.Name = "lblLoading"
			Me.lblLoading.Size = New System.Drawing.Size(55, 13)
			Me.lblLoading.TabIndex = 8
			Me.lblLoading.Text = "Sending..."
			Me.lblLoading.Visible = False
			Me.picLoading.Image = DirectCast(componentResourceManager.GetObject("picLoading.Image"), Image)
			Me.picLoading.Location = New Point(310, 141)
			Me.picLoading.Name = "picLoading"
			Me.picLoading.Size = New System.Drawing.Size(59, 56)
			Me.picLoading.TabIndex = 10
			Me.picLoading.TabStop = False
			Me.picLoading.Visible = False
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(405, 295)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.picLoading)
			MyBase.Controls.Add(Me.lblLoading)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdSend)
			MyBase.Controls.Add(Me.txtMessage)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtEmail)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Name = "ReportBug"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Support"
			DirectCast(Me.picLoading, ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Public Shared Async Function sendLog(ByVal email As String, ByVal message As String) As Task(Of String)
			Dim str As String
			str = If(Not File.Exists(String.Concat(AppConst.m_rootPath, "/Log/SuperImpactor.log")), String.Concat(AppConst.m_rootPath, "/bin/Debug/Log/SuperImpactor.log"), String.Concat(AppConst.m_rootPath, "/Log/SuperImpactor.log"))
			Dim fileStream As System.IO.FileStream = New System.IO.FileStream(str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
			Dim streamReader As System.IO.StreamReader = New System.IO.StreamReader(fileStream)
			Dim str1 As String = ""
			While Not streamReader.EndOfStream
				str1 = String.Concat(str1, streamReader.ReadLine(), "" & VbCrLf & "")
			End While
			streamReader.Close()
			fileStream.Close()
			If (str1.Length > 10000) Then
				str1 = str1.Substring(str1.Length - 10000)
			End If
			Dim versionString() As String = { Environment.OSVersion.VersionString, "" & VbCrLf & "v", Assembly.GetExecutingAssembly().GetName().Version.ToString(), "" & VbCrLf & "", message, "" & VbCrLf & "" }
			message = String.Concat(versionString)
			Dim httpClient As System.Net.Http.HttpClient = New System.Net.Http.HttpClient()
			Dim strs As Dictionary(Of String, String) = New Dictionary(Of String, String)() From
			{
				{ "email", email },
				{ "message", message },
				{ "log", str1 }
			}
			Dim formUrlEncodedContent As System.Net.Http.FormUrlEncodedContent = New System.Net.Http.FormUrlEncodedContent(strs)
			Dim httpResponseMessage As System.Net.Http.HttpResponseMessage = Await httpClient.PostAsync("http://superimpactor.net/api/send_log.php", formUrlEncodedContent)
			httpResponseMessage.EnsureSuccessStatusCode()
			Await httpResponseMessage.Content.ReadAsStringAsync()
			Dim str2 As String = ""
			Return str2
		End Function
	End Class
End Namespace