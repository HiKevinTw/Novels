using NLog;

namespace Novels.Machine.Jobs
{
	delegate void ExitHandler();
	abstract class Job
	{
		public Job()
		{
			this.Log = LogManager.GetLogger(this.GetType().ToString());
		}

		public abstract bool IsExecuting { get; }

		protected Logger Log { get; private set; }

        /// <summary>
        /// 開始
        /// </summary>
        public abstract void Start();

		/// <summary>
		/// 停止
		/// </summary>

		public abstract void Stop();

		/// <summary>
		/// 作業
		/// </summary>
		/// <param name="args"></param>

		protected abstract void Work(params object[] args);
        
    }
}
