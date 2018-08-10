using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class InstallResult : Form
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

		internal virtual Button cmdDetail
		{
			get
			{
				stackVariable1 = this._cmdDetail;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdDetail_Click);
				Button button = this._cmdDetail;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdDetail = value;
				button = this._cmdDetail;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdSupport
		{
			get
			{
				stackVariable1 = this._cmdSupport;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdSupport_Click);
				Button button = this._cmdSupport;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdSupport = value;
				button = this._cmdSupport;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Label lblMessage
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual TextBox txtDetail
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public InstallResult()
		{
			this.InitializeComponent();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void cmdDetail_Click(object sender, EventArgs e)
		{
			base.Height = checked(checked(this.txtDetail.Height + this.txtDetail.Top) + 50);
			this.cmdDetail.Visible = false;
		}

		private void cmdSupport_Click(object sender, EventArgs e)
		{
			(new ReportBug()).ShowDialog();
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
			this.lblMessage = new Label();
			this.cmdClose = new Button();
			this.cmdSupport = new Button();
			this.cmdDetail = new Button();
			this.txtDetail = new TextBox();
			base.SuspendLayout();
			this.lblMessage.AutoSize = true;
			this.lblMessage.Location = new Point(13, 24);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(0, 13);
			this.lblMessage.TabIndex = 0;
			this.cmdClose.Location = new Point(399, 15);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 1;
			this.cmdClose.Text = "Close";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdSupport.Location = new Point(399, 54);
			this.cmdSupport.Name = "cmdSupport";
			this.cmdSupport.Size = new System.Drawing.Size(75, 23);
			this.cmdSupport.TabIndex = 2;
			this.cmdSupport.Text = "Support";
			this.cmdSupport.UseVisualStyleBackColor = true;
			this.cmdDetail.Location = new Point(12, 54);
			this.cmdDetail.Name = "cmdDetail";
			this.cmdDetail.Size = new System.Drawing.Size(75, 23);
			this.cmdDetail.TabIndex = 3;
			this.cmdDetail.Text = "Detail";
			this.cmdDetail.UseVisualStyleBackColor = true;
			this.txtDetail.Location = new Point(12, 99);
			this.txtDetail.Multiline = true;
			this.txtDetail.Name = "txtDetail";
			this.txtDetail.ScrollBars = ScrollBars.Vertical;
			this.txtDetail.Size = new System.Drawing.Size(461, 81);
			this.txtDetail.TabIndex = 4;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(485, 90);
			base.ControlBox = false;
			base.Controls.Add(this.txtDetail);
			base.Controls.Add(this.cmdDetail);
			base.Controls.Add(this.cmdSupport);
			base.Controls.Add(this.cmdClose);
			base.Controls.Add(this.lblMessage);
			base.Name = "InstallResult";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Install Result";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void showMessage(string rs, string detail)
		{
			this.lblMessage.Text = rs;
			this.txtDetail.Text = detail;
			base.ShowDialog();
		}
	}
}