using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Novels.Model
{
	public class HtmlRule : DataModel
	{
		/// <summary>
		/// 編號
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// 名稱
		/// </summary>
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		public string SiteTitle { get; set; }

		public string ListXPath { get; set; }

		public string ListTag { get; set; }

		public string ListTagFilter { get; set; }

		public string TextXPath { get; set; }

		public string TextTag { get; set; }

		public string TextTagFilter { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Sort { get; set; }

		public virtual List<Novel> Novels { get; set; }
	}
}
