using Novels.Model;

namespace Novels.Service.Interface
{
	public interface INovelService
	{
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="condition">查詢條件</param>
        /// <returns>查詢回傳結果</returns>
        QueryServiceResult<Novel> Query(NovelQueryCondition condition);

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新建回傳結果</returns>
        ServiceResult Create(Novel model);        

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改回傳結果</returns>
        ServiceResult Modify(Novel model);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="model"></param>
        /// <returns>移除回傳結果</returns>
        ServiceResult Remove(Novel model);
    }
}
