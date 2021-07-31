using LinqKit;
using Novels.Model;
using Novels.Repository.Interface.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Novels.Repository.Utility
{
	public sealed class QueryObject<TEntity> : IQueryObject<TEntity> where TEntity : DataModel
    {
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private set; }

        public Expression<Func<TEntity, bool>> QueryExpression { get; private set; }

        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; private set; }

        public int? Page { get; private set; }

        public int? PageSize { get; private set; }

        public void Include(Expression<Func<TEntity, object>> includeExpression)
        {
            if (this.IncludeExpressions == null)
            {
                this.IncludeExpressions = new List<Expression<Func<TEntity, object>>>();
            }

            this.IncludeExpressions.Add(includeExpression);
        }

        public void And(Expression<Func<TEntity, bool>> queryExpression)
        {
            if (this.QueryExpression == null)
            {
                this.QueryExpression = queryExpression;
            }
            else
            {
                this.QueryExpression = this.QueryExpression.And(queryExpression.Expand());
            }
        }

        public void Sort(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            this.OrderBy = orderBy;
        }

        public void Paging(int page, int pageSize)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }

        public void Reset()
        {
            this.IncludeExpressions = null;
            this.QueryExpression = null;
            this.OrderBy = null;
            this.Page = null;
            this.PageSize = null;
        }
    }
}
