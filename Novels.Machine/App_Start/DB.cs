using Novels.Model;
using Novels.Repository;
using Novels.Repository.Interface;
using Novels.Repository.Interface.Utility;
using Novels.Repository.Utility;
using Novels.Service;
using Novels.Service.Interface;
using SimpleInjector;

namespace Novels.Machine.App_Start
{
	/// <summary>
	/// SimpleInjector
	/// </summary>
	public static class DB
	{
		private static Container container;

		public static IHtmlRuleService HtmlRule { get { return container.GetInstance<IHtmlRuleService>(); } }

		public static INovelService Novel { get { return container.GetInstance<INovelService>(); } }

		public static IChapterService Chapter { get { return container.GetInstance<IChapterService>(); } }

		static DB()
		{
			if (container == null)
			{
				container = RegisterServices();
			}
		}

		private static Container RegisterServices()
		{
			var container = new Container();

			//註冊 HtmlRuleService
			container.Register<IHtmlRuleService, HtmlRuleService>();
			container.Register<IQueryObject<HtmlRule>, QueryObject<HtmlRule>>();
			container.Register<IQueryRepository<HtmlRule>, QueryRepository<HtmlRule>>();
			container.Register<ICreateRepository<HtmlRule>, CreateRepository<HtmlRule>>();
			container.Register<IUpdateRepository<HtmlRule>, UpdateRepository<HtmlRule>>();
			container.Register<IDeleteRepository<HtmlRule>, DeleteRepository<HtmlRule>>();
			container.Register<HtmlRuleService>();

			//註冊 NovelService
			container.Register<INovelService, NovelService>();
			container.Register<IQueryObject<Novel>, QueryObject<Novel>>();
			container.Register<IQueryRepository<Novel>, QueryRepository<Novel>>();
			container.Register<ICreateRepository<Novel>, CreateRepository<Novel>>();
			container.Register<IUpdateRepository<Novel>, UpdateRepository<Novel>>();
			container.Register<IDeleteRepository<Novel>, DeleteRepository<Novel>>();
			container.Register<NovelService>();

			//註冊 ChapterService
			container.Register<IChapterService, ChapterService>();
			container.Register<IQueryObject<Chapter>, QueryObject<Chapter>>();
			container.Register<IQueryRepository<Chapter>, QueryRepository<Chapter>>();
			container.Register<ICreateRepository<Chapter>, CreateRepository<Chapter>>();
			container.Register<IUpdateRepository<Chapter>, UpdateRepository<Chapter>>();
			container.Register<IDeleteRepository<Chapter>, DeleteRepository<Chapter>>();
			container.Register<ChapterService>();

			return container;
		}

	}
}
