

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetMyCourseListRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 行业id
        /// </summary>
        public int IndustryId { set; get; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int Page { set; get; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; }

    }
}
