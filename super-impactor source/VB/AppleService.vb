Imports Claunia.PropertyList
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Web

Namespace SuperImpactor
	Public Class AppleService
		Private Shared base_url_services As String

		Private Shared protocol_version_daw2 As String

		Private Shared protocol_version_connect1 As String

		Private Shared app_id_key As String

		Private Shared client_id As String

		Private Shared cookie As CookieContainer

		Shared Sub New()
			AppleService.base_url_services = "https://developerservices2.apple.com/services/QH65B2/"
			AppleService.protocol_version_daw2 = "A1234"
			AppleService.protocol_version_connect1 = "QH65B2"
			AppleService.app_id_key = "ba2ec180e6ca6e6c6a542255453b24d6e6e5b2be0cc48bc1b0d8ad64cfe0228f"
			AppleService.client_id = "XABBG36SBA"
		End Sub

		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Function addAppId(ByVal appName As String, ByVal appId As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/addAppId.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>identifier</key>" & VbCrLf & "	<string>", appId, "</string>" & VbCrLf & "	<key>name</key>" & VbCrLf & "	<string>", appName, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(11) = guid.ToString().ToUpper()
				clientId(12) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function addDevelopmentCert(ByVal csrContent As String, ByVal machineName As String, ByVal machineId As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/submitDevelopmentCSR.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>machineName</key>" & VbCrLf & "	<string>", machineName, "</string>" & VbCrLf & "	<key>machineId</key>" & VbCrLf & "	<string>", machineId, "</string>" & VbCrLf & "	<key>csrContent</key>" & VbCrLf & "	<string>", csrContent, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(13) = guid.ToString().ToUpper()
				clientId(14) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function addDevice(ByVal udid As String, ByVal deviceName As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/addDevice.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>deviceNumber</key>" & VbCrLf & "	<string>", udid, "</string>" & VbCrLf & "	<key>name</key>" & VbCrLf & "	<string>", deviceName, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(11) = guid.ToString().ToUpper()
				clientId(12) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function allDevelopmentCert(ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/listAllDevelopmentCerts.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				httpWebRequest.Timeout = 10000
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(7) = guid.ToString().ToUpper()
				clientId(8) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function appIds(ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/listAppIds.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(7) = guid.ToString().ToUpper()
				clientId(8) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function deleteAppId(ByVal appIdId As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/deleteAppId.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>appIdId</key>" & VbCrLf & "	<string>", appIdId, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(9) = guid.ToString().ToUpper()
				clientId(10) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function downloadProvisionProfile(ByVal appIdId As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/downloadTeamProvisioningProfile.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>appIdId</key>" & VbCrLf & "	<string>", appIdId, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(9) = guid.ToString().ToUpper()
				clientId(10) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function listDevices(ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/listDevices.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(7) = guid.ToString().ToUpper()
				clientId(8) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function listTeam(ByVal accInfo As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "listTeams.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>myacinfo</key>" & VbCrLf & "	<string>", accInfo, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(7) = guid.ToString().ToUpper()
				clientId(8) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				AppleService.cookie = New CookieContainer()
				AppleService.cookie.Add(New Uri("https://developerservices2.apple.com/"), New System.Net.Cookie("myacinfo", accInfo))
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function login(ByVal appleId As String, ByVal password As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create("https://idmsa.apple.com/IDMSWebAuth/clientDAW.cgi"), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "application/x-www-form-urlencoded"
				Dim str As String = String.Concat(New String() { "format=plist&appIdKey=", AppleService.app_id_key, "&appleId=", HttpUtility.UrlEncode(appleId), "&password=", HttpUtility.UrlEncode(password), "&userLocale=en_US&protocolVersion=", AppleService.protocol_version_daw2 })
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.KeepAlive = True
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function

		Public Shared Function revokeCertificate(ByVal serialNumber As String, ByVal teamId As String) As Claunia.PropertyList.NSDictionary
			Dim nSDictionary As Claunia.PropertyList.NSDictionary
			Try
				Dim httpWebRequest As System.Net.HttpWebRequest = DirectCast(WebRequest.Create(String.Concat(AppleService.base_url_services, "/ios/revokeDevelopmentCert.action?clientId=", AppleService.client_id)), System.Net.HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ContentType = "text/x-xml-plist"
				Dim clientId() As String = { "<?xml version=""1.0"" encoding=""UTF-8""?>" & VbCrLf & "<!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">" & VbCrLf & "<plist version=""1.0"">" & VbCrLf & "<dict>" & VbCrLf & "	<key>clientId</key>" & VbCrLf & "	<string>", AppleService.client_id, "</string>" & VbCrLf & "	<key>teamId</key>" & VbCrLf & "	<string>", teamId, "</string>" & VbCrLf & "	<key>serialNumber</key>" & VbCrLf & "	<string>", serialNumber, "</string>" & VbCrLf & "	<key>protocolVersion</key>" & VbCrLf & "	<string>", AppleService.protocol_version_connect1, "</string>" & VbCrLf & "	<key>requestId</key>" & VbCrLf & "	<string>", Nothing, Nothing }
				Dim guid As System.Guid = System.Guid.NewGuid()
				clientId(9) = guid.ToString().ToUpper()
				clientId(10) = "</string>" & VbCrLf & "	<key>userLocale</key>" & VbCrLf & "	<array>" & VbCrLf & "		<string>en_US</string>" & VbCrLf & "	</array>" & VbCrLf & "</dict>" & VbCrLf & "</plist>" & VbCrLf & ""
				Dim str As String = String.Concat(clientId)
				httpWebRequest.UserAgent = "Xcode"
				httpWebRequest.Accept = "text/x-xml-plist"
				httpWebRequest.Headers.Add("Accept-Language", "en-us")
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)")
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
				httpWebRequest.KeepAlive = True
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
				httpWebRequest.CookieContainer = AppleService.cookie
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count())
				Dim response As HttpWebResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
				Dim [end] As String = (New StreamReader(response.GetResponseStream())).ReadToEnd()
				File.WriteAllText(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"), [end])
				Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(String.Concat(AppConst.m_rootPath, "\tmp\data.plist"))
				httpWebRequest.GetRequestStream().Close()
				httpWebRequest.GetRequestStream().Dispose()
				response.Close()
				response.Dispose()
				nSDictionary = DirectCast(PropertyListParser.Parse(fileInfo), Claunia.PropertyList.NSDictionary)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, Nothing)
				nSDictionary = Nothing
				ProjectData.ClearProjectError()
			End Try
			Return nSDictionary
		End Function
	End Class
End Namespace