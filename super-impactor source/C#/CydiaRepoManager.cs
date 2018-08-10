using ICSharpCode.SharpZipLib.BZip2;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class CydiaRepoManager : Form
	{
		private IContainer components;

		internal virtual Button cmdAdd
		{
			get
			{
				stackVariable1 = this._cmdAdd;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdAdd_Click);
				Button button = this._cmdAdd;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdAdd = value;
				button = this._cmdAdd;
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

		public CydiaRepoManager()
		{
			base.Load += new EventHandler(this.CydiaRepoManager_Load);
			this.InitializeComponent();
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			string str = Interaction.InputBox("Enter URL of Cydia Repos", "Add Cydia Repos", "", -1, -1);
			if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
			{
				if (!str.StartsWith("http"))
				{
					str = string.Concat("http://", str);
				}
				int count = checked(this.lstCydia.Items.Count - 1);
				int num = 0;
				while (num <= count)
				{
					if (Operators.CompareString(this.lstCydia.Items[num].SubItems[1].Text, str, false) != 0)
					{
						num = checked(num + 1);
					}
					else
					{
						Interaction.MsgBox("Cydia existed!", MsgBoxStyle.OkOnly, "Error");
						return;
					}
				}
				File.Delete("Release.txt");
				string str1 = "Noname";
				try
				{
					(new WebClient()).DownloadFile(string.Concat(str, "/Release"), "Release.txt");
					string[] strArrays = File.ReadAllLines("Release.txt");
					int num1 = Information.LBound(strArrays, 1);
					int num2 = Information.UBound(strArrays, 1);
					int num3 = num1;
					while (num3 <= num2)
					{
						if (!strArrays[num3].StartsWith("Label:"))
						{
							num3 = checked(num3 + 1);
						}
						else
						{
							str1 = strArrays[num3].Substring(6);
							break;
						}
					}
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					ProjectData.ClearProjectError();
				}
				SQLiteCommand sQLiteCommand = new SQLiteCommand("INSERT INTO cydia_repos(name, path) VALUES(@name, @path)", AppConst.m_dbConnection);
				SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
				parameters.AddWithValue("@name", str1);
				parameters.AddWithValue("@path", str);
				parameters = null;
				sQLiteCommand.ExecuteNonQuery();
				object objectValue = RuntimeHelpers.GetObjectValue(this.LoadCydiaRepos(str));
				CydiaRepoManager.LoadPackages(str);
				if (File.Exists("Packages"))
				{
					CydiaRepoManager.ParsePackages(Conversions.ToInteger(objectValue), null, null, "");
				}
			}
			else
			{
				Interaction.MsgBox("Incorrect URL", MsgBoxStyle.OkOnly, "Error");
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdRemove_Click(object sender, EventArgs e)
		{
			if (this.lstCydia.SelectedItems.Count > 0)
			{
				ListViewItem item = this.lstCydia.SelectedItems[0];
				string str = string.Concat("select * from cydia_repos WHERE path='", item.SubItems[1].Text, "'");
				SQLiteDataReader sQLiteDataReader = (new SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteReader();
				long num = (long)-1;
				if (sQLiteDataReader.Read())
				{
					num = Conversions.ToLong(sQLiteDataReader.get_Item("id"));
				}
				str = string.Concat("DELETE FROM cydia_repos WHERE id=", Conversions.ToString(num));
				(new SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery();
				str = string.Concat("DELETE FROM list_app WHERE cydia_repos=", Conversions.ToString(num));
				(new SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery();
				this.LoadCydiaRepos("");
			}
		}

		private void CydiaRepoManager_Load(object sender, EventArgs e)
		{
			this.LoadCydiaRepos("");
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
			this.lstCydia = new ListView();
			this.Label1 = new Label();
			this.cmdAdd = new Button();
			this.cmdRemove = new Button();
			this.cmdClose = new Button();
			base.SuspendLayout();
			this.lstCydia.FullRowSelect = true;
			this.lstCydia.GridLines = true;
			this.lstCydia.HideSelection = false;
			this.lstCydia.Location = new Point(8, 30);
			this.lstCydia.MultiSelect = false;
			this.lstCydia.Name = "lstCydia";
			this.lstCydia.Size = new System.Drawing.Size(288, 345);
			this.lstCydia.TabIndex = 0;
			this.lstCydia.UseCompatibleStateImageBehavior = false;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(8, 11);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(98, 13);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "List of Cydia Repos";
			this.cmdAdd.Location = new Point(310, 31);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(106, 24);
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.UseVisualStyleBackColor = true;
			this.cmdRemove.Location = new Point(310, 64);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(104, 25);
			this.cmdRemove.TabIndex = 3;
			this.cmdRemove.Text = "Remove";
			this.cmdRemove.UseVisualStyleBackColor = true;
			this.cmdClose.Location = new Point(310, 350);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(104, 25);
			this.cmdClose.TabIndex = 4;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(430, 383);
			base.ControlBox = false;
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdRemove);
			base.Controls.Add(this.cmdAdd);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.lstCydia);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CydiaRepoManager";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Cydia Repos Manager";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private object LoadCydiaRepos(string cydiaReposName = "")
		{
			SQLiteDataReader sQLiteDataReader = (new SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader();
			this.lstCydia.Clear();
			this.lstCydia.View = View.Details;
			this.lstCydia.Columns.Add("Name");
			this.lstCydia.Columns.Add("Cydia URL");
			this.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			int integer = -1;
			while (sQLiteDataReader.Read())
			{
				ListViewItem listViewItem = new ListViewItem()
				{
					Text = Conversions.ToString(sQLiteDataReader.get_Item("name"))
				};
				NewLateBinding.LateCall(listViewItem.SubItems, null, "Add", new object[] { sQLiteDataReader.get_Item("path") }, null, null, null, true);
				this.lstCydia.Items.Add(listViewItem);
				if (Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("path"), cydiaReposName, false))
				{
					integer = Conversions.ToInteger(sQLiteDataReader.get_Item("id"));
				}
			}
			return integer;
		}

		public static void LoadPackages(string cydiaRepos)
		{
			WebClient webClient = new WebClient();
			try
			{
				webClient.DownloadFile(string.Concat(cydiaRepos, "/Packages.bz2"), "Packages.bz2");
				FileStream fileStream = (new FileInfo("Packages.bz2")).OpenRead();
				using (fileStream)
				{
					FileStream fileStream1 = File.Create("Packages");
					using (fileStream1)
					{
						BZip2.Decompress(fileStream, fileStream1, true);
					}
				}
			}
			catch (Exception exception1)
			{
				ProjectData.SetProjectError(exception1);
				try
				{
					webClient.DownloadFile(string.Concat(cydiaRepos, "/Packages"), "Packages");
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					Interaction.MsgBox("Invalid cydia", MsgBoxStyle.OkOnly, null);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static void ParsePackages(int cydiaId, UpdateCydia frm = null, object fn = null, string cydiaUrl = "")
		{
			string str = File.ReadAllText("Packages");
			string[] strArrays = str.Split(new string[] { "Package:" }, StringSplitOptions.RemoveEmptyEntries);
			string str1 = "INSERT INTO list_app(cydia_repos,package,version,section,depends,arch,filename,size,icon,description,name,author,homepage) \r\n                                                VALUES(@cydia_repos,@package,@version,@section,@depends,@arch,@filename,@size,@icon,@description,@name,@author,@homepage)";
			SQLiteTransaction sQLiteTransaction = AppConst.m_dbConnection.BeginTransaction();
			int num = Information.LBound(strArrays, 1);
			int num1 = Information.UBound(strArrays, 1);
			for (int i = num; i <= num1; i = checked(i + 1))
			{
				string[] strArrays1 = strArrays[i].Split(new char[] { '\n' });
				AppInfos appInfo = new AppInfos()
				{
					Package = Strings.Trim(strArrays1[0])
				};
				int num2 = Information.UBound(strArrays1, 1);
				for (int j = 1; j <= num2; j = checked(j + 1))
				{
					string str2 = strArrays1[j];
					if (str2.StartsWith("Section:"))
					{
						appInfo.Section = Strings.Trim(strArrays1[j].Substring(8));
					}
					else if (str2.StartsWith("Version:"))
					{
						appInfo.Version = Strings.Trim(strArrays1[j].Substring(8));
					}
					else if (str2.StartsWith("Depends:"))
					{
						appInfo.Depends = Strings.Trim(strArrays1[j].Substring(8));
					}
					else if (str2.StartsWith("Architecture:"))
					{
						appInfo.Architecture = Strings.Trim(strArrays1[j].Substring(13));
					}
					else if (str2.StartsWith("Filename:"))
					{
						appInfo.Filename = Strings.Trim(strArrays1[j].Substring(9));
						if (!appInfo.Filename.StartsWith("http"))
						{
							appInfo.Filename = string.Concat(cydiaUrl, "/", appInfo.Filename);
						}
					}
					else if (str2.StartsWith("Size:"))
					{
						appInfo.Size = Strings.Trim(strArrays1[j].Substring(5));
					}
					else if (str2.StartsWith("Icon:"))
					{
						appInfo.Icon = Strings.Trim(strArrays1[j].Substring(5));
					}
					else if (str2.StartsWith("Description:"))
					{
						appInfo.Description = Strings.Trim(strArrays1[j].Substring(12));
					}
					else if (str2.StartsWith("Name:"))
					{
						appInfo.Name = Strings.Trim(strArrays1[j].Substring(5));
					}
					else if (str2.StartsWith("Author:"))
					{
						appInfo.Author = Strings.Trim(strArrays1[j].Substring(7));
					}
					else if (str2.StartsWith("Homepage:"))
					{
						appInfo.Homepage = Strings.Trim(strArrays1[j].Substring(9));
					}
				}
				SQLiteCommand sQLiteCommand = new SQLiteCommand(str1, AppConst.m_dbConnection);
				SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
				parameters.AddWithValue("@cydia_repos", cydiaId);
				parameters.AddWithValue("@package", appInfo.Package);
				parameters.AddWithValue("@version", appInfo.Version);
				parameters.AddWithValue("@section", appInfo.Section);
				parameters.AddWithValue("@depends", appInfo.Depends);
				parameters.AddWithValue("@arch", appInfo.Architecture);
				parameters.AddWithValue("@filename", appInfo.Filename);
				parameters.AddWithValue("@size", appInfo.Size);
				parameters.AddWithValue("@icon", appInfo.Icon);
				parameters.AddWithValue("@description", appInfo.Description);
				parameters.AddWithValue("@name", appInfo.Name);
				parameters.AddWithValue("@author", appInfo.Author);
				parameters.AddWithValue("@homepage", appInfo.Homepage);
				parameters = null;
				sQLiteCommand.ExecuteNonQuery();
				if (i % 10 == 0)
				{
					if (frm != null)
					{
						frm.Invoke((Delegate)fn, new object[] { "", checked((int)Math.Round((double)(checked(i * 100)) / (double)Information.UBound(strArrays, 1))) });
					}
				}
			}
			sQLiteTransaction.Commit();
		}
	}
}