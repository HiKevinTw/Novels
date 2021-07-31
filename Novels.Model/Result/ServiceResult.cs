namespace Novels.Model
{
    /// <summary>
    /// 回傳結果
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// 結果種類
        /// </summary>
        public ResultKind Kind { get; set; }

        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; }
    }
}
