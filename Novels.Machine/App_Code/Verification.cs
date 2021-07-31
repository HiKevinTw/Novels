using Novels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novels.Machine.App_Code
{
	public static class Verification // Ver
	{
		static Dictionary<string, string> WordDictionary = new Dictionary<string, string>();

		static Verification() {
			WordDictionary.Add("&nbsp;", " ");
			WordDictionary.Add("&emsp;", " ");
		}

		public static void Ver(this HtmlRule htmlRule)
		{
		
		}

		public static void Ver(this Novel novel)
		{
			if (novel.ContentLinkMode == 2 && string.IsNullOrEmpty(novel.ContentLink))
				throw new Exception("ContentLink Error!");

			novel.UpdateTime = DateTime.Now;

		}

		public static void Ver(this Chapter chapter)
		{

			chapter.Content = chapter.Content.VerWord();

			chapter.UpdateTime = DateTime.Now;
		}

		public static string VerWord(this string str)
		{
			foreach (var item in WordDictionary)
			{
				str = str.Replace(item.Key, item.Value);
			}

			return str;
		}
	}
}
