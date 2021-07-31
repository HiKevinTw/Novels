namespace Novels.Model
{
    /// <summary>
    /// 結果種類
    /// </summary>
    public enum ResultKind
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 警告
        /// </summary>
        Warning = 2,

        /// <summary>
        /// 失敗
        /// </summary>
        Failed = 3,

        /// <summary>
        /// 例外
        /// </summary>
        Exception = 4,
    }
}
