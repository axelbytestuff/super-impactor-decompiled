Imports Claunia.PropertyList
Imports Ionic.Zip
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class Install
		Inherits Form
		Private components As IContainer

		Private trd As Thread

		Public Shared appInfo As AppInfos

		Private statusRs As String

		Private appId As String

		Private isExit As Boolean

		Private lstAcc As Dictionary(Of String, String)

		Private listDevice As List(Of Install.DeviceInfo)

		Private cloneID As String

		Friend Overridable Property chkCloneApp As CheckBox

		Friend Overridable Property chkSave As CheckBox

		Friend Overridable Property cmbAppleId As ComboBox
			Get
				stackVariable1 = Me._cmbAppleId
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ComboBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmbAppleId_SelectedIndexChanged)
				Dim comboBox As System.Windows.Forms.ComboBox = Me._cmbAppleId
				If (comboBox IsNot Nothing) Then
					RemoveHandler comboBox.SelectedIndexChanged,  eventHandler
				End If
				Me._cmbAppleId = value
				comboBox = Me._cmbAppleId
				If (comboBox IsNot Nothing) Then
					AddHandler comboBox.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmbDevice As ComboBox
			Get
				stackVariable1 = Me._cmbDevice
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ComboBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmbDevice_TextChanged)
				Dim comboBox As System.Windows.Forms.ComboBox = Me._cmbDevice
				If (comboBox IsNot Nothing) Then
					RemoveHandler comboBox.TextChanged,  eventHandler
				End If
				Me._cmbDevice = value
				comboBox = Me._cmbDevice
				If (comboBox IsNot Nothing) Then
					AddHandler comboBox.TextChanged,  eventHandler
				End If
			End Set
		End Property

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

		Friend Overridable Property Label1 As Label

		Friend Overridable Property Label2 As Label

		Friend Overridable Property Label3 As Label

		Friend Overridable Property Label4 As Label

		Friend Overridable Property Label5 As Label

		Friend Overridable Property lblLoading As Label

		Friend Overridable Property picLoading As PictureBox

		Friend Overridable Property txtAppName As TextBox

		Friend Overridable Property txtPassword As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Install_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub cmbAppleId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtPassword.Text = Me.lstAcc(Me.cmbAppleId.Text)
		End Sub

		Private Sub cmbDevice_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String = Nothing
			Dim str1 As String
			If (Me.cmbDevice.Text.Length > 40) Then
				Dim str2 As String = Me.cmbDevice.Text.Substring(Me.cmbDevice.Text.Length - 40)
				str1 = If(Not Me.cloneID.Equals(""), Database.getInstalledApp(String.Concat("clone", Me.cloneID, ".", Install.appInfo.Package), str2, str), Database.getInstalledApp(Install.appInfo.Package, str2, str))
				If (Operators.CompareString(str1, "", False) <> 0) Then
					Me.cmbAppleId.Text = str1
				End If
			End If
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.isExit = True
			MyBase.Close()
		End Sub

		Private Async Sub cmdInstall_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim variable As Install.VB$StateMachine_82_cmdInstall_Click = Nothing
			AsyncVoidMethodBuilder.Create().Start(Of Install.VB$StateMachine_82_cmdInstall_Click)(variable)
		End Sub

		Public Async Function Create(ByVal appleId As String, ByVal password As String, ByVal udid As String, ByVal deviceName As String, ByVal machineName As String, ByVal machineId As String, ByVal ipaOrgFile As String, Optional ByVal isClone As Boolean = False) As Task(Of String)
			Dim str As String
			Dim num As Integer
			Dim str1 As String
			Dim num1 As Integer
			Dim str2 As String
			Dim str3 As String = Nothing
			Dim str4 As String
			If (Not isClone) Then
				str2 = Me.cloneID
				If (Not str2.Equals("")) Then
					isClone = True
				End If
			Else
				Dim now As TimeSpan = System.DateTime.Now - New System.DateTime(1970, 1, 1)
				str2 = Common.GetHash(Conversions.ToString(now.TotalMilliseconds)).Substring(25)
			End If
			Dim str5 As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Operators.AddObject(String.Concat("si.", Common.GetHash(Microsoft.VisualBasic.Strings.Trim(appleId)), "."), Interaction.IIf(isClone, String.Concat("clone", str2, "."), "")), Regex.Replace(Install.appInfo.Package, "[^a-zA-Z.]", ""))))
			Dim str6 As String = Regex.Replace(String.Concat("SI - ", Install.appInfo.Name), "[^a-zA-Z ]", "")
			Dim log As ILog = AppConst.logger
			Dim strArrays() As String = { "Install::create: ", deviceName, ",", machineName, ",", machineId, ",", ipaOrgFile, "    id=", str5, ",", str6 }
			log.Info(String.Concat(strArrays))
			Dim num2 As Integer = 9
			Me.lblLoading.Text = String.Concat("[1/", Conversions.ToString(num2), "] Login...")
			Application.DoEvents()
			Dim nSDictionary As Claunia.PropertyList.NSDictionary = AppleService.login(appleId, password)
			If (nSDictionary.ContainsKey("myacinfo")) Then
				Dim str7 As String = nSDictionary.ObjectForKey("myacinfo").ToString()
				Me.lblLoading.Text = String.Concat("[2/", Conversions.ToString(num2), "] Get team...")
				Application.DoEvents()
				nSDictionary = AppleService.listTeam(str7)
				Dim str8 As String = ""
				If (nSDictionary.ContainsKey("teams")) Then
					Dim nSArray As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("teams"), Claunia.PropertyList.NSArray)
					If (nSArray.get_Count() > 0) Then
						Dim nSDictionary1 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray.ElementAt(0), Claunia.PropertyList.NSDictionary)
						If (nSDictionary1.ContainsKey("teamId")) Then
							str8 = nSDictionary1.ObjectForKey("teamId").ToString()
						End If
					End If
				End If
				If (Operators.CompareString(str8, "", False) <> 0) Then
					Me.lblLoading.Text = String.Concat("[3/", Conversions.ToString(num2), "] Get devices...")
					Application.DoEvents()
					nSDictionary = AppleService.listDevices(str8)
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
						Me.lblLoading.Text = String.Concat("[3+/", Conversions.ToString(num2), "] Add device...")
						Application.DoEvents()
						nSDictionary = AppleService.addDevice(udid, deviceName, str8)
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
							AppConst.logger.Info(String.Concat("Install::create: cannot add device ", nSDictionary.ToXmlPropertyList()))
							If (Not nSDictionary.ContainsKey("userString")) Then
								str = "Cannot add device"
								num1 = -2
								num = num1
								Return str
							Else
								str = String.Concat("Cannot add device: ", nSDictionary.ObjectForKey("userString").ToString())
								num1 = -2
								num = num1
								Return str
							End If
						End If
					End If
					Me.lblLoading.Text = String.Concat("[4/", Conversions.ToString(num2), "] Get certs...")
					Application.DoEvents()
					nSDictionary = AppleService.allDevelopmentCert(str8)
					AppConst.logger.Info(String.Concat("Install::create: all certs: ", nSDictionary.ToXmlPropertyList()))
					Dim base64String As String = ""
					If (nSDictionary.ContainsKey("certificates")) Then
						Dim nSArray3 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("certificates"), Claunia.PropertyList.NSArray)
						Dim count2 As Integer = nSArray3.get_Count() - 1
						For k As Integer = 0 To count2 Step 1
							Dim nSDictionary5 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray3.ElementAt(k), Claunia.PropertyList.NSDictionary)
							If (nSDictionary5.ContainsKey("certContent") And nSDictionary5.ContainsKey("machineName")) Then
								Dim str9 As String = nSDictionary5.ObjectForKey("machineName").ToString()
								If (Operators.CompareString(str9, machineName, False) = 0) Then
									str3 = nSDictionary5.ObjectForKey("serialNumber").ToString()
									base64String = Convert.ToBase64String(DirectCast(nSDictionary5.ObjectForKey("certContent"), NSData).get_Bytes())
								End If
							End If
						Next

					End If
					Dim str10 As String = String.Concat(AppConst.m_rootPath, "\certs\", Common.GetHash(appleId))
					Dim str11 As String = String.Concat(str10, "\ios.key")
					Dim str12 As String = String.Concat(str10, "\private.pem")
					Dim str13 As String = String.Concat(str10, "\ios.csr")
					Dim str14 As String = String.Concat(str10, "\ios.cer")
					Dim str15 As String = String.Concat(str10, "\ioscer.pem")
					Dim str16 As String = String.Concat(str10, "\ios.mobileprovision")
					If (Operators.CompareString(base64String, "", False) <> 0) Then
						If (Directory.Exists(str10)) Then
							If (Not File.Exists(str12) Or Not File.Exists(str11) Or Not File.Exists(str13)) Then
								GoTo Label3
							End If
							GoTo Label1
						Else
							AppleService.revokeCertificate(str3, str8)
						End If
					End If
				Label3:
					If (Not Directory.Exists(str10)) Then
						Directory.CreateDirectory(str10)
					End If
					str1 = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe"), String.Concat("genrsa -des3 -passout pass:12345 -out """, str11, """ 2048"), False)
					Dim str17 As String = str1
					Dim str18 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim strArrays1() As String = { "rsa -in """, str11, """ -passin pass:12345 -out """, str12, """ -outform PEM" }
					str1 = Await Common.RunExe(str18, String.Concat(strArrays1), False)
					str17 = str1
					Dim str19 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim mRootPath() As String = { "req -new -key """, str11, """ -passin pass:12345 -out """, str13, """ -subj ""/emailAddress=noname@superimpactor.com, CN=SuperImpactor, C=VN"" -config """, AppConst.m_rootPath, "\openssl\bin\openssl.cfg""" }
					str1 = Await Common.RunExe(str19, String.Concat(mRootPath), False)
					str17 = str1
					File.ReadAllText(str12)
					Dim str20 As String = File.ReadAllText(str13)
					Me.lblLoading.Text = String.Concat("[4+/", Conversions.ToString(num2), "] Add cert...")
					Application.DoEvents()
					nSDictionary = AppleService.addDevelopmentCert(str20, machineName, machineId, str8)
					AppConst.logger.Info(String.Concat("Install::create: add cert: ", nSDictionary.ToXmlPropertyList()))
					nSDictionary = AppleService.allDevelopmentCert(str8)
					AppConst.logger.Info(String.Concat("Install::create: all certs after added: ", nSDictionary.ToXmlPropertyList()))
					If (nSDictionary.ContainsKey("certificates")) Then
						Dim nSArray4 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("certificates"), Claunia.PropertyList.NSArray)
						Dim count3 As Integer = nSArray4.get_Count() - 1
						For l As Integer = 0 To count3 Step 1
							Dim nSDictionary6 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray4.ElementAt(l), Claunia.PropertyList.NSDictionary)
							If (nSDictionary6.ContainsKey("certContent") And nSDictionary6.ContainsKey("machineName")) Then
								Dim str21 As String = nSDictionary6.ObjectForKey("machineName").ToString()
								If (Operators.CompareString(str21, machineName, False) = 0) Then
									base64String = Convert.ToBase64String(DirectCast(nSDictionary6.ObjectForKey("certContent"), NSData).get_Bytes())
								End If
							End If
						Next

					End If
					If (Operators.CompareString(base64String, "", False) = 0) Then
						str = "Cannot create cert. Please Revoke the existing one!"
						num1 = -2
						num = num1
						Return str
					End If
				Label1:
					File.WriteAllBytes(str14, Convert.FromBase64String(base64String))
					Dim str22 As String = String.Concat(AppConst.m_rootPath, "\openssl\bin\openssl.exe")
					Dim strArrays2() As String = { "x509 -in """, str14, """ -inform DER -out """, str15, """ -outform PEM" }
					Await Common.RunExe(str22, String.Concat(strArrays2), False)
					Me.lblLoading.Text = String.Concat("[5/", Conversions.ToString(num2), "] Get AppID...")
					Application.DoEvents()
					nSDictionary = AppleService.appIds(str8)
					AppConst.logger.Info(String.Concat("Install::create: all appIds: ", nSDictionary.ToXmlPropertyList()))
					Dim str23 As String = ""
					If (nSDictionary.ContainsKey("appIds")) Then
						Dim nSArray5 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("appIds"), Claunia.PropertyList.NSArray)
						If (nSArray5.get_Count() > 0) Then
							Dim num3 As Integer = nSArray5.get_Count() - 1
							For m As Integer = 0 To num3 Step 1
								Dim nSDictionary7 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray5.ElementAt(m), Claunia.PropertyList.NSDictionary)
								If (nSDictionary7.ContainsKey("identifier") And Operators.CompareString(nSDictionary7.ObjectForKey("identifier").ToString(), str5, False) = 0) Then
									str23 = nSDictionary7.ObjectForKey("appIdId").ToString()
								End If
							Next

						End If
						If (Operators.CompareString(str23, "", False) = 0 And nSArray5.get_Count() >= 10) Then
							str = "Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days"
							num1 = -2
							num = num1
							Return str
						End If
					End If
					If (Operators.CompareString(str23, "", False) = 0) Then
						Me.lblLoading.Text = String.Concat("[5+/", Conversions.ToString(num2), "] add AppID...")
						Application.DoEvents()
						nSDictionary = AppleService.addAppId(str6, str5, str8)
						If (Not nSDictionary.ContainsKey("appId")) Then
							AppConst.logger.Info(String.Concat("Install::create: add appId failed: ", nSDictionary.ToXmlPropertyList()))
							If (Not nSDictionary.ContainsKey("userString")) Then
								str = "Cannot create App ID. It seem you use other Apple Id to install this app before. Please remove that AppId from menu Tool->Delete AppIds then try again"
								num1 = -2
								num = num1
								Return str
							Else
								str = String.Concat("Cannot create App ID: ", nSDictionary.ObjectForKey("userString").ToString())
								num1 = -2
								num = num1
								Return str
							End If
						Else
							Dim nSDictionary8 As Claunia.PropertyList.NSDictionary = DirectCast(nSDictionary.ObjectForKey("appId"), Claunia.PropertyList.NSDictionary)
							str23 = nSDictionary8.ObjectForKey("appIdId").ToString()
						End If
					End If
					Dim fileName As String = Path.GetFileName(ipaOrgFile)
					Database.updateInstalledApp(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Interaction.IIf(isClone, String.Concat("clone", str2, "."), ""), Install.appInfo.Package))), appleId, fileName, udid)
					Try
						File.Copy(ipaOrgFile, String.Concat(AppConst.m_rootPath, "/\download\/", fileName), True)
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
					Me.lblLoading.Text = String.Concat("[6/", Conversions.ToString(num2), "] Get provision...")
					Application.DoEvents()
					nSDictionary = AppleService.downloadProvisionProfile(str23, str8)
					AppConst.logger.Info(String.Concat("Install::create: provision: ", nSDictionary.ToXmlPropertyList()))
					If (Not nSDictionary.ContainsKey("provisioningProfile")) Then
						str = "Cannot get provision"
					Else
						Dim nSDictionary9 As Claunia.PropertyList.NSDictionary = DirectCast(nSDictionary.ObjectForKey("provisioningProfile"), Claunia.PropertyList.NSDictionary)
						If (Not nSDictionary9.ContainsKey("encodedProfile")) Then
							str = "Cannot get provision"
						Else
							Dim bytes As Byte() = DirectCast(nSDictionary9.ObjectForKey("encodedProfile"), NSData).get_Bytes()
							File.WriteAllBytes(str16, bytes)
							AppConst.logger.Info("Install::create: start sign")
							Dim tempFolder As String = Common.GetTempFolder()
							Try
								Directory.Delete(tempFolder, True)
							Catch exception1 As System.Exception
								ProjectData.SetProjectError(exception1)
								ProjectData.ClearProjectError()
							End Try
							Application.DoEvents()
							Common.Unzip(String.Concat(AppConst.m_rootPath, "data"), tempFolder, "ABCDEF$%^&abcdef12345")
							Application.DoEvents()
							Common.Unzip(String.Concat(tempFolder, "\data"), tempFolder, "")
							Application.DoEvents()
							Directory.SetCurrentDirectory(String.Concat(tempFolder, "\scripts\"))
							Me.lblLoading.Text = String.Concat("[7/", Conversions.ToString(num2), "] Sign...")
							Application.DoEvents()
							If (Not Me.txtAppName.Text.Equals("")) Then
								Dim text() As String = { "isign -i CFBundleIdentifier=", str5, ",CFBundleDisplayName=""", Me.txtAppName.Text, """ -c """, str15, """ -k """, str12, """ -p """, str16, """ -o superimpact.ipa """, ipaOrgFile, """" }
								str4 = String.Concat(text)
							Else
								Dim strArrays3() As String = { "isign -i CFBundleIdentifier=", str5, " -c """, str15, """ -k """, str12, """ -p """, str16, """ -o superimpact.ipa """, ipaOrgFile, """" }
								str4 = String.Concat(strArrays3)
							End If
							str1 = Await Common.RunExe("..\python.exe", str4, False)
							Dim str24 As String = str1
							Dim str25 As String = ""
							If (Not File.Exists("superimpact.ipa")) Then
								AppConst.logger.Info(String.Concat("Install::create: sign app failed: ", str24))
								str25 = "Sign failed"
							Else
								Me.lblLoading.Text = String.Concat("[8/", Conversions.ToString(num2), "] Install...")
								Application.DoEvents()
								Dim str26 As String = String.Concat(AppConst.m_rootPath, "\certs\\pr\", udid)
								Try
									Directory.CreateDirectory(str26)
								Catch exception2 As System.Exception
									ProjectData.SetProjectError(exception2)
									ProjectData.ClearProjectError()
								End Try
								str1 = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("copy """, str26, """"), False)
								str24 = str1
								str1 = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), "remove-all", False)
								str24 = str1
								str1 = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinstaller.exe"), String.Concat("-u ", udid, " -i superimpact.ipa"), True)
								str24 = str1
								Debug.Print(String.Concat("install output=", str24))
								AppConst.logger.Info(String.Concat("Install output: ", str24))
								Dim str27 As String = ""
								If (str24.IndexOf("ERROR:", StringComparison.Ordinal) > 0) Then
									str27 = str24.Substring(str24.IndexOf("ERROR:", StringComparison.Ordinal))
								ElseIf (str24.IndexOf("error", StringComparison.Ordinal) > 0) Then
									str27 = str24.Substring(str24.IndexOf("error", StringComparison.Ordinal))
								ElseIf (str24.IndexOf("No iOS device found", StringComparison.Ordinal) > 0) Then
									str27 = str24.Substring(str24.IndexOf("No iOS device found", StringComparison.Ordinal))
								End If
								If (Not str27.Equals("")) Then
									AppConst.logger.Info(String.Concat("Install::create: install app failed: ", str27))
									str25 = String.Concat("Install failed!: " & VbCrLf & "", str27)
								End If
								Me.lblLoading.Text = String.Concat("[9/", Conversions.ToString(num2), "] Few seconds for finishing...")
								Application.DoEvents()
								Dim files As String() = Directory.GetFiles(str26)
								Dim num4 As Integer = Information.UBound(files, 1)
								For n As Integer = 0 To num4 Step 1
									If (Operators.CompareString(Path.GetExtension(files(n)).ToLower(), ".mobileprovision", False) = 0) Then
										Dim strArrays4 As String() = File.ReadAllLines(files(n))
										Dim flag1 As Boolean = False
										Dim num5 As Integer = Information.LBound(strArrays4, 1)
										Dim num6 As Integer = Information.UBound(strArrays4, 1)
										Dim num7 As Integer = num5
										Do
											If (strArrays4(num7).IndexOf("<key>ExpirationDate</key>") >= 0) Then
												Dim str28 As String = strArrays4(num7 + 1).Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim()
												Dim dateTime As System.DateTime = System.DateTime.ParseExact(str28, "yyyy-MM-dd HH:mm:ss", Nothing)
												If (System.DateTime.Compare(dateTime, System.DateTime.Now) < 0) Then
													flag1 = True
													Exit Do
												End If
											End If
											num7 = num7 + 1
										Loop While num7 <= num6
										If (Not flag1) Then
											str1 = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("install """, files(n), """"), False)
											str24 = str1
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
							Catch exception3 As System.Exception
								ProjectData.SetProjectError(exception3)
								ProjectData.ClearProjectError()
							End Try
							Dim directories As String() = Directory.GetDirectories(String.Concat(tempFolder, "\..\"))
							Dim num8 As Integer = 0
							While num8 < CInt(directories.Length)
								Dim str29 As String = directories(num8)
								If (Path.GetFileName(str29).StartsWith("isign-")) Then
									Try
										Common.DeleteFilesFromFolder(str29)
									Catch exception4 As System.Exception
										ProjectData.SetProjectError(exception4)
										ProjectData.ClearProjectError()
									End Try
								End If
								num8 = num8 + 1
							End While
							Me.picLoading.Visible = False
							Me.lblLoading.Visible = False
							Me.lblLoading.Text = ""
							str = If(Operators.CompareString(str25, "", False) <> 0, str25, "")
						End If
					End If
				Else
					AppConst.logger.Info(String.Concat("Install::create: not have teamId: ", nSDictionary.ToXmlPropertyList()))
					str = "Not have teamId"
				End If
			Else
				AppConst.logger.Info(String.Concat("Install::create: cannot login itune: ", nSDictionary.ToXmlPropertyList()))
				str = "Cannot login itune..."
			End If
			num1 = -2
			num = num1
			Return str
			GoTo Label3
		End Function

		Private Async Function detectDevice() As Task
			Dim str As String = Nothing
			Dim str1 As String = Nothing
			Dim str2 As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinfo.exe"), "", False)
			Dim strArrays As String() = str2.Split(New Char() { Strings.ChrW(10) })
			Dim length As Integer = CInt(strArrays.Length) - 1
			Dim num As Integer = 0
			Do
				If (strArrays(num).StartsWith("UniqueDeviceID")) Then
					str1 = strArrays(num).Substring("UniqueDeviceID:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("DeviceName")) Then
					str = strArrays(num).Substring("DeviceName:".Length).Trim()
				End If
				num = num + 1
			Loop While num <= length
			Me.listDevice.Clear()
			If (Operators.CompareString(str1, "", False) <> 0 And Operators.CompareString(str, "", False) <> 0) Then
				Dim deviceInfo As Install.DeviceInfo = New Install.DeviceInfo() With
				{
					.udid = str1,
					.deviceName = str
				}
				Me.listDevice.Add(deviceInfo)
			End If
		End Function

		Public Sub DeviceInvokeMethod()
			Me.cmbDevice.Items.Clear()
			Dim count As Integer = Me.listDevice.Count - 1
			Dim num As Integer = 0
			Do
				Me.cmbDevice.Items.Add(String.Concat(Me.listDevice(num).deviceName, " - ", Me.listDevice(num).udid))
				num = num + 1
			Loop While num <= count
			If (Me.cmbDevice.Items.Count <> 0) Then
				Me.cmdInstall.Enabled = True
				If (Operators.CompareString(Me.lblLoading.Text, "Detecting device...", False) = 0) Then
					Me.picLoading.Visible = False
					Me.lblLoading.Text = ""
				End If
			Else
				Me.cmdInstall.Enabled = False
				Me.cmbDevice.Text = ""
				Me.picLoading.Visible = True
				Me.lblLoading.Visible = True
				Me.lblLoading.Text = "Detecting device..."
			End If
			If (Me.cmbDevice.Items.Count > 0) Then
				Dim count1 As Integer = Me.cmbDevice.Items.Count - 1
				Dim num1 As Integer = 0
				While num1 <= count1
					If (Not Operators.ConditionalCompareObjectEqual(Me.cmbDevice.Text, Me.cmbDevice.Items(num1), False)) Then
						num1 = num1 + 1
					Else
						Return
					End If
				End While
				Me.cmbDevice.SelectedIndex = 0
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
			Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Install))
			Me.cmbDevice = New ComboBox()
			Me.cmbAppleId = New ComboBox()
			Me.txtPassword = New TextBox()
			Me.cmdInstall = New Button()
			Me.Label1 = New Label()
			Me.Label2 = New Label()
			Me.Label3 = New Label()
			Me.chkSave = New CheckBox()
			Me.lblLoading = New Label()
			Me.picLoading = New PictureBox()
			Me.cmdClose = New Button()
			Me.Label4 = New Label()
			Me.Label5 = New Label()
			Me.txtAppName = New TextBox()
			Me.chkCloneApp = New CheckBox()
			DirectCast(Me.picLoading, ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.cmbDevice.FormattingEnabled = True
			Me.cmbDevice.Location = New Point(62, 12)
			Me.cmbDevice.Name = "cmbDevice"
			Me.cmbDevice.Size = New System.Drawing.Size(339, 21)
			Me.cmbDevice.TabIndex = 0
			Me.cmbAppleId.FormattingEnabled = True
			Me.cmbAppleId.Location = New Point(62, 48)
			Me.cmbAppleId.Name = "cmbAppleId"
			Me.cmbAppleId.Size = New System.Drawing.Size(206, 21)
			Me.cmbAppleId.TabIndex = 1
			Me.txtPassword.Location = New Point(62, 84)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.Size = New System.Drawing.Size(206, 20)
			Me.txtPassword.TabIndex = 2
			Me.txtPassword.UseSystemPasswordChar = True
			Me.cmdInstall.Location = New Point(299, 49)
			Me.cmdInstall.Name = "cmdInstall"
			Me.cmdInstall.Size = New System.Drawing.Size(75, 23)
			Me.cmdInstall.TabIndex = 3
			Me.cmdInstall.Text = "Install"
			Me.cmdInstall.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(5, 15)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(41, 13)
			Me.Label1.TabIndex = 4
			Me.Label1.Text = "Device"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Point(5, 53)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(46, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Apple Id"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Point(5, 86)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(53, 13)
			Me.Label3.TabIndex = 6
			Me.Label3.Text = "Password"
			Me.chkSave.AutoSize = True
			Me.chkSave.Checked = True
			Me.chkSave.CheckState = CheckState.Checked
			Me.chkSave.Location = New Point(62, 267)
			Me.chkSave.Name = "chkSave"
			Me.chkSave.Size = New System.Drawing.Size(123, 17)
			Me.chkSave.TabIndex = 7
			Me.chkSave.Text = "Save Account Local"
			Me.chkSave.UseVisualStyleBackColor = True
			Me.chkSave.Visible = False
			Me.lblLoading.Location = New Point(8, 231)
			Me.lblLoading.Name = "lblLoading"
			Me.lblLoading.Size = New System.Drawing.Size(393, 23)
			Me.lblLoading.TabIndex = 8
			Me.lblLoading.Text = "Loading"
			Me.lblLoading.TextAlign = ContentAlignment.MiddleCenter
			Me.lblLoading.Visible = False
			Me.picLoading.Image = DirectCast(componentResourceManager.GetObject("picLoading.Image"), Image)
			Me.picLoading.Location = New Point(177, 175)
			Me.picLoading.Name = "picLoading"
			Me.picLoading.Size = New System.Drawing.Size(59, 56)
			Me.picLoading.TabIndex = 9
			Me.picLoading.TabStop = False
			Me.picLoading.Visible = False
			Me.cmdClose.Location = New Point(299, 83)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(75, 23)
			Me.cmdClose.TabIndex = 10
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, 0)
			Me.Label4.Location = New Point(62, 110)
			Me.Label4.Name = "Label4"
			Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Me.Label4.Size = New System.Drawing.Size(261, 13)
			Me.Label4.TabIndex = 11
			Me.Label4.Text = "We only send your password to Apple Server"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Point(4, 132)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(130, 13)
			Me.Label5.TabIndex = 12
			Me.Label5.Text = "New App Name (Optional)"
			Me.txtAppName.Location = New Point(134, 131)
			Me.txtAppName.Name = "txtAppName"
			Me.txtAppName.Size = New System.Drawing.Size(134, 20)
			Me.txtAppName.TabIndex = 13
			Me.chkCloneApp.AutoSize = True
			Me.chkCloneApp.Location = New Point(301, 134)
			Me.chkCloneApp.Name = "chkCloneApp"
			Me.chkCloneApp.Size = New System.Drawing.Size(75, 17)
			Me.chkCloneApp.TabIndex = 14
			Me.chkCloneApp.Text = "Clone App"
			Me.chkCloneApp.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(401, 252)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.chkCloneApp)
			MyBase.Controls.Add(Me.txtAppName)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.picLoading)
			MyBase.Controls.Add(Me.lblLoading)
			MyBase.Controls.Add(Me.chkSave)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.cmdInstall)
			MyBase.Controls.Add(Me.txtPassword)
			MyBase.Controls.Add(Me.cmbAppleId)
			MyBase.Controls.Add(Me.cmbDevice)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "Install"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			Me.Text = "Install"
			DirectCast(Me.picLoading, ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub Install_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As Dictionary(Of String, String).Enumerator = New Dictionary(Of String, String).Enumerator()
			Me.listDevice = New List(Of Install.DeviceInfo)()
			Dim thread As System.Threading.Thread = New System.Threading.Thread(New ThreadStart(AddressOf Me.ThreadTask))
			thread.Start()
			Me.lstAcc = Database.GetAccounts()
			Try
				enumerator = Me.lstAcc.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As KeyValuePair(Of String, String) = enumerator.Current
					Me.cmbAppleId.Items.Add(current.Key)
				End While
			Finally
				DirectCast(enumerator, IDisposable).Dispose()
			End Try
		End Sub

		Public Function installFromFile(ByVal fileIpa As String, Optional ByVal cloneIds As String = "", Optional ByVal newName As String = "") As String
			Dim str As String
			Dim enumerator As IEnumerator(Of ZipEntry) = Nothing
			Try
				Directory.Delete(AppConst.m_localTmp, True)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Try
				Directory.CreateDirectory(AppConst.m_localTmp)
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				ProjectData.ClearProjectError()
			End Try
			Using zipFiles As ZipFile = ZipFile.Read(fileIpa)
				Try
					enumerator = zipFiles.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As ZipEntry = enumerator.Current
						If (current.FileName.EndsWith("Info.plist")) Then
							current.Extract(AppConst.m_localTmp, ExtractExistingFileAction.OverwriteSilently)
						End If
					End While
				Finally
					If (enumerator IsNot Nothing) Then
						enumerator.Dispose()
					End If
				End Try
			End Using
			Dim directories As String() = Directory.GetDirectories(String.Concat(AppConst.m_localTmp, "\Payload\"), "*.app")
			If (Information.LBound(directories, 1) = 0) Then
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_localTmp, "\Payload\", Path.GetFileName(directories(0)), "\Info.plist"))
				Dim nSDictionary As Claunia.PropertyList.NSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
				Install.appInfo = New AppInfos() With
				{
					.Filename = fileIpa,
					.Package = nSDictionary.ObjectForKey("CFBundleIdentifier").ToString()
				}
				Install.appInfo.Package = Regex.Replace(Install.appInfo.Package, "[^a-zA-Z.]", "")
				If (Not nSDictionary.ContainsKey("CFBundleName")) Then
					Install.appInfo.Name = "noname"
				Else
					Install.appInfo.Name = nSDictionary.ObjectForKey("CFBundleName").ToString()
				End If
				AppConst.logger.Info(String.Concat("installFromFile: pk=", Install.appInfo.Package))
				Me.picLoading.Visible = True
				Me.lblLoading.Visible = True
				Me.lblLoading.Text = "Detecting device..."
				Me.txtAppName.Text = newName
				Me.cloneID = cloneIds
				If (Not Me.cloneID.Equals("")) Then
					Me.chkCloneApp.Checked = False
				Else
					Me.chkCloneApp.Checked = False
				End If
				MyBase.ShowDialog()
				str = ""
			Else
				str = "IPA file is error"
			End If
			Return str
		End Function

		Public Sub LoadingInvokeMethod()
			Me.picLoading.Invalidate()
		End Sub

		Private Async Sub ThreadTask()
			Dim variable As Install.VB$StateMachine_76_ThreadTask = Nothing
			AsyncVoidMethodBuilder.Create().Start(Of Install.VB$StateMachine_76_ThreadTask)(variable)
		End Sub

		Private Class DeviceInfo
			Public udid As String

			Public deviceName As String

			Public Sub New()
				MyBase.New()
				Me.udid = ""
				Me.deviceName = ""
			End Sub
		End Class

		Public Delegate Sub DeviceInvokeDelegate()

		Public Delegate Sub LoadingInvokeDelegate()
	End Class
End Namespace