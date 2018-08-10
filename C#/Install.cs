using Claunia.PropertyList;
using Ionic.Zip;
using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class Install : Form
	{
		private IContainer components;

		private Thread trd;

		public static AppInfos appInfo;

		private string statusRs;

		private string appId;

		private bool isExit;

		private Dictionary<string, string> lstAcc;

		private List<Install.DeviceInfo> listDevice;

		private string cloneID;

		internal virtual CheckBox chkCloneApp
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual CheckBox chkSave
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ComboBox cmbAppleId
		{
			get
			{
				stackVariable1 = this._cmbAppleId;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmbAppleId_SelectedIndexChanged);
				ComboBox comboBox = this._cmbAppleId;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._cmbAppleId = value;
				comboBox = this._cmbAppleId;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		internal virtual ComboBox cmbDevice
		{
			get
			{
				stackVariable1 = this._cmbDevice;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmbDevice_TextChanged);
				ComboBox comboBox = this._cmbDevice;
				if (comboBox != null)
				{
					comboBox.TextChanged -= eventHandler;
				}
				this._cmbDevice = value;
				comboBox = this._cmbDevice;
				if (comboBox != null)
				{
					comboBox.TextChanged += eventHandler;
				}
			}
		}

		internal virtual Button cmdClose
		{
			get
			{
				stackVariable1 = this._cmdClose;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdClose_Click);
				Button button = this._cmdClose;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdClose = value;
				button = this._cmdClose;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdInstall
		{
			get
			{
				stackVariable1 = this._cmdInstall;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdInstall_Click);
				Button button = this._cmdInstall;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdInstall = value;
				button = this._cmdInstall;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Label Label1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label2
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label3
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label4
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label5
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblLoading
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox picLoading
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtAppName
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtPassword
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public Install()
		{
			base.Load += new EventHandler(this.Install_Load);
			this.InitializeComponent();
		}

		private void cmbAppleId_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txtPassword.Text = this.lstAcc[this.cmbAppleId.Text];
		}

		private void cmbDevice_TextChanged(object sender, EventArgs e)
		{
			string str = null;
			string str1;
			if (this.cmbDevice.Text.Length > 40)
			{
				string str2 = this.cmbDevice.Text.Substring(checked(this.cmbDevice.Text.Length - 40));
				str1 = (!this.cloneID.Equals("") ? Database.getInstalledApp(string.Concat("clone", this.cloneID, ".", Install.appInfo.Package), str2, ref str) : Database.getInstalledApp(Install.appInfo.Package, str2, ref str));
				if (Operators.CompareString(str1, "", false) != 0)
				{
					this.cmbAppleId.Text = str1;
				}
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.isExit = true;
			base.Close();
		}

		private async void cmdInstall_Click(object sender, EventArgs e)
		{
			Install.VB$StateMachine_82_cmdInstall_Click variable = null;
			AsyncVoidMethodBuilder.Create().Start<Install.VB$StateMachine_82_cmdInstall_Click>(ref variable);
		}

		public async Task<string> Create(string appleId, string password, string udid, string deviceName, string machineName, string machineId, string ipaOrgFile, bool isClone = false)
		{
			string str;
			int num;
			string str1;
			int num1;
			string str2;
			string str3 = null;
			string str4;
			if (!isClone)
			{
				str2 = this.cloneID;
				if (!str2.Equals(""))
				{
					isClone = true;
				}
			}
			else
			{
				TimeSpan now = DateTime.Now - new DateTime(1970, 1, 1);
				str2 = Common.GetHash(Conversions.ToString(now.TotalMilliseconds)).Substring(25);
			}
			string str5 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Operators.AddObject(string.Concat("si.", Common.GetHash(Microsoft.VisualBasic.Strings.Trim(appleId)), "."), Interaction.IIf(isClone, string.Concat("clone", str2, "."), "")), Regex.Replace(Install.appInfo.Package, "[^a-zA-Z.]", ""))));
			string str6 = Regex.Replace(string.Concat("SI - ", Install.appInfo.Name), "[^a-zA-Z ]", "");
			ILog log = AppConst.logger;
			string[] strArrays = new string[] { "Install::create: ", deviceName, ",", machineName, ",", machineId, ",", ipaOrgFile, "    id=", str5, ",", str6 };
			log.Info(string.Concat(strArrays));
			int num2 = 9;
			this.lblLoading.Text = string.Concat("[1/", Conversions.ToString(num2), "] Login...");
			Application.DoEvents();
			NSDictionary nSDictionary = AppleService.login(appleId, password);
			if (nSDictionary.ContainsKey("myacinfo"))
			{
				string str7 = nSDictionary.ObjectForKey("myacinfo").ToString();
				this.lblLoading.Text = string.Concat("[2/", Conversions.ToString(num2), "] Get team...");
				Application.DoEvents();
				nSDictionary = AppleService.listTeam(str7);
				string str8 = "";
				if (nSDictionary.ContainsKey("teams"))
				{
					NSArray nSArray = (NSArray)nSDictionary.ObjectForKey("teams");
					if (nSArray.get_Count() > 0)
					{
						NSDictionary nSDictionary1 = (NSDictionary)nSArray.ElementAt<NSObject>(0);
						if (nSDictionary1.ContainsKey("teamId"))
						{
							str8 = nSDictionary1.ObjectForKey("teamId").ToString();
						}
					}
				}
				if (Operators.CompareString(str8, "", false) != 0)
				{
					this.lblLoading.Text = string.Concat("[3/", Conversions.ToString(num2), "] Get devices...");
					Application.DoEvents();
					nSDictionary = AppleService.listDevices(str8);
					bool flag = false;
					if (nSDictionary.ContainsKey("devices"))
					{
						NSArray nSArray1 = (NSArray)nSDictionary.ObjectForKey("devices");
						if (nSArray1.get_Count() > 0)
						{
							int count = checked(nSArray1.get_Count() - 1);
							for (int i = 0; i <= count; i = checked(i + 1))
							{
								NSDictionary nSDictionary2 = (NSDictionary)nSArray1.ElementAt<NSObject>(i);
								if (nSDictionary2.ContainsKey("deviceNumber"))
								{
									if (Operators.CompareString(udid, nSDictionary2.ObjectForKey("deviceNumber").ToString(), false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
					}
					if (!flag)
					{
						this.lblLoading.Text = string.Concat("[3+/", Conversions.ToString(num2), "] Add device...");
						Application.DoEvents();
						nSDictionary = AppleService.addDevice(udid, deviceName, str8);
						flag = false;
						if (nSDictionary.ContainsKey("devices"))
						{
							NSArray nSArray2 = (NSArray)nSDictionary.ObjectForKey("devices");
							if (nSArray2.get_Count() > 0)
							{
								int count1 = checked(nSArray2.get_Count() - 1);
								for (int j = 0; j <= count1; j = checked(j + 1))
								{
									NSDictionary nSDictionary3 = (NSDictionary)nSArray2.ElementAt<NSObject>(j);
									if (nSDictionary3.ContainsKey("deviceNumber"))
									{
										if (Operators.CompareString(udid, nSDictionary3.ObjectForKey("deviceNumber").ToString(), false) == 0)
										{
											flag = true;
											break;
										}
									}
								}
							}
						}
						else if (nSDictionary.ContainsKey("device"))
						{
							NSDictionary nSDictionary4 = (NSDictionary)nSDictionary.ObjectForKey("device");
							if (nSDictionary4.ContainsKey("deviceNumber"))
							{
								if (Operators.CompareString(udid, nSDictionary4.ObjectForKey("deviceNumber").ToString(), false) == 0)
								{
									flag = true;
								}
							}
						}
						if (!flag)
						{
							AppConst.logger.Info(string.Concat("Install::create: cannot add device ", nSDictionary.ToXmlPropertyList()));
							if (!nSDictionary.ContainsKey("userString"))
							{
								str = "Cannot add device";
								num1 = -2;
								num = num1;
								return str;
							}
							else
							{
								str = string.Concat("Cannot add device: ", nSDictionary.ObjectForKey("userString").ToString());
								num1 = -2;
								num = num1;
								return str;
							}
						}
					}
					this.lblLoading.Text = string.Concat("[4/", Conversions.ToString(num2), "] Get certs...");
					Application.DoEvents();
					nSDictionary = AppleService.allDevelopmentCert(str8);
					AppConst.logger.Info(string.Concat("Install::create: all certs: ", nSDictionary.ToXmlPropertyList()));
					string base64String = "";
					if (nSDictionary.ContainsKey("certificates"))
					{
						NSArray nSArray3 = (NSArray)nSDictionary.ObjectForKey("certificates");
						int count2 = checked(nSArray3.get_Count() - 1);
						for (int k = 0; k <= count2; k = checked(k + 1))
						{
							NSDictionary nSDictionary5 = (NSDictionary)nSArray3.ElementAt<NSObject>(k);
							if (nSDictionary5.ContainsKey("certContent") & nSDictionary5.ContainsKey("machineName"))
							{
								string str9 = nSDictionary5.ObjectForKey("machineName").ToString();
								if (Operators.CompareString(str9, machineName, false) == 0)
								{
									str3 = nSDictionary5.ObjectForKey("serialNumber").ToString();
									base64String = Convert.ToBase64String(((NSData)nSDictionary5.ObjectForKey("certContent")).get_Bytes());
								}
							}
						}
					}
					string str10 = string.Concat(AppConst.m_rootPath, "\\certs\\", Common.GetHash(appleId));
					string str11 = string.Concat(str10, "\\ios.key");
					string str12 = string.Concat(str10, "\\private.pem");
					string str13 = string.Concat(str10, "\\ios.csr");
					string str14 = string.Concat(str10, "\\ios.cer");
					string str15 = string.Concat(str10, "\\ioscer.pem");
					string str16 = string.Concat(str10, "\\ios.mobileprovision");
					if (Operators.CompareString(base64String, "", false) != 0)
					{
						if (Directory.Exists(str10))
						{
							if (!File.Exists(str12) | !File.Exists(str11) | !File.Exists(str13))
							{
								goto Label3;
							}
							goto Label1;
						}
						else
						{
							AppleService.revokeCertificate(str3, str8);
						}
					}
				Label3:
					if (!Directory.Exists(str10))
					{
						Directory.CreateDirectory(str10);
					}
					str1 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe"), string.Concat("genrsa -des3 -passout pass:12345 -out \"", str11, "\" 2048"), false);
					string str17 = str1;
					string str18 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] strArrays1 = new string[] { "rsa -in \"", str11, "\" -passin pass:12345 -out \"", str12, "\" -outform PEM" };
					str1 = await Common.RunExe(str18, string.Concat(strArrays1), false);
					str17 = str1;
					string str19 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] mRootPath = new string[] { "req -new -key \"", str11, "\" -passin pass:12345 -out \"", str13, "\" -subj \"/emailAddress=noname@superimpactor.com, CN=SuperImpactor, C=VN\" -config \"", AppConst.m_rootPath, "\\openssl\\bin\\openssl.cfg\"" };
					str1 = await Common.RunExe(str19, string.Concat(mRootPath), false);
					str17 = str1;
					File.ReadAllText(str12);
					string str20 = File.ReadAllText(str13);
					this.lblLoading.Text = string.Concat("[4+/", Conversions.ToString(num2), "] Add cert...");
					Application.DoEvents();
					nSDictionary = AppleService.addDevelopmentCert(str20, machineName, machineId, str8);
					AppConst.logger.Info(string.Concat("Install::create: add cert: ", nSDictionary.ToXmlPropertyList()));
					nSDictionary = AppleService.allDevelopmentCert(str8);
					AppConst.logger.Info(string.Concat("Install::create: all certs after added: ", nSDictionary.ToXmlPropertyList()));
					if (nSDictionary.ContainsKey("certificates"))
					{
						NSArray nSArray4 = (NSArray)nSDictionary.ObjectForKey("certificates");
						int count3 = checked(nSArray4.get_Count() - 1);
						for (int l = 0; l <= count3; l = checked(l + 1))
						{
							NSDictionary nSDictionary6 = (NSDictionary)nSArray4.ElementAt<NSObject>(l);
							if (nSDictionary6.ContainsKey("certContent") & nSDictionary6.ContainsKey("machineName"))
							{
								string str21 = nSDictionary6.ObjectForKey("machineName").ToString();
								if (Operators.CompareString(str21, machineName, false) == 0)
								{
									base64String = Convert.ToBase64String(((NSData)nSDictionary6.ObjectForKey("certContent")).get_Bytes());
								}
							}
						}
					}
					if (Operators.CompareString(base64String, "", false) == 0)
					{
						str = "Cannot create cert. Please Revoke the existing one!";
						num1 = -2;
						num = num1;
						return str;
					}
				Label1:
					File.WriteAllBytes(str14, Convert.FromBase64String(base64String));
					string str22 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] strArrays2 = new string[] { "x509 -in \"", str14, "\" -inform DER -out \"", str15, "\" -outform PEM" };
					await Common.RunExe(str22, string.Concat(strArrays2), false);
					this.lblLoading.Text = string.Concat("[5/", Conversions.ToString(num2), "] Get AppID...");
					Application.DoEvents();
					nSDictionary = AppleService.appIds(str8);
					AppConst.logger.Info(string.Concat("Install::create: all appIds: ", nSDictionary.ToXmlPropertyList()));
					string str23 = "";
					if (nSDictionary.ContainsKey("appIds"))
					{
						NSArray nSArray5 = (NSArray)nSDictionary.ObjectForKey("appIds");
						if (nSArray5.get_Count() > 0)
						{
							int num3 = checked(nSArray5.get_Count() - 1);
							for (int m = 0; m <= num3; m = checked(m + 1))
							{
								NSDictionary nSDictionary7 = (NSDictionary)nSArray5.ElementAt<NSObject>(m);
								if (nSDictionary7.ContainsKey("identifier") & Operators.CompareString(nSDictionary7.ObjectForKey("identifier").ToString(), str5, false) == 0)
								{
									str23 = nSDictionary7.ObjectForKey("appIdId").ToString();
								}
							}
						}
						if (Operators.CompareString(str23, "", false) == 0 & nSArray5.get_Count() >= 10)
						{
							str = "Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days";
							num1 = -2;
							num = num1;
							return str;
						}
					}
					if (Operators.CompareString(str23, "", false) == 0)
					{
						this.lblLoading.Text = string.Concat("[5+/", Conversions.ToString(num2), "] add AppID...");
						Application.DoEvents();
						nSDictionary = AppleService.addAppId(str6, str5, str8);
						if (!nSDictionary.ContainsKey("appId"))
						{
							AppConst.logger.Info(string.Concat("Install::create: add appId failed: ", nSDictionary.ToXmlPropertyList()));
							if (!nSDictionary.ContainsKey("userString"))
							{
								str = "Cannot create App ID. It seem you use other Apple Id to install this app before. Please remove that AppId from menu Tool->Delete AppIds then try again";
								num1 = -2;
								num = num1;
								return str;
							}
							else
							{
								str = string.Concat("Cannot create App ID: ", nSDictionary.ObjectForKey("userString").ToString());
								num1 = -2;
								num = num1;
								return str;
							}
						}
						else
						{
							NSDictionary nSDictionary8 = (NSDictionary)nSDictionary.ObjectForKey("appId");
							str23 = nSDictionary8.ObjectForKey("appIdId").ToString();
						}
					}
					string fileName = Path.GetFileName(ipaOrgFile);
					Database.updateInstalledApp(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Interaction.IIf(isClone, string.Concat("clone", str2, "."), ""), Install.appInfo.Package))), appleId, fileName, udid);
					try
					{
						File.Copy(ipaOrgFile, string.Concat(AppConst.m_rootPath, "/\\download\\/", fileName), true);
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
					}
					this.lblLoading.Text = string.Concat("[6/", Conversions.ToString(num2), "] Get provision...");
					Application.DoEvents();
					nSDictionary = AppleService.downloadProvisionProfile(str23, str8);
					AppConst.logger.Info(string.Concat("Install::create: provision: ", nSDictionary.ToXmlPropertyList()));
					if (!nSDictionary.ContainsKey("provisioningProfile"))
					{
						str = "Cannot get provision";
					}
					else
					{
						NSDictionary nSDictionary9 = (NSDictionary)nSDictionary.ObjectForKey("provisioningProfile");
						if (!nSDictionary9.ContainsKey("encodedProfile"))
						{
							str = "Cannot get provision";
						}
						else
						{
							byte[] bytes = ((NSData)nSDictionary9.ObjectForKey("encodedProfile")).get_Bytes();
							File.WriteAllBytes(str16, bytes);
							AppConst.logger.Info("Install::create: start sign");
							string tempFolder = Common.GetTempFolder();
							try
							{
								Directory.Delete(tempFolder, true);
							}
							catch (Exception exception1)
							{
								ProjectData.SetProjectError(exception1);
								ProjectData.ClearProjectError();
							}
							Application.DoEvents();
							Common.Unzip(string.Concat(AppConst.m_rootPath, "data"), tempFolder, "ABCDEF$%^&abcdef12345");
							Application.DoEvents();
							Common.Unzip(string.Concat(tempFolder, "\\data"), tempFolder, "");
							Application.DoEvents();
							Directory.SetCurrentDirectory(string.Concat(tempFolder, "\\scripts\\"));
							this.lblLoading.Text = string.Concat("[7/", Conversions.ToString(num2), "] Sign...");
							Application.DoEvents();
							if (!this.txtAppName.Text.Equals(""))
							{
								string[] text = new string[] { "isign -i CFBundleIdentifier=", str5, ",CFBundleDisplayName=\"", this.txtAppName.Text, "\" -c \"", str15, "\" -k \"", str12, "\" -p \"", str16, "\" -o superimpact.ipa \"", ipaOrgFile, "\"" };
								str4 = string.Concat(text);
							}
							else
							{
								string[] strArrays3 = new string[] { "isign -i CFBundleIdentifier=", str5, " -c \"", str15, "\" -k \"", str12, "\" -p \"", str16, "\" -o superimpact.ipa \"", ipaOrgFile, "\"" };
								str4 = string.Concat(strArrays3);
							}
							str1 = await Common.RunExe("..\\python.exe", str4, false);
							string str24 = str1;
							string str25 = "";
							if (!File.Exists("superimpact.ipa"))
							{
								AppConst.logger.Info(string.Concat("Install::create: sign app failed: ", str24));
								str25 = "Sign failed";
							}
							else
							{
								this.lblLoading.Text = string.Concat("[8/", Conversions.ToString(num2), "] Install...");
								Application.DoEvents();
								string str26 = string.Concat(AppConst.m_rootPath, "\\certs\\\\pr\\", udid);
								try
								{
									Directory.CreateDirectory(str26);
								}
								catch (Exception exception2)
								{
									ProjectData.SetProjectError(exception2);
									ProjectData.ClearProjectError();
								}
								str1 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("copy \"", str26, "\""), false);
								str24 = str1;
								str1 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), "remove-all", false);
								str24 = str1;
								str1 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinstaller.exe"), string.Concat("-u ", udid, " -i superimpact.ipa"), true);
								str24 = str1;
								Debug.Print(string.Concat("install output=", str24));
								AppConst.logger.Info(string.Concat("Install output: ", str24));
								string str27 = "";
								if (str24.IndexOf("ERROR:", StringComparison.Ordinal) > 0)
								{
									str27 = str24.Substring(str24.IndexOf("ERROR:", StringComparison.Ordinal));
								}
								else if (str24.IndexOf("error", StringComparison.Ordinal) > 0)
								{
									str27 = str24.Substring(str24.IndexOf("error", StringComparison.Ordinal));
								}
								else if (str24.IndexOf("No iOS device found", StringComparison.Ordinal) > 0)
								{
									str27 = str24.Substring(str24.IndexOf("No iOS device found", StringComparison.Ordinal));
								}
								if (!str27.Equals(""))
								{
									AppConst.logger.Info(string.Concat("Install::create: install app failed: ", str27));
									str25 = string.Concat("Install failed!: \r\n", str27);
								}
								this.lblLoading.Text = string.Concat("[9/", Conversions.ToString(num2), "] Few seconds for finishing...");
								Application.DoEvents();
								string[] files = Directory.GetFiles(str26);
								int num4 = Information.UBound(files, 1);
								for (int n = 0; n <= num4; n = checked(n + 1))
								{
									if (Operators.CompareString(Path.GetExtension(files[n]).ToLower(), ".mobileprovision", false) == 0)
									{
										string[] strArrays4 = File.ReadAllLines(files[n]);
										bool flag1 = false;
										int num5 = Information.LBound(strArrays4, 1);
										int num6 = Information.UBound(strArrays4, 1);
										for (int o = num5; o <= num6; o = checked(o + 1))
										{
											if (strArrays4[o].IndexOf("<key>ExpirationDate</key>") >= 0)
											{
												string str28 = strArrays4[checked(o + 1)].Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim();
												DateTime dateTime = DateTime.ParseExact(str28, "yyyy-MM-dd HH:mm:ss", null);
												if (DateTime.Compare(dateTime, DateTime.Now) < 0)
												{
													flag1 = true;
													break;
												}
											}
										}
										if (!flag1)
										{
											str1 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("install \"", files[n], "\""), false);
											str24 = str1;
										}
										else
										{
											File.Delete(files[n]);
										}
										Application.DoEvents();
									}
								}
							}
							Directory.SetCurrentDirectory(string.Concat(tempFolder, "\\..\\"));
							Common.DeleteFilesFromFolder(tempFolder);
							try
							{
								Directory.Delete(AppConst.m_localTmp, true);
							}
							catch (Exception exception3)
							{
								ProjectData.SetProjectError(exception3);
								ProjectData.ClearProjectError();
							}
							string[] directories = Directory.GetDirectories(string.Concat(tempFolder, "\\..\\"));
							for (int p = 0; p < (int)directories.Length; p = checked(p + 1))
							{
								string str29 = directories[p];
								if (Path.GetFileName(str29).StartsWith("isign-"))
								{
									try
									{
										Common.DeleteFilesFromFolder(str29);
									}
									catch (Exception exception4)
									{
										ProjectData.SetProjectError(exception4);
										ProjectData.ClearProjectError();
									}
								}
							}
							this.picLoading.Visible = false;
							this.lblLoading.Visible = false;
							this.lblLoading.Text = "";
							str = (Operators.CompareString(str25, "", false) != 0 ? str25 : "");
						}
					}
				}
				else
				{
					AppConst.logger.Info(string.Concat("Install::create: not have teamId: ", nSDictionary.ToXmlPropertyList()));
					str = "Not have teamId";
				}
			}
			else
			{
				AppConst.logger.Info(string.Concat("Install::create: cannot login itune: ", nSDictionary.ToXmlPropertyList()));
				str = "Cannot login itune...";
			}
			num1 = -2;
			num = num1;
			return str;
			goto Label3;
		}

		private async Task detectDevice()
		{
			string str = null;
			string str1 = null;
			string str2 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinfo.exe"), "", false);
			string[] strArrays = str2.Split(new char[] { '\n' });
			int length = checked((int)strArrays.Length - 1);
			for (int i = 0; i <= length; i = checked(i + 1))
			{
				if (strArrays[i].StartsWith("UniqueDeviceID"))
				{
					str1 = strArrays[i].Substring("UniqueDeviceID:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("DeviceName"))
				{
					str = strArrays[i].Substring("DeviceName:".Length).Trim();
				}
			}
			this.listDevice.Clear();
			if (Operators.CompareString(str1, "", false) != 0 & Operators.CompareString(str, "", false) != 0)
			{
				Install.DeviceInfo deviceInfo = new Install.DeviceInfo()
				{
					udid = str1,
					deviceName = str
				};
				this.listDevice.Add(deviceInfo);
			}
		}

		public void DeviceInvokeMethod()
		{
			this.cmbDevice.Items.Clear();
			int count = checked(this.listDevice.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				this.cmbDevice.Items.Add(string.Concat(this.listDevice[i].deviceName, " - ", this.listDevice[i].udid));
			}
			if (this.cmbDevice.Items.Count != 0)
			{
				this.cmdInstall.Enabled = true;
				if (Operators.CompareString(this.lblLoading.Text, "Detecting device...", false) == 0)
				{
					this.picLoading.Visible = false;
					this.lblLoading.Text = "";
				}
			}
			else
			{
				this.cmdInstall.Enabled = false;
				this.cmbDevice.Text = "";
				this.picLoading.Visible = true;
				this.lblLoading.Visible = true;
				this.lblLoading.Text = "Detecting device...";
			}
			if (this.cmbDevice.Items.Count > 0)
			{
				int num = checked(this.cmbDevice.Items.Count - 1);
				int num1 = 0;
				while (num1 <= num)
				{
					if (!Operators.ConditionalCompareObjectEqual(this.cmbDevice.Text, this.cmbDevice.Items[num1], false))
					{
						num1 = checked(num1 + 1);
					}
					else
					{
						return;
					}
				}
				this.cmbDevice.SelectedIndex = 0;
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if ((!disposing ? false : this.components != null))
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Install));
			this.cmbDevice = new ComboBox();
			this.cmbAppleId = new ComboBox();
			this.txtPassword = new TextBox();
			this.cmdInstall = new Button();
			this.Label1 = new Label();
			this.Label2 = new Label();
			this.Label3 = new Label();
			this.chkSave = new CheckBox();
			this.lblLoading = new Label();
			this.picLoading = new PictureBox();
			this.cmdClose = new Button();
			this.Label4 = new Label();
			this.Label5 = new Label();
			this.txtAppName = new TextBox();
			this.chkCloneApp = new CheckBox();
			((ISupportInitialize)this.picLoading).BeginInit();
			base.SuspendLayout();
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new Point(62, 12);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new System.Drawing.Size(339, 21);
			this.cmbDevice.TabIndex = 0;
			this.cmbAppleId.FormattingEnabled = true;
			this.cmbAppleId.Location = new Point(62, 48);
			this.cmbAppleId.Name = "cmbAppleId";
			this.cmbAppleId.Size = new System.Drawing.Size(206, 21);
			this.cmbAppleId.TabIndex = 1;
			this.txtPassword.Location = new Point(62, 84);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(206, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.UseSystemPasswordChar = true;
			this.cmdInstall.Location = new Point(299, 49);
			this.cmdInstall.Name = "cmdInstall";
			this.cmdInstall.Size = new System.Drawing.Size(75, 23);
			this.cmdInstall.TabIndex = 3;
			this.cmdInstall.Text = "Install";
			this.cmdInstall.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(5, 15);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(41, 13);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Device";
			this.Label2.AutoSize = true;
			this.Label2.Location = new Point(5, 53);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(46, 13);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Apple Id";
			this.Label3.AutoSize = true;
			this.Label3.Location = new Point(5, 86);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(53, 13);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Password";
			this.chkSave.AutoSize = true;
			this.chkSave.Checked = true;
			this.chkSave.CheckState = CheckState.Checked;
			this.chkSave.Location = new Point(62, 267);
			this.chkSave.Name = "chkSave";
			this.chkSave.Size = new System.Drawing.Size(123, 17);
			this.chkSave.TabIndex = 7;
			this.chkSave.Text = "Save Account Local";
			this.chkSave.UseVisualStyleBackColor = true;
			this.chkSave.Visible = false;
			this.lblLoading.Location = new Point(8, 231);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(393, 23);
			this.lblLoading.TabIndex = 8;
			this.lblLoading.Text = "Loading";
			this.lblLoading.TextAlign = ContentAlignment.MiddleCenter;
			this.lblLoading.Visible = false;
			this.picLoading.Image = (Image)componentResourceManager.GetObject("picLoading.Image");
			this.picLoading.Location = new Point(177, 175);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(59, 56);
			this.picLoading.TabIndex = 9;
			this.picLoading.TabStop = false;
			this.picLoading.Visible = false;
			this.cmdClose.Location = new Point(299, 83);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 10;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.Label4.Location = new Point(62, 110);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Label4.Size = new System.Drawing.Size(261, 13);
			this.Label4.TabIndex = 11;
			this.Label4.Text = "We only send your password to Apple Server";
			this.Label5.AutoSize = true;
			this.Label5.Location = new Point(4, 132);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(130, 13);
			this.Label5.TabIndex = 12;
			this.Label5.Text = "New App Name (Optional)";
			this.txtAppName.Location = new Point(134, 131);
			this.txtAppName.Name = "txtAppName";
			this.txtAppName.Size = new System.Drawing.Size(134, 20);
			this.txtAppName.TabIndex = 13;
			this.chkCloneApp.AutoSize = true;
			this.chkCloneApp.Location = new Point(301, 134);
			this.chkCloneApp.Name = "chkCloneApp";
			this.chkCloneApp.Size = new System.Drawing.Size(75, 17);
			this.chkCloneApp.TabIndex = 14;
			this.chkCloneApp.Text = "Clone App";
			this.chkCloneApp.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(401, 252);
			base.ControlBox = false;
			base.Controls.Add(this.chkCloneApp);
			base.Controls.Add(this.txtAppName);
			base.Controls.Add(this.Label5);
			base.Controls.Add(this.Label4);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.picLoading);
			base.Controls.Add(this.lblLoading);
			base.Controls.Add(this.chkSave);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.cmdInstall);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.cmbAppleId);
			base.Controls.Add(this.cmbDevice);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Install";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Install";
			((ISupportInitialize)this.picLoading).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void Install_Load(object sender, EventArgs e)
		{
			Dictionary<string, string>.Enumerator enumerator = new Dictionary<string, string>.Enumerator();
			this.listDevice = new List<Install.DeviceInfo>();
			(new Thread(new ThreadStart(this.ThreadTask))).Start();
			this.lstAcc = Database.GetAccounts();
			try
			{
				enumerator = this.lstAcc.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					this.cmbAppleId.Items.Add(current.Key);
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		public string installFromFile(string fileIpa, string cloneIds = "", string newName = "")
		{
			string str;
			IEnumerator<ZipEntry> enumerator = null;
			try
			{
				Directory.Delete(AppConst.m_localTmp, true);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
			try
			{
				Directory.CreateDirectory(AppConst.m_localTmp);
			}
			catch (Exception exception1)
			{
				ProjectData.SetProjectError(exception1);
				ProjectData.ClearProjectError();
			}
			using (ZipFile zipFiles = ZipFile.Read(fileIpa))
			{
				try
				{
					enumerator = zipFiles.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ZipEntry current = enumerator.Current;
						if (current.FileName.EndsWith("Info.plist"))
						{
							current.Extract(AppConst.m_localTmp, ExtractExistingFileAction.OverwriteSilently);
						}
					}
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			string[] directories = Directory.GetDirectories(string.Concat(AppConst.m_localTmp, "\\Payload\\"), "*.app");
			if (Information.LBound(directories, 1) == 0)
			{
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_localTmp, "\\Payload\\", Path.GetFileName(directories[0]), "\\Info.plist"));
				NSDictionary nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
				Install.appInfo = new AppInfos()
				{
					Filename = fileIpa,
					Package = nSDictionary.ObjectForKey("CFBundleIdentifier").ToString()
				};
				Install.appInfo.Package = Regex.Replace(Install.appInfo.Package, "[^a-zA-Z.]", "");
				if (!nSDictionary.ContainsKey("CFBundleName"))
				{
					Install.appInfo.Name = "noname";
				}
				else
				{
					Install.appInfo.Name = nSDictionary.ObjectForKey("CFBundleName").ToString();
				}
				AppConst.logger.Info(string.Concat("installFromFile: pk=", Install.appInfo.Package));
				this.picLoading.Visible = true;
				this.lblLoading.Visible = true;
				this.lblLoading.Text = "Detecting device...";
				this.txtAppName.Text = newName;
				this.cloneID = cloneIds;
				if (!this.cloneID.Equals(""))
				{
					this.chkCloneApp.Checked = false;
				}
				else
				{
					this.chkCloneApp.Checked = false;
				}
				base.ShowDialog();
				str = "";
			}
			else
			{
				str = "IPA file is error";
			}
			return str;
		}

		public void LoadingInvokeMethod()
		{
			this.picLoading.Invalidate();
		}

		private async void ThreadTask()
		{
			Install.VB$StateMachine_76_ThreadTask variable = null;
			AsyncVoidMethodBuilder.Create().Start<Install.VB$StateMachine_76_ThreadTask>(ref variable);
		}

		private class DeviceInfo
		{
			public string udid;

			public string deviceName;

			public DeviceInfo()
			{
				this.udid = "";
				this.deviceName = "";
			}
		}

		public delegate void DeviceInvokeDelegate();

		public delegate void LoadingInvokeDelegate();
	}
}