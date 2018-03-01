
namespace FrameWork.Common
{
    public class PageHelper
    {
        /// <summary>
        /// 判断是否还有下一页
        /// </summary>
        /// <param name="totalNum">总页数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页的条数</param>
        /// <returns>true表示还有下一页</returns>
        public static bool JudgeNextPage(int totalNum, int currentPage, int pageSize)
        {
            int pagenum = 0;
            if (pageSize > 0)
            {
                pagenum = totalNum / pageSize;
                if (totalNum % pageSize > 0)
                    pagenum += 1;
            }
            if (pagenum > currentPage)
                return true;
            return false;
        }
    }
}
