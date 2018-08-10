Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class AppDetail
		Inherits Form
		Private components As IContainer

		Public appDetailInfo As AppInfos

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

		Friend Overridable Property cmdInstall As Button
			Get
				stackVariable1 = Me._cmdInstall
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdInstall_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdInstall
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdInstall = value
				button = Me._cmdInstall
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property imgApp As PictureBox

		Friend Overridable Property Label1 As Label

		Friend Overridable Property Label4 As Label

		Friend Overridable Property Label6 As Label

		Friend Overridable Property Label8 As Label

		Friend Overridable Property Label9 As Label

		Friend Overridable Property lblAppName As Label

		Friend Overridable Property lblAuthor As Label

		Friend Overridable Property lblCategory As Label

		Friend Overridable Property lblSize As Label

		Friend Overridable Property lblSupport As Label

		Friend Overridable Property lblVersion As Label

		Friend Overridable Property pic1 As PictureBox

		Friend Overridable Property pic2 As PictureBox

		Friend Overridable Property pic3 As PictureBox

		Friend Overridable Property pic4 As PictureBox

		Friend Overridable Property txtDesc As TextBox

		Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdInstall_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim filename As String
			Dim str As String
			If (Me.appDetailInfo.Filename.IndexOf("dailyuploads.net") < 0) Then
				filename = Me.appDetailInfo.Filename
				str = String.Concat(Me.appDetailInfo.Name, ".ipa")
			Else
				filename = Me.appDetailInfo.Filename
				str = "checking...ipa"
			End If
			MyBase.Close()
			Common.Download(New DownloadProgress(), filename, str)
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
			Me.imgApp = New PictureBox()
			Me.lblAppName = New Label()
			Me.cmdInstall = New Button()
			Me.lblVersion = New Label()
			Me.lblSize = New Label()
			Me.Label4 = New Label()
			Me.lblCategory = New Label()
			Me.Label6 = New Label()
			Me.lblSupport = New Label()
			Me.Label8 = New Label()
			Me.txtDesc = New TextBox()
			Me.Label9 = New Label()
			Me.lblAuthor = New Label()
			Me.cmdClose = New Button()
			Me.Label1 = New Label()
			Me.pic1 = New PictureBox()
			Me.pic2 = New PictureBox()
			Me.pic3 = New PictureBox()
			Me.pic4 = New PictureBox()
			DirectCast(Me.imgApp, ISupportInitialize).BeginInit()
			DirectCast(Me.pic1, ISupportInitialize).BeginInit()
			DirectCast(Me.pic2, ISupportInitialize).BeginInit()
			DirectCast(Me.pic3, ISupportInitialize).BeginInit()
			DirectCast(Me.pic4, ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.imgApp.Location = New Point(13, 13)
			Me.imgApp.Name = "imgApp"
			Me.imgApp.Size = New System.Drawing.Size(63, 58)
			Me.imgApp.SizeMode = PictureBoxSizeMode.Zoom
			Me.imgApp.TabIndex = 0
			Me.imgApp.TabStop = False
			Me.lblAppName.AutoSize = True
			Me.lblAppName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.lblAppName.Location = New Point(84, 19)
			Me.lblAppName.Name = "lblAppName"
			Me.lblAppName.Size = New System.Drawing.Size(91, 18)
			Me.lblAppName.TabIndex = 1
			Me.lblAppName.Text = "APP HERE"
			Me.cmdInstall.Location = New Point(423, 19)
			Me.cmdInstall.Name = "cmdInstall"
			Me.cmdInstall.Size = New System.Drawing.Size(75, 23)
			Me.cmdInstall.TabIndex = 2
			Me.cmdInstall.Text = "Download"
			Me.cmdInstall.UseVisualStyleBackColor = True
			Me.lblVersion.AutoSize = True
			Me.lblVersion.Location = New Point(83, 52)
			Me.lblVersion.Name = "lblVersion"
			Me.lblVersion.Size = New System.Drawing.Size(22, 13)
			Me.lblVersion.TabIndex = 3
			Me.lblVersion.Text = "0.0"
			Me.lblSize.AutoSize = True
			Me.lblSize.Location = New Point(181, 52)
			Me.lblSize.Name = "lblSize"
			Me.lblSize.Size = New System.Drawing.Size(29, 13)
			Me.lblSize.TabIndex = 4
			Me.lblSize.Text = "0 kB"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Point(12, 98)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(49, 13)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Category"
			Me.lblCategory.AutoSize = True
			Me.lblCategory.Location = New Point(84, 98)
			Me.lblCategory.Name = "lblCategory"
			Me.lblCategory.Size = New System.Drawing.Size(39, 13)
			Me.lblCategory.TabIndex = 6
			Me.lblCategory.Text = "Label5"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Point(12, 124)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(68, 13)
			Me.Label6.TabIndex = 7
			Me.Label6.Text = "Minimum iOS"
			Me.lblSupport.AutoSize = True
			Me.lblSupport.Location = New Point(84, 124)
			Me.lblSupport.Name = "lblSupport"
			Me.lblSupport.Size = New System.Drawing.Size(39, 13)
			Me.lblSupport.TabIndex = 8
			Me.lblSupport.Text = "Label7"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Point(12, 176)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(60, 13)
			Me.Label8.TabIndex = 9
			Me.Label8.Text = "Description"
			Me.txtDesc.Location = New Point(84, 176)
			Me.txtDesc.Multiline = True
			Me.txtDesc.Name = "txtDesc"
			Me.txtDesc.[ReadOnly] = True
			Me.txtDesc.ScrollBars = ScrollBars.Vertical
			Me.txtDesc.Size = New System.Drawing.Size(418, 215)
			Me.txtDesc.TabIndex = 10
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Point(12, 150)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(38, 13)
			Me.Label9.TabIndex = 11
			Me.Label9.Text = "Author"
			Me.lblAuthor.AutoSize = True
			Me.lblAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.lblAuthor.Location = New Point(84, 150)
			Me.lblAuthor.Name = "lblAuthor"
			Me.lblAuthor.Size = New System.Drawing.Size(52, 13)
			Me.lblAuthor.TabIndex = 12
			Me.lblAuthor.Text = "Label10"
			Me.cmdClose.Location = New Point(423, 50)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(75, 23)
			Me.cmdClose.TabIndex = 13
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(16, 415)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(68, 13)
			Me.Label1.TabIndex = 14
			Me.Label1.Text = "ScreenShots"
			Me.pic1.Location = New Point(84, 415)
			Me.pic1.Name = "pic1"
			Me.pic1.Size = New System.Drawing.Size(100, 174)
			Me.pic1.SizeMode = PictureBoxSizeMode.Zoom
			Me.pic1.TabIndex = 15
			Me.pic1.TabStop = False
			Me.pic2.Location = New Point(190, 415)
			Me.pic2.Name = "pic2"
			Me.pic2.Size = New System.Drawing.Size(100, 174)
			Me.pic2.SizeMode = PictureBoxSizeMode.Zoom
			Me.pic2.TabIndex = 16
			Me.pic2.TabStop = False
			Me.pic3.Location = New Point(296, 415)
			Me.pic3.Name = "pic3"
			Me.pic3.Size = New System.Drawing.Size(100, 174)
			Me.pic3.SizeMode = PictureBoxSizeMode.Zoom
			Me.pic3.TabIndex = 17
			Me.pic3.TabStop = False
			Me.pic4.Location = New Point(402, 415)
			Me.pic4.Name = "pic4"
			Me.pic4.Size = New System.Drawing.Size(100, 174)
			Me.pic4.SizeMode = PictureBoxSizeMode.Zoom
			Me.pic4.TabIndex = 18
			Me.pic4.TabStop = False
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(503, 589)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.pic4)
			MyBase.Controls.Add(Me.pic3)
			MyBase.Controls.Add(Me.pic2)
			MyBase.Controls.Add(Me.pic1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.lblAuthor)
			MyBase.Controls.Add(Me.Label9)
			MyBase.Controls.Add(Me.txtDesc)
			MyBase.Controls.Add(Me.Label8)
			MyBase.Controls.Add(Me.lblSupport)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.lblCategory)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.lblSize)
			MyBase.Controls.Add(Me.lblVersion)
			MyBase.Controls.Add(Me.cmdInstall)
			MyBase.Controls.Add(Me.lblAppName)
			MyBase.Controls.Add(Me.imgApp)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "AppDetail"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			Me.Text = "App Detail"
			DirectCast(Me.imgApp, ISupportInitialize).EndInit()
			DirectCast(Me.pic1, ISupportInitialize).EndInit()
			DirectCast(Me.pic2, ISupportInitialize).EndInit()
			DirectCast(Me.pic3, ISupportInitialize).EndInit()
			DirectCast(Me.pic4, ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Public Sub showApp(ByVal appinfo As AppInfos)
			Dim ituneResult As SuperImpactor.ItuneResult
			Me.appDetailInfo = appinfo
			Dim webClient As System.Net.WebClient = New System.Net.WebClient()
			Me.lblAppName.Text = Me.appDetailInfo.Name
			Me.lblAuthor.Text = Me.appDetailInfo.Author
			Me.lblCategory.Text = Me.appDetailInfo.Section
			Me.lblVersion.Text = Me.appDetailInfo.Version
			Try
				Dim str As String = webClient.DownloadString(String.Concat("https://itunes.apple.com/lookup?id=", Me.appDetailInfo.Package))
				ituneResult = JsonConvert.DeserializeObject(Of SuperImpactor.ItuneResult)(str)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox("Cannot get app information", MsgBoxStyle.OkOnly, Nothing)
				ProjectData.ClearProjectError()
				Return
			End Try
			Dim webClient1 As System.Net.WebClient = New System.Net.WebClient()
			If (ituneResult.resultCount <= 0) Then
				Me.appDetailInfo.Size = ""
				Me.appDetailInfo.Description = ""
			Else
				Me.appDetailInfo.Size = ituneResult.results.ElementAt(0).fileSizeBytes
				Me.appDetailInfo.Description = ituneResult.results.ElementAt(0).description.Replace("" & VbCrLf & "", "" & VbCrLf & "")
				Me.appDetailInfo.Architecture = ituneResult.results.ElementAt(0).minimumOsVersion
				Dim num As Long = Conversions.ToLong(Me.appDetailInfo.Size)
				If (CDbl(num) / 1024 / 1024 / 1024 > 1) Then
					Me.lblSize.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(num) / 1024 / 1024 / 1024, 2)), " GB")
				ElseIf (CDbl(num) / 1024 / 1024 <= 1) Then
					Me.lblSize.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(num) / 1024, 2)), " KB")
				Else
					Me.lblSize.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(num) / 1024 / 1024, 2)), " MB")
				End If
				Me.pic1.Image = Image.FromStream(New MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt(0).screenshotUrls.ElementAt(0))))
				Me.pic2.Image = Image.FromStream(New MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt(0).screenshotUrls.ElementAt(1))))
				Me.pic3.Image = Image.FromStream(New MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt(0).screenshotUrls.ElementAt(2))))
				Me.pic4.Image = Image.FromStream(New MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt(0).screenshotUrls.ElementAt(3))))
			End If
			If (Not (Operators.CompareString(appinfo.Icon, "", False) <> 0 And appinfo.Icon.StartsWith("http"))) Then
				Me.imgApp.Image = New Bitmap(String.Concat(AppConst.m_rootPath, "\res\/apptype_tweak.png"))
			Else
				Me.imgApp.Image = Image.FromStream(New MemoryStream(webClient1.DownloadData(appinfo.Icon)))
			End If
			Me.lblSupport.Text = Me.appDetailInfo.Architecture
			Me.txtDesc.Text = Me.appDetailInfo.Description
			MyBase.ShowDialog()
		End Sub
	End Class
End Namespace