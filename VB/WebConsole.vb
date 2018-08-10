Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text

Namespace SuperImpactor
	Public Class WebConsole
		Public cookie As CookieContainer

		Public Sub New()
			MyBase.New()
		End Sub

		Public Function getKeyValue(ByVal rs As String, ByVal key As String, ByRef value As String, Optional ByVal fromPos As Integer = 0, Optional ByVal keyWithoutQuote As Boolean = False, Optional ByVal quoteChar As String = """") As Object
			Dim obj As Object
			If (Not keyWithoutQuote) Then
				key = String.Concat(quoteChar, key, quoteChar)
			End If
			Dim num As Integer = rs.IndexOf(key, fromPos)
			If (num <> -1) Then
				Dim num1 As Integer = rs.IndexOf(quoteChar, num + key.Length)
				If (num1 <> -1) Then
					num1 = num1 + 1
					Dim num2 As Integer = rs.IndexOf(quoteChar, num1)
					If (num2 <> -1) Then
						value = rs.Substring(num1, num2 - num1)
						obj = ""
					Else
						obj = "incorrect key value 2"
					End If
				Else
					obj = "incorrect key value 1"
				End If
			Else
				obj = "Cannot find key"
			End If
			Return obj
		End Function

		Public Function http(ByVal url As String, Optional ByVal postData As String = "") As String
			Dim str As String
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(url), System.Net.HttpWebRequest)
				httpWebRequest.AllowAutoRedirect = True
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				If (Me.cookie Is Nothing) Then
					Me.cookie = New CookieContainer()
				Else
					httpWebRequest.CookieContainer = Me.cookie
				End If
				If (Operators.CompareString(postData, "", False) <> 0) Then
					httpWebRequest.Method = "POST"
					httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetBytes(postData).Count())
				End If
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				Me.cookie.Add(response.Cookies)
				If (Operators.CompareString(postData, "", False) <> 0) Then
					httpWebRequest.GetRequestStream().Close()
					httpWebRequest.GetRequestStream().Dispose()
				End If
				response.Close()
				response.Dispose()
				str = [end]
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				str = ""
				ProjectData.ClearProjectError()
			End Try
			Return str
		End Function
	End Class
End Namespace