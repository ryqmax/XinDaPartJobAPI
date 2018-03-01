

using System;

namespace FrameWork.Entity.Model.Course
{
    public class CourseModel
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public int CategoryId { set; get; }

        /// <summary>
        /// 分类名字
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
        /// 课程图片
        /// </summary>
        public string Image { set; get; }

    }

    /// <summary>
    /// 课程新闻信息
    /// </summary>
    public class CourseNewsModel
    {
        /// <summary>
        /// 新闻id
        /// </summary>
        public int NewsId { set; get; }

        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { set; get; }
    }

    /// <summary>
    /// 付费课程下的视频
    /// </summary>
    public class CourseVideoModel
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 视频封面地址
        /// </summary>
        public string VideoImgPath { set; get; }

        /// <summary>
        /// 视频高清地址
        /// </summary>
        public string HighPath { set; get; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifyTime { set; get; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int BrowseCount { set; get; }

        /// <summary>
        /// 分类名字
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
        /// 小节id
        /// </summary>
        public int SectionId { set; get; }

        /// <summary>
        /// 小节描述
        /// </summary>
        public string SectionDesc { set; get; }

        /// <summary>
        /// 用户购买数量
        /// </summary>
        public int UserBuyCount { get; set; }

        /// <summary>
        /// 章的序号
        /// </summary>
        public int ChapterSequence { set; get; }

        /// <summary>
        /// 小节序号
        /// </summary>
        public int SectionSequence { set; get; }

    }
}
