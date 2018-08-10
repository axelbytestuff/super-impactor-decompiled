Imports ICSharpCode.SharpZipLib.BZip2
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SuperImpactor
	<DesignerGenerated>
	Public Class CydiaRepoManager
		Inherits Form
		Private components As IContainer

		Friend Overridable Property cmdAdd As Button
			Get
				stackVariable1 = Me._cmdAdd
				Return stackVariable1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Windows.Forms.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.cmdAdd_Click)
				Dim button As System.Windows.Forms.Button = Me._cmdAdd
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._cmdAdd = value
				button = Me._cmdAdd
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

		Friend Overridable Property Label1 As Label

		Friend Overridable Property lstCydia As ListView

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.CydiaRepoManager_Load)
			Me.InitializeComponent()
		End Sub

		Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim str As String = Interaction.InputBox("Enter URL of Cydia Repos", "Add Cydia Repos", "", -1, -1)
			If (Operators.CompareString(Strings.Trim(str), "", False) <> 0) Then
				If (Not str.StartsWith("http")) Then
					str = String.Concat("http://", str)
				End If
				Dim count As Integer = Me.lstCydia.Items.Count - 1
				Dim num As Integer = 0
				While num <= count
					If (Operators.CompareString(Me.lstCydia.Items(num).SubItems(1).Text, str, False) <> 0) Then
						num = num + 1
					Else
						Interaction.MsgBox("Cydia existed!", MsgBoxStyle.OkOnly, "Error")
						Return
					End If
				End While
				File.Delete("Release.txt")
				Dim str1 As String = "Noname"
				Try
					Dim webClient As System.Net.WebClient = New System.Net.WebClient()
					webClient.DownloadFile(String.Concat(str, "/Release"), "Release.txt")
					Dim strArrays As String() = File.ReadAllLines("Release.txt")
					Dim num1 As Integer = Information.LBound(strArrays, 1)
					Dim num2 As Integer = Information.UBound(strArrays, 1)
					Dim num3 As Integer = num1
					While num3 <= num2
						If (Not strArrays(num3).StartsWith("Label:")) Then
							num3 = num3 + 1
						Else
							str1 = strArrays(num3).Substring(6)
							Exit While
						End If
					End While
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
				Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("INSERT INTO cydia_repos(name, path) VALUES(@name, @path)", AppConst.m_dbConnection)
				Dim parameters As SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				parameters.AddWithValue("@name", str1)
				parameters.AddWithValue("@path", str)
				parameters = Nothing
				sQLiteCommand.ExecuteNonQuery()
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.LoadCydiaRepos(str))
				CydiaRepoManager.LoadPackages(str)
				If (File.Exists("Packages")) Then
					CydiaRepoManager.ParsePackages(Conversions.ToInteger(objectValue), Nothing, Nothing, "")
				End If
			Else
				Interaction.MsgBox("Incorrect URL", MsgBoxStyle.OkOnly, "Error")
			End If
		End Sub

		Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.lstCydia.SelectedItems.Count > 0) Then
				Dim item As ListViewItem = Me.lstCydia.SelectedItems(0)
				Dim str As String = String.Concat("select * from cydia_repos WHERE path='", item.SubItems(1).Text, "'")
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

		Private Sub CydiaRepoManager_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.LoadCydiaRepos("")
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
			Me.lstCydia = New ListView()
			Me.Label1 = New Label()
			Me.cmdAdd = New Button()
			Me.cmdRemove = New Button()
			Me.cmdClose = New Button()
			MyBase.SuspendLayout()
			Me.lstCydia.FullRowSelect = True
			Me.lstCydia.GridLines = True
			Me.lstCydia.HideSelection = False
			Me.lstCydia.Location = New Point(8, 30)
			Me.lstCydia.MultiSelect = False
			Me.lstCydia.Name = "lstCydia"
			Me.lstCydia.Size = New System.Drawing.Size(288, 345)
			Me.lstCydia.TabIndex = 0
			Me.lstCydia.UseCompatibleStateImageBehavior = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Point(8, 11)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(98, 13)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "List of Cydia Repos"
			Me.cmdAdd.Location = New Point(310, 31)
			Me.cmdAdd.Name = "cmdAdd"
			Me.cmdAdd.Size = New System.Drawing.Size(106, 24)
			Me.cmdAdd.TabIndex = 2
			Me.cmdAdd.Text = "Add"
			Me.cmdAdd.UseVisualStyleBackColor = True
			Me.cmdRemove.Location = New Point(310, 64)
			Me.cmdRemove.Name = "cmdRemove"
			Me.cmdRemove.Size = New System.Drawing.Size(104, 25)
			Me.cmdRemove.TabIndex = 3
			Me.cmdRemove.Text = "Remove"
			Me.cmdRemove.UseVisualStyleBackColor = True
			Me.cmdClose.Location = New Point(310, 350)
			Me.cmdClose.Name = "cmdClose"
			Me.cmdClose.Size = New System.Drawing.Size(104, 25)
			Me.cmdClose.TabIndex = 4
			Me.cmdClose.Text = "Close"
			Me.cmdClose.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
			MyBase.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New System.Drawing.Size(430, 383)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.cmdClose)
			MyBase.Controls.Add(Me.cmdRemove)
			MyBase.Controls.Add(Me.cmdAdd)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.lstCydia)
			MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "CydiaRepoManager"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			Me.Text = "Cydia Repos Manager"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		Private Function LoadCydiaRepos(Optional ByVal cydiaReposName As String = "") As Object
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader()
			Me.lstCydia.Clear()
			Me.lstCydia.View = View.Details
			Me.lstCydia.Columns.Add("Name")
			Me.lstCydia.Columns.Add("Cydia URL")
			Me.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
			Me.lstCydia.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
			Dim [integer] As Integer = -1
			While sQLiteDataReader.Read()
				Dim listViewItem As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem() With
				{
					.Text = Conversions.ToString(sQLiteDataReader.get_Item("name"))
				}
				NewLateBinding.LateCall(listViewItem.SubItems, Nothing, "Add", New Object() { sQLiteDataReader.get_Item("path") }, Nothing, Nothing, Nothing, True)
				Me.lstCydia.Items.Add(listViewItem)
				If (Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("path"), cydiaReposName, False)) Then
					[integer] = Conversions.ToInteger(sQLiteDataReader.get_Item("id"))
				End If
			End While
			Return [integer]
		End Function

		Public Shared Sub LoadPackages(ByVal cydiaRepos As String)
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
					ProjectData.ClearProjectError()
				End Try
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Shared Sub ParsePackages(ByVal cydiaId As Integer, Optional ByVal frm As UpdateCydia = Nothing, Optional ByVal fn As Object = Nothing, Optional ByVal cydiaUrl As String = "")
			Dim str As String = File.ReadAllText("Packages")
			Dim strArrays As String() = str.Split(New String() { "Package:" }, StringSplitOptions.RemoveEmptyEntries)
			Dim str1 As String = "INSERT INTO list_app(cydia_repos,package,version,section,depends,arch,filename,size,icon,description,name,author,homepage) " & VbCrLf & "                                                VALUES(@cydia_repos,@package,@version,@section,@depends,@arch,@filename,@size,@icon,@description,@name,@author,@homepage)"
			Dim sQLiteTransaction As System.Data.SQLite.SQLiteTransaction = AppConst.m_dbConnection.BeginTransaction()
			Dim num As Integer = Information.LBound(strArrays, 1)
			Dim num1 As Integer = Information.UBound(strArrays, 1)
			Dim num2 As Integer = num
			Do
				Dim strArrays1 As String() = strArrays(num2).Split(New Char() { Strings.ChrW(10) })
				Dim appInfo As AppInfos = New AppInfos() With
				{
					.Package = Strings.Trim(strArrays1(0))
				}
				Dim num3 As Integer = Information.UBound(strArrays1, 1)
				Dim num4 As Integer = 1
				Do
					Dim str2 As String = strArrays1(num4)
					If (str2.StartsWith("Section:")) Then
						appInfo.Section = Strings.Trim(strArrays1(num4).Substring(8))
					ElseIf (str2.StartsWith("Version:")) Then
						appInfo.Version = Strings.Trim(strArrays1(num4).Substring(8))
					ElseIf (str2.StartsWith("Depends:")) Then
						appInfo.Depends = Strings.Trim(strArrays1(num4).Substring(8))
					ElseIf (str2.StartsWith("Architecture:")) Then
						appInfo.Architecture = Strings.Trim(strArrays1(num4).Substring(13))
					ElseIf (str2.StartsWith("Filename:")) Then
						appInfo.Filename = Strings.Trim(strArrays1(num4).Substring(9))
						If (Not appInfo.Filename.StartsWith("http")) Then
							appInfo.Filename = String.Concat(cydiaUrl, "/", appInfo.Filename)
						End If
					ElseIf (str2.StartsWith("Size:")) Then
						appInfo.Size = Strings.Trim(strArrays1(num4).Substring(5))
					ElseIf (str2.StartsWith("Icon:")) Then
						appInfo.Icon = Strings.Trim(strArrays1(num4).Substring(5))
					ElseIf (str2.StartsWith("Description:")) Then
						appInfo.Description = Strings.Trim(strArrays1(num4).Substring(12))
					ElseIf (str2.StartsWith("Name:")) Then
						appInfo.Name = Strings.Trim(strArrays1(num4).Substring(5))
					ElseIf (str2.StartsWith("Author:")) Then
						appInfo.Author = Strings.Trim(strArrays1(num4).Substring(7))
					ElseIf (str2.StartsWith("Homepage:")) Then
						appInfo.Homepage = Strings.Trim(strArrays1(num4).Substring(9))
					End If
					num4 = num4 + 1
				Loop While num4 <= num3
				Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand(str1, AppConst.m_dbConnection)
				Dim parameters As SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				parameters.AddWithValue("@cydia_repos", cydiaId)
				parameters.AddWithValue("@package", appInfo.Package)
				parameters.AddWithValue("@version", appInfo.Version)
				parameters.AddWithValue("@section", appInfo.Section)
				parameters.AddWithValue("@depends", appInfo.Depends)
				parameters.AddWithValue("@arch", appInfo.Architecture)
				parameters.AddWithValue("@filename", appInfo.Filename)
				parameters.AddWithValue("@size", appInfo.Size)
				parameters.AddWithValue("@icon", appInfo.Icon)
				parameters.AddWithValue("@description", appInfo.Description)
				parameters.AddWithValue("@name", appInfo.Name)
				parameters.AddWithValue("@author", appInfo.Author)
				parameters.AddWithValue("@homepage", appInfo.Homepage)
				parameters = Nothing
				sQLiteCommand.ExecuteNonQuery()
				If (num2 Mod 10 = 0) Then
					If (frm IsNot Nothing) Then
						frm.Invoke(DirectCast(fn, [Delegate]), New Object() { "", CInt(Math.Round(CDbl((num2 * 100)) / CDbl(Information.UBound(strArrays, 1)))) })
					End If
				End If
				num2 = num2 + 1
			Loop While num2 <= num1
			sQLiteTransaction.Commit()
		End Sub
	End Class
End Namespace