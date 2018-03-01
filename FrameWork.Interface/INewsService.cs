using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Course;

namespace FrameWork.Interface
{
    public interface INewsService : IBaseService<T_News>
    {
        /// <summary>
        /// 获取首页免费视频列表
        /// </summary>
        /// <returns></returns>
        List<NewsModelForList> GetNewsList(int industryId, int currentPage, int pageSize);

        /// <summary>
        /// 获取文章详情
        /// </summary>
        NewsDetailsModel GetArticleDetail(int articleId, int userId);

        /// <summary>
        /// 收藏文章
        /// </summary>
        int CollectNews(int articleId, int userId, bool up);

        /// <summary>
        /// 点赞文章
        /// </summary>
        int UpvoteNews(int articleId, int userId, bool up);

        /// <summary>
        /// 分享文章
        /// </summary>
        int ShareNews(int articleId);
    }
}
