Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Web
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class URLInstall
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

		Friend Overridable Property cmdNext As Button
			Get
				stackVariable1 = Me._cmdNext
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdNext_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdNext
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdNext = value
				button = Me._cmdNext
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property optDailyUpload As RadioButton
			Get
				stackVariable1 = Me._optDailyUpload
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.RadioButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.optDailyUpload_Click)
				Dim radioButton As System.Windows.Forms.RadioButton = Me._optDailyUpload
				If (radioButton IsNot Nothing) Then
					RemoveHandler radioButton.Click,  eventHandler
				End If
				Me._optDailyUpload = value
				radioButton = Me._optDailyUpload
				If (radioButton IsNot Nothing) Then
					AddHandler radioButton.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property optDirect As RadioButton
			Get
				stackVariable1 = Me._optDirect
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.RadioButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.optDirect_CheckedChanged)
				Dim radioButton As System.Windows.Forms.RadioButton = Me._optDirect
				If (radioButton IsNot Nothing) Then
					RemoveHandler radioButton.CheckedChanged,  eventHandler
				End If
				Me._optDirect = value
				radioButton = Me._optDirect
				If (radioButton IsNot Nothing) Then
					AddHandler radioButton.CheckedChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property optFileUp As RadioButton
			Get
				stackVariable1 = Me._optFileUp
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.RadioButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.optFileUp_Click)
				Dim radioButton As System.Windows.Forms.RadioButton = Me._optFileUp
				If (radioButton IsNot Nothing) Then
					RemoveHandler radioButton.Click,  eventHandler
				End If
				Me._optFileUp = value
				radioButton = Me._optFileUp
				If (radioButton IsNot Nothing) Then
					AddHandler radioButton.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property optOpenload As RadioButton
			Get
				stackVariable1 = Me._optOpenload
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.RadioButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.optOpenload_Click)
				Dim radioButton As System.Windows.Forms.RadioButton = Me._optOpenload
				If (radioButton IsNot Nothing) Then
					RemoveHandler radioButton.Click,  eventHandler
				End If
				Me._optOpenload = value
				radioButton = Me._optOpenload
				If (radioButton IsNot Nothing) Then
					AddHandler radioButton.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property optSendSpace As RadioButton
			Get
				stackVariable1 = Me._optSendSpace
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.RadioButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.optSendSpace_Click)
				Dim radioButton As System.Windows.Forms.RadioButton = Me._optSendSpace
				If (radioButton IsNot Nothing) Then
					RemoveHandler radioButton.Click,  eventHandler
				End If
				Me._optSendSpace = value
				radioButton = Me._optSendSpace
				If (radioButton IsNot Nothing) Then
					AddHandler radioButton.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property txtDailyUpload As TextBox

		Friend Overridable Property txtDirect As TextBox

		Friend Overridable Property txtFileUp As TextBox

		Friend Overridable Property txtOpenload As TextBox

		Friend Overridable Property txtSendspace As TextBox

		Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim text As String = Nothing
			Dim str As String = Nothing
			Dim num As Integer = 0
			If (Not Me.optDailyUpload.Checked) Then
				text = Me.txtDirect.Text
				str = String.Concat(Path.GetFileNameWithoutExtension(text), ".ipa")
			Else
				num = URLInstall.DailyUpload(Me.txtDailyUpload.Text, text, str)
			End If
			If (num >= 0) Then
				Common.Download(New DownloadProgress(), text, str)
				MyBase.Close()
			Else
				Interaction.MsgBox(String.Concat("Cannot download file! Is your link correct? ", num.ToString()), MsgBoxStyle.OkOnly, Nothing)
			End If
		End Sub

		Public Shared Function DailyUpload(ByVal url As String, ByRef ipaLink As String, ByRef ipaName As String) As Integer
			Dim num As Integer
			Dim str As String
			Dim str1 As String = Nothing
			Dim str2 As String = Nothing
			Dim str3 As String = Nothing
			Dim str4 As String = Nothing
			Dim webConsole As SuperImpactor.WebConsole = New SuperImpactor.WebConsole()
			Dim str5 As String = webConsole.http(url, "")
			Dim num1 As Integer = str5.IndexOf("name=""fname""")
			If (num1 > 0) Then
				str = Conversions.ToString(webConsole.getKeyValue(str5, "value", str1, num1 + 1, True, """"))
				If (Operators.CompareString(str, "", False) = 0) Then
					num1 = str5.IndexOf("name=""id""")
					If (num1 <> -1) Then
						str = Conversions.ToString(webConsole.getKeyValue(str5, "value", str4, num1 + 1, True, """"))
						If (Operators.CompareString(str, "", False) <> 0) Then
							num = -2
							Return num
						End If
						str5 = webConsole.http(url, String.Concat(New String() { "op=download1&usr_login=&id=", str4, "&fname=", HttpUtility.UrlEncode(str1), "&referer=&method_free=Free+Download" }))
					Else
						num = -1
						Return num
					End If
				Else
					num = -2
					Return num
				End If
			End If
			num1 = str5.IndexOf("name=""id""")
			If (num1 <> -1) Then
				str = Conversions.ToString(webConsole.getKeyValue(str5, "value", str2, num1 + 1, True, """"))
				If (Operators.CompareString(str, "", False) = 0) Then
					num1 = str5.IndexOf("name=""rand""")
					If (num1 <> -1) Then
						str = Conversions.ToString(webConsole.getKeyValue(str5, "value", str3, num1 + 1, True, """"))
						If (Operators.CompareString(str, "", False) = 0) Then
							Thread.Sleep(5000)
							str = webConsole.http(url, String.Concat(New String() { "op=download2&id=", str2, "&rand=", str3, "&referer=&method_free=&method_premium=&down_script=1&fs_download_file=" }))
							num1 = str.IndexOf("This direct link will be available for your IP")
							If (num1 <> -1) Then
								str = Conversions.ToString(webConsole.getKeyValue(str, "href", ipaLink, num1 + 1, True, """"))
								If (Operators.CompareString(str, "", False) = 0) Then
									ipaName = Path.GetFileName(ipaLink)
									num = 0
								Else
									num = -7
								End If
							Else
								File.WriteAllText("dl.html", str)
								num = -5
							End If
						Else
							num = -4
						End If
					Else
						num = -3
					End If
				Else
					num = -2
				End If
			Else
				num = -1
			End If
			Return num
		End Function

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
			Me.Label1 = New Label()
			Me.optSendSpace = New RadioButton()
			Me.optDailyUpload = New RadioButton()
			Me.optFileUp = New RadioButton()
			Me.txtSendspace = New TextBox()
			Me.txtDailyUpload = New TextBox()
			Me.txtFileUp = New TextBox()
			Me.cmdNext = New Button()
			Me.cmdClose = New Button()
			Me.txtOpenload = New TextBox()
			Me.optOpenload = New RadioButton()
			Me.txtDirect = New TextBox()
			Me.optDirect = New RadioButton()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(3, 13)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(130, 13)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Enter URL of IPA to install"
			Me.optSendSpace.AutoSize = True
			Me.optSendSpace.Location = New Point(6, 160)
			Me.optSendSpace.Name = "optSendSpace"
			Me.optSendSpace.Size = New System.Drawing.Size(102, 17)
			Me.optSendSpace.TabIndex = 1
			Me.optSendSpace.Text = "Sendspace.com"
			Me.optSendSpace.UseVisualStyleBackColor = True
			Me.optSendSpace.Visible = False
			Me.optDailyUpload.AutoSize = True
			Me.optDailyUpload.Checked = True
			Me.optDailyUpload.Location = New Point(6, 39)
			Me.optDailyUpload.Name = "optDailyUpload"
			Me.optDailyUpload.Size = New System.Drawing.Size(103, 17)
			Me.optDailyUpload.TabIndex = 2
			Me.optDailyUpload.TabStop = True
			Me.optDailyUpload.Text = "Dailyuploads.net"
			Me.optDailyUpload.UseVisualStyleBackColor = True
			Me.optFileUp.AutoSize = True
			Me.optFileUp.Location = New Point(6, 196)
			Me.optFileUp.Name = "optFileUp"
			Me.optFileUp.Size = New System.Drawing.Size(77, 17)
			Me.optFileUp.TabIndex = 3
			Me.optFileUp.Text = "Filepup.net"
			Me.optFileUp.UseVisualStyleBackColor = True
			Me.optFileUp.Visible = False
			Me.txtSendspace.Location = New Point(115, 160)
			Me.txtSendspace.Name = "txtSendspace"
			Me.txtSendspace.Size = New System.Drawing.Size(258, 20)
			Me.txtSendspace.TabIndex = 4
			Me.txtSendspace.Visible = False
			Me.txtDailyUpload.Location = New Point(115, 39)
			Me.txtDailyUpload.Name = "txtDailyUpload"
			Me.txtDailyUpload.Size = New System.Drawing.Size(258, 20)
			Me.txtDailyUpload.TabIndex = 5
			Me.txtFileUp.Location = New Point(115, 195)
			Me.txtFileUp.Name = "txtFileUp"
			Me.txtFileUp.Size = New System.Drawing.Size(258, 20)
			Me.txtFileUp.TabIndex = 6
			Me.txtFileUp.Visible = False
			Me.cmdNext.Location = New Point(207, 110)
			Me.cmdNext.Name = "cmdNext"
			Me.cmdNext.Size = New System.Drawing.Size(75, 23)
			Me.cmdNext.TabIndex = 7
			Me.cmdNext.Text = "Next"
			Me.cmdNext.UseVisualStyleBackColor = True
			Me.cmdClose.Location = New Point(114, 110)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(75, 23)
			Me.cmdClose.TabIndex = 8
			Me.cmdClose.Text = "Cancel"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.txtOpenload.Location = New Point(115, 231)
			Me.txtOpenload.Name = "txtOpenload"
			Me.txtOpenload.Size = New System.Drawing.Size(258, 20)
			Me.txtOpenload.TabIndex = 10
			Me.txtOpenload.Visible = False
			Me.optOpenload.AutoSize = True
			Me.optOpenload.Location = New Point(6, 232)
			Me.optOpenload.Name = "optOpenload"
			Me.optOpenload.Size = New System.Drawing.Size(86, 17)
			Me.optOpenload.TabIndex = 9
			Me.optOpenload.Text = "Openload.co"
			Me.optOpenload.UseVisualStyleBackColor = True
			Me.optOpenload.Visible = False
			Me.txtDirect.Location = New Point(114, 72)
			Me.txtDirect.Name = "txtDirect"
			Me.txtDirect.Size = New System.Drawing.Size(258, 20)
			Me.txtDirect.TabIndex = 12
			Me.optDirect.AutoSize = True
			Me.optDirect.Location = New Point(5, 72)
			Me.optDirect.Name = "optDirect"
			Me.optDirect.Size = New System.Drawing.Size(104, 17)
			Me.optDirect.TabIndex = 11
			Me.optDirect.Text = "Direct Download"
			Me.optDirect.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(385, 145)
			MyBase.Controls.Add(Me.txtDirect)
			MyBase.Controls.Add(Me.optDirect)
			MyBase.Controls.Add(Me.txtOpenload)
			MyBase.Controls.Add(Me.optOpenload)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdNext)
			MyBase.Controls.Add(Me.txtFileUp)
			MyBase.Controls.Add(Me.txtDailyUpload)
			MyBase.Controls.Add(Me.txtSendspace)
			MyBase.Controls.Add(Me.optFileUp)
			MyBase.Controls.Add(Me.optDailyUpload)
			MyBase.Controls.Add(Me.optSendSpace)
			MyBase.Controls.Add(Me.Label1)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "URLInstall"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			Me.Text = "Install from URL"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub optDailyUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtDailyUpload.Enabled = True
			Me.txtFileUp.Enabled = False
			Me.txtOpenload.Enabled = False
			Me.txtSendspace.Enabled = False
			Me.txtDirect.Enabled = False
		End Sub

		Private Sub optDirect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtDailyUpload.Enabled = False
			Me.txtFileUp.Enabled = False
			Me.txtOpenload.Enabled = False
			Me.txtSendspace.Enabled = False
			Me.txtDirect.Enabled = True
		End Sub

		Private Sub optFileUp_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtDailyUpload.Enabled = False
			Me.txtFileUp.Enabled = True
			Me.txtOpenload.Enabled = False
			Me.txtSendspace.Enabled = False
			Me.txtDirect.Enabled = False
		End Sub

		Private Sub optOpenload_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtDailyUpload.Enabled = False
			Me.txtFileUp.Enabled = False
			Me.txtOpenload.Enabled = True
			Me.txtSendspace.Enabled = False
			Me.txtDirect.Enabled = False
		End Sub

		Private Sub optSendSpace_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtDailyUpload.Enabled = False
			Me.txtFileUp.Enabled = False
			Me.txtOpenload.Enabled = False
			Me.txtSendspace.Enabled = True
			Me.txtDirect.Enabled = False
		End Sub
	End Class
End Namespace