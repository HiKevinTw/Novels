using Novels.Model;
using Novels.Repository.Interface;
using System.Data.Entity;

namespace Novels.Repository
{
    public sealed class DeleteRepository<TEntity> : IDeleteRepository<TEntity> where TEntity : DataModel
    {
        public void Delete(TEntity model)
        {
            using (var context = DataContext.GetContext())
            {
                context.Entry<TEntity>(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
