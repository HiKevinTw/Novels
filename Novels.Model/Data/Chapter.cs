using System;
using System.ComponentModel.DataAnnotations;

namespace Novels.Model
{
	/// <summary>
	/// 內文
	/// </summary>
	public class Chapter : DataModel
	{
		/// <summary>
		/// 編號
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Sort { get; set; }

		/// <summary>
		/// 標題
		/// </summary>
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		/// <summary>
		/// 內文
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 來源網址
		/// </summary>
		public string WebLink { get; set; }

		/// <summary>
		/// 更新時間
		/// </summary>
		public DateTime UpdateTime { get; set; }

		/// <summary>
		/// 上層編號
		/// </summary>
		public int NovelID { get; set; }
		public virtual Novel Novel { get; set; }
	}
}
