using Novels.Model;
using Novels.Repository.Interface;

namespace Novels.Repository
{
	public sealed class CreateRepository<TEntity> : ICreateRepository<TEntity> where TEntity : DataModel
    {
        public void Create(TEntity model)
        {
			using (var context = DataContext.GetContext())
			{
				context.Set<TEntity>().Add(model);
				context.SaveChanges();
			}
		}
    }
}
