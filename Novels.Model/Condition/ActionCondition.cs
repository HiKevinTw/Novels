namespace Novels.Model
{
    /// <summary>
    /// 動作條件
    /// </summary>
    /// <typeparam name="TAction">動作型別</typeparam>
    public abstract class ActionCondition<TAction> where TAction : struct
    {
        /// <summary>
        /// 動作
        /// </summary>
        public abstract TAction Action { get; }
    }
}
