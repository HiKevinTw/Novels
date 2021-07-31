namespace Novels.Log
{

	public delegate void ShowLogHandler(string level, string message);
	public class ShowLogAppender
	{
		public static ShowLogHandler ShowLogHandler { private get; set; }
		public static void LogMethod(string level, string message)
		{
			if (ShowLogHandler != null)
			{
				ShowLogHandler(level, message);
			}
		}
	}

}
