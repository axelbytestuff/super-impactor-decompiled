using Claunia.PropertyList;
using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class AutoResign : Form
	{
		private IContainer components;

		private List<AppInfosResign> lstAppInfo;

		private string udid;

		private string deviceName;

		private string machineName;

		private string machineId;

		private bool isRunning;

		internal virtual BackgroundWorker BackgroundWorker1
		{
			get
			{
				stackVariable1 = this._BackgroundWorker1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DoWorkEventHandler doWorkEventHandler = new DoWorkEventHandler(this.BackgroundWorker1_DoWork);
				BackgroundWorker backgroundWorker = this._BackgroundWorker1;
				if (backgroundWorker != null)
				{
					backgroundWorker.DoWork -= doWorkEventHandler;
				}
				this._BackgroundWorker1 = value;
				backgroundWorker = this._BackgroundWorker1;
				if (backgroundWorker != null)
				{
					backgroundWorker.DoWork += doWorkEventHandler;
				}
			}
		}

		internal virtual Button cmdCancel
		{
			get
			{
				stackVariable1 = this._cmdCancel;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdCancel_Click);
				Button button = this._cmdCancel;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdCancel = value;
				button = this._cmdCancel;
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

		internal virtual Label lblAppName
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblFile
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblNo
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ListBox lstStatus
		{
			get
			{
				stackVariable1 = this._lstStatus;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lstStatus_SelectedIndexChanged);
				ListBox listBox = this._lstStatus;
				if (listBox != null)
				{
					listBox.SelectedIndexChanged -= eventHandler;
				}
				this._lstStatus = value;
				listBox = this._lstStatus;
				if (listBox != null)
				{
					listBox.SelectedIndexChanged += eventHandler;
				}
			}
		}

		internal virtual PictureBox picLoading
		{
			get
			{
				stackVariable1 = this._picLoading;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picLoading_Click);
				PictureBox pictureBox = this._picLoading;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picLoading = value;
				pictureBox = this._picLoading;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		public AutoResign()
		{
			base.Load += new EventHandler(this.AutoResign_Load);
			base.Closing += new CancelEventHandler(this.AutoResign_Closing);
			this.isRunning = false;
			this.InitializeComponent();
		}

		private void AddLog(string log)
		{
			this.lstStatus.Items.Add(log);
			AppConst.logger.Debug(string.Concat("Resign all: ", log));
		}

		private void AutoResign_Closing(object sender, CancelEventArgs e)
		{
			if (this.isRunning)
			{
				this.cmdCancel_Click(RuntimeHelpers.GetObjectValue(sender), e);
				e.Cancel = true;
			}
		}

		private void AutoResign_Load(object sender, EventArgs e)
		{
		}

		private async void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			AutoResign.VB$StateMachine_50_BackgroundWorker1_DoWork variable = null;
			AsyncVoidMethodBuilder.Create().Start<AutoResign.VB$StateMachine_50_BackgroundWorker1_DoWork>(ref variable);
		}

		private void ChangeTexts(string no, AppInfosResign appInf)
		{
			this.lblNo.Text = string.Concat("Processing No.: ", no);
			this.lblAppName.Text = string.Concat("App name: ", appInf.Name);
			this.lblFile.Text = string.Concat("IPA file: ", appInf.Filename);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			if (!this.isRunning)
			{
				base.Close();
			}
			else
			{
				this.BackgroundWorker1.CancelAsync();
				this.cmdCancel.Text = "Waiting...";
				this.cmdCancel.Enabled = false;
			}
		}

		private void Complete(bool cancelled)
		{
			this.isRunning = false;
			if (!cancelled)
			{
				this.lstStatus.Items.Add("Complete");
				this.picLoading.Visible = false;
				this.cmdCancel.Visible = false;
			}
			else
			{
				base.Close();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AutoResign));
			this.lstStatus = new ListBox();
			this.cmdCancel = new Button();
			this.Label1 = new Label();
			this.lblNo = new Label();
			this.lblAppName = new Label();
			this.lblFile = new Label();
			this.picLoading = new PictureBox();
			this.BackgroundWorker1 = new BackgroundWorker();
			((ISupportInitialize)this.picLoading).BeginInit();
			base.SuspendLayout();
			this.lstStatus.FormattingEnabled = true;
			this.lstStatus.Location = new Point(4, 102);
			this.lstStatus.Name = "lstStatus";
			this.lstStatus.Size = new System.Drawing.Size(495, 173);
			this.lstStatus.TabIndex = 0;
			this.cmdCancel.Location = new Point(417, 27);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(4, 83);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(37, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Status";
			this.lblNo.AutoSize = true;
			this.lblNo.Location = new Point(86, 9);
			this.lblNo.Name = "lblNo";
			this.lblNo.Size = new System.Drawing.Size(79, 13);
			this.lblNo.TabIndex = 3;
			this.lblNo.Text = "Processing No.";
			this.lblAppName.AutoSize = true;
			this.lblAppName.Location = new Point(86, 34);
			this.lblAppName.Name = "lblAppName";
			this.lblAppName.Size = new System.Drawing.Size(0, 13);
			this.lblAppName.TabIndex = 5;
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new Point(86, 59);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(0, 13);
			this.lblFile.TabIndex = 6;
			this.picLoading.Image = (Image)componentResourceManager.GetObject("picLoading.Image");
			this.picLoading.Location = new Point(14, 12);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(59, 56);
			this.picLoading.TabIndex = 10;
			this.picLoading.TabStop = false;
			this.picLoading.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(504, 279);
			base.Controls.Add(this.picLoading);
			base.Controls.Add(this.lblFile);
			base.Controls.Add(this.lblAppName);
			base.Controls.Add(this.lblNo);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.lstStatus);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "AutoResign";
			this.Text = "AutoResign";
			((ISupportInitialize)this.picLoading).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void picLoading_Click(object sender, EventArgs e)
		{
		}

		public async Task Resign(AppInfos appInfo, string appleId, string password, string udid, string deviceName, string machineName, string machineId, string cloneId = "")
		{
			int num;
			string str;
			int num1;
			object[] objArray;
			AutoResign autoResign;
			AutoResign.AddLogSafe addLogSafe;
			object[] objArray1;
			AutoResign autoResign1;
			AutoResign.AddLogSafe addLogSafe1;
			object obj;
			object obj1;
			string str1 = null;
			string str2;
			string str3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Operators.AddObject(string.Concat("si.", Common.GetHash(Microsoft.VisualBasic.Strings.Trim(appleId)), "."), Interaction.IIf(cloneId.Equals(""), "", string.Concat("clone", cloneId, "."))), Regex.Replace(appInfo.Package, "[^a-zA-Z.]", ""))));
			string str4 = Regex.Replace(string.Concat("SI - ", appInfo.Name), "[^a-zA-Z ]", "");
			string str5 = string.Concat(AppConst.m_rootPath, "\\download\\", appInfo.Filename);
			ILog log = AppConst.logger;
			string[] strArrays = new string[] { "Install::create: ", deviceName, ",", machineName, ",", machineId, ",", str5, "    id=", str3, ",", str4 };
			log.Info(string.Concat(strArrays));
			AutoResign.AddLogSafe addLogSafe2 = new AutoResign.AddLogSafe(this.AddLog);
			int num2 = 9;
			try
			{
				AutoResign autoResign2 = this;
				AutoResign.AddLogSafe addLogSafe3 = addLogSafe2;
				object[] objArray2 = new object[] { string.Concat("\t[1/", Conversions.ToString(num2), "] Login... ", appleId) };
				autoResign2.Invoke(addLogSafe3, objArray2);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
			Application.DoEvents();
			NSDictionary nSDictionary = AppleService.login(appleId, password);
			if (nSDictionary.ContainsKey("myacinfo"))
			{
				string str6 = nSDictionary.ObjectForKey("myacinfo").ToString();
				try
				{
					AutoResign autoResign3 = this;
					AutoResign.AddLogSafe addLogSafe4 = addLogSafe2;
					object[] objArray3 = new object[] { string.Concat("\t[2/", Conversions.ToString(num2), "] Get team...") };
					autoResign3.Invoke(addLogSafe4, objArray3);
				}
				catch (Exception exception1)
				{
					ProjectData.SetProjectError(exception1);
					ProjectData.ClearProjectError();
				}
				Application.DoEvents();
				nSDictionary = AppleService.listTeam(str6);
				string str7 = "";
				if (nSDictionary.ContainsKey("teams"))
				{
					NSArray nSArray = (NSArray)nSDictionary.ObjectForKey("teams");
					if (nSArray.get_Count() > 0)
					{
						NSDictionary nSDictionary1 = (NSDictionary)nSArray.ElementAt<NSObject>(0);
						if (nSDictionary1.ContainsKey("teamId"))
						{
							str7 = nSDictionary1.ObjectForKey("teamId").ToString();
						}
					}
				}
				if (Operators.CompareString(str7, "", false) != 0)
				{
					try
					{
						AutoResign autoResign4 = this;
						AutoResign.AddLogSafe addLogSafe5 = addLogSafe2;
						object[] objArray4 = new object[] { string.Concat("\t[3/", Conversions.ToString(num2), "] Get devices...") };
						autoResign4.Invoke(addLogSafe5, objArray4);
					}
					catch (Exception exception2)
					{
						ProjectData.SetProjectError(exception2);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					nSDictionary = AppleService.listDevices(str7);
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
						try
						{
							AutoResign autoResign5 = this;
							AutoResign.AddLogSafe addLogSafe6 = addLogSafe2;
							object[] objArray5 = new object[] { string.Concat("\t[3+/", Conversions.ToString(num2), "] Add device...") };
							autoResign5.Invoke(addLogSafe6, objArray5);
						}
						catch (Exception exception3)
						{
							ProjectData.SetProjectError(exception3);
							ProjectData.ClearProjectError();
						}
						Application.DoEvents();
						nSDictionary = AppleService.addDevice(udid, deviceName, str7);
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
							goto Label1;
						}
					}
					try
					{
						AutoResign autoResign6 = this;
						AutoResign.AddLogSafe addLogSafe7 = addLogSafe2;
						object[] objArray6 = new object[] { string.Concat("\t[4/", Conversions.ToString(num2), "] Get certs...") };
						autoResign6.Invoke(addLogSafe7, objArray6);
					}
					catch (Exception exception4)
					{
						ProjectData.SetProjectError(exception4);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					nSDictionary = AppleService.allDevelopmentCert(str7);
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
								string str8 = nSDictionary5.ObjectForKey("machineName").ToString();
								if (Operators.CompareString(str8, machineName, false) == 0)
								{
									AppleService.revokeCertificate(nSDictionary5.ObjectForKey("serialNumber").ToString(), str7);
								}
							}
						}
					}
					string str9 = string.Concat(AppConst.m_rootPath, "\\certs\\", Common.GetHash(appleId));
					string str10 = string.Concat(str9, "\\ios.key");
					string str11 = string.Concat(str9, "\\private.pem");
					string str12 = string.Concat(str9, "\\ios.csr");
					string str13 = string.Concat(str9, "\\ios.cer");
					string str14 = string.Concat(str9, "\\ioscer.pem");
					string str15 = string.Concat(str9, "\\ios.mobileprovision");
					if (Operators.CompareString(base64String, "", false) != 0)
					{
						if (Directory.Exists(str9))
						{
							if (!File.Exists(str11) | !File.Exists(str10) | !File.Exists(str12))
							{
								goto Label7;
							}
							goto Label2;
						}
						else
						{
							AppleService.revokeCertificate(str1, str7);
						}
					}
				Label7:
					if (!Directory.Exists(str9))
					{
						Directory.CreateDirectory(str9);
					}
					str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe"), string.Concat("genrsa -des3 -passout pass:12345 -out \"", str10, "\" 2048"), false);
					string str16 = str;
					string str17 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] strArrays1 = new string[] { "rsa -in \"", str10, "\" -passin pass:12345 -out \"", str11, "\" -outform PEM" };
					str = await Common.RunExe(str17, string.Concat(strArrays1), false);
					str16 = str;
					string str18 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] mRootPath = new string[] { "req -new -key \"", str10, "\" -passin pass:12345 -out \"", str12, "\" -subj \"/emailAddress=noname@superimpactor.com, CN=SuperImpactor, C=VN\" -config \"", AppConst.m_rootPath, "\\openssl\\bin\\openssl.cfg\"" };
					str = await Common.RunExe(str18, string.Concat(mRootPath), false);
					str16 = str;
					File.ReadAllText(str11);
					string str19 = File.ReadAllText(str12);
					try
					{
						AutoResign autoResign7 = this;
						AutoResign.AddLogSafe addLogSafe8 = addLogSafe2;
						object[] objArray7 = new object[] { string.Concat("\t[4+/", Conversions.ToString(num2), "] Add cert...") };
						autoResign7.Invoke(addLogSafe8, objArray7);
					}
					catch (Exception exception5)
					{
						ProjectData.SetProjectError(exception5);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					nSDictionary = AppleService.addDevelopmentCert(str19, machineName, machineId, str7);
					AppConst.logger.Info(string.Concat("Install::create: add cert: ", nSDictionary.ToXmlPropertyList()));
					nSDictionary = AppleService.allDevelopmentCert(str7);
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
								string str20 = nSDictionary6.ObjectForKey("machineName").ToString();
								if (Operators.CompareString(str20, machineName, false) == 0)
								{
									base64String = Convert.ToBase64String(((NSData)nSDictionary6.ObjectForKey("certContent")).get_Bytes());
								}
							}
						}
					}
					if (Operators.CompareString(base64String, "", false) == 0)
					{
						try
						{
							autoResign1 = this;
							addLogSafe1 = addLogSafe2;
							objArray1 = new object[] { "\tERROR: Cannot create cert. Please Revoke the existing one!" };
							obj = autoResign1.Invoke(addLogSafe1, objArray1);
						}
						catch (Exception exception6)
						{
							ProjectData.SetProjectError(exception6);
							ProjectData.ClearProjectError();
						}
						num1 = -2;
						num = num1;
						return;
					}
				Label2:
					File.WriteAllBytes(str13, Convert.FromBase64String(base64String));
					string str21 = string.Concat(AppConst.m_rootPath, "\\openssl\\bin\\openssl.exe");
					string[] strArrays2 = new string[] { "x509 -in \"", str13, "\" -inform DER -out \"", str14, "\" -outform PEM" };
					await Common.RunExe(str21, string.Concat(strArrays2), false);
					try
					{
						AutoResign autoResign8 = this;
						AutoResign.AddLogSafe addLogSafe9 = addLogSafe2;
						object[] objArray8 = new object[] { string.Concat("\t[5/", Conversions.ToString(num2), "] Get AppID...") };
						autoResign8.Invoke(addLogSafe9, objArray8);
					}
					catch (Exception exception7)
					{
						ProjectData.SetProjectError(exception7);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					nSDictionary = AppleService.appIds(str7);
					AppConst.logger.Info(string.Concat("Install::create: all appIds: ", nSDictionary.ToXmlPropertyList()));
					str2 = "";
					if (nSDictionary.ContainsKey("appIds"))
					{
						NSArray nSArray5 = (NSArray)nSDictionary.ObjectForKey("appIds");
						if (nSArray5.get_Count() > 0)
						{
							int num3 = checked(nSArray5.get_Count() - 1);
							for (int m = 0; m <= num3; m = checked(m + 1))
							{
								NSDictionary nSDictionary7 = (NSDictionary)nSArray5.ElementAt<NSObject>(m);
								if (nSDictionary7.ContainsKey("identifier") & Operators.CompareString(nSDictionary7.ObjectForKey("identifier").ToString(), str3, false) == 0)
								{
									str2 = nSDictionary7.ObjectForKey("appIdId").ToString();
								}
							}
						}
						if (Operators.CompareString(str2, "", false) == 0 & nSArray5.get_Count() >= 10)
						{
							try
							{
								autoResign = this;
								addLogSafe = addLogSafe2;
								objArray = new object[] { "\tERROR: Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days" };
								obj1 = autoResign.Invoke(addLogSafe, objArray);
							}
							catch (Exception exception8)
							{
								ProjectData.SetProjectError(exception8);
								ProjectData.ClearProjectError();
							}
							num1 = -2;
							num = num1;
							return;
						}
					}
					if (Operators.CompareString(str2, "", false) == 0)
					{
						try
						{
							AutoResign autoResign9 = this;
							AutoResign.AddLogSafe addLogSafe10 = addLogSafe2;
							object[] objArray9 = new object[] { string.Concat("\t[5+/", Conversions.ToString(num2), "] add AppID...") };
							autoResign9.Invoke(addLogSafe10, objArray9);
						}
						catch (Exception exception9)
						{
							ProjectData.SetProjectError(exception9);
							ProjectData.ClearProjectError();
						}
						Application.DoEvents();
						nSDictionary = AppleService.addAppId(str4, str3, str7);
						if (nSDictionary.ContainsKey("appId"))
						{
							goto Label6;
						}
						AppConst.logger.Info(string.Concat("Install::create: add appId failed: ", nSDictionary.ToXmlPropertyList()));
						if (!nSDictionary.ContainsKey("userString"))
						{
							try
							{
								AutoResign autoResign10 = this;
								AutoResign.AddLogSafe addLogSafe11 = addLogSafe2;
								object[] objArray10 = new object[] { "\tERROR: Cannot create App ID. It seem you use other Apple Id to install this app before. Please remove that AppId from menu Tool->Delete AppIds then try again" };
								autoResign10.Invoke(addLogSafe11, objArray10);
							}
							catch (Exception exception10)
							{
								ProjectData.SetProjectError(exception10);
								ProjectData.ClearProjectError();
							}
							num1 = -2;
							num = num1;
							return;
						}
						else
						{
							try
							{
								AutoResign autoResign11 = this;
								AutoResign.AddLogSafe addLogSafe12 = addLogSafe2;
								object[] objArray11 = new object[] { string.Concat("\tERROR: Cannot create App ID: ", nSDictionary.ObjectForKey("userString").ToString()) };
								autoResign11.Invoke(addLogSafe12, objArray11);
							}
							catch (Exception exception11)
							{
								ProjectData.SetProjectError(exception11);
								ProjectData.ClearProjectError();
							}
							num1 = -2;
							num = num1;
							return;
						}
					}
				Label8:
					Database.updateInstalledApp(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.AddObject(Interaction.IIf(cloneId.Equals(""), "", string.Concat("clone", cloneId, ".")), appInfo.Package))), appleId, Path.GetFileName(str5), udid);
					try
					{
						AutoResign autoResign12 = this;
						AutoResign.AddLogSafe addLogSafe13 = addLogSafe2;
						object[] objArray12 = new object[] { string.Concat("\t[6/", Conversions.ToString(num2), "] Get provision...") };
						autoResign12.Invoke(addLogSafe13, objArray12);
					}
					catch (Exception exception12)
					{
						ProjectData.SetProjectError(exception12);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					nSDictionary = AppleService.downloadProvisionProfile(str2, str7);
					AppConst.logger.Info(string.Concat("Install::create: provision: ", nSDictionary.ToXmlPropertyList()));
					if (!nSDictionary.ContainsKey("provisioningProfile"))
					{
						try
						{
							AutoResign autoResign13 = this;
							AutoResign.AddLogSafe addLogSafe14 = addLogSafe2;
							object[] objArray13 = new object[] { "\tERROR: Cannot get provision" };
							autoResign13.Invoke(addLogSafe14, objArray13);
						}
						catch (Exception exception13)
						{
							ProjectData.SetProjectError(exception13);
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						NSDictionary nSDictionary8 = (NSDictionary)nSDictionary.ObjectForKey("provisioningProfile");
						if (!nSDictionary8.ContainsKey("encodedProfile"))
						{
							try
							{
								AutoResign autoResign14 = this;
								AutoResign.AddLogSafe addLogSafe15 = addLogSafe2;
								object[] objArray14 = new object[] { "\tERROR: Cannot get provision" };
								autoResign14.Invoke(addLogSafe15, objArray14);
							}
							catch (Exception exception14)
							{
								ProjectData.SetProjectError(exception14);
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							byte[] bytes = ((NSData)nSDictionary8.ObjectForKey("encodedProfile")).get_Bytes();
							File.WriteAllBytes(str15, bytes);
							AppConst.logger.Info("Install::create: start sign");
							string tempFolder = Common.GetTempFolder();
							try
							{
								Directory.Delete(tempFolder, true);
							}
							catch (Exception exception15)
							{
								ProjectData.SetProjectError(exception15);
								ProjectData.ClearProjectError();
							}
							Application.DoEvents();
							Common.Unzip(string.Concat(AppConst.m_rootPath, "data"), tempFolder, "ABCDEF$%^&abcdef12345");
							Application.DoEvents();
							Common.Unzip(string.Concat(tempFolder, "\\data"), tempFolder, "");
							Application.DoEvents();
							Directory.SetCurrentDirectory(string.Concat(tempFolder, "\\scripts\\"));
							try
							{
								AutoResign autoResign15 = this;
								AutoResign.AddLogSafe addLogSafe16 = addLogSafe2;
								object[] objArray15 = new object[] { string.Concat("\t[7/", Conversions.ToString(num2), "] Sign...") };
								autoResign15.Invoke(addLogSafe16, objArray15);
							}
							catch (Exception exception16)
							{
								ProjectData.SetProjectError(exception16);
								ProjectData.ClearProjectError();
							}
							Application.DoEvents();
							string[] name = new string[] { "isign -i CFBundleIdentifier=", str3, ",CFBundleDisplayName=\"", appInfo.Name, "\" -c \"", str14, "\" -k \"", str11, "\" -p \"", str15, "\" -o superimpact.ipa \"", str5, "\"" };
							str = await Common.RunExe("..\\python.exe", string.Concat(name), false);
							string str22 = str;
							string str23 = "";
							if (!File.Exists("superimpact.ipa"))
							{
								AppConst.logger.Info(string.Concat("Install::create: sign app failed: ", str22));
								str23 = "Sign failed";
							}
							else
							{
								try
								{
									AutoResign autoResign16 = this;
									AutoResign.AddLogSafe addLogSafe17 = addLogSafe2;
									object[] objArray16 = new object[] { string.Concat("\t[8/", Conversions.ToString(num2), "] Install...") };
									autoResign16.Invoke(addLogSafe17, objArray16);
								}
								catch (Exception exception17)
								{
									ProjectData.SetProjectError(exception17);
									ProjectData.ClearProjectError();
								}
								Application.DoEvents();
								string str24 = string.Concat(AppConst.m_rootPath, "\\certs\\\\pr\\", udid);
								try
								{
									Directory.CreateDirectory(str24);
								}
								catch (Exception exception18)
								{
									ProjectData.SetProjectError(exception18);
									ProjectData.ClearProjectError();
								}
								str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("copy \"", str24, "\""), false);
								str22 = str;
								str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), "remove-all", false);
								str22 = str;
								str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinstaller.exe"), string.Concat("-u ", udid, " -i superimpact.ipa"), true);
								str22 = str;
								Debug.Print(string.Concat("install output=", str22));
								AppConst.logger.Info(string.Concat("Install output: ", str22));
								string str25 = "";
								if (str22.IndexOf("ERROR:", StringComparison.Ordinal) > 0)
								{
									str25 = str22.Substring(str22.IndexOf("ERROR:", StringComparison.Ordinal));
								}
								else if (str22.IndexOf("error", StringComparison.Ordinal) > 0)
								{
									str25 = str22.Substring(str22.IndexOf("error", StringComparison.Ordinal));
								}
								else if (str22.IndexOf("No iOS device found", StringComparison.Ordinal) > 0)
								{
									str25 = str22.Substring(str22.IndexOf("No iOS device found", StringComparison.Ordinal));
								}
								if (!str25.Equals(""))
								{
									AppConst.logger.Info(string.Concat("Install::create: install app failed: ", str25));
									str23 = string.Concat("Install failed!: \r\n", str25);
								}
								try
								{
									AutoResign autoResign17 = this;
									AutoResign.AddLogSafe addLogSafe18 = addLogSafe2;
									object[] objArray17 = new object[] { string.Concat("\t[9/", Conversions.ToString(num2), "] Few seconds for finishing...") };
									autoResign17.Invoke(addLogSafe18, objArray17);
								}
								catch (Exception exception19)
								{
									ProjectData.SetProjectError(exception19);
									ProjectData.ClearProjectError();
								}
								Application.DoEvents();
								string[] files = Directory.GetFiles(str24);
								int num4 = Information.UBound(files, 1);
								for (int n = 0; n <= num4; n = checked(n + 1))
								{
									if (Operators.CompareString(Path.GetExtension(files[n]).ToLower(), ".mobileprovision", false) == 0)
									{
										string[] strArrays3 = File.ReadAllLines(files[n]);
										bool flag1 = false;
										int num5 = Information.LBound(strArrays3, 1);
										int num6 = Information.UBound(strArrays3, 1);
										for (int o = num5; o <= num6; o = checked(o + 1))
										{
											if (strArrays3[o].IndexOf("<key>ExpirationDate</key>") >= 0)
											{
												string str26 = strArrays3[checked(o + 1)].Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim();
												DateTime dateTime = DateTime.ParseExact(str26, "yyyy-MM-dd HH:mm:ss", null);
												if (DateTime.Compare(dateTime, DateTime.Now) < 0)
												{
													flag1 = true;
													break;
												}
											}
										}
										if (!flag1)
										{
											str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("install \"", files[n], "\""), false);
											str22 = str;
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
							catch (Exception exception20)
							{
								ProjectData.SetProjectError(exception20);
								ProjectData.ClearProjectError();
							}
							string[] directories = Directory.GetDirectories(string.Concat(tempFolder, "\\..\\"));
							for (int p = 0; p < (int)directories.Length; p = checked(p + 1))
							{
								string str27 = directories[p];
								if (Path.GetFileName(str27).StartsWith("isign-"))
								{
									try
									{
										Common.DeleteFilesFromFolder(str27);
									}
									catch (Exception exception21)
									{
										ProjectData.SetProjectError(exception21);
										ProjectData.ClearProjectError();
									}
								}
							}
							if (Operators.CompareString(str23, "", false) != 0)
							{
								try
								{
									AutoResign autoResign18 = this;
									AutoResign.AddLogSafe addLogSafe19 = addLogSafe2;
									object[] objArray18 = new object[] { string.Concat("\t-----> ERROR: ", str23) };
									autoResign18.Invoke(addLogSafe19, objArray18);
								}
								catch (Exception exception22)
								{
									ProjectData.SetProjectError(exception22);
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								try
								{
									AutoResign autoResign19 = this;
									AutoResign.AddLogSafe addLogSafe20 = addLogSafe2;
									object[] objArray19 = new object[] { "\t-----> SUCCESS" };
									autoResign19.Invoke(addLogSafe20, objArray19);
								}
								catch (Exception exception23)
								{
									ProjectData.SetProjectError(exception23);
									ProjectData.ClearProjectError();
								}
							}
						}
					}
				}
				else
				{
					AppConst.logger.Info(string.Concat("Install::create: not have teamId: ", nSDictionary.ToXmlPropertyList()));
					try
					{
						AutoResign autoResign20 = this;
						AutoResign.AddLogSafe addLogSafe21 = addLogSafe2;
						object[] objArray20 = new object[] { "\tERROR: Not have teamId" };
						autoResign20.Invoke(addLogSafe21, objArray20);
					}
					catch (Exception exception24)
					{
						ProjectData.SetProjectError(exception24);
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				AppConst.logger.Info(string.Concat("Install::create: cannot login itune: ", nSDictionary.ToXmlPropertyList()));
				try
				{
					AutoResign autoResign21 = this;
					AutoResign.AddLogSafe addLogSafe22 = addLogSafe2;
					object[] objArray21 = new object[] { "\tERROR: Cannot login itune..." };
					autoResign21.Invoke(addLogSafe22, objArray21);
				}
				catch (Exception exception25)
				{
					ProjectData.SetProjectError(exception25);
					ProjectData.ClearProjectError();
				}
			}
			num1 = -2;
			num = num1;
			return;
		Label1:
			AppConst.logger.Info(string.Concat("Install::create: cannot add device ", nSDictionary.ToXmlPropertyList()));
			if (!nSDictionary.ContainsKey("userString"))
			{
				try
				{
					AutoResign autoResign22 = this;
					AutoResign.AddLogSafe addLogSafe23 = addLogSafe2;
					object[] objArray22 = new object[] { "\tERROR: Cannot add device" };
					autoResign22.Invoke(addLogSafe23, objArray22);
				}
				catch (Exception exception26)
				{
					ProjectData.SetProjectError(exception26);
					ProjectData.ClearProjectError();
				}
				num1 = -2;
				num = num1;
				return;
			}
			else
			{
				try
				{
					AutoResign autoResign23 = this;
					AutoResign.AddLogSafe addLogSafe24 = addLogSafe2;
					object[] objArray23 = new object[] { string.Concat("\tERROR: Cannot add device: ", nSDictionary.ObjectForKey("userString").ToString()) };
					autoResign23.Invoke(addLogSafe24, objArray23);
				}
				catch (Exception exception27)
				{
					ProjectData.SetProjectError(exception27);
					ProjectData.ClearProjectError();
				}
				num1 = -2;
				num = num1;
				return;
			}
			goto Label7;
			try
			{
				autoResign1 = this;
				addLogSafe1 = addLogSafe2;
				objArray1 = new object[] { "\tERROR: Cannot create cert. Please Revoke the existing one!" };
				obj = autoResign1.Invoke(addLogSafe1, objArray1);
			}
			catch (Exception exception6)
			{
				ProjectData.SetProjectError(exception6);
				ProjectData.ClearProjectError();
			}
			num1 = -2;
			num = num1;
			return;
			try
			{
				autoResign = this;
				addLogSafe = addLogSafe2;
				objArray = new object[] { "\tERROR: Maximun 10 apps reach for your appleId. Please change other appleId or waiting for 7 days" };
				obj1 = autoResign.Invoke(addLogSafe, objArray);
			}
			catch (Exception exception8)
			{
				ProjectData.SetProjectError(exception8);
				ProjectData.ClearProjectError();
			}
			num1 = -2;
			num = num1;
			return;
		Label6:
			NSDictionary nSDictionary9 = (NSDictionary)nSDictionary.ObjectForKey("appId");
			str2 = nSDictionary9.ObjectForKey("appIdId").ToString();
			goto Label8;
		}

		public void ResignAsync(List<AppInfosResign> lstAppInfos, string udid, string deviceName, string machineName, string machineId)
		{
			this.lstAppInfo = lstAppInfos;
			this.udid = udid;
			this.deviceName = deviceName;
			this.machineName = machineName;
			this.machineId = machineId;
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			base.Show();
			this.picLoading.Visible = true;
			this.BackgroundWorker1.RunWorkerAsync();
		}

		public delegate void AddLogSafe(string log);

		public delegate void ChangeTextsSafe(string no, AppInfos appInf);

		public delegate void CompleteSafe(bool cancelled);
	}
}