Imports Claunia.PropertyList
Imports ICSharpCode.SharpZipLib.BZip2
Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NetSparkle
Imports SuperImpactor.My.Resources
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Timers
Imports System.Web
Imports System.Windows.Forms
Imports System.Xml

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class frmSuperImpactor
		Inherits Form
		Private components As IContainer

		Public Const LVM_FIRST As Long = 4096L

		Public Const LVM_SETICONSPACING As Long = 4149L

		Private crrTools As Integer

		Private lstAcc As Dictionary(Of String, String)

		Private lstProvision As Dictionary(Of String, frmSuperImpactor.ProvisionInfo)

		Private sparkle As NetSparkle.Sparkle

		Private isNewApp As Boolean

		Private firstTimeLoadApp As Boolean

		Private mint_LastReceivedTimerID As Integer

		Private mint_LastInitializedTimerID As Integer

		Private trd As Thread

		Private isExit As Boolean

		Private listDevice As List(Of frmSuperImpactor.DeviceInfo)

		Private isShowDownload As Boolean

		Public crrAppsOnDevice As List(Of AppInfos)

		Friend Overridable Property childPanelAppleIds As Panel

		Friend Overridable Property childPanelRepo As Panel

		Friend Overridable Property childPanelRevoke As Panel

		Friend Overridable Property cmbAppleId As ComboBox
			Get
				stackVariable1 = Me._cmbAppleId
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ComboBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmbAppleId_SelectedIndexChanged)
				Dim comboBox As System.Windows.Forms.ComboBox = Me._cmbAppleId
				If (comboBox IsNot Nothing) Then
					RemoveHandler comboBox.SelectedIndexChanged,  eventHandler
				End If
				Me._cmbAppleId = value
				comboBox = Me._cmbAppleId
				If (comboBox IsNot Nothing) Then
					AddHandler comboBox.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmbDevice As ComboBox
			Get
				stackVariable1 = Me._cmbDevice
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ComboBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmbDevice_TextChanged)
				Dim comboBox As System.Windows.Forms.ComboBox = Me._cmbDevice
				If (comboBox IsNot Nothing) Then
					RemoveHandler comboBox.TextChanged,  eventHandler
				End If
				Me._cmbDevice = value
				comboBox = Me._cmbDevice
				If (comboBox IsNot Nothing) Then
					AddHandler comboBox.TextChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdAbout As Button
			Get
				stackVariable1 = Me._cmdAbout
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdAbout_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdAbout
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdAbout = value
				button = Me._cmdAbout
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdAddCydia As Button
			Get
				stackVariable1 = Me._cmdAddCydia
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdAddCydia_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdAddCydia
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdAddCydia = value
				button = Me._cmdAddCydia
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdCheckForUpdate As Button
			Get
				stackVariable1 = Me._cmdCheckForUpdate
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdCheckForUpdate_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdCheckForUpdate
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdCheckForUpdate = value
				button = Me._cmdCheckForUpdate
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdClearText As Button
			Get
				stackVariable1 = Me._cmdClearText
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdClearText_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdClearText
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdClearText = value
				button = Me._cmdClearText
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdFixCrash As Button
			Get
				stackVariable1 = Me._cmdFixCrash
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdFixCrash_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdFixCrash
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdFixCrash = value
				button = Me._cmdFixCrash
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdInstallFromFile As Button
			Get
				stackVariable1 = Me._cmdInstallFromFile
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdInstallFromFile_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdInstallFromFile
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdInstallFromFile = value
				button = Me._cmdInstallFromFile
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdRefreshRevoke As Button
			Get
				stackVariable1 = Me._cmdRefreshRevoke
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdRefreshRevoke_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdRefreshRevoke
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdRefreshRevoke = value
				button = Me._cmdRefreshRevoke
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdResignAll As Button
			Get
				stackVariable1 = Me._cmdResignAll
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdResignAll_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdResignAll
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdResignAll = value
				button = Me._cmdResignAll
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdResignExpired As Button
			Get
				stackVariable1 = Me._cmdResignExpired
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdResignExpired_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdResignExpired
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdResignExpired = value
				button = Me._cmdResignExpired
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdSupport As Button
			Get
				stackVariable1 = Me._cmdSupport
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdSupport_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdSupport
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdSupport = value
				button = Me._cmdSupport
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdUpdate As Button
			Get
				stackVariable1 = Me._cmdUpdate
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdUpdate_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdUpdate
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdUpdate = value
				button = Me._cmdUpdate
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Private Overridable Property dt As System.Windows.Forms.Timer
			Get
				stackVariable1 = Me._dt
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Timer)
				Dim eventHandler As System.EventHandler = Sub(a0 As Object, a1 As EventArgs) Me.dt_Tick()
				Dim timer As System.Windows.Forms.Timer = Me._dt
				If (timer IsNot Nothing) Then
					RemoveHandler timer.Tick,  eventHandler
				End If
				Me._dt = value
				timer = Me._dt
				If (timer IsNot Nothing) Then
					AddHandler timer.Tick,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property homeBrower As WebBrowser
			Get
				stackVariable1 = Me._homeBrower
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.WebBrowser)
				Dim webBrowserNavigatingEventHandler As System.Windows.Forms.WebBrowserNavigatingEventHandler = New System.Windows.Forms.WebBrowserNavigatingEventHandler(AddressOf Me.homeBrower_Navigating)
				Dim webBrowser As System.Windows.Forms.WebBrowser = Me._homeBrower
				If (webBrowser IsNot Nothing) Then
					RemoveHandler webBrowser.Navigating,  webBrowserNavigatingEventHandler
				End If
				Me._homeBrower = value
				webBrowser = Me._homeBrower
				If (webBrowser IsNot Nothing) Then
					AddHandler webBrowser.Navigating,  webBrowserNavigatingEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property Label2 As Label

		Friend Overridable Property Label3 As Label

		Friend Overridable Property Label4 As Label

		Friend Overridable Property Label5 As Label

		Friend Overridable Property Label6 As Label

		Friend Overridable Property lblAccount As Label
			Get
				stackVariable1 = Me._lblAccount
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Label)
				Dim mouseEventHandler As System.Windows.Forms.MouseEventHandler = New System.Windows.Forms.MouseEventHandler(AddressOf Me.lblAccount_MouseMove)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lblAccount_MouseLeave)
				Dim eventHandler1 As System.EventHandler = New System.EventHandler(AddressOf Me.lblAccount_Click)
				Dim label As System.Windows.Forms.Label = Me._lblAccount
				If (label IsNot Nothing) Then
					RemoveHandler label.MouseMove,  mouseEventHandler
					RemoveHandler label.MouseLeave,  eventHandler
					RemoveHandler label.Click,  eventHandler1
				End If
				Me._lblAccount = value
				label = Me._lblAccount
				If (label IsNot Nothing) Then
					AddHandler label.MouseMove,  mouseEventHandler
					AddHandler label.MouseLeave,  eventHandler
					AddHandler label.Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lblCydiaRepos As Label
			Get
				stackVariable1 = Me._lblCydiaRepos
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Label)
				Dim mouseEventHandler As System.Windows.Forms.MouseEventHandler = New System.Windows.Forms.MouseEventHandler(AddressOf Me.lblCydiaRepos_MouseMove)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lblCydiaRepos_MouseLeave)
				Dim eventHandler1 As System.EventHandler = New System.EventHandler(AddressOf Me.lblCydiaRepos_Click)
				Dim label As System.Windows.Forms.Label = Me._lblCydiaRepos
				If (label IsNot Nothing) Then
					RemoveHandler label.MouseMove,  mouseEventHandler
					RemoveHandler label.MouseLeave,  eventHandler
					RemoveHandler label.Click,  eventHandler1
				End If
				Me._lblCydiaRepos = value
				label = Me._lblCydiaRepos
				If (label IsNot Nothing) Then
					AddHandler label.MouseMove,  mouseEventHandler
					AddHandler label.MouseLeave,  eventHandler
					AddHandler label.Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lblDeleteAppId As Label
			Get
				stackVariable1 = Me._lblDeleteAppId
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Label)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lblDeleteAppId_MouseLeave)
				Dim mouseEventHandler As System.Windows.Forms.MouseEventHandler = New System.Windows.Forms.MouseEventHandler(AddressOf Me.lblDeleteAppId_MouseMove)
				Dim eventHandler1 As System.EventHandler = New System.EventHandler(AddressOf Me.lblDeleteAppId_Click)
				Dim label As System.Windows.Forms.Label = Me._lblDeleteAppId
				If (label IsNot Nothing) Then
					RemoveHandler label.MouseLeave,  eventHandler
					RemoveHandler label.MouseMove,  mouseEventHandler
					RemoveHandler label.Click,  eventHandler1
				End If
				Me._lblDeleteAppId = value
				label = Me._lblDeleteAppId
				If (label IsNot Nothing) Then
					AddHandler label.MouseLeave,  eventHandler
					AddHandler label.MouseMove,  mouseEventHandler
					AddHandler label.Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lblDeviceClass As Label

		Friend Overridable Property lblDeviceName As Label

		Friend Overridable Property lblModelNumber As Label

		Friend Overridable Property lblPhone As Label

		Friend Overridable Property lblProductionVersion As Label

		Friend Overridable Property lblRevokeCert As Label
			Get
				stackVariable1 = Me._lblRevokeCert
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Label)
				Dim mouseEventHandler As System.Windows.Forms.MouseEventHandler = New System.Windows.Forms.MouseEventHandler(AddressOf Me.lblRevokeCert_MouseMove)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lblRevokeCert_MouseLeave)
				Dim eventHandler1 As System.EventHandler = New System.EventHandler(AddressOf Me.lblRevokeCert_Click)
				Dim label As System.Windows.Forms.Label = Me._lblRevokeCert
				If (label IsNot Nothing) Then
					RemoveHandler label.MouseMove,  mouseEventHandler
					RemoveHandler label.MouseLeave,  eventHandler
					RemoveHandler label.Click,  eventHandler1
				End If
				Me._lblRevokeCert = value
				label = Me._lblRevokeCert
				If (label IsNot Nothing) Then
					AddHandler label.MouseMove,  mouseEventHandler
					AddHandler label.MouseLeave,  eventHandler
					AddHandler label.Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lblSerialNumber As Label

		Friend Overridable Property lstAccount As ListViewEx
			Get
				stackVariable1 = Me._lstAccount
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstAccount_Button2Click)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstAccount
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.Button2Click,  eventHandler
				End If
				Me._lstAccount = value
				listViewEx = Me._lstAccount
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.Button2Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property lstAppOnDevice As ListViewEx
			Get
				stackVariable1 = Me._lstAppOnDevice
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lstAppOnDevice_SelectedIndexChanged)
				Dim eventHandler1 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstAppOnDevice_Button1Click)
				Dim eventHandler2 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstAppOnDevice_Button2Click)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstAppOnDevice
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.SelectedIndexChanged,  eventHandler
					RemoveHandler listViewEx.Button1Click,  eventHandler1
					RemoveHandler listViewEx.Button2Click,  eventHandler2
				End If
				Me._lstAppOnDevice = value
				listViewEx = Me._lstAppOnDevice
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.SelectedIndexChanged,  eventHandler
					AddHandler listViewEx.Button1Click,  eventHandler1
					AddHandler listViewEx.Button2Click,  eventHandler2
				End If
			End Set
		End Property

		Friend Overridable Property lstApps As ListViewEx
			Get
				stackVariable1 = Me._lstApps
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lstApps_SelectedIndexChanged)
				Dim eventHandler1 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstApps_Button1Click)
				Dim eventHandler2 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstApps_Button2Click)
				Dim eventHandler3 As System.EventHandler = New System.EventHandler(AddressOf Me.lstApps_DoubleClick)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstApps
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.SelectedIndexChanged,  eventHandler
					RemoveHandler listViewEx.Button1Click,  eventHandler1
					RemoveHandler listViewEx.Button2Click,  eventHandler2
					RemoveHandler listViewEx.DoubleClick,  eventHandler3
				End If
				Me._lstApps = value
				listViewEx = Me._lstApps
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.SelectedIndexChanged,  eventHandler
					AddHandler listViewEx.Button1Click,  eventHandler1
					AddHandler listViewEx.Button2Click,  eventHandler2
					AddHandler listViewEx.DoubleClick,  eventHandler3
				End If
			End Set
		End Property

		Friend Overridable Property lstCydia As ListViewEx
			Get
				stackVariable1 = Me._lstCydia
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lstCydia_SelectedIndexChanged)
				Dim eventHandler1 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstCydia_Button2Click)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstCydia
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.SelectedIndexChanged,  eventHandler
					RemoveHandler listViewEx.Button2Click,  eventHandler1
				End If
				Me._lstCydia = value
				listViewEx = Me._lstCydia
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.SelectedIndexChanged,  eventHandler
					AddHandler listViewEx.Button2Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lstDownloads As ListViewEx
			Get
				stackVariable1 = Me._lstDownloads
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstDownloads_Button1Click)
				Dim eventHandler1 As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstDownloads_Button2Click)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstDownloads
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.Button1Click,  eventHandler
					RemoveHandler listViewEx.Button2Click,  eventHandler1
				End If
				Me._lstDownloads = value
				listViewEx = Me._lstDownloads
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.Button1Click,  eventHandler
					AddHandler listViewEx.Button2Click,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property lstRevoke As ListViewEx
			Get
				stackVariable1 = Me._lstRevoke
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As EventHandler(Of FileEventArgs) = New EventHandler(Of FileEventArgs)(AddressOf Me.lstRevoke_Button2Click)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstRevoke
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.Button2Click,  eventHandler
				End If
				Me._lstRevoke = value
				listViewEx = Me._lstRevoke
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.Button2Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Panel1 As Panel
			Get
				stackVariable1 = Me._Panel1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Panel)
				Dim paintEventHandler As System.Windows.Forms.PaintEventHandler = New System.Windows.Forms.PaintEventHandler(AddressOf Me.Panel1_Paint)
				Dim panel As System.Windows.Forms.Panel = Me._Panel1
				If (panel IsNot Nothing) Then
					RemoveHandler panel.Paint,  paintEventHandler
				End If
				Me._Panel1 = value
				panel = Me._Panel1
				If (panel IsNot Nothing) Then
					AddHandler panel.Paint,  paintEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Panel2 As Panel

		Friend Overridable Property panelApp As Panel

		Friend Overridable Property panelDevice As Panel
			Get
				stackVariable1 = Me._panelDevice
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Panel)
				Dim paintEventHandler As System.Windows.Forms.PaintEventHandler = New System.Windows.Forms.PaintEventHandler(AddressOf Me.panelDevice_Paint)
				Dim panel As System.Windows.Forms.Panel = Me._panelDevice
				If (panel IsNot Nothing) Then
					RemoveHandler panel.Paint,  paintEventHandler
				End If
				Me._panelDevice = value
				panel = Me._panelDevice
				If (panel IsNot Nothing) Then
					AddHandler panel.Paint,  paintEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property panelDownloads As Panel
			Get
				stackVariable1 = Me._panelDownloads
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Panel)
				Dim paintEventHandler As System.Windows.Forms.PaintEventHandler = New System.Windows.Forms.PaintEventHandler(AddressOf Me.panelDownloads_Paint)
				Dim panel As System.Windows.Forms.Panel = Me._panelDownloads
				If (panel IsNot Nothing) Then
					RemoveHandler panel.Paint,  paintEventHandler
				End If
				Me._panelDownloads = value
				panel = Me._panelDownloads
				If (panel IsNot Nothing) Then
					AddHandler panel.Paint,  paintEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property panelHome As Panel

		Friend Overridable Property panelTools As Panel

		Friend Overridable Property picAppBtn As PictureBox
			Get
				stackVariable1 = Me._picAppBtn
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picAppBtn_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picAppBtn
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picAppBtn = value
				pictureBox = Me._picAppBtn
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picDevice As PictureBox
			Get
				stackVariable1 = Me._picDevice
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picDevice_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picDevice
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picDevice = value
				pictureBox = Me._picDevice
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picDeviceBtn As PictureBox
			Get
				stackVariable1 = Me._picDeviceBtn
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picDeviceBtn_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picDeviceBtn
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picDeviceBtn = value
				pictureBox = Me._picDeviceBtn
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picDownloadBtn As PictureBox
			Get
				stackVariable1 = Me._picDownloadBtn
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picDownloadBtn_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picDownloadBtn
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picDownloadBtn = value
				pictureBox = Me._picDownloadBtn
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picHomeBtn As PictureBox
			Get
				stackVariable1 = Me._picHomeBtn
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picHomeBtn_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picHomeBtn
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picHomeBtn = value
				pictureBox = Me._picHomeBtn
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picLoading As PictureBox

		Friend Overridable Property picLogo As PictureBox
			Get
				stackVariable1 = Me._picLogo
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picLogo_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picLogo
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picLogo = value
				pictureBox = Me._picLogo
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property picToolBtn As PictureBox
			Get
				stackVariable1 = Me._picToolBtn
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.PictureBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.picToolBtn_Click)
				Dim pictureBox As System.Windows.Forms.PictureBox = Me._picToolBtn
				If (pictureBox IsNot Nothing) Then
					RemoveHandler pictureBox.Click,  eventHandler
				End If
				Me._picToolBtn = value
				pictureBox = Me._picToolBtn
				If (pictureBox IsNot Nothing) Then
					AddHandler pictureBox.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property txtAppSearch As TextBox
			Get
				stackVariable1 = Me._txtAppSearch
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.TextBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.txtAppSearch_TextChanged)
				Dim textBox As System.Windows.Forms.TextBox = Me._txtAppSearch
				If (textBox IsNot Nothing) Then
					RemoveHandler textBox.TextChanged,  eventHandler
				End If
				Me._txtAppSearch = value
				textBox = Me._txtAppSearch
				If (textBox IsNot Nothing) Then
					AddHandler textBox.TextChanged,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property txtCydia As TextBox

		Friend Overridable Property txtPassword As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.frmSuperImpactor_Load)
			AddHandler MyBase.Closed,  New EventHandler(AddressOf Me.frmSuperImpactor_Closed)
			Me.lstProvision = New Dictionary(Of String, frmSuperImpactor.ProvisionInfo)()
			Me.isNewApp = False
			Me.firstTimeLoadApp = True
			Me.mint_LastReceivedTimerID = 0
			Me.mint_LastInitializedTimerID = 0
			Me.listDevice = New List(Of frmSuperImpactor.DeviceInfo)()
			Me.isShowDownload = False
			Me.crrAppsOnDevice = New List(Of AppInfos)()
			Me.InitializeComponent()
		End Sub

		Private Sub cmbAppleId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtPassword.Text = Me.lstAcc(Me.cmbAppleId.Text)
		End Sub

		Private Async Sub cmbDevice_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String
			Dim dateTime As System.DateTime = New System.DateTime()
			If (Operators.CompareString(Me.cmbDevice.Text, "", False) <> 0) Then
				Me.lstAppOnDevice.Clear()
				Me.cmdResignAll.Visible = True
				Me.cmdResignExpired.Visible = True
				Me.cmdFixCrash.Visible = True
				Me.cmdInstallFromFile.Visible = True
				Dim count As Integer = Me.listDevice.Count - 1
				Dim num As Integer = 0
				Do
					If (Operators.CompareString(Me.cmbDevice.Text, String.Concat(Me.listDevice(num).deviceName, " - ", Me.listDevice(num).udid), False) = 0) Then
						Me.lblPhone.Text = String.Concat("PhoneNumber: ", Me.listDevice(num).phoneNumber)
						Me.lblDeviceName.Text = String.Concat("DeviceName: ", Me.listDevice(num).deviceName)
						Me.lblDeviceClass.Text = String.Concat("DeviceClass: ", Me.listDevice(num).deviceClass)
						Me.lblSerialNumber.Text = String.Concat("SerialNumber: ", Me.listDevice(num).serialNumber)
						Me.lblModelNumber.Text = String.Concat("ModelNumber: ", Me.listDevice(num).modelNumber)
						Me.lblProductionVersion.Text = String.Concat("ProductVersion: ", Me.listDevice(num).productVersion)
						If (Operators.CompareString(Me.listDevice(num).deviceClass, "iPhone", False) <> 0) Then
							Me.picDevice.Image = DirectCast(Resources.ResourceManager.GetObject("ipad"), Image)
						Else
							Me.picDevice.Image = DirectCast(Resources.ResourceManager.GetObject("iphone"), Image)
						End If
						Me.crrAppsOnDevice.Clear()
						Dim _frmSuperImpactor As frmSuperImpactor = Me
						Dim str1 As String = Me.cmbDevice.Text.Substring(Me.cmbDevice.Text.Length - 40)
						Dim item As String = Me.listDevice(num).productVersion
						Dim chrArray() As Char = { "."C }
						Await _frmSuperImpactor.getAppsOnDevice(str1, Integer.Parse(item.Split(chrArray)(0)))
						Try
							str = String.Concat(AppConst.m_rootPath, "\certs\\pr\", Me.listDevice(num).udid)
						Catch exception As System.Exception
							ProjectData.SetProjectError(exception)
							ProjectData.ClearProjectError()
							GoTo Label0
						End Try
						Try
							Directory.CreateDirectory(str)
						Catch exception1 As System.Exception
							ProjectData.SetProjectError(exception1)
							ProjectData.ClearProjectError()
						End Try
						Dim str2 As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("copy """, str, """"), True)
						Dim files As String() = Directory.GetFiles(str)
						Dim num1 As Integer = Information.UBound(files, 1)
						Dim num2 As Integer = 0
						Do
							If (Operators.CompareString(Path.GetExtension(files(num2)).ToLower(), ".mobileprovision", False) = 0) Then
								If (Not File.Exists(files(num2))) Then
									GoTo Label1
								End If
								Dim strArrays As String() = File.ReadAllLines(files(num2))
								Dim str3 As String = ""
								Dim num3 As Integer = Information.LBound(strArrays, 1)
								Dim num4 As Integer = Information.UBound(strArrays, 1)
								Dim num5 As Integer = num3
								Do
									If (strArrays(num5).IndexOf("<key>ExpirationDate</key>") >= 0) Then
										Dim str4 As String = strArrays(num5 + 1).Replace("<date>", "").Replace("</date>", "").Replace("T", " ").Replace("Z", "").Trim()
										dateTime = System.DateTime.ParseExact(str4, "yyyy-MM-dd HH:mm:ss", Nothing)
									ElseIf (strArrays(num5).IndexOf("<key>application-identifier</key>") >= 0) Then
										Dim str5 As String = strArrays(num5 + 1).Replace("<string>", "").Replace("</string>", "").Trim()
										Dim num6 As Integer = str5.IndexOf(".")
										If (num6 > 0) Then
											str3 = str5.Substring(num6 + 1)
										End If
									End If
									num5 = num5 + 1
								Loop While num5 <= num4
								If (Operators.CompareString(str3, "", False) <> 0) Then
									Dim provisionInfo As frmSuperImpactor.ProvisionInfo = New frmSuperImpactor.ProvisionInfo() With
									{
										.eDate = dateTime,
										.id = files(num2)
									}
									If (Not Me.lstProvision.ContainsKey(str3)) Then
										Me.lstProvision.Add(str3, provisionInfo)
									ElseIf (System.DateTime.Compare(dateTime, Me.lstProvision(str3).eDate) > 0) Then
										Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("remove ", Path.GetFileName(Me.lstProvision(str3).id).ToLower().Replace(".mobileprovision", "")), False)
										Try
											File.Delete(Me.lstProvision(str3).id)
										Catch exception2 As System.Exception
											ProjectData.SetProjectError(exception2)
											ProjectData.ClearProjectError()
										End Try
										Me.lstProvision.Remove(str3)
										Me.lstProvision.Add(str3, provisionInfo)
									ElseIf (System.DateTime.Compare(dateTime, Me.lstProvision(str3).eDate) < 0) Then
										Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceprovision.exe"), String.Concat("remove ", Path.GetFileName(provisionInfo.id).ToLower().Replace(".mobileprovision", "")), False)
										Try
											File.Delete(files(num2))
										Catch exception3 As System.Exception
											ProjectData.SetProjectError(exception3)
											ProjectData.ClearProjectError()
										End Try
									End If
								End If
								Application.DoEvents()
							End If
						Label1:
							num2 = num2 + 1
						Loop While num2 <= num1
						Me.lstAppOnDevice.Clear()
						Me.lstAppOnDevice.View = View.Details
						Me.lstAppOnDevice.Columns.Add("App Installed by SuperImpact", Me.lstAppOnDevice.Width - 5)
						Dim count1 As Integer = Me.crrAppsOnDevice.Count - 1
						Dim num7 As Integer = 0
						Do
							Dim extraDatum As ExtraData = New ExtraData()
							If (Me.lstProvision.ContainsKey(Me.crrAppsOnDevice(num7).Package)) Then
								extraDatum.MinorText = String.Concat("Version: ", Me.crrAppsOnDevice(num7).Version, " - Expire On: ", Conversions.ToString(Me.lstProvision(Me.crrAppsOnDevice(num7).Package).eDate))
								If (System.DateTime.Compare(Me.lstProvision(Me.crrAppsOnDevice(num7).Package).eDate, DateAndTime.Now.[Date]) <= 0) Then
									extraDatum.HeaderColor = Color.Red
								End If
							Else
								extraDatum.HeaderColor = Color.Red
								extraDatum.MinorText = String.Concat("Version: ", Me.crrAppsOnDevice(num7).Version, " - Expire On: ? ")
							End If
							extraDatum.HeaderText = Me.crrAppsOnDevice(num7).Name
							extraDatum.DescText = Me.crrAppsOnDevice(num7).Package
							extraDatum.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("appid"), Bitmap))
							extraDatum.ButtonText1 = "RESIGN"
							extraDatum.ButtonText2 = "REMOVE"
							Me.lstAppOnDevice.Items.Add("").Tag = extraDatum
							num7 = num7 + 1
						Loop While num7 <= count1
						Exit Do
					End If
				Label0:
					num = num + 1
				Loop While num <= count
				Me.picDevice.Visible = True
				Me.picDevice.BringToFront()
			Else
				Me.picDevice.Visible = False
				Me.lstAppOnDevice.Clear()
				Me.cmdResignAll.Visible = False
				Me.cmdResignExpired.Visible = False
				Me.cmdFixCrash.Visible = False
				Me.cmdInstallFromFile.Visible = False
				Me.lblPhone.Text = ""
				Me.lblDeviceName.Text = ""
				Me.lblDeviceClass.Text = ""
				Me.lblSerialNumber.Text = ""
				Me.lblModelNumber.Text = ""
				Me.lblProductionVersion.Text = ""
			End If
			Return
			GoTo Label1
		End Sub

		Private Sub cmdAbout_Click(ByVal sender As Object, ByVal e As EventArgs)
			Interaction.MsgBox(String.Concat("v", Assembly.GetExecutingAssembly().GetName().Version.ToString(), " - Copyright @2017 - TuanHa Jsc" & VbCrLf & "Contact: flashsupporter@gmail.com" & VbCrLf & "Website: http://superimpactor.net" & VbCrLf & "" & VbCrLf & "This program uses: " & VbCrLf & "- libimobiledevice team: http://www.libimobiledevice.org/" & VbCrLf & "- Copyright (c) 1998-2017 The OpenSSL Project, Copyright (C) 1995-1998 Eric Young (eay@cryptsoft.com). All rights reserved." & VbCrLf & "- isign by Neil Kandalgaonkar" & VbCrLf & "- 7zip" & VbCrLf & "- zip"), MsgBoxStyle.OkOnly, "About")
		End Sub

		Private Async Sub cmdAddCydia_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim num As Integer
			Dim num1 As Integer
			Dim text As String = Me.txtCydia.Text
			If (Operators.CompareString(Microsoft.VisualBasic.Strings.Trim(text), "", False) <> 0) Then
				If (Not text.StartsWith("http")) Then
					text = String.Concat("http://", text)
				End If
				Dim count As Integer = Me.lstCydia.Items.Count - 1
				Dim num2 As Integer = 0
				While num2 <= count
					Dim item As ListViewItem = Me.lstCydia.Items(num2)
					If (Operators.CompareString(DirectCast(item.Tag, ExtraData).MinorText, text, False) <> 0) Then
						num2 = num2 + 1
					Else
						Interaction.MsgBox("Cydia existed!", MsgBoxStyle.OkOnly, "Error")
						num1 = -2
						num = num1
						Return
					End If
				End While
				Try
					File.Delete("Release.txt")
					File.Delete("Release")
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
				Dim str As String = "Noname"
				Try
					Dim webClient As System.Net.WebClient = New System.Net.WebClient()
					webClient.DownloadFile(String.Concat(text, "/Release"), "Release.txt")
					Dim strArrays As String() = File.ReadAllLines("Release.txt")
					Dim num3 As Integer = Information.LBound(strArrays, 1)
					Dim num4 As Integer = Information.UBound(strArrays, 1)
					Dim num5 As Integer = num3
					While num5 <= num4
						If (Not strArrays(num5).StartsWith("Label:")) Then
							num5 = num5 + 1
						Else
							str = strArrays(num5).Substring(6)
							Exit While
						End If
					End While
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					ProjectData.ClearProjectError()
				End Try
				If (frmSuperImpactor.LoadPackages(text)) Then
					Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("INSERT INTO cydia_repos(name, path) VALUES(@name, @path)", AppConst.m_dbConnection)
					Dim parameters As SQLiteParameterCollection = sQLiteCommand.get_Parameters()
					parameters.AddWithValue("@name", str)
					parameters.AddWithValue("@path", text)
					parameters = Nothing
					sQLiteCommand.ExecuteNonQuery()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.LoadCydiaRepos(text))
					Dim updateCydium As UpdateCydia = New UpdateCydia()
					updateCydium.LoadApp(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(objectValue)))
					AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(True)
				End If
			Else
				Interaction.MsgBox("Incorrect URL", MsgBoxStyle.OkOnly, "Error")
			End If
			num1 = -2
			num = num1
		End Sub

		Private Sub cmdCheckForUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.sparkle.CheckForUpdatesAtUserRequest()
		End Sub

		Private Sub cmdClearText_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtAppSearch.Text = ""
		End Sub

		Private Async Sub cmdFixCrash_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim variable As frmSuperImpactor.VB$StateMachine_321_cmdFixCrash_Click = Nothing
			AsyncVoidMethodBuilder.Create().Start(Of frmSuperImpactor.VB$StateMachine_321_cmdFixCrash_Click)(variable)
		End Sub

		Private Sub cmdInstallFromFile_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog() With
			{
				.InitialDirectory = "c:\\",
				.Filter = "IPA Files (*.ipa)|*.ipa",
				.FilterIndex = 2,
				.RestoreDirectory = True
			}
			If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
				Dim install As SuperImpactor.Install = New SuperImpactor.Install()
				install.installFromFile(openFileDialog.FileName, "", "")
			End If
		End Sub

		Private Sub cmdRefreshRevoke_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String
			If (Operators.CompareString(Me.cmbAppleId.Text.Trim(), "", False) = 0) Then
				Interaction.MsgBox("No appleId!", MsgBoxStyle.OkOnly, "Error")
			ElseIf (Operators.CompareString(Me.txtPassword.Text, "", False) <> 0) Then
				Me.cmdRefreshRevoke.Enabled = False
				str = If(Me.lblDeleteAppId.BackColor <> Color.FromName("GradientActiveCaption"), Conversions.ToString(Me.LoadCertificates()), Conversions.ToString(Me.LoadApps()))
				Me.cmdRefreshRevoke.Enabled = True
				If (Operators.CompareString(str, "", False) <> 0) Then
					Interaction.MsgBox(str, MsgBoxStyle.OkOnly, "Warning")
				End If
			Else
				Interaction.MsgBox("No password!", MsgBoxStyle.OkOnly, "Error")
			End If
		End Sub

		Private Sub cmdResignAll_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.resign(False)
		End Sub

		Private Sub cmdResignExpired_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.resign(True)
		End Sub

		Private Sub cmdSupport_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New ReportBug()).ShowDialog()
		End Sub

		Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
			If ((New UpdateCydia()).UpdateApp()) Then
			End If
		End Sub

		Private Async Function detectDevice() As Task
			Dim str As String = Nothing
			Dim str1 As String = Nothing
			Dim str2 As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinfo.exe"), "", False)
			Dim strArrays As String() = str2.Split(New Char() { Strings.ChrW(10) })
			Dim str3 As String = ""
			Dim str4 As String = ""
			Dim str5 As String = ""
			Dim str6 As String = ""
			Dim str7 As String = ""
			Dim length As Integer = CInt(strArrays.Length) - 1
			Dim num As Integer = 0
			Do
				If (strArrays(num).StartsWith("UniqueDeviceID")) Then
					str1 = strArrays(num).Substring("UniqueDeviceID:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("DeviceName")) Then
					str = strArrays(num).Substring("DeviceName:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("ProductVersion")) Then
					str4 = strArrays(num).Substring("ProductVersion:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("DeviceClass")) Then
					str3 = strArrays(num).Substring("DeviceClass:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("SerialNumber")) Then
					str5 = strArrays(num).Substring("SerialNumber:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("ModelNumber")) Then
					str6 = strArrays(num).Substring("ModelNumber:".Length).Trim()
				ElseIf (strArrays(num).StartsWith("PhoneNumber")) Then
					str7 = strArrays(num).Substring("PhoneNumber:".Length).Trim()
				End If
				num = num + 1
			Loop While num <= length
			Me.listDevice.Clear()
			If (Operators.CompareString(str1, "", False) <> 0 And Operators.CompareString(str, "", False) <> 0) Then
				Dim deviceInfo As frmSuperImpactor.DeviceInfo = New frmSuperImpactor.DeviceInfo() With
				{
					.udid = str1,
					.deviceName = str,
					.productVersion = str4,
					.deviceClass = str3,
					.serialNumber = str5,
					.modelNumber = str6,
					.phoneNumber = str7
				}
				Me.listDevice.Add(deviceInfo)
			End If
		End Function

		Public Sub DeviceInvokeMethod()
			Me.cmbDevice.Items.Clear()
			Dim count As Integer = Me.listDevice.Count - 1
			Dim num As Integer = 0
			Do
				Me.cmbDevice.Items.Add(String.Concat(Me.listDevice(num).deviceName, " - ", Me.listDevice(num).udid))
				num = num + 1
			Loop While num <= count
			If (Me.cmbDevice.Items.Count = 0) Then
				Me.cmbDevice.Text = ""
			End If
			If (Me.cmbDevice.Items.Count > 0) Then
				Dim count1 As Integer = Me.cmbDevice.Items.Count - 1
				Dim num1 As Integer = 0
				While num1 <= count1
					If (Not Operators.ConditionalCompareObjectEqual(Me.cmbDevice.Text, Me.cmbDevice.Items(num1), False)) Then
						num1 = num1 + 1
					Else
						Return
					End If
				End While
				Me.cmbDevice.SelectedIndex = 0
			End If
		End Sub

		<DebuggerNonUserCode>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If (If(Not disposing, False, Me.components IsNot Nothing)) Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		Private Sub dt_Tick()
			Me.dt.[Stop]()
			Me.cmdCheckForUpdate.PerformClick()
		End Sub

		Private Sub frmSuperImpactor_Closed(ByVal sender As Object, ByVal e As EventArgs)
			Me.isExit = True
			Try
				File.Delete(String.Concat(AppConst.m_rootPath, "/\tmp\/running.pid"))
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub frmSuperImpactor_Load(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Try
					AppConst.logger = LogManager.GetLogger("SuperImpactor")
					AppConst.logger.Info(String.Concat("Start ver ", Assembly.GetExecutingAssembly().GetName().Version.ToString()))
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
			End Try
			Me.sparkle = New NetSparkle.Sparkle("http://superimpactor.net/release/versions.xml", MyBase.Icon)
			AppConst.mainForm = Me
			Me.homeBrower.ScriptErrorsSuppressed = True
			Try
				Try
					Me.homeBrower.Url = New Uri(String.Concat("http://home.superimpactor.net/?ver=", HttpUtility.UrlEncode(Assembly.GetExecutingAssembly().GetName().Version.ToString())))
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					Interaction.MsgBox(exception1.Message, MsgBoxStyle.OkOnly, Nothing)
					ProjectData.ClearProjectError()
				End Try
			Finally
			End Try
			AppConst.m_localTmp = Common.GetTempFolder()
			Dim startupPath As String = Application.StartupPath
			AppConst.m_rootPath = String.Concat(startupPath, "\..\..\")
			If (Not File.Exists(String.Concat(AppConst.m_rootPath, "\iaidb.sqlite"))) Then
				AppConst.m_rootPath = String.Concat(startupPath, "\")
				If (Not File.Exists(String.Concat(AppConst.m_rootPath, "\iaidb.sqlite"))) Then
					Interaction.MsgBox("Application error! Please install again!", MsgBoxStyle.OkOnly, "Error")
					ProjectData.EndApp()
				End If
			End If
			AppConst.m_dbConnection = New SQLiteConnection(String.Concat("Data Source=", AppConst.m_rootPath, "\iaidb.sqlite;Version=3;"))
			AppConst.m_dbConnection.Open()
			Me.SetListViewSpacing(Me.lstApps, 16, 16)
			AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(True)
			Me.crrTools = 0
			Me.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption")
			Me.lblCydiaRepos_Click(Nothing, Nothing)
			Dim num As Integer = 0
			Do
				AppConst.m_randomKey = String.Concat(AppConst.m_randomKey, Char.ConvertFromUtf32(num * 2 + 64))
				num = num + 1
			Loop While num <= 16
			Me.lstAcc = Database.GetAccounts()
			Me.picHomeBtn_Click(Nothing, Nothing)
			Dim thread As System.Threading.Thread = New System.Threading.Thread(New ThreadStart(AddressOf Me.ThreadTask))
			thread.Start()
			AddHandler AppDomain.CurrentDomain.UnhandledException,  New UnhandledExceptionEventHandler(AddressOf frmSuperImpactor.UnhandledExceptionHandler)
			MyBase.Show()
			Me.sparkle.StartLoop(True)
			If (Me.sparkle.CheckForUpdatesQuietly() = NetSparkle.Sparkle.UpdateStatus.UpdateAvailable) Then
				Me.dt = New System.Windows.Forms.Timer() With
				{
					.Interval = 10000
				}
				Me.dt.Start()
			End If
			If (Not File.Exists(String.Concat(AppConst.m_rootPath, "/\tmp\/running.pid"))) Then
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "/\tmp\/running.pid"), Conversions.ToString(DateTime.Now))
			Else
				ReportBug.sendLog("crashreport", "auto")
			End If
		End Sub

		Private Async Function getAppsOnDevice(ByVal udid As String, ByVal iOSVersion As Integer) As Task
			Dim str As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinstaller.exe"), "-l", False)
			Dim strArrays As String() = str.Split(New Char() { Strings.ChrW(10) })
			Dim str1 As String = "si"
			Me.crrAppsOnDevice.Clear()
			Dim length As Integer = CInt(strArrays.Length) - 1
			Dim num As Integer = 0
			Do
				If (strArrays(num).StartsWith(str1)) Then
					Dim num1 As Integer = strArrays(num).IndexOf("-")
					If (iOSVersion > 1) Then
						Dim str2 As String = strArrays(num).Replace("", "")
						Dim strArrays1 As String() = str2.Split(New Char() { ","C })
						If (CInt(strArrays1.Length) = 3) Then
							Dim appInfo As AppInfos = New AppInfos() With
							{
								.Name = Microsoft.VisualBasic.Strings.Trim(strArrays1(2).Replace("""", "")),
								.Version = Microsoft.VisualBasic.Strings.Trim(strArrays1(1).Replace("""", "")),
								.Package = Microsoft.VisualBasic.Strings.Trim(strArrays1(0).Replace(String.Concat(udid, "."), ""))
							}
							Me.crrAppsOnDevice.Add(appInfo)
						End If
					ElseIf (num1 > 0) Then
						Dim appInfo1 As AppInfos = New AppInfos()
						Dim appInfo2 As AppInfos = appInfo1
						Dim str3 As String = strArrays(num)
						Dim chrArray() As Char = { Strings.ChrW(32) }
						appInfo2.Version = str3.Split(chrArray).Last()
						appInfo1.Name = Microsoft.VisualBasic.Strings.Trim(strArrays(num).Substring(num1 + 1, strArrays(num).Length - appInfo1.Version.Length - num1 - 1).Replace("", "").Replace("" & VbCrLf & "", ""))
						appInfo1.Version = Microsoft.VisualBasic.Strings.Trim(appInfo1.Version.Replace("", "").Replace("" & VbCrLf & "", ""))
						appInfo1.Package = Microsoft.VisualBasic.Strings.Trim(strArrays(num).Substring(0, num1 - 1).Replace("", "").Replace("" & VbCrLf & "", "").Replace(String.Concat(udid, "."), ""))
						Me.crrAppsOnDevice.Add(appInfo1)
					End If
				End If
				num = num + 1
			Loop While num <= length
		End Function

		Private Sub homeBrower_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs)
			If (Not e.Url.ToString().EndsWith(".ipa")) Then
				e.Cancel = False
			Else
				e.Cancel = True
				Dim str As String = e.Url.ToString().Substring(e.Url.ToString().LastIndexOf("/") + 1)
				Common.Download(New DownloadProgress(), e.Url.ToString(), str)
			End If
		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuperImpactor))
			Me.Panel1 = New Panel()
			Me.picHomeBtn = New PictureBox()
			Me.picDownloadBtn = New PictureBox()
			Me.picToolBtn = New PictureBox()
			Me.picDeviceBtn = New PictureBox()
			Me.picAppBtn = New PictureBox()
			Me.picLogo = New PictureBox()
			Me.panelHome = New Panel()
			Me.homeBrower = New WebBrowser()
			Me.panelApp = New Panel()
			Me.cmdClearText = New Button()
			Me.lstApps = New ListViewEx()
			Me.txtAppSearch = New TextBox()
			Me.cmdUpdate = New Button()
			Me.Label1 = New Label()
			Me.panelDownloads = New Panel()
			Me.lstDownloads = New ListViewEx()
			Me.panelTools = New Panel()
			Me.childPanelRepo = New Panel()
			Me.txtCydia = New TextBox()
			Me.cmdAddCydia = New Button()
			Me.Label4 = New Label()
			Me.lstCydia = New ListViewEx()
			Me.childPanelRevoke = New Panel()
			Me.txtPassword = New TextBox()
			Me.Label3 = New Label()
			Me.cmdRefreshRevoke = New Button()
			Me.Label2 = New Label()
			Me.cmbAppleId = New ComboBox()
			Me.lstRevoke = New ListViewEx()
			Me.childPanelAppleIds = New Panel()
			Me.lstAccount = New ListViewEx()
			Me.Panel2 = New Panel()
			Me.lblDeleteAppId = New Label()
			Me.lblAccount = New Label()
			Me.lblRevokeCert = New Label()
			Me.lblCydiaRepos = New Label()
			Me.panelDevice = New Panel()
			Me.cmdCheckForUpdate = New Button()
			Me.cmdAbout = New Button()
			Me.cmdFixCrash = New Button()
			Me.cmdInstallFromFile = New Button()
			Me.picLoading = New PictureBox()
			Me.cmdResignExpired = New Button()
			Me.lblPhone = New Label()
			Me.lblModelNumber = New Label()
			Me.lblSerialNumber = New Label()
			Me.lblProductionVersion = New Label()
			Me.lblDeviceClass = New Label()
			Me.lblDeviceName = New Label()
			Me.cmdResignAll = New Button()
			Me.picDevice = New PictureBox()
			Me.lstAppOnDevice = New ListViewEx()
			Me.Label6 = New Label()
			Me.Label5 = New Label()
			Me.cmbDevice = New ComboBox()
			Me.cmdSupport = New Button()
			Me.Panel1.SuspendLayout()
			DirectCast(Me.picHomeBtn, ISupportInitialize).BeginInit()
			DirectCast(Me.picDownloadBtn, ISupportInitialize).BeginInit()
			DirectCast(Me.picToolBtn, ISupportInitialize).BeginInit()
			DirectCast(Me.picDeviceBtn, ISupportInitialize).BeginInit()
			DirectCast(Me.picAppBtn, ISupportInitialize).BeginInit()
			DirectCast(Me.picLogo, ISupportInitialize).BeginInit()
			Me.panelHome.SuspendLayout()
			Me.panelApp.SuspendLayout()
			Me.panelDownloads.SuspendLayout()
			Me.panelTools.SuspendLayout()
			Me.childPanelRepo.SuspendLayout()
			Me.childPanelRevoke.SuspendLayout()
			Me.childPanelAppleIds.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.panelDevice.SuspendLayout()
			DirectCast(Me.picLoading, ISupportInitialize).BeginInit()
			DirectCast(Me.picDevice, ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Color.Transparent
			Me.Panel1.BackgroundImage = Resources.titlebar
			Me.Panel1.Controls.Add(Me.picHomeBtn)
			Me.Panel1.Controls.Add(Me.picDownloadBtn)
			Me.Panel1.Controls.Add(Me.picToolBtn)
			Me.Panel1.Controls.Add(Me.picDeviceBtn)
			Me.Panel1.Controls.Add(Me.picAppBtn)
			Me.Panel1.Controls.Add(Me.picLogo)
			Me.Panel1.ForeColor = SystemColors.GradientActiveCaption
			Me.Panel1.Location = New Point(-1, -1)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(939, 100)
			Me.Panel1.TabIndex = 0
			Me.picHomeBtn.BackgroundImage = DirectCast(componentResourceManager.GetObject("picHomeBtn.BackgroundImage"), Image)
			Me.picHomeBtn.Location = New Point(322, 0)
			Me.picHomeBtn.Name = "picHomeBtn"
			Me.picHomeBtn.Size = New System.Drawing.Size(89, 99)
			Me.picHomeBtn.TabIndex = 5
			Me.picHomeBtn.TabStop = False
			Me.picDownloadBtn.BackgroundImage = Resources.download_btn
			Me.picDownloadBtn.Location = New Point(500, 0)
			Me.picDownloadBtn.Name = "picDownloadBtn"
			Me.picDownloadBtn.Size = New System.Drawing.Size(96, 99)
			Me.picDownloadBtn.TabIndex = 4
			Me.picDownloadBtn.TabStop = False
			Me.picToolBtn.BackgroundImage = Resources.tools_btn
			Me.picToolBtn.Location = New Point(596, 0)
			Me.picToolBtn.Name = "picToolBtn"
			Me.picToolBtn.Size = New System.Drawing.Size(89, 99)
			Me.picToolBtn.TabIndex = 3
			Me.picToolBtn.TabStop = False
			Me.picDeviceBtn.BackgroundImage = Resources.device_btn
			Me.picDeviceBtn.Location = New Point(685, 0)
			Me.picDeviceBtn.Name = "picDeviceBtn"
			Me.picDeviceBtn.Size = New System.Drawing.Size(89, 99)
			Me.picDeviceBtn.TabIndex = 2
			Me.picDeviceBtn.TabStop = False
			Me.picAppBtn.BackgroundImage = Resources.apps_btn
			Me.picAppBtn.Location = New Point(411, 0)
			Me.picAppBtn.Name = "picAppBtn"
			Me.picAppBtn.Size = New System.Drawing.Size(89, 99)
			Me.picAppBtn.TabIndex = 1
			Me.picAppBtn.TabStop = False
			Me.picLogo.BackgroundImageLayout = ImageLayout.Zoom
			Me.picLogo.Image = Resources.appicon
			Me.picLogo.Location = New Point(50, 3)
			Me.picLogo.Name = "picLogo"
			Me.picLogo.Size = New System.Drawing.Size(117, 94)
			Me.picLogo.SizeMode = PictureBoxSizeMode.Zoom
			Me.picLogo.TabIndex = 0
			Me.picLogo.TabStop = False
			Me.panelHome.Controls.Add(Me.homeBrower)
			Me.panelHome.Location = New Point(-1, 100)
			Me.panelHome.Name = "panelHome"
			Me.panelHome.Size = New System.Drawing.Size(939, 493)
			Me.panelHome.TabIndex = 1
			Me.homeBrower.Dock = DockStyle.Fill
			Me.homeBrower.Location = New Point(0, 0)
			Me.homeBrower.MinimumSize = New System.Drawing.Size(20, 20)
			Me.homeBrower.Name = "homeBrower"
			Me.homeBrower.Size = New System.Drawing.Size(939, 493)
			Me.homeBrower.TabIndex = 0
			Me.panelApp.Controls.Add(Me.cmdClearText)
			Me.panelApp.Controls.Add(Me.lstApps)
			Me.panelApp.Controls.Add(Me.txtAppSearch)
			Me.panelApp.Controls.Add(Me.cmdUpdate)
			Me.panelApp.Controls.Add(Me.Label1)
			Me.panelApp.Location = New Point(0, 100)
			Me.panelApp.Name = "panelApp"
			Me.panelApp.Size = New System.Drawing.Size(938, 493)
			Me.panelApp.TabIndex = 2
			Me.cmdClearText.Location = New Point(869, 2)
			Me.cmdClearText.Name = "cmdClearText"
			Me.cmdClearText.Size = New System.Drawing.Size(60, 23)
			Me.cmdClearText.TabIndex = 13
			Me.cmdClearText.Text = "Clear"
			Me.cmdClearText.UseVisualStyleBackColor = True
			Me.lstApps.BackColor = Color.White
			Me.lstApps.FullRowSelect = True
			Me.lstApps.Location = New Point(-2, 32)
			Me.lstApps.MultiSelect = False
			Me.lstApps.Name = "lstApps"
			Me.lstApps.OwnerDraw = True
			Me.lstApps.Size = New System.Drawing.Size(938, 461)
			Me.lstApps.TabIndex = 12
			Me.lstApps.UseCompatibleStateImageBehavior = False
			Me.lstApps.View = View.Details
			Me.txtAppSearch.Location = New Point(520, 4)
			Me.txtAppSearch.Name = "txtAppSearch"
			Me.txtAppSearch.Size = New System.Drawing.Size(342, 20)
			Me.txtAppSearch.TabIndex = 11
			Me.cmdUpdate.Location = New Point(10, 2)
			Me.cmdUpdate.Name = "cmdUpdate"
			Me.cmdUpdate.Size = New System.Drawing.Size(88, 25)
			Me.cmdUpdate.TabIndex = 9
			Me.cmdUpdate.Text = "Refresh Repos"
			Me.cmdUpdate.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(455, 7)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(63, 13)
			Me.Label1.TabIndex = 8
			Me.Label1.Text = "App Search"
			Me.panelDownloads.Controls.Add(Me.lstDownloads)
			Me.panelDownloads.Location = New Point(0, 99)
			Me.panelDownloads.Name = "panelDownloads"
			Me.panelDownloads.Size = New System.Drawing.Size(938, 494)
			Me.panelDownloads.TabIndex = 3
			Me.lstDownloads.BackColor = Color.White
			Me.lstDownloads.FullRowSelect = True
			Me.lstDownloads.Location = New Point(0, 1)
			Me.lstDownloads.Name = "lstDownloads"
			Me.lstDownloads.OwnerDraw = True
			Me.lstDownloads.Size = New System.Drawing.Size(938, 493)
			Me.lstDownloads.TabIndex = 6
			Me.lstDownloads.UseCompatibleStateImageBehavior = False
			Me.lstDownloads.View = View.Details
			Me.panelTools.BackColor = SystemColors.InactiveCaptionText
			Me.panelTools.Controls.Add(Me.childPanelRepo)
			Me.panelTools.Controls.Add(Me.childPanelRevoke)
			Me.panelTools.Controls.Add(Me.childPanelAppleIds)
			Me.panelTools.Controls.Add(Me.Panel2)
			Me.panelTools.Location = New Point(-2, 99)
			Me.panelTools.Name = "panelTools"
			Me.panelTools.Size = New System.Drawing.Size(939, 494)
			Me.panelTools.TabIndex = 4
			Me.childPanelRepo.Controls.Add(Me.txtCydia)
			Me.childPanelRepo.Controls.Add(Me.cmdAddCydia)
			Me.childPanelRepo.Controls.Add(Me.Label4)
			Me.childPanelRepo.Controls.Add(Me.lstCydia)
			Me.childPanelRepo.Location = New Point(203, 1)
			Me.childPanelRepo.Name = "childPanelRepo"
			Me.childPanelRepo.Size = New System.Drawing.Size(736, 493)
			Me.childPanelRepo.TabIndex = 8
			Me.txtCydia.Location = New Point(76, 6)
			Me.txtCydia.Name = "txtCydia"
			Me.txtCydia.Size = New System.Drawing.Size(549, 20)
			Me.txtCydia.TabIndex = 2
			Me.cmdAddCydia.Location = New Point(631, 6)
			Me.cmdAddCydia.Name = "cmdAddCydia"
			Me.cmdAddCydia.Size = New System.Drawing.Size(99, 22)
			Me.cmdAddCydia.TabIndex = 3
			Me.cmdAddCydia.Text = "Add Repo"
			Me.cmdAddCydia.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Point(9, 9)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(63, 13)
			Me.Label4.TabIndex = 1
			Me.Label4.Text = "Repos URL"
			Me.lstCydia.BackColor = Color.White
			Me.lstCydia.FullRowSelect = True
			Me.lstCydia.Location = New Point(-1, 31)
			Me.lstCydia.Name = "lstCydia"
			Me.lstCydia.OwnerDraw = True
			Me.lstCydia.Size = New System.Drawing.Size(737, 462)
			Me.lstCydia.TabIndex = 0
			Me.lstCydia.UseCompatibleStateImageBehavior = False
			Me.lstCydia.View = View.Details
			Me.childPanelRevoke.Controls.Add(Me.txtPassword)
			Me.childPanelRevoke.Controls.Add(Me.Label3)
			Me.childPanelRevoke.Controls.Add(Me.cmdRefreshRevoke)
			Me.childPanelRevoke.Controls.Add(Me.Label2)
			Me.childPanelRevoke.Controls.Add(Me.cmbAppleId)
			Me.childPanelRevoke.Controls.Add(Me.lstRevoke)
			Me.childPanelRevoke.Location = New Point(203, 0)
			Me.childPanelRevoke.Name = "childPanelRevoke"
			Me.childPanelRevoke.Size = New System.Drawing.Size(736, 493)
			Me.childPanelRevoke.TabIndex = 1
			Me.txtPassword.Location = New Point(370, 6)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "*"C
			Me.txtPassword.Size = New System.Drawing.Size(201, 20)
			Me.txtPassword.TabIndex = 10
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Point(310, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(53, 13)
			Me.Label3.TabIndex = 9
			Me.Label3.Text = "Password"
			Me.cmdRefreshRevoke.Location = New Point(630, 5)
			Me.cmdRefreshRevoke.Name = "cmdRefreshRevoke"
			Me.cmdRefreshRevoke.Size = New System.Drawing.Size(103, 23)
			Me.cmdRefreshRevoke.TabIndex = 8
			Me.cmdRefreshRevoke.Text = "Load Account"
			Me.cmdRefreshRevoke.UseVisualStyleBackColor = True
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Point(7, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(47, 13)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Account"
			Me.cmbAppleId.FormattingEnabled = True
			Me.cmbAppleId.Location = New Point(61, 5)
			Me.cmbAppleId.Name = "cmbAppleId"
			Me.cmbAppleId.Size = New System.Drawing.Size(227, 21)
			Me.cmbAppleId.TabIndex = 6
			Me.lstRevoke.BackColor = Color.White
			Me.lstRevoke.FullRowSelect = True
			Me.lstRevoke.Location = New Point(-1, 33)
			Me.lstRevoke.Name = "lstRevoke"
			Me.lstRevoke.OwnerDraw = True
			Me.lstRevoke.Size = New System.Drawing.Size(735, 457)
			Me.lstRevoke.TabIndex = 5
			Me.lstRevoke.UseCompatibleStateImageBehavior = False
			Me.lstRevoke.View = View.Details
			Me.childPanelAppleIds.Controls.Add(Me.lstAccount)
			Me.childPanelAppleIds.Location = New Point(203, 0)
			Me.childPanelAppleIds.Name = "childPanelAppleIds"
			Me.childPanelAppleIds.Size = New System.Drawing.Size(736, 493)
			Me.childPanelAppleIds.TabIndex = 6
			Me.lstAccount.BackColor = Color.White
			Me.lstAccount.FullRowSelect = True
			Me.lstAccount.Location = New Point(0, -1)
			Me.lstAccount.Name = "lstAccount"
			Me.lstAccount.OwnerDraw = True
			Me.lstAccount.Size = New System.Drawing.Size(734, 491)
			Me.lstAccount.TabIndex = 0
			Me.lstAccount.UseCompatibleStateImageBehavior = False
			Me.lstAccount.View = View.Details
			Me.Panel2.BackColor = Color.WhiteSmoke
			Me.Panel2.Controls.Add(Me.lblDeleteAppId)
			Me.Panel2.Controls.Add(Me.lblAccount)
			Me.Panel2.Controls.Add(Me.lblRevokeCert)
			Me.Panel2.Controls.Add(Me.lblCydiaRepos)
			Me.Panel2.Location = New Point(2, -1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New System.Drawing.Size(200, 494)
			Me.Panel2.TabIndex = 0
			Me.lblDeleteAppId.BackColor = Color.WhiteSmoke
			Me.lblDeleteAppId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 163)
			Me.lblDeleteAppId.Location = New Point(1, 110)
			Me.lblDeleteAppId.Name = "lblDeleteAppId"
			Me.lblDeleteAppId.Size = New System.Drawing.Size(198, 35)
			Me.lblDeleteAppId.TabIndex = 3
			Me.lblDeleteAppId.Text = "     Delete AppId"
			Me.lblDeleteAppId.TextAlign = ContentAlignment.MiddleLeft
			Me.lblAccount.BackColor = Color.WhiteSmoke
			Me.lblAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 163)
			Me.lblAccount.Location = New Point(1, 38)
			Me.lblAccount.Name = "lblAccount"
			Me.lblAccount.Size = New System.Drawing.Size(198, 35)
			Me.lblAccount.TabIndex = 2
			Me.lblAccount.Text = "     Account Manager"
			Me.lblAccount.TextAlign = ContentAlignment.MiddleLeft
			Me.lblRevokeCert.BackColor = Color.WhiteSmoke
			Me.lblRevokeCert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 163)
			Me.lblRevokeCert.Location = New Point(1, 74)
			Me.lblRevokeCert.Name = "lblRevokeCert"
			Me.lblRevokeCert.Size = New System.Drawing.Size(198, 35)
			Me.lblRevokeCert.TabIndex = 1
			Me.lblRevokeCert.Text = "     Revoke Certificate"
			Me.lblRevokeCert.TextAlign = ContentAlignment.MiddleLeft
			Me.lblCydiaRepos.BackColor = Color.WhiteSmoke
			Me.lblCydiaRepos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 163)
			Me.lblCydiaRepos.Location = New Point(1, 2)
			Me.lblCydiaRepos.Name = "lblCydiaRepos"
			Me.lblCydiaRepos.Size = New System.Drawing.Size(198, 35)
			Me.lblCydiaRepos.TabIndex = 0
			Me.lblCydiaRepos.Text = "     Cydia Repos"
			Me.lblCydiaRepos.TextAlign = ContentAlignment.MiddleLeft
			Me.panelDevice.BackColor = Color.Transparent
			Me.panelDevice.Controls.Add(Me.cmdSupport)
			Me.panelDevice.Controls.Add(Me.cmdCheckForUpdate)
			Me.panelDevice.Controls.Add(Me.cmdAbout)
			Me.panelDevice.Controls.Add(Me.cmdFixCrash)
			Me.panelDevice.Controls.Add(Me.cmdInstallFromFile)
			Me.panelDevice.Controls.Add(Me.picLoading)
			Me.panelDevice.Controls.Add(Me.cmdResignExpired)
			Me.panelDevice.Controls.Add(Me.lblPhone)
			Me.panelDevice.Controls.Add(Me.lblModelNumber)
			Me.panelDevice.Controls.Add(Me.lblSerialNumber)
			Me.panelDevice.Controls.Add(Me.lblProductionVersion)
			Me.panelDevice.Controls.Add(Me.lblDeviceClass)
			Me.panelDevice.Controls.Add(Me.lblDeviceName)
			Me.panelDevice.Controls.Add(Me.cmdResignAll)
			Me.panelDevice.Controls.Add(Me.picDevice)
			Me.panelDevice.Controls.Add(Me.lstAppOnDevice)
			Me.panelDevice.Controls.Add(Me.Label6)
			Me.panelDevice.Controls.Add(Me.Label5)
			Me.panelDevice.Controls.Add(Me.cmbDevice)
			Me.panelDevice.Location = New Point(0, 98)
			Me.panelDevice.Name = "panelDevice"
			Me.panelDevice.Size = New System.Drawing.Size(938, 494)
			Me.panelDevice.TabIndex = 5
			Me.cmdCheckForUpdate.Location = New Point(139, 451)
			Me.cmdCheckForUpdate.Name = "cmdCheckForUpdate"
			Me.cmdCheckForUpdate.Size = New System.Drawing.Size(111, 23)
			Me.cmdCheckForUpdate.TabIndex = 18
			Me.cmdCheckForUpdate.Text = "Check for Update"
			Me.cmdCheckForUpdate.UseVisualStyleBackColor = True
			Me.cmdAbout.Location = New Point(261, 451)
			Me.cmdAbout.Name = "cmdAbout"
			Me.cmdAbout.Size = New System.Drawing.Size(75, 23)
			Me.cmdAbout.TabIndex = 17
			Me.cmdAbout.Text = "About"
			Me.cmdAbout.UseVisualStyleBackColor = True
			Me.cmdFixCrash.Location = New Point(744, 7)
			Me.cmdFixCrash.Name = "cmdFixCrash"
			Me.cmdFixCrash.Size = New System.Drawing.Size(81, 23)
			Me.cmdFixCrash.TabIndex = 16
			Me.cmdFixCrash.Text = "Fix Crash"
			Me.cmdFixCrash.UseVisualStyleBackColor = True
			Me.cmdFixCrash.Visible = False
			Me.cmdInstallFromFile.Location = New Point(832, 7)
			Me.cmdInstallFromFile.Name = "cmdInstallFromFile"
			Me.cmdInstallFromFile.Size = New System.Drawing.Size(96, 23)
			Me.cmdInstallFromFile.TabIndex = 15
			Me.cmdInstallFromFile.Text = "Install from IPA"
			Me.cmdInstallFromFile.UseVisualStyleBackColor = True
			Me.cmdInstallFromFile.Visible = False
			Me.picLoading.Image = DirectCast(componentResourceManager.GetObject("picLoading.Image"), Image)
			Me.picLoading.Location = New Point(155, 110)
			Me.picLoading.Name = "picLoading"
			Me.picLoading.Size = New System.Drawing.Size(59, 56)
			Me.picLoading.TabIndex = 13
			Me.picLoading.TabStop = False
			Me.cmdResignExpired.Location = New Point(466, 7)
			Me.cmdResignExpired.Name = "cmdResignExpired"
			Me.cmdResignExpired.Size = New System.Drawing.Size(103, 23)
			Me.cmdResignExpired.TabIndex = 12
			Me.cmdResignExpired.Text = "Resign Expired"
			Me.cmdResignExpired.UseVisualStyleBackColor = True
			Me.cmdResignExpired.Visible = False
			Me.lblPhone.AutoSize = True
			Me.lblPhone.Location = New Point(50, 304)
			Me.lblPhone.Name = "lblPhone"
			Me.lblPhone.Size = New System.Drawing.Size(0, 13)
			Me.lblPhone.TabIndex = 11
			Me.lblModelNumber.AutoSize = True
			Me.lblModelNumber.Location = New Point(50, 416)
			Me.lblModelNumber.Name = "lblModelNumber"
			Me.lblModelNumber.Size = New System.Drawing.Size(0, 13)
			Me.lblModelNumber.TabIndex = 10
			Me.lblSerialNumber.AutoSize = True
			Me.lblSerialNumber.Location = New Point(50, 388)
			Me.lblSerialNumber.Name = "lblSerialNumber"
			Me.lblSerialNumber.Size = New System.Drawing.Size(0, 13)
			Me.lblSerialNumber.TabIndex = 9
			Me.lblProductionVersion.AutoSize = True
			Me.lblProductionVersion.Location = New Point(50, 360)
			Me.lblProductionVersion.Name = "lblProductionVersion"
			Me.lblProductionVersion.Size = New System.Drawing.Size(0, 13)
			Me.lblProductionVersion.TabIndex = 8
			Me.lblDeviceClass.AutoSize = True
			Me.lblDeviceClass.Location = New Point(50, 332)
			Me.lblDeviceClass.Name = "lblDeviceClass"
			Me.lblDeviceClass.Size = New System.Drawing.Size(0, 13)
			Me.lblDeviceClass.TabIndex = 7
			Me.lblDeviceName.AutoSize = True
			Me.lblDeviceName.Location = New Point(50, 276)
			Me.lblDeviceName.Name = "lblDeviceName"
			Me.lblDeviceName.Size = New System.Drawing.Size(0, 13)
			Me.lblDeviceName.TabIndex = 6
			Me.cmdResignAll.Location = New Point(575, 7)
			Me.cmdResignAll.Name = "cmdResignAll"
			Me.cmdResignAll.Size = New System.Drawing.Size(75, 23)
			Me.cmdResignAll.TabIndex = 5
			Me.cmdResignAll.Text = "Resign All"
			Me.cmdResignAll.UseVisualStyleBackColor = True
			Me.cmdResignAll.Visible = False
			Me.picDevice.Location = New Point(89, 41)
			Me.picDevice.Name = "picDevice"
			Me.picDevice.Size = New System.Drawing.Size(196, 195)
			Me.picDevice.SizeMode = PictureBoxSizeMode.Zoom
			Me.picDevice.TabIndex = 4
			Me.picDevice.TabStop = False
			Me.picDevice.Visible = False
			Me.lstAppOnDevice.BackColor = Color.White
			Me.lstAppOnDevice.FullRowSelect = True
			Me.lstAppOnDevice.Location = New Point(382, 37)
			Me.lstAppOnDevice.Name = "lstAppOnDevice"
			Me.lstAppOnDevice.OwnerDraw = True
			Me.lstAppOnDevice.Size = New System.Drawing.Size(556, 457)
			Me.lstAppOnDevice.TabIndex = 3
			Me.lstAppOnDevice.UseCompatibleStateImageBehavior = False
			Me.lstAppOnDevice.View = View.Details
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Point(387, 12)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(73, 13)
			Me.Label6.TabIndex = 2
			Me.Label6.Text = "Installed Apps"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Point(5, 11)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(41, 13)
			Me.Label5.TabIndex = 1
			Me.Label5.Text = "Device"
			Me.cmbDevice.FormattingEnabled = True
			Me.cmbDevice.Location = New Point(50, 7)
			Me.cmbDevice.Name = "cmbDevice"
			Me.cmbDevice.Size = New System.Drawing.Size(324, 21)
			Me.cmbDevice.TabIndex = 0
			Me.cmdSupport.Location = New Point(53, 451)
			Me.cmdSupport.Name = "cmdSupport"
			Me.cmdSupport.Size = New System.Drawing.Size(75, 23)
			Me.cmdSupport.TabIndex = 19
			Me.cmdSupport.Text = "Support"
			Me.cmdSupport.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(939, 592)
			MyBase.Controls.Add(Me.panelDevice)
			MyBase.Controls.Add(Me.panelTools)
			MyBase.Controls.Add(Me.panelApp)
			MyBase.Controls.Add(Me.panelDownloads)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.panelHome)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = DirectCast(componentResourceManager.GetObject("$this.Icon"), System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSuperImpactor"
			Me.Text = "SuperImpactor"
			Me.Panel1.ResumeLayout(False)
			DirectCast(Me.picHomeBtn, ISupportInitialize).EndInit()
			DirectCast(Me.picDownloadBtn, ISupportInitialize).EndInit()
			DirectCast(Me.picToolBtn, ISupportInitialize).EndInit()
			DirectCast(Me.picDeviceBtn, ISupportInitialize).EndInit()
			DirectCast(Me.picAppBtn, ISupportInitialize).EndInit()
			DirectCast(Me.picLogo, ISupportInitialize).EndInit()
			Me.panelHome.ResumeLayout(False)
			Me.panelApp.ResumeLayout(False)
			Me.panelApp.PerformLayout()
			Me.panelDownloads.ResumeLayout(False)
			Me.panelTools.ResumeLayout(False)
			Me.childPanelRepo.ResumeLayout(False)
			Me.childPanelRepo.PerformLayout()
			Me.childPanelRevoke.ResumeLayout(False)
			Me.childPanelRevoke.PerformLayout()
			Me.childPanelAppleIds.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.panelDevice.ResumeLayout(False)
			Me.panelDevice.PerformLayout()
			DirectCast(Me.picLoading, ISupportInitialize).EndInit()
			DirectCast(Me.picDevice, ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub lblAccount_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.crrTools = 1
			Me.lblAccount.BackColor = Color.FromName("GradientActiveCaption")
			Me.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke")
			Me.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke")
			Me.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke")
			Me.childPanelAppleIds.BringToFront()
			Me.LoadAccounts()
		End Sub

		Private Sub lblAccount_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.crrTools <> 1) Then
				Me.lblAccount.BackColor = Color.FromName("WhiteSmoke")
			Else
				Me.lblAccount.BackColor = Color.FromName("GradientActiveCaption")
			End If
		End Sub

		Private Sub lblAccount_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Me.lblAccount.BackColor = Color.FromName("Info")
		End Sub

		Private Sub lblCydiaRepos_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.crrTools = 0
			Me.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption")
			Me.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke")
			Me.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke")
			Me.lblAccount.BackColor = Color.FromName("WhiteSmoke")
			Me.lstCydia.Clear()
			Me.LoadCydiaRepos("")
			Me.childPanelRepo.BringToFront()
		End Sub

		Private Sub lblCydiaRepos_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.crrTools <> 0) Then
				Me.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke")
			Else
				Me.lblCydiaRepos.BackColor = Color.FromName("GradientActiveCaption")
			End If
		End Sub

		Private Sub lblCydiaRepos_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Me.lblCydiaRepos.BackColor = Color.FromName("Info")
		End Sub

		Private Sub lblDeleteAppId_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As Dictionary(Of String, String).Enumerator = New Dictionary(Of String, String).Enumerator()
			Me.crrTools = 3
			Me.lblDeleteAppId.BackColor = Color.FromName("GradientActiveCaption")
			Me.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke")
			Me.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke")
			Me.lblAccount.BackColor = Color.FromName("WhiteSmoke")
			Me.cmbAppleId.Items.Clear()
			Try
				enumerator = Me.lstAcc.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As KeyValuePair(Of String, String) = enumerator.Current
					Me.cmbAppleId.Items.Add(current.Key)
				End While
			Finally
				DirectCast(enumerator, IDisposable).Dispose()
			End Try
			Me.lstRevoke.Clear()
			Me.childPanelRevoke.BringToFront()
		End Sub

		Private Sub lblDeleteAppId_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.crrTools <> 3) Then
				Me.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke")
			Else
				Me.lblDeleteAppId.BackColor = Color.FromName("GradientActiveCaption")
			End If
		End Sub

		Private Sub lblDeleteAppId_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Me.lblDeleteAppId.BackColor = Color.FromName("Info")
		End Sub

		Private Sub lblRevokeCert_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As Dictionary(Of String, String).Enumerator = New Dictionary(Of String, String).Enumerator()
			Me.crrTools = 2
			Me.lblRevokeCert.BackColor = Color.FromName("GradientActiveCaption")
			Me.lblCydiaRepos.BackColor = Color.FromName("WhiteSmoke")
			Me.lblDeleteAppId.BackColor = Color.FromName("WhiteSmoke")
			Me.lblAccount.BackColor = Color.FromName("WhiteSmoke")
			Me.cmbAppleId.Items.Clear()
			Try
				enumerator = Me.lstAcc.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As KeyValuePair(Of String, String) = enumerator.Current
					Me.cmbAppleId.Items.Add(current.Key)
				End While
			Finally
				DirectCast(enumerator, IDisposable).Dispose()
			End Try
			Me.lstRevoke.Clear()
			Me.childPanelRevoke.BringToFront()
		End Sub

		Private Sub lblRevokeCert_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.crrTools <> 2) Then
				Me.lblRevokeCert.BackColor = Color.FromName("WhiteSmoke")
			Else
				Me.lblRevokeCert.BackColor = Color.FromName("GradientActiveCaption")
			End If
		End Sub

		Private Sub lblRevokeCert_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Me.lblRevokeCert.BackColor = Color.FromName("Info")
		End Sub

		Private Sub LoadAccounts()
			Me.lstAcc = Database.GetAccounts()
			Me.lstAccount.Clear()
			Me.lstAccount.View = View.Details
			Me.lstAccount.Columns.Add("Saved Apple Ids", Me.childPanelAppleIds.Width - 5)
			Dim count As Integer = Me.lstAcc.Keys.Count - 1
			For i As Integer = 0 To count Step 1
				Dim extraDatum As ExtraData = New ExtraData() With
				{
					.HeaderText = Me.lstAcc.Keys.ElementAt(i),
					.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("appleid"), Bitmap)),
					.ButtonText2 = "REMOVE"
				}
				Me.lstAccount.Items.Add("").Tag = extraDatum
			Next

		End Sub

		Private Function LoadApps() As Object
			Dim obj As Object
			Application.DoEvents()
			Dim nSDictionary As Claunia.PropertyList.NSDictionary = AppleService.login(Me.cmbAppleId.Text, Me.txtPassword.Text)
			If (nSDictionary.ContainsKey("myacinfo")) Then
				Dim str As String = nSDictionary.ObjectForKey("myacinfo").ToString()
				Application.DoEvents()
				nSDictionary = AppleService.listTeam(str)
				Dim str1 As String = ""
				If (nSDictionary.ContainsKey("teams")) Then
					Dim nSArray As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("teams"), Claunia.PropertyList.NSArray)
					If (nSArray.get_Count() > 0) Then
						Dim nSDictionary1 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray.ElementAt(0), Claunia.PropertyList.NSDictionary)
						If (nSDictionary1.ContainsKey("teamId")) Then
							str1 = nSDictionary1.ObjectForKey("teamId").ToString()
						End If
					End If
				End If
				If (Operators.CompareString(str1, "", False) <> 0) Then
					Me.lstRevoke.Clear()
					Me.lstRevoke.Columns.Add("Name", Me.childPanelRevoke.Width - 5)
					Me.lstRevoke.View = View.Details
					Me.lstRevoke.Tag = str1
					Application.DoEvents()
					nSDictionary = AppleService.appIds(str1)
					Dim str2 As String = ""
					If (nSDictionary.ContainsKey("appIds")) Then
						Dim nSArray1 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("appIds"), Claunia.PropertyList.NSArray)
						Dim count As Integer = nSArray1.get_Count() - 1
						Dim num As Integer = 0
						Do
							Dim nSDictionary2 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray1.ElementAt(num), Claunia.PropertyList.NSDictionary)
							If (nSDictionary2.ContainsKey("appIdId") And nSDictionary2.ContainsKey("name")) Then
								str2 = nSDictionary2.ObjectForKey("appIdId").ToString()
								Dim extraDatum As ExtraData = New ExtraData() With
								{
									.HeaderText = nSDictionary2.ObjectForKey("name").ToString(),
									.MinorText = nSDictionary2.ObjectForKey("appIdId").ToString(),
									.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("appid"), Bitmap)),
									.ButtonText2 = "REMOVE"
								}
								Me.lstRevoke.Items.Add("").Tag = extraDatum
							End If
							num = num + 1
						Loop While num <= count
						If (Me.lstRevoke.Items.Count = 0) Then
							obj = "No AppId"
							Return obj
						End If
					End If
					obj = ""
				Else
					obj = "Not have teamId"
				End If
			Else
				obj = "Cannot login itune..."
			End If
			Return obj
		End Function

		Private Function LoadCertificates() As Object
			Dim obj As Object
			Application.DoEvents()
			Dim nSDictionary As Claunia.PropertyList.NSDictionary = AppleService.login(Me.cmbAppleId.Text, Me.txtPassword.Text)
			If (nSDictionary.ContainsKey("myacinfo")) Then
				Dim str As String = nSDictionary.ObjectForKey("myacinfo").ToString()
				Application.DoEvents()
				nSDictionary = AppleService.listTeam(str)
				Dim str1 As String = ""
				If (nSDictionary.ContainsKey("teams")) Then
					Dim nSArray As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("teams"), Claunia.PropertyList.NSArray)
					If (nSArray.get_Count() > 0) Then
						Dim nSDictionary1 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray.ElementAt(0), Claunia.PropertyList.NSDictionary)
						If (nSDictionary1.ContainsKey("teamId")) Then
							str1 = nSDictionary1.ObjectForKey("teamId").ToString()
						End If
					End If
				End If
				If (Operators.CompareString(str1, "", False) <> 0) Then
					Application.DoEvents()
					nSDictionary = AppleService.allDevelopmentCert(str1)
					Me.lstRevoke.Clear()
					Me.lstRevoke.Columns.Add("Name", Me.childPanelRevoke.Width - 5)
					Me.lstRevoke.View = View.Details
					Me.lstRevoke.Tag = str1
					If (nSDictionary.ContainsKey("certificates")) Then
						Dim nSArray1 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("certificates"), Claunia.PropertyList.NSArray)
						Dim count As Integer = nSArray1.get_Count() - 1
						Dim num As Integer = 0
						Do
							Dim nSDictionary2 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray1.ElementAt(num), Claunia.PropertyList.NSDictionary)
							If (nSDictionary2.ContainsKey("name") And nSDictionary2.ContainsKey("serialNumber")) Then
								Dim extraDatum As ExtraData = New ExtraData()
								If (Not nSDictionary2.ContainsKey("machineName")) Then
									extraDatum.HeaderText = nSDictionary2.ObjectForKey("name").ToString()
								Else
									extraDatum.HeaderText = String.Concat(nSDictionary2.ObjectForKey("name").ToString(), " - ", nSDictionary2.ObjectForKey("machineName").ToString())
								End If
								extraDatum.MinorText = nSDictionary2.ObjectForKey("serialNumber").ToString()
								extraDatum.DescText = nSDictionary2.ObjectForKey("expirationDate").ToString()
								extraDatum.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("cert"), Bitmap))
								extraDatum.ButtonText2 = "REMOVE"
								Me.lstRevoke.Items.Add("").Tag = extraDatum
							End If
							num = num + 1
						Loop While num <= count
						If (Me.lstRevoke.Items.Count = 0) Then
							obj = "No Certificates"
							Return obj
						End If
					End If
					obj = ""
				Else
					obj = "Not have teamId"
				End If
			Else
				obj = "Cannot login itune..."
			End If
			Return obj
		End Function

		Private Function LoadCydiaRepos(Optional ByVal cydiaReposName As String = "") As Object
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader()
			Me.lstCydia.Clear()
			Me.lstCydia.View = View.Details
			Me.lstCydia.Columns.Add("Repos", Me.childPanelRepo.Width - 5)
			Dim [integer] As Integer = -1
			While sQLiteDataReader.Read()
				Dim extraDatum As ExtraData = New ExtraData() With
				{
					.HeaderText = Conversions.ToString(sQLiteDataReader.get_Item("name")),
					.MinorText = Conversions.ToString(sQLiteDataReader.get_Item("path")),
					.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("repos"), Bitmap)),
					.ButtonText2 = "REMOVE"
				}
				Me.lstCydia.Items.Add("").Tag = extraDatum
				If (Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("path"), cydiaReposName, False)) Then
					[integer] = Conversions.ToInteger(sQLiteDataReader.get_Item("id"))
				End If
			End While
			Return [integer]
		End Function

		Public Shared Function LoadPackages(ByVal cydiaRepos As String) As Boolean
			Dim flag As Boolean
			Dim webClient As System.Net.WebClient = New System.Net.WebClient()
			Try
				webClient.DownloadFile(String.Concat(cydiaRepos, "/Packages.bz2"), "Packages.bz2")
				Dim fileStream As System.IO.FileStream = (New FileInfo("Packages.bz2")).OpenRead()
				Using fileStream
					Dim fileStream1 As System.IO.FileStream = File.Create("Packages")
					Using fileStream1
						BZip2.Decompress(fileStream, fileStream1, True)
					End Using
				End Using
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				Try
					webClient.DownloadFile(String.Concat(cydiaRepos, "/Packages"), "Packages")
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Interaction.MsgBox("Invalid cydia", MsgBoxStyle.OkOnly, Nothing)
					flag = False
					ProjectData.ClearProjectError()
					Return flag
				End Try
				ProjectData.ClearProjectError()
			End Try
			flag = True
			Return flag
		End Function

		Private Sub lstAccount_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
			If (Me.lstAccount.SelectedItems.Count <= 0) Then
				Interaction.MsgBox("Select account to remove", MsgBoxStyle.OkOnly, Nothing)
			Else
				Database.DeleteAccount(DirectCast(Me.lstAccount.SelectedItems(0).Tag, ExtraData).HeaderText)
				Me.LoadAccounts()
			End If
		End Sub

		Private Sub lstAppOnDevice_Button1Click(ByVal sender As Object, ByVal e As FileEventArgs)
			Dim str As String = Nothing
			Dim str1 As String
			Dim install As SuperImpactor.Install = New SuperImpactor.Install()
			Dim str2 As String = ""
			str2 = e.data.DescText.Substring(36)
			str1 = If(Not str2.StartsWith("clone"), "", str2.Substring(5, 7))
			Database.getInstalledApp(str2, Me.cmbDevice.Text.Substring(Me.cmbDevice.Text.Length - 40), str)
			If (Not File.Exists(String.Concat(AppConst.m_rootPath, "\download\", str))) Then
				Interaction.MsgBox("IPA file have been remove from Downloads. Please download this app again then install", MsgBoxStyle.OkOnly, "Error")
			Else
				install.installFromFile(String.Concat(AppConst.m_rootPath, "\download\", str), str1, e.data.HeaderText)
			End If
		End Sub

		Private Async Sub lstAppOnDevice_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
			Dim str As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "\libimobiledevice\ideviceinstaller.exe"), String.Concat("-u ", Me.cmbDevice.Text.Substring(Me.cmbDevice.Text.Length - 40), " -U ", e.data.DescText), False)
			Me.cmbDevice.Text = ""
		End Sub

		Private Sub lstAppOnDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub lstApps_Button1Click(ByVal sender As Object, ByVal e As FileEventArgs)
			Dim filename As String
			Dim str As String = Nothing
			Dim downloadProgress As SuperImpactor.DownloadProgress = New SuperImpactor.DownloadProgress()
			If (e.data.AppDetailObj.Filename.IndexOf("dailyuploads.net") < 0) Then
				If (e.data.AppDetailObj.Filename.EndsWith(".deb")) Then
					str = String.Concat(e.data.AppDetailObj.Name, ".deb")
				End If
				filename = e.data.AppDetailObj.Filename
			Else
				filename = e.data.AppDetailObj.Filename
				str = "checking...ipa"
			End If
			Common.Download(downloadProgress, filename, str)
		End Sub

		Private Sub lstApps_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
		End Sub

		Private Sub lstApps_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.lstApps.SelectedItems.Count > 0) Then
				Dim appDetail As SuperImpactor.AppDetail = New SuperImpactor.AppDetail()
				appDetail.showApp(DirectCast(Me.lstApps.SelectedItems(0).Tag, ExtraData).AppDetailObj)
			End If
		End Sub

		Private Sub lstApps_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub lstCydia_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
			If (Me.lstCydia.SelectedItems.Count <= 0) Then
				Interaction.MsgBox("No repos to remove", MsgBoxStyle.OkOnly, Nothing)
			Else
				Dim str As String = String.Concat("select * from cydia_repos WHERE path='", DirectCast(Me.lstCydia.SelectedItems(0).Tag, ExtraData).MinorText, "'")
				Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteReader()
				Dim num As Long = CLng(-1)
				If (sQLiteDataReader.Read()) Then
					num = Conversions.ToLong(sQLiteDataReader.get_Item("id"))
				End If
				str = String.Concat("DELETE FROM cydia_repos WHERE id=", Conversions.ToString(num))
				Dim num1 As Integer = (New SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery()
				str = String.Concat("DELETE FROM list_app WHERE cydia_repos=", Conversions.ToString(num))
				Dim num2 As Integer = (New SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteNonQuery()
				Me.LoadCydiaRepos("")
			End If
		End Sub

		Private Sub lstCydia_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub lstDownloads_Button1Click(ByVal sender As Object, ByVal e As FileEventArgs)
			Dim install As SuperImpactor.Install = New SuperImpactor.Install()
			install.installFromFile(String.Concat(AppConst.m_rootPath, "\download\", e.data.HeaderText), "", "")
		End Sub

		Private Sub lstDownloads_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
			If (Me.lstDownloads.SelectedItems.Count <= 0) Then
				Interaction.MsgBox("No file selected", MsgBoxStyle.OkOnly, Nothing)
			Else
				File.Delete(String.Concat(AppConst.m_rootPath, "\download\", DirectCast(Me.lstDownloads.SelectedItems(0).Tag, ExtraData).HeaderText))
				Me.lstDownloads.Items.Remove(Me.lstDownloads.SelectedItems(0))
			End If
		End Sub

		Private Sub lstRevoke_Button2Click(ByVal sender As Object, ByVal e As FileEventArgs)
			If (Me.lstRevoke.SelectedItems.Count <= 0) Then
				Interaction.MsgBox("No Certificate/AppId selected", MsgBoxStyle.OkOnly, Nothing)
			Else
				If (Me.lblDeleteAppId.BackColor <> Color.FromName("GradientActiveCaption")) Then
					AppleService.revokeCertificate(DirectCast(Me.lstRevoke.SelectedItems(0).Tag, ExtraData).MinorText, Conversions.ToString(Me.lstRevoke.Tag))
				Else
					AppleService.deleteAppId(DirectCast(Me.lstRevoke.SelectedItems(0).Tag, ExtraData).MinorText, Conversions.ToString(Me.lstRevoke.Tag))
				End If
				Me.lstRevoke.Items.Remove(Me.lstRevoke.SelectedItems(0))
			End If
		End Sub

		Private Sub MySearchMethod()
			Me.ReloadApps(Me.txtAppSearch.Text)
		End Sub

		Public Sub onDownloadComplete()
			If (Me.isShowDownload) Then
				Me.picDownloadBtn_Click(Nothing, Nothing)
			End If
		End Sub

		Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
		End Sub

		Private Sub panelDevice_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
		End Sub

		Private Sub panelDownloads_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
		End Sub

		Public Shared Async Function ParsePackages(ByVal cydiaId As Integer, Optional ByVal frm As UpdateCydia = Nothing, Optional ByVal fn As Object = Nothing, Optional ByVal cydiaUrl As String = "") As Task
			Dim enumerator As IEnumerator = Nothing
			Try
				File.Delete("Packages.xml")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Dim str As String = Await Common.RunExe(String.Concat(AppConst.m_rootPath, "/repo2xml.exe"), String.Concat("Packages Packages.xml """, cydiaUrl, """"), True)
			AppConst.logger.Debug(String.Concat("Convert repo2xml: ", str))
			Dim xmlDocument As System.Xml.XmlDocument = New System.Xml.XmlDocument()
			xmlDocument.Load("Packages.xml")
			Dim xmlNodeLists As XmlNodeList = xmlDocument.DocumentElement.SelectNodes("/allapp/app")
			Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("INSERT INTO list_app(cydia_repos,package,version,section,depends,arch,filename,size,icon,description,name,author,homepage) " & VbCrLf & "                                                VALUES(@cydia_repos,@package,@version,@section,@depends,@arch,@filename,@size,@icon,@description,@name,@author,@homepage)", AppConst.m_dbConnection)
			Dim count As Integer = xmlNodeLists.Count
			Dim num As Integer = 0
			Try
				enumerator = xmlNodeLists.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As XmlNode = DirectCast(enumerator.Current, XmlNode)
					Dim parameters As SQLiteParameterCollection = sQLiteCommand.get_Parameters()
					parameters.AddWithValue("@cydia_repos", cydiaId)
					parameters.AddWithValue("@package", current.SelectSingleNode("Package").InnerText)
					parameters.AddWithValue("@version", current.SelectSingleNode("Version").InnerText)
					parameters.AddWithValue("@section", current.SelectSingleNode("Section").InnerText)
					parameters.AddWithValue("@depends", current.SelectSingleNode("Depends").InnerText)
					parameters.AddWithValue("@arch", current.SelectSingleNode("Architecture").InnerText)
					parameters.AddWithValue("@filename", current.SelectSingleNode("Filename").InnerText)
					parameters.AddWithValue("@size", current.SelectSingleNode("Size").InnerText)
					parameters.AddWithValue("@icon", current.SelectSingleNode("Icon").InnerText)
					parameters.AddWithValue("@description", current.SelectSingleNode("Description").InnerText)
					parameters.AddWithValue("@name", current.SelectSingleNode("Name").InnerText)
					parameters.AddWithValue("@author", current.SelectSingleNode("Author").InnerText)
					parameters.AddWithValue("@homepage", current.SelectSingleNode("Homepage").InnerText)
					parameters = Nothing
					sQLiteCommand.ExecuteNonQuery()
					num = num + 1
					If (frm IsNot Nothing) Then
						Dim updateCydium As UpdateCydia = frm
						Dim [delegate] As System.[Delegate] = DirectCast(fn, System.[Delegate])
						Dim objArray() As Object = { "", CInt(Math.Round(Math.Round(CDbl((num * 100)) / CDbl(count)))) }
						updateCydium.Invoke([delegate], objArray)
					End If
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Function

		Private Sub picAppBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.picAppBtn.BorderStyle = BorderStyle.Fixed3D
			Me.picDeviceBtn.BorderStyle = BorderStyle.None
			Me.picDownloadBtn.BorderStyle = BorderStyle.None
			Me.picHomeBtn.BorderStyle = BorderStyle.None
			Me.picToolBtn.BorderStyle = BorderStyle.None
			Me.panelApp.BringToFront()
			Me.isShowDownload = False
			If (Me.firstTimeLoadApp) Then
				Me.firstTimeLoadApp = False
				MyBase.Invoke(New frmSuperImpactor.MySearchMethodDelegrate(AddressOf Me.MySearchMethod))
			End If
		End Sub

		Private Sub picDevice_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub picDeviceBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.picAppBtn.BorderStyle = BorderStyle.None
			Me.picDeviceBtn.BorderStyle = BorderStyle.Fixed3D
			Me.picDownloadBtn.BorderStyle = BorderStyle.None
			Me.picHomeBtn.BorderStyle = BorderStyle.None
			Me.picToolBtn.BorderStyle = BorderStyle.None
			Me.isShowDownload = False
			Me.panelDevice.BringToFront()
			Me.cmbDevice.Text = ""
		End Sub

		Private Sub picDownloadBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String
			Dim num As Double
			Me.picAppBtn.BorderStyle = BorderStyle.None
			Me.picDeviceBtn.BorderStyle = BorderStyle.None
			Me.picDownloadBtn.BorderStyle = BorderStyle.Fixed3D
			Me.picHomeBtn.BorderStyle = BorderStyle.None
			Me.picToolBtn.BorderStyle = BorderStyle.None
			Me.isShowDownload = True
			Me.panelDownloads.BringToFront()
			Me.lstDownloads.Clear()
			Me.lstDownloads.View = View.Details
			Me.lstDownloads.Columns.Add("Name", MyBase.Width - 20)
			Dim files As String() = Directory.GetFiles(String.Concat(AppConst.m_rootPath, "\download\"), "*.ipa")
			Dim num1 As Integer = Information.UBound(files, 1)
			For i As Integer = 0 To num1 Step 1
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(files(i))
				If (CDbl(fileInfo.Length) / 1024 / 1024 / 1024 >= 1) Then
					num = Math.Round(CDbl(fileInfo.Length) / 1024 / 1024 / 1024, 2)
					str = String.Concat(num.ToString(), " GB")
				ElseIf (CDbl(fileInfo.Length) / 1024 / 1024 < 1) Then
					num = Math.Round(CDbl(fileInfo.Length) / 1024, 2)
					str = String.Concat(num.ToString(), " KB")
				Else
					num = Math.Round(CDbl(fileInfo.Length) / 1024 / 1024, 2)
					str = String.Concat(num.ToString(), " MB")
				End If
				Dim extraDatum As ExtraData = New ExtraData() With
				{
					.HeaderText = fileInfo.Name,
					.MinorText = str,
					.DescText = Conversions.ToString(fileInfo.LastWriteTime)
				}
				If (Not File.Exists(String.Concat(fileInfo.FullName, ".png"))) Then
					extraDatum.MainImage = New Bitmap(DirectCast(Resources.ResourceManager.GetObject("ipafile"), Bitmap))
				Else
					extraDatum.MainImage = New Bitmap(String.Concat(fileInfo.Name, ".png"))
				End If
				extraDatum.ButtonText1 = "INSTALL"
				extraDatum.ButtonText2 = "REMOVE"
				Me.lstDownloads.Items.Add("").Tag = extraDatum
			Next

		End Sub

		Private Sub picHomeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.picAppBtn.BorderStyle = BorderStyle.None
			Me.picDeviceBtn.BorderStyle = BorderStyle.None
			Me.picDownloadBtn.BorderStyle = BorderStyle.None
			Me.picHomeBtn.BorderStyle = BorderStyle.Fixed3D
			Me.picToolBtn.BorderStyle = BorderStyle.None
			Me.isShowDownload = False
			Me.panelHome.BringToFront()
		End Sub

		Private Sub picLogo_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub picToolBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.picAppBtn.BorderStyle = BorderStyle.None
			Me.picDeviceBtn.BorderStyle = BorderStyle.None
			Me.picDownloadBtn.BorderStyle = BorderStyle.None
			Me.picHomeBtn.BorderStyle = BorderStyle.None
			Me.picToolBtn.BorderStyle = BorderStyle.Fixed3D
			Me.isShowDownload = False
			Me.panelTools.BringToFront()
		End Sub

		Private Async Sub ReloadApps(Optional ByVal search As String = "")
			Dim variable As frmSuperImpactor.VB$StateMachine_246_ReloadApps = Nothing
			AsyncVoidMethodBuilder.Create().Start(Of frmSuperImpactor.VB$StateMachine_246_ReloadApps)(variable)
		End Sub

		Private Sub resign(ByVal expire As Boolean)
			Dim str As String = Nothing
			Dim appInfosResigns As List(Of SuperImpactor.AppInfosResign) = New List(Of SuperImpactor.AppInfosResign)()
			Dim str1 As String = Me.cmbDevice.Text.Substring(Me.cmbDevice.Text.Length - 40)
			Dim count As Integer = Me.crrAppsOnDevice.Count - 1
			Dim num As Integer = 0
			Do
				Dim flag As Boolean = False
				If (Not expire) Then
					flag = True
				ElseIf (Not Me.lstProvision.ContainsKey(Me.crrAppsOnDevice(num).Package)) Then
					flag = True
				Else
					Dim item As DateTime = Me.lstProvision(Me.crrAppsOnDevice(num).Package).eDate
					Dim now As DateTime = DateAndTime.Now
					flag = DateTime.Compare(item, now.[Date]) <= 0
				End If
				If (flag) Then
					If (Me.crrAppsOnDevice(num).Package.Length > 40) Then
						Dim appInfosResign As SuperImpactor.AppInfosResign = New SuperImpactor.AppInfosResign() With
						{
							.Architecture = Me.crrAppsOnDevice(num).Architecture,
							.Author = Me.crrAppsOnDevice(num).Author,
							.Depends = Me.crrAppsOnDevice(num).Depends,
							.Description = Me.crrAppsOnDevice(num).Description,
							.Filename = Me.crrAppsOnDevice(num).Filename,
							.Homepage = Me.crrAppsOnDevice(num).Homepage,
							.Icon = Me.crrAppsOnDevice(num).Icon,
							.Name = Me.crrAppsOnDevice(num).Name,
							.Package = Me.crrAppsOnDevice(num).Package.Substring(36)
						}
						If (Not appInfosResign.Package.StartsWith("clone")) Then
							appInfosResign.cloneId = ""
						Else
							appInfosResign.cloneId = appInfosResign.Package.Substring(5, 7)
							appInfosResign.Package = appInfosResign.Package.Substring(13)
						End If
						appInfosResign.Section = Me.crrAppsOnDevice(num).Section
						appInfosResign.Size = Me.crrAppsOnDevice(num).Size
						appInfosResign.Version = Me.crrAppsOnDevice(num).Version
						appInfosResign.appleId = Database.getInstalledApp(appInfosResign.Package, str1, str)
						If (Operators.CompareString(appInfosResign.appleId, "", False) <> 0) Then
							appInfosResign.Filename = str
							If (Me.lstAcc.ContainsKey(appInfosResign.appleId)) Then
								appInfosResign.password = Me.lstAcc(appInfosResign.appleId)
							End If
						Else
							appInfosResign.password = ""
						End If
						appInfosResigns.Add(appInfosResign)
					End If
				End If
				num = num + 1
			Loop While num <= count
			If (Not Application.OpenForms.OfType(Of SuperImpactor.AutoResign)().Any()) Then
				Dim autoResign As SuperImpactor.AutoResign = New SuperImpactor.AutoResign()
				autoResign.ResignAsync(appInfosResigns, str1, Me.cmbDevice.Text.Substring(0, Me.cmbDevice.Text.Length - 40), "SuperImpactor", Common.GetHash(str1))
			Else
				MessageBox.Show("Other Resign process is already running. Please wait until current Resign process finished!")
			End If
		End Sub

		<DllImport("user32", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=True)>
		Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		End Function

		Public Sub SetListViewSpacing(ByVal lst As ListView, ByVal x As Integer, ByVal y As Integer)
			frmSuperImpactor.SendMessage(lst.Handle, 4149, 0, x * 65536 + y)
		End Sub

		Private Sub ThreadTask()
			Dim webClient As System.Net.WebClient = New System.Net.WebClient()
			Dim num As Integer = 0
			While Not Me.isExit
				num = (num + 1) Mod 10
				Try
					If (num = 0) Then
						Me.detectDevice()
						MyBase.BeginInvoke(New frmSuperImpactor.DeviceInvokeDelegate(AddressOf Me.DeviceInvokeMethod))
					End If
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Console.WriteLine(exception.Message)
					ProjectData.ClearProjectError()
				End Try
				Thread.Sleep(200)
			End While
		End Sub

		Private Sub txtAppSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.mint_LastInitializedTimerID = Me.mint_LastInitializedTimerID + 1
			Dim num As Integer = 500
			If (Me.txtAppSearch.Text.Length >= 6) Then
				num = 250
			End If
			If (Me.txtAppSearch.Text.Contains(" ") And Not Me.txtAppSearch.Text.EndsWith(" ")) Then
				num = 175
			End If
			Dim timer As System.Timers.Timer = New System.Timers.Timer(CDbl(num))
			AddHandler timer.Elapsed,  New ElapsedEventHandler(AddressOf Me.txtAppSearch_TimerElapsed)
			timer.AutoReset = False
			timer.Enabled = True
		End Sub

		Private Sub txtAppSearch_TimerElapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
			Me.mint_LastReceivedTimerID = Me.mint_LastReceivedTimerID + 1
			If (Me.mint_LastReceivedTimerID = Me.mint_LastInitializedTimerID) Then
				MyBase.Invoke(New frmSuperImpactor.MySearchMethodDelegrate(AddressOf Me.MySearchMethod))
			End If
		End Sub

		Public Shared Sub UnhandledExceptionHandler(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
			AppConst.logger.[Error](String.Concat("Exception: ", DirectCast(args.ExceptionObject, Exception).Message, " - ", DirectCast(args.ExceptionObject, Exception).StackTrace))
		End Sub

		Private Class DeviceInfo
			Public udid As String

			Public deviceName As String

			Public deviceClass As String

			Public productVersion As String

			Public serialNumber As String

			Public modelNumber As String

			Public phoneNumber As String

			Public Sub New()
				MyBase.New()
				Me.udid = ""
				Me.deviceName = ""
				Me.deviceClass = ""
				Me.productVersion = ""
				Me.serialNumber = ""
				Me.modelNumber = ""
				Me.phoneNumber = ""
			End Sub
		End Class

		Public Delegate Sub DeviceInvokeDelegate()

		Public Delegate Sub MySearchMethodDelegrate()

		Private Class ProvisionInfo
			Public eDate As DateTime

			Public id As String

			Public Sub New()
				MyBase.New()
			End Sub
		End Class
	End Class
End Namespace