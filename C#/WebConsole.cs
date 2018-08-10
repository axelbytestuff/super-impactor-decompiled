using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SuperImpactor
{
	public class WebConsole
	{
		public CookieContainer cookie;

		public WebConsole()
		{
		}

		public object getKeyValue(string rs, string key, ref string value, int fromPos = 0, bool keyWithoutQuote = false, string quoteChar = "\"")
		{
			object obj;
			if (!keyWithoutQuote)
			{
				key = string.Concat(quoteChar, key, quoteChar);
			}
			int num = rs.IndexOf(key, fromPos);
			if (num != -1)
			{
				int num1 = rs.IndexOf(quoteChar, checked(num + key.Length));
				if (num1 != -1)
				{
					num1 = checked(num1 + 1);
					int num2 = rs.IndexOf(quoteChar, num1);
					if (num2 != -1)
					{
						value = rs.Substring(num1, checked(num2 - num1));
						obj = "";
					}
					else
					{
						obj = "incorrect key value 2";
					}
				}
				else
				{
					obj = "incorrect key value 1";
				}
			}
			else
			{
				obj = "Cannot find key";
			}
			return obj;
		}

		public string http(string url, string postData = "")
		{
			string str;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.AllowAutoRedirect = true;
				httpWebRequest.Headers.Add("Accept-Language", "en-us");
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				if (this.cookie == null)
				{
					this.cookie = new CookieContainer();
				}
				else
				{
					httpWebRequest.CookieContainer = this.cookie;
				}
				if (Operators.CompareString(postData, "", false) != 0)
				{
					httpWebRequest.Method = "POST";
					httpWebRequest.GetRequestStream().Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetBytes(postData).Count<byte>());
				}
				HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				this.cookie.Add(response.Cookies);
				if (Operators.CompareString(postData, "", false) != 0)
				{
					httpWebRequest.GetRequestStream().Close();
					httpWebRequest.GetRequestStream().Dispose();
				}
				response.Close();
				response.Dispose();
				str = end;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly, null);
				str = "";
				ProjectData.ClearProjectError();
			}
			return str;
		}
	}
}