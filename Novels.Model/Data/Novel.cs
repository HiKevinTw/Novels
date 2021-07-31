using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Novels.Model
{
	public class Novel : DataModel
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

		/// <summary>
		/// 作者
		/// </summary>
		[Required]
		[MaxLength(100)]
		public string Author { get; set; }

		/// <summary>
		/// 來源網址
		/// </summary>
		public string WebLink { get; set; }

		/// <summary>
		/// 內容鏈結
		/// </summary>
		public string ContentLink { get; set; }

		/// <summary>
		/// 內容鏈結模式
		/// </summary>
		public int ContentLinkMode { get; set; }

		/// <summary>
		/// 更新時間
		/// </summary>
		public DateTime UpdateTime { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Sort { get; set; }

		public int IsFinish { get; set; }

		public int HtmlRuleID { get; set; }


		public virtual HtmlRule HtmlRule { get; set; }
		/// <summary>
		/// 內文
		/// </summary>
		public virtual List<Chapter> Chapters { get; set; }
	}
}
