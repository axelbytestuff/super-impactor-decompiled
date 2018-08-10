using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class AppDetail : Form
	{
		private IContainer components;

		public AppInfos appDetailInfo;

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

		internal virtual PictureBox imgApp
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label1
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

		internal virtual Label Label6
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label8
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label9
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

		internal virtual Label lblAuthor
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblCategory
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblSize
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblSupport
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblVersion
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox pic1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox pic2
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox pic3
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox pic4
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtDesc
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public AppDetail()
		{
			this.InitializeComponent();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdInstall_Click(object sender, EventArgs e)
		{
			string filename;
			string str;
			if (this.appDetailInfo.Filename.IndexOf("dailyuploads.net") < 0)
			{
				filename = this.appDetailInfo.Filename;
				str = string.Concat(this.appDetailInfo.Name, ".ipa");
			}
			else
			{
				filename = this.appDetailInfo.Filename;
				str = "checking...ipa";
			}
			base.Close();
			Common.Download(new DownloadProgress(), filename, str);
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
			this.imgApp = new PictureBox();
			this.lblAppName = new Label();
			this.cmdInstall = new Button();
			this.lblVersion = new Label();
			this.lblSize = new Label();
			this.Label4 = new Label();
			this.lblCategory = new Label();
			this.Label6 = new Label();
			this.lblSupport = new Label();
			this.Label8 = new Label();
			this.txtDesc = new TextBox();
			this.Label9 = new Label();
			this.lblAuthor = new Label();
			this.cmdClose = new Button();
			this.Label1 = new Label();
			this.pic1 = new PictureBox();
			this.pic2 = new PictureBox();
			this.pic3 = new PictureBox();
			this.pic4 = new PictureBox();
			((ISupportInitialize)this.imgApp).BeginInit();
			((ISupportInitialize)this.pic1).BeginInit();
			((ISupportInitialize)this.pic2).BeginInit();
			((ISupportInitialize)this.pic3).BeginInit();
			((ISupportInitialize)this.pic4).BeginInit();
			base.SuspendLayout();
			this.imgApp.Location = new Point(13, 13);
			this.imgApp.Name = "imgApp";
			this.imgApp.Size = new System.Drawing.Size(63, 58);
			this.imgApp.SizeMode = PictureBoxSizeMode.Zoom;
			this.imgApp.TabIndex = 0;
			this.imgApp.TabStop = false;
			this.lblAppName.AutoSize = true;
			this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblAppName.Location = new Point(84, 19);
			this.lblAppName.Name = "lblAppName";
			this.lblAppName.Size = new System.Drawing.Size(91, 18);
			this.lblAppName.TabIndex = 1;
			this.lblAppName.Text = "APP HERE";
			this.cmdInstall.Location = new Point(423, 19);
			this.cmdInstall.Name = "cmdInstall";
			this.cmdInstall.Size = new System.Drawing.Size(75, 23);
			this.cmdInstall.TabIndex = 2;
			this.cmdInstall.Text = "Download";
			this.cmdInstall.UseVisualStyleBackColor = true;
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new Point(83, 52);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(22, 13);
			this.lblVersion.TabIndex = 3;
			this.lblVersion.Text = "0.0";
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new Point(181, 52);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(29, 13);
			this.lblSize.TabIndex = 4;
			this.lblSize.Text = "0 kB";
			this.Label4.AutoSize = true;
			this.Label4.Location = new Point(12, 98);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(49, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "Category";
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new Point(84, 98);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(39, 13);
			this.lblCategory.TabIndex = 6;
			this.lblCategory.Text = "Label5";
			this.Label6.AutoSize = true;
			this.Label6.Location = new Point(12, 124);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(68, 13);
			this.Label6.TabIndex = 7;
			this.Label6.Text = "Minimum iOS";
			this.lblSupport.AutoSize = true;
			this.lblSupport.Location = new Point(84, 124);
			this.lblSupport.Name = "lblSupport";
			this.lblSupport.Size = new System.Drawing.Size(39, 13);
			this.lblSupport.TabIndex = 8;
			this.lblSupport.Text = "Label7";
			this.Label8.AutoSize = true;
			this.Label8.Location = new Point(12, 176);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(60, 13);
			this.Label8.TabIndex = 9;
			this.Label8.Text = "Description";
			this.txtDesc.Location = new Point(84, 176);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.ScrollBars = ScrollBars.Vertical;
			this.txtDesc.Size = new System.Drawing.Size(418, 215);
			this.txtDesc.TabIndex = 10;
			this.Label9.AutoSize = true;
			this.Label9.Location = new Point(12, 150);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(38, 13);
			this.Label9.TabIndex = 11;
			this.Label9.Text = "Author";
			this.lblAuthor.AutoSize = true;
			this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblAuthor.Location = new Point(84, 150);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(52, 13);
			this.lblAuthor.TabIndex = 12;
			this.lblAuthor.Text = "Label10";
			this.cmdClose.Location = new Point(423, 50);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 13;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(16, 415);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(68, 13);
			this.Label1.TabIndex = 14;
			this.Label1.Text = "ScreenShots";
			this.pic1.Location = new Point(84, 415);
			this.pic1.Name = "pic1";
			this.pic1.Size = new System.Drawing.Size(100, 174);
			this.pic1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pic1.TabIndex = 15;
			this.pic1.TabStop = false;
			this.pic2.Location = new Point(190, 415);
			this.pic2.Name = "pic2";
			this.pic2.Size = new System.Drawing.Size(100, 174);
			this.pic2.SizeMode = PictureBoxSizeMode.Zoom;
			this.pic2.TabIndex = 16;
			this.pic2.TabStop = false;
			this.pic3.Location = new Point(296, 415);
			this.pic3.Name = "pic3";
			this.pic3.Size = new System.Drawing.Size(100, 174);
			this.pic3.SizeMode = PictureBoxSizeMode.Zoom;
			this.pic3.TabIndex = 17;
			this.pic3.TabStop = false;
			this.pic4.Location = new Point(402, 415);
			this.pic4.Name = "pic4";
			this.pic4.Size = new System.Drawing.Size(100, 174);
			this.pic4.SizeMode = PictureBoxSizeMode.Zoom;
			this.pic4.TabIndex = 18;
			this.pic4.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(503, 589);
			base.ControlBox = false;
			base.Controls.Add(this.pic4);
			base.Controls.Add(this.pic3);
			base.Controls.Add(this.pic2);
			base.Controls.Add(this.pic1);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.lblAuthor);
			base.Controls.Add(this.Label9);
			base.Controls.Add(this.txtDesc);
			base.Controls.Add(this.Label8);
			base.Controls.Add(this.lblSupport);
			base.Controls.Add(this.Label6);
			base.Controls.Add(this.lblCategory);
			base.Controls.Add(this.Label4);
			base.Controls.Add(this.lblSize);
			base.Controls.Add(this.lblVersion);
			base.Controls.Add(this.cmdInstall);
			base.Controls.Add(this.lblAppName);
			base.Controls.Add(this.imgApp);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AppDetail";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "App Detail";
			((ISupportInitialize)this.imgApp).EndInit();
			((ISupportInitialize)this.pic1).EndInit();
			((ISupportInitialize)this.pic2).EndInit();
			((ISupportInitialize)this.pic3).EndInit();
			((ISupportInitialize)this.pic4).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void showApp(AppInfos appinfo)
		{
			ItuneResult ituneResult;
			this.appDetailInfo = appinfo;
			WebClient webClient = new WebClient();
			this.lblAppName.Text = this.appDetailInfo.Name;
			this.lblAuthor.Text = this.appDetailInfo.Author;
			this.lblCategory.Text = this.appDetailInfo.Section;
			this.lblVersion.Text = this.appDetailInfo.Version;
			try
			{
				string str = webClient.DownloadString(string.Concat("https://itunes.apple.com/lookup?id=", this.appDetailInfo.Package));
				ituneResult = JsonConvert.DeserializeObject<ItuneResult>(str);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox("Cannot get app information", MsgBoxStyle.OkOnly, null);
				ProjectData.ClearProjectError();
				return;
			}
			WebClient webClient1 = new WebClient();
			if (ituneResult.resultCount <= 0)
			{
				this.appDetailInfo.Size = "";
				this.appDetailInfo.Description = "";
			}
			else
			{
				this.appDetailInfo.Size = ituneResult.results.ElementAt<AppleAppInfo>(0).fileSizeBytes;
				this.appDetailInfo.Description = ituneResult.results.ElementAt<AppleAppInfo>(0).description.Replace("\n", "\r\n");
				this.appDetailInfo.Architecture = ituneResult.results.ElementAt<AppleAppInfo>(0).minimumOsVersion;
				long num = Conversions.ToLong(this.appDetailInfo.Size);
				if ((double)num / 1024 / 1024 / 1024 > 1)
				{
					this.lblSize.Text = string.Concat(Conversions.ToString(Math.Round((double)num / 1024 / 1024 / 1024, 2)), " GB");
				}
				else if ((double)num / 1024 / 1024 <= 1)
				{
					this.lblSize.Text = string.Concat(Conversions.ToString(Math.Round((double)num / 1024, 2)), " KB");
				}
				else
				{
					this.lblSize.Text = string.Concat(Conversions.ToString(Math.Round((double)num / 1024 / 1024, 2)), " MB");
				}
				this.pic1.Image = Image.FromStream(new MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt<AppleAppInfo>(0).screenshotUrls.ElementAt<string>(0))));
				this.pic2.Image = Image.FromStream(new MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt<AppleAppInfo>(0).screenshotUrls.ElementAt<string>(1))));
				this.pic3.Image = Image.FromStream(new MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt<AppleAppInfo>(0).screenshotUrls.ElementAt<string>(2))));
				this.pic4.Image = Image.FromStream(new MemoryStream(webClient1.DownloadData(ituneResult.results.ElementAt<AppleAppInfo>(0).screenshotUrls.ElementAt<string>(3))));
			}
			if (!(Operators.CompareString(appinfo.Icon, "", false) != 0 & appinfo.Icon.StartsWith("http")))
			{
				this.imgApp.Image = new Bitmap(string.Concat(AppConst.m_rootPath, "\\res\\/apptype_tweak.png"));
			}
			else
			{
				this.imgApp.Image = Image.FromStream(new MemoryStream(webClient1.DownloadData(appinfo.Icon)));
			}
			this.lblSupport.Text = this.appDetailInfo.Architecture;
			this.txtDesc.Text = this.appDetailInfo.Description;
			base.ShowDialog();
		}
	}
}