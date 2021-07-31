using Novels.Model;

namespace Novels.Repository.Interface
{
    /// <summary>
    /// 刪除資料物件 Repository
    /// </summary>
    /// <typeparam name="TEntity">資料物件型別</typeparam>
    public interface IDeleteRepository<TEntity> where TEntity : DataModel
    {
        /// <summary>
        /// 刪除資料物件
        /// </summary>
        /// <param name="model">資料物件</param>
        void Delete(TEntity model);
    }
}
