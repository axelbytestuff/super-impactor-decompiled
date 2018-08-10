Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class DownloadProgress
		Inherits Form
		Private components As IContainer

		Private downloadLink As String

		Private localFile As String

		Private storeFile As String

		Private bComplete As Boolean

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

		Friend Overridable Property chkStore As CheckBox
			Get
				stackVariable1 = Me._chkStore
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.CheckBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.chkStore_CheckedChanged)
				Dim checkBox As System.Windows.Forms.CheckBox = Me._chkStore
				If (checkBox IsNot Nothing) Then
					RemoveHandler checkBox.CheckedChanged,  eventHandler
				End If
				Me._chkStore = value
				checkBox = Me._chkStore
				If (checkBox IsNot Nothing) Then
					AddHandler checkBox.CheckedChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property Label2 As Label

		Friend Overridable Property Label3 As Label

		Friend Overridable Property Label5 As Label

		Friend Overridable Property lblDownload As Label

		Friend Overridable Property lblFile As Label

		Friend Overridable Property lblFileSize As Label

		Friend Overridable Property lblPercent As Label

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
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.DownloadProgress_Load)
			AddHandler MyBase.Closed,  New EventHandler(AddressOf Me.DownloadProgress_Closed)
			Me.bComplete = False
			Me.InitializeComponent()
		End Sub

		Private Async Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
			Dim num As Integer
			Dim num1 As Integer
			Dim objArray As Object()
			Dim downloadProgress As SuperImpactor.DownloadProgress
			Dim downloadCompleteSafe As SuperImpactor.DownloadProgress.DownloadCompleteSafe
			Dim msgBoxResult As Microsoft.VisualBasic.MsgBoxResult
			Dim obj As Object
			Dim num2 As Integer
			Dim response As HttpWebResponse
			Dim num3 As Long = 0L
			Dim downloadCompleteSafe1 As SuperImpactor.DownloadProgress.DownloadCompleteSafe
			If (Me.downloadLink.IndexOf("dailyuploads.net") >= 0) Then
				num2 = URLInstall.DailyUpload(Me.downloadLink, Me.downloadLink, Me.storeFile)
				If (num2 < 0) Then
					msgBoxResult = Interaction.MsgBox(String.Concat("Cannot download file! Is your link correct? ", num2.ToString()), MsgBoxStyle.OkOnly, Nothing)
					downloadCompleteSafe1 = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
					Try
						downloadProgress = Me
						downloadCompleteSafe = downloadCompleteSafe1
						objArray = New Object() { True }
						obj = downloadProgress.Invoke(downloadCompleteSafe, objArray)
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
					num1 = -2
					num = num1
					Return
				End If
			End If
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(Me.downloadLink), System.Net.HttpWebRequest)
				response = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			Catch exception2 As System.Exception
				ProjectData.SetProjectError(exception2)
				MessageBox.Show("An error occurred while downloading file. Possibe causes:" & VbCrLf & "1) File doesn't exist" & VbCrLf & "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Dim downloadCompleteSafe2 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
				Try
					Dim downloadProgress1 As SuperImpactor.DownloadProgress = Me
					Dim downloadCompleteSafe3 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = downloadCompleteSafe2
					Dim objArray1() As Object = { True }
					downloadProgress1.Invoke(downloadCompleteSafe3, objArray1)
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					ProjectData.ClearProjectError()
				End Try
				ProjectData.ClearProjectError()
				num1 = -2
				num = num1
				Return
			End Try
			Dim contentLength As Long = response.ContentLength
			Dim changeTextsSafe As SuperImpactor.DownloadProgress.ChangeTextsSafe = New SuperImpactor.DownloadProgress.ChangeTextsSafe(AddressOf Me.ChangeTexts)
			Try
				Dim downloadProgress2 As SuperImpactor.DownloadProgress = Me
				Dim changeTextsSafe1 As SuperImpactor.DownloadProgress.ChangeTextsSafe = changeTextsSafe
				Dim objArray2() As Object = { contentLength, 0, 0, 0 }
				downloadProgress2.Invoke(changeTextsSafe1, objArray2)
			Catch exception3 As System.Exception
				ProjectData.SetProjectError(exception3)
				ProjectData.ClearProjectError()
			End Try
			Dim fileStream As System.IO.FileStream = New System.IO.FileStream(Me.localFile, FileMode.Create)
			Dim stopwatch As System.Diagnostics.Stopwatch = New System.Diagnostics.Stopwatch()
			Dim elapsedMilliseconds As Double = -1
			Dim num4 As Integer = 0
			While True
				If (Not Me.BackgroundWorker1.CancellationPending) Then
					stopwatch.Start()
					Dim numArray(4095) As Byte
					Dim num5 As Integer = response.GetResponseStream().Read(numArray, 0, 4096)
					num3 = num3 + CLng(num5)
					Dim num6 As Long = CLng(Math.Round(Math.Round(CDbl((num3 * CLng(100))) / CDbl(contentLength))))
					Try
						Dim downloadProgress3 As SuperImpactor.DownloadProgress = Me
						Dim changeTextsSafe2 As SuperImpactor.DownloadProgress.ChangeTextsSafe = changeTextsSafe
						Dim objArray3() As Object = { contentLength, num3, num6, elapsedMilliseconds }
						downloadProgress3.Invoke(changeTextsSafe2, objArray3)
					Catch exception5 As System.Exception
						ProjectData.SetProjectError(exception5)
						response.GetResponseStream().Close()
						fileStream.Close()
						Try
							File.Delete(Me.localFile)
							Dim downloadCompleteSafe4 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
							Dim downloadProgress4 As SuperImpactor.DownloadProgress = Me
							Dim downloadCompleteSafe5 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = downloadCompleteSafe4
							Dim objArray4() As Object = { True }
							downloadProgress4.Invoke(downloadCompleteSafe5, objArray4)
						Catch exception4 As System.Exception
							ProjectData.SetProjectError(exception4)
							ProjectData.ClearProjectError()
						End Try
						ProjectData.ClearProjectError()
						num1 = -2
						num = num1
						Return
					End Try
					If (num5 <> 0) Then
						fileStream.Write(numArray, 0, num5)
						stopwatch.[Stop]()
						num4 = num4 + 1
						If (num4 >= 100) Then
							elapsedMilliseconds = 409600 / (CDbl(stopwatch.ElapsedMilliseconds) / 1000)
							stopwatch.Reset()
							num4 = 0
						End If
					Else
						Exit While
					End If
				Else
					Exit While
				End If
			End While
			response.GetResponseStream().Close()
			fileStream.Close()
			If (Not Me.BackgroundWorker1.CancellationPending) Then
				If (Me.storeFile.EndsWith(".deb")) Then
					Try
						Directory.CreateDirectory(AppConst.m_localTmp)
					Catch exception6 As System.Exception
						ProjectData.SetProjectError(exception6)
						ProjectData.ClearProjectError()
					End Try
					Try
						File.Delete(String.Concat(AppConst.m_localTmp, "/data.tar"))
					Catch exception7 As System.Exception
						ProjectData.SetProjectError(exception7)
						ProjectData.ClearProjectError()
					End Try
					Try
						Common.DeleteFilesFromFolder(String.Concat(AppConst.m_localTmp, "/data"))
					Catch exception8 As System.Exception
						ProjectData.SetProjectError(exception8)
						ProjectData.ClearProjectError()
					End Try
					Dim changeStatusSafe As SuperImpactor.DownloadProgress.ChangeStatusSafe = New SuperImpactor.DownloadProgress.ChangeStatusSafe(AddressOf Me.ChangeStatus)
					Try
						Dim downloadProgress5 As SuperImpactor.DownloadProgress = Me
						Dim changeStatusSafe1 As SuperImpactor.DownloadProgress.ChangeStatusSafe = changeStatusSafe
						Dim objArray5() As Object = { "Please wait for processing download file..." }
						downloadProgress5.Invoke(changeStatusSafe1, objArray5)
					Catch exception9 As System.Exception
						ProjectData.SetProjectError(exception9)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					Dim str As String = String.Concat(AppConst.m_rootPath, "\7zip\7z.exe")
					Dim mLocalTmp() As String = { "e """, Me.localFile, """ -o""", AppConst.m_localTmp, """" }
					Dim str1 As String = Await Common.RunExe(str, String.Concat(mLocalTmp), True)
					Dim str2 As String = str1
					Dim str3 As String = String.Concat(AppConst.m_rootPath, "\7zip\7z.exe")
					Dim strArrays() As String = { "x """, AppConst.m_localTmp, "\data.tar"" -o""", AppConst.m_localTmp, "\data\"" -r -aoa" }
					str1 = Await Common.RunExe(str3, String.Concat(strArrays), True)
					str2 = str1
					Directory.Move(String.Concat(AppConst.m_localTmp, "\data\Applications"), String.Concat(AppConst.m_localTmp, "\data\Payload"))
					Dim str4 As String = String.Concat(AppConst.m_rootPath, "\7zip\7z.exe")
					Dim mLocalTmp1() As String = { "a -tzip """, Me.localFile, ".zip"" """, AppConst.m_localTmp, "\data\*""" }
					str1 = Await Common.RunExe(str4, String.Concat(mLocalTmp1), False)
					str2 = str1
					Me.storeFile = String.Concat(Me.storeFile, ".ipa")
					Try
						File.Delete(Me.localFile)
					Catch exception10 As System.Exception
						ProjectData.SetProjectError(exception10)
						ProjectData.ClearProjectError()
					End Try
					Try
						File.Move(String.Concat(Me.localFile, ".zip"), Me.localFile)
					Catch exception11 As System.Exception
						ProjectData.SetProjectError(exception11)
						Interaction.MsgBox(exception11.Message, MsgBoxStyle.OkOnly, Nothing)
						ProjectData.ClearProjectError()
					End Try
				End If
				Dim downloadCompleteSafe6 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
				Try
					Dim downloadProgress6 As SuperImpactor.DownloadProgress = Me
					Dim downloadCompleteSafe7 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = downloadCompleteSafe6
					Dim objArray6() As Object = { False }
					downloadProgress6.Invoke(downloadCompleteSafe7, objArray6)
				Catch exception12 As System.Exception
					ProjectData.SetProjectError(exception12)
					ProjectData.ClearProjectError()
				End Try
			Else
				File.Delete(Me.localFile)
				Dim downloadCompleteSafe8 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
				Try
					Dim downloadProgress7 As SuperImpactor.DownloadProgress = Me
					Dim downloadCompleteSafe9 As SuperImpactor.DownloadProgress.DownloadCompleteSafe = downloadCompleteSafe8
					Dim objArray7() As Object = { True }
					downloadProgress7.Invoke(downloadCompleteSafe9, objArray7)
				Catch exception13 As System.Exception
					ProjectData.SetProjectError(exception13)
					ProjectData.ClearProjectError()
				End Try
			End If
			num1 = -2
			num = num1
			Return
			msgBoxResult = Interaction.MsgBox(String.Concat("Cannot download file! Is your link correct? ", num2.ToString()), MsgBoxStyle.OkOnly, Nothing)
			downloadCompleteSafe1 = New SuperImpactor.DownloadProgress.DownloadCompleteSafe(AddressOf Me.DownloadComplete)
			Try
				downloadProgress = Me
				downloadCompleteSafe = downloadCompleteSafe1
				objArray = New Object() { True }
				obj = downloadProgress.Invoke(downloadCompleteSafe, objArray)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			num1 = -2
			num = num1
		End Sub

		Private Sub ChangeStatus(ByVal text As String)
			Me.lblFile.Text = text
			Me.Text = text
		End Sub

		Private Sub ChangeTexts(ByVal length As Long, ByVal position As Long, ByVal percent As Long, ByVal speed As Double)
			If (length = CLng(-1)) Then
				Me.lblFileSize.Text = "calculating..."
			ElseIf (CDbl(length) / 1024 / 1024 <= 1) Then
				Me.lblFileSize.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(length) / 1024, 2)), " KB")
			Else
				Me.lblFileSize.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(length) / 1024 / 1024, 2)), " MB")
			End If
			If (CDbl(position) / 1024 / 1024 <= 1) Then
				Me.lblDownload.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(position) / 1024, 2)), " KB")
			Else
				Me.lblDownload.Text = String.Concat(Conversions.ToString(Math.Round(CDbl(position) / 1024 / 1024, 2)), " MB")
			End If
			If (speed = -1) Then
				Me.lblSpeed.Text = "calculating..."
			ElseIf (speed / 1024 / 1024 <= 1) Then
				Me.lblSpeed.Text = String.Concat(Conversions.ToString(Math.Round(speed / 1024, 2)), " KB/s")
			Else
				Me.lblSpeed.Text = String.Concat(Conversions.ToString(Math.Round(speed / 1024 / 1024, 2)), " MB/s")
			End If
			Me.ProgressBar1.Value = CInt(percent)
			Me.lblPercent.BringToFront()
			Me.lblPercent.Text = String.Concat(Conversions.ToString(percent), "%")
			Me.Text = String.Concat(Conversions.ToString(percent), "%  ", Me.storeFile)
			Me.lblPercent.BackColor = Color.Transparent
			Me.lblFile.Text = Me.storeFile
		End Sub

		Private Sub chkStore_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.BackgroundWorker1.CancelAsync()
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

		Public Function Download(ByVal url As String, ByVal tmpFile As String, ByVal storedFile As String) As Boolean
			Me.downloadLink = url
			Me.localFile = tmpFile
			Me.storeFile = storedFile
			Me.ChangeTexts(CLng(-1), CLng(0), CLng(0), -1)
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.BackgroundWorker1.RunWorkerAsync()
			Me.Text = String.Concat("Download:    ", storedFile)
			MyBase.ShowDialog()
			Return Me.bComplete
		End Function

		Public Sub DownloadAsync(ByVal url As String, ByVal tmpFile As String, ByVal storedFile As String)
			Me.downloadLink = url
			Me.localFile = tmpFile
			Me.storeFile = storedFile
			Me.ChangeTexts(CLng(-1), CLng(0), CLng(0), -1)
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			Me.BackgroundWorker1.RunWorkerAsync()
			MyBase.Show()
			Me.Text = String.Concat("Download: ", storedFile)
		End Sub

		Private Sub DownloadComplete(ByVal cancelled As Boolean)
			If (Not cancelled) Then
				If (Me.chkStore.Checked) Then
					Try
						File.Delete(String.Concat(AppConst.m_rootPath, "\download\", Me.storeFile))
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
					Try
						File.Move(Me.localFile, String.Concat(AppConst.m_rootPath, "\download\", Me.storeFile))
						AppConst.mainForm.onDownloadComplete()
					Catch exception1 As System.Exception
						ProjectData.SetProjectError(exception1)
						ProjectData.ClearProjectError()
					End Try
				End If
				Me.bComplete = True
				MyBase.Close()
			Else
				MyBase.Close()
			End If
		End Sub

		Private Sub DownloadProgress_Closed(ByVal sender As Object, ByVal e As EventArgs)
			Me.BackgroundWorker1.CancelAsync()
		End Sub

		Private Sub DownloadProgress_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.Label1 = New Label()
			Me.Label2 = New Label()
			Me.ProgressBar1 = New ProgressBar()
			Me.lblFileSize = New Label()
			Me.lblSpeed = New Label()
			Me.BackgroundWorker1 = New BackgroundWorker()
			Me.Label3 = New Label()
			Me.lblFile = New Label()
			Me.chkStore = New CheckBox()
			Me.lblPercent = New Label()
			Me.lblDownload = New Label()
			Me.Label5 = New Label()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(15, 38)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(47, 13)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "File size:"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Point(143, 38)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(41, 13)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Speed:"
			Me.ProgressBar1.Location = New Point(45, 62)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New System.Drawing.Size(482, 23)
			Me.ProgressBar1.TabIndex = 4
			Me.lblFileSize.AutoSize = True
			Me.lblFileSize.Location = New Point(66, 38)
			Me.lblFileSize.Name = "lblFileSize"
			Me.lblFileSize.Size = New System.Drawing.Size(0, 13)
			Me.lblFileSize.TabIndex = 5
			Me.lblSpeed.AutoSize = True
			Me.lblSpeed.Location = New Point(190, 38)
			Me.lblSpeed.Name = "lblSpeed"
			Me.lblSpeed.Size = New System.Drawing.Size(0, 13)
			Me.lblSpeed.TabIndex = 6
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Point(15, 12)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(26, 13)
			Me.Label3.TabIndex = 7
			Me.Label3.Text = "File:"
			Me.lblFile.AutoSize = True
			Me.lblFile.Location = New Point(42, 12)
			Me.lblFile.Name = "lblFile"
			Me.lblFile.Size = New System.Drawing.Size(0, 13)
			Me.lblFile.TabIndex = 8
			Me.chkStore.AutoSize = True
			Me.chkStore.Checked = True
			Me.chkStore.CheckState = CheckState.Checked
			Me.chkStore.Location = New Point(441, 35)
			Me.chkStore.Name = "chkStore"
			Me.chkStore.Size = New System.Drawing.Size(92, 17)
			Me.chkStore.TabIndex = 9
			Me.chkStore.Text = "Store file local"
			Me.chkStore.UseVisualStyleBackColor = True
			Me.lblPercent.AutoSize = True
			Me.lblPercent.BackColor = Color.Transparent
			Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 163)
			Me.lblPercent.ForeColor = Color.Fuchsia
			Me.lblPercent.Location = New Point(14, 65)
			Me.lblPercent.Name = "lblPercent"
			Me.lblPercent.Size = New System.Drawing.Size(0, 13)
			Me.lblPercent.TabIndex = 10
			Me.lblDownload.AutoSize = True
			Me.lblDownload.Location = New Point(362, 38)
			Me.lblDownload.Name = "lblDownload"
			Me.lblDownload.Size = New System.Drawing.Size(0, 13)
			Me.lblDownload.TabIndex = 12
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Point(279, 38)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(79, 13)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Download size:"
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(542, 97)
			MyBase.Controls.Add(Me.lblDownload)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.lblPercent)
			MyBase.Controls.Add(Me.chkStore)
			MyBase.Controls.Add(Me.lblFile)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.lblSpeed)
			MyBase.Controls.Add(Me.lblFileSize)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.Name = "DownloadProgress"
			Me.Text = "Download IPA"
			MyBase.TransparencyKey = Color.Lime
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub ProgressBar1_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Public Delegate Sub ChangeStatusSafe(ByVal text As String)

		Public Delegate Sub ChangeTextsSafe(ByVal length As Long, ByVal position As Long, ByVal percent As Long, ByVal speed As Double)

		Public Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)
	End Class
End Namespace