
using System;

namespace FrameWork.Entity.Model.Course
{
    public class GetTeacherDetailModel
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
        /// 章id
        /// </summary>
        public int ChapterId { set; get; }

        /// <summary>
        /// 章名字
        /// </summary>
        public string ChapterName { set; get; }

        /// <summary>
        /// 小节id
        /// </summary>
        public int SectionId { set; get; }

        /// <summary>
        /// 章节序号
        /// </summary>
        public int ChapterSequence { get; set; }
        
        /// <summary>
        /// 小节序号
        /// </summary>
        public int SectionSequence { get; set; }

        /// <summary>
        /// 小节名字
        /// </summary>
        public string SectionName { set; get; }

        /// <summary>
        /// 小节描述
        /// </summary>
        public string SectionDesc { set; get; }

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
        /// 浏览量
        /// </summary>
        public int BrowseCount { set; get; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifyTime { set; get; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int TotalCount { set; get; }

        /// <summary>
        /// 讲师描述
        /// </summary>
        public string TeacherDesc { set; get; }

        /// <summary>
        /// 讲师描述图片
        /// </summary>
        public string TeacherDescImgPath { set; get; }

        /// <summary>
        /// 该用户购买该视频的数量
        /// </summary>
        public int UserBuyCount { set; get; }
    }
}
