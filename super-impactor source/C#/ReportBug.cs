using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class ReportBug : Form
	{
		private IContainer components;

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

		internal virtual Button cmdSend
		{
			get
			{
				stackVariable1 = this._cmdSend;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdSend_Click);
				Button button = this._cmdSend;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdSend = value;
				button = this._cmdSend;
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

		internal virtual TextBox txtEmail
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtMessage
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public ReportBug()
		{
			this.InitializeComponent();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private async void cmdSend_Click(object sender, EventArgs e)
		{
			this.cmdSend.Enabled = false;
			this.picLoading.Visible = true;
			this.lblLoading.Visible = true;
			string str = await ReportBug.sendLog(this.txtEmail.Text, this.txtMessage.Text);
			string str1 = str;
			if (Operators.CompareString(str1, "", false) != 0)
			{
				this.cmdSend.Enabled = true;
				this.picLoading.Visible = false;
				this.lblLoading.Visible = false;
				Interaction.MsgBox(str1, MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Interaction.MsgBox("Send successfully. We will contact you after processing your request", MsgBoxStyle.OkOnly, null);
				this.Close();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ReportBug));
			this.Label1 = new Label();
			this.txtEmail = new TextBox();
			this.txtMessage = new TextBox();
			this.Label2 = new Label();
			this.cmdSend = new Button();
			this.cmdClose = new Button();
			this.Label3 = new Label();
			this.lblLoading = new Label();
			this.picLoading = new PictureBox();
			((ISupportInitialize)this.picLoading).BeginInit();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(13, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(32, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Email";
			this.txtEmail.Location = new Point(65, 19);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(214, 20);
			this.txtEmail.TabIndex = 1;
			this.txtMessage.Location = new Point(65, 59);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(214, 223);
			this.txtMessage.TabIndex = 3;
			this.Label2.AutoSize = true;
			this.Label2.Location = new Point(13, 62);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(50, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Message";
			this.cmdSend.Location = new Point(304, 19);
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(75, 23);
			this.cmdSend.TabIndex = 4;
			this.cmdSend.Text = "Send";
			this.cmdSend.UseVisualStyleBackColor = true;
			this.cmdClose.Location = new Point(304, 59);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			this.Label3.Location = new Point(62, 40);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(236, 13);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Optional (we will support by email ASAP)";
			this.lblLoading.AutoSize = true;
			this.lblLoading.Location = new Point(314, 200);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(55, 13);
			this.lblLoading.TabIndex = 8;
			this.lblLoading.Text = "Sending...";
			this.lblLoading.Visible = false;
			this.picLoading.Image = (Image)componentResourceManager.GetObject("picLoading.Image");
			this.picLoading.Location = new Point(310, 141);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(59, 56);
			this.picLoading.TabIndex = 10;
			this.picLoading.TabStop = false;
			this.picLoading.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(405, 295);
			base.ControlBox = false;
			base.Controls.Add(this.picLoading);
			base.Controls.Add(this.lblLoading);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdSend);
			base.Controls.Add(this.txtMessage);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.txtEmail);
			base.Controls.Add(this.Label1);
			base.Name = "ReportBug";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Support";
			((ISupportInitialize)this.picLoading).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public static async Task<string> sendLog(string email, string message)
		{
			string str;
			str = (!File.Exists(string.Concat(AppConst.m_rootPath, "/Log/SuperImpactor.log")) ? string.Concat(AppConst.m_rootPath, "/bin/Debug/Log/SuperImpactor.log") : string.Concat(AppConst.m_rootPath, "/Log/SuperImpactor.log"));
			FileStream fileStream = new FileStream(str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader streamReader = new StreamReader(fileStream);
			string str1 = "";
			while (!streamReader.EndOfStream)
			{
				str1 = string.Concat(str1, streamReader.ReadLine(), "\r\n");
			}
			streamReader.Close();
			fileStream.Close();
			if (str1.Length > 10000)
			{
				str1 = str1.Substring(checked(str1.Length - 10000));
			}
			string[] versionString = new string[] { Environment.OSVersion.VersionString, "\r\nv", Assembly.GetExecutingAssembly().GetName().Version.ToString(), "\r\n", message, "\r\n" };
			message = string.Concat(versionString);
			HttpClient httpClient = new HttpClient();
			Dictionary<string, string> strs = new Dictionary<string, string>()
			{
				{ "email", email },
				{ "message", message },
				{ "log", str1 }
			};
			FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(strs);
			HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://superimpactor.net/api/send_log.php", formUrlEncodedContent);
			httpResponseMessage.EnsureSuccessStatusCode();
			await httpResponseMessage.Content.ReadAsStringAsync();
			string str2 = "";
			return str2;
		}
	}
}