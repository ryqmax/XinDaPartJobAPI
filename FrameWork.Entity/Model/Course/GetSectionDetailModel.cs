

using System;

namespace FrameWork.Entity.Model.Course
{
    public class GetSectionDetailModel
    {
        /// <summary>
        /// 大类名字
        /// </summary>
        public string CategoryName { set; get; }

        /// <summary>
        /// 课程名字
        /// </summary>
        public string CourseName { set; get; }

        /// <summary>
        /// 课程Id
        /// </summary>
        public string CourseId { set; get; }

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
        /// 是否免费
        /// </summary>
        public bool IsFree { get; set; }

        /// <summary>
        /// 小节描述
        /// </summary>
        public string SectionDesc { set; get; }

        /// <summary>
        /// 讲师id
        /// </summary>
        public int TeacherId { set; get; }

        /// <summary>
        /// 章的序号
        /// </summary>
        public int ChapterSequence { set; get; }

        /// <summary>
        /// 小节序号
        /// </summary>
        public int SectionSequence { set; get; }

        /// <summary>
        /// 讲师名字
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string TeacherImg { set; get; }

        /// <summary>
        /// 讲师头衔
        /// </summary>
        public string TeacherTitle { set; get; }

        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 视频封面
        /// </summary>
        public string VideoImgPath { set; get; }

        /// <summary>
        /// 视频地址
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
        /// 小节视频价格
        /// </summary>
        public float Price { set; get; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { set; get; }

        /// <summary>
        /// 该用户购买的数量
        /// </summary>
        public int UserBuyCount { set; get; }

    }
}
