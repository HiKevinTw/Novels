using Novels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Novels.Repository.Interface.Utility
{
	/// <summary>
	/// 查詢物件
	/// </summary>
	/// <typeparam name="TEntity">資料物件型別</typeparam>
	public interface IQueryObject<TEntity> where TEntity : DataModel
    {
        /// <summary>
        /// 載入物件表達式集合
        /// </summary>
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }

        /// <summary>
        /// 查詢表達式
        /// </summary>
        Expression<Func<TEntity, bool>> QueryExpression { get; }

        /// <summary>
        /// 排序表達式
        /// </summary>
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; }

        /// <summary>
        /// 查詢頁數
        /// </summary>
        int? Page { get; }

        /// <summary>
        /// 分頁筆數
        /// </summary>
        int? PageSize { get; }

        /// <summary>
        /// 包含載入物件表達式
        /// </summary>
        /// <param name="includeExpression">載入物件表達式</param>
        void Include(Expression<Func<TEntity, object>> includeExpression);

        /// <summary>
        /// 附加查詢表達式
        /// </summary>
        /// <param name="queryExpression">查詢表達式</param>
        void And(Expression<Func<TEntity, bool>> queryExpression);

        /// <summary>
        /// 排序表達式
        /// </summary>
        /// <param name="orderBy">排序表達式</param>
        void Sort(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="page">查詢頁數</param>
        /// <param name="pageSize">分頁筆數</param>
        void Paging(int page, int pageSize);

        /// <summary>
        /// 重置查詢物件
        /// </summary>
        void Reset();
    }
}
