using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Model.Account;

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetUserCollectViewModel
    {
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool IsHaveNext { set; get; }

        /// <summary>
        /// 资讯列表
        /// </summary>
        public List<GetUserCollectNewsViewModel> NewsList = new List<GetUserCollectNewsViewModel>();

        /// <summary>
        /// 课程列表
        /// </summary>
        public List<GetUserCollectCourseViewModel> CourseList = new List<GetUserCollectCourseViewModel>();

        /// <summary>
        /// 获取视图模型数据
        /// </summary>
        public GetUserCollectViewModel GetViewModel(List<GetUserCollectCourseModel> courseModels, List<GetUserCollectNewsModel> newsModels, GetUserCollectRequest request)
        {
            var viewModel = new GetUserCollectViewModel();
            if (courseModels != null)
            {
                foreach (var model in courseModels)
                {
                    viewModel.CourseList.Add(new GetUserCollectCourseViewModel
                    {
                        CategoryName = model.CategoryName ?? string.Empty,
                        CreateTime = model.CreateTime.ToString("yyyy-MM-dd"),
                        IsFree = model.IsFree,
                        SectionVideoId = model.SectionVideoId,
                        SectionVideoName = model.SectionVideoName ?? string.Empty,
                        TeacherName = model.TeacherName ?? string.Empty,
                        VideoImgPath = PictureHelper.ConcatPicUrl(model.VideoImgPath),
                        SubSectionName = $"{model.CourseName}/第{model.ChapterSequence.NumberToChinese()}章/第{model.SectionSequence.NumberToChinese()}节"
                    });
                }
                if (courseModels.Any())
                {
                    viewModel.IsHaveNext = PageHelper.JudgeNextPage(courseModels.First().TotalCount, request.Page, request.PageSize);
                }
            }
            if (newsModels != null)
            {
                foreach (var model in newsModels)
                {
                    viewModel.NewsList.Add(new GetUserCollectNewsViewModel
                    {
                        CreateTime = model.CreateTime.ToString("yyyy-MM-dd"),
                        NewsTitle = model.Title,
                        IndustryName = model.IndustryName ?? string.Empty,
                        NewsId = model.NewsId,
                        Summary = model.Summary ?? string.Empty
                    });
                }
                if (newsModels.Any())
                {
                    viewModel.IsHaveNext = PageHelper.JudgeNextPage(newsModels.First().TotalCount, request.Page, request.PageSize);
                }
            }
            return viewModel;
        }
    }

    /// <summary>
    /// 获取收藏中心参数
    /// </summary>
    public class GetUserCollectRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 请求类型：1.课程，2.资讯
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int Page { set; get; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// 请求的类型
        /// </summary>
        public enum EnumRequestType
        {
            /// <summary>
            /// 请求课程
            /// </summary>
            Course = 1,

            /// <summary>
            /// 请求资讯
            /// </summary>
            News = 2
        }
    }

    /// <summary>
    /// 收藏的资讯模型
    /// </summary>
    public class GetUserCollectNewsViewModel
    {
        /// <summary>
        /// 资讯id
        /// </summary>
        public int NewsId { set; get; }

        /// <summary>
        /// 资讯标题
        /// </summary>
        public string NewsTitle { get; set; }

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
        public string CreateTime { set; get; }

    }

    /// <summary>
    /// 收藏的课程模型
    /// </summary>
    public class GetUserCollectCourseViewModel
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
        /// 小节子标题展示字段
        /// </summary>
        public string SubSectionName { set; get; }

        /// <summary>
        /// 视频封面地址
        /// </summary>
        public string VideoImgPath { set; get; }

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
        public string CreateTime { set; get; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { set; get; }

    }
}
