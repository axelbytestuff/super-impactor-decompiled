using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class DownloadFiles : Form
	{
		private IContainer components;

		internal virtual Button Button1
		{
			get
			{
				stackVariable1 = this._Button1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button1_Click);
				Button button = this._Button1;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button1 = value;
				button = this._Button1;
				if (button != null)
				{
					button.Click += eventHandler;
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

		internal virtual Button cmdRemove
		{
			get
			{
				stackVariable1 = this._cmdRemove;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdRemove_Click);
				Button button = this._cmdRemove;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdRemove = value;
				button = this._cmdRemove;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdRemoveAll
		{
			get
			{
				stackVariable1 = this._cmdRemoveAll;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdRemoveAll_Click);
				Button button = this._cmdRemoveAll;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdRemoveAll = value;
				button = this._cmdRemoveAll;
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

		internal virtual ListView lstCydia
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public DownloadFiles()
		{
			base.Load += new EventHandler(this.DownloadFiles_Load);
			this.InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (this.lstCydia.SelectedItems.Count != 0)
			{
				ListViewItem item = this.lstCydia.SelectedItems[0];
				Install install = new Install();
				install.installFromFile(string.Concat(AppConst.m_rootPath, "\\download\\", item.SubItems[0].Text), "", "");
			}
			else
			{
				Interaction.MsgBox("Please select file to install", MsgBoxStyle.OkOnly, null);
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdRemove_Click(object sender, EventArgs e)
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = this.lstCydia.SelectedItems.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ListViewItem current = (ListViewItem)enumerator.Current;
					File.Delete(string.Concat(AppConst.m_rootPath, "\\download\\", current.SubItems[0].Text));
					current.Remove();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		private void cmdRemoveAll_Click(object sender, EventArgs e)
		{
			Common.DeleteFilesFromFolder(string.Concat(AppConst.m_rootPath, "\\download\\"));
			this.lstCydia.Clear();
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

		private void DownloadFiles_Load(object sender, EventArgs e)
		{
			string str;
			double num;
			this.lstCydia.Clear();
			this.lstCydia.View = View.Details;
			this.lstCydia.Columns.Add("Name", checked(this.lstCydia.Width - 70), HorizontalAlignment.Left);
			this.lstCydia.Columns.Add("Size");
			string[] files = Directory.GetFiles(string.Concat(AppConst.m_rootPath, "\\download\\"));
			int num1 = Information.UBound(files, 1);
			for (int i = 0; i <= num1; i = checked(i + 1))
			{
				ListViewItem listViewItem = new ListViewItem();
				FileInfo fileInfo = new FileInfo(files[i]);
				listViewItem.Text = fileInfo.Name;
				if ((double)fileInfo.Length / 1024 / 1024 / 1024 >= 1)
				{
					num = Math.Round((double)fileInfo.Length / 1024 / 1024 / 1024, 2);
					str = string.Concat(num.ToString(), " GB");
				}
				else if ((double)fileInfo.Length / 1024 / 1024 < 1)
				{
					num = Math.Round((double)fileInfo.Length / 1024, 2);
					str = string.Concat(num.ToString(), " KB");
				}
				else
				{
					num = Math.Round((double)fileInfo.Length / 1024 / 1024, 2);
					str = string.Concat(num.ToString(), " MB");
				}
				listViewItem.SubItems.Add(str);
				this.lstCydia.Items.Add(listViewItem);
			}
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.cmdClose = new Button();
			this.cmdRemove = new Button();
			this.cmdRemoveAll = new Button();
			this.Label1 = new Label();
			this.lstCydia = new ListView();
			this.Button1 = new Button();
			base.SuspendLayout();
			this.cmdClose.Location = new Point(432, 361);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(104, 25);
			this.cmdClose.TabIndex = 9;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdRemove.Location = new Point(432, 61);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(104, 25);
			this.cmdRemove.TabIndex = 8;
			this.cmdRemove.Text = "Remove";
			this.cmdRemove.UseVisualStyleBackColor = true;
			this.cmdRemoveAll.Location = new Point(432, 94);
			this.cmdRemoveAll.Name = "cmdRemoveAll";
			this.cmdRemoveAll.Size = new System.Drawing.Size(104, 25);
			this.cmdRemoveAll.TabIndex = 7;
			this.cmdRemoveAll.Text = "Remove All";
			this.cmdRemoveAll.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(12, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(110, 13);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "List of Download Files";
			this.lstCydia.FullRowSelect = true;
			this.lstCydia.GridLines = true;
			this.lstCydia.HideSelection = false;
			this.lstCydia.Location = new Point(12, 28);
			this.lstCydia.Name = "lstCydia";
			this.lstCydia.Size = new System.Drawing.Size(405, 358);
			this.lstCydia.TabIndex = 5;
			this.lstCydia.UseCompatibleStateImageBehavior = false;
			this.Button1.Location = new Point(432, 28);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(104, 25);
			this.Button1.TabIndex = 10;
			this.Button1.Text = "Install";
			this.Button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(548, 398);
			base.ControlBox = false;
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdRemove);
			base.Controls.Add(this.cmdRemoveAll);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.lstCydia);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DownloadFiles";
			this.Text = "DownloadFiles";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}