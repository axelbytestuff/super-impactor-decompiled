using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class UpdateCydia : Form
	{
		private IContainer components;

		private bool bComplete;

		private bool bAsync;

		private int CrrLoadCydiaId;

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

		internal virtual Label lblCydia
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

		public UpdateCydia()
		{
			this.bComplete = false;
			this.bAsync = false;
			this.CrrLoadCydiaId = -1;
			this.InitializeComponent();
		}

		private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Dictionary<int, string>.Enumerator enumerator = new Dictionary<int, string>.Enumerator();
			Thread.Sleep(2000);
			UpdateCydia.ChangeTextsSafe changeTextsSafe = new UpdateCydia.ChangeTextsSafe(this.ChangeTexts);
			UpdateCydia.CompleteSafe completeSafe = new UpdateCydia.CompleteSafe(this.Complete);
			Dictionary<int, string> cydiaRepos = Database.GetCydiaRepos(false);
			try
			{
				enumerator = cydiaRepos.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, string> current = enumerator.Current;
					if (this.CrrLoadCydiaId != -1)
					{
						if (this.CrrLoadCydiaId != current.Key)
						{
							goto Label1;
						}
					}
					if (!this.bAsync)
					{
						base.Invoke(changeTextsSafe, new object[] { current.Value, 0 });
					}
					File.Delete("Packages");
					CydiaRepoManager.LoadPackages(current.Value);
					if (File.Exists("Packages"))
					{
						string str = string.Concat("DELETE FROM list_app WHERE cydia_repos=", Conversions.ToString(current.Key));
						(new SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery();
						if (!this.bAsync)
						{
							CydiaRepoManager.ParsePackages(current.Key, this, changeTextsSafe, current.Value);
						}
						else
						{
							CydiaRepoManager.ParsePackages(current.Key, null, null, current.Value);
						}
					}
					if (this.BackgroundWorker1.CancellationPending)
					{
						if (!this.bAsync)
						{
							base.Invoke(completeSafe, new object[] { true });
						}
						return;
					}
				Label1:
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (!this.bAsync)
			{
				base.Invoke(completeSafe, new object[] { false });
			}
		}

		private void ChangeTexts(string cydia, long percent)
		{
			if (Operators.CompareString(cydia, "", false) != 0)
			{
				this.lblCydia.Text = string.Concat("Repos: ", cydia);
			}
			this.ProgressBar1.Value = checked((int)percent);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.BackgroundWorker1.CancelAsync();
		}

		private void Complete(bool cancelled)
		{
			if (!cancelled)
			{
				this.bComplete = true;
				if (this.CrrLoadCydiaId != -1)
				{
					Interaction.MsgBox("Add Repos completed!", MsgBoxStyle.OkOnly, null);
				}
				else
				{
					Interaction.MsgBox("Update all Repos completed!", MsgBoxStyle.OkOnly, null);
				}
				base.Close();
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
			this.lblSpeed = new Label();
			this.lblFileSize = new Label();
			this.ProgressBar1 = new ProgressBar();
			this.Label1 = new Label();
			this.cmdCancel = new Button();
			this.BackgroundWorker1 = new BackgroundWorker();
			this.lblCydia = new Label();
			base.SuspendLayout();
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new Point(219, 38);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(0, 13);
			this.lblSpeed.TabIndex = 15;
			this.lblFileSize.AutoSize = true;
			this.lblFileSize.Location = new Point(62, 38);
			this.lblFileSize.Name = "lblFileSize";
			this.lblFileSize.Size = new System.Drawing.Size(0, 13);
			this.lblFileSize.TabIndex = 14;
			this.ProgressBar1.Location = new Point(13, 53);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(414, 23);
			this.ProgressBar1.TabIndex = 13;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(10, 34);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(111, 13);
			this.Label1.TabIndex = 11;
			this.Label1.Text = "Update apps progress";
			this.cmdCancel.Location = new Point(352, 11);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.lblCydia.AutoSize = true;
			this.lblCydia.Location = new Point(10, 10);
			this.lblCydia.Name = "lblCydia";
			this.lblCydia.Size = new System.Drawing.Size(41, 13);
			this.lblCydia.TabIndex = 16;
			this.lblCydia.Text = "Repos:";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(439, 85);
			base.ControlBox = false;
			base.Controls.Add(this.lblSpeed);
			base.Controls.Add(this.lblFileSize);
			base.Controls.Add(this.ProgressBar1);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.lblCydia);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UpdateCydia";
			this.Text = "Update Reposes";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public bool LoadApp(int cydiaId)
		{
			this.CrrLoadCydiaId = cydiaId;
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker1.RunWorkerAsync();
			base.ShowDialog();
			return this.bComplete;
		}

		private void ProgressBar1_Click(object sender, EventArgs e)
		{
		}

		public bool UpdateApp()
		{
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker1.RunWorkerAsync();
			base.Show();
			return this.bComplete;
		}

		public void UpdateAppAsync()
		{
			this.bAsync = true;
			this.BackgroundWorker1.WorkerSupportsCancellation = true;
			this.BackgroundWorker1.RunWorkerAsync();
		}

		public delegate void ChangeTextsSafe(string cydia, long percent);

		public delegate void CompleteSafe(bool cancelled);
	}
}