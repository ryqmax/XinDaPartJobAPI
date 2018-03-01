

using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.Course
{
    /// <summary>
    /// 课程实体
    /// </summary>
    public class GetCourseMenuListViewModel
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
        /// 章列表
        /// </summary>
        public List<ChapterViewModel> ChapterList =new List<ChapterViewModel>();

    }

    /// <summary>
    /// 章实体
    /// </summary>
    public class ChapterViewModel
    {
        /// <summary>
        /// 章id
        /// </summary>
        public int ChapterId { set; get; }

        /// <summary>
        /// 章名字
        /// </summary>
        public string ChapterName { set; get; }

        /// <summary>
        /// 小节列表
        /// </summary>
        public List<SectionViewModel> SectionList = new List<SectionViewModel>();
    }

    /// <summary>
    /// 小节实体
    /// </summary>
    public class SectionViewModel
    {
        /// <summary>
        /// 小节id
        /// </summary>
        public int SectionId { set; get; }

        ///// <summary>
        ///// 小节的序号
        ///// </summary>
        //public string SectionSequence { get; set; }

        /// <summary>
        /// 小节名字
        /// </summary>
        public string SectionName { set; get; }

        /// <summary>
        /// 被考概率
        /// </summary>
        public int ExamRate { set; get; }
    }
}
