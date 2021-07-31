using Novels.Model;
using Novels.Repository.Interface;
using System.Data.Entity;

namespace Novels.Repository
{
	public sealed class UpdateRepository<TEntity> : IUpdateRepository<TEntity> where TEntity : DataModel
	{
		public void Update(TEntity model)
		{
			using (var context = DataContext.GetContext())
			{
				context.Entry<TEntity>(model).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
