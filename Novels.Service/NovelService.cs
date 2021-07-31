using Novels.Service.Interface;
using Novels.Model;
using Novels.Repository.Interface;
using Novels.Repository.Interface.Utility;
using System;
using System.Linq;

namespace Novels.Service
{
	public sealed class NovelService : INovelService
	{
		private readonly IQueryObject<Novel> queryObject;
		private readonly IQueryRepository<Novel> queryRepository;
		private readonly ICreateRepository<Novel> createRepository;
		private readonly IUpdateRepository<Novel> updateRepository;
		private readonly IDeleteRepository<Novel> deleteRepository;

		public NovelService(
			IQueryObject<Novel> queryObject,
			IQueryRepository<Novel> queryRepository,
			ICreateRepository<Novel> createRepository,
			IUpdateRepository<Novel> updateRepository,
			IDeleteRepository<Novel> deleteRepository)
		{
			this.createRepository = createRepository;
			this.queryRepository = queryRepository;
			this.queryObject = queryObject;
			this.updateRepository = updateRepository;
			this.deleteRepository = deleteRepository;
		}

		public QueryServiceResult<Novel> Query(NovelQueryCondition condition)
		{
			var result = new QueryServiceResult<Novel>();

			if (condition.ID.HasValue)
			{
				this.queryObject.And(d => d.ID == condition.ID);
			}

			if (!string.IsNullOrEmpty(condition.Name))
			{
				this.queryObject.And(d => d.Name == condition.Name);
			}

			if (condition.IsFinish.HasValue)
			{
				this.queryObject.And(d => d.IsFinish == condition.IsFinish);
			}

			if (!string.IsNullOrEmpty(condition.Keyword))
			{
				this.queryObject.And(d => d.Name.Contains(condition.Keyword));
			}

			int totalCount;

			this.queryObject.Include(x => x.HtmlRule);      // Include 1對1 Table

			this.queryObject.Include(x => x.Chapters);      // Include 1對多 Table

			this.queryObject.Sort(x => x.OrderBy(y => y.Sort)); // Order By

			result.QueryResult = this.queryRepository.Query(this.queryObject, out totalCount);

			result.QueryResult.ForEach(x => { x.Chapters = x.Chapters != null ? x.Chapters.OrderBy(y => y.Sort).ToList() : null; }); // Child Order By

			result.TotalCount = totalCount;

			this.queryObject.Reset();

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Create(Novel model)
		{
			var result = new ServiceResult();

			if (this.queryRepository.QueryByKey(model.ID) != null)
			{
				result.Kind = ResultKind.Failed;
				result.Message =
					string.Format(
						"【{0}】已存在，無法新建！",
						model.Name);

				return result;
			}

			this.createRepository.Create(model);

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Modify(Novel model)
		{
			var result = new ServiceResult();

			if (this.queryRepository.QueryByKey(model.ID) == null)
			{
				result.Kind = ResultKind.Failed;
				result.Message =
					string.Format(
						"【{0}】不存在，無法修改！",
						model.Name);

				return result;
			}

			foreach (var item in model.Chapters)
			{
				item.UpdateTime = DateTime.Now;
			}

			model.UpdateTime = DateTime.Now;

			this.updateRepository.Update(model);

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Remove(Novel model)
		{
			var result = new ServiceResult();

			var condition =
				new NovelQueryCondition()
				{
					ID = model.ID,
					Name = model.Name
				};

			var queryResult = this.Query(condition);

			if (queryResult.Kind != ResultKind.Success)
			{
				return queryResult;
			}

			if (queryResult.TotalCount == 0)
			{
				result.Kind = ResultKind.Failed;
				result.Message =
					string.Format(
						"【{0}】不存在，無法移除！",
						model.Name);

				return result;
			}

			this.deleteRepository.Delete(model);

			result.Kind = ResultKind.Success;

			return result;
		}
	}
}
