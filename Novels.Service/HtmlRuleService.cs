using Novels.Service.Interface;
using Novels.Model;
using Novels.Repository.Interface;
using Novels.Repository.Interface.Utility;
using System.Linq;

namespace Novels.Service
{
	public sealed class HtmlRuleService : IHtmlRuleService
	{
		private readonly IQueryObject<HtmlRule> queryObject;
		private readonly IQueryRepository<HtmlRule> queryRepository;
		private readonly ICreateRepository<HtmlRule> createRepository;
		private readonly IUpdateRepository<HtmlRule> updateRepository;
		private readonly IDeleteRepository<HtmlRule> deleteRepository;

		public HtmlRuleService(
			IQueryObject<HtmlRule> queryObject,
			IQueryRepository<HtmlRule> queryRepository,
			ICreateRepository<HtmlRule> createRepository,
			IUpdateRepository<HtmlRule> updateRepository,
			IDeleteRepository<HtmlRule> deleteRepository)
		{
			this.createRepository = createRepository;
			this.queryRepository = queryRepository;
			this.queryObject = queryObject;
			this.updateRepository = updateRepository;
			this.deleteRepository = deleteRepository;
		}

		public QueryServiceResult<HtmlRule> Query(HtmlRuleQueryCondition condition)
		{
			var result = new QueryServiceResult<HtmlRule>();

			if (condition.ID.HasValue)
			{
				this.queryObject.And(d => d.ID == condition.ID);
			}

			if (!string.IsNullOrEmpty(condition.Name))
			{
				this.queryObject.And(d => d.Name == condition.Name);
			}

			if (!string.IsNullOrEmpty(condition.Keyword))
			{
				this.queryObject.And(d => d.Name.Contains(condition.Keyword));
			}

			int totalCount;

			this.queryObject.Sort(x => x.OrderBy(y => y.Sort)); // Order By

			result.QueryResult = this.queryRepository.Query(this.queryObject, out totalCount);

			result.TotalCount = totalCount;

			this.queryObject.Reset();

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Create(HtmlRule model)
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

		public ServiceResult Modify(HtmlRule model)
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

			this.updateRepository.Update(model);

			result.Kind = ResultKind.Success;

			return result;
		}

		public ServiceResult Remove(HtmlRule model)
		{
			var result = new ServiceResult();

			var condition =
				new HtmlRuleQueryCondition()
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
