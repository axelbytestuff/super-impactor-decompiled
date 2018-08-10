using Claunia.PropertyList;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
	public class CertificateDelete : Form
	{
		private IContainer components;

		private Dictionary<string, string> lstAcc;

		private string teamId;

		internal virtual ComboBox cmbAppleId
		{
			get
			{
				stackVariable1 = this._cmbAppleId;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmbAppleId_SelectedIndexChanged);
				ComboBox comboBox = this._cmbAppleId;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged -= eventHandler;
				}
				this._cmbAppleId = value;
				comboBox = this._cmbAppleId;
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += eventHandler;
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

		internal virtual Button cmdGetCert
		{
			get
			{
				stackVariable1 = this._cmdGetCert;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdGetCert_Click);
				Button button = this._cmdGetCert;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdGetCert = value;
				button = this._cmdGetCert;
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

		internal virtual ListView lstCydia
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtPassword
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public CertificateDelete()
		{
			base.Load += new EventHandler(this.CertificateDelete_Load);
			this.InitializeComponent();
		}

		private void CertificateDelete_Load(object sender, EventArgs e)
		{
			Dictionary<string, string>.Enumerator enumerator = new Dictionary<string, string>.Enumerator();
			this.lstAcc = Database.GetAccounts();
			try
			{
				enumerator = this.lstAcc.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					this.cmbAppleId.Items.Add(current.Key);
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		private void cmbAppleId_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txtPassword.Text = this.lstAcc[this.cmbAppleId.Text];
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdGetCert_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.cmbAppleId.Text.Trim(), "", false) == 0)
			{
				Interaction.MsgBox("No appleId!", MsgBoxStyle.OkOnly, "Error");
			}
			else if (Operators.CompareString(this.txtPassword.Text, "", false) != 0)
			{
				this.cmdGetCert.Enabled = false;
				object objectValue = RuntimeHelpers.GetObjectValue(this.LoadCertificates());
				this.cmdGetCert.Enabled = true;
				if (Operators.ConditionalCompareObjectNotEqual(objectValue, "", false))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(objectValue), MsgBoxStyle.OkOnly, "Warning");
				}
			}
			else
			{
				Interaction.MsgBox("No password!", MsgBoxStyle.OkOnly, "Error");
			}
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
					AppleService.revokeCertificate(current.SubItems[1].Text, this.teamId);
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
			IEnumerator enumerator = null;
			try
			{
				enumerator = this.lstCydia.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ListViewItem current = (ListViewItem)enumerator.Current;
					AppleService.revokeCertificate(current.SubItems[1].Text, this.teamId);
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
			this.Label3 = new Label();
			this.Label2 = new Label();
			this.txtPassword = new TextBox();
			this.cmbAppleId = new ComboBox();
			this.cmdClose = new Button();
			this.cmdRemove = new Button();
			this.Label1 = new Label();
			this.lstCydia = new ListView();
			this.cmdGetCert = new Button();
			this.cmdRemoveAll = new Button();
			base.SuspendLayout();
			this.Label3.AutoSize = true;
			this.Label3.Location = new Point(7, 46);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(53, 13);
			this.Label3.TabIndex = 10;
			this.Label3.Text = "Password";
			this.Label2.AutoSize = true;
			this.Label2.Location = new Point(7, 15);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(46, 13);
			this.Label2.TabIndex = 9;
			this.Label2.Text = "Apple Id";
			this.txtPassword.Location = new Point(64, 44);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(206, 20);
			this.txtPassword.TabIndex = 8;
			this.txtPassword.UseSystemPasswordChar = true;
			this.cmbAppleId.FormattingEnabled = true;
			this.cmbAppleId.Location = new Point(64, 12);
			this.cmbAppleId.Name = "cmbAppleId";
			this.cmbAppleId.Size = new System.Drawing.Size(206, 21);
			this.cmbAppleId.TabIndex = 7;
			this.cmdClose.Location = new Point(285, 293);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(104, 25);
			this.cmdClose.TabIndex = 15;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdRemove.Location = new Point(285, 95);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(104, 25);
			this.cmdRemove.TabIndex = 14;
			this.cmdRemove.Text = "Revoke";
			this.cmdRemove.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(8, 76);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(90, 13);
			this.Label1.TabIndex = 12;
			this.Label1.Text = "List of Certificates";
			this.lstCydia.FullRowSelect = true;
			this.lstCydia.GridLines = true;
			this.lstCydia.HideSelection = false;
			this.lstCydia.Location = new Point(8, 95);
			this.lstCydia.MultiSelect = false;
			this.lstCydia.Name = "lstCydia";
			this.lstCydia.Size = new System.Drawing.Size(262, 224);
			this.lstCydia.TabIndex = 11;
			this.lstCydia.UseCompatibleStateImageBehavior = false;
			this.cmdGetCert.Location = new Point(285, 12);
			this.cmdGetCert.Name = "cmdGetCert";
			this.cmdGetCert.Size = new System.Drawing.Size(106, 24);
			this.cmdGetCert.TabIndex = 16;
			this.cmdGetCert.Text = "Get Certificates";
			this.cmdGetCert.UseVisualStyleBackColor = true;
			this.cmdRemoveAll.Location = new Point(285, 128);
			this.cmdRemoveAll.Name = "cmdRemoveAll";
			this.cmdRemoveAll.Size = new System.Drawing.Size(104, 25);
			this.cmdRemoveAll.TabIndex = 17;
			this.cmdRemoveAll.Text = "Revoke All";
			this.cmdRemoveAll.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(401, 327);
			base.ControlBox = false;
			base.Controls.Add(this.cmdRemoveAll);
			base.Controls.Add(this.cmdGetCert);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.cmdRemove);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.lstCydia);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.cmbAppleId);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "CertificateDelete";
			this.Text = "Revoke Certificates";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private object LoadCertificates()
		{
			object obj;
			Application.DoEvents();
			NSDictionary nSDictionary = AppleService.login(this.cmbAppleId.Text, this.txtPassword.Text);
			if (nSDictionary.ContainsKey("myacinfo"))
			{
				string str = nSDictionary.ObjectForKey("myacinfo").ToString();
				Application.DoEvents();
				nSDictionary = AppleService.listTeam(str);
				this.teamId = "";
				if (nSDictionary.ContainsKey("teams"))
				{
					NSArray nSArray = (NSArray)nSDictionary.ObjectForKey("teams");
					if (nSArray.get_Count() > 0)
					{
						NSDictionary nSDictionary1 = (NSDictionary)nSArray.ElementAt<NSObject>(0);
						if (nSDictionary1.ContainsKey("teamId"))
						{
							this.teamId = nSDictionary1.ObjectForKey("teamId").ToString();
						}
					}
				}
				if (Operators.CompareString(this.teamId, "", false) != 0)
				{
					Application.DoEvents();
					nSDictionary = AppleService.allDevelopmentCert(this.teamId);
					this.lstCydia.Clear();
					this.lstCydia.Clear();
					this.lstCydia.View = View.Details;
					this.lstCydia.Columns.Add("Name", 500);
					this.lstCydia.Columns.Add("Serial");
					if (nSDictionary.ContainsKey("certificates"))
					{
						NSArray nSArray1 = (NSArray)nSDictionary.ObjectForKey("certificates");
						int count = checked(nSArray1.get_Count() - 1);
						for (int i = 0; i <= count; i = checked(i + 1))
						{
							NSDictionary nSDictionary2 = (NSDictionary)nSArray1.ElementAt<NSObject>(i);
							if (nSDictionary2.ContainsKey("name") & nSDictionary2.ContainsKey("serialNumber"))
							{
								ListViewItem listViewItem = new ListViewItem();
								if (!nSDictionary2.ContainsKey("machineName"))
								{
									listViewItem.Text = nSDictionary2.ObjectForKey("name").ToString();
								}
								else
								{
									listViewItem.Text = string.Concat(nSDictionary2.ObjectForKey("name").ToString(), " - ", nSDictionary2.ObjectForKey("machineName").ToString());
								}
								listViewItem.SubItems.Add(nSDictionary2.ObjectForKey("serialNumber").ToString());
								this.lstCydia.Items.Add(listViewItem);
							}
						}
						if (this.lstCydia.Items.Count == 0)
						{
							obj = "No Certificates";
							return obj;
						}
					}
					obj = "";
				}
				else
				{
					obj = "Not have teamId";
				}
			}
			else
			{
				obj = "Cannot login itune...";
			}
			return obj;
		}
	}
}