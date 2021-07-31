namespace Novels.Model
{
    /// <summary>
    /// 物件回傳結果
    /// </summary>
    /// <typeparam name="TEntity">物件型別</typeparam>
    public sealed class EntityServiceResult<TEntity> : ServiceResult
    {
        /// <summary>
        /// 物件
        /// </summary>
        public TEntity Result { get; set; }
    }
}
