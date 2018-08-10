using log4net;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SuperImpactor
{
	public class Database
	{
		public Database()
		{
		}

		public static void DeleteAccount(string appId)
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand("DELETE From account where appleId=@appleId", AppConst.m_dbConnection);
			sQLiteCommand.get_Parameters().AddWithValue("@appleId", appId);
			sQLiteCommand.ExecuteNonQuery();
		}

		public static void DeleteAccounts()
		{
			(new SQLiteCommand("DELETE From account", AppConst.m_dbConnection)).ExecuteNonQuery();
		}

		public static Dictionary<string, string> GetAccounts()
		{
			Dictionary<string, string> strs = new Dictionary<string, string>();
			SQLiteDataReader sQLiteDataReader = (new SQLiteCommand("select * from account", AppConst.m_dbConnection)).ExecuteReader();
			while (sQLiteDataReader.Read())
			{
				strs.Add(Conversions.ToString(sQLiteDataReader.get_Item("appleId")), Common.AES_Decrypt(Conversions.ToString(sQLiteDataReader.get_Item("password")), Conversions.ToString(Operators.AddObject(AppConst.m_randomKey, sQLiteDataReader.get_Item("appleId")))));
			}
			return strs;
		}

		public static Dictionary<int, string> GetCydiaRepos(bool getName = true)
		{
			SQLiteDataReader sQLiteDataReader = (new SQLiteCommand("select * from cydia_repos order by id", AppConst.m_dbConnection)).ExecuteReader();
			Dictionary<int, string> nums = new Dictionary<int, string>();
			while (sQLiteDataReader.Read())
			{
				if (!getName)
				{
					nums.Add(Conversions.ToInteger(sQLiteDataReader.get_Item("id")), Conversions.ToString(sQLiteDataReader.get_Item("path")));
				}
				else
				{
					nums.Add(Conversions.ToInteger(sQLiteDataReader.get_Item("id")), Conversions.ToString(sQLiteDataReader.get_Item("name")));
				}
			}
			return nums;
		}

		public static string getInstalledApp(string package, string udid, ref string fileIpa)
		{
			string str;
			SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from list_installed_app where package=@package", AppConst.m_dbConnection);
			sQLiteCommand.get_Parameters().AddWithValue("@package", package);
			SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
			string str1 = "";
			while (true)
			{
				if (sQLiteDataReader.Read())
				{
					str1 = Conversions.ToString(sQLiteDataReader.get_Item("installed_appleid_email"));
					if (sQLiteDataReader.get_Item("udid").Equals(udid))
					{
						fileIpa = Conversions.ToString(sQLiteDataReader.get_Item("file_ipa"));
						str = Conversions.ToString(sQLiteDataReader.get_Item("installed_appleid_email"));
						break;
					}
				}
				else if (Operators.CompareString(str1, "", false) == 0)
				{
					str = "";
					break;
				}
				else
				{
					str = str1;
					break;
				}
			}
			return str;
		}

		public static void SaveAccount(string appId, string pass)
		{
			string str = Common.AES_Encrypt(pass, string.Concat(AppConst.m_randomKey, appId));
			string str1 = "select * from account where appleId=@appleId";
			SQLiteCommand sQLiteCommand = new SQLiteCommand(str1, AppConst.m_dbConnection);
			sQLiteCommand.get_Parameters().AddWithValue("@appleId", appId);
			AppConst.logger.Debug(string.Concat("SaveAccount: 1. ", str1, ", ", appId));
			SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
			if (!sQLiteDataReader.Read())
			{
				str1 = "INSERT INTO account(appleId, password) VALUES(@appleId, @password)";
				sQLiteCommand = new SQLiteCommand(str1, AppConst.m_dbConnection);
				SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
				parameters.AddWithValue("@appleId", appId);
				parameters.AddWithValue("@password", str);
				parameters = null;
				AppConst.logger.Debug(string.Concat(new string[] { "SaveAccount: 3. ", str1, ", ", appId, ",", str }));
				sQLiteCommand.ExecuteNonQuery();
			}
			else if (!Operators.ConditionalCompareObjectEqual(sQLiteDataReader.get_Item("password"), str, false))
			{
				str1 = "UPDATE account SET appleId=@appleId, password=@password";
				sQLiteCommand = new SQLiteCommand(str1, AppConst.m_dbConnection);
				SQLiteParameterCollection sQLiteParameterCollection = sQLiteCommand.get_Parameters();
				sQLiteParameterCollection.AddWithValue("@appleId", appId);
				sQLiteParameterCollection.AddWithValue("@password", str);
				sQLiteParameterCollection = null;
				AppConst.logger.Debug(string.Concat(new string[] { "SaveAccount: 2. ", str1, ", ", appId, ",", str }));
				sQLiteCommand.ExecuteNonQuery();
			}
		}

		public static void updateInstalledApp(string package, string appleId, string fileIpa, string udid)
		{
			TimeSpan utcNow;
			SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from list_installed_app where installed_appleid_email=@appleId AND package=@package AND udid=@udid", AppConst.m_dbConnection);
			SQLiteParameterCollection parameters = sQLiteCommand.get_Parameters();
			parameters.AddWithValue("@appleId", appleId);
			parameters.AddWithValue("@package", package);
			parameters.AddWithValue("@udid", udid);
			parameters = null;
			if (sQLiteCommand.ExecuteReader().Read())
			{
				sQLiteCommand = new SQLiteCommand("UPDATE list_installed_app SET file_ipa=@fileIpa, installed_time=@timenow WHERE installed_appleid_email=@appleId AND package=@package AND udid=@udid", AppConst.m_dbConnection);
				SQLiteParameterCollection sQLiteParameterCollection = sQLiteCommand.get_Parameters();
				sQLiteParameterCollection.AddWithValue("@fileIpa", fileIpa);
				utcNow = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
				sQLiteParameterCollection.AddWithValue("@timenow", utcNow.TotalSeconds);
				sQLiteParameterCollection.AddWithValue("@appleId", appleId);
				sQLiteParameterCollection.AddWithValue("@package", package);
				sQLiteParameterCollection.AddWithValue("@udid", udid);
				sQLiteParameterCollection = null;
				sQLiteCommand.ExecuteNonQuery();
			}
			else
			{
				sQLiteCommand = new SQLiteCommand("INSERT INTO list_installed_app(installed_appleid_email, package, file_ipa, installed_time, udid) VALUES(@appleId, @package, @fileIpa, @timenow, @udid)", AppConst.m_dbConnection);
				SQLiteParameterCollection parameters1 = sQLiteCommand.get_Parameters();
				parameters1.AddWithValue("@appleId", appleId);
				parameters1.AddWithValue("@package", package);
				parameters1.AddWithValue("@fileIpa", fileIpa);
				parameters1.AddWithValue("@udid", udid);
				utcNow = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
				parameters1.AddWithValue("@timenow", utcNow.TotalSeconds);
				parameters1 = null;
				sQLiteCommand.ExecuteNonQuery();
			}
		}
	}
}