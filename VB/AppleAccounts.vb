Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class AppleAccounts
		Inherits Form
		Private components As IContainer

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
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.AppleAccounts_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub AppleAccounts_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.LoadAccounts()
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.lstCydia.SelectedItems.Count <= 0) Then
				Interaction.MsgBox("Select account to remove", MsgBoxStyle.OkOnly, Nothing)
			Else
				Dim item As ListViewItem = Me.lstCydia.SelectedItems(0)
				Database.DeleteAccount(item.SubItems(0).Text)
				Me.LoadAccounts()
			End If
		End Sub

		Private Sub cmdRemoveAll_Click(ByVal sender As Object, ByVal e As EventArgs)
			Database.DeleteAccounts()
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

		<DebuggerStepThrough>
		Private Sub InitializeComponent()
			Me.cmdClose = New Button()
			Me.cmdRemove = New Button()
			Me.cmdRemoveAll = New Button()
			Me.Label1 = New Label()
			Me.lstCydia = New ListView()
			MyBase.SuspendLayout()
			Me.cmdClose.Location = New Point(262, 357)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(104, 25)
			Me.cmdClose.TabIndex = 15
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.cmdRemove.Location = New Point(262, 24)
			Me.cmdRemove.Name = "cmdRemove"
			Me.cmdRemove.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemove.TabIndex = 14
			Me.cmdRemove.Text = "Remove"
			Me.cmdRemove.UseVisualStyleBackColor = True
			Me.cmdRemoveAll.Location = New Point(262, 57)
			Me.cmdRemoveAll.Name = "cmdRemoveAll"
			Me.cmdRemoveAll.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemoveAll.TabIndex = 13
			Me.cmdRemoveAll.Text = "Remove All"
			Me.cmdRemoveAll.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(12, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(117, 13)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "List of Stored Accounts"
			Me.lstCydia.FullRowSelect = True
			Me.lstCydia.GridLines = True
			Me.lstCydia.HideSelection = False
			Me.lstCydia.Location = New Point(12, 24)
			Me.lstCydia.Name = "lstCydia"
			Me.lstCydia.Size = New System.Drawing.Size(239, 358)
			Me.lstCydia.TabIndex = 11
			Me.lstCydia.UseCompatibleStateImageBehavior = False
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(377, 393)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdRemove)
			MyBase.Controls.Add(Me.cmdRemoveAll)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.lstCydia)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "AppleAccounts"
			Me.Text = "Stored Apple Accounts"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Sub LoadAccounts()
			Dim accounts As Dictionary(Of String, String) = Database.GetAccounts()
			Me.lstCydia.Clear()
			Me.lstCydia.View = View.Details
			Me.lstCydia.Columns.Add("Apple Id")
			Me.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
			Me.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
			Dim count As Integer = accounts.Keys.Count - 1
			For i As Integer = 0 To count Step 1
				Dim listViewItem As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem() With
				{
					.Text = accounts.Keys.ElementAt(i)
				}
				listViewItem.SubItems.Add(accounts.Keys.ElementAt(i))
				Me.lstCydia.Items.Add(listViewItem)
			Next

		End Sub
	End Class
End Namespace