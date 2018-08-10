Imports Claunia.PropertyList
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class AutoResign
		Inherits Form
		Private components As IContainer

		Private lstAppInfo As List(Of AppInfosResign)

		Private udid As String

		Private deviceName As String

		Private machineName As String

		Private machineId As String

		Private isRunning As Boolean

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

		Friend Overridable Property lblAppName As Label

		Friend Overridable Property lblFile As Label

		Friend Overridable Property lblNo As Label

		Friend Overridable Property lstStatus As ListBox
			Get
				stackVariable1 = Me._lstStatus
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ListBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lstStatus_SelectedIndexChanged)
				Dim listBox As System.Windows.Forms.ListBox = Me._lstStatus
				If (listBox IsNot Nothing) Then
					RemoveHandler listBox.SelectedIndexChanged,  eventHandler
				End If
				Me._lstStatus = value
				listBox = Me._lstStatus
				If (listBox IsNot Nothing) Then
					AddHandler listBox.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picLoading As PictureBox
			Get
				stackVariable1 = Me._picLoading
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picLoading_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picLoading
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picLoading = value
				pictureBox = Me._picLoading
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.AutoResign_Load)
			AddHandler MyBase.Closing,  New CancelEventHandler(AddressOf Me.AutoResign_Closing)
			Me.isRunning = False
			Me.InitializeComponent()
		End Sub

		Private Sub AddLog(ByVal log As String)
			Me.lstStatus.Items.Add(log)
			AppConst.logger.Debug(String.Concat("Resign all: ", log))
		End Sub

		Private Sub AutoResign_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
			If (Me.isRunning) Then
				Me.cmdCancel_Click(RuntimeHelpers.GetObjectValue(sender), e)
				e.Cancel = True
			End If
		End Sub

		Private Sub AutoResign_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Async Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
			Dim variable As AutoResign.VB$StateMachine_50_BackgroundWorker1_DoWork = Nothing
			AsyncVoidMethodBuilder.Create().Start(Of AutoResign.VB$StateMachine_50_BackgroundWorker1_DoWork)(variable)
		End Sub

		Private Sub ChangeTexts(ByVal no As String, ByVal appInf As AppInfosResign)
			Me.lblNo.Text = String.Concat("Processing No.: ", no)
			Me.lblAppName.Text = String.Concat("App name: ", appInf.Name)
			Me.lblFile.Text = String.Concat("IPA file: ", appInf.Filename)
		End Sub

		Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.isRunning) Then
				MyBase.Close()
			Else
				Me.BackgroundWorker1.CancelAsync()
				Me.cmdCancel.Text = "Waiting..."
				Me.cmdCancel.Enabled = False
			End If
		End Sub

		Private Sub Complete(ByVal cancelled As Boolean)
			Me.isRunning = False
			If (Not cancelled) Then
				Me.lstStatus.Items.Add("Complete")
				Me.picLoading.Visible = False
				Me.cmdCancel.Visible = False
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
			Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoResign))
			Me.lstStatus = New ListBox()
			Me.cmdCancel = New Button()
			Me.Label1 = New Label()
			Me.lblNo = New Label()
			Me.lblAppName = New Label()
			Me.lblFile = New Label()
			Me.picLoading = New PictureBox()
			Me.BackgroundWorker1 = New BackgroundWorker()
			DirectCast(Me.picLoading, ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.lstStatus.FormattingEnabled = True
			Me.lstStatus.Location = New Point(4, 102)
			Me.lstStatus.Name = "lstStatus"
			Me.lstStatus.Size = New System.Drawing.Size(495, 173)
			Me.lstStatus.TabIndex = 0
			Me.cmdCancel.Location = New Point(417, 27)
			Me.cmdCancel.Name = "cmdCancel"
			Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
			Me.cmdCancel.TabIndex = 1
			Me.cmdCancel.Text = "Cancel"
			Me.cmdCancel.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(4, 83)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(37, 13)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Status"
			Me.lblNo.AutoSize = True
			Me.lblNo.Location = New Point(86, 9)
			Me.lblNo.Name = "lblNo"
			Me.lblNo.Size = New System.Drawing.Size(79, 13)
			Me.lblNo.TabIndex = 3
			Me.lblNo.Text = "Processing No."
			Me.lblAppName.AutoSize = True
			Me.lblAppName.Location = New Point(86, 34)
			Me.lblAppName.Name = "lblAppName"
			Me.lblAppName.Size = New System.Drawing.Size(0, 13)
			Me.lblAppName.TabIndex = 5
			Me.lblFile.AutoSize = True
			Me.lblFile.Location = New Point(86, 59)
			Me.lblFile.Name = "lblFile"
			Me.lblFile.Size = New System.Drawing.Size(0, 13)
			Me.lblFile.TabIndex = 6
			Me.picLoading.Image = DirectCast(componentResourceManager.GetObject("picLoading.Image"), Image)
			Me.picLoading.Location = New Point(14, 12)
			Me.picLoading.Name = "picLoading"
			Me.picLoading.Size = New System.Drawing.Size(59, 56)
			Me.picLoading.TabIndex = 10
			Me.picLoading.TabStop = False
			Me.picLoading.Visible = False
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(504, 279)
			MyBase.Controls.Add(Me.picLoading)
			MyBase.Controls.Add(Me.lblFile)
			MyBase.Controls.Add(Me.lblAppName)
			MyBase.Controls.Add(Me.lblNo)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.cmdCancel)
			MyBase.Controls.Add(Me.lstStatus)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.Name = "AutoResign"
			Me.Text = "AutoResign"
			DirectCast(Me.picLoading, ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub lstStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub picLoading_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Public Async Function Resign(ByVal appInfo As AppInfos, ByVal appleId As String, ByVal password As String, ByVal udid As String, ByVal deviceName As String, ByVal machineName As String, ByVal machineId As String, Optional ByVal cloneId As String = "") As Task
			Dim num As Integer
			Dim str As String
			Dim num1 As Integer
			Dim objArray As Object()
			Dim autoResign As SuperImpactor.AutoResign
			Dim addLogSafe As SuperImpactor.AutoResign.AddLogSafe
			Dim objArray1 As Object()
			Dim autoResign1 As SuperImpactor.AutoResign
			Dim addLogSafe1 As SuperImpactor.AutoResign.AddLogSafe
			Dim obj As Object
			Dim obj1 As Object
			Dim str1 As String = Nothing
			Dim str2 As String
			Dim str3 As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Operators.AddObject(String.Concat("si.", Common.GetHash(Microsoft.VisualBasic.Strings.Trim(appleId)), "."), Interaction.IIf(cloneId.Equals(""), "", String.Concat("clone", cloneId, "."))), Regex.Replace(appInfo.Package, "[^a-zA-Z.]", ""))))
			Dim str4 As String = Regex.Replace(String.Concat("SI - ", appInfo.Name), "[^a-zA-Z ]", "")
			Dim str5 As String = String.Concat(AppConst.m_rootPath, "\download\", appInfo.Filename)
			Dim log As ILog = AppConst.logger
			Dim strArrays() As String = { "Install::create: ", deviceName, ",", machineName, ",", machineId, ",", str5, "    id=", str3, ",", str4 }
			log.Info(String.Concat(strArrays))
			Dim addLogSafe2 As SuperImpactor.AutoResign.AddLogSafe = New SuperImpactor.AutoResign.AddLogSafe(AddressOf Me.AddLog)
			Dim num2 As Integer = 9
			Try
				Dim autoResign2 As SuperImpactor.AutoResign = Me
				Dim addLogSafe3 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
				Dim objArray2() As Object = { String.Concat("	[1/", Conversions.ToString(num2), "] Login... ", appleId) }
				autoResign2.Invoke(addLogSafe3, objArray2)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Application.DoEvents()
			Dim nSDictionary As Claunia.PropertyList.NSDictionary = AppleService.login(appleId, password)
			If (nSDictionary.ContainsKey("myacinfo")) Then
				Dim str6 As String = nSDictionary.ObjectForKey("myacinfo").ToString()
				Try
					Dim autoResign3 As SuperImpactor.AutoResign = Me
					Dim addLogSafe4 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
					Dim objArray3() As Object = { String.Concat("	[2/", Conversions.ToString(num2), "] Get team...") }
					autoResign3.Invoke(addLogSafe4, objArray3)
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					ProjectData.ClearProjectError()
				End Try
				Application.DoEvents()
				nSDictionary = AppleService.listTeam(str6)
				Dim str7 As String = ""
				If (nSDictionary.ContainsKey("teams")) Then
					Dim nSArray As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("teams"), Claunia.PropertyList.NSArray)
					If (nSArray.get_Count() > 0) Then
						Dim nSDictionary1 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray.ElementAt(0), Claunia.PropertyList.NSDictionary)
						If (nSDictionary1.ContainsKey("teamId")) Then
							str7 = nSDictionary1.ObjectForKey("teamId").ToString()
						End If
					End If
				End If
				If (Operators.CompareString(str7, "", False) <> 0) Then
					Try
						Dim autoResign4 As SuperImpactor.AutoResign = Me
						Dim addLogSafe5 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray4() As Object = { String.Concat("	[3/", Conversions.ToString(num2), "] Get devices...") }
						autoResign4.Invoke(addLogSafe5, objArray4)
					Catch exception2 As System.Exception
						ProjectData.SetProjectError(exception2)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					nSDictionary = AppleService.listDevices(str7)
					Dim flag As Boolean = False
					If (nSDictionary.ContainsKey("devices")) Then
						Dim nSArray1 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("devices"), Claunia.PropertyList.NSArray)
						If (nSArray1.get_Count() > 0) Then
							Dim count As Integer = nSArray1.get_Count() - 1
							For i As Integer = 0 To count Step 1
								Dim nSDictionary2 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray1.ElementAt(i), Claunia.PropertyList.NSDictionary)
								If (nSDictionary2.ContainsKey("deviceNumber")) Then
									If (Operators.CompareString(udid, nSDictionary2.ObjectForKey("deviceNumber").ToString(), False) = 0) Then
										flag = True
										Exit For
									End If
								End If
							Next

						End If
					End If
					If (Not flag) Then
						Try
							Dim autoResign5 As SuperImpactor.AutoResign = Me
							Dim addLogSafe6 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
							Dim objArray5() As Object = { String.Concat("	[3+/", Conversions.ToString(num2), "] Add device...") }
							autoResign5.Invoke(addLogSafe6, objArray5)
						Catch exception3 As System.Exception
							ProjectData.SetProjectError(exception3)
							ProjectData.ClearProjectError()
						End Try
						Application.DoEvents()
						nSDictionary = AppleService.addDevice(udid, deviceName, str7)
						flag = False
						If (nSDictionary.ContainsKey("devices")) Then
							Dim nSArray2 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("devices"), Claunia.PropertyList.NSArray)
							If (nSArray2.get_Count() > 0) Then
								Dim count1 As Integer = nSArray2.get_Count() - 1
								For j As Integer = 0 To count1 Step 1
									Dim nSDictionary3 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray2.ElementAt(j), Claunia.PropertyList.NSDictionary)
									If (nSDictionary3.ContainsKey("deviceNumber")) Then
										If (Operators.CompareString(udid, nSDictionary3.ObjectForKey("deviceNumber").ToString(), False) = 0) Then
											flag = True
											Exit For
										End If
									End If
								Next

							End If
						ElseIf (nSDictionary.ContainsKey("device")) Then
							Dim nSDictionary4 As Claunia.PropertyList.NSDictionary = DirectCast(nSDictionary.ObjectForKey("device"), Claunia.PropertyList.NSDictionary)
							If (nSDictionary4.ContainsKey("deviceNumber")) Then
								If (Operators.CompareString(udid, nSDictionary4.ObjectForKey("deviceNumber").ToString(), False) = 0) Then
									flag = True
								End If
							End If
						End If
						If (Not flag) Then
							GoTo Label1
						End If
					End If
					Try
						Dim autoResign6 As SuperImpactor.AutoResign = Me
						Dim addLogSafe7 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray6() As Object = { String.Concat("	[4/", Conversions.ToString(num2), "] Get certs...") }
						autoResign6.Invoke(addLogSafe7, objArray6)
					Catch exception4 As System.Exception
						ProjectData.SetProjectError(exception4)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					nSDictionary = AppleService.allDevelopmentCert(str7)
					AppConst.logger.Info(String.Concat("Install::create: all certs: ", nSDictionary.ToXmlPropertyList()))
					Dim base64String As String = ""
					If (nSDictionary.ContainsKey("certificates")) Then
						Dim nSArray3 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("certificates"), Claunia.PropertyList.NSArray)
						Dim count2 As Integer = nSArray3.get_Count() - 1
						For k As Integer = 0 To count2 Step 1
							Dim nSDictionary5 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray3.ElementAt(k), Claunia.PropertyList.NSDictionary)
							If (nSDictionary5.ContainsKey("certContent") And nSDictionary5.ContainsKey("machineName")) Then
								Dim str8 As String = nSDictionary5.ObjectForKey("machineName").ToString()
								If (Operators.CompareString(str8, machineName, False) = 0) Then
									AppleService.revokeCertificate(nSDictionary5.ObjectForKey("serialNumber").ToString(), str7)
								End If
							End If
						Next

					End If
					Dim str9 As String = String.Concat(AppConst.m_rootPath, "\certs\", Common.GetHash(appleId))
					Dim str10 As String = String.Concat(str9, "\ios.key")
					Dim str11 As String = String.Concat(str9, "\private.pem")
					Dim str12 As String = String.Concat(str9, "\ios.csr")
					Dim str13 As String = String.Concat(str9, "\ios.cer")
					Dim str14 As String = String.Concat(str9, "\ioscer.pem")
					Dim str15 As String = String.Concat(str9, "\ios.mobileprovision")
					If (Operators.CompareString(base64String, "", False) <> 0) Then
						If (Directory.Exists(str9)) Then
							If (Not File.Exists(str11) Or Not File.Exists(str10) Or Not File.Exists(str12)) Then
								GoTo Label7
							End If
							GoTo Label2
						Else
							AppleService.revokeCertificate(str1, str7)
						End If
					End If
				Label7:
					If (Not Directory.Exists(str9)) Then
						Directory.CreateDirectory(str9)
					End If
					str = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe"), String.Concat("genrsa -des3 -passout pass:12345 -out """, str10, """ 2048"), False)
					Dim str16 As String = str
					Dim str17 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim strArrays1() As String = { "rsa -in """, str10, """ -passin pass:12345 -out """, str11, """ -outform PEM" }
					str = Await Common.RunExe(str17, String.Concat(strArrays1), False)
					str16 = str
					Dim str18 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim mRootPath() As String = { "req -new -key """, str10, """ -passin pass:12345 -out """, str12, """ -subj ""/emailAddress=noname@superimpactor.com, CN=SuperImpactor, C=VN"" -config """, AppConst.m_rootPath, "\openssl\bin\openssl.cfg""" }
					str = Await Common.RunExe(str18, String.Concat(mRootPath), False)
					str16 = str
					File.ReadAllText(str11)
					Dim str19 As String = File.ReadAllText(str12)
					Try
						Dim autoResign7 As SuperImpactor.AutoResign = Me
						Dim addLogSafe8 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray7() As Object = { String.Concat("	[4+/", Conversions.ToString(num2), "] Add cert...") }
						autoResign7.Invoke(addLogSafe8, objArray7)
					Catch exception5 As System.Exception
						ProjectData.SetProjectError(exception5)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					nSDictionary = AppleService.addDevelopmentCert(str19, machineName, machineId, str7)
					AppConst.logger.Info(String.Concat("Install::create: add cert: ", nSDictionary.ToXmlPropertyList()))
					nSDictionary = AppleService.allDevelopmentCert(str7)
					AppConst.logger.Info(String.Concat("Install::create: all certs after added: ", nSDictionary.ToXmlPropertyList()))
					If (nSDictionary.ContainsKey("certificates")) Then
						Dim nSArray4 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("certificates"), Claunia.PropertyList.NSArray)
						Dim count3 As Integer = nSArray4.get_Count() - 1
						For l As Integer = 0 To count3 Step 1
							Dim nSDictionary6 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray4.ElementAt(l), Claunia.PropertyList.NSDictionary)
							If (nSDictionary6.ContainsKey("certContent") And nSDictionary6.ContainsKey("machineName")) Then
								Dim str20 As String = nSDictionary6.ObjectForKey("machineName").ToString()
								If (Operators.CompareString(str20, machineName, False) = 0) Then
									base64String = Convert.ToBase64String(DirectCast(nSDictionary6.ObjectForKey("certContent"), NSData).get_Bytes())
								End If
							End If
						Next

					End If
					If (Operators.CompareString(base64String, "", False) = 0) Then
						Try
							autoResign1 = Me
							addLogSafe1 = addLogSafe2
							objArray1 = New Object() { "	ERROR: Cannot create cert. Please Revoke the existing one!" }
							obj = autoResign1.Invoke(addLogSafe1, objArray1)
						Catch exception6 As System.Exception
							ProjectData.SetProjectError(exception6)
							ProjectData.ClearProjectError()
						End Try
						num1 = -2
						num = num1
						Return
					End If
				Label2:
					File.WriteAllBytes(str13, Convert.FromBase64String(base64String))
					Dim str21 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim strArrays2() As String = { "x509 -in """, str13, """ -inform DER -out """, str14, """ -outform PEM" }
					Await Common.RunExe(str21, String.Concat(strArrays2), False)
					Try
						Dim autoResign8 As SuperImpactor.AutoResign = Me
						Dim addLogSafe9 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray8() As Object = { String.Concat("	[5/", Conversions.ToString(num2), "] Get AppID...") }
						autoResign8.Invoke(addLogSafe9, objArray8)
					Catch exception7 As System.Exception
						ProjectData.SetProjectError(exception7)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					nSDictionary = AppleService.appIds(str7)
					AppConst.logger.Info(String.Concat("Install::create: all appIds: ", nSDictionary.ToXmlPropertyList()))
					str2 = ""
					If (nSDictionary.ContainsKey("appIds")) Then
						Dim nSArray5 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("appIds"), Claunia.PropertyList.NSArray)
						If (nSArray5.get_Count() > 0) Then
							Dim num3 As Integer = nSArray5.get_Count() - 1
							For m As Integer = 0 To num3 Step 1
								Dim nSDictionary7 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray5.ElementAt(m), Claunia.PropertyList.NSDictionary)
								If (nSDictionary7.ContainsKey("identifier") And Operators.CompareString(nSDictionary7.ObjectForKey("identifier").ToString(), str3, False) = 0) Then
									str2 = nSDictionary7.ObjectForKey("appIdId").ToString()
								End If
							Next

						End If
						If (Operators.CompareString(str2, "", False) = 0 And nSArray5.get_Count() >= 10) Then
							Try
								autoResign = Me
								addLogSafe = addLogSafe2
								objArray = New Object() { "	ERROR: Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days" }
								obj1 = autoResign.Invoke(addLogSafe, objArray)
							Catch exception8 As System.Exception
								ProjectData.SetProjectError(exception8)
								ProjectData.ClearProjectError()
							End Try
							num1 = -2
							num = num1
							Return
						End If
					End If
					If (Operators.CompareString(str2, "", False) = 0) Then
						Try
							Dim autoResign9 As SuperImpactor.AutoResign = Me
							Dim addLogSafe10 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
							Dim objArray9() As Object = { String.Concat("	[5+/", Conversions.ToString(num2), "] add AppID...") }
							autoResign9.Invoke(addLogSafe10, objArray9)
						Catch exception9 As System.Exception
							ProjectData.SetProjectError(exception9)
							ProjectData.ClearProjectError()
						End Try
						Application.DoEvents()
						nSDictionary = AppleService.addAppId(str4, str3, str7)
						If (nSDictionary.ContainsKey("appId")) Then
							GoTo Label6
						End If
						AppConst.logger.Info(String.Concat("Install::create: add appId failed: ", nSDictionary.ToXmlPropertyList()))
						If (Not nSDictionary.ContainsKey("userString")) Then
							Try
								Dim autoResign10 As SuperImpactor.AutoResign = Me
								Dim addLogSafe11 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
								Dim objArray10() As Object = { "	ERROR: Cannot create App ID. It seem you use other Apple Id to install this app before. Please remove that AppId from menu Tool->Delete AppIds then try again" }
								autoResign10.Invoke(addLogSafe11, objArray10)
							Catch exception10 As System.Exception
								ProjectData.SetProjectError(exception10)
								ProjectData.ClearProjectError()
							End Try
							num1 = -2
							num = num1
							Return
						Else
							Try
								Dim autoResign11 As SuperImpactor.AutoResign = Me
								Dim addLogSafe12 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
								Dim objArray11() As Object = { String.Concat("	ERROR: Cannot create App ID: ", nSDictionary.ObjectForKey("userString").ToString()) }
								autoResign11.Invoke(addLogSafe12, objArray11)
							Catch exception11 As System.Exception
								ProjectData.SetProjectError(exception11)
								ProjectData.ClearProjectError()
							End Try
							num1 = -2
							num = num1
							Return
						End If
					End If
				Label8:
					Database.updateInstalledApp(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Interaction.IIf(cloneId.Equals(""), "", String.Concat("clone", cloneId, ".")), appInfo.Package))), appleId, Path.GetFileName(str5), udid)
					Try
						Dim autoResign12 As SuperImpactor.AutoResign = Me
						Dim addLogSafe13 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray12() As Object = { String.Concat("	[6/", Conversions.ToString(num2), "] Get provision...") }
						autoResign12.Invoke(addLogSafe13, objArray12)
					Catch exception12 As System.Exception
						ProjectData.SetProjectError(exception12)
						ProjectData.ClearProjectError()
					End Try
					Application.DoEvents()
					nSDictionary = AppleService.downloadProvisionProfile(str2, str7)
					AppConst.logger.Info(String.Concat("Install::create: provision: ", nSDictionary.ToXmlPropertyList()))
					If (Not nSDictionary.ContainsKey("provisioningProfile")) Then
						Try
							Dim autoResign13 As SuperImpactor.AutoResign = Me
							Dim addLogSafe14 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
							Dim objArray13() As Object = { "	ERROR: Cannot get provision" }
							autoResign13.Invoke(addLogSafe14, objArray13)
						Catch exception13 As System.Exception
							ProjectData.SetProjectError(exception13)
							ProjectData.ClearProjectError()
						End Try
					Else
						Dim nSDictionary8 As Claunia.PropertyList.NSDictionary = DirectCast(nSDictionary.ObjectForKey("provisioningProfile"), Claunia.PropertyList.NSDictionary)
						If (Not nSDictionary8.ContainsKey("encodedProfile")) Then
							Try
								Dim autoResign14 As SuperImpactor.AutoResign = Me
								Dim addLogSafe15 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
								Dim objArray14() As Object = { "	ERROR: Cannot get provision" }
								autoResign14.Invoke(addLogSafe15, objArray14)
							Catch exception14 As System.Exception
								ProjectData.SetProjectError(exception14)
								ProjectData.ClearProjectError()
							End Try
						Else
							Dim bytes As Byte() = DirectCast(nSDictionary8.ObjectForKey("encodedProfile"), NSData).get_Bytes()
							File.WriteAllBytes(str15, bytes)
							AppConst.logger.Info("Install::create: start sign")
							Dim tempFolder As String = Common.GetTempFolder()
							Try
								Directory.Delete(tempFolder, True)
							Catch exception15 As System.Exception
								ProjectData.SetProjectError(exception15)
								ProjectData.ClearProjectError()
							End Try
							Application.DoEvents()
							Common.Unzip(String.Concat(AppConst.m_rootPath, "data"), tempFolder, "ABCDEF$%^&abcdef12345")
							Application.DoEvents()
							Common.Unzip(String.Concat(tempFolder, "\data"), tempFolder, "")
							Application.DoEvents()
							Directory.SetCurrentDirectory(String.Concat(tempFolder, "\scripts\"))
							Try
								Dim autoResign15 As SuperImpactor.AutoResign = Me
								Dim addLogSafe16 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
								Dim objArray15() As Object = { String.Concat("	[7/", Conversions.ToString(num2), "] Sign...") }
								autoResign15.Invoke(addLogSafe16, objArray15)
							Catch exception16 As System.Exception
								ProjectData.SetProjectError(exception16)
								ProjectData.ClearProjectError()
							End Try
							Application.DoEvents()
							Dim name() As String = { "isign -i CFBundleIdentifier=", str3, ",CFBundleDisplayName=""", appInfo.Name, """ -c """, str14, """ -k """, str11, """ -p """, str15, """ -o superimpact.ipa """, str5, """" }
							str = Await Common.RunExe("..\python.exe", String.Concat(name), False)
							Dim str22 As String = str
							Dim str23 As String = ""
							If (Not File.Exists("superimpact.ipa")) Then
								AppConst.logger.Info(String.Concat("Install::create: sign app failed: ", str22))
								str23 = "Sign failed"
							Else
								Try
									Dim autoResign16 As SuperImpactor.AutoResign = Me
									Dim addLogSafe17 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
									Dim objArray16() As Object = { String.Concat("	[8/", Conversions.ToString(num2), "] Install...") }
									autoResign16.Invoke(addLogSafe17, objArray16)
								Catch exception17 As System.Exception
									ProjectData.SetProjectError(exception17)
									ProjectData.ClearProjectError()
								End Try
								Application.DoEvents()
								Dim str24 As String = String.Concat(AppConst.m_rootPath, "\certs\\pr\", udid)
								Try
									Directory.CreateDirectory(str24)
								Catch exception18 As System.Exception
									ProjectData.SetProjectError(exception18)
									ProjectData.ClearProjectError()
								End Try
								str = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("copy """, str24, """"), False)
								str22 = str
								str = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), "remove-all", False)
								str22 = str
								str = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinstaller.exe"), String.Concat("-u ", udid, " -i superimpact.ipa"), True)
								str22 = str
								Debug.Print(String.Concat("install output=", str22))
								AppConst.logger.Info(String.Concat("Install output: ", str22))
								Dim str25 As String = ""
								If (str22.IndexOf("ERROR:", StringComparison.Ordinal) > 0) Then
									str25 = str22.Substring(str22.IndexOf("ERROR:", StringComparison.Ordinal))
								ElseIf (str22.IndexOf("error", StringComparison.Ordinal) > 0) Then
									str25 = str22.Substring(str22.IndexOf("error", StringComparison.Ordinal))
								ElseIf (str22.IndexOf("No iOS device found", StringComparison.Ordinal) > 0) Then
									str25 = str22.Substring(str22.IndexOf("No iOS device found", StringComparison.Ordinal))
								End If
								If (Not str25.Equals("")) Then
									AppConst.logger.Info(String.Concat("Install::create: install app failed: ", str25))
									str23 = String.Concat("Install failed!: " & VbCrLf & "", str25)
								End If
								Try
									Dim autoResign17 As SuperImpactor.AutoResign = Me
									Dim addLogSafe18 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
									Dim objArray17() As Object = { String.Concat("	[9/", Conversions.ToString(num2), "] Few seconds for finishing...") }
									autoResign17.Invoke(addLogSafe18, objArray17)
								Catch exception19 As System.Exception
									ProjectData.SetProjectError(exception19)
									ProjectData.ClearProjectError()
								End Try
								Application.DoEvents()
								Dim files As String() = Directory.GetFiles(str24)
								Dim num4 As Integer = Information.UBound(files, 1)
								For n As Integer = 0 To num4 Step 1
									If (Operators.CompareString(Path.GetExtension(files(n)).ToLower(), ".mobileprovision", False) = 0) Then
										Dim strArrays3 As String() = File.ReadAllLines(files(n))
										Dim flag1 As Boolean = False
										Dim num5 As Integer = Information.LBound(strArrays3, 1)
										Dim num6 As Integer = Information.UBound(strArrays3, 1)
										Dim num7 As Integer = num5
										Do
											If (strArrays3(num7).IndexOf("<key>ExpirationDate</key>") >= 0) Then
												Dim str26 As String = strArrays3(num7 + 1).Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim()
												Dim dateTime As System.DateTime = System.DateTime.ParseExact(str26, "yyyy-MM-dd HH:mm:ss", Nothing)
												If (System.DateTime.Compare(dateTime, System.DateTime.Now) < 0) Then
													flag1 = True
													Exit Do
												End If
											End If
											num7 = num7 + 1
										Loop While num7 <= num6
										If (Not flag1) Then
											str = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("install """, files(n), """"), False)
											str22 = str
										Else
											File.Delete(files(n))
										End If
										Application.DoEvents()
									End If
								Next

							End If
							Directory.SetCurrentDirectory(String.Concat(tempFolder, "\..\"))
							Common.DeleteFilesFromFolder(tempFolder)
							Try
								Directory.Delete(AppConst.m_localTmp, True)
							Catch exception20 As System.Exception
								ProjectData.SetProjectError(exception20)
								ProjectData.ClearProjectError()
							End Try
							Dim directories As String() = Directory.GetDirectories(String.Concat(tempFolder, "\..\"))
							Dim num8 As Integer = 0
							While num8 < CInt(directories.Length)
								Dim str27 As String = directories(num8)
								If (Path.GetFileName(str27).StartsWith("isign-")) Then
									Try
										Common.DeleteFilesFromFolder(str27)
									Catch exception21 As System.Exception
										ProjectData.SetProjectError(exception21)
										ProjectData.ClearProjectError()
									End Try
								End If
								num8 = num8 + 1
							End While
							If (Operators.CompareString(str23, "", False) <> 0) Then
								Try
									Dim autoResign18 As SuperImpactor.AutoResign = Me
									Dim addLogSafe19 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
									Dim objArray18() As Object = { String.Concat("	-----> ERROR: ", str23) }
									autoResign18.Invoke(addLogSafe19, objArray18)
								Catch exception22 As System.Exception
									ProjectData.SetProjectError(exception22)
									ProjectData.ClearProjectError()
								End Try
							Else
								Try
									Dim autoResign19 As SuperImpactor.AutoResign = Me
									Dim addLogSafe20 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
									Dim objArray19() As Object = { "	-----> SUCCESS" }
									autoResign19.Invoke(addLogSafe20, objArray19)
								Catch exception23 As System.Exception
									ProjectData.SetProjectError(exception23)
									ProjectData.ClearProjectError()
								End Try
							End If
						End If
					End If
				Else
					AppConst.logger.Info(String.Concat("Install::create: not have teamId: ", nSDictionary.ToXmlPropertyList()))
					Try
						Dim autoResign20 As SuperImpactor.AutoResign = Me
						Dim addLogSafe21 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
						Dim objArray20() As Object = { "	ERROR: Not have teamId" }
						autoResign20.Invoke(addLogSafe21, objArray20)
					Catch exception24 As System.Exception
						ProjectData.SetProjectError(exception24)
						ProjectData.ClearProjectError()
					End Try
				End If
			Else
				AppConst.logger.Info(String.Concat("Install::create: cannot login itune: ", nSDictionary.ToXmlPropertyList()))
				Try
					Dim autoResign21 As SuperImpactor.AutoResign = Me
					Dim addLogSafe22 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
					Dim objArray21() As Object = { "	ERROR: Cannot login itune..." }
					autoResign21.Invoke(addLogSafe22, objArray21)
				Catch exception25 As System.Exception
					ProjectData.SetProjectError(exception25)
					ProjectData.ClearProjectError()
				End Try
			End If
			num1 = -2
			num = num1
			Return
		Label1:
			AppConst.logger.Info(String.Concat("Install::create: cannot add device ", nSDictionary.ToXmlPropertyList()))
			If (Not nSDictionary.ContainsKey("userString")) Then
				Try
					Dim autoResign22 As SuperImpactor.AutoResign = Me
					Dim addLogSafe23 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
					Dim objArray22() As Object = { "	ERROR: Cannot add device" }
					autoResign22.Invoke(addLogSafe23, objArray22)
				Catch exception26 As System.Exception
					ProjectData.SetProjectError(exception26)
					ProjectData.ClearProjectError()
				End Try
				num1 = -2
				num = num1
				Return
			Else
				Try
					Dim autoResign23 As SuperImpactor.AutoResign = Me
					Dim addLogSafe24 As SuperImpactor.AutoResign.AddLogSafe = addLogSafe2
					Dim objArray23() As Object = { String.Concat("	ERROR: Cannot add device: ", nSDictionary.ObjectForKey("userString").ToString()) }
					autoResign23.Invoke(addLogSafe24, objArray23)
				Catch exception27 As System.Exception
					ProjectData.SetProjectError(exception27)
					ProjectData.ClearProjectError()
				End Try
				num1 = -2
				num = num1
				Return
			End If
			GoTo Label7
			Try
				autoResign1 = Me
				addLogSafe1 = addLogSafe2
				objArray1 = New Object() { "	ERROR: Cannot create cert. Please Revoke the existing one!" }
				obj = autoResign1.Invoke(addLogSafe1, objArray1)
			Catch exception6 As System.Exception
				ProjectData.SetProjectError(exception6)
				ProjectData.ClearProjectError()
			End Try
			num1 = -2
			num = num1
			Return
			Try
				autoResign = Me
				addLogSafe = addLogSafe2
				objArray = New Object() { "	ERROR: Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days" }
				obj1 = autoResign.Invoke(addLogSafe, objArray)
			Catch exception8 As System.Exception
				ProjectData.SetProjectError(exception8)
				ProjectData.ClearProjectError()
			End Try
			num1 = -2
			num = num1
			Return
		Label6:
			Dim nSDictionary9 As Claunia.PropertyList.NSDictionary = DirectCast(nSDictionary.ObjectForKey("appId"), Claunia.PropertyList.NSDictionary)
			str2 = nSDictionary9.ObjectForKey("appIdId").ToString()
			GoTo Label8
		End Function

		Public Sub ResignAsync(ByVal lstAppInfos As List(Of AppInfosResign), ByVal udid As String, ByVal deviceName As String, ByVal machineName As String, ByVal machineId As String)
			Me.lstAppInfo = lstAppInfos
			Me.udid = udid
			Me.deviceName = deviceName
			Me.machineName = machineName
			Me.machineId = machineId
			Me.BackgroundWorker1.WorkerSupportsCancellation = True
			MyBase.Show()
			Me.picLoading.Visible = True
			Me.BackgroundWorker1.RunWorkerAsync()
		End Sub

		Public Delegate Sub AddLogSafe(ByVal log As String)

		Public Delegate Sub ChangeTextsSafe(ByVal no As String, ByVal appInf As AppInfos)

		Public Delegate Sub CompleteSafe(ByVal cancelled As Boolean)
	End Class
End Namespace