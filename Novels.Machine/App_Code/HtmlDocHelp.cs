using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Novels.Machine.App_Code
{
	// HtmlAgilityPack 官網：	https://html-agility-pack.net/
	// 教學：					https://www.itread01.com/content/1513012925.html
	public class HtmlDocHelp
	{
		/// <summary>
		/// 依網址，取得HTML Document
		/// </summary>
		/// <param name="UrlString"></param>
		/// <param name="XPathString"></param>
		/// <returns></returns>
		public static string GetHtmlDocByUrl(string UrlString, string XPathString = "")
		{
			var doc = new HtmlDocument();

			try
			{
				doc = new HtmlWeb().Load(UrlString);

				if (!string.IsNullOrEmpty(XPathString) && doc.DocumentNode.SelectNodes(XPathString) != null)
					doc.LoadHtml(doc.DocumentNode.SelectSingleNode(XPathString).InnerHtml);
				else
					throw new Exception("GetHtmlDocByUrl Error：" + UrlString);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return doc.Text;
		}

		/// <summary>
		/// 依HTML Document，取得HTML Document
		/// </summary>
		/// <param name="htmlDocString"></param>
		/// <param name="XPathString"></param>
		/// <returns></returns>
		public static string GetHtmlDocByDoc(string htmlDocString, string XPathString = "")
		{
			var doc = new HtmlDocument();

			try
			{
				doc.LoadHtml(htmlDocString);

				if (!string.IsNullOrEmpty(XPathString) && doc.DocumentNode.SelectNodes(XPathString) != null)
					doc.LoadHtml(doc.DocumentNode.SelectSingleNode(XPathString).InnerHtml);
				else
					throw new Exception("GetHtmlDocByDoc Error");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return doc.Text;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="htmlDocString"></param>
		/// <param name="descendants"></param>
		/// <returns></returns>
		public static IEnumerable<HtmlNode> GetHtmlNodeByUrl(string htmlDocString, string descendants = "")
		{
			IEnumerable<HtmlNode> result;

			try
			{
				var doc = new HtmlDocument();

				doc.LoadHtml(htmlDocString);

				if (string.IsNullOrEmpty(descendants))
					result = doc.DocumentNode.Descendants();
				else
					result = doc.DocumentNode.Descendants(descendants);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return result;
		}
	}
}
