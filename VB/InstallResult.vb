Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class InstallResult
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

		Friend Overridable Property cmdDetail As Button
			Get
				stackVariable1 = Me._cmdDetail
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdDetail_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdDetail
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdDetail = value
				button = Me._cmdDetail
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

		Friend Overridable Property lblMessage As Label

		Friend Overridable Property txtDetail As TextBox

		Public Sub New()
			MyBase.New()
			Me.InitializeComponent()
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdDetail_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Height = Me.txtDetail.Height + Me.txtDetail.Top + 50
			Me.cmdDetail.Visible = False
		End Sub

		Private Sub cmdSupport_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim dialogResult As System.Windows.Forms.DialogResult = (New ReportBug()).ShowDialog()
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
			Me.lblMessage = New Label()
			Me.cmdClose = New Button()
			Me.cmdSupport = New Button()
			Me.cmdDetail = New Button()
			Me.txtDetail = New TextBox()
			MyBase.SuspendLayout()
			Me.lblMessage.AutoSize = True
			Me.lblMessage.Location = New Point(13, 24)
			Me.lblMessage.Name = "lblMessage"
			Me.lblMessage.Size = New System.Drawing.Size(0, 13)
			Me.lblMessage.TabIndex = 0
			Me.cmdClose.Location = New Point(399, 15)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(75, 23)
			Me.cmdClose.TabIndex = 1
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.cmdSupport.Location = New Point(399, 54)
			Me.cmdSupport.Name = "cmdSupport"
			Me.cmdSupport.Size = New System.Drawing.Size(75, 23)
			Me.cmdSupport.TabIndex = 2
			Me.cmdSupport.Text = "Support"
			Me.cmdSupport.UseVisualStyleBackColor = True
			Me.cmdDetail.Location = New Point(12, 54)
			Me.cmdDetail.Name = "cmdDetail"
			Me.cmdDetail.Size = New System.Drawing.Size(75, 23)
			Me.cmdDetail.TabIndex = 3
			Me.cmdDetail.Text = "Detail"
			Me.cmdDetail.UseVisualStyleBackColor = True
			Me.txtDetail.Location = New Point(12, 99)
			Me.txtDetail.Multiline = True
			Me.txtDetail.Name = "txtDetail"
			Me.txtDetail.ScrollBars = ScrollBars.Vertical
			Me.txtDetail.Size = New System.Drawing.Size(461, 81)
			Me.txtDetail.TabIndex = 4
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(485, 90)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.txtDetail)
			MyBase.Controls.Add(Me.cmdDetail)
			MyBase.Controls.Add(Me.cmdSupport)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.lblMessage)
			MyBase.Name = "InstallResult"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Install Result"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Public Sub showMessage(ByVal rs As String, ByVal detail As String)
			Me.lblMessage.Text = rs
			Me.txtDetail.Text = detail
			MyBase.ShowDialog()
		End Sub
	End Class
End Namespace