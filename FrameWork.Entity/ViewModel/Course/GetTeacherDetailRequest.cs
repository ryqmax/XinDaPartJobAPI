

namespace FrameWork.Entity.ViewModel.Course
{
    public class GetTeacherDetailRequest
    {
        /// <summary>
        /// 讲师id
        /// </summary>
        public int TeacherId { set; get; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int Page { set; get; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

    }
}
