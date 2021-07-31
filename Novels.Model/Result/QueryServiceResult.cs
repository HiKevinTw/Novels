using System.Collections.Generic;

namespace Novels.Model
{
	/// <summary>
	/// 查詢回傳結果
	/// </summary>
	/// <typeparam name="TEntity">資料物件型別</typeparam>
	public sealed class QueryServiceResult<TEntity> : ServiceResult where TEntity : DataModel
    {
        /// <summary>
        /// 資料物件集合
        /// </summary>
        public List<TEntity> QueryResult { get; set; }

        /// <summary>
        /// 查詢總筆數
        /// </summary>
        public int TotalCount { get; set; }
    }
}
