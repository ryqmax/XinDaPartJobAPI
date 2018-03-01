

namespace FrameWork.Entity.ViewModel.Course
{
    public class GetCourseDetailRequest
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { set; get; }
    }
}
