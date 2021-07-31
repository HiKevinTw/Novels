using Novels.Model;

namespace Novels.Repository.Interface
{
    /// <summary>
    /// 更新資料物件 Repository
    /// </summary>
    /// <typeparam name="TEntity">資料物件型別</typeparam>
    public interface IUpdateRepository<TEntity> where TEntity : DataModel
    {
        /// <summary>
        /// 更新資料物件
        /// </summary>
        /// <param name="model">資料物件</param>
        void Update(TEntity model);
    }
}
