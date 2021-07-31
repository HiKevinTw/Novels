namespace Novels.Repository.Interface.Utility
{
	public interface IConfig
	{
		string Novels_SqlConnection { get; }

        /// <summary>
        /// 動作佇列 Uri
        /// </summary>
        /// <typeparam name="TAction">動作型別</typeparam>
        /// <param name="action">動作</param>
        /// <returns>動作佇列 Uri</returns>
        string ActionQueueUri<TAction>(TAction action) where TAction : struct;
    }
}
