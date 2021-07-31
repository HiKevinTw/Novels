using LinqKit;
using Novels.Model;
using Novels.Repository.Interface;
using Novels.Repository.Interface.Utility;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Novels.Repository
{
    public sealed class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : DataModel
    {
        public List<TEntity> Query(IQueryObject<TEntity> queryObject, out int totalCount)
        {
            using (var context = DataContext.GetContext())
            {                  
                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();

                IQueryable<TEntity> totalCountQuery = context.Set<TEntity>().AsNoTracking();

				if (queryObject.IncludeExpressions != null)
				{
					query = queryObject.IncludeExpressions.Aggregate(query, (current, include) => current.Include(include));
				}

				if (queryObject.OrderBy != null)
				{
					query = queryObject.OrderBy(query);
				}

				if (queryObject.QueryExpression != null)
				{
					totalCountQuery = totalCountQuery.AsExpandable().Where(queryObject.QueryExpression);
					query = query.AsExpandable().Where(queryObject.QueryExpression);
				}

				if (queryObject.Page.HasValue && queryObject.PageSize.HasValue)
				{
					query = query.Skip((queryObject.Page.Value - 1) * queryObject.PageSize.Value).Take(queryObject.PageSize.Value);
				}

				totalCount = totalCountQuery.Count();

                return query.ToList();
            }
        }

        public TEntity QueryByKey(params object[] keyValues)
        {
            using (var context = DataContext.GetContext())
            {
                return context.Set<TEntity>().Find(keyValues);
            }
        }
    }
}
