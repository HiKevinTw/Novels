using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Novels.Repository.Verification
{
	public class SQLite
	{
		static string connectionString;

		static string dbPath;

		#region Create CommandText
		static string NovelsCreate
		{
			get
			{
				return @"
						CREATE TABLE Novels (
							ID INTEGER,
							Name NVARCHAR(100),
							Author NVARCHAR(100),
							UpdateTime DATETIME,
							CONSTRAINT Player_PK PRIMARY KEY (ID)
						)";
			}
		}

		static bool NovelsTableOK = false;

		static bool NovelsOK = false;

		static string ChaptersCreate
		{
			get
			{
				return @"
						CREATE TABLE Chapters (
							ID INTEGER,
							NovelID INTEGER,
							Sort INTEGER,
							Title NVARCHAR(100),
							Content Text,
							WebLink NVARCHAR(100),
							UpdateTime DATETIME,
							CONSTRAINT Player_PK PRIMARY KEY (ID)
						)";
			}
		}

		static bool ChaptersTableOK = false;

		static bool ChaptersOK = false;

		static string HtmlRuleCreate
		{
			get
			{
				return @"
						CREATE TABLE HtmlRule (
							ID INTEGER,
							Name NVARCHAR(100),
							SiteTitle NVARCHAR(100),
							ListXPath NVARCHAR(100),
							ListTag NVARCHAR(100),
							ListTagFilter NVARCHAR(100),
							TextXPath NVARCHAR(100),
							TextTag NVARCHAR(100),
							TextTagFilter NVARCHAR(100),
							Sort INTEGER,
							CONSTRAINT Player_PK PRIMARY KEY (ID)
						)";
			}
		}

		static bool HtmlRuleTableOK = false;

		static bool HtmlRuleOK = false;


		#endregion

		static SQLite()
		{
			dbPath = @"TestNovels.sqlite";

			connectionString = "data source=" + dbPath;
		}

		public static void VerificationSql()
		{
			CheckFile();
			CheckTable();

			if (!NovelsTableOK)
			{
				CreateTable(NovelsCreate);
			}
			if (!NovelsOK)
			{
				DataTable dt = GetDataTable("Novels");
			}


			if (!ChaptersTableOK)
			{
				CreateTable(ChaptersCreate);
			}
			if (!ChaptersOK)
			{
				DataTable dt = GetDataTable("Chapters");
			}

			if (!HtmlRuleTableOK)
			{
				CreateTable(HtmlRuleCreate);
			}
			if (!HtmlRuleOK)
			{
				DataTable dt = GetDataTable("HtmlRule");
			}
		}


		/// <summary>
		/// 檢查檔案，沒有的話則建立
		/// </summary>
		private static void CheckFile()
		{
			if (!File.Exists(dbPath))
			{
				using (var cn = new SQLiteConnection(connectionString))
				{
					try
					{
						cn.Open();
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}   // 當代碼退出using時，連接自動關閉。
			}
		}

		private static void CheckTable()
		{
			using (var cn = new SQLiteConnection(connectionString))
			{
				try
				{
					cn.Open();

					SQLiteCommand cmd = new SQLiteCommand();

					cmd.Connection = cn;

					cmd.CommandText = "SELECT tbl_name,sql FROM sqlite_master";

					SQLiteDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						if (reader[0].ToString() == "Novels")
						{
							NovelsTableOK = true;

							// 有 table 則比對 schema
							string sql = reader[1].ToString().Replace("\r", "").Replace("\t", "").Replace("\n", "");
							string str = NovelsCreate.Replace("\r", "").Replace("\t", "").Replace("\n", "");

							if (sql == str)
							{
								NovelsOK = true;
							}

							//var da = new SQLiteDataAdapter("SELECT * FROM Novels", cn);
							//DataTable dt = new DataTable();
							//da.Fill(dt);
						}

						if (reader[0].ToString() == "Chapters")
						{
							ChaptersTableOK = true;

							// 有 table 則比對 schema
							string sql = reader[1].ToString().Replace("\r", "").Replace("\t", "").Replace("\n", "");
							string str = ChaptersCreate.Replace("\r", "").Replace("\t", "").Replace("\n", "");

							if (sql == str)
							{
								ChaptersOK = true;
							}
						}

						if (reader[0].ToString() == "HtmlRule")
						{
							HtmlRuleTableOK = true;

							// 有 table 則比對 schema
							string sql = reader[1].ToString().Replace("\r", "").Replace("\t", "").Replace("\n", "");
							string str = HtmlRuleCreate.Replace("\r", "").Replace("\t", "").Replace("\n", "");

							if (sql == str)
							{
								HtmlRuleOK = true;
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private static void CreateTable(string sql)
		{
			using (var cn = new SQLiteConnection(connectionString))
			{
				try
				{
					cn.Open();

					SQLiteCommand cmd = new SQLiteCommand(cn);

					cmd.CommandText = sql;

					cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private static DataTable GetDataTable(string tableName)
		{
			DataTable result = new DataTable();

			using (var cn = new SQLiteConnection(connectionString))
			{
				try
				{
					cn.Open();

					string sql = string.Format("SELECT * FROM {0} ", tableName);

					var da = new SQLiteDataAdapter(sql, cn);

					da.Fill(result);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return result;
		}
	}
}
