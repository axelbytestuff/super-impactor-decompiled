using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class DownloadProgress : Form
	{
		private IContainer components;

		private string downloadLink;

		private string localFile;

		private string storeFile;

		private bool bComplete;

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

		internal virtual CheckBox chkStore
		{
			get
			{
				stackVariable1 = this._chkStore;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.chkStore_CheckedChanged);
				CheckBox checkBox = this._chkStore;
				if (checkBox != null)
				{
					checkBox.CheckedChanged -= eventHandler;
				}
				this._chkStore = value;
				checkBox = this._chkStore;
				if (checkBox != null)
				{
					checkBox.CheckedChanged += eventHandler;
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

		internal virtual Label Label5
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblDownload
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

		internal virtual Label lblFileSize
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblPercent
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblSpeed
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ProgressBar ProgressBar1
		{
			get
			{
				stackVariable1 = this._ProgressBar1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.ProgressBar1_Click);
				ProgressBar progressBar = this._ProgressBar1;
				if (progressBar != null)
				{
					progressBar.Click -= eventHandler;
				}
				this._ProgressBar1 = value;
				progressBar = this._ProgressBar1;
				if (progressBar != null)
				{
					progressBar.Click += eventHandler;
				}
			}
		}

		public DownloadProgress()
		{
			base.Load += new EventHandler(this.DownloadProgress_Load);
			base.Closed += new EventHandler(this.DownloadProgress_Closed);
			this.bComplete = false;
			this.InitializeComponent();
		}

		private async void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			int num;
			int num1;
			object[] objArray;
			DownloadProgress downloadProgress;
			DownloadProgress.DownloadCompleteSafe downloadCompleteSafe;
			MsgBoxResult msgBoxResult;
			object obj;
			int num2;
			HttpWebResponse response;
			long num3 = 0L;
			DownloadProgress.DownloadCompleteSafe downloadCompleteSafe1;
			if (this.downloadLink.IndexOf("dailyuploads.net") >= 0)
			{
				num2 = URLInstall.DailyUpload(this.downloadLink, ref this.downloadLink, ref this.storeFile);
				if (num2 < 0)
				{
					msgBoxResult = Interaction.MsgBox(string.Concat("Cannot download file! Is your link correct? ", num2.ToString()), MsgBoxStyle.OkOnly, null);
					downloadCompleteSafe1 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
					try
					{
						downloadProgress = this;
						downloadCompleteSafe = downloadCompleteSafe1;
						objArray = new object[] { true };
						obj = downloadProgress.Invoke(downloadCompleteSafe, objArray);
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
					}
					num1 = -2;
					num = num1;
					return;
				}
			}
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.downloadLink);
				response = (HttpWebResponse)httpWebRequest.GetResponse();
			}
			catch (Exception exception2)
			{
				ProjectData.SetProjectError(exception2);
				MessageBox.Show("An error occurred while downloading file. Possibe causes:\r\n1) File doesn't exist\r\n2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DownloadProgress.DownloadCompleteSafe downloadCompleteSafe2 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
				try
				{
					DownloadProgress downloadProgress1 = this;
					DownloadProgress.DownloadCompleteSafe downloadCompleteSafe3 = downloadCompleteSafe2;
					object[] objArray1 = new object[] { true };
					downloadProgress1.Invoke(downloadCompleteSafe3, objArray1);
				}
				catch (Exception exception1)
				{
					ProjectData.SetProjectError(exception1);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
				num1 = -2;
				num = num1;
				return;
			}
			long contentLength = response.ContentLength;
			DownloadProgress.ChangeTextsSafe changeTextsSafe = new DownloadProgress.ChangeTextsSafe(this.ChangeTexts);
			try
			{
				DownloadProgress downloadProgress2 = this;
				DownloadProgress.ChangeTextsSafe changeTextsSafe1 = changeTextsSafe;
				object[] objArray2 = new object[] { contentLength, 0, 0, 0 };
				downloadProgress2.Invoke(changeTextsSafe1, objArray2);
			}
			catch (Exception exception3)
			{
				ProjectData.SetProjectError(exception3);
				ProjectData.ClearProjectError();
			}
			FileStream fileStream = new FileStream(this.localFile, FileMode.Create);
			Stopwatch stopwatch = new Stopwatch();
			double elapsedMilliseconds = -1;
			int num4 = 0;
			while (true)
			{
				if (!this.BackgroundWorker1.CancellationPending)
				{
					stopwatch.Start();
					byte[] numArray = new byte[4096];
					int num5 = response.GetResponseStream().Read(numArray, 0, 4096);
					num3 = checked(num3 + (long)num5);
					long num6 = checked((long)Math.Round(Math.Round((double)(checked(num3 * (long)100)) / (double)contentLength)));
					try
					{
						DownloadProgress downloadProgress3 = this;
						DownloadProgress.ChangeTextsSafe changeTextsSafe2 = changeTextsSafe;
						object[] objArray3 = new object[] { contentLength, num3, num6, elapsedMilliseconds };
						downloadProgress3.Invoke(changeTextsSafe2, objArray3);
					}
					catch (Exception exception5)
					{
						ProjectData.SetProjectError(exception5);
						response.GetResponseStream().Close();
						fileStream.Close();
						try
						{
							File.Delete(this.localFile);
							DownloadProgress.DownloadCompleteSafe downloadCompleteSafe4 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
							DownloadProgress downloadProgress4 = this;
							DownloadProgress.DownloadCompleteSafe downloadCompleteSafe5 = downloadCompleteSafe4;
							object[] objArray4 = new object[] { true };
							downloadProgress4.Invoke(downloadCompleteSafe5, objArray4);
						}
						catch (Exception exception4)
						{
							ProjectData.SetProjectError(exception4);
							ProjectData.ClearProjectError();
						}
						ProjectData.ClearProjectError();
						num1 = -2;
						num = num1;
						return;
					}
					if (num5 != 0)
					{
						fileStream.Write(numArray, 0, num5);
						stopwatch.Stop();
						num4 = checked(num4 + 1);
						if (num4 >= 100)
						{
							elapsedMilliseconds = 409600 / ((double)stopwatch.ElapsedMilliseconds / 1000);
							stopwatch.Reset();
							num4 = 0;
						}
					}
					else
					{
						break;
					}
				}
				else
				{
					break;
				}
			}
			response.GetResponseStream().Close();
			fileStream.Close();
			if (!this.BackgroundWorker1.CancellationPending)
			{
				if (this.storeFile.EndsWith(".deb"))
				{
					try
					{
						Directory.CreateDirectory(AppConst.m_localTmp);
					}
					catch (Exception exception6)
					{
						ProjectData.SetProjectError(exception6);
						ProjectData.ClearProjectError();
					}
					try
					{
						File.Delete(string.Concat(AppConst.m_localTmp, "/data.tar"));
					}
					catch (Exception exception7)
					{
						ProjectData.SetProjectError(exception7);
						ProjectData.ClearProjectError();
					}
					try
					{
						Common.DeleteFilesFromFolder(string.Concat(AppConst.m_localTmp, "/data"));
					}
					catch (Exception exception8)
					{
						ProjectData.SetProjectError(exception8);
						ProjectData.ClearProjectError();
					}
					DownloadProgress.ChangeStatusSafe changeStatusSafe = new DownloadProgress.ChangeStatusSafe(this.ChangeStatus);
					try
					{
						DownloadProgress downloadProgress5 = this;
						DownloadProgress.ChangeStatusSafe changeStatusSafe1 = changeStatusSafe;
						object[] objArray5 = new object[] { "Please wait for processing download file..." };
						downloadProgress5.Invoke(changeStatusSafe1, objArray5);
					}
					catch (Exception exception9)
					{
						ProjectData.SetProjectError(exception9);
						ProjectData.ClearProjectError();
					}
					Application.DoEvents();
					string str = string.Concat(AppConst.m_rootPath, "\\7zip\\7z.exe");
					string[] mLocalTmp = new string[] { "e \"", this.localFile, "\" -o\"", AppConst.m_localTmp, "\"" };
					string str1 = await Common.RunExe(str, string.Concat(mLocalTmp), true);
					string str2 = str1;
					string str3 = string.Concat(AppConst.m_rootPath, "\\7zip\\7z.exe");
					string[] strArrays = new string[] { "x \"", AppConst.m_localTmp, "\\data.tar\" -o\"", AppConst.m_localTmp, "\\data\\\" -r -aoa" };
					str1 = await Common.RunExe(str3, string.Concat(strArrays), true);
					str2 = str1;
					Directory.Move(string.Concat(AppConst.m_localTmp, "\\data\\Applications"), string.Concat(AppConst.m_localTmp, "\\data\\Payload"));
					string str4 = string.Concat(AppConst.m_rootPath, "\\7zip\\7z.exe");
					string[] mLocalTmp1 = new string[] { "a -tzip \"", this.localFile, ".zip\" \"", AppConst.m_localTmp, "\\data\\*\"" };
					str1 = await Common.RunExe(str4, string.Concat(mLocalTmp1), false);
					str2 = str1;
					this.storeFile = string.Concat(this.storeFile, ".ipa");
					try
					{
						File.Delete(this.localFile);
					}
					catch (Exception exception10)
					{
						ProjectData.SetProjectError(exception10);
						ProjectData.ClearProjectError();
					}
					try
					{
						File.Move(string.Concat(this.localFile, ".zip"), this.localFile);
					}
					catch (Exception exception11)
					{
						ProjectData.SetProjectError(exception11);
						Interaction.MsgBox(exception11.Message, MsgBoxStyle.OkOnly, null);
						ProjectData.ClearProjectError();
					}
				}
				DownloadProgress.DownloadCompleteSafe downloadCompleteSafe6 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
				try
				{
					DownloadProgress downloadProgress6 = this;
					DownloadProgress.DownloadCompleteSafe downloadCompleteSafe7 = downloadCompleteSafe6;
					object[] objArray6 = new object[] { false };
					downloadProgress6.Invoke(downloadCompleteSafe7, objArray6);
				}
				catch (Exception exception12)
				{
					ProjectData.SetProjectError(exception12);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				File.Delete(this.localFile);
				DownloadProgress.DownloadCompleteSafe downloadCompleteSafe8 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
				try
				{
					DownloadProgress downloadProgress7 = this;
					DownloadProgress.DownloadCompleteSafe downloadCompleteSafe9 = downloadCompleteSafe8;
					object[] objArray7 = new object[] { true };
					downloadProgress7.Invoke(downloadCompleteSafe9, objArray7);
				}
				catch (Exception exception13)
				{
					ProjectData.SetProjectError(exception13);
					ProjectData.ClearProjectError();
				}
			}
			num1 = -2;
			num = num1;
			return;
			msgBoxResult = Interaction.MsgBox(string.Concat("Cannot download file! Is your link correct? ", num2.ToString()), MsgBoxStyle.OkOnly, null);
			downloadCompleteSafe1 = new DownloadProgress.DownloadCompleteSafe(this.DownloadComplete);
			try
			{
				downloadProgress = this;
				downloadCompleteSafe = downloadCompleteSafe1;
				objArray = new object[] { true };
				obj = downloadProgress.Invoke(downloadCompleteSafe, objArray);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
			num1 = -2;
			num = num1;
		}

		private void ChangeStatus(string text)
		{
			this.lblFile.Text = text;
			this.Text = text;
		}

		private void ChangeTexts(long length, long position, long percent, double speed)
		{
			if (length == (long)-1)
			{
				this.lblFileSize.Text = "calculating...";
			}
			else if ((double)length / 1024 / 1024 <= 1)
			{
				this.lblFileSize.Text = string.Concat(Conversions.ToString(Math.Round((double)length / 1024, 2)), " KB");
			}
			else
			{
				this.lblFileSize.Text = string.Concat(Conversions.ToString(Math.Round((double)length / 1024 / 1024, 2)), " MB");
			}
			if ((double)position / 1024 / 1024 <= 1)
			{
				this.lblDownload.Text = string.Concat(Conversions.ToString(Math.Round((double)position / 1024, 2)), " KB");
			}
			else
			{
				this.lblDownload.Text = string.Concat(Conversions.ToString(Math.Round((double)position / 1024 / 1024, 2)), " MB");
			}
			if (speed == -1)
			{
				this.lblSpeed.Text = "calculating...";
			}
			else if (speed / 1024 / 1024 <= 1)
			{
				this.lblSpeed.Text = string.Concat(Conversions.ToString(Math.Round(speed / 1024, 2)), " KB/s");
			}
			else
			{
				this.lblSpeed.Text = string.Concat(Conversions.ToString(Math.Round(speed / 1024 / 1024, 2)), " MB/s");
			}
			this.ProgressBar1.Value = checked((int)percent);
			this.lblPercent.BringToFront();
			this.lblPercent.Text = string.Concat(Conversions.ToString(percent), "%");
			this.Text = string.Concat(Conversions.ToString(percent), "%  ", this.storeFile);
			this.lblPercent.BackColor = Color.Transparent;
			this.lblFile.Text = this.storeFile;
		}

		private void chkStore_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.BackgroundWorker1.CancelAsync();
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

		public bool Download(string url, string tmpFile, string storedFile)
		{
			this.downloadLink = url;
			this.localFile = tmpFile;
			this.storeFile = storedFile;
			this.ChangeTexts((long)-1, (long)0, (long)0, -1);
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker1.RunWorkerAsync();
			this.Text = string.Concat("Download:    ", storedFile);
			base.ShowDialog();
			return this.bComplete;
		}

		public void DownloadAsync(string url, string tmpFile, string storedFile)
		{
			this.downloadLink = url;
			this.localFile = tmpFile;
			this.storeFile = storedFile;
			this.ChangeTexts((long)-1, (long)0, (long)0, -1);
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker1.RunWorkerAsync();
			base.Show();
			this.Text = string.Concat("Download: ", storedFile);
		}

		private void DownloadComplete(bool cancelled)
		{
			if (!cancelled)
			{
				if (this.chkStore.Checked)
				{
					try
					{
						File.Delete(string.Concat(AppConst.m_rootPath, "\\download\\", this.storeFile));
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
					}
					try
					{
						File.Move(this.localFile, string.Concat(AppConst.m_rootPath, "\\download\\", this.storeFile));
						AppConst.mainForm.onDownloadComplete();
					}
					catch (Exception exception1)
					{
						ProjectData.SetProjectError(exception1);
						ProjectData.ClearProjectError();
					}
				}
				this.bComplete = true;
				base.Close();
			}
			else
			{
				base.Close();
			}
		}

		private void DownloadProgress_Closed(object sender, EventArgs e)
		{
			this.BackgroundWorker1.CancelAsync();
		}

		private void DownloadProgress_Load(object sender, EventArgs e)
		{
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new Label();
			this.Label2 = new Label();
			this.ProgressBar1 = new ProgressBar();
			this.lblFileSize = new Label();
			this.lblSpeed = new Label();
			this.BackgroundWorker1 = new BackgroundWorker();
			this.Label3 = new Label();
			this.lblFile = new Label();
			this.chkStore = new CheckBox();
			this.lblPercent = new Label();
			this.lblDownload = new Label();
			this.Label5 = new Label();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(15, 38);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(47, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "File size:";
			this.Label2.AutoSize = true;
			this.Label2.Location = new Point(143, 38);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(41, 13);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Speed:";
			this.ProgressBar1.Location = new Point(45, 62);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(482, 23);
			this.ProgressBar1.TabIndex = 4;
			this.lblFileSize.AutoSize = true;
			this.lblFileSize.Location = new Point(66, 38);
			this.lblFileSize.Name = "lblFileSize";
			this.lblFileSize.Size = new System.Drawing.Size(0, 13);
			this.lblFileSize.TabIndex = 5;
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new Point(190, 38);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(0, 13);
			this.lblSpeed.TabIndex = 6;
			this.Label3.AutoSize = true;
			this.Label3.Location = new Point(15, 12);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(26, 13);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "File:";
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new Point(42, 12);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(0, 13);
			this.lblFile.TabIndex = 8;
			this.chkStore.AutoSize = true;
			this.chkStore.Checked = true;
			this.chkStore.CheckState = CheckState.Checked;
			this.chkStore.Location = new Point(441, 35);
			this.chkStore.Name = "chkStore";
			this.chkStore.Size = new System.Drawing.Size(92, 17);
			this.chkStore.TabIndex = 9;
			this.chkStore.Text = "Store file local";
			this.chkStore.UseVisualStyleBackColor = true;
			this.lblPercent.AutoSize = true;
			this.lblPercent.BackColor = Color.Transparent;
			this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 163);
			this.lblPercent.ForeColor = Color.Fuchsia;
			this.lblPercent.Location = new Point(14, 65);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(0, 13);
			this.lblPercent.TabIndex = 10;
			this.lblDownload.AutoSize = true;
			this.lblDownload.Location = new Point(362, 38);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(0, 13);
			this.lblDownload.TabIndex = 12;
			this.Label5.AutoSize = true;
			this.Label5.Location = new Point(279, 38);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(79, 13);
			this.Label5.TabIndex = 11;
			this.Label5.Text = "Download size:";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(542, 97);
			base.Controls.Add(this.lblDownload);
			base.Controls.Add(this.Label5);
			base.Controls.Add(this.lblPercent);
			base.Controls.Add(this.chkStore);
			base.Controls.Add(this.lblFile);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.lblSpeed);
			base.Controls.Add(this.lblFileSize);
			base.Controls.Add(this.ProgressBar1);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.Label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "DownloadProgress";
			this.Text = "Download IPA";
			base.TransparencyKey = Color.Lime;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void ProgressBar1_Click(object sender, EventArgs e)
		{
		}

		public delegate void ChangeStatusSafe(string text);

		public delegate void ChangeTextsSafe(long length, long position, long percent, double speed);

		public delegate void DownloadCompleteSafe(bool cancelled);
	}
}