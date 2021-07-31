using Novels.Model;

namespace Novels.Service.Interface
{
	public interface IHtmlRuleService
	{
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="condition">查詢條件</param>
        /// <returns>查詢回傳結果</returns>
        QueryServiceResult<HtmlRule> Query(HtmlRuleQueryCondition condition);

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新建回傳結果</returns>
        ServiceResult Create(HtmlRule model);        

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改回傳結果</returns>
        ServiceResult Modify(HtmlRule model);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="model"></param>
        /// <returns>移除回傳結果</returns>
        ServiceResult Remove(HtmlRule model);
    }
}
