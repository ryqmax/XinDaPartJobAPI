

using System;
using System.Collections.Generic;
using System.Linq;
using FrameWork.Common;
using FrameWork.Entity.Model.Account;

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetMyCourseListViewModel
    {
        /// <summary>
        /// 是否还有下一页
        /// </summary>
        public bool IsEnd { set; get; }

        /// <summary>
        /// 我的课程视频列表
        /// </summary>
        public List<MyCourseViewModel> VideoList = new List<MyCourseViewModel>();

        /// <summary>
        /// 获取视图模型数据
        /// </summary>
        public GetMyCourseListViewModel GetViewModel(List<GetMyCourseListModel> models, GetMyCourseListRequest request)
        {
            var viewModel = new GetMyCourseListViewModel();
            if (models.Any())
            {
                var item = models.First();
                viewModel.IsEnd = (item.TotalCount + request.PageSize - 1) / request.PageSize <= request.Page;
                foreach (var model in models)
                {
                    viewModel.VideoList.Add(new MyCourseViewModel
                    {
                        CategoryName = StringHelper.NullOrEmpty(model.CategoryName),
                        CourseId = model.CourseId,
                        ChapterName = StringHelper.NullOrEmpty(model.ChapterName),
                        CourseName = StringHelper.NullOrEmpty(model.CourseName),
                        LastWatchTime = DateTimeHelper.GetDateTime(model.LastWatchTime),
                        SectionName = StringHelper.NullOrEmpty(model.SectionName),
                        SectionVideoId = model.SectionVideoId,
                        TeacherName = StringHelper.NullOrEmpty(model.TeacherName),
                        VideoImgPath = PictureHelper.ConcatPicUrl(model.VideoImgPath),
                        LeftDay = GetLeftDay(model)
                    });
                }
            }
            return viewModel;
        }

        public int GetLeftDay(GetMyCourseListModel model)
        {
            var leftDay = 0;
            if (model.BuyTime.HasValue)
            {
                leftDay = model.ValidateDay - (DateTime.Now.Day - model.BuyTime.Value.Day) + 1;
            }

            return leftDay;
        }
    }

    /// <summary>
    /// 我的课程视频模型
    /// </summary>
    public class MyCourseViewModel
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
        public string LastWatchTime { set; get; }

        /// <summary>
        /// 剩余有效期天数
        /// </summary>
        public int LeftDay { set; get; }

    }
}
