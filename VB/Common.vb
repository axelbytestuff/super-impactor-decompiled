Imports Ionic.Zip
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks

Namespace SuperImpactor
	Public Class Common
		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
			Dim str As String
			Dim rijndaelManaged As System.Security.Cryptography.RijndaelManaged = New System.Security.Cryptography.RijndaelManaged()
			Dim mD5CryptoServiceProvider As System.Security.Cryptography.MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider()
			Dim str1 As String = ""
			Try
				Dim numArray(31) As Byte
				Dim numArray1 As Byte() = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(pass))
				Array.Copy(numArray1, 0, numArray, 0, 16)
				Array.Copy(numArray1, 0, numArray, 15, 16)
				rijndaelManaged.Key = numArray
				rijndaelManaged.Mode = CipherMode.ECB
				Dim cryptoTransform As ICryptoTransform = rijndaelManaged.CreateDecryptor()
				Dim numArray2 As Byte() = Convert.FromBase64String(input)
				str1 = Encoding.ASCII.GetString(cryptoTransform.TransformFinalBlock(numArray2, 0, CInt(numArray2.Length)))
				str = str1
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				str = input
				ProjectData.ClearProjectError()
			End Try
			Return str
		End Function

		Public Shared Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
			Dim str As String
			Dim rijndaelManaged As System.Security.Cryptography.RijndaelManaged = New System.Security.Cryptography.RijndaelManaged()
			Dim mD5CryptoServiceProvider As System.Security.Cryptography.MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider()
			Dim base64String As String = ""
			Try
				Dim numArray(31) As Byte
				Dim numArray1 As Byte() = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(pass))
				Array.Copy(numArray1, 0, numArray, 0, 16)
				Array.Copy(numArray1, 0, numArray, 15, 16)
				rijndaelManaged.Key = numArray
				rijndaelManaged.Mode = CipherMode.ECB
				Dim cryptoTransform As ICryptoTransform = rijndaelManaged.CreateEncryptor()
				Dim bytes As Byte() = Encoding.ASCII.GetBytes(input)
				base64String = Convert.ToBase64String(cryptoTransform.TransformFinalBlock(bytes, 0, CInt(bytes.Length)))
				str = base64String
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				str = input
				ProjectData.ClearProjectError()
			End Try
			Return str
		End Function

		Public Shared Sub DeleteFilesFromFolder(ByVal Folder As String)
			If (Directory.Exists(Folder)) Then
				Dim files As String() = Directory.GetFiles(Folder)
				Dim num As Integer = 0
				While num < CInt(files.Length)
					Dim str As String = files(num)
					Try
						File.Delete(str)
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
					num = num + 1
				End While
				Dim directories As String() = Directory.GetDirectories(Folder)
				Dim num1 As Integer = 0
				While num1 < CInt(directories.Length)
					Dim str1 As String = directories(num1)
					Common.DeleteFilesFromFolder(str1)
					Try
						Directory.Delete(str1, True)
					Catch exception1 As System.Exception
						ProjectData.SetProjectError(exception1)
						ProjectData.ClearProjectError()
					End Try
					num1 = num1 + 1
				End While
			End If
		End Sub

		Public Shared Sub DeleteFolderInFolder(ByVal Folder As String, ByVal deleteExtension As String, ByRef fnd As Boolean)
			If (Directory.Exists(Folder)) Then
				Dim directories As String() = Directory.GetDirectories(Folder)
				Dim num As Integer = 0
				While num < CInt(directories.Length)
					Dim str As String = directories(num)
					If (Operators.CompareString(Path.GetExtension(str), String.Concat(".", deleteExtension), False) <> 0) Then
						Common.DeleteFolderInFolder(str, deleteExtension, fnd)
					Else
						Directory.Delete(str, True)
						fnd = True
					End If
					num = num + 1
				End While
			End If
		End Sub

		Public Shared Sub Download(ByVal downloadPro As DownloadProgress, ByVal ipaLink As String, ByVal ipaName As String)
			Dim mRootPath As String = AppConst.m_rootPath
			Dim now As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1)
			downloadPro.DownloadAsync(ipaLink, String.Concat(mRootPath, "\tmp\\download", Conversions.ToString(CLng(Math.Round(now.TotalMilliseconds))), ".ipa"), ipaName)
		End Sub

		Public Shared Sub DownloadAndInstall(ByVal ipaLink As String, ByVal ipaName As String)
			If ((New DownloadProgress()).Download(ipaLink, String.Concat(AppConst.m_rootPath, "\tmp\\download.ipa"), ipaName)) Then
				Dim install As SuperImpactor.Install = New SuperImpactor.Install()
				install.installFromFile(String.Concat(AppConst.m_rootPath, "\download\", ipaName), "", "")
			End If
			Try
				File.Delete("\tmp\\download.ipa")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Shared Function GetHash(ByVal theInput As String) As String
			Dim str As String
			Using mD5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
				Dim numArray As Byte() = mD5.ComputeHash(Encoding.UTF8.GetBytes(theInput))
				Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
				Dim length As Integer = CInt(numArray.Length) - 1
				Dim num As Integer = 0
				Do
					stringBuilder.Append(numArray(num).ToString("X2"))
					num = num + 1
				Loop While num <= length
				str = stringBuilder.ToString()
			End Using
			Return str
		End Function

		Public Shared Function GetTempFolder() As String
			Dim str As String = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
			While Directory.Exists(str) Or File.Exists(str)
				str = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
			End While
			Return str
		End Function

		Public Shared Async Function RunExe(ByVal exe As String, ByVal params As String, Optional ByVal getError As Boolean = False) As Task(Of String)
			Dim variable As Common.VB$StateMachine_7_RunExe = Nothing
			Dim asyncTaskMethodBuilder As AsyncTaskMethodBuilder(Of String) = AsyncTaskMethodBuilder(Of String).Create()
			asyncTaskMethodBuilder.Start(Of Common.VB$StateMachine_7_RunExe)(variable)
			Return asyncTaskMethodBuilder.Task
		End Function

		<DllImport("user32", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=True)>
		Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal hideType As Common.ShowWindowType) As Integer
		End Function

		Public Shared Sub Unzip(ByVal ZipToUnpack As String, ByVal UnpackDirectory As String, Optional ByVal Password As String = "")
			Dim enumerator As IEnumerator(Of ZipEntry) = Nothing
			Using zipFiles As ZipFile = ZipFile.Read(ZipToUnpack)
				If (Operators.CompareString(Password, "", False) <> 0) Then
					zipFiles.Password = Password
				End If
				Using enumerator
					enumerator = zipFiles.GetEnumerator()
					While enumerator.MoveNext()
						enumerator.Current.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
					End While
				End Using
			End Using
		End Sub

		Public Shared Sub Zip(ByVal Folder As String, ByVal ZipFile As String)
			Using zipFiles As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile()
				zipFiles.AddDirectory(Folder)
				zipFiles.Save(ZipFile)
			End Using
		End Sub

		Public Enum ShowWindowType
			Hide = 0
			Minimized = 1
			Maximized = 2
			Restore = 9
		End Enum
	End Class
End Namespace