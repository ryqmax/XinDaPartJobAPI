

using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.Course
{
    public class GetPayCourseListViewModel
    {
        /// <summary>
        /// 轮播图列表
        /// </summary>
        public List<BannerViewModel> BannerList = new List<BannerViewModel>();

        /// <summary>
        /// 分类列表
        /// </summary>
        public List<CategoryViewModel> CategoryList = new List<CategoryViewModel>();

        /// <summary>
        /// 资讯列表
        /// </summary>
        public List<NewsViewModel> NewsViewModelList = new List<NewsViewModel>();

        /// <summary>
        /// 视频列表
        /// </summary>
        public List<CourseVideoViewModel> VideoViewModelList = new List<CourseVideoViewModel>();
    }

    /// <summary>
    /// 轮播图viewmodel
    /// </summary>
    public class BannerViewModel
    {
        /// <summary>
        /// 轮播图id
        /// </summary>
        public int BannerId { set; get; }

        /// <summary>
        /// 轮播图地址
        /// </summary>
        public string BannerUrl { set; get; }
    }

    /// <summary>
    /// 分类模型
    /// </summary>
    public class CategoryViewModel
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
        /// 课程列表
        /// </summary>
        public List<CourseViewModel> CourseViewModelList = new List<CourseViewModel>();
    }

    /// <summary>
    /// 课程模型
    /// </summary>
    public class CourseViewModel
    {
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
    /// 资讯模型
    /// </summary>
    public class NewsViewModel
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
    /// 课程视频列表
    /// </summary>
    public class CourseVideoViewModel
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
        public string ModifyTime { set; get; }

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
        /// 拼接的小节名字
        /// </summary>
        public string SubSctionName { get; set; } = string.Empty;

        /// <summary>
        /// 小节id
        /// </summary>
        public int SectionId { set; get; }

        /// <summary>
        /// 小节描述
        /// </summary>
        public string SectionDesc { set; get; }

        /// <summary>
        /// 是否购买
        /// </summary>
        public bool IsBuy { set; get; }

    }
}
