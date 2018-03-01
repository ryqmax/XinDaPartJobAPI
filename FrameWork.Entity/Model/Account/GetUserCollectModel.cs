
using System;

namespace FrameWork.Entity.Model.Account
{
    /// <summary>
    /// 收藏的课程模型
    /// </summary>
    public class GetUserCollectCourseModel
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 小节视频名字
        /// </summary>
        public string SectionVideoName { set; get; }

        /// <summary>
        /// 视频封面地址
        /// </summary>
        public string VideoImgPath { set; get; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 章序号
        /// </summary>
        public int ChapterSequence { get; set; }

        /// <summary>
        /// 节序号
        /// </summary>
        public int SectionSequence { get; set; }

        /// <summary>
        /// 大类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 讲师名字
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 收藏记录的创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { set; get; }

        /// <summary>
        /// 总记录数量
        /// </summary>
        public int TotalCount { set; get; }
    }

    /// <summary>
    /// 收藏的资讯模型
    /// </summary>
    public class GetUserCollectNewsModel
    {
        /// <summary>
        /// 资讯id
        /// </summary>
        public int NewsId { set; get; }

        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 资讯摘要
        /// </summary>
        public string Summary { set; get; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { get; set; }

        /// <summary>
        /// 收藏记录的创建时间
        /// </summary>
        public DateTime CreateTime { set; get; }

        /// <summary>
        /// 总记录数量
        /// </summary>
        public int TotalCount { set; get; }
    }
}
