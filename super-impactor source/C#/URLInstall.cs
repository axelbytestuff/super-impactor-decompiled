using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class URLInstall : Form
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

		internal virtual Button cmdNext
		{
			get
			{
				stackVariable1 = this._cmdNext;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdNext_Click);
				Button button = this._cmdNext;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdNext = value;
				button = this._cmdNext;
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

		internal virtual RadioButton optDailyUpload
		{
			get
			{
				stackVariable1 = this._optDailyUpload;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.optDailyUpload_Click);
				RadioButton radioButton = this._optDailyUpload;
				if (radioButton != null)
				{
					radioButton.Click -= eventHandler;
				}
				this._optDailyUpload = value;
				radioButton = this._optDailyUpload;
				if (radioButton != null)
				{
					radioButton.Click += eventHandler;
				}
			}
		}

		internal virtual RadioButton optDirect
		{
			get
			{
				stackVariable1 = this._optDirect;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.optDirect_CheckedChanged);
				RadioButton radioButton = this._optDirect;
				if (radioButton != null)
				{
					radioButton.CheckedChanged -= eventHandler;
				}
				this._optDirect = value;
				radioButton = this._optDirect;
				if (radioButton != null)
				{
					radioButton.CheckedChanged += eventHandler;
				}
			}
		}

		internal virtual RadioButton optFileUp
		{
			get
			{
				stackVariable1 = this._optFileUp;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.optFileUp_Click);
				RadioButton radioButton = this._optFileUp;
				if (radioButton != null)
				{
					radioButton.Click -= eventHandler;
				}
				this._optFileUp = value;
				radioButton = this._optFileUp;
				if (radioButton != null)
				{
					radioButton.Click += eventHandler;
				}
			}
		}

		internal virtual RadioButton optOpenload
		{
			get
			{
				stackVariable1 = this._optOpenload;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.optOpenload_Click);
				RadioButton radioButton = this._optOpenload;
				if (radioButton != null)
				{
					radioButton.Click -= eventHandler;
				}
				this._optOpenload = value;
				radioButton = this._optOpenload;
				if (radioButton != null)
				{
					radioButton.Click += eventHandler;
				}
			}
		}

		internal virtual RadioButton optSendSpace
		{
			get
			{
				stackVariable1 = this._optSendSpace;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.optSendSpace_Click);
				RadioButton radioButton = this._optSendSpace;
				if (radioButton != null)
				{
					radioButton.Click -= eventHandler;
				}
				this._optSendSpace = value;
				radioButton = this._optSendSpace;
				if (radioButton != null)
				{
					radioButton.Click += eventHandler;
				}
			}
		}

		internal virtual TextBox txtDailyUpload
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtDirect
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtFileUp
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtOpenload
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtSendspace
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public URLInstall()
		{
			this.InitializeComponent();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdNext_Click(object sender, EventArgs e)
		{
			string text = null;
			string str = null;
			int num = 0;
			if (!this.optDailyUpload.Checked)
			{
				text = this.txtDirect.Text;
				str = string.Concat(Path.GetFileNameWithoutExtension(text), ".ipa");
			}
			else
			{
				num = URLInstall.DailyUpload(this.txtDailyUpload.Text, ref text, ref str);
			}
			if (num >= 0)
			{
				Common.Download(new DownloadProgress(), text, str);
				base.Close();
			}
			else
			{
				Interaction.MsgBox(string.Concat("Cannot download file! Is your link correct? ", num.ToString()), MsgBoxStyle.OkOnly, null);
			}
		}

		public static int DailyUpload(string url, ref string ipaLink, ref string ipaName)
		{
			int num;
			string str;
			string str1 = null;
			string str2 = null;
			string str3 = null;
			string str4 = null;
			WebConsole webConsole = new WebConsole();
			string str5 = webConsole.http(url, "");
			int num1 = str5.IndexOf("name=\"fname\"");
			if (num1 > 0)
			{
				str = Conversions.ToString(webConsole.getKeyValue(str5, "value", ref str1, checked(num1 + 1), true, "\""));
				if (Operators.CompareString(str, "", false) == 0)
				{
					num1 = str5.IndexOf("name=\"id\"");
					if (num1 != -1)
					{
						str = Conversions.ToString(webConsole.getKeyValue(str5, "value", ref str4, checked(num1 + 1), true, "\""));
						if (Operators.CompareString(str, "", false) != 0)
						{
							num = -2;
							return num;
						}
						str5 = webConsole.http(url, string.Concat(new string[] { "op=download1&usr_login=&id=", str4, "&fname=", HttpUtility.UrlEncode(str1), "&referer=&method_free=Free+Download" }));
					}
					else
					{
						num = -1;
						return num;
					}
				}
				else
				{
					num = -2;
					return num;
				}
			}
			num1 = str5.IndexOf("name=\"id\"");
			if (num1 != -1)
			{
				str = Conversions.ToString(webConsole.getKeyValue(str5, "value", ref str2, checked(num1 + 1), true, "\""));
				if (Operators.CompareString(str, "", false) == 0)
				{
					num1 = str5.IndexOf("name=\"rand\"");
					if (num1 != -1)
					{
						str = Conversions.ToString(webConsole.getKeyValue(str5, "value", ref str3, checked(num1 + 1), true, "\""));
						if (Operators.CompareString(str, "", false) == 0)
						{
							Thread.Sleep(5000);
							str = webConsole.http(url, string.Concat(new string[] { "op=download2&id=", str2, "&rand=", str3, "&referer=&method_free=&method_premium=&down_script=1&fs_download_file=" }));
							num1 = str.IndexOf("This direct link will be available for your IP");
							if (num1 != -1)
							{
								str = Conversions.ToString(webConsole.getKeyValue(str, "href", ref ipaLink, checked(num1 + 1), true, "\""));
								if (Operators.CompareString(str, "", false) == 0)
								{
									ipaName = Path.GetFileName(ipaLink);
									num = 0;
								}
								else
								{
									num = -7;
								}
							}
							else
							{
								File.WriteAllText("dl.html", str);
								num = -5;
							}
						}
						else
						{
							num = -4;
						}
					}
					else
					{
						num = -3;
					}
				}
				else
				{
					num = -2;
				}
			}
			else
			{
				num = -1;
			}
			return num;
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
			this.Label1 = new Label();
			this.optSendSpace = new RadioButton();
			this.optDailyUpload = new RadioButton();
			this.optFileUp = new RadioButton();
			this.txtSendspace = new TextBox();
			this.txtDailyUpload = new TextBox();
			this.txtFileUp = new TextBox();
			this.cmdNext = new Button();
			this.cmdClose = new Button();
			this.txtOpenload = new TextBox();
			this.optOpenload = new RadioButton();
			this.txtDirect = new TextBox();
			this.optDirect = new RadioButton();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(3, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(130, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Enter URL of IPA to install";
			this.optSendSpace.AutoSize = true;
			this.optSendSpace.Location = new Point(6, 160);
			this.optSendSpace.Name = "optSendSpace";
			this.optSendSpace.Size = new System.Drawing.Size(102, 17);
			this.optSendSpace.TabIndex = 1;
			this.optSendSpace.Text = "Sendspace.com";
			this.optSendSpace.UseVisualStyleBackColor = true;
			this.optSendSpace.Visible = false;
			this.optDailyUpload.AutoSize = true;
			this.optDailyUpload.Checked = true;
			this.optDailyUpload.Location = new Point(6, 39);
			this.optDailyUpload.Name = "optDailyUpload";
			this.optDailyUpload.Size = new System.Drawing.Size(103, 17);
			this.optDailyUpload.TabIndex = 2;
			this.optDailyUpload.TabStop = true;
			this.optDailyUpload.Text = "Dailyuploads.net";
			this.optDailyUpload.UseVisualStyleBackColor = true;
			this.optFileUp.AutoSize = true;
			this.optFileUp.Location = new Point(6, 196);
			this.optFileUp.Name = "optFileUp";
			this.optFileUp.Size = new System.Drawing.Size(77, 17);
			this.optFileUp.TabIndex = 3;
			this.optFileUp.Text = "Filepup.net";
			this.optFileUp.UseVisualStyleBackColor = true;
			this.optFileUp.Visible = false;
			this.txtSendspace.Location = new Point(115, 160);
			this.txtSendspace.Name = "txtSendspace";
			this.txtSendspace.Size = new System.Drawing.Size(258, 20);
			this.txtSendspace.TabIndex = 4;
			this.txtSendspace.Visible = false;
			this.txtDailyUpload.Location = new Point(115, 39);
			this.txtDailyUpload.Name = "txtDailyUpload";
			this.txtDailyUpload.Size = new System.Drawing.Size(258, 20);
			this.txtDailyUpload.TabIndex = 5;
			this.txtFileUp.Location = new Point(115, 195);
			this.txtFileUp.Name = "txtFileUp";
			this.txtFileUp.Size = new System.Drawing.Size(258, 20);
			this.txtFileUp.TabIndex = 6;
			this.txtFileUp.Visible = false;
			this.cmdNext.Location = new Point(207, 110);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(75, 23);
			this.cmdNext.TabIndex = 7;
			this.cmdNext.Text = "Next";
			this.cmdNext.UseVisualStyleBackColor = true;
			this.cmdClose.Location = new Point(114, 110);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 8;
			this.cmdClose.Text = "Cancel";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.txtOpenload.Location = new Point(115, 231);
			this.txtOpenload.Name = "txtOpenload";
			this.txtOpenload.Size = new System.Drawing.Size(258, 20);
			this.txtOpenload.TabIndex = 10;
			this.txtOpenload.Visible = false;
			this.optOpenload.AutoSize = true;
			this.optOpenload.Location = new Point(6, 232);
			this.optOpenload.Name = "optOpenload";
			this.optOpenload.Size = new System.Drawing.Size(86, 17);
			this.optOpenload.TabIndex = 9;
			this.optOpenload.Text = "Openload.co";
			this.optOpenload.UseVisualStyleBackColor = true;
			this.optOpenload.Visible = false;
			this.txtDirect.Location = new Point(114, 72);
			this.txtDirect.Name = "txtDirect";
			this.txtDirect.Size = new System.Drawing.Size(258, 20);
			this.txtDirect.TabIndex = 12;
			this.optDirect.AutoSize = true;
			this.optDirect.Location = new Point(5, 72);
			this.optDirect.Name = "optDirect";
			this.optDirect.Size = new System.Drawing.Size(104, 17);
			this.optDirect.TabIndex = 11;
			this.optDirect.Text = "Direct Download";
			this.optDirect.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(385, 145);
			base.Controls.Add(this.txtDirect);
			base.Controls.Add(this.optDirect);
			base.Controls.Add(this.txtOpenload);
			base.Controls.Add(this.optOpenload);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdNext);
			base.Controls.Add(this.txtFileUp);
			base.Controls.Add(this.txtDailyUpload);
			base.Controls.Add(this.txtSendspace);
			base.Controls.Add(this.optFileUp);
			base.Controls.Add(this.optDailyUpload);
			base.Controls.Add(this.optSendSpace);
			base.Controls.Add(this.Label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "URLInstall";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Install from URL";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void optDailyUpload_Click(object sender, EventArgs e)
		{
			this.txtDailyUpload.Enabled = true;
			this.txtFileUp.Enabled = false;
			this.txtOpenload.Enabled = false;
			this.txtSendspace.Enabled = false;
			this.txtDirect.Enabled = false;
		}

		private void optDirect_CheckedChanged(object sender, EventArgs e)
		{
			this.txtDailyUpload.Enabled = false;
			this.txtFileUp.Enabled = false;
			this.txtOpenload.Enabled = false;
			this.txtSendspace.Enabled = false;
			this.txtDirect.Enabled = true;
		}

		private void optFileUp_Click(object sender, EventArgs e)
		{
			this.txtDailyUpload.Enabled = false;
			this.txtFileUp.Enabled = true;
			this.txtOpenload.Enabled = false;
			this.txtSendspace.Enabled = false;
			this.txtDirect.Enabled = false;
		}

		private void optOpenload_Click(object sender, EventArgs e)
		{
			this.txtDailyUpload.Enabled = false;
			this.txtFileUp.Enabled = false;
			this.txtOpenload.Enabled = true;
			this.txtSendspace.Enabled = false;
			this.txtDirect.Enabled = false;
		}

		private void optSendSpace_Click(object sender, EventArgs e)
		{
			this.txtDailyUpload.Enabled = false;
			this.txtFileUp.Enabled = false;
			this.txtOpenload.Enabled = false;
			this.txtSendspace.Enabled = true;
			this.txtDirect.Enabled = false;
		}
	}
}