using log4net;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SuperImpactor
{
	public class AppConst
	{
		public const string API_SENDLOG = "http://superimpactor.net/api/send_log.php";

		public const string DB = "\\iaidb.sqlite";

		public const string IMAGE = "\\res\\";

		public const string IMOBILEDEVICE = "\\libimobiledevice\\";

		public const string OPENSSL = "\\openssl\\bin\\";

		public const string ZIP7 = "\\7zip\\";

		public const string CERTSTORE = "\\certs\\";

		public const string DOWNLOAD = "\\download\\";

		public const string LOCALTMP = "\\tmp\\";

		public static string m_localTmp;

		public static SQLiteConnection m_dbConnection;

		public static Dictionary<int, string> m_lstCydiaRepos;

		public static string m_rootPath;

		public static string m_randomKey;

		public static ILog logger;

		public static frmSuperImpactor mainForm;

		public AppConst()
		{
		}
	}
}