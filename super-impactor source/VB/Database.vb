Imports log4net
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Data.SQLite

Namespace SuperImpactor
	Public Class Database
		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Sub DeleteAccount(ByVal appId As String)
			Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("DELETE From account where appleId=@appleId", AppConst.m_dbConnection)
			sQLiteCommand.get_Parameters().AddWithValue("@appleId", appId)
			sQLiteCommand.ExecuteNonQuery()
		End Sub

		Public Shared Sub DeleteAccounts()
			Dim num As Integer = (New SQLiteCommand("DELETE From account", AppConst.m_dbConnection)).ExecuteNonQuery()
		End Sub

		Public Shared Function GetAccounts() As Dictionary(Of String, String)
			Dim strs As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand("select * from account", AppConst.m_dbConnection)).ExecuteReader()
			While sQLiteDataReader.Read()
				strs.Add(Conversions.ToString(sQLiteDataReader.get_Item("appleId")), Common.AES_Decrypt(Conversions.ToString(sQLiteDataReader.get_Item("password")), Conversions.ToString(Operators.AddObject(AppConst.m_randomKey, sQLiteDataReader.get_Item("appleId")))))
			End While
			Return strs
		End Function

		Public Shared Function GetCydiaRepos(Optional ByVal getName As Boolean = True) As Dictionary(Of Integer, String)
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = (New SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader()
			Dim nums As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
			While sQLiteDataReader.Read()
				If (Not getName) Then
					nums.Add(Conversions.ToInteger(sQLiteDataReader.get_Item("id")), Conversions.ToString(sQLiteDataReader.get_Item("path")))
				Else
					nums.Add(Conversions.ToInteger(sQLiteDataReader.get_Item("id")), Conversions.ToString(sQLiteDataReader.get_Item("name")))
				End If
			End While
			Return nums
		End Function

		Public Shared Function getInstalledApp(ByVal package As String, ByVal udid As String, ByRef fileIpa As String) As String
			Dim str As String
			Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("select * from list_installed_app where package=@package", AppConst.m_dbConnection)
			sQLiteCommand.get_Parameters().AddWithValue("@package", package)
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = sQLiteCommand.ExecuteReader()
			Dim str1 As String = ""
			While True
				If (sQLiteDataReader.Read()) Then
					str1 = Conversions.ToString(sQLiteDataReader.get_Item("installed_appleid_email"))
					If (sQLiteDataReader.get_Item("udid").Equals(udid)) Then
						fileIpa = Conversions.ToString(sQLiteDataReader.get_Item("file_ipa"))
						str = Conversions.ToString(sQLiteDataReader.get_Item("installed_appleid_email"))
						Exit While
					End If
				ElseIf (Operators.CompareString(str1, "", False) = 0) Then
					str = ""
					Exit While
				Else
					str = str1
					Exit While
				End If
			End While
			Return str
		End Function

		Public Shared Sub SaveAccount(ByVal appId As String, ByVal pass As String)
			Dim str As String = Common.AES_Encrypt(pass, String.Concat(AppConst.m_randomKey, appId))
			Dim str1 As String = "select * from account where appleId=@appleId"
			Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand(str1, AppConst.m_dbConnection)
			sQLiteCommand.get_Parameters().AddWithValue("@appleId", appId)
			AppConst.logger.Debug(String.Concat("SaveAccount: 1. ", str1, ", ", appId))
			Dim sQLiteDataReader As System.Data.SQLite.SQLiteDataReader = sQLiteCommand.ExecuteReader()
			If (Not sQLiteDataReader.Read()) Then
				str1 = "INSERT INTO account(appleId, password) VALUES(@appleId, @password)"
				sQLiteCommand = New System.Data.SQLite.SQLiteCommand(str1, AppConst.m_dbConnection)
				Dim parameters As System.Data.SQLite.SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				parameters.AddWithValue("@appleId", appId)
				parameters.AddWithValue("@password", str)
				parameters = Nothing
				AppConst.logger.Debug(String.Concat(New String() { "SaveAccount: 3. ", str1, ", ", appId, ",", str }))
				sQLiteCommand.ExecuteNonQuery()
			ElseIf (Not Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("password"), str, False)) Then
				str1 = "UPDATE account SET appleId=@appleId, password=@password"
				sQLiteCommand = New System.Data.SQLite.SQLiteCommand(str1, AppConst.m_dbConnection)
				Dim sQLiteParameterCollection As System.Data.SQLite.SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				sQLiteParameterCollection.AddWithValue("@appleId", appId)
				sQLiteParameterCollection.AddWithValue("@password", str)
				sQLiteParameterCollection = Nothing
				AppConst.logger.Debug(String.Concat(New String() { "SaveAccount: 2. ", str1, ", ", appId, ",", str }))
				sQLiteCommand.ExecuteNonQuery()
			End If
		End Sub

		Public Shared Sub updateInstalledApp(ByVal package As String, ByVal appleId As String, ByVal fileIpa As String, ByVal udid As String)
			Dim utcNow As TimeSpan
			Dim sQLiteCommand As System.Data.SQLite.SQLiteCommand = New System.Data.SQLite.SQLiteCommand("select * from list_installed_app where installed_appleid_email=@appleId AND package=@package AND udid=@udid", AppConst.m_dbConnection)
			Dim parameters As System.Data.SQLite.SQLiteParameterCollection = sQLiteCommand.get_Parameters()
			parameters.AddWithValue("@appleId", appleId)
			parameters.AddWithValue("@package", package)
			parameters.AddWithValue("@udid", udid)
			parameters = Nothing
			If (sQLiteCommand.ExecuteReader().Read()) Then
				sQLiteCommand = New System.Data.SQLite.SQLiteCommand("UPDATE list_installed_app SET file_ipa=@fileIpa, installed_time=@timenow WHERE installed_appleid_email=@appleId AND package=@package AND udid=@udid", AppConst.m_dbConnection)
				Dim sQLiteParameterCollection As System.Data.SQLite.SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				sQLiteParameterCollection.AddWithValue("@fileIpa", fileIpa)
				utcNow = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)
				sQLiteParameterCollection.AddWithValue("@timenow", utcNow.TotalSeconds)
				sQLiteParameterCollection.AddWithValue("@appleId", appleId)
				sQLiteParameterCollection.AddWithValue("@package", package)
				sQLiteParameterCollection.AddWithValue("@udid", udid)
				sQLiteParameterCollection = Nothing
				sQLiteCommand.ExecuteNonQuery()
			Else
				sQLiteCommand = New System.Data.SQLite.SQLiteCommand("INSERT INTO list_installed_app(installed_appleid_email, package, file_ipa, installed_time, udid) VALUES(@appleId, @package, @fileIpa, @timenow, @udid)", AppConst.m_dbConnection)
				Dim parameters1 As System.Data.SQLite.SQLiteParameterCollection = sQLiteCommand.get_Parameters()
				parameters1.AddWithValue("@appleId", appleId)
				parameters1.AddWithValue("@package", package)
				parameters1.AddWithValue("@fileIpa", fileIpa)
				parameters1.AddWithValue("@udid", udid)
				utcNow = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)
				parameters1.AddWithValue("@timenow", utcNow.TotalSeconds)
				parameters1 = Nothing
				sQLiteCommand.ExecuteNonQuery()
			End If
		End Sub
	End Class
End Namespace