using Ionic.Zip;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuperImpactor
{
	public class Common
	{
		public Common()
		{
		}

		public static string AES_Decrypt(string input, string pass)
		{
			string str;
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			string str1 = "";
			try
			{
				byte[] numArray = new byte[32];
				byte[] numArray1 = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(pass));
				Array.Copy(numArray1, 0, numArray, 0, 16);
				Array.Copy(numArray1, 0, numArray, 15, 16);
				rijndaelManaged.Key = numArray;
				rijndaelManaged.Mode = CipherMode.ECB;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
				byte[] numArray2 = Convert.FromBase64String(input);
				str1 = Encoding.ASCII.GetString(cryptoTransform.TransformFinalBlock(numArray2, 0, (int)numArray2.Length));
				str = str1;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				str = input;
				ProjectData.ClearProjectError();
			}
			return str;
		}

		public static string AES_Encrypt(string input, string pass)
		{
			string str;
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			string base64String = "";
			try
			{
				byte[] numArray = new byte[32];
				byte[] numArray1 = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(pass));
				Array.Copy(numArray1, 0, numArray, 0, 16);
				Array.Copy(numArray1, 0, numArray, 15, 16);
				rijndaelManaged.Key = numArray;
				rijndaelManaged.Mode = CipherMode.ECB;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
				byte[] bytes = Encoding.ASCII.GetBytes(input);
				base64String = Convert.ToBase64String(cryptoTransform.TransformFinalBlock(bytes, 0, (int)bytes.Length));
				str = base64String;
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				str = input;
				ProjectData.ClearProjectError();
			}
			return str;
		}

		public static void DeleteFilesFromFolder(string Folder)
		{
			if (Directory.Exists(Folder))
			{
				string[] files = Directory.GetFiles(Folder);
				for (int i = 0; i < (int)files.Length; i = checked(i + 1))
				{
					string str = files[i];
					try
					{
						File.Delete(str);
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
					}
				}
				string[] directories = Directory.GetDirectories(Folder);
				for (int j = 0; j < (int)directories.Length; j = checked(j + 1))
				{
					string str1 = directories[j];
					Common.DeleteFilesFromFolder(str1);
					try
					{
						Directory.Delete(str1, true);
					}
					catch (Exception exception1)
					{
						ProjectData.SetProjectError(exception1);
						ProjectData.ClearProjectError();
					}
				}
			}
		}

		public static void DeleteFolderInFolder(string Folder, string deleteExtension, ref bool fnd)
		{
			if (Directory.Exists(Folder))
			{
				string[] directories = Directory.GetDirectories(Folder);
				for (int i = 0; i < (int)directories.Length; i = checked(i + 1))
				{
					string str = directories[i];
					if (Operators.CompareString(Path.GetExtension(str), string.Concat(".", deleteExtension), false) != 0)
					{
						Common.DeleteFolderInFolder(str, deleteExtension, ref fnd);
					}
					else
					{
						Directory.Delete(str, true);
						fnd = true;
					}
				}
			}
		}

		public static void Download(DownloadProgress downloadPro, string ipaLink, string ipaName)
		{
			string mRootPath = AppConst.m_rootPath;
			TimeSpan now = DateTime.Now - new DateTime(1970, 1, 1);
			downloadPro.DownloadAsync(ipaLink, string.Concat(mRootPath, "\\tmp\\\\download", Conversions.ToString(checked((long)Math.Round(now.TotalMilliseconds))), ".ipa"), ipaName);
		}

		public static void DownloadAndInstall(string ipaLink, string ipaName)
		{
			if ((new DownloadProgress()).Download(ipaLink, string.Concat(AppConst.m_rootPath, "\\tmp\\\\download.ipa"), ipaName))
			{
				Install install = new Install();
				install.installFromFile(string.Concat(AppConst.m_rootPath, "\\download\\", ipaName), "", "");
			}
			try
			{
				File.Delete("\\tmp\\\\download.ipa");
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				ProjectData.ClearProjectError();
			}
		}

		public static string GetHash(string theInput)
		{
			string str;
			using (MD5 mD5 = MD5.Create())
			{
				byte[] numArray = mD5.ComputeHash(Encoding.UTF8.GetBytes(theInput));
				StringBuilder stringBuilder = new StringBuilder();
				int length = checked((int)numArray.Length - 1);
				for (int i = 0; i <= length; i = checked(i + 1))
				{
					stringBuilder.Append(numArray[i].ToString("X2"));
				}
				str = stringBuilder.ToString();
			}
			return str;
		}

		public static string GetTempFolder()
		{
			string str = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			while (Directory.Exists(str) | File.Exists(str))
			{
				str = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			}
			return str;
		}

		public static async Task<string> RunExe(string exe, string @params, bool getError = false)
		{
			Common.VB$StateMachine_7_RunExe variable = null;
			AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = AsyncTaskMethodBuilder<string>.Create();
			asyncTaskMethodBuilder.Start<Common.VB$StateMachine_7_RunExe>(ref variable);
			return asyncTaskMethodBuilder.Task;
		}

		[DllImport("user32", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		private static extern int ShowWindow(IntPtr hwnd, Common.ShowWindowType hideType);

		public static void Unzip(string ZipToUnpack, string UnpackDirectory, string Password = "")
		{
			IEnumerator<ZipEntry> enumerator = null;
			using (ZipFile password = ZipFile.Read(ZipToUnpack))
			{
				if (Operators.CompareString(Password, "", false) != 0)
				{
					password.Password = Password;
				}
				using (enumerator)
				{
					enumerator = password.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently);
					}
				}
			}
		}

		public static void Zip(string Folder, string ZipFile)
		{
			using (Ionic.Zip.ZipFile zipFiles = new Ionic.Zip.ZipFile())
			{
				zipFiles.AddDirectory(Folder);
				zipFiles.Save(ZipFile);
			}
		}

		public enum ShowWindowType
		{
			Hide = 0,
			Minimized = 1,
			Maximized = 2,
			Restore = 9
		}
	}
}