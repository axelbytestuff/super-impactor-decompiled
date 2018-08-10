Imports log4net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class Main
		Inherits Form
		Public Const LVM_FIRST As Long = 4096L

		Public Const LVM_SETICONSPACING As Long = 4149L

		Private components As IContainer

		Friend Overridable Property AboutToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._AboutToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AboutToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._AboutToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._AboutToolStripMenuItem = value
				toolStripMenuItem = Me._AboutToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property AboutToolStripMenuItem1 As ToolStripMenuItem
			Get
				stackVariable1 = Me._AboutToolStripMenuItem1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AboutToolStripMenuItem1_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._AboutToolStripMenuItem1
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._AboutToolStripMenuItem1 = value
				toolStripMenuItem = Me._AboutToolStripMenuItem1
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property AppleAccountsManagerMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._AppleAccountsManagerMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AppleAccountsManagerMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._AppleAccountsManagerMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._AppleAccountsManagerMenuItem = value
				toolStripMenuItem = Me._AppleAccountsManagerMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdHot As Button
			Get
				stackVariable1 = Me._cmdHot
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button1_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdHot
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdHot = value
				button = Me._cmdHot
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

		Friend Overridable Property CydiaReposManagerMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._CydiaReposManagerMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.CydiaReposManagerMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._CydiaReposManagerMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._CydiaReposManagerMenuItem = value
				toolStripMenuItem = Me._CydiaReposManagerMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property DeleteAppIDToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._DeleteAppIDToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DeleteAppIDToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._DeleteAppIDToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._DeleteAppIDToolStripMenuItem = value
				toolStripMenuItem = Me._DeleteAppIDToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property DownloadedFilesToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._DownloadedFilesToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadedFilesToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._DownloadedFilesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._DownloadedFilesToolStripMenuItem = value
				toolStripMenuItem = Me._DownloadedFilesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property EditToolStripMenuItem As ToolStripMenuItem

		Friend Overridable Property FileToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._FileToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.FileToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._FileToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._FileToolStripMenuItem = value
				toolStripMenuItem = Me._FileToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property FromDownloadedFilesToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._FromDownloadedFilesToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.FromDownloadedFilesToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._FromDownloadedFilesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._FromDownloadedFilesToolStripMenuItem = value
				toolStripMenuItem = Me._FromDownloadedFilesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property HelpToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._HelpToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.HelpToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._HelpToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._HelpToolStripMenuItem = value
				toolStripMenuItem = Me._HelpToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property InstallFromFileToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._InstallFromFileToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.InstallFromFileToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._InstallFromFileToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._InstallFromFileToolStripMenuItem = value
				toolStripMenuItem = Me._InstallFromFileToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property InstallFromReposToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._InstallFromReposToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.InstallFromReposToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._InstallFromReposToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._InstallFromReposToolStripMenuItem = value
				toolStripMenuItem = Me._InstallFromReposToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property InstallFromURLToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._InstallFromURLToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.InstallFromURLToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._InstallFromURLToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._InstallFromURLToolStripMenuItem = value
				toolStripMenuItem = Me._InstallFromURLToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property lblStatusBar As ToolStripStatusLabel

		Friend Overridable Property lstApps As ListViewEx
			Get
				stackVariable1 = Me._lstApps
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As SuperImpactor.ListViewEx)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lstApps_SelectedIndexChanged)
				Dim eventHandler1 As System.EventHandler = New System.EventHandler(AddressOf Me.lstApps_DoubleClick)
				Dim listViewEx As SuperImpactor.ListViewEx = Me._lstApps
				If (listViewEx IsNot Nothing) Then
					RemoveHandler listViewEx.SelectedIndexChanged,  eventHandler
					RemoveHandler listViewEx.DoubleClick,  eventHandler1
				End If
				Me._lstApps = value
				listViewEx = Me._lstApps
				If (listViewEx IsNot Nothing) Then
					AddHandler listViewEx.SelectedIndexChanged,  eventHandler
					AddHandler listViewEx.DoubleClick,  eventHandler1
				End If
			End Set
		End Property

		Friend Overridable Property MenuStrip1 As MenuStrip

		Friend Overridable Property RevokeCertificatesToolStripMenuItem As ToolStripMenuItem
			Get
				stackVariable1 = Me._RevokeCertificatesToolStripMenuItem
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.ToolStripMenuItem)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.RevokeCertificatesToolStripMenuItem_Click)
				Dim toolStripMenuItem As System.Windows.Forms.ToolStripMenuItem = Me._RevokeCertificatesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					RemoveHandler toolStripMenuItem.Click,  eventHandler
				End If
				Me._RevokeCertificatesToolStripMenuItem = value
				toolStripMenuItem = Me._RevokeCertificatesToolStripMenuItem
				If (toolStripMenuItem IsNot Nothing) Then
					AddHandler toolStripMenuItem.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property StatusStrip1 As StatusStrip

		Friend Overridable Property ToolsToolStripMenuItem As ToolStripMenuItem

		Friend Overridable Property txtAppSearch As TextBox
			Get
				stackVariable1 = Me._txtAppSearch
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.TextBox)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.txtAppSearch_TextChanged)
				Dim keyPressEventHandler As System.Windows.Forms.KeyPressEventHandler = New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.txtAppSearch_KeyPress)
				Dim textBox As System.Windows.Forms.TextBox = Me._txtAppSearch
				If (textBox IsNot Nothing) Then
					RemoveHandler textBox.TextChanged,  eventHandler
					RemoveHandler textBox.KeyPress,  keyPressEventHandler
				End If
				Me._txtAppSearch = value
				textBox = Me._txtAppSearch
				If (textBox IsNot Nothing) Then
					AddHandler textBox.TextChanged,  eventHandler
					AddHandler textBox.KeyPress,  keyPressEventHandler
				End If
			End Set
		End Property

		Friend Overridable Property WebBrowser1 As WebBrowser
			Get
				stackVariable1 = Me._WebBrowser1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.WebBrowser)
				Dim webBrowserNavigatingEventHandler As System.Windows.Forms.WebBrowserNavigatingEventHandler = New System.Windows.Forms.WebBrowserNavigatingEventHandler(AddressOf Me.WebBrowser1_Navigating)
				Dim webBrowser As System.Windows.Forms.WebBrowser = Me._WebBrowser1
				If (webBrowser IsNot Nothing) Then
					RemoveHandler webBrowser.Navigating,  webBrowserNavigatingEventHandler
				End If
				Me._WebBrowser1 = value
				webBrowser = Me._WebBrowser1
				If (webBrowser IsNot Nothing) Then
					AddHandler webBrowser.Navigating,  webBrowserNavigatingEventHandler
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Main_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub AboutToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Interaction.MsgBox("Copyright @2017 - TuanHa Jsc" & VbCrLf & "" & VbCrLf & "This program use: " & VbCrLf & "- libimobiledevice team: http://www.libimobiledevice.org/" & VbCrLf & "- Copyright (c) 1998-2017 The OpenSSL Project, Copyright (C) 1995-1998 Eric Young (eay@cryptsoft.com). All rights reserved." & VbCrLf & "- isign by Neil Kandalgaonkar", MsgBoxStyle.OkOnly, "About")
		End Sub

		Private Sub AppleAccountsManagerMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New AppleAccounts()).ShowDialog()
		End Sub

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.WebBrowser1.Visible = True
			Me.lstApps.Visible = False
		End Sub

		Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
			If ((New UpdateCydia()).UpdateApp()) Then
				Me.ReloadApps("")
				Interaction.MsgBox("Update all cydia completed!", MsgBoxStyle.OkOnly, Nothing)
			End If
		End Sub

		Private Sub CydiaReposManagerMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New CydiaRepoManager()).ShowDialog()
			Me.ReloadApps("")
		End Sub

		Private Sub DeleteAppIDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New AppIdDelete()).ShowDialog()
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

		Private Sub DownloadedFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New DownloadFiles()).ShowDialog()
		End Sub

		Private Sub FileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub FromDownloadedFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New DownloadFiles()).ShowDialog()
		End Sub

		Private Sub HelpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Process.Start("http://www.superimpactor.net/help")
		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim componentResourceManager As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
			Me.MenuStrip1 = New MenuStrip()
			Me.FileToolStripMenuItem = New ToolStripMenuItem()
			Me.InstallFromURLToolStripMenuItem = New ToolStripMenuItem()
			Me.InstallFromReposToolStripMenuItem = New ToolStripMenuItem()
			Me.InstallFromFileToolStripMenuItem = New ToolStripMenuItem()
			Me.FromDownloadedFilesToolStripMenuItem = New ToolStripMenuItem()
			Me.EditToolStripMenuItem = New ToolStripMenuItem()
			Me.CydiaReposManagerMenuItem = New ToolStripMenuItem()
			Me.AppleAccountsManagerMenuItem = New ToolStripMenuItem()
			Me.DownloadedFilesToolStripMenuItem = New ToolStripMenuItem()
			Me.ToolsToolStripMenuItem = New ToolStripMenuItem()
			Me.RevokeCertificatesToolStripMenuItem = New ToolStripMenuItem()
			Me.DeleteAppIDToolStripMenuItem = New ToolStripMenuItem()
			Me.AboutToolStripMenuItem = New ToolStripMenuItem()
			Me.HelpToolStripMenuItem = New ToolStripMenuItem()
			Me.AboutToolStripMenuItem1 = New ToolStripMenuItem()
			Me.cmdHot = New Button()
			Me.txtAppSearch = New TextBox()
			Me.Label1 = New Label()
			Me.cmdUpdate = New Button()
			Me.WebBrowser1 = New WebBrowser()
			Me.StatusStrip1 = New StatusStrip()
			Me.lblStatusBar = New ToolStripStatusLabel()
			Me.lstApps = New ListViewEx()
			Me.MenuStrip1.SuspendLayout()
			Me.StatusStrip1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.MenuStrip1.Items.AddRange(New ToolStripItem() { Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem })
			Me.MenuStrip1.Location = New Point(0, 0)
			Me.MenuStrip1.Name = "MenuStrip1"
			Me.MenuStrip1.Size = New System.Drawing.Size(474, 24)
			Me.MenuStrip1.TabIndex = 0
			Me.MenuStrip1.Text = "MenuStrip1"
			Me.FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.InstallFromURLToolStripMenuItem, Me.InstallFromReposToolStripMenuItem, Me.InstallFromFileToolStripMenuItem, Me.FromDownloadedFilesToolStripMenuItem })
			Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
			Me.FileToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
			Me.FileToolStripMenuItem.Text = "Install IPA"
			Me.InstallFromURLToolStripMenuItem.Name = "InstallFromURLToolStripMenuItem"
			Me.InstallFromURLToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
			Me.InstallFromURLToolStripMenuItem.Text = "From URL"
			Me.InstallFromReposToolStripMenuItem.Name = "InstallFromReposToolStripMenuItem"
			Me.InstallFromReposToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
			Me.InstallFromReposToolStripMenuItem.Text = "From Repos"
			Me.InstallFromFileToolStripMenuItem.Name = "InstallFromFileToolStripMenuItem"
			Me.InstallFromFileToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
			Me.InstallFromFileToolStripMenuItem.Text = "From File"
			Me.FromDownloadedFilesToolStripMenuItem.Name = "FromDownloadedFilesToolStripMenuItem"
			Me.FromDownloadedFilesToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
			Me.FromDownloadedFilesToolStripMenuItem.Text = "From Downloaded Files"
			Me.EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.CydiaReposManagerMenuItem, Me.AppleAccountsManagerMenuItem, Me.DownloadedFilesToolStripMenuItem })
			Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
			Me.EditToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
			Me.EditToolStripMenuItem.Text = "Setting"
			Me.CydiaReposManagerMenuItem.Name = "CydiaReposManagerMenuItem"
			Me.CydiaReposManagerMenuItem.Size = New System.Drawing.Size(148, 22)
			Me.CydiaReposManagerMenuItem.Text = "Cydia Repos"
			Me.AppleAccountsManagerMenuItem.Name = "AppleAccountsManagerMenuItem"
			Me.AppleAccountsManagerMenuItem.Size = New System.Drawing.Size(148, 22)
			Me.AppleAccountsManagerMenuItem.Text = "Apple Accounts"
			Me.DownloadedFilesToolStripMenuItem.Name = "DownloadedFilesToolStripMenuItem"
			Me.DownloadedFilesToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
			Me.DownloadedFilesToolStripMenuItem.Text = "Download Files"
			Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.RevokeCertificatesToolStripMenuItem, Me.DeleteAppIDToolStripMenuItem })
			Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
			Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
			Me.ToolsToolStripMenuItem.Text = "Tools"
			Me.RevokeCertificatesToolStripMenuItem.Name = "RevokeCertificatesToolStripMenuItem"
			Me.RevokeCertificatesToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
			Me.RevokeCertificatesToolStripMenuItem.Text = "Revoke Certificates"
			Me.DeleteAppIDToolStripMenuItem.Name = "DeleteAppIDToolStripMenuItem"
			Me.DeleteAppIDToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
			Me.DeleteAppIDToolStripMenuItem.Text = "Delete App ID"
			Me.AboutToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { Me.HelpToolStripMenuItem, Me.AboutToolStripMenuItem1 })
			Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
			Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
			Me.AboutToolStripMenuItem.Text = "Help"
			Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
			Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
			Me.HelpToolStripMenuItem.Text = "Help"
			Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
			Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
			Me.AboutToolStripMenuItem1.Text = "About"
			Me.cmdHot.Location = New Point(302, 33)
			Me.cmdHot.Name = "cmdHot"
			Me.cmdHot.Size = New System.Drawing.Size(66, 25)
			Me.cmdHot.TabIndex = 2
			Me.cmdHot.Text = "Hot Apps"
			Me.cmdHot.UseVisualStyleBackColor = True
			Me.txtAppSearch.Location = New Point(76, 35)
			Me.txtAppSearch.Name = "txtAppSearch"
			Me.txtAppSearch.Size = New System.Drawing.Size(220, 20)
			Me.txtAppSearch.TabIndex = 3
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(10, 38)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(63, 13)
			Me.Label1.TabIndex = 4
			Me.Label1.Text = "App Search"
			Me.cmdUpdate.Enabled = False
			Me.cmdUpdate.Location = New Point(374, 33)
			Me.cmdUpdate.Name = "cmdUpdate"
			Me.cmdUpdate.Size = New System.Drawing.Size(88, 25)
			Me.cmdUpdate.TabIndex = 6
			Me.cmdUpdate.Text = "Refresh Repos"
			Me.cmdUpdate.UseVisualStyleBackColor = True
			Me.WebBrowser1.Location = New Point(12, 240)
			Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
			Me.WebBrowser1.Name = "WebBrowser1"
			Me.WebBrowser1.Size = New System.Drawing.Size(449, 467)
			Me.WebBrowser1.TabIndex = 7
			Me.StatusStrip1.Items.AddRange(New ToolStripItem() { Me.lblStatusBar })
			Me.StatusStrip1.Location = New Point(0, 538)
			Me.StatusStrip1.Name = "StatusStrip1"
			Me.StatusStrip1.Size = New System.Drawing.Size(474, 22)
			Me.StatusStrip1.TabIndex = 8
			Me.StatusStrip1.Text = "StatusStrip1"
			Me.lblStatusBar.Name = "lblStatusBar"
			Me.lblStatusBar.Size = New System.Drawing.Size(111, 17)
			Me.lblStatusBar.Text = "ToolStripStatusLabel1"
			Me.lstApps.BackColor = Color.White
			Me.lstApps.FullRowSelect = True
			Me.lstApps.Location = New Point(13, 68)
			Me.lstApps.Name = "lstApps"
			Me.lstApps.OwnerDraw = True
			Me.lstApps.Size = New System.Drawing.Size(449, 467)
			Me.lstApps.TabIndex = 5
			Me.lstApps.UseCompatibleStateImageBehavior = False
			Me.lstApps.View = View.Details
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(474, 560)
			MyBase.Controls.Add(Me.StatusStrip1)
			MyBase.Controls.Add(Me.WebBrowser1)
			MyBase.Controls.Add(Me.cmdUpdate)
			MyBase.Controls.Add(Me.lstApps)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtAppSearch)
			MyBase.Controls.Add(Me.cmdHot)
			MyBase.Controls.Add(Me.MenuStrip1)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = DirectCast(componentResourceManager.GetObject("$this.Icon"), System.Drawing.Icon)
			MyBase.MainMenuStrip = Me.MenuStrip1
			MyBase.MaximizeBox = False
			MyBase.Name = "Main"
			Me.Text = "Super Impactor"
			Me.MenuStrip1.ResumeLayout(False)
			Me.MenuStrip1.PerformLayout()
			Me.StatusStrip1.ResumeLayout(False)
			Me.StatusStrip1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub InstallFromFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog() With
			{
				.InitialDirectory = "c:\\",
				.Filter = "IPA Files (*.ipa)|*.ipa|All files (*.*)|*.*",
				.FilterIndex = 2,
				.RestoreDirectory = True
			}
			If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
				Dim install As SuperImpactor.Install = New SuperImpactor.Install()
				install.installFromFile(openFileDialog.FileName, "", "")
			End If
		End Sub

		Private Sub InstallFromReposToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New CydiaRepoManager()).ShowDialog()
		End Sub

		Private Sub InstallFromURLToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New URLInstall()).ShowDialog()
		End Sub

		Private Sub lstApps_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim tag As ExtraData = DirectCast(Me.lstApps.SelectedItems(0).Tag, ExtraData)
			Dim appDetail As SuperImpactor.AppDetail = New SuperImpactor.AppDetail()
			appDetail.showApp(tag.AppDetailObj)
		End Sub

		Private Sub lstApps_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Try
					AppConst.logger = LogManager.GetLogger("SuperImpactor")
					AppConst.logger.Info("Start")
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
			End Try
			Try
				Try
					Me.WebBrowser1.Url = New Uri("https://www.iphonecake.com")
					Me.WebBrowser1.ScriptErrorsSuppressed = True
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					Interaction.MsgBox(exception1.Message, MsgBoxStyle.OkOnly, Nothing)
					ProjectData.ClearProjectError()
				End Try
			Finally
			End Try
			AppConst.m_rootPath = String.Concat(Application.StartupPath, "\..\..\")
			AppConst.m_localTmp = Common.GetTempFolder()
			If (Not File.Exists(String.Concat(AppConst.m_rootPath, "\iaidb.sqlite"))) Then
				Interaction.MsgBox("Application error! Please install again!", MsgBoxStyle.OkOnly, "Error")
				ProjectData.EndApp()
			End If
			AppConst.m_dbConnection = New SQLiteConnection(String.Concat("Data Source=", AppConst.m_rootPath, "\iaidb.sqlite;Version=3;"))
			AppConst.m_dbConnection.Open()
			Me.SetListViewSpacing(Me.lstApps, 16, 16)
			AppConst.m_lstCydiaRepos = Database.GetCydiaRepos(True)
			Dim num As Integer = 0
			Do
				AppConst.m_randomKey = String.Concat(AppConst.m_randomKey, Char.ConvertFromUtf32(num * 2 + 64))
				num = num + 1
			Loop While num <= 16
			Me.ReloadApps("")
		End Sub

		Private Sub ReloadApps(Optional ByVal search As String = "")
			Dim str As String
			Try
				str = If(Operators.CompareString(search, "", False) <> 0, String.Concat("select * from list_app where name like '%", search, "%' order by name"), "select * from list_app order by name")
				Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand(str, AppConst.m_dbConnection)).ExecuteReader()
				Me.lstApps.Clear()
				Me.lstApps.Columns.Add("Apps", MyBase.Width - 30)
				Dim webClient As System.Net.WebClient = New System.Net.WebClient()
				While sQLiteDataReader.Read()
					Dim extraDatum As ExtraData = New ExtraData() With
					{
						.DescText = Conversions.ToString(sQLiteDataReader.get_Item("description")),
						.HeaderText = Conversions.ToString(sQLiteDataReader.get_Item("name")),
						.MinorText = Conversions.ToString(Operators.AddObject(Operators.AddObject(String.Concat("from ", Strings.Trim(AppConst.m_lstCydiaRepos(Conversions.ToInteger(sQLiteDataReader.get_Item("cydia_repos")))), " ["), sQLiteDataReader.get_Item("section")), "]")),
						.AppDetailObj = New AppInfos()
					}
					Dim appDetailObj As AppInfos = extraDatum.AppDetailObj
					appDetailObj.Icon = sQLiteDataReader.get_Item("icon").ToString()
					appDetailObj.Architecture = sQLiteDataReader.get_Item("arch").ToString()
					appDetailObj.Author = sQLiteDataReader.get_Item("author").ToString()
					appDetailObj.Depends = sQLiteDataReader.get_Item("depends").ToString()
					appDetailObj.Description = sQLiteDataReader.get_Item("description").ToString()
					appDetailObj.Filename = sQLiteDataReader.get_Item("filename").ToString()
					appDetailObj.Homepage = sQLiteDataReader.get_Item("homepage").ToString()
					appDetailObj.Name = sQLiteDataReader.get_Item("name").ToString()
					appDetailObj.Package = sQLiteDataReader.get_Item("package").ToString()
					appDetailObj.Section = sQLiteDataReader.get_Item("section").ToString()
					appDetailObj.Size = sQLiteDataReader.get_Item("size").ToString()
					appDetailObj.Version = sQLiteDataReader.get_Item("version").ToString()
					appDetailObj = Nothing
					If (Not (Operators.CompareString(extraDatum.AppDetailObj.Icon, "", False) <> 0 And extraDatum.AppDetailObj.Icon.StartsWith("http"))) Then
						extraDatum.MainImage = New Bitmap(String.Concat(AppConst.m_rootPath, "\res\/apptype_tweak.png"))
					Else
						extraDatum.MainImage = DirectCast(Image.FromStream(New MemoryStream(webClient.DownloadData(extraDatum.AppDetailObj.Icon))), Bitmap)
					End If
					Me.lstApps.Items.Add("").Tag = extraDatum
				End While
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub RevokeCertificatesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New CertificateDelete()).ShowDialog()
		End Sub

		<DllImport("user32", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=True)>
		Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		End Function

		Public Sub SetListViewSpacing(ByVal lst As ListView, ByVal x As Integer, ByVal y As Integer)
			Main.SendMessage(lst.Handle, 4149, 0, x * 65536 + y)
		End Sub

		Private Sub ThreadTask()
		End Sub

		Private Sub txtAppSearch_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
			If (Operators.CompareString(Conversions.ToString(e.KeyChar), "", False) = 0) Then
				Me.cmdHot.PerformClick()
			End If
		End Sub

		Private Sub txtAppSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.WebBrowser1.Visible = False
			Me.lstApps.Visible = True
			Me.ReloadApps(Me.txtAppSearch.Text)
		End Sub

		Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs)
			If (Interaction.MsgBox(String.Concat("You are trying to go to:", e.Url.ToString(), "Cancel Navigate?"), MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes) Then
				e.Cancel = True
			End If
		End Sub

		Public Delegate Sub InvokeDelegate()
	End Class
End Namespace