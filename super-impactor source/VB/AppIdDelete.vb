Imports Claunia.PropertyList
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class AppIdDelete
		Inherits Form
		Private components As IContainer

		Private lstAcc As Dictionary(Of String, String)

		Private teamId As String

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

		Friend Overridable Property cmdGetCert As Button
			Get
				stackVariable1 = Me._cmdGetCert
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdGetCert_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdGetCert
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdGetCert = value
				button = Me._cmdGetCert
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

		Friend Overridable Property Label2 As Label

		Friend Overridable Property Label3 As Label

		Friend Overridable Property lstCydia As ListView

		Friend Overridable Property txtPassword As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.CertificateDelete_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub CertificateDelete_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As Dictionary(Of String, String).Enumerator = New Dictionary(Of String, String).Enumerator()
			Me.lstAcc = Database.GetAccounts()
			Try
				enumerator = Me.lstAcc.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As KeyValuePair(Of String, String) = enumerator.Current
					Me.cmbAppleId.Items.Add(current.Key)
				End While
			Finally
				DirectCast(enumerator, IDisposable).Dispose()
			End Try
		End Sub

		Private Sub cmbAppleId_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.txtPassword.Text = Me.lstAcc(Me.cmbAppleId.Text)
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdGetCert_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Operators.CompareString(Me.cmbAppleId.Text.Trim(), "", False) = 0) Then
				Interaction.MsgBox("No appleId!", MsgBoxStyle.OkOnly, "Error")
			ElseIf (Operators.CompareString(Me.txtPassword.Text, "", False) <> 0) Then
				Me.cmdGetCert.Enabled = False
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.LoadApps())
				Me.cmdGetCert.Enabled = True
				If (Operators.ConditionalCompareObjectNotEqual(objectValue, "", False)) Then
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(objectValue), MsgBoxStyle.OkOnly, "Warning")
				End If
			Else
				Interaction.MsgBox("No password!", MsgBoxStyle.OkOnly, "Error")
			End If
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.lstCydia.SelectedItems.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
					AppleService.deleteAppId(current.SubItems(1).Text, Me.teamId)
					current.Remove()
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		Private Sub cmdRemoveAll_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.lstCydia.Items.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As ListViewItem = DirectCast(enumerator.Current, ListViewItem)
					AppleService.deleteAppId(current.SubItems(1).Text, Me.teamId)
					current.Remove()
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
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
			Me.cmdRemoveAll = New Button()
			Me.cmdGetCert = New Button()
			Me.cmdClose = New Button()
			Me.cmdRemove = New Button()
			Me.Label1 = New Label()
			Me.lstCydia = New ListView()
			Me.Label3 = New Label()
			Me.Label2 = New Label()
			Me.txtPassword = New TextBox()
			Me.cmbAppleId = New ComboBox()
			MyBase.SuspendLayout()
			Me.cmdRemoveAll.Location = New Point(289, 122)
			Me.cmdRemoveAll.Name = "cmdRemoveAll"
			Me.cmdRemoveAll.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemoveAll.TabIndex = 27
			Me.cmdRemoveAll.Text = "Delete All"
			Me.cmdRemoveAll.UseVisualStyleBackColor = True
			Me.cmdGetCert.Location = New Point(289, 6)
			Me.cmdGetCert.Name = "cmdGetCert"
			Me.cmdGetCert.Size = New System.Drawing.Size(106, 24)
			Me.cmdGetCert.TabIndex = 26
			Me.cmdGetCert.Text = "Get AppIds"
			Me.cmdGetCert.UseVisualStyleBackColor = True
			Me.cmdClose.Location = New Point(289, 287)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(104, 25)
			Me.cmdClose.TabIndex = 25
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			Me.cmdRemove.Location = New Point(289, 89)
			Me.cmdRemove.Name = "cmdRemove"
			Me.cmdRemove.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemove.TabIndex = 24
			Me.cmdRemove.Text = "Delete"
			Me.cmdRemove.UseVisualStyleBackColor = True
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(12, 70)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(71, 13)
			Me.Label1.TabIndex = 23
			Me.Label1.Text = "List of AppIds"
			Me.lstCydia.FullRowSelect = True
			Me.lstCydia.GridLines = True
			Me.lstCydia.HideSelection = False
			Me.lstCydia.Location = New Point(12, 89)
			Me.lstCydia.MultiSelect = False
			Me.lstCydia.Name = "lstCydia"
			Me.lstCydia.Size = New System.Drawing.Size(262, 224)
			Me.lstCydia.TabIndex = 22
			Me.lstCydia.UseCompatibleStateImageBehavior = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Point(11, 40)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(53, 13)
			Me.Label3.TabIndex = 21
			Me.Label3.Text = "Password"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Point(11, 9)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(46, 13)
			Me.Label2.TabIndex = 20
			Me.Label2.Text = "Apple Id"
			Me.txtPassword.Location = New Point(68, 38)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.Size = New System.Drawing.Size(206, 20)
			Me.txtPassword.TabIndex = 19
			Me.txtPassword.UseSystemPasswordChar = True
			Me.cmbAppleId.FormattingEnabled = True
			Me.cmbAppleId.Location = New Point(68, 6)
			Me.cmbAppleId.Name = "cmbAppleId"
			Me.cmbAppleId.Size = New System.Drawing.Size(206, 21)
			Me.cmbAppleId.TabIndex = 18
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(403, 323)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.cmdRemoveAll)
			MyBase.Controls.Add(Me.cmdGetCert)
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdRemove)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.lstCydia)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtPassword)
			MyBase.Controls.Add(Me.cmbAppleId)
			MyBase.Name = "AppIdDelete"
			Me.Text = "Delete AppId"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Function LoadApps() As Object
			Dim obj As Object
			Application.DoEvents()
			Dim nSDictionary As Claunia.PropertyList.NSDictionary = AppleService.login(Me.cmbAppleId.Text, Me.txtPassword.Text)
			If (nSDictionary.ContainsKey("myacinfo")) Then
				Dim str As String = nSDictionary.ObjectForKey("myacinfo").ToString()
				Application.DoEvents()
				nSDictionary = AppleService.listTeam(str)
				Me.teamId = ""
				If (nSDictionary.ContainsKey("teams")) Then
					Dim nSArray As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("teams"), Claunia.PropertyList.NSArray)
					If (nSArray.get_Count() > 0) Then
						Dim nSDictionary1 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray.ElementAt(0), Claunia.PropertyList.NSDictionary)
						If (nSDictionary1.ContainsKey("teamId")) Then
							Me.teamId = nSDictionary1.ObjectForKey("teamId").ToString()
						End If
					End If
				End If
				If (Operators.CompareString(Me.teamId, "", False) <> 0) Then
					Me.lstCydia.Clear()
					Me.lstCydia.Clear()
					Me.lstCydia.View = View.Details
					Me.lstCydia.Columns.Add("Name", 234)
					Me.lstCydia.Columns.Add("Id")
					Application.DoEvents()
					nSDictionary = AppleService.appIds(Me.teamId)
					Dim str1 As String = ""
					If (nSDictionary.ContainsKey("appIds")) Then
						Dim nSArray1 As Claunia.PropertyList.NSArray = DirectCast(nSDictionary.ObjectForKey("appIds"), Claunia.PropertyList.NSArray)
						Dim count As Integer = nSArray1.get_Count() - 1
						Dim num As Integer = 0
						Do
							Dim nSDictionary2 As Claunia.PropertyList.NSDictionary = DirectCast(nSArray1.ElementAt(num), Claunia.PropertyList.NSDictionary)
							If (nSDictionary2.ContainsKey("appIdId") And nSDictionary2.ContainsKey("name")) Then
								str1 = nSDictionary2.ObjectForKey("appIdId").ToString()
								Dim listViewItem As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem() With
								{
									.Text = nSDictionary2.ObjectForKey("name").ToString()
								}
								listViewItem.SubItems.Add(nSDictionary2.ObjectForKey("appIdId").ToString())
								Me.lstCydia.Items.Add(listViewItem)
							End If
							num = num + 1
						Loop While num <= count
						If (Me.lstCydia.Items.Count = 0) Then
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
	End Class
End Namespace