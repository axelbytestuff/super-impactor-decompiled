using Claunia.PropertyList;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SuperImpactor
{
	public class AppleService
	{
		private static string base_url_services;

		private static string protocol_version_daw2;

		private static string protocol_version_connect1;

		private static string app_id_key;

		private static string client_id;

		private static CookieContainer cookie;

		static AppleService()
		{
			AppleService.base_url_services = "https://developerservices2.apple.com/services/QH65B2/";
			AppleService.protocol_version_daw2 = "A1234";
			AppleService.protocol_version_connect1 = "QH65B2";
			AppleService.app_id_key = "ba2ec180e6ca6e6c6a542255453b24d6e6e5b2be0cc48bc1b0d8ad64cfe0228f";
			AppleService.client_id = "XABBG36SBA";
		}

		public AppleService()
		{
		}

		public static NSDictionary addAppId(string appName, string appId, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/addAppId.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>identifier</key>\n\t<string>", appId, "</string>\n\t<key>name</key>\n\t<string>", appName, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[11] = guid.ToString().ToUpper();
				clientId[12] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary addDevelopmentCert(string csrContent, string machineName, string machineId, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/submitDevelopmentCSR.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>machineName</key>\n\t<string>", machineName, "</string>\n\t<key>machineId</key>\n\t<string>", machineId, "</string>\n\t<key>csrContent</key>\n\t<string>", csrContent, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[13] = guid.ToString().ToUpper();
				clientId[14] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary addDevice(string udid, string deviceName, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/addDevice.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>deviceNumber</key>\n\t<string>", udid, "</string>\n\t<key>name</key>\n\t<string>", deviceName, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[11] = guid.ToString().ToUpper();
				clientId[12] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary allDevelopmentCert(string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/listAllDevelopmentCerts.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				httpWebRequest.Timeout = 10000;
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[7] = guid.ToString().ToUpper();
				clientId[8] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary appIds(string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/listAppIds.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[7] = guid.ToString().ToUpper();
				clientId[8] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary deleteAppId(string appIdId, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/deleteAppId.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>appIdId</key>\n\t<string>", appIdId, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[9] = guid.ToString().ToUpper();
				clientId[10] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary downloadProvisionProfile(string appIdId, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/downloadTeamProvisioningProfile.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>appIdId</key>\n\t<string>", appIdId, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[9] = guid.ToString().ToUpper();
				clientId[10] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary listDevices(string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/listDevices.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[7] = guid.ToString().ToUpper();
				clientId[8] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary listTeam(string accInfo)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "listTeams.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>myacinfo</key>\n\t<string>", accInfo, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[7] = guid.ToString().ToUpper();
				clientId[8] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				AppleService.cookie = new CookieContainer();
				AppleService.cookie.Add(new Uri("https://developerservices2.apple.com/"), new Cookie("myacinfo", accInfo));
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary login(string appleId, string password)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://idmsa.apple.com/IDMSWebAuth/clientDAW.cgi");
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				string str = string.Concat(new string[] { "format=plist&appIdKey=", AppleService.app_id_key, "&appleId=", HttpUtility.UrlEncode(appleId), "&password=", HttpUtility.UrlEncode(password), "&userLocale=en_US&protocolVersion=", AppleService.protocol_version_daw2 });
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}

		public static NSDictionary revokeCertificate(string serialNumber, string teamId)
		{
			NSDictionary nSDictionary;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(AppleService.base_url_services, "/ios/revokeDevelopmentCert.action?clientId=", AppleService.client_id));
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "text/x-xml-plist";
				string[] clientId = new string[] { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">\n<plist version=\"1.0\">\n<dict>\n\t<key>clientId</key>\n\t<string>", AppleService.client_id, "</string>\n\t<key>teamId</key>\n\t<string>", teamId, "</string>\n\t<key>serialNumber</key>\n\t<string>", serialNumber, "</string>\n\t<key>protocolVersion</key>\n\t<string>", AppleService.protocol_version_connect1, "</string>\n\t<key>requestId</key>\n\t<string>", null, null };
				Guid guid = Guid.NewGuid();
				clientId[9] = guid.ToString().ToUpper();
				clientId[10] = "</string>\n\t<key>userLocale</key>\n\t<array>\n\t\t<string>en_US</string>\n\t</array>\n</dict>\n</plist>\n";
				string str = string.Concat(clientId);
				httpWebRequest.UserAgent = "Xcode";
				httpWebRequest.Accept = "text/x-xml-plist";
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("X-Xcode-Version", "7.0 (7A120f)");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.CookieContainer = AppleService.cookie;
				httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetBytes(str).Count<byte>());
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				File.WriteAllText(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"), end);
				FileInfo fileInfo = new FileInfo(string.Concat(AppConst.m_rootPath, "\\tmp\\data.plist"));
				httpWebRequest.GetRequestStream().Close();
				httpWebRequest.GetRequestStream().Dispose();
				response.Close();
				response.Dispose();
				nSDictionary = (NSDictionary)PropertyListParser.Parse(fileInfo);
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				nSDictionary = null;
				ProjectData.ClearProjectError();
			}
			return nSDictionary;
		}
	}
}