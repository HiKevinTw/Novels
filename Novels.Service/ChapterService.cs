using Novels.Service.Interface;
using Novels.Model;
using Novels.Repository.Interface;
using Novels.Repository.Interface.Utility;

namespace Novels.Service
{
	public sealed class ChapterService : IChapterService
	{
		private readonly IQueryObject<Chapter> queryObject;
		private readonly IQueryRepository<Chapter> queryRepository;
		private readonly ICreateRepository<Chapter> createRepository;
		private readonly IUpdateRepository<Chapter> updateRepository;
		private readonly IDeleteRepository<Chapter> deleteRepository;

		public ChapterService(
			IQueryObject<Chapter> queryObject,
			IQueryRepository<Chapter> queryRepository,
			ICreateRepository<Chapter> createRepository,
			IUpdateRepository<Chapter> updateRepository,
			IDeleteRepository<Chapter> deleteRepository)
		{
			this.createRepository = createRepository;
			this.queryRepository = queryRepository;
			this.queryObject = queryObject;
			this.updateRepository = updateRepository;
			this.deleteRepository = deleteRepository;
		}

		public QueryServiceResult<Chapter> Query(ChapterQueryCondition condition)
		{
			var result = new QueryServiceResult<Chapter>();

			if (condition.ID.HasValue)
			{
				this.queryObject.And(d => d.ID == condition.ID);
			}

			if (!string.IsNullOrEmpty(condition.Name))
			{
				this.queryObject.And(d => d.Title == condition.Name);
			}

			if (!string.IsNullOrEmpty(condition.Keyword))
			{
				this.queryObject.And(d => d.Title.Contains(condition.Keyword));
			}

			int totalCount;

			result.QueryResult = this.queryRepository.Query(this.queryObject, out totalCount);
			result.TotalCount = totalCount;

			this.queryObject.Reset();

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Create(Chapter model)
		{
			var result = new ServiceResult();

			if (this.queryRepository.QueryByKey(model.ID) != null)
			{
				result.Kind = ResultKind.Failed;
				result.Message =
					string.Format(
						"【{0}】已存在，無法新建！",
						model.Title);

				return result;
			}

			this.createRepository.Create(model);

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Modify(Chapter model)
		{
			var result = new ServiceResult();

			if (this.queryRepository.QueryByKey(model.ID) == null)
			{
				result.Kind = ResultKind.Failed;
				result.Message =
					string.Format(
						"【{0}】不存在，無法修改！",
						model.Title);

				return result;
			}

			this.updateRepository.Update(model);

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Remove(Chapter model)
		{
			var result = new ServiceResult();

			var condition =
				new ChapterQueryCondition()
				{
					ID = model.ID,
					Name = model.Title
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
						model.Title);

				return result;
			}

			this.deleteRepository.Delete(model);

			result.Kind = ResultKind.Success;

			return result;
		}
	}
}
