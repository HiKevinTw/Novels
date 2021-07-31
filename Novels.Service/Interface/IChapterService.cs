using Novels.Model;

namespace Novels.Service.Interface
{
	public interface IChapterService
	{
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="condition">查詢條件</param>
        /// <returns>查詢回傳結果</returns>
        QueryServiceResult<Chapter> Query(ChapterQueryCondition condition);

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新建回傳結果</returns>
        ServiceResult Create(Chapter model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改回傳結果</returns>
        ServiceResult Modify(Chapter model);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="model"></param>
        /// <returns>移除回傳結果</returns>
        ServiceResult Remove(Chapter model);
    }
}
