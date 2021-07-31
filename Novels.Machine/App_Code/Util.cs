using HtmlAgilityPack;
using Novels.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Novels.Machine.App_Code
{
	public static class Util
	{

		public static Dictionary<int, string> EnumNamedValues<T>(bool addEntity = false) where T : Enum
		{
			var dictionary = new Dictionary<int, string>();

			var values = Enum.GetValues(typeof(T));

			if (addEntity)
				dictionary.Add(0, "");

			foreach (int item in values)
			{
				dictionary.Add(item, Enum.GetName(typeof(T), item));
			}

			return dictionary;
		}

		/// <summary>
		/// 指定 Enum，戴入 Combobox
		/// </summary>
		/// <param name="addEntity">是否需要插入空白第一項</param>
		/// <returns>Text = string ; Value = int </returns>
		public static Dictionary<string, int> ToDictionaryByEnum<T>(bool addEntity = false) where T : Enum
		{
			var dictionary = new Dictionary<string, int>();

			var values = Enum.GetValues(typeof(T));

			if (addEntity)
				dictionary.Add("", 0);

			foreach (int item in values)
			{
				dictionary.Add(Enum.GetName(typeof(T), item), item);
			}

			return dictionary;
		}

		/// <summary>
		/// 指定 Enum，戴入 Combobox
		/// </summary>
		/// <param name="enumType">typeof(Enum)</param>
		/// <param name="addEntity">是否需要插入空白第一項</param>
		/// <returns>Text = string ; Value = int </returns>
		public static Dictionary<string, int> ToDictionaryByEnum(Type enumType, bool addEntity = false)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();

			if (addEntity)
				dictionary.Add("", 0);

			foreach (int item in Enum.GetValues(enumType))
			{
				dictionary.Add(Enum.GetName(enumType, item), item);
			}

			return dictionary;
		}

		/// <summary>
		/// 指定物件陣列，屬性，戴入 Combobox
		/// </summary>
		/// <param name="t">List<Object> Source</param>
		/// <param name="Key">Key (string Property Name)</param>
		/// <param name="Value">Value (int Property Name)</param>
		/// <param name="addEntity">是否需要插入空白第一項</param>
		/// <returns>Text = string ; Value = int </returns>
		public static Dictionary<string, int> ToDictionaryByObject<T>(this List<T> t, string Key, string Value, bool addEntity = false)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();

			foreach (var item in t)
			{
				int value = (int)typeof(T).GetProperty(Value).GetValue(item);

				string key = typeof(T).GetProperty(Key).GetValue(item).ToString();

				dictionary.Add(key, value);
			}

			return dictionary;
		}

		/// <summary>
		/// 將物件 List<T>，存成 Dictionary<string, object> 格式 (Text = T.key , Value = T)
		/// </summary>
		/// <param name="t"></param>
		/// <param name="Key">PropertyInfo.Name</param>
		/// <param name="addEntity">是否需要插入空白第一項</param>
		/// <returns></returns>
		public static Dictionary<string, object> ToDictionary<T>(this List<T> t, string Key, bool addEntity = false)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();

			if (addEntity)
				dictionary.Add("", null);

			foreach (var item in t)
			{
				var value = item;

				var key = typeof(T).GetProperty(Key).GetValue(item).ToString();

				dictionary.Add(key, value);
			}

			return dictionary;
		}

		#region HtmlRule Novel 測試 爬蟲
		public static string Test(this HtmlRule obj, string url, string TitleLink)
		{
			string result = string.Empty;

			if (string.IsNullOrEmpty(url))
			{
				return "error 1";
			}

			// 原始檔
			if (string.IsNullOrEmpty(obj.ListXPath))
			{
				return HtmlDocHelp.GetHtmlDocByUrl(url);
			}

			#region 目錄頁

			result = HtmlDocHelp.GetHtmlDocByUrl(url, obj.ListXPath);

			IEnumerable<HtmlNode> nodes;
			if (string.IsNullOrEmpty(obj.ListTag))
			{
				return result;
			}
			else
			{
				// 解析 HTMLDOC 
				nodes = HtmlDocHelp.GetHtmlNodeByUrl(result, obj.ListTag);

				foreach (var item in nodes)
				{
					result = item.InnerHtml;
					break;
				}
			}

			// 取得 目錄連結
			Dictionary<string, string> nodesDic = new Dictionary<string, string>();

			if (string.IsNullOrEmpty(obj.ListTagFilter))
			{
				return result;
			}
			else
			{
				foreach (var item in nodes)
				{
					nodesDic.Add(item.InnerHtml, item.Attributes[obj.ListTagFilter].Value);
					result = nodesDic.ToList()[0].Value;
					break;
				}
			}

			#endregion

			#region 內文頁			

			if (string.IsNullOrEmpty(obj.TextXPath))
			{
				return result;
			}
			else
			{
				result = HtmlDocHelp.GetHtmlDocByUrl(TitleLink + nodesDic.ToList()[0].Value, obj.TextXPath);
			}

			if (string.IsNullOrEmpty(obj.TextTag))
			{
				return result;
			}
			else
			{
				// 解析 HTMLDOC 
				nodes = HtmlDocHelp.GetHtmlNodeByUrl(result, obj.TextTag);

				result = string.Join("\r\n", nodes.Select(x => x.InnerHtml).ToList());
			}

			if (string.IsNullOrEmpty(obj.TextTagFilter))
			{
				return result;
			}
			else
			{
				// 取得內容文字
				result = string.Empty;

				bool start = false;

				foreach (var item in nodes)
				{
					if (start || item.XPath == obj.TextTagFilter)
					{
						result += item.InnerHtml + "\r\n";
						start = true;
					}
				}
			}

			#endregion

			return result;
		}

		public static string Test(this Novel novel)
		{
			string result = string.Empty;

			if (string.IsNullOrEmpty(novel.WebLink))
			{
				return "error 1";
			}

			#region 目錄頁

			result = HtmlDocHelp.GetHtmlDocByUrl(novel.WebLink, novel.HtmlRule.ListXPath);

			IEnumerable<HtmlNode> nodes;
			if (string.IsNullOrEmpty(novel.HtmlRule.ListTag))
			{
				return result;
			}
			else
			{
				// 解析 HTMLDOC 
				nodes = HtmlDocHelp.GetHtmlNodeByUrl(result, novel.HtmlRule.ListTag);

				foreach (var item in nodes)
				{
					result = item.InnerHtml;
					break;
				}
			}

			// 取得 目錄連結
			Dictionary<string, string> nodesDic = new Dictionary<string, string>();

			if (string.IsNullOrEmpty(novel.HtmlRule.ListTagFilter))
			{
				return result;
			}
			else
			{
				foreach (var item in nodes)
				{
					nodesDic.Add(item.InnerHtml, item.Attributes[novel.HtmlRule.ListTagFilter].Value);
					result = nodesDic.ToList()[0].Value;
					break;
				}
			}

			#endregion

			#region 內文頁			

			if (string.IsNullOrEmpty(novel.HtmlRule.TextXPath))
			{
				return result;
			}
			else
			{
				string TitleLink = string.Empty;

				switch (novel.ContentLinkMode)
				{
					case 1:
						TitleLink = novel.HtmlRule.SiteTitle;
						break;

					case 2:

						if (string.IsNullOrEmpty(novel.ContentLink))
						{
							return "error 2";
						}

						TitleLink = novel.ContentLink;
						break;
				}

				result = HtmlDocHelp.GetHtmlDocByUrl(TitleLink + nodesDic.ToList()[0].Value, novel.HtmlRule.TextXPath);
			}

			if (string.IsNullOrEmpty(novel.HtmlRule.TextTag))
			{
				return result;
			}
			else
			{
				// 解析 HTMLDOC 
				nodes = HtmlDocHelp.GetHtmlNodeByUrl(result, novel.HtmlRule.TextTag);

				result = string.Join("\r\n", nodes.Select(x => x.InnerHtml).ToList());
			}

			if (string.IsNullOrEmpty(novel.HtmlRule.TextTagFilter))
			{
				return result;
			}
			else
			{
				// 取得內容文字
				result = string.Empty;

				bool start = false;

				foreach (var item in nodes)
				{
					if (start || item.XPath == novel.HtmlRule.TextTagFilter)
					{
						result += item.InnerHtml + "\r\n";
						start = true;
					}
				}
			}

			#endregion

			return result;
		}

		#endregion

		#region 建立 Chapter 相關 爬蟲

		/// <summary>
		/// 取得目錄頁章節名稱及鏈結路徑
		/// </summary>
		/// <param name="novel"></param>
		/// <returns></returns>
		public static Dictionary<string, string> GetDirs(Novel novel)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			try
			{
				var doc = HtmlDocHelp.GetHtmlDocByUrl(novel.WebLink, novel.HtmlRule.ListXPath);

				var nodes = HtmlDocHelp.GetHtmlNodeByUrl(doc, novel.HtmlRule.ListTag);

				var i = 0;

				foreach (var item in nodes)
				{
					var key = item.InnerHtml;
					var value = item.Attributes[novel.HtmlRule.ListTagFilter].Value;

					if (result.ContainsKey(key))	// 相同標題處理
					{
						if (result[key] == value)	// 相同標題、相同網址，則跳過
						{							
							continue;
						}
						else                        // 相同標題、不同網址，則修改標題名稱
						{
							key = key + "_" + i.ToString();

							i++;
						}
					}
					result.Add(key, value);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return result;
		}

		public static string GetContentURL(Novel novel, string url)
		{
			// set url
			switch (novel.ContentLinkMode)
			{
				case 1:
					url = novel.HtmlRule.SiteTitle + url;
					break;
				case 2:
					url = novel.ContentLink + url;
					break;
			}

			return url;
		}

		/// <summary>
		/// 取得內容文字
		/// </summary>
		/// <param name="novel"></param>
		/// <param name="url"></param>
		/// <returns></returns>
		public static string GetChapterContent(Novel novel, string url)
		{
			// 取得內容文字
			var result = string.Empty;

			// set url
			switch (novel.ContentLinkMode)
			{
				case 1:
					url = novel.HtmlRule.SiteTitle + url;
					break;
				case 2:
					url = novel.ContentLink + url;
					break;
			}

			try
			{
				// 取得 HTMLDOC
				var doc = HtmlDocHelp.GetHtmlDocByUrl(url, novel.HtmlRule.TextXPath);

				// 解析 HTMLDOC
				result = NewMethod(novel, result, doc);

				if (string.IsNullOrEmpty(result))
				{
					doc = HtmlDocHelp.GetHtmlDocByUrl(url, "/html[1]/body[1]/table[7]/tr[1]/td[1]/div[4]");

					result = NewMethod(novel, result, doc);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return result;
		}

		private static string NewMethod(Novel novel, string result, string doc)
		{
			IEnumerable<HtmlNode> nodes = HtmlDocHelp.GetHtmlNodeByUrl(doc, novel.HtmlRule.TextTag);

			// 過濾前幾個 TextTagFilter
			bool start = false;

			foreach (var item in nodes)
			{
				if (start || item.XPath == novel.HtmlRule.TextTagFilter)
				{
					result += item.InnerHtml + "\r\n";
					start = true;
				}
			}

			return result;
		}

		#endregion

		#region 檔案下載

		/// <summary>
		/// 檔案下載
		/// </summary>
		/// <param name="novel"></param>
		public static void DownloadChapters(this Novel novel)
		{
			string fileName = "《" + novel.Name + "》" + novel.Author + ".txt";

			string content = string.Join("\r\n", novel.Chapters.Select(x => x.Content));

			// 指定文字內容，儲存文字檔案
			SaveFileDialog Dialog = new SaveFileDialog
			{
				Filter = "文字文件(*.txt)|*.txt*",
				DefaultExt = ".txt",
				FileName = fileName
			};

			if (Dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					StreamWriter SW = new StreamWriter(Dialog.FileName, true, Encoding.Unicode);

					SW.Write(content);

					SW.Dispose();

					OpenFilePath(Dialog.FileName);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

		/// <summary>
		/// 指定路徑，開啟檔案總管，並反白指定檔案
		/// </summary>
		/// <param name="fileName"></param>
		private static void OpenFilePath(string fileName)
		{
			try
			{
				if (File.Exists(fileName))
				{
					//string explorer = @"C:\Windows\explorer.exe"; or "explorer" // windows 命令
					System.Diagnostics.Process.Start("explorer", "/select, " + fileName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}			
		}

		#endregion
	}
}
