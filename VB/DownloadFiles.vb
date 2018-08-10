Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class DownloadFiles
		Inherits Form
		Private components As IContainer

		Friend Overridable Property Button1 As Button
			Get
				stackVariable1 = Me._Button1
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button1_Click)
				Dim button As System.Windows.Forms.Button = Me._Button1
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdClose As Button
			Get
				stackVariable1 = Me._cmdClose
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdClose_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdClose
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdClose = value
				button = Me._cmdClose
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdRemove As Button
			Get
				stackVariable1 = Me._cmdRemove
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdRemove_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdRemove
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdRemove = value
				button = Me._cmdRemove
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property cmdRemoveAll As Button
			Get
				stackVariable1 = Me._cmdRemoveAll
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdRemoveAll_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdRemoveAll
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdRemoveAll = value
				button = Me._cmdRemoveAll
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Friend Overridable Property Label1 As Label

		Friend Overridable Property lstCydia As ListView

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.DownloadFiles_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.lstCydia.SelectedItems.Count <> 0) Then
				Dim item As ListViewItem = Me.lstCydia.SelectedItems(0)
				Dim install As SuperImpactor.Install = New SuperImpactor.Install()
				install.installFromFile(String.Concat(AppConst.m_rootPath, "\download\", item.SubItems(0).Text), "", "")
			Else
				Interaction.MsgBox("Please select file to install", MsgBoxStyle.OkOnly, Nothing)
			End If
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.lstCydia.SelectedItems.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
					File.Delete(String.Concat(AppConst.m_rootPath, "\download\", current.SubItems(0).Text))
					current.Remove()
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		Private Sub cmdRemoveAll_Click(ByVal sender As Object, ByVal e As EventArgs)
			Common.DeleteFilesFromFolder(String.Concat(AppConst.m_rootPath, "\download\"))
			Me.lstCydia.Clear()
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

		Private Sub DownloadFiles_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String
			Dim num As Double
			Me.lstCydia.Clear()
			Me.lstCydia.View = View.Details
			Me.lstCydia.Columns.Add("Name", Me.lstCydia.Width - 70, HorizontalAlignment.Left)
			Me.lstCydia.Columns.Add("Size")
			Dim files As String() = Directory.GetFiles(String.Concat(AppConst.m_rootPath, "\download\"))
			Dim num1 As Integer = Information.UBound(files, 1)
			For i As Integer = 0 To num1 Step 1
				Dim listViewItem As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem()
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(files(i))
				listViewItem.Text = fileInfo.Name
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
				listViewItem.SubItems.Add(str)
				Me.lstCydia.Items.Add(listViewItem)
			Next

		End Sub

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.cmdClose = New Button()
			Me.cmdRemove = New Button()
			Me.cmdRemoveAll = New Button()
			Me.Label1 = New Label()
			Me.lstCydia = New ListView()
			Me.Button1 = New Button()
			MyBase.SuspendLayout()
			Me.cmdClose.Location = New Point(432, 361)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(104, 25)
			Me.cmdClose.TabIndex = 9
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.cmdRemove.Location = New Point(432, 61)
			Me.cmdRemove.Name = "cmdRemove"
			Me.cmdRemove.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemove.TabIndex = 8
			Me.cmdRemove.Text = "Remove"
			Me.cmdRemove.UseVisualStyleBackColor = True
			Me.cmdRemoveAll.Location = New Point(432, 94)
			Me.cmdRemoveAll.Name = "cmdRemoveAll"
			Me.cmdRemoveAll.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemoveAll.TabIndex = 7
			Me.cmdRemoveAll.Text = "Remove All"
			Me.cmdRemoveAll.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(12, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(110, 13)
			Me.Label1.TabIndex = 6
			Me.Label1.Text = "List of Download Files"
			Me.lstCydia.FullRowSelect = True
			Me.lstCydia.GridLines = True
			Me.lstCydia.HideSelection = False
			Me.lstCydia.Location = New Point(12, 28)
			Me.lstCydia.Name = "lstCydia"
			Me.lstCydia.Size = New System.Drawing.Size(405, 358)
			Me.lstCydia.TabIndex = 5
			Me.lstCydia.UseCompatibleStateImageBehavior = False
			Me.Button1.Location = New Point(432, 28)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New System.Drawing.Size(104, 25)
			Me.Button1.TabIndex = 10
			Me.Button1.Text = "Install"
			Me.Button1.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(548, 398)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdRemove)
			MyBase.Controls.Add(Me.cmdRemoveAll)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.lstCydia)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "DownloadFiles"
			Me.Text = "DownloadFiles"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub
	End Class
End Namespace