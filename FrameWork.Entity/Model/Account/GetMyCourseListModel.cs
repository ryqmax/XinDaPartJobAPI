

using System;

namespace FrameWork.Entity.Model.Account
{
    public class GetMyCourseListModel
    {
        /// <summary>
        /// 大类名字
        /// </summary>
        public string CategoryName { set; get; }

        /// <summary>
        /// 课程id
        /// </summary>
        public int CourseId { set; get; }

        /// <summary>
        /// 课程名字
        /// </summary>
        public string CourseName { set; get; }

        /// <summary>
        /// 章名字
        /// </summary>
        public string ChapterName { set; get; }

        /// <summary>
        /// 小节名字
        /// </summary>
        public string SectionName { set; get; }

        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 视频封面
        /// </summary>
        public string VideoImgPath { set; get; }

        /// <summary>
        /// 讲师名字
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 上次观看时间
        /// </summary>
        public DateTime? LastWatchTime { set; get; }

        /// <summary>
        /// 购买这门课程的时间
        /// </summary>
        public DateTime? BuyTime { set; get; }

        /// <summary>
        /// 有效期天数
        /// </summary>
        public int ValidateDay { set; get; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { set; get; }

    }
}
