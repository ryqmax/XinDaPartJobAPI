

using System;

namespace FrameWork.Entity.Model.Course
{
    public class CourseDetailModel
    {
        /// <summary>
        /// 视频id
        /// </summary>
        public int VideoId { set; get; }

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
        /// 小节视频id
        /// </summary>
        public float Price { set; get; }

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
        /// 视频讲义
        /// </summary>
        public string Lecture { set; get; }

        /// <summary>
        /// 讲师id
        /// </summary>
        public int TeacherId { set; get; }

        /// <summary>
        /// 讲师名字
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 讲师头衔
        /// </summary>
        public string TeacherTitle { set; get; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string TeacherImgPath { get; set; }

        /// <summary>
        /// 点赞数量
        /// </summary>
        public int PraiseCount { set; get; }

        /// <summary>
        /// 该用户点赞的数量
        /// </summary>
        public int UserPraiseCount { set; get; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        public int CollectCount { set; get; }

        /// <summary>
        /// 该用户收藏的数量
        /// </summary>
        public int UserCollectCount { set; get; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { set; get; }

        /// <summary>
        /// 该用户购买该视频的数量
        /// </summary>
        public int UserBuyCount { set; get; }

        /// <summary>
        /// 购买小节视频的数量
        /// </summary>
        public int BuyCount { set; get; }

        /// <summary>
        /// 观看视频的人数
        /// </summary>
        public int WatchingCount { set; get; }

        /// <summary>
        /// 章的序号
        /// </summary>
        public int ChapterSequence { set; get; }

        /// <summary>
        /// 小节序号
        /// </summary>
        public int SectionSequence { set; get; }

    }

    /// <summary>
    /// 相关的小节视频
    /// </summary>
    public class RelateVideoModel
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
        /// 视频路径
        /// </summary>
        public string VideoImgPath { set; get; }
    }
}
