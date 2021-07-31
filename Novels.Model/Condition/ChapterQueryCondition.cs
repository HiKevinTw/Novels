namespace Novels.Model
{
	public class ChapterQueryCondition
	{
		/// <summary>
		/// 編號
		/// </summary>
		public int? ID { get; set; }
		/// <summary>
		/// 名稱
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// 關鍵字
		/// </summary>
		public string Keyword { get; set; }
	}
}
