using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class AppleAccounts : Form
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

		public AppleAccounts()
		{
			base.Load += new EventHandler(this.AppleAccounts_Load);
			this.InitializeComponent();
		}

		private void AppleAccounts_Load(object sender, EventArgs e)
		{
			this.LoadAccounts();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdRemove_Click(object sender, EventArgs e)
		{
			if (this.lstCydia.SelectedItems.Count <= 0)
			{
				Interaction.MsgBox("Select account to remove", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				ListViewItem item = this.lstCydia.SelectedItems[0];
				Database.DeleteAccount(item.SubItems[0].Text);
				this.LoadAccounts();
			}
		}

		private void cmdRemoveAll_Click(object sender, EventArgs e)
		{
			Database.DeleteAccounts();
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

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.cmdClose = new Button();
			this.cmdRemove = new Button();
			this.cmdRemoveAll = new Button();
			this.Label1 = new Label();
			this.lstCydia = new ListView();
			base.SuspendLayout();
			this.cmdClose.Location = new Point(262, 357);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(104, 25);
			this.cmdClose.TabIndex = 15;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdRemove.Location = new Point(262, 24);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(104, 25);
			this.cmdRemove.TabIndex = 14;
			this.cmdRemove.Text = "Remove";
			this.cmdRemove.UseVisualStyleBackColor = true;
			this.cmdRemoveAll.Location = new Point(262, 57);
			this.cmdRemoveAll.Name = "cmdRemoveAll";
			this.cmdRemoveAll.Size = new System.Drawing.Size(104, 25);
			this.cmdRemoveAll.TabIndex = 13;
			this.cmdRemoveAll.Text = "Remove All";
			this.cmdRemoveAll.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(12, 5);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(117, 13);
			this.Label1.TabIndex = 12;
			this.Label1.Text = "List of Stored Accounts";
			this.lstCydia.FullRowSelect = true;
			this.lstCydia.GridLines = true;
			this.lstCydia.HideSelection = false;
			this.lstCydia.Location = new Point(12, 24);
			this.lstCydia.Name = "lstCydia";
			this.lstCydia.Size = new System.Drawing.Size(239, 358);
			this.lstCydia.TabIndex = 11;
			this.lstCydia.UseCompatibleStateImageBehavior = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(377, 393);
			base.ControlBox = false;
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdRemove);
			base.Controls.Add(this.cmdRemoveAll);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.lstCydia);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AppleAccounts";
			this.Text = "Stored Apple Accounts";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void LoadAccounts()
		{
			Dictionary<string, string> accounts = Database.GetAccounts();
			this.lstCydia.Clear();
			this.lstCydia.View = View.Details;
			this.lstCydia.Columns.Add("Apple Id");
			this.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			int count = checked(accounts.Keys.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				ListViewItem listViewItem = new ListViewItem()
				{
					Text = accounts.Keys.ElementAt<string>(i)
				};
				listViewItem.SubItems.Add(accounts.Keys.ElementAt<string>(i));
				this.lstCydia.Items.Add(listViewItem);
			}
		}
	}
}