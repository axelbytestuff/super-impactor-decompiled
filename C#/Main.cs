using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class Main : Form
	{
		public const long LVM_FIRST = 4096L;

		public const long LVM_SETICONSPACING = 4149L;

		private IContainer components;

		internal virtual ToolStripMenuItem AboutToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._AboutToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AboutToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._AboutToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._AboutToolStripMenuItem = value;
				toolStripMenuItem = this._AboutToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem AboutToolStripMenuItem1
		{
			get
			{
				stackVariable1 = this._AboutToolStripMenuItem1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AboutToolStripMenuItem1_Click);
				ToolStripMenuItem toolStripMenuItem = this._AboutToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._AboutToolStripMenuItem1 = value;
				toolStripMenuItem = this._AboutToolStripMenuItem1;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem AppleAccountsManagerMenuItem
		{
			get
			{
				stackVariable1 = this._AppleAccountsManagerMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.AppleAccountsManagerMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._AppleAccountsManagerMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._AppleAccountsManagerMenuItem = value;
				toolStripMenuItem = this._AppleAccountsManagerMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdHot
		{
			get
			{
				stackVariable1 = this._cmdHot;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button1_Click);
				Button button = this._cmdHot;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdHot = value;
				button = this._cmdHot;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdUpdate
		{
			get
			{
				stackVariable1 = this._cmdUpdate;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdUpdate_Click);
				Button button = this._cmdUpdate;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdUpdate = value;
				button = this._cmdUpdate;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem CydiaReposManagerMenuItem
		{
			get
			{
				stackVariable1 = this._CydiaReposManagerMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.CydiaReposManagerMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._CydiaReposManagerMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._CydiaReposManagerMenuItem = value;
				toolStripMenuItem = this._CydiaReposManagerMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem DeleteAppIDToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._DeleteAppIDToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.DeleteAppIDToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._DeleteAppIDToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._DeleteAppIDToolStripMenuItem = value;
				toolStripMenuItem = this._DeleteAppIDToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem DownloadedFilesToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._DownloadedFilesToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.DownloadedFilesToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._DownloadedFilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._DownloadedFilesToolStripMenuItem = value;
				toolStripMenuItem = this._DownloadedFilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem EditToolStripMenuItem
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ToolStripMenuItem FileToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._FileToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.FileToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._FileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._FileToolStripMenuItem = value;
				toolStripMenuItem = this._FileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem FromDownloadedFilesToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._FromDownloadedFilesToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.FromDownloadedFilesToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._FromDownloadedFilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._FromDownloadedFilesToolStripMenuItem = value;
				toolStripMenuItem = this._FromDownloadedFilesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem HelpToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._HelpToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.HelpToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._HelpToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._HelpToolStripMenuItem = value;
				toolStripMenuItem = this._HelpToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem InstallFromFileToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._InstallFromFileToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.InstallFromFileToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._InstallFromFileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._InstallFromFileToolStripMenuItem = value;
				toolStripMenuItem = this._InstallFromFileToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem InstallFromReposToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._InstallFromReposToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.InstallFromReposToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._InstallFromReposToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._InstallFromReposToolStripMenuItem = value;
				toolStripMenuItem = this._InstallFromReposToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual ToolStripMenuItem InstallFromURLToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._InstallFromURLToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.InstallFromURLToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._InstallFromURLToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._InstallFromURLToolStripMenuItem = value;
				toolStripMenuItem = this._InstallFromURLToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual Label Label1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ToolStripStatusLabel lblStatusBar
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ListViewEx lstApps
		{
			get
			{
				stackVariable1 = this._lstApps;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lstApps_SelectedIndexChanged);
				EventHandler eventHandler1 = new EventHandler(this.lstApps_DoubleClick);
				ListViewEx listViewEx = this._lstApps;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged -= eventHandler;
					listViewEx.DoubleClick -= eventHandler1;
				}
				this._lstApps = value;
				listViewEx = this._lstApps;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged += eventHandler;
					listViewEx.DoubleClick += eventHandler1;
				}
			}
		}

		internal virtual MenuStrip MenuStrip1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ToolStripMenuItem RevokeCertificatesToolStripMenuItem
		{
			get
			{
				stackVariable1 = this._RevokeCertificatesToolStripMenuItem;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.RevokeCertificatesToolStripMenuItem_Click);
				ToolStripMenuItem toolStripMenuItem = this._RevokeCertificatesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click -= eventHandler;
				}
				this._RevokeCertificatesToolStripMenuItem = value;
				toolStripMenuItem = this._RevokeCertificatesToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Click += eventHandler;
				}
			}
		}

		internal virtual StatusStrip StatusStrip1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ToolStripMenuItem ToolsToolStripMenuItem
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtAppSearch
		{
			get
			{
				stackVariable1 = this._txtAppSearch;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.txtAppSearch_TextChanged);
				KeyPressEventHandler keyPressEventHandler = new KeyPressEventHandler(this.txtAppSearch_KeyPress);
				TextBox textBox = this._txtAppSearch;
				if (textBox != null)
				{
					textBox.TextChanged -= eventHandler;
					textBox.KeyPress -= keyPressEventHandler;
				}
				this._txtAppSearch = value;
				textBox = this._txtAppSearch;
				if (textBox != null)
				{
					textBox.TextChanged += eventHandler;
					textBox.KeyPress += keyPressEventHandler;
				}
			}
		}

		internal virtual WebBrowser WebBrowser1
		{
			get
			{
				stackVariable1 = this._WebBrowser1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				WebBrowserNavigatingEventHandler webBrowserNavigatingEventHandler = new WebBrowserNavigatingEventHandler(this.WebBrowser1_Navigating);
				WebBrowser webBrowser = this._WebBrowser1;
				if (webBrowser != null)
				{
					webBrowser.Navigating -= webBrowserNavigatingEventHandler;
				}
				this._WebBrowser1 = value;
				webBrowser = this._WebBrowser1;
				if (webBrowser != null)
				{
					webBrowser.Navigating += webBrowserNavigatingEventHandler;
				}
			}
		}

		public Main()
		{
			base.Load += new EventHandler(this.Main_Load);
			this.InitializeComponent();
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Interaction.MsgBox("Copyright @2017 - TuanHa Jsc\r\n\r\nThis program use: \r\n- libimobiledevice team: http://www.libimobiledevice.org/\r\n- Copyright (c) 1998-2017 The OpenSSL Project, Copyright (C) 1995-1998 Eric Young (eay@cryptsoft.com). All rights reserved.\r\n- isign by Neil Kandalgaonkar", MsgBoxStyle.OkOnly, "About");
		}

		private void AppleAccountsManagerMenuItem_Click(object sender, EventArgs e)
		{
			(new AppleAccounts()).ShowDialog();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.Visible = true;
			this.lstApps.Visible = false;
		}

		private void cmdUpdate_Click(object sender, EventArgs e)
		{
			if ((new UpdateCydia()).UpdateApp())
			{
				this.ReloadApps("");
				Interaction.MsgBox("Update all cydia completed!", MsgBoxStyle.OkOnly, null);
			}
		}

		private void CydiaReposManagerMenuItem_Click(object sender, EventArgs e)
		{
			(new CydiaRepoManager()).ShowDialog();
			this.ReloadApps("");
		}

		private void DeleteAppIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new AppIdDelete()).ShowDialog();
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

		private void DownloadedFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new DownloadFiles()).ShowDialog();
		}

		private void FileToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void FromDownloadedFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new DownloadFiles()).ShowDialog();
		}

		private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.superimpactor.net/help");
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Main));
			this.MenuStrip1 = new MenuStrip();
			this.FileToolStripMenuItem = new ToolStripMenuItem();
			this.InstallFromURLToolStripMenuItem = new ToolStripMenuItem();
			this.InstallFromReposToolStripMenuItem = new ToolStripMenuItem();
			this.InstallFromFileToolStripMenuItem = new ToolStripMenuItem();
			this.FromDownloadedFilesToolStripMenuItem = new ToolStripMenuItem();
			this.EditToolStripMenuItem = new ToolStripMenuItem();
			this.CydiaReposManagerMenuItem = new ToolStripMenuItem();
			this.AppleAccountsManagerMenuItem = new ToolStripMenuItem();
			this.DownloadedFilesToolStripMenuItem = new ToolStripMenuItem();
			this.ToolsToolStripMenuItem = new ToolStripMenuItem();
			this.RevokeCertificatesToolStripMenuItem = new ToolStripMenuItem();
			this.DeleteAppIDToolStripMenuItem = new ToolStripMenuItem();
			this.AboutToolStripMenuItem = new ToolStripMenuItem();
			this.HelpToolStripMenuItem = new ToolStripMenuItem();
			this.AboutToolStripMenuItem1 = new ToolStripMenuItem();
			this.cmdHot = new Button();
			this.txtAppSearch = new TextBox();
			this.Label1 = new Label();
			this.cmdUpdate = new Button();
			this.WebBrowser1 = new WebBrowser();
			this.StatusStrip1 = new StatusStrip();
			this.lblStatusBar = new ToolStripStatusLabel();
			this.lstApps = new ListViewEx();
			this.MenuStrip1.SuspendLayout();
			this.StatusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.MenuStrip1.Items.AddRange(new ToolStripItem[] { this.FileToolStripMenuItem, this.EditToolStripMenuItem, this.ToolsToolStripMenuItem, this.AboutToolStripMenuItem });
			this.MenuStrip1.Location = new Point(0, 0);
			this.MenuStrip1.Name = "MenuStrip1";
			this.MenuStrip1.Size = new System.Drawing.Size(474, 24);
			this.MenuStrip1.TabIndex = 0;
			this.MenuStrip1.Text = "MenuStrip1";
			this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.InstallFromURLToolStripMenuItem, this.InstallFromReposToolStripMenuItem, this.InstallFromFileToolStripMenuItem, this.FromDownloadedFilesToolStripMenuItem });
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.FileToolStripMenuItem.Text = "Install IPA";
			this.InstallFromURLToolStripMenuItem.Name = "InstallFromURLToolStripMenuItem";
			this.InstallFromURLToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.InstallFromURLToolStripMenuItem.Text = "From URL";
			this.InstallFromReposToolStripMenuItem.Name = "InstallFromReposToolStripMenuItem";
			this.InstallFromReposToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.InstallFromReposToolStripMenuItem.Text = "From Repos";
			this.InstallFromFileToolStripMenuItem.Name = "InstallFromFileToolStripMenuItem";
			this.InstallFromFileToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.InstallFromFileToolStripMenuItem.Text = "From File";
			this.FromDownloadedFilesToolStripMenuItem.Name = "FromDownloadedFilesToolStripMenuItem";
			this.FromDownloadedFilesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.FromDownloadedFilesToolStripMenuItem.Text = "From Downloaded Files";
			this.EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.CydiaReposManagerMenuItem, this.AppleAccountsManagerMenuItem, this.DownloadedFilesToolStripMenuItem });
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.EditToolStripMenuItem.Text = "Setting";
			this.CydiaReposManagerMenuItem.Name = "CydiaReposManagerMenuItem";
			this.CydiaReposManagerMenuItem.Size = new System.Drawing.Size(148, 22);
			this.CydiaReposManagerMenuItem.Text = "Cydia Repos";
			this.AppleAccountsManagerMenuItem.Name = "AppleAccountsManagerMenuItem";
			this.AppleAccountsManagerMenuItem.Size = new System.Drawing.Size(148, 22);
			this.AppleAccountsManagerMenuItem.Text = "Apple Accounts";
			this.DownloadedFilesToolStripMenuItem.Name = "DownloadedFilesToolStripMenuItem";
			this.DownloadedFilesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.DownloadedFilesToolStripMenuItem.Text = "Download Files";
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RevokeCertificatesToolStripMenuItem, this.DeleteAppIDToolStripMenuItem });
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.ToolsToolStripMenuItem.Text = "Tools";
			this.RevokeCertificatesToolStripMenuItem.Name = "RevokeCertificatesToolStripMenuItem";
			this.RevokeCertificatesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.RevokeCertificatesToolStripMenuItem.Text = "Revoke Certificates";
			this.DeleteAppIDToolStripMenuItem.Name = "DeleteAppIDToolStripMenuItem";
			this.DeleteAppIDToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.DeleteAppIDToolStripMenuItem.Text = "Delete App ID";
			this.AboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.HelpToolStripMenuItem, this.AboutToolStripMenuItem1 });
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.AboutToolStripMenuItem.Text = "Help";
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.HelpToolStripMenuItem.Text = "Help";
			this.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1";
			this.AboutToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			this.AboutToolStripMenuItem1.Text = "About";
			this.cmdHot.Location = new Point(302, 33);
			this.cmdHot.Name = "cmdHot";
			this.cmdHot.Size = new System.Drawing.Size(66, 25);
			this.cmdHot.TabIndex = 2;
			this.cmdHot.Text = "Hot Apps";
			this.cmdHot.UseVisualStyleBackColor = true;
			this.txtAppSearch.Location = new Point(76, 35);
			this.txtAppSearch.Name = "txtAppSearch";
			this.txtAppSearch.Size = new System.Drawing.Size(220, 20);
			this.txtAppSearch.TabIndex = 3;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(10, 38);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(63, 13);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "App Search";
			this.cmdUpdate.Enabled = false;
			this.cmdUpdate.Location = new Point(374, 33);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.Size = new System.Drawing.Size(88, 25);
			this.cmdUpdate.TabIndex = 6;
			this.cmdUpdate.Text = "Refresh Repos";
			this.cmdUpdate.UseVisualStyleBackColor = true;
			this.WebBrowser1.Location = new Point(12, 240);
			this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.WebBrowser1.Name = "WebBrowser1";
			this.WebBrowser1.Size = new System.Drawing.Size(449, 467);
			this.WebBrowser1.TabIndex = 7;
			this.StatusStrip1.Items.AddRange(new ToolStripItem[] { this.lblStatusBar });
			this.StatusStrip1.Location = new Point(0, 538);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(474, 22);
			this.StatusStrip1.TabIndex = 8;
			this.StatusStrip1.Text = "StatusStrip1";
			this.lblStatusBar.Name = "lblStatusBar";
			this.lblStatusBar.Size = new System.Drawing.Size(111, 17);
			this.lblStatusBar.Text = "ToolStripStatusLabel1";
			this.lstApps.BackColor = Color.White;
			this.lstApps.FullRowSelect = true;
			this.lstApps.Location = new Point(13, 68);
			this.lstApps.Name = "lstApps";
			this.lstApps.OwnerDraw = true;
			this.lstApps.Size = new System.Drawing.Size(449, 467);
			this.lstApps.TabIndex = 5;
			this.lstApps.UseCompatibleStateImageBehavior = false;
			this.lstApps.View = View.Details;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(474, 560);
			base.Controls.Add(this.StatusStrip1);
			base.Controls.Add(this.WebBrowser1);
			base.Controls.Add(this.cmdUpdate);
			base.Controls.Add(this.lstApps);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.txtAppSearch);
			base.Controls.Add(this.cmdHot);
			base.Controls.Add(this.MenuStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.MenuStrip1;
			base.MaximizeBox = false;
			base.Name = "Main";
			this.Text = "Super Impactor";
			this.MenuStrip1.ResumeLayout(false);
			this.MenuStrip1.PerformLayout();
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void InstallFromFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = "c:\\\\",
				Filter = "IPA Files (*.ipa)|*.ipa|All files (*.*)|*.*",
				FilterIndex = 2,
				RestoreDirectory = true
			};
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Install install = new Install();
				install.installFromFile(openFileDialog.FileName, "", "");
			}
		}

		private void InstallFromReposToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new CydiaRepoManager()).ShowDialog();
		}

		private void InstallFromURLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new URLInstall()).ShowDialog();
		}

		private void lstApps_DoubleClick(object sender, EventArgs e)
		{
			ExtraData tag = (ExtraData)this.lstApps.SelectedItems[0].Tag;
			(new AppDetail()).showApp(tag.AppDetailObj);
		}

		private void lstApps_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void Main_Load(object sender, EventArgs e)
		{
			try
			{
				try
				{
					AppConst.logger = LogManager.GetLogger("SuperImpactor");
					AppConst.logger.Info("Start");
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
			}
			try
			{
				try
				{
					this.WebBrowser1.Url = new Uri("https://www.iphonecake.com");
					this.WebBrowser1.ScriptErrorsSuppressed = true;
				}
				catch (Exception exception1)
				{
					ProjectData.SetProjectError(exception1);
					Interaction.MsgBox(exception1.Message, MsgBoxStyle.OkOnly, null);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
			}
			AppConst.m_rootPath = string.Concat(Application.StartupPath, "\\..\\..\\");
			AppConst.m_localTmp = Common.GetTempFolder();
			if (!File.Exists(string.Concat(AppConst.m_rootPath, "\\iaidb.sqlite")))
			{
				Interaction.MsgBox("Application error! Please install again!", MsgBoxStyle.OkOnly, "Error");
				ProjectData.EndApp();
			}
			AppConst.m_dbConnection = new SQLiteConnection(string.Concat("Data Source=", AppConst.m_rootPath, "\\iaidb.sqlite;Version=3;"));
			AppConst.m_dbConnection.Open();
			this.SetListViewSpacing(this.lstApps, 16, 16);
			AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(true);
			int num = 0;
			do
			{
				AppConst.m_randomKey = string.Concat(AppConst.m_randomKey, char.ConvertFromUtf32(checked(checked(num * 2) + 64)));
				num = checked(num + 1);
			}
			while (num <= 16);
			this.ReloadApps("");
		}

		private void ReloadApps(string search = "")
		{
			string str;
			try
			{
				str = (Operators.CompareString(search, "", false) != 0 ? string.Concat("select * from list_app where name like '%", search, "%' order by name") : "select * from list_app order by name");
				SQLiteDataReader sQLiteDataReader = (new SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteReader();
				this.lstApps.Clear();
				this.lstApps.Columns.Add("Apps", checked(base.Width - 30));
				WebClient webClient = new WebClient();
				while (sQLiteDataReader.Read())
				{
					ExtraData extraDatum = new ExtraData()
					{
						DescText = Conversions.ToString(sQLiteDataReader.get_Item("description")),
						HeaderText = Conversions.ToString(sQLiteDataReader.get_Item("name")),
						MinorText = Conversions.ToString(Operators.AddObject(Operators.AddObject(string.Concat("from ", Strings.Trim(AppConst.m_lstCydiaRepos[Conversions.ToInteger(sQLiteDataReader.get_Item("cydia_repos"))]), " ["), sQLiteDataReader.get_Item("section")), "]")),
						AppDetailObj = new AppInfos()
					};
					AppInfos appDetailObj = extraDatum.AppDetailObj;
					appDetailObj.Icon = sQLiteDataReader.get_Item("icon").ToString();
					appDetailObj.Architecture = sQLiteDataReader.get_Item("arch").ToString();
					appDetailObj.Author = sQLiteDataReader.get_Item("author").ToString();
					appDetailObj.Depends = sQLiteDataReader.get_Item("depends").ToString();
					appDetailObj.Description = sQLiteDataReader.get_Item("description").ToString();
					appDetailObj.Filename = sQLiteDataReader.get_Item("filename").ToString();
					appDetailObj.Homepage = sQLiteDataReader.get_Item("homepage").ToString();
					appDetailObj.Name = sQLiteDataReader.get_Item("name").ToString();
					appDetailObj.Package = sQLiteDataReader.get_Item("package").ToString();
					appDetailObj.Section = sQLiteDataReader.get_Item("section").ToString();
					appDetailObj.Size = sQLiteDataReader.get_Item("size").ToString();
					appDetailObj.Version = sQLiteDataReader.get_Item("version").ToString();
					appDetailObj = null;
					if (!(Operators.CompareString(extraDatum.AppDetailObj.Icon, "", false) != 0 & extraDatum.AppDetailObj.Icon.StartsWith("http")))
					{
						extraDatum.MainImage = new Bitmap(string.Concat(AppConst.m_rootPath, "\\res\\/apptype_tweak.png"));
					}
					else
					{
						extraDatum.MainImage = (Bitmap)Image.FromStream(new MemoryStream(webClient.DownloadData(extraDatum.AppDetailObj.Icon)));
					}
					this.lstApps.Items.Add("").Tag = extraDatum;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				ProjectData.ClearProjectError();
			}
		}

		private void RevokeCertificatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new CertificateDelete()).ShowDialog();
		}

		[DllImport("user32", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

		public void SetListViewSpacing(ListView lst, int x, int y)
		{
			Main.SendMessage(lst.Handle, 4149, 0, checked(checked(x * 65536) + y));
		}

		private void ThreadTask()
		{
		}

		private void txtAppSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Operators.CompareString(Conversions.ToString(e.KeyChar), "\r", false) == 0)
			{
				this.cmdHot.PerformClick();
			}
		}

		private void txtAppSearch_TextChanged(object sender, EventArgs e)
		{
			this.WebBrowser1.Visible = false;
			this.lstApps.Visible = true;
			this.ReloadApps(this.txtAppSearch.Text);
		}

		private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (Interaction.MsgBox(string.Concat("You are trying to go to:\r", e.Url.ToString(), "\rCancel Navigate?"), MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
			{
				e.Cancel = true;
			}
		}

		public delegate void InvokeDelegate();
	}
}