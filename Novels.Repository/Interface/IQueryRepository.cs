using Novels.Model;
using Novels.Repository.Interface.Utility;
using System.Collections.Generic;

namespace Novels.Repository.Interface
{
	/// <summary>
	/// 查詢資料物件 Repository
	/// </summary>
	/// <typeparam name="TEntity">資料物件型別</typeparam>
	public interface IQueryRepository<TEntity> where TEntity : DataModel
    {
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="queryObject">查詢物件</param>
        /// <param name="totalCount">查詢總筆數</param>
        /// <returns>查詢結果</returns>
        List<TEntity> Query(IQueryObject<TEntity> queryObject, out int totalCount);

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="keyValues">主索引</param>
        /// <returns>資料物件，若無值回傳 null</returns>
        TEntity QueryByKey(params object[] keyValues);
    }
}
