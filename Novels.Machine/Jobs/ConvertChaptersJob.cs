using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Novels.Machine.App_Code;
using Novels.Machine.App_Start;
using Novels.Model;

namespace Novels.Machine.Jobs
{
	sealed class ConvertChaptersJob : Job
	{
		private DateTime latestExecutionTime;
		private bool isWorking;
		private bool stopWorking;

		private List<Novel> novels;

		public ConvertChaptersJob(List<Novel> novels)
		{
			this.novels = novels;
		}

		public override bool IsExecuting
		{
			get { return this.isWorking; }
		}

		public override void Start()
		{
			this.isWorking = true;
			this.stopWorking = false;
			this.latestExecutionTime = DateTime.Now;

			Task.Run(() => this.Polling());
		}

		public override void Stop()
		{
			this.stopWorking = true;
			this.isWorking = false;
		}

		protected override void Work(params object[] args)
		{
			var infoString = string.Empty;

			try
			{
				var chapterService = DB.Chapter;

				foreach (var novel in novels)
				{
					infoString = string.Format("【轉換 - {0}】", novel.Name);
					Log.Info(string.Format("{0}啟動。", infoString));

					var Links = Util.GetDirs(novel);

					if (Links.Count == 0)
					{
						throw new Exception("取得連結目錄失敗。");
					}

					var workDirs = Links.Where(x => novel.Chapters.FindIndex(y => y.Title == x.Key) == -1);

					// 沒用過的目錄
					foreach (var item in workDirs)
					{
						var queryResult = chapterService.Query(new ChapterQueryCondition());

						if (queryResult.Kind != ResultKind.Success)
							throw new Exception(string.Format("查詢資料發生錯誤：{0}。", queryResult.Message));

						var id = queryResult.TotalCount == 0 ? 1 : queryResult.QueryResult.Max(x => x.ID) + 1;

						var chapter = new Chapter()
						{
							ID = id,
							NovelID = novel.ID,
							Sort = novel.Chapters.Count + 1,
							Title = item.Key,
							WebLink = item.Value
						};

						var createResult = chapterService.Create(chapter);

						if (createResult.Kind == ResultKind.Success)
						{
							novel.Chapters.Add(chapter);
							Log.Info(string.Format("{0}，建立【{1}】資料成功。", infoString, chapter.Title));
						}
						else
						{
							throw new Exception(string.Format("建立【{0}】資料失敗 ：", chapter.Title));
						}
					}

					// 已存檔的章節，但沒內文
					var chapters = novel.Chapters.Where(x => string.IsNullOrEmpty(x.Content) && !string.IsNullOrEmpty(x.WebLink)).ToList();

					foreach (var item in chapters)
					{
						string content = string.Empty;

						try
						{
							content = Util.GetChapterContent(novel, item.WebLink);
						}
						catch (Exception ex2)
						{
							Log.Error(string.Format("連結發生錯誤，{0}無法取得網頁：{1}，原因；{2}。", item.Title, Util.GetContentURL(novel, item.WebLink)), ex2.Message);

							continue;
						}

						if (string.IsNullOrEmpty(content))
						{
							Log.Error(string.Format("連結發生錯誤，{0}無法自動讀取內文：{1}。", item.Title, Util.GetContentURL(novel, item.WebLink)));

							continue;
						}

						item.Content = content;

						item.Ver();

						var createResult = chapterService.Modify(item);

						if (createResult.Kind == ResultKind.Success)
						{
							Log.Info(string.Format("{0}，更新【{1}】資料成功。", infoString, item.Title));
						}
						else
						{
							Log.Error(string.Format("更新【{0}】【{1}】資料失敗 ：", item.Title, item.WebLink));
						}
					}


					Log.Info(string.Format("{0}完成。", infoString));
				}
			}
			catch (Exception ex)
			{
				Log.Error(string.Format("{0}因發生不可預期例外而終止，例外狀況：{1}。", infoString, ex.Message));
			}
		}

		private void Polling()
		{
			while (!this.stopWorking)
			{
				// 超過預定的執行區間才執行工作
				if (DateTime.Now.Subtract(this.latestExecutionTime).TotalSeconds >= 5)
				{
					this.latestExecutionTime = DateTime.Now;

					this.Work();
				}

				Thread.Sleep(1000);
			}

			this.isWorking = false;
		}
	}
}
