

namespace FrameWork.Entity.Model.Course
{
    public class GetCourseMenuListModel
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
        /// 章id
        /// </summary>
        public int ChapterId { set; get; }

        /// <summary>
        /// 章节序号
        /// </summary>
        public int ChapterSequence { get; set; }

        /// <summary>
        /// 章名字
        /// </summary>
        public string ChapterName { set; get; }

        /// <summary>
        /// 小节id
        /// </summary>
        public int SectionId { set; get; }

        /// <summary>
        /// 小节的序号
        /// </summary>
        public int SectionSequence { get; set; }

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
