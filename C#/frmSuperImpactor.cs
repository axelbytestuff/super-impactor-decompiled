using Claunia.PropertyList;
using ICSharpCode.SharpZipLib.BZip2;
using log4net;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetSparkle;
using SuperImpactor.My.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace SuperImpactor
{
	[DesignerGenerated]
	public class frmSuperImpactor : Form
	{
		private IContainer components;

		public const long LVM_FIRST = 4096L;

		public const long LVM_SETICONSPACING = 4149L;

		private int crrTools;

		private Dictionary<string, string> lstAcc;

		private Dictionary<string, frmSuperImpactor.ProvisionInfo> lstProvision;

		private Sparkle sparkle;

		private bool isNewApp;

		private bool firstTimeLoadApp;

		private int mint_LastReceivedTimerID;

		private int mint_LastInitializedTimerID;

		private Thread trd;

		private bool isExit;

		private List<frmSuperImpactor.DeviceInfo> listDevice;

		private bool isShowDownload;

		public List<AppInfos> crrAppsOnDevice;

		internal virtual Panel childPanelAppleIds
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Panel childPanelRepo
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Panel childPanelRevoke
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

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

		internal virtual ComboBox cmbDevice
		{
			get
			{
				stackVariable1 = this._cmbDevice;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmbDevice_TextChanged);
				ComboBox comboBox = this._cmbDevice;
				if (comboBox != null)
				{
					comboBox.TextChanged -= eventHandler;
				}
				this._cmbDevice = value;
				comboBox = this._cmbDevice;
				if (comboBox != null)
				{
					comboBox.TextChanged += eventHandler;
				}
			}
		}

		internal virtual Button cmdAbout
		{
			get
			{
				stackVariable1 = this._cmdAbout;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdAbout_Click);
				Button button = this._cmdAbout;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdAbout = value;
				button = this._cmdAbout;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdAddCydia
		{
			get
			{
				stackVariable1 = this._cmdAddCydia;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdAddCydia_Click);
				Button button = this._cmdAddCydia;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdAddCydia = value;
				button = this._cmdAddCydia;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdCheckForUpdate
		{
			get
			{
				stackVariable1 = this._cmdCheckForUpdate;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdCheckForUpdate_Click);
				Button button = this._cmdCheckForUpdate;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdCheckForUpdate = value;
				button = this._cmdCheckForUpdate;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdClearText
		{
			get
			{
				stackVariable1 = this._cmdClearText;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdClearText_Click);
				Button button = this._cmdClearText;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdClearText = value;
				button = this._cmdClearText;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdFixCrash
		{
			get
			{
				stackVariable1 = this._cmdFixCrash;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdFixCrash_Click);
				Button button = this._cmdFixCrash;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdFixCrash = value;
				button = this._cmdFixCrash;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdInstallFromFile
		{
			get
			{
				stackVariable1 = this._cmdInstallFromFile;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdInstallFromFile_Click);
				Button button = this._cmdInstallFromFile;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdInstallFromFile = value;
				button = this._cmdInstallFromFile;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdRefreshRevoke
		{
			get
			{
				stackVariable1 = this._cmdRefreshRevoke;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdRefreshRevoke_Click);
				Button button = this._cmdRefreshRevoke;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdRefreshRevoke = value;
				button = this._cmdRefreshRevoke;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdResignAll
		{
			get
			{
				stackVariable1 = this._cmdResignAll;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdResignAll_Click);
				Button button = this._cmdResignAll;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdResignAll = value;
				button = this._cmdResignAll;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button cmdResignExpired
		{
			get
			{
				stackVariable1 = this._cmdResignExpired;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cmdResignExpired_Click);
				Button button = this._cmdResignExpired;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._cmdResignExpired = value;
				button = this._cmdResignExpired;
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

		private virtual System.Windows.Forms.Timer dt
		{
			get
			{
				stackVariable1 = this._dt;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = (object a0, EventArgs a1) => this.dt_Tick();
				System.Windows.Forms.Timer timer = this._dt;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._dt = value;
				timer = this._dt;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		internal virtual WebBrowser homeBrower
		{
			get
			{
				stackVariable1 = this._homeBrower;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				WebBrowserNavigatingEventHandler webBrowserNavigatingEventHandler = new WebBrowserNavigatingEventHandler(this.homeBrower_Navigating);
				WebBrowser webBrowser = this._homeBrower;
				if (webBrowser != null)
				{
					webBrowser.Navigating -= webBrowserNavigatingEventHandler;
				}
				this._homeBrower = value;
				webBrowser = this._homeBrower;
				if (webBrowser != null)
				{
					webBrowser.Navigating += webBrowserNavigatingEventHandler;
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

		internal virtual Label Label4
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label5
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

		internal virtual Label lblAccount
		{
			get
			{
				stackVariable1 = this._lblAccount;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblAccount_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblAccount_MouseLeave);
				EventHandler eventHandler1 = new EventHandler(this.lblAccount_Click);
				Label label = this._lblAccount;
				if (label != null)
				{
					label.MouseMove -= mouseEventHandler;
					label.MouseLeave -= eventHandler;
					label.Click -= eventHandler1;
				}
				this._lblAccount = value;
				label = this._lblAccount;
				if (label != null)
				{
					label.MouseMove += mouseEventHandler;
					label.MouseLeave += eventHandler;
					label.Click += eventHandler1;
				}
			}
		}

		internal virtual Label lblCydiaRepos
		{
			get
			{
				stackVariable1 = this._lblCydiaRepos;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblCydiaRepos_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblCydiaRepos_MouseLeave);
				EventHandler eventHandler1 = new EventHandler(this.lblCydiaRepos_Click);
				Label label = this._lblCydiaRepos;
				if (label != null)
				{
					label.MouseMove -= mouseEventHandler;
					label.MouseLeave -= eventHandler;
					label.Click -= eventHandler1;
				}
				this._lblCydiaRepos = value;
				label = this._lblCydiaRepos;
				if (label != null)
				{
					label.MouseMove += mouseEventHandler;
					label.MouseLeave += eventHandler;
					label.Click += eventHandler1;
				}
			}
		}

		internal virtual Label lblDeleteAppId
		{
			get
			{
				stackVariable1 = this._lblDeleteAppId;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lblDeleteAppId_MouseLeave);
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblDeleteAppId_MouseMove);
				EventHandler eventHandler1 = new EventHandler(this.lblDeleteAppId_Click);
				Label label = this._lblDeleteAppId;
				if (label != null)
				{
					label.MouseLeave -= eventHandler;
					label.MouseMove -= mouseEventHandler;
					label.Click -= eventHandler1;
				}
				this._lblDeleteAppId = value;
				label = this._lblDeleteAppId;
				if (label != null)
				{
					label.MouseLeave += eventHandler;
					label.MouseMove += mouseEventHandler;
					label.Click += eventHandler1;
				}
			}
		}

		internal virtual Label lblDeviceClass
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblDeviceName
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblModelNumber
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblPhone
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblProductionVersion
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label lblRevokeCert
		{
			get
			{
				stackVariable1 = this._lblRevokeCert;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblRevokeCert_MouseMove);
				EventHandler eventHandler = new EventHandler(this.lblRevokeCert_MouseLeave);
				EventHandler eventHandler1 = new EventHandler(this.lblRevokeCert_Click);
				Label label = this._lblRevokeCert;
				if (label != null)
				{
					label.MouseMove -= mouseEventHandler;
					label.MouseLeave -= eventHandler;
					label.Click -= eventHandler1;
				}
				this._lblRevokeCert = value;
				label = this._lblRevokeCert;
				if (label != null)
				{
					label.MouseMove += mouseEventHandler;
					label.MouseLeave += eventHandler;
					label.Click += eventHandler1;
				}
			}
		}

		internal virtual Label lblSerialNumber
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual ListViewEx lstAccount
		{
			get
			{
				stackVariable1 = this._lstAccount;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler<FileEventArgs> eventHandler = new EventHandler<FileEventArgs>(this.lstAccount_Button2Click);
				ListViewEx listViewEx = this._lstAccount;
				if (listViewEx != null)
				{
					listViewEx.Button2Click -= eventHandler;
				}
				this._lstAccount = value;
				listViewEx = this._lstAccount;
				if (listViewEx != null)
				{
					listViewEx.Button2Click += eventHandler;
				}
			}
		}

		internal virtual ListViewEx lstAppOnDevice
		{
			get
			{
				stackVariable1 = this._lstAppOnDevice;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lstAppOnDevice_SelectedIndexChanged);
				EventHandler<FileEventArgs> eventHandler1 = new EventHandler<FileEventArgs>(this.lstAppOnDevice_Button1Click);
				EventHandler<FileEventArgs> eventHandler2 = new EventHandler<FileEventArgs>(this.lstAppOnDevice_Button2Click);
				ListViewEx listViewEx = this._lstAppOnDevice;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged -= eventHandler;
					listViewEx.Button1Click -= eventHandler1;
					listViewEx.Button2Click -= eventHandler2;
				}
				this._lstAppOnDevice = value;
				listViewEx = this._lstAppOnDevice;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged += eventHandler;
					listViewEx.Button1Click += eventHandler1;
					listViewEx.Button2Click += eventHandler2;
				}
			}
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
				EventHandler<FileEventArgs> eventHandler1 = new EventHandler<FileEventArgs>(this.lstApps_Button1Click);
				EventHandler<FileEventArgs> eventHandler2 = new EventHandler<FileEventArgs>(this.lstApps_Button2Click);
				EventHandler eventHandler3 = new EventHandler(this.lstApps_DoubleClick);
				ListViewEx listViewEx = this._lstApps;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged -= eventHandler;
					listViewEx.Button1Click -= eventHandler1;
					listViewEx.Button2Click -= eventHandler2;
					listViewEx.DoubleClick -= eventHandler3;
				}
				this._lstApps = value;
				listViewEx = this._lstApps;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged += eventHandler;
					listViewEx.Button1Click += eventHandler1;
					listViewEx.Button2Click += eventHandler2;
					listViewEx.DoubleClick += eventHandler3;
				}
			}
		}

		internal virtual ListViewEx lstCydia
		{
			get
			{
				stackVariable1 = this._lstCydia;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lstCydia_SelectedIndexChanged);
				EventHandler<FileEventArgs> eventHandler1 = new EventHandler<FileEventArgs>(this.lstCydia_Button2Click);
				ListViewEx listViewEx = this._lstCydia;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged -= eventHandler;
					listViewEx.Button2Click -= eventHandler1;
				}
				this._lstCydia = value;
				listViewEx = this._lstCydia;
				if (listViewEx != null)
				{
					listViewEx.SelectedIndexChanged += eventHandler;
					listViewEx.Button2Click += eventHandler1;
				}
			}
		}

		internal virtual ListViewEx lstDownloads
		{
			get
			{
				stackVariable1 = this._lstDownloads;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler<FileEventArgs> eventHandler = new EventHandler<FileEventArgs>(this.lstDownloads_Button1Click);
				EventHandler<FileEventArgs> eventHandler1 = new EventHandler<FileEventArgs>(this.lstDownloads_Button2Click);
				ListViewEx listViewEx = this._lstDownloads;
				if (listViewEx != null)
				{
					listViewEx.Button1Click -= eventHandler;
					listViewEx.Button2Click -= eventHandler1;
				}
				this._lstDownloads = value;
				listViewEx = this._lstDownloads;
				if (listViewEx != null)
				{
					listViewEx.Button1Click += eventHandler;
					listViewEx.Button2Click += eventHandler1;
				}
			}
		}

		internal virtual ListViewEx lstRevoke
		{
			get
			{
				stackVariable1 = this._lstRevoke;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler<FileEventArgs> eventHandler = new EventHandler<FileEventArgs>(this.lstRevoke_Button2Click);
				ListViewEx listViewEx = this._lstRevoke;
				if (listViewEx != null)
				{
					listViewEx.Button2Click -= eventHandler;
				}
				this._lstRevoke = value;
				listViewEx = this._lstRevoke;
				if (listViewEx != null)
				{
					listViewEx.Button2Click += eventHandler;
				}
			}
		}

		internal virtual Panel Panel1
		{
			get
			{
				stackVariable1 = this._Panel1;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.Panel1_Paint);
				Panel panel = this._Panel1;
				if (panel != null)
				{
					panel.Paint -= paintEventHandler;
				}
				this._Panel1 = value;
				panel = this._Panel1;
				if (panel != null)
				{
					panel.Paint += paintEventHandler;
				}
			}
		}

		internal virtual Panel Panel2
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Panel panelApp
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Panel panelDevice
		{
			get
			{
				stackVariable1 = this._panelDevice;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.panelDevice_Paint);
				Panel panel = this._panelDevice;
				if (panel != null)
				{
					panel.Paint -= paintEventHandler;
				}
				this._panelDevice = value;
				panel = this._panelDevice;
				if (panel != null)
				{
					panel.Paint += paintEventHandler;
				}
			}
		}

		internal virtual Panel panelDownloads
		{
			get
			{
				stackVariable1 = this._panelDownloads;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				PaintEventHandler paintEventHandler = new PaintEventHandler(this.panelDownloads_Paint);
				Panel panel = this._panelDownloads;
				if (panel != null)
				{
					panel.Paint -= paintEventHandler;
				}
				this._panelDownloads = value;
				panel = this._panelDownloads;
				if (panel != null)
				{
					panel.Paint += paintEventHandler;
				}
			}
		}

		internal virtual Panel panelHome
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Panel panelTools
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox picAppBtn
		{
			get
			{
				stackVariable1 = this._picAppBtn;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picAppBtn_Click);
				PictureBox pictureBox = this._picAppBtn;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picAppBtn = value;
				pictureBox = this._picAppBtn;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picDevice
		{
			get
			{
				stackVariable1 = this._picDevice;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picDevice_Click);
				PictureBox pictureBox = this._picDevice;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picDevice = value;
				pictureBox = this._picDevice;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picDeviceBtn
		{
			get
			{
				stackVariable1 = this._picDeviceBtn;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picDeviceBtn_Click);
				PictureBox pictureBox = this._picDeviceBtn;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picDeviceBtn = value;
				pictureBox = this._picDeviceBtn;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picDownloadBtn
		{
			get
			{
				stackVariable1 = this._picDownloadBtn;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picDownloadBtn_Click);
				PictureBox pictureBox = this._picDownloadBtn;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picDownloadBtn = value;
				pictureBox = this._picDownloadBtn;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picHomeBtn
		{
			get
			{
				stackVariable1 = this._picHomeBtn;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picHomeBtn_Click);
				PictureBox pictureBox = this._picHomeBtn;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picHomeBtn = value;
				pictureBox = this._picHomeBtn;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picLoading
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual PictureBox picLogo
		{
			get
			{
				stackVariable1 = this._picLogo;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picLogo_Click);
				PictureBox pictureBox = this._picLogo;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picLogo = value;
				pictureBox = this._picLogo;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
		}

		internal virtual PictureBox picToolBtn
		{
			get
			{
				stackVariable1 = this._picToolBtn;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.picToolBtn_Click);
				PictureBox pictureBox = this._picToolBtn;
				if (pictureBox != null)
				{
					pictureBox.Click -= eventHandler;
				}
				this._picToolBtn = value;
				pictureBox = this._picToolBtn;
				if (pictureBox != null)
				{
					pictureBox.Click += eventHandler;
				}
			}
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
				TextBox textBox = this._txtAppSearch;
				if (textBox != null)
				{
					textBox.TextChanged -= eventHandler;
				}
				this._txtAppSearch = value;
				textBox = this._txtAppSearch;
				if (textBox != null)
				{
					textBox.TextChanged += eventHandler;
				}
			}
		}

		internal virtual TextBox txtCydia
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

		public frmSuperImpactor()
		{
			base.Load += new EventHandler(this.frmSuperImpactor_Load);
			base.Closed += new EventHandler(this.frmSuperImpactor_Closed);
			this.lstProvision = new Dictionary<string, frmSuperImpactor.ProvisionInfo>();
			this.isNewApp = false;
			this.firstTimeLoadApp = true;
			this.mint_LastReceivedTimerID = 0;
			this.mint_LastInitializedTimerID = 0;
			this.listDevice = new List<frmSuperImpactor.DeviceInfo>();
			this.isShowDownload = false;
			this.crrAppsOnDevice = new List<AppInfos>();
			this.InitializeComponent();
		}

		private void cmbAppleId_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txtPassword.Text = this.lstAcc[this.cmbAppleId.Text];
		}

		private async void cmbDevice_TextChanged(object sender, EventArgs e)
		{
			string str;
			DateTime dateTime = new DateTime();
			if (Operators.CompareString(this.cmbDevice.Text, "", false) != 0)
			{
				this.lstAppOnDevice.Clear();
				this.cmdResignAll.Visible = true;
				this.cmdResignExpired.Visible = true;
				this.cmdFixCrash.Visible = true;
				this.cmdInstallFromFile.Visible = true;
				int count = checked(this.listDevice.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					if (Operators.CompareString(this.cmbDevice.Text, string.Concat(this.listDevice[i].deviceName, " - ", this.listDevice[i].udid), false) == 0)
					{
						this.lblPhone.Text = string.Concat("PhoneNumber: ", this.listDevice[i].phoneNumber);
						this.lblDeviceName.Text = string.Concat("DeviceName: ", this.listDevice[i].deviceName);
						this.lblDeviceClass.Text = string.Concat("DeviceClass: ", this.listDevice[i].deviceClass);
						this.lblSerialNumber.Text = string.Concat("SerialNumber: ", this.listDevice[i].serialNumber);
						this.lblModelNumber.Text = string.Concat("ModelNumber: ", this.listDevice[i].modelNumber);
						this.lblProductionVersion.Text = string.Concat("ProductVersion: ", this.listDevice[i].productVersion);
						if (Operators.CompareString(this.listDevice[i].deviceClass, "iPhone", false) != 0)
						{
							this.picDevice.Image = (Image)Resources.ResourceManager.GetObject("ipad");
						}
						else
						{
							this.picDevice.Image = (Image)Resources.ResourceManager.GetObject("iphone");
						}
						this.crrAppsOnDevice.Clear();
						frmSuperImpactor _frmSuperImpactor = this;
						string str1 = this.cmbDevice.Text.Substring(checked(this.cmbDevice.Text.Length - 40));
						string item = this.listDevice[i].productVersion;
						char[] chrArray = new char[] { '.' };
						await _frmSuperImpactor.getAppsOnDevice(str1, int.Parse(item.Split(chrArray)[0]));
						try
						{
							str = string.Concat(AppConst.m_rootPath, "\\certs\\\\pr\\", this.listDevice[i].udid);
						}
						catch (Exception exception)
						{
							ProjectData.SetProjectError(exception);
							ProjectData.ClearProjectError();
							goto Label0;
						}
						try
						{
							Directory.CreateDirectory(str);
						}
						catch (Exception exception1)
						{
							ProjectData.SetProjectError(exception1);
							ProjectData.ClearProjectError();
						}
						string str2 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("copy \"", str, "\""), true);
						string[] files = Directory.GetFiles(str);
						int num = Information.UBound(files, 1);
						for (int j = 0; j <= num; j = checked(j + 1))
						{
							if (Operators.CompareString(Path.GetExtension(files[j]).ToLower(), ".mobileprovision", false) == 0)
							{
								if (!File.Exists(files[j]))
								{
									goto Label1;
								}
								string[] strArrays = File.ReadAllLines(files[j]);
								string str3 = "";
								int num1 = Information.LBound(strArrays, 1);
								int num2 = Information.UBound(strArrays, 1);
								for (int k = num1; k <= num2; k = checked(k + 1))
								{
									if (strArrays[k].IndexOf("<key>ExpirationDate</key>") >= 0)
									{
										string str4 = strArrays[checked(k + 1)].Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim();
										dateTime = DateTime.ParseExact(str4, "yyyy-MM-dd HH:mm:ss", null);
									}
									else if (strArrays[k].IndexOf("<key>application-identifier</key>") >= 0)
									{
										string str5 = strArrays[checked(k + 1)].Replace("<string>", "").Replace("</string>", "").Trim();
										int num3 = str5.IndexOf(".");
										if (num3 > 0)
										{
											str3 = str5.Substring(checked(num3 + 1));
										}
									}
								}
								if (Operators.CompareString(str3, "", false) != 0)
								{
									frmSuperImpactor.ProvisionInfo provisionInfo = new frmSuperImpactor.ProvisionInfo()
									{
										eDate = dateTime,
										id = files[j]
									};
									if (!this.lstProvision.ContainsKey(str3))
									{
										this.lstProvision.Add(str3, provisionInfo);
									}
									else if (DateTime.Compare(dateTime, this.lstProvision[str3].eDate) > 0)
									{
										Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("remove ", Path.GetFileName(this.lstProvision[str3].id).ToLower().Replace(".mobileprovision", "")), false);
										try
										{
											File.Delete(this.lstProvision[str3].id);
										}
										catch (Exception exception2)
										{
											ProjectData.SetProjectError(exception2);
											ProjectData.ClearProjectError();
										}
										this.lstProvision.Remove(str3);
										this.lstProvision.Add(str3, provisionInfo);
									}
									else if (DateTime.Compare(dateTime, this.lstProvision[str3].eDate) < 0)
									{
										Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceprovision.exe"), string.Concat("remove ", Path.GetFileName(provisionInfo.id).ToLower().Replace(".mobileprovision", "")), false);
										try
										{
											File.Delete(files[j]);
										}
										catch (Exception exception3)
										{
											ProjectData.SetProjectError(exception3);
											ProjectData.ClearProjectError();
										}
									}
								}
								Application.DoEvents();
							}
						Label1:
						}
						this.lstAppOnDevice.Clear();
						this.lstAppOnDevice.View = View.Details;
						this.lstAppOnDevice.Columns.Add("App Installed by SuperImpact", checked(this.lstAppOnDevice.Width - 5));
						int count1 = checked(this.crrAppsOnDevice.Count - 1);
						for (int l = 0; l <= count1; l = checked(l + 1))
						{
							ExtraData extraDatum = new ExtraData();
							if (this.lstProvision.ContainsKey(this.crrAppsOnDevice[l].Package))
							{
								extraDatum.MinorText = string.Concat("Version: ", this.crrAppsOnDevice[l].Version, " - Expire On: ", Conversions.ToString(this.lstProvision[this.crrAppsOnDevice[l].Package].eDate));
								if (DateTime.Compare(this.lstProvision[this.crrAppsOnDevice[l].Package].eDate, DateAndTime.Now.Date) <= 0)
								{
									extraDatum.HeaderColor = Color.Red;
								}
							}
							else
							{
								extraDatum.HeaderColor = Color.Red;
								extraDatum.MinorText = string.Concat("Version: ", this.crrAppsOnDevice[l].Version, " - Expire On: ? ");
							}
							extraDatum.HeaderText = this.crrAppsOnDevice[l].Name;
							extraDatum.DescText = this.crrAppsOnDevice[l].Package;
							extraDatum.MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("appid"));
							extraDatum.ButtonText1 = "RESIGN";
							extraDatum.ButtonText2 = "REMOVE";
							this.lstAppOnDevice.Items.Add("").Tag = extraDatum;
						}
						break;
					}
				Label0:
				}
				this.picDevice.Visible = true;
				this.picDevice.BringToFront();
			}
			else
			{
				this.picDevice.Visible = false;
				this.lstAppOnDevice.Clear();
				this.cmdResignAll.Visible = false;
				this.cmdResignExpired.Visible = false;
				this.cmdFixCrash.Visible = false;
				this.cmdInstallFromFile.Visible = false;
				this.lblPhone.Text = "";
				this.lblDeviceName.Text = "";
				this.lblDeviceClass.Text = "";
				this.lblSerialNumber.Text = "";
				this.lblModelNumber.Text = "";
				this.lblProductionVersion.Text = "";
			}
			return;
			goto Label1;
		}

		private void cmdAbout_Click(object sender, EventArgs e)
		{
			Interaction.MsgBox(string.Concat("v", Assembly.GetExecutingAssembly().GetName().Version.ToString(), " - Copyright @2017 - TuanHa Jsc\r\nContact: flashsupporter@gmail.com\r\nWebsite: http://superimpactor.net\r\n\r\nThis program uses: \r\n- libimobiledevice team: http://www.libimobiledevice.org/\r\n- Copyright (c) 1998-2017 The OpenSSL Project, Copyright (C) 1995-1998 Eric Young (eay@cryptsoft.com). All rights reserved.\r\n- isign by Neil Kandalgaonkar\r\n- 7zip\r\n- zip"), MsgBoxStyle.OkOnly, "About");
		}

		private async void cmdAddCydia_Click(object sender, EventArgs e)
		{
			int num;
			int num1;
			string text = this.txtCydia.Text;
			if (Operators.CompareString(Microsoft.VisualBasic.Strings.Trim(text), "", false) != 0)
			{
				if (!text.StartsWith("http"))
				{
					text = string.Concat("http://", text);
				}
				int count = checked(this.lstCydia.Items.Count - 1);
				int num2 = 0;
				while (num2 <= count)
				{
					ListViewItem item = this.lstCydia.Items[num2];
					if (Operators.CompareString(((ExtraData)item.Tag).MinorText, text, false) != 0)
					{
						num2 = checked(num2 + 1);
					}
					else
					{
						Interaction.MsgBox("Cydia existed!", MsgBoxStyle.OkOnly, "Error");
						num1 = -2;
						num = num1;
						return;
					}
				}
				try
				{
					File.Delete("Release.txt");
					File.Delete("Release");
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					ProjectData.ClearProjectError();
				}
				string str = "Noname";
				try
				{
					WebClient webClient = new WebClient();
					webClient.DownloadFile(string.Concat(text, "/Release"), "Release.txt");
					string[] strArrays = File.ReadAllLines("Release.txt");
					int num3 = Information.LBound(strArrays, 1);
					int num4 = Information.UBound(strArrays, 1);
					int num5 = num3;
					while (num5 <= num4)
					{
						if (!strArrays[num5].StartsWith("Label:"))
						{
							num5 = checked(num5 + 1);
						}
						else
						{
							str = strArrays[num5].Substring(6);
							break;
						}
					}
				}
				catch (Exception exception1)
				{
					ProjectData.SetProjectError(exception1);
					ProjectData.ClearProjectError();
				}
				if (frmSuperImpactor.LoadPackages(text))
				{
					SQLiteCommand sQLiteCommand = new SQLiteCommand("INSERT INTO cydia_repos(name, path) VALUES(@name, @path)", AppConst.m_dbConnection);
					SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
					parameters.AddWithValue("@name", str);
					parameters.AddWithValue("@path", text);
					parameters = null;
					sQLiteCommand.ExecuteNonQuery();
					object objectValue = RuntimeHelpers.GetObjectValue(this.LoadCydiaRepos(text));
					UpdateCydia updateCydium = new UpdateCydia();
					updateCydium.LoadApp(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(objectValue)));
					AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(true);
				}
			}
			else
			{
				Interaction.MsgBox("Incorrect URL", MsgBoxStyle.OkOnly, "Error");
			}
			num1 = -2;
			num = num1;
		}

		private void cmdCheckForUpdate_Click(object sender, EventArgs e)
		{
			this.sparkle.CheckForUpdatesAtUserRequest();
		}

		private void cmdClearText_Click(object sender, EventArgs e)
		{
			this.txtAppSearch.Text = "";
		}

		private async void cmdFixCrash_Click(object sender, EventArgs e)
		{
			frmSuperImpactor.VB$StateMachine_321_cmdFixCrash_Click variable = null;
			AsyncVoidMethodBuilder.Create().Start<frmSuperImpactor.VB$StateMachine_321_cmdFixCrash_Click>(ref variable);
		}

		private void cmdInstallFromFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = "c:\\\\",
				Filter = "IPA Files (*.ipa)|*.ipa",
				FilterIndex = 2,
				RestoreDirectory = true
			};
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Install install = new Install();
				install.installFromFile(openFileDialog.FileName, "", "");
			}
		}

		private void cmdRefreshRevoke_Click(object sender, EventArgs e)
		{
			string str;
			if (Operators.CompareString(this.cmbAppleId.Text.Trim(), "", false) == 0)
			{
				Interaction.MsgBox("No appleId!", MsgBoxStyle.OkOnly, "Error");
			}
			else if (Operators.CompareString(this.txtPassword.Text, "", false) != 0)
			{
				this.cmdRefreshRevoke.Enabled = false;
				str = (this.lblDeleteAppId.BackColor != Color.FromName("GradientActiveCaption") ? Conversions.ToString(this.LoadCertificates()) : Conversions.ToString(this.LoadApps()));
				this.cmdRefreshRevoke.Enabled = true;
				if (Operators.CompareString(str, "", false) != 0)
				{
					Interaction.MsgBox(str, MsgBoxStyle.OkOnly, "Warning");
				}
			}
			else
			{
				Interaction.MsgBox("No password!", MsgBoxStyle.OkOnly, "Error");
			}
		}

		private void cmdResignAll_Click(object sender, EventArgs e)
		{
			this.resign(false);
		}

		private void cmdResignExpired_Click(object sender, EventArgs e)
		{
			this.resign(true);
		}

		private void cmdSupport_Click(object sender, EventArgs e)
		{
			(new ReportBug()).ShowDialog();
		}

		private void cmdUpdate_Click(object sender, EventArgs e)
		{
			if ((new UpdateCydia()).UpdateApp())
			{
			}
		}

		private async Task detectDevice()
		{
			string str = null;
			string str1 = null;
			string str2 = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinfo.exe"), "", false);
			string[] strArrays = str2.Split(new char[] { '\n' });
			string str3 = "";
			string str4 = "";
			string str5 = "";
			string str6 = "";
			string str7 = "";
			int length = checked((int)strArrays.Length - 1);
			for (int i = 0; i <= length; i = checked(i + 1))
			{
				if (strArrays[i].StartsWith("UniqueDeviceID"))
				{
					str1 = strArrays[i].Substring("UniqueDeviceID:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("DeviceName"))
				{
					str = strArrays[i].Substring("DeviceName:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("ProductVersion"))
				{
					str4 = strArrays[i].Substring("ProductVersion:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("DeviceClass"))
				{
					str3 = strArrays[i].Substring("DeviceClass:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("SerialNumber"))
				{
					str5 = strArrays[i].Substring("SerialNumber:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("ModelNumber"))
				{
					str6 = strArrays[i].Substring("ModelNumber:".Length).Trim();
				}
				else if (strArrays[i].StartsWith("PhoneNumber"))
				{
					str7 = strArrays[i].Substring("PhoneNumber:".Length).Trim();
				}
			}
			this.listDevice.Clear();
			if (Operators.CompareString(str1, "", false) != 0 & Operators.CompareString(str, "", false) != 0)
			{
				frmSuperImpactor.DeviceInfo deviceInfo = new frmSuperImpactor.DeviceInfo()
				{
					udid = str1,
					deviceName = str,
					productVersion = str4,
					deviceClass = str3,
					serialNumber = str5,
					modelNumber = str6,
					phoneNumber = str7
				};
				this.listDevice.Add(deviceInfo);
			}
		}

		public void DeviceInvokeMethod()
		{
			this.cmbDevice.Items.Clear();
			int count = checked(this.listDevice.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				this.cmbDevice.Items.Add(string.Concat(this.listDevice[i].deviceName, " - ", this.listDevice[i].udid));
			}
			if (this.cmbDevice.Items.Count == 0)
			{
				this.cmbDevice.Text = "";
			}
			if (this.cmbDevice.Items.Count > 0)
			{
				int num = checked(this.cmbDevice.Items.Count - 1);
				int num1 = 0;
				while (num1 <= num)
				{
					if (!Operators.ConditionalCompareObjectEqual(this.cmbDevice.Text, this.cmbDevice.Items[num1], false))
					{
						num1 = checked(num1 + 1);
					}
					else
					{
						return;
					}
				}
				this.cmbDevice.SelectedIndex = 0;
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

		private void dt_Tick()
		{
			this.dt.Stop();
			this.cmdCheckForUpdate.PerformClick();
		}

		private void frmSuperImpactor_Closed(object sender, EventArgs e)
		{
			this.isExit = true;
			try
			{
				File.Delete(string.Concat(AppConst.m_rootPath, "/\\tmp\\/running.pid"));
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void frmSuperImpactor_Load(object sender, EventArgs e)
		{
			try
			{
				try
				{
					AppConst.logger = LogManager.GetLogger("SuperImpactor");
					AppConst.logger.Info(string.Concat("Start ver ", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
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
			this.sparkle = new Sparkle("http://superimpactor.net/release/versions.xml", base.Icon);
			AppConst.mainForm = this;
			this.homeBrower.ScriptErrorsSuppressed = true;
			try
			{
				try
				{
					this.homeBrower.Url = new Uri(string.Concat("http://home.superimpactor.net/?ver=", HttpUtility.UrlEncode(Assembly.GetExecutingAssembly().GetName().Version.ToString())));
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
			AppConst.m_localTmp = Common.GetTempFolder();
			string startupPath = Application.StartupPath;
			AppConst.m_rootPath = string.Concat(startupPath, "\\..\\..\\");
			if (!File.Exists(string.Concat(AppConst.m_rootPath, "\\iaidb.sqlite")))
			{
				AppConst.m_rootPath = string.Concat(startupPath, "\\");
				if (!File.Exists(string.Concat(AppConst.m_rootPath, "\\iaidb.sqlite")))
				{
					Interaction.MsgBox("Application error! Please install again!", MsgBoxStyle.OkOnly, "Error");
					ProjectData.EndApp();
				}
			}
			AppConst.m_dbConnection = new SQLiteConnection(string.Concat("Data Source=", AppConst.m_rootPath, "\\iaidb.sqlite;Version=3;"));
			AppConst.m_dbConnection.Open();
			this.SetListViewSpacing(this.lstApps, 16, 16);
			AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(true);
			this.crrTools = 0;
			this.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption");
			this.lblCydiaRepos_Click(null, null);
			int num = 0;
			do
			{
				AppConst.m_randomKey = string.Concat(AppConst.m_randomKey, char.ConvertFromUtf32(checked(checked(num * 2) + 64)));
				num = checked(num + 1);
			}
			while (num <= 16);
			this.lstAcc = Database.GetAccounts();
			this.picHomeBtn_Click(null, null);
			(new Thread(new ThreadStart(this.ThreadTask))).Start();
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(frmSuperImpactor.UnhandledExceptionHandler);
			base.Show();
			this.sparkle.StartLoop(true);
			if (this.sparkle.CheckForUpdatesQuietly() == Sparkle.UpdateStatus.UpdateAvailable)
			{
				this.dt = new System.Windows.Forms.Timer()
				{
					Interval = 10000
				};
				this.dt.Start();
			}
			if (!File.Exists(string.Concat(AppConst.m_rootPath, "/\\tmp\\/running.pid")))
			{
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "/\\tmp\\/running.pid"), Conversions.ToString(DateTime.Now));
			}
			else
			{
				ReportBug.sendLog("crashreport", "auto");
			}
		}

		private async Task getAppsOnDevice(string udid, int iOSVersion)
		{
			string str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinstaller.exe"), "-l", false);
			string[] strArrays = str.Split(new char[] { '\n' });
			string str1 = "si";
			this.crrAppsOnDevice.Clear();
			int length = checked((int)strArrays.Length - 1);
			for (int i = 0; i <= length; i = checked(i + 1))
			{
				if (strArrays[i].StartsWith(str1))
				{
					int num = strArrays[i].IndexOf("-");
					if (iOSVersion > 1)
					{
						string str2 = strArrays[i].Replace("\r", "");
						string[] strArrays1 = str2.Split(new char[] { ',' });
						if ((int)strArrays1.Length == 3)
						{
							AppInfos appInfo = new AppInfos()
							{
								Name = Microsoft.VisualBasic.Strings.Trim(strArrays1[2].Replace("\"", "")),
								Version = Microsoft.VisualBasic.Strings.Trim(strArrays1[1].Replace("\"", "")),
								Package = Microsoft.VisualBasic.Strings.Trim(strArrays1[0].Replace(string.Concat(udid, "."), ""))
							};
							this.crrAppsOnDevice.Add(appInfo);
						}
					}
					else if (num > 0)
					{
						AppInfos appInfo1 = new AppInfos();
						AppInfos appInfo2 = appInfo1;
						string str3 = strArrays[i];
						char[] chrArray = new char[] { ' ' };
						appInfo2.Version = str3.Split(chrArray).Last<string>();
						appInfo1.Name = Microsoft.VisualBasic.Strings.Trim(strArrays[i].Substring(checked(num + 1), checked(checked(checked(strArrays[i].Length - appInfo1.Version.Length) - num) - 1)).Replace("\r", "").Replace("\n", ""));
						appInfo1.Version = Microsoft.VisualBasic.Strings.Trim(appInfo1.Version.Replace("\r", "").Replace("\n", ""));
						appInfo1.Package = Microsoft.VisualBasic.Strings.Trim(strArrays[i].Substring(0, checked(num - 1)).Replace("\r", "").Replace("\n", "").Replace(string.Concat(udid, "."), ""));
						this.crrAppsOnDevice.Add(appInfo1);
					}
				}
			}
		}

		private void homeBrower_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (!e.Url.ToString().EndsWith(".ipa"))
			{
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
				string str = e.Url.ToString().Substring(checked(e.Url.ToString().LastIndexOf("/") + 1));
				Common.Download(new DownloadProgress(), e.Url.ToString(), str);
			}
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSuperImpactor));
			this.Panel1 = new Panel();
			this.picHomeBtn = new PictureBox();
			this.picDownloadBtn = new PictureBox();
			this.picToolBtn = new PictureBox();
			this.picDeviceBtn = new PictureBox();
			this.picAppBtn = new PictureBox();
			this.picLogo = new PictureBox();
			this.panelHome = new Panel();
			this.homeBrower = new WebBrowser();
			this.panelApp = new Panel();
			this.cmdClearText = new Button();
			this.lstApps = new ListViewEx();
			this.txtAppSearch = new TextBox();
			this.cmdUpdate = new Button();
			this.Label1 = new Label();
			this.panelDownloads = new Panel();
			this.lstDownloads = new ListViewEx();
			this.panelTools = new Panel();
			this.childPanelRepo = new Panel();
			this.txtCydia = new TextBox();
			this.cmdAddCydia = new Button();
			this.Label4 = new Label();
			this.lstCydia = new ListViewEx();
			this.childPanelRevoke = new Panel();
			this.txtPassword = new TextBox();
			this.Label3 = new Label();
			this.cmdRefreshRevoke = new Button();
			this.Label2 = new Label();
			this.cmbAppleId = new ComboBox();
			this.lstRevoke = new ListViewEx();
			this.childPanelAppleIds = new Panel();
			this.lstAccount = new ListViewEx();
			this.Panel2 = new Panel();
			this.lblDeleteAppId = new Label();
			this.lblAccount = new Label();
			this.lblRevokeCert = new Label();
			this.lblCydiaRepos = new Label();
			this.panelDevice = new Panel();
			this.cmdCheckForUpdate = new Button();
			this.cmdAbout = new Button();
			this.cmdFixCrash = new Button();
			this.cmdInstallFromFile = new Button();
			this.picLoading = new PictureBox();
			this.cmdResignExpired = new Button();
			this.lblPhone = new Label();
			this.lblModelNumber = new Label();
			this.lblSerialNumber = new Label();
			this.lblProductionVersion = new Label();
			this.lblDeviceClass = new Label();
			this.lblDeviceName = new Label();
			this.cmdResignAll = new Button();
			this.picDevice = new PictureBox();
			this.lstAppOnDevice = new ListViewEx();
			this.Label6 = new Label();
			this.Label5 = new Label();
			this.cmbDevice = new ComboBox();
			this.cmdSupport = new Button();
			this.Panel1.SuspendLayout();
			((ISupportInitialize)this.picHomeBtn).BeginInit();
			((ISupportInitialize)this.picDownloadBtn).BeginInit();
			((ISupportInitialize)this.picToolBtn).BeginInit();
			((ISupportInitialize)this.picDeviceBtn).BeginInit();
			((ISupportInitialize)this.picAppBtn).BeginInit();
			((ISupportInitialize)this.picLogo).BeginInit();
			this.panelHome.SuspendLayout();
			this.panelApp.SuspendLayout();
			this.panelDownloads.SuspendLayout();
			this.panelTools.SuspendLayout();
			this.childPanelRepo.SuspendLayout();
			this.childPanelRevoke.SuspendLayout();
			this.childPanelAppleIds.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.panelDevice.SuspendLayout();
			((ISupportInitialize)this.picLoading).BeginInit();
			((ISupportInitialize)this.picDevice).BeginInit();
			base.SuspendLayout();
			this.Panel1.BackColor = Color.Transparent;
			this.Panel1.BackgroundImage = Resources.titlebar;
			this.Panel1.Controls.Add(this.picHomeBtn);
			this.Panel1.Controls.Add(this.picDownloadBtn);
			this.Panel1.Controls.Add(this.picToolBtn);
			this.Panel1.Controls.Add(this.picDeviceBtn);
			this.Panel1.Controls.Add(this.picAppBtn);
			this.Panel1.Controls.Add(this.picLogo);
			this.Panel1.ForeColor = SystemColors.GradientActiveCaption;
			this.Panel1.Location = new Point(-1, -1);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(939, 100);
			this.Panel1.TabIndex = 0;
			this.picHomeBtn.BackgroundImage = (Image)componentResourceManager.GetObject("picHomeBtn.BackgroundImage");
			this.picHomeBtn.Location = new Point(322, 0);
			this.picHomeBtn.Name = "picHomeBtn";
			this.picHomeBtn.Size = new System.Drawing.Size(89, 99);
			this.picHomeBtn.TabIndex = 5;
			this.picHomeBtn.TabStop = false;
			this.picDownloadBtn.BackgroundImage = Resources.download_btn;
			this.picDownloadBtn.Location = new Point(500, 0);
			this.picDownloadBtn.Name = "picDownloadBtn";
			this.picDownloadBtn.Size = new System.Drawing.Size(96, 99);
			this.picDownloadBtn.TabIndex = 4;
			this.picDownloadBtn.TabStop = false;
			this.picToolBtn.BackgroundImage = Resources.tools_btn;
			this.picToolBtn.Location = new Point(596, 0);
			this.picToolBtn.Name = "picToolBtn";
			this.picToolBtn.Size = new System.Drawing.Size(89, 99);
			this.picToolBtn.TabIndex = 3;
			this.picToolBtn.TabStop = false;
			this.picDeviceBtn.BackgroundImage = Resources.device_btn;
			this.picDeviceBtn.Location = new Point(685, 0);
			this.picDeviceBtn.Name = "picDeviceBtn";
			this.picDeviceBtn.Size = new System.Drawing.Size(89, 99);
			this.picDeviceBtn.TabIndex = 2;
			this.picDeviceBtn.TabStop = false;
			this.picAppBtn.BackgroundImage = Resources.apps_btn;
			this.picAppBtn.Location = new Point(411, 0);
			this.picAppBtn.Name = "picAppBtn";
			this.picAppBtn.Size = new System.Drawing.Size(89, 99);
			this.picAppBtn.TabIndex = 1;
			this.picAppBtn.TabStop = false;
			this.picLogo.BackgroundImageLayout = ImageLayout.Zoom;
			this.picLogo.Image = Resources.appicon;
			this.picLogo.Location = new Point(50, 3);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(117, 94);
			this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
			this.picLogo.TabIndex = 0;
			this.picLogo.TabStop = false;
			this.panelHome.Controls.Add(this.homeBrower);
			this.panelHome.Location = new Point(-1, 100);
			this.panelHome.Name = "panelHome";
			this.panelHome.Size = new System.Drawing.Size(939, 493);
			this.panelHome.TabIndex = 1;
			this.homeBrower.Dock = DockStyle.Fill;
			this.homeBrower.Location = new Point(0, 0);
			this.homeBrower.MinimumSize = new System.Drawing.Size(20, 20);
			this.homeBrower.Name = "homeBrower";
			this.homeBrower.Size = new System.Drawing.Size(939, 493);
			this.homeBrower.TabIndex = 0;
			this.panelApp.Controls.Add(this.cmdClearText);
			this.panelApp.Controls.Add(this.lstApps);
			this.panelApp.Controls.Add(this.txtAppSearch);
			this.panelApp.Controls.Add(this.cmdUpdate);
			this.panelApp.Controls.Add(this.Label1);
			this.panelApp.Location = new Point(0, 100);
			this.panelApp.Name = "panelApp";
			this.panelApp.Size = new System.Drawing.Size(938, 493);
			this.panelApp.TabIndex = 2;
			this.cmdClearText.Location = new Point(869, 2);
			this.cmdClearText.Name = "cmdClearText";
			this.cmdClearText.Size = new System.Drawing.Size(60, 23);
			this.cmdClearText.TabIndex = 13;
			this.cmdClearText.Text = "Clear";
			this.cmdClearText.UseVisualStyleBackColor = true;
			this.lstApps.BackColor = Color.White;
			this.lstApps.FullRowSelect = true;
			this.lstApps.Location = new Point(-2, 32);
			this.lstApps.MultiSelect = false;
			this.lstApps.Name = "lstApps";
			this.lstApps.OwnerDraw = true;
			this.lstApps.Size = new System.Drawing.Size(938, 461);
			this.lstApps.TabIndex = 12;
			this.lstApps.UseCompatibleStateImageBehavior = false;
			this.lstApps.View = View.Details;
			this.txtAppSearch.Location = new Point(520, 4);
			this.txtAppSearch.Name = "txtAppSearch";
			this.txtAppSearch.Size = new System.Drawing.Size(342, 20);
			this.txtAppSearch.TabIndex = 11;
			this.cmdUpdate.Location = new Point(10, 2);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.Size = new System.Drawing.Size(88, 25);
			this.cmdUpdate.TabIndex = 9;
			this.cmdUpdate.Text = "Refresh Repos";
			this.cmdUpdate.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Location = new Point(455, 7);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(63, 13);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "App Search";
			this.panelDownloads.Controls.Add(this.lstDownloads);
			this.panelDownloads.Location = new Point(0, 99);
			this.panelDownloads.Name = "panelDownloads";
			this.panelDownloads.Size = new System.Drawing.Size(938, 494);
			this.panelDownloads.TabIndex = 3;
			this.lstDownloads.BackColor = Color.White;
			this.lstDownloads.FullRowSelect = true;
			this.lstDownloads.Location = new Point(0, 1);
			this.lstDownloads.Name = "lstDownloads";
			this.lstDownloads.OwnerDraw = true;
			this.lstDownloads.Size = new System.Drawing.Size(938, 493);
			this.lstDownloads.TabIndex = 6;
			this.lstDownloads.UseCompatibleStateImageBehavior = false;
			this.lstDownloads.View = View.Details;
			this.panelTools.BackColor = SystemColors.InactiveCaptionText;
			this.panelTools.Controls.Add(this.childPanelRepo);
			this.panelTools.Controls.Add(this.childPanelRevoke);
			this.panelTools.Controls.Add(this.childPanelAppleIds);
			this.panelTools.Controls.Add(this.Panel2);
			this.panelTools.Location = new Point(-2, 99);
			this.panelTools.Name = "panelTools";
			this.panelTools.Size = new System.Drawing.Size(939, 494);
			this.panelTools.TabIndex = 4;
			this.childPanelRepo.Controls.Add(this.txtCydia);
			this.childPanelRepo.Controls.Add(this.cmdAddCydia);
			this.childPanelRepo.Controls.Add(this.Label4);
			this.childPanelRepo.Controls.Add(this.lstCydia);
			this.childPanelRepo.Location = new Point(203, 1);
			this.childPanelRepo.Name = "childPanelRepo";
			this.childPanelRepo.Size = new System.Drawing.Size(736, 493);
			this.childPanelRepo.TabIndex = 8;
			this.txtCydia.Location = new Point(76, 6);
			this.txtCydia.Name = "txtCydia";
			this.txtCydia.Size = new System.Drawing.Size(549, 20);
			this.txtCydia.TabIndex = 2;
			this.cmdAddCydia.Location = new Point(631, 6);
			this.cmdAddCydia.Name = "cmdAddCydia";
			this.cmdAddCydia.Size = new System.Drawing.Size(99, 22);
			this.cmdAddCydia.TabIndex = 3;
			this.cmdAddCydia.Text = "Add Repo";
			this.cmdAddCydia.UseVisualStyleBackColor = true;
			this.Label4.AutoSize = true;
			this.Label4.Location = new Point(9, 9);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(63, 13);
			this.Label4.TabIndex = 1;
			this.Label4.Text = "Repos URL";
			this.lstCydia.BackColor = Color.White;
			this.lstCydia.FullRowSelect = true;
			this.lstCydia.Location = new Point(-1, 31);
			this.lstCydia.Name = "lstCydia";
			this.lstCydia.OwnerDraw = true;
			this.lstCydia.Size = new System.Drawing.Size(737, 462);
			this.lstCydia.TabIndex = 0;
			this.lstCydia.UseCompatibleStateImageBehavior = false;
			this.lstCydia.View = View.Details;
			this.childPanelRevoke.Controls.Add(this.txtPassword);
			this.childPanelRevoke.Controls.Add(this.Label3);
			this.childPanelRevoke.Controls.Add(this.cmdRefreshRevoke);
			this.childPanelRevoke.Controls.Add(this.Label2);
			this.childPanelRevoke.Controls.Add(this.cmbAppleId);
			this.childPanelRevoke.Controls.Add(this.lstRevoke);
			this.childPanelRevoke.Location = new Point(203, 0);
			this.childPanelRevoke.Name = "childPanelRevoke";
			this.childPanelRevoke.Size = new System.Drawing.Size(736, 493);
			this.childPanelRevoke.TabIndex = 1;
			this.txtPassword.Location = new Point(370, 6);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(201, 20);
			this.txtPassword.TabIndex = 10;
			this.Label3.AutoSize = true;
			this.Label3.Location = new Point(310, 10);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(53, 13);
			this.Label3.TabIndex = 9;
			this.Label3.Text = "Password";
			this.cmdRefreshRevoke.Location = new Point(630, 5);
			this.cmdRefreshRevoke.Name = "cmdRefreshRevoke";
			this.cmdRefreshRevoke.Size = new System.Drawing.Size(103, 23);
			this.cmdRefreshRevoke.TabIndex = 8;
			this.cmdRefreshRevoke.Text = "Load Account";
			this.cmdRefreshRevoke.UseVisualStyleBackColor = true;
			this.Label2.AutoSize = true;
			this.Label2.Location = new Point(7, 8);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 7;
			this.Label2.Text = "Account";
			this.cmbAppleId.FormattingEnabled = true;
			this.cmbAppleId.Location = new Point(61, 5);
			this.cmbAppleId.Name = "cmbAppleId";
			this.cmbAppleId.Size = new System.Drawing.Size(227, 21);
			this.cmbAppleId.TabIndex = 6;
			this.lstRevoke.BackColor = Color.White;
			this.lstRevoke.FullRowSelect = true;
			this.lstRevoke.Location = new Point(-1, 33);
			this.lstRevoke.Name = "lstRevoke";
			this.lstRevoke.OwnerDraw = true;
			this.lstRevoke.Size = new System.Drawing.Size(735, 457);
			this.lstRevoke.TabIndex = 5;
			this.lstRevoke.UseCompatibleStateImageBehavior = false;
			this.lstRevoke.View = View.Details;
			this.childPanelAppleIds.Controls.Add(this.lstAccount);
			this.childPanelAppleIds.Location = new Point(203, 0);
			this.childPanelAppleIds.Name = "childPanelAppleIds";
			this.childPanelAppleIds.Size = new System.Drawing.Size(736, 493);
			this.childPanelAppleIds.TabIndex = 6;
			this.lstAccount.BackColor = Color.White;
			this.lstAccount.FullRowSelect = true;
			this.lstAccount.Location = new Point(0, -1);
			this.lstAccount.Name = "lstAccount";
			this.lstAccount.OwnerDraw = true;
			this.lstAccount.Size = new System.Drawing.Size(734, 491);
			this.lstAccount.TabIndex = 0;
			this.lstAccount.UseCompatibleStateImageBehavior = false;
			this.lstAccount.View = View.Details;
			this.Panel2.BackColor = Color.WhiteSmoke;
			this.Panel2.Controls.Add(this.lblDeleteAppId);
			this.Panel2.Controls.Add(this.lblAccount);
			this.Panel2.Controls.Add(this.lblRevokeCert);
			this.Panel2.Controls.Add(this.lblCydiaRepos);
			this.Panel2.Location = new Point(2, -1);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(200, 494);
			this.Panel2.TabIndex = 0;
			this.lblDeleteAppId.BackColor = Color.WhiteSmoke;
			this.lblDeleteAppId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 163);
			this.lblDeleteAppId.Location = new Point(1, 110);
			this.lblDeleteAppId.Name = "lblDeleteAppId";
			this.lblDeleteAppId.Size = new System.Drawing.Size(198, 35);
			this.lblDeleteAppId.TabIndex = 3;
			this.lblDeleteAppId.Text = "     Delete AppId";
			this.lblDeleteAppId.TextAlign = ContentAlignment.MiddleLeft;
			this.lblAccount.BackColor = Color.WhiteSmoke;
			this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 163);
			this.lblAccount.Location = new Point(1, 38);
			this.lblAccount.Name = "lblAccount";
			this.lblAccount.Size = new System.Drawing.Size(198, 35);
			this.lblAccount.TabIndex = 2;
			this.lblAccount.Text = "     Account Manager";
			this.lblAccount.TextAlign = ContentAlignment.MiddleLeft;
			this.lblRevokeCert.BackColor = Color.WhiteSmoke;
			this.lblRevokeCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 163);
			this.lblRevokeCert.Location = new Point(1, 74);
			this.lblRevokeCert.Name = "lblRevokeCert";
			this.lblRevokeCert.Size = new System.Drawing.Size(198, 35);
			this.lblRevokeCert.TabIndex = 1;
			this.lblRevokeCert.Text = "     Revoke Certificate";
			this.lblRevokeCert.TextAlign = ContentAlignment.MiddleLeft;
			this.lblCydiaRepos.BackColor = Color.WhiteSmoke;
			this.lblCydiaRepos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 163);
			this.lblCydiaRepos.Location = new Point(1, 2);
			this.lblCydiaRepos.Name = "lblCydiaRepos";
			this.lblCydiaRepos.Size = new System.Drawing.Size(198, 35);
			this.lblCydiaRepos.TabIndex = 0;
			this.lblCydiaRepos.Text = "     Cydia Repos";
			this.lblCydiaRepos.TextAlign = ContentAlignment.MiddleLeft;
			this.panelDevice.BackColor = Color.Transparent;
			this.panelDevice.Controls.Add(this.cmdSupport);
			this.panelDevice.Controls.Add(this.cmdCheckForUpdate);
			this.panelDevice.Controls.Add(this.cmdAbout);
			this.panelDevice.Controls.Add(this.cmdFixCrash);
			this.panelDevice.Controls.Add(this.cmdInstallFromFile);
			this.panelDevice.Controls.Add(this.picLoading);
			this.panelDevice.Controls.Add(this.cmdResignExpired);
			this.panelDevice.Controls.Add(this.lblPhone);
			this.panelDevice.Controls.Add(this.lblModelNumber);
			this.panelDevice.Controls.Add(this.lblSerialNumber);
			this.panelDevice.Controls.Add(this.lblProductionVersion);
			this.panelDevice.Controls.Add(this.lblDeviceClass);
			this.panelDevice.Controls.Add(this.lblDeviceName);
			this.panelDevice.Controls.Add(this.cmdResignAll);
			this.panelDevice.Controls.Add(this.picDevice);
			this.panelDevice.Controls.Add(this.lstAppOnDevice);
			this.panelDevice.Controls.Add(this.Label6);
			this.panelDevice.Controls.Add(this.Label5);
			this.panelDevice.Controls.Add(this.cmbDevice);
			this.panelDevice.Location = new Point(0, 98);
			this.panelDevice.Name = "panelDevice";
			this.panelDevice.Size = new System.Drawing.Size(938, 494);
			this.panelDevice.TabIndex = 5;
			this.cmdCheckForUpdate.Location = new Point(139, 451);
			this.cmdCheckForUpdate.Name = "cmdCheckForUpdate";
			this.cmdCheckForUpdate.Size = new System.Drawing.Size(111, 23);
			this.cmdCheckForUpdate.TabIndex = 18;
			this.cmdCheckForUpdate.Text = "Check for Update";
			this.cmdCheckForUpdate.UseVisualStyleBackColor = true;
			this.cmdAbout.Location = new Point(261, 451);
			this.cmdAbout.Name = "cmdAbout";
			this.cmdAbout.Size = new System.Drawing.Size(75, 23);
			this.cmdAbout.TabIndex = 17;
			this.cmdAbout.Text = "About";
			this.cmdAbout.UseVisualStyleBackColor = true;
			this.cmdFixCrash.Location = new Point(744, 7);
			this.cmdFixCrash.Name = "cmdFixCrash";
			this.cmdFixCrash.Size = new System.Drawing.Size(81, 23);
			this.cmdFixCrash.TabIndex = 16;
			this.cmdFixCrash.Text = "Fix Crash";
			this.cmdFixCrash.UseVisualStyleBackColor = true;
			this.cmdFixCrash.Visible = false;
			this.cmdInstallFromFile.Location = new Point(832, 7);
			this.cmdInstallFromFile.Name = "cmdInstallFromFile";
			this.cmdInstallFromFile.Size = new System.Drawing.Size(96, 23);
			this.cmdInstallFromFile.TabIndex = 15;
			this.cmdInstallFromFile.Text = "Install from IPA";
			this.cmdInstallFromFile.UseVisualStyleBackColor = true;
			this.cmdInstallFromFile.Visible = false;
			this.picLoading.Image = (Image)componentResourceManager.GetObject("picLoading.Image");
			this.picLoading.Location = new Point(155, 110);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(59, 56);
			this.picLoading.TabIndex = 13;
			this.picLoading.TabStop = false;
			this.cmdResignExpired.Location = new Point(466, 7);
			this.cmdResignExpired.Name = "cmdResignExpired";
			this.cmdResignExpired.Size = new System.Drawing.Size(103, 23);
			this.cmdResignExpired.TabIndex = 12;
			this.cmdResignExpired.Text = "Resign Expired";
			this.cmdResignExpired.UseVisualStyleBackColor = true;
			this.cmdResignExpired.Visible = false;
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new Point(50, 304);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(0, 13);
			this.lblPhone.TabIndex = 11;
			this.lblModelNumber.AutoSize = true;
			this.lblModelNumber.Location = new Point(50, 416);
			this.lblModelNumber.Name = "lblModelNumber";
			this.lblModelNumber.Size = new System.Drawing.Size(0, 13);
			this.lblModelNumber.TabIndex = 10;
			this.lblSerialNumber.AutoSize = true;
			this.lblSerialNumber.Location = new Point(50, 388);
			this.lblSerialNumber.Name = "lblSerialNumber";
			this.lblSerialNumber.Size = new System.Drawing.Size(0, 13);
			this.lblSerialNumber.TabIndex = 9;
			this.lblProductionVersion.AutoSize = true;
			this.lblProductionVersion.Location = new Point(50, 360);
			this.lblProductionVersion.Name = "lblProductionVersion";
			this.lblProductionVersion.Size = new System.Drawing.Size(0, 13);
			this.lblProductionVersion.TabIndex = 8;
			this.lblDeviceClass.AutoSize = true;
			this.lblDeviceClass.Location = new Point(50, 332);
			this.lblDeviceClass.Name = "lblDeviceClass";
			this.lblDeviceClass.Size = new System.Drawing.Size(0, 13);
			this.lblDeviceClass.TabIndex = 7;
			this.lblDeviceName.AutoSize = true;
			this.lblDeviceName.Location = new Point(50, 276);
			this.lblDeviceName.Name = "lblDeviceName";
			this.lblDeviceName.Size = new System.Drawing.Size(0, 13);
			this.lblDeviceName.TabIndex = 6;
			this.cmdResignAll.Location = new Point(575, 7);
			this.cmdResignAll.Name = "cmdResignAll";
			this.cmdResignAll.Size = new System.Drawing.Size(75, 23);
			this.cmdResignAll.TabIndex = 5;
			this.cmdResignAll.Text = "Resign All";
			this.cmdResignAll.UseVisualStyleBackColor = true;
			this.cmdResignAll.Visible = false;
			this.picDevice.Location = new Point(89, 41);
			this.picDevice.Name = "picDevice";
			this.picDevice.Size = new System.Drawing.Size(196, 195);
			this.picDevice.SizeMode = PictureBoxSizeMode.Zoom;
			this.picDevice.TabIndex = 4;
			this.picDevice.TabStop = false;
			this.picDevice.Visible = false;
			this.lstAppOnDevice.BackColor = Color.White;
			this.lstAppOnDevice.FullRowSelect = true;
			this.lstAppOnDevice.Location = new Point(382, 37);
			this.lstAppOnDevice.Name = "lstAppOnDevice";
			this.lstAppOnDevice.OwnerDraw = true;
			this.lstAppOnDevice.Size = new System.Drawing.Size(556, 457);
			this.lstAppOnDevice.TabIndex = 3;
			this.lstAppOnDevice.UseCompatibleStateImageBehavior = false;
			this.lstAppOnDevice.View = View.Details;
			this.Label6.AutoSize = true;
			this.Label6.Location = new Point(387, 12);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(73, 13);
			this.Label6.TabIndex = 2;
			this.Label6.Text = "Installed Apps";
			this.Label5.AutoSize = true;
			this.Label5.Location = new Point(5, 11);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(41, 13);
			this.Label5.TabIndex = 1;
			this.Label5.Text = "Device";
			this.cmbDevice.FormattingEnabled = true;
			this.cmbDevice.Location = new Point(50, 7);
			this.cmbDevice.Name = "cmbDevice";
			this.cmbDevice.Size = new System.Drawing.Size(324, 21);
			this.cmbDevice.TabIndex = 0;
			this.cmdSupport.Location = new Point(53, 451);
			this.cmdSupport.Name = "cmdSupport";
			this.cmdSupport.Size = new System.Drawing.Size(75, 23);
			this.cmdSupport.TabIndex = 19;
			this.cmdSupport.Text = "Support";
			this.cmdSupport.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(939, 592);
			base.Controls.Add(this.panelDevice);
			base.Controls.Add(this.panelTools);
			base.Controls.Add(this.panelApp);
			base.Controls.Add(this.panelDownloads);
			base.Controls.Add(this.Panel1);
			base.Controls.Add(this.panelHome);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmSuperImpactor";
			this.Text = "SuperImpactor";
			this.Panel1.ResumeLayout(false);
			((ISupportInitialize)this.picHomeBtn).EndInit();
			((ISupportInitialize)this.picDownloadBtn).EndInit();
			((ISupportInitialize)this.picToolBtn).EndInit();
			((ISupportInitialize)this.picDeviceBtn).EndInit();
			((ISupportInitialize)this.picAppBtn).EndInit();
			((ISupportInitialize)this.picLogo).EndInit();
			this.panelHome.ResumeLayout(false);
			this.panelApp.ResumeLayout(false);
			this.panelApp.PerformLayout();
			this.panelDownloads.ResumeLayout(false);
			this.panelTools.ResumeLayout(false);
			this.childPanelRepo.ResumeLayout(false);
			this.childPanelRepo.PerformLayout();
			this.childPanelRevoke.ResumeLayout(false);
			this.childPanelRevoke.PerformLayout();
			this.childPanelAppleIds.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.panelDevice.ResumeLayout(false);
			this.panelDevice.PerformLayout();
			((ISupportInitialize)this.picLoading).EndInit();
			((ISupportInitialize)this.picDevice).EndInit();
			base.ResumeLayout(false);
		}

		private void lblAccount_Click(object sender, EventArgs e)
		{
			this.crrTools = 1;
			this.lblAccount.BackColor = Color.FromName("GradientActiveCaption");
			this.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke");
			this.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke");
			this.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke");
			this.childPanelAppleIds.BringToFront();
			this.LoadAccounts();
		}

		private void lblAccount_MouseLeave(object sender, EventArgs e)
		{
			if (this.crrTools != 1)
			{
				this.lblAccount.BackColor = Color.FromName("WhiteSmoke");
			}
			else
			{
				this.lblAccount.BackColor = Color.FromName("GradientActiveCaption");
			}
		}

		private void lblAccount_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblAccount.BackColor = Color.FromName("Info");
		}

		private void lblCydiaRepos_Click(object sender, EventArgs e)
		{
			this.crrTools = 0;
			this.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption");
			this.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke");
			this.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke");
			this.lblAccount.BackColor = Color.FromName("WhiteSmoke");
			this.lstCydia.Clear();
			this.LoadCydiaRepos("");
			this.childPanelRepo.BringToFront();
		}

		private void lblCydiaRepos_MouseLeave(object sender, EventArgs e)
		{
			if (this.crrTools != 0)
			{
				this.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke");
			}
			else
			{
				this.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption");
			}
		}

		private void lblCydiaRepos_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblCydiaRepos.BackColor = Color.FromName("Info");
		}

		private void lblDeleteAppId_Click(object sender, EventArgs e)
		{
			Dictionary<string, string>.Enumerator enumerator = new Dictionary<string, string>.Enumerator();
			this.crrTools = 3;
			this.lblDeleteAppId.BackColor = Color.FromName("GradientActiveCaption");
			this.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke");
			this.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke");
			this.lblAccount.BackColor = Color.FromName("WhiteSmoke");
			this.cmbAppleId.Items.Clear();
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
			this.lstRevoke.Clear();
			this.childPanelRevoke.BringToFront();
		}

		private void lblDeleteAppId_MouseLeave(object sender, EventArgs e)
		{
			if (this.crrTools != 3)
			{
				this.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke");
			}
			else
			{
				this.lblDeleteAppId.BackColor = Color.FromName("GradientActiveCaption");
			}
		}

		private void lblDeleteAppId_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDeleteAppId.BackColor = Color.FromName("Info");
		}

		private void lblRevokeCert_Click(object sender, EventArgs e)
		{
			Dictionary<string, string>.Enumerator enumerator = new Dictionary<string, string>.Enumerator();
			this.crrTools = 2;
			this.lblRevokeCert.BackColor = Color.FromName("GradientActiveCaption");
			this.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke");
			this.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke");
			this.lblAccount.BackColor = Color.FromName("WhiteSmoke");
			this.cmbAppleId.Items.Clear();
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
			this.lstRevoke.Clear();
			this.childPanelRevoke.BringToFront();
		}

		private void lblRevokeCert_MouseLeave(object sender, EventArgs e)
		{
			if (this.crrTools != 2)
			{
				this.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke");
			}
			else
			{
				this.lblRevokeCert.BackColor = Color.FromName("GradientActiveCaption");
			}
		}

		private void lblRevokeCert_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblRevokeCert.BackColor = Color.FromName("Info");
		}

		private void LoadAccounts()
		{
			this.lstAcc = Database.GetAccounts();
			this.lstAccount.Clear();
			this.lstAccount.View = View.Details;
			this.lstAccount.Columns.Add("Saved Apple Ids", checked(this.childPanelAppleIds.Width - 5));
			int count = checked(this.lstAcc.Keys.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				ExtraData extraDatum = new ExtraData()
				{
					HeaderText = this.lstAcc.Keys.ElementAt<string>(i),
					MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("appleid")),
					ButtonText2 = "REMOVE"
				};
				this.lstAccount.Items.Add("").Tag = extraDatum;
			}
		}

		private object LoadApps()
		{
			object obj;
			Application.DoEvents();
			NSDictionary nSDictionary = AppleService.login(this.cmbAppleId.Text, this.txtPassword.Text);
			if (nSDictionary.ContainsKey("myacinfo"))
			{
				string str = nSDictionary.ObjectForKey("myacinfo").ToString();
				Application.DoEvents();
				nSDictionary = AppleService.listTeam(str);
				string str1 = "";
				if (nSDictionary.ContainsKey("teams"))
				{
					NSArray nSArray = (NSArray)nSDictionary.ObjectForKey("teams");
					if (nSArray.get_Count() > 0)
					{
						NSDictionary nSDictionary1 = (NSDictionary)nSArray.ElementAt<NSObject>(0);
						if (nSDictionary1.ContainsKey("teamId"))
						{
							str1 = nSDictionary1.ObjectForKey("teamId").ToString();
						}
					}
				}
				if (Operators.CompareString(str1, "", false) != 0)
				{
					this.lstRevoke.Clear();
					this.lstRevoke.Columns.Add("Name", checked(this.childPanelRevoke.Width - 5));
					this.lstRevoke.View = View.Details;
					this.lstRevoke.Tag = str1;
					Application.DoEvents();
					nSDictionary = AppleService.appIds(str1);
					string str2 = "";
					if (nSDictionary.ContainsKey("appIds"))
					{
						NSArray nSArray1 = (NSArray)nSDictionary.ObjectForKey("appIds");
						int count = checked(nSArray1.get_Count() - 1);
						for (int i = 0; i <= count; i = checked(i + 1))
						{
							NSDictionary nSDictionary2 = (NSDictionary)nSArray1.ElementAt<NSObject>(i);
							if (nSDictionary2.ContainsKey("appIdId") & nSDictionary2.ContainsKey("name"))
							{
								str2 = nSDictionary2.ObjectForKey("appIdId").ToString();
								ExtraData extraDatum = new ExtraData()
								{
									HeaderText = nSDictionary2.ObjectForKey("name").ToString(),
									MinorText = nSDictionary2.ObjectForKey("appIdId").ToString(),
									MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("appid")),
									ButtonText2 = "REMOVE"
								};
								this.lstRevoke.Items.Add("").Tag = extraDatum;
							}
						}
						if (this.lstRevoke.Items.Count == 0)
						{
							obj = "No AppId";
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
				string str1 = "";
				if (nSDictionary.ContainsKey("teams"))
				{
					NSArray nSArray = (NSArray)nSDictionary.ObjectForKey("teams");
					if (nSArray.get_Count() > 0)
					{
						NSDictionary nSDictionary1 = (NSDictionary)nSArray.ElementAt<NSObject>(0);
						if (nSDictionary1.ContainsKey("teamId"))
						{
							str1 = nSDictionary1.ObjectForKey("teamId").ToString();
						}
					}
				}
				if (Operators.CompareString(str1, "", false) != 0)
				{
					Application.DoEvents();
					nSDictionary = AppleService.allDevelopmentCert(str1);
					this.lstRevoke.Clear();
					this.lstRevoke.Columns.Add("Name", checked(this.childPanelRevoke.Width - 5));
					this.lstRevoke.View = View.Details;
					this.lstRevoke.Tag = str1;
					if (nSDictionary.ContainsKey("certificates"))
					{
						NSArray nSArray1 = (NSArray)nSDictionary.ObjectForKey("certificates");
						int count = checked(nSArray1.get_Count() - 1);
						for (int i = 0; i <= count; i = checked(i + 1))
						{
							NSDictionary nSDictionary2 = (NSDictionary)nSArray1.ElementAt<NSObject>(i);
							if (nSDictionary2.ContainsKey("name") & nSDictionary2.ContainsKey("serialNumber"))
							{
								ExtraData extraDatum = new ExtraData();
								if (!nSDictionary2.ContainsKey("machineName"))
								{
									extraDatum.HeaderText = nSDictionary2.ObjectForKey("name").ToString();
								}
								else
								{
									extraDatum.HeaderText = string.Concat(nSDictionary2.ObjectForKey("name").ToString(), " - ", nSDictionary2.ObjectForKey("machineName").ToString());
								}
								extraDatum.MinorText = nSDictionary2.ObjectForKey("serialNumber").ToString();
								extraDatum.DescText = nSDictionary2.ObjectForKey("expirationDate").ToString();
								extraDatum.MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("cert"));
								extraDatum.ButtonText2 = "REMOVE";
								this.lstRevoke.Items.Add("").Tag = extraDatum;
							}
						}
						if (this.lstRevoke.Items.Count == 0)
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

		private object LoadCydiaRepos(string cydiaReposName = "")
		{
			SQLiteDataReader sQLiteDataReader = (new SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader();
			this.lstCydia.Clear();
			this.lstCydia.View = View.Details;
			this.lstCydia.Columns.Add("Repos", checked(this.childPanelRepo.Width - 5));
			int integer = -1;
			while (sQLiteDataReader.Read())
			{
				ExtraData extraDatum = new ExtraData()
				{
					HeaderText = Conversions.ToString(sQLiteDataReader.get_Item("name")),
					MinorText = Conversions.ToString(sQLiteDataReader.get_Item("path")),
					MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("repos")),
					ButtonText2 = "REMOVE"
				};
				this.lstCydia.Items.Add("").Tag = extraDatum;
				if (Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("path"), cydiaReposName, false))
				{
					integer = Conversions.ToInteger(sQLiteDataReader.get_Item("id"));
				}
			}
			return integer;
		}

		public static bool LoadPackages(string cydiaRepos)
		{
			bool flag;
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
					flag = false;
					ProjectData.ClearProjectError();
					return flag;
				}
				ProjectData.ClearProjectError();
			}
			flag = true;
			return flag;
		}

		private void lstAccount_Button2Click(object sender, FileEventArgs e)
		{
			if (this.lstAccount.SelectedItems.Count <= 0)
			{
				Interaction.MsgBox("Select account to remove", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Database.DeleteAccount(((ExtraData)this.lstAccount.SelectedItems[0].Tag).HeaderText);
				this.LoadAccounts();
			}
		}

		private void lstAppOnDevice_Button1Click(object sender, FileEventArgs e)
		{
			string str = null;
			string str1;
			Install install = new Install();
			string str2 = "";
			str2 = e.data.DescText.Substring(36);
			str1 = (!str2.StartsWith("clone") ? "" : str2.Substring(5, 7));
			Database.getInstalledApp(str2, this.cmbDevice.Text.Substring(checked(this.cmbDevice.Text.Length - 40)), ref str);
			if (!File.Exists(string.Concat(AppConst.m_rootPath, "\\download\\", str)))
			{
				Interaction.MsgBox("IPA file have been remove from Downloads. Please download this app again then install", MsgBoxStyle.OkOnly, "Error");
			}
			else
			{
				install.installFromFile(string.Concat(AppConst.m_rootPath, "\\download\\", str), str1, e.data.HeaderText);
			}
		}

		private async void lstAppOnDevice_Button2Click(object sender, FileEventArgs e)
		{
			string str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "\\libimobiledevice\\ideviceinstaller.exe"), string.Concat("-u ", this.cmbDevice.Text.Substring(checked(this.cmbDevice.Text.Length - 40)), " -U ", e.data.DescText), false);
			this.cmbDevice.Text = "";
		}

		private void lstAppOnDevice_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lstApps_Button1Click(object sender, FileEventArgs e)
		{
			string filename;
			string str = null;
			DownloadProgress downloadProgress = new DownloadProgress();
			if (e.data.AppDetailObj.Filename.IndexOf("dailyuploads.net") < 0)
			{
				if (e.data.AppDetailObj.Filename.EndsWith(".deb"))
				{
					str = string.Concat(e.data.AppDetailObj.Name, ".deb");
				}
				filename = e.data.AppDetailObj.Filename;
			}
			else
			{
				filename = e.data.AppDetailObj.Filename;
				str = "checking...ipa";
			}
			Common.Download(downloadProgress, filename, str);
		}

		private void lstApps_Button2Click(object sender, FileEventArgs e)
		{
		}

		private void lstApps_DoubleClick(object sender, EventArgs e)
		{
			if (this.lstApps.SelectedItems.Count > 0)
			{
				AppDetail appDetail = new AppDetail();
				appDetail.showApp(((ExtraData)this.lstApps.SelectedItems[0].Tag).AppDetailObj);
			}
		}

		private void lstApps_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lstCydia_Button2Click(object sender, FileEventArgs e)
		{
			if (this.lstCydia.SelectedItems.Count <= 0)
			{
				Interaction.MsgBox("No repos to remove", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				string str = string.Concat("select * from cydia_repos WHERE path='", ((ExtraData)this.lstCydia.SelectedItems[0].Tag).MinorText, "'");
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

		private void lstCydia_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lstDownloads_Button1Click(object sender, FileEventArgs e)
		{
			Install install = new Install();
			install.installFromFile(string.Concat(AppConst.m_rootPath, "\\download\\", e.data.HeaderText), "", "");
		}

		private void lstDownloads_Button2Click(object sender, FileEventArgs e)
		{
			if (this.lstDownloads.SelectedItems.Count <= 0)
			{
				Interaction.MsgBox("No file selected", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				File.Delete(string.Concat(AppConst.m_rootPath, "\\download\\", ((ExtraData)this.lstDownloads.SelectedItems[0].Tag).HeaderText));
				this.lstDownloads.Items.Remove(this.lstDownloads.SelectedItems[0]);
			}
		}

		private void lstRevoke_Button2Click(object sender, FileEventArgs e)
		{
			if (this.lstRevoke.SelectedItems.Count <= 0)
			{
				Interaction.MsgBox("No Certificate/AppId selected", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				if (this.lblDeleteAppId.BackColor != Color.FromName("GradientActiveCaption"))
				{
					AppleService.revokeCertificate(((ExtraData)this.lstRevoke.SelectedItems[0].Tag).MinorText, Conversions.ToString(this.lstRevoke.Tag));
				}
				else
				{
					AppleService.deleteAppId(((ExtraData)this.lstRevoke.SelectedItems[0].Tag).MinorText, Conversions.ToString(this.lstRevoke.Tag));
				}
				this.lstRevoke.Items.Remove(this.lstRevoke.SelectedItems[0]);
			}
		}

		private void MySearchMethod()
		{
			this.ReloadApps(this.txtAppSearch.Text);
		}

		public void onDownloadComplete()
		{
			if (this.isShowDownload)
			{
				this.picDownloadBtn_Click(null, null);
			}
		}

		private void Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panelDevice_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panelDownloads_Paint(object sender, PaintEventArgs e)
		{
		}

		public static async Task ParsePackages(int cydiaId, UpdateCydia frm = null, object fn = null, string cydiaUrl = "")
		{
			IEnumerator enumerator = null;
			try
			{
				File.Delete("Packages.xml");
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
			string str = await Common.RunExe(string.Concat(AppConst.m_rootPath, "/repo2xml.exe"), string.Concat("Packages Packages.xml \"", cydiaUrl, "\""), true);
			AppConst.logger.Debug(string.Concat("Convert repo2xml: ", str));
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load("Packages.xml");
			XmlNodeList xmlNodeLists = xmlDocument.DocumentElement.SelectNodes("/allapp/app");
			SQLiteCommand sQLiteCommand = new SQLiteCommand("INSERT INTO list_app(cydia_repos,package,version,section,depends,arch,filename,size,icon,description,name,author,homepage) \r\n                                                VALUES(@cydia_repos,@package,@version,@section,@depends,@arch,@filename,@size,@icon,@description,@name,@author,@homepage)", AppConst.m_dbConnection);
			int count = xmlNodeLists.Count;
			int num = 0;
			try
			{
				enumerator = xmlNodeLists.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode current = (XmlNode)enumerator.Current;
					SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
					parameters.AddWithValue("@cydia_repos", cydiaId);
					parameters.AddWithValue("@package", current.SelectSingleNode("Package").InnerText);
					parameters.AddWithValue("@version", current.SelectSingleNode("Version").InnerText);
					parameters.AddWithValue("@section", current.SelectSingleNode("Section").InnerText);
					parameters.AddWithValue("@depends", current.SelectSingleNode("Depends").InnerText);
					parameters.AddWithValue("@arch", current.SelectSingleNode("Architecture").InnerText);
					parameters.AddWithValue("@filename", current.SelectSingleNode("Filename").InnerText);
					parameters.AddWithValue("@size", current.SelectSingleNode("Size").InnerText);
					parameters.AddWithValue("@icon", current.SelectSingleNode("Icon").InnerText);
					parameters.AddWithValue("@description", current.SelectSingleNode("Description").InnerText);
					parameters.AddWithValue("@name", current.SelectSingleNode("Name").InnerText);
					parameters.AddWithValue("@author", current.SelectSingleNode("Author").InnerText);
					parameters.AddWithValue("@homepage", current.SelectSingleNode("Homepage").InnerText);
					parameters = null;
					sQLiteCommand.ExecuteNonQuery();
					num = checked(num + 1);
					if (frm != null)
					{
						UpdateCydia updateCydium = frm;
						Delegate @delegate = (Delegate)fn;
						object[] objArray = new object[] { "", checked((int)Math.Round(Math.Round((double)(checked(num * 100)) / (double)count))) };
						updateCydium.Invoke(@delegate, objArray);
					}
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

		private void picAppBtn_Click(object sender, EventArgs e)
		{
			this.picAppBtn.BorderStyle = BorderStyle.Fixed3D;
			this.picDeviceBtn.BorderStyle = BorderStyle.None;
			this.picDownloadBtn.BorderStyle = BorderStyle.None;
			this.picHomeBtn.BorderStyle = BorderStyle.None;
			this.picToolBtn.BorderStyle = BorderStyle.None;
			this.panelApp.BringToFront();
			this.isShowDownload = false;
			if (this.firstTimeLoadApp)
			{
				this.firstTimeLoadApp = false;
				base.Invoke(new frmSuperImpactor.MySearchMethodDelegrate(this.MySearchMethod));
			}
		}

		private void picDevice_Click(object sender, EventArgs e)
		{
		}

		private void picDeviceBtn_Click(object sender, EventArgs e)
		{
			this.picAppBtn.BorderStyle = BorderStyle.None;
			this.picDeviceBtn.BorderStyle = BorderStyle.Fixed3D;
			this.picDownloadBtn.BorderStyle = BorderStyle.None;
			this.picHomeBtn.BorderStyle = BorderStyle.None;
			this.picToolBtn.BorderStyle = BorderStyle.None;
			this.isShowDownload = false;
			this.panelDevice.BringToFront();
			this.cmbDevice.Text = "";
		}

		private void picDownloadBtn_Click(object sender, EventArgs e)
		{
			string str;
			double num;
			this.picAppBtn.BorderStyle = BorderStyle.None;
			this.picDeviceBtn.BorderStyle = BorderStyle.None;
			this.picDownloadBtn.BorderStyle = BorderStyle.Fixed3D;
			this.picHomeBtn.BorderStyle = BorderStyle.None;
			this.picToolBtn.BorderStyle = BorderStyle.None;
			this.isShowDownload = true;
			this.panelDownloads.BringToFront();
			this.lstDownloads.Clear();
			this.lstDownloads.View = View.Details;
			this.lstDownloads.Columns.Add("Name", checked(base.Width - 20));
			string[] files = Directory.GetFiles(string.Concat(AppConst.m_rootPath, "\\download\\"), "*.ipa");
			int num1 = Information.UBound(files, 1);
			for (int i = 0; i <= num1; i = checked(i + 1))
			{
				FileInfo fileInfo = new FileInfo(files[i]);
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
				ExtraData extraDatum = new ExtraData()
				{
					HeaderText = fileInfo.Name,
					MinorText = str,
					DescText = Conversions.ToString(fileInfo.LastWriteTime)
				};
				if (!File.Exists(string.Concat(fileInfo.FullName, ".png")))
				{
					extraDatum.MainImage = new Bitmap((Bitmap)Resources.ResourceManager.GetObject("ipafile"));
				}
				else
				{
					extraDatum.MainImage = new Bitmap(string.Concat(fileInfo.Name, ".png"));
				}
				extraDatum.ButtonText1 = "INSTALL";
				extraDatum.ButtonText2 = "REMOVE";
				this.lstDownloads.Items.Add("").Tag = extraDatum;
			}
		}

		private void picHomeBtn_Click(object sender, EventArgs e)
		{
			this.picAppBtn.BorderStyle = BorderStyle.None;
			this.picDeviceBtn.BorderStyle = BorderStyle.None;
			this.picDownloadBtn.BorderStyle = BorderStyle.None;
			this.picHomeBtn.BorderStyle = BorderStyle.Fixed3D;
			this.picToolBtn.BorderStyle = BorderStyle.None;
			this.isShowDownload = false;
			this.panelHome.BringToFront();
		}

		private void picLogo_Click(object sender, EventArgs e)
		{
		}

		private void picToolBtn_Click(object sender, EventArgs e)
		{
			this.picAppBtn.BorderStyle = BorderStyle.None;
			this.picDeviceBtn.BorderStyle = BorderStyle.None;
			this.picDownloadBtn.BorderStyle = BorderStyle.None;
			this.picHomeBtn.BorderStyle = BorderStyle.None;
			this.picToolBtn.BorderStyle = BorderStyle.Fixed3D;
			this.isShowDownload = false;
			this.panelTools.BringToFront();
		}

		private async void ReloadApps(string search = "")
		{
			frmSuperImpactor.VB$StateMachine_246_ReloadApps variable = null;
			AsyncVoidMethodBuilder.Create().Start<frmSuperImpactor.VB$StateMachine_246_ReloadApps>(ref variable);
		}

		private void resign(bool expire)
		{
			string str = null;
			List<AppInfosResign> appInfosResigns = new List<AppInfosResign>();
			string str1 = this.cmbDevice.Text.Substring(checked(this.cmbDevice.Text.Length - 40));
			int count = checked(this.crrAppsOnDevice.Count - 1);
			for (int i = 0; i <= count; i = checked(i + 1))
			{
				bool flag = false;
				if (!expire)
				{
					flag = true;
				}
				else if (!this.lstProvision.ContainsKey(this.crrAppsOnDevice[i].Package))
				{
					flag = true;
				}
				else
				{
					DateTime item = this.lstProvision[this.crrAppsOnDevice[i].Package].eDate;
					DateTime now = DateAndTime.Now;
					flag = DateTime.Compare(item, now.Date) <= 0;
				}
				if (flag)
				{
					if (this.crrAppsOnDevice[i].Package.Length > 40)
					{
						AppInfosResign appInfosResign = new AppInfosResign()
						{
							Architecture = this.crrAppsOnDevice[i].Architecture,
							Author = this.crrAppsOnDevice[i].Author,
							Depends = this.crrAppsOnDevice[i].Depends,
							Description = this.crrAppsOnDevice[i].Description,
							Filename = this.crrAppsOnDevice[i].Filename,
							Homepage = this.crrAppsOnDevice[i].Homepage,
							Icon = this.crrAppsOnDevice[i].Icon,
							Name = this.crrAppsOnDevice[i].Name,
							Package = this.crrAppsOnDevice[i].Package.Substring(36)
						};
						if (!appInfosResign.Package.StartsWith("clone"))
						{
							appInfosResign.cloneId = "";
						}
						else
						{
							appInfosResign.cloneId = appInfosResign.Package.Substring(5, 7);
							appInfosResign.Package = appInfosResign.Package.Substring(13);
						}
						appInfosResign.Section = this.crrAppsOnDevice[i].Section;
						appInfosResign.Size = this.crrAppsOnDevice[i].Size;
						appInfosResign.Version = this.crrAppsOnDevice[i].Version;
						appInfosResign.appleId = Database.getInstalledApp(appInfosResign.Package, str1, ref str);
						if (Operators.CompareString(appInfosResign.appleId, "", false) != 0)
						{
							appInfosResign.Filename = str;
							if (this.lstAcc.ContainsKey(appInfosResign.appleId))
							{
								appInfosResign.password = this.lstAcc[appInfosResign.appleId];
							}
						}
						else
						{
							appInfosResign.password = "";
						}
						appInfosResigns.Add(appInfosResign);
					}
				}
			}
			if (!Application.OpenForms.OfType<AutoResign>().Any<AutoResign>())
			{
				AutoResign autoResign = new AutoResign();
				autoResign.ResignAsync(appInfosResigns, str1, this.cmbDevice.Text.Substring(0, checked(this.cmbDevice.Text.Length - 40)), "SuperImpactor", Common.GetHash(str1));
			}
			else
			{
				MessageBox.Show("Other Resign process is already running. Please wait until current Resign process finished!");
			}
		}

		[DllImport("user32", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

		public void SetListViewSpacing(ListView lst, int x, int y)
		{
			frmSuperImpactor.SendMessage(lst.Handle, 4149, 0, checked(checked(x * 65536) + y));
		}

		private void ThreadTask()
		{
			WebClient webClient = new WebClient();
			int num = 0;
			while (!this.isExit)
			{
				num = (checked(num + 1)) % 10;
				try
				{
					if (num == 0)
					{
						this.detectDevice();
						base.BeginInvoke(new frmSuperImpactor.DeviceInvokeDelegate(this.DeviceInvokeMethod));
					}
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					Console.WriteLine(exception.Message);
					ProjectData.ClearProjectError();
				}
				Thread.Sleep(200);
			}
		}

		private void txtAppSearch_TextChanged(object sender, EventArgs e)
		{
			this.mint_LastInitializedTimerID = checked(this.mint_LastInitializedTimerID + 1);
			int num = 500;
			if (this.txtAppSearch.Text.Length >= 6)
			{
				num = 250;
			}
			if (this.txtAppSearch.Text.Contains(" ") & !this.txtAppSearch.Text.EndsWith(" "))
			{
				num = 175;
			}
			System.Timers.Timer timer = new System.Timers.Timer((double)num);
			timer.Elapsed += new ElapsedEventHandler(this.txtAppSearch_TimerElapsed);
			timer.AutoReset = false;
			timer.Enabled = true;
		}

		private void txtAppSearch_TimerElapsed(object sender, ElapsedEventArgs e)
		{
			this.mint_LastReceivedTimerID = checked(this.mint_LastReceivedTimerID + 1);
			if (this.mint_LastReceivedTimerID == this.mint_LastInitializedTimerID)
			{
				base.Invoke(new frmSuperImpactor.MySearchMethodDelegrate(this.MySearchMethod));
			}
		}

		public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
		{
			AppConst.logger.Error(string.Concat("Exception: ", ((Exception)args.ExceptionObject).Message, " - ", ((Exception)args.ExceptionObject).StackTrace));
		}

		private class DeviceInfo
		{
			public string udid;

			public string deviceName;

			public string deviceClass;

			public string productVersion;

			public string serialNumber;

			public string modelNumber;

			public string phoneNumber;

			public DeviceInfo()
			{
				this.udid = "";
				this.deviceName = "";
				this.deviceClass = "";
				this.productVersion = "";
				this.serialNumber = "";
				this.modelNumber = "";
				this.phoneNumber = "";
			}
		}

		public delegate void DeviceInvokeDelegate();

		public delegate void MySearchMethodDelegrate();

		private class ProvisionInfo
		{
			public DateTime eDate;

			public string id;

			public ProvisionInfo()
			{
			}
		}
	}
}