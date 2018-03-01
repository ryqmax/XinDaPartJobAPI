
using System.Collections.Generic;
using AutoMapper;
using FrameWork.Common;
using FrameWork.Entity.Model.Course;

namespace FrameWork.Entity.ViewModel.Course
{
    public class GetCourseDetailViewModel
    {
        /// <summary>
        /// 视频信息
        /// </summary>
        public VideoViewModel VideoInfo = new VideoViewModel();

        /// <summary>
        /// 相关视频列表
        /// </summary>
        public List<RelateVideoViewModel> RelateVideoList = new List<RelateVideoViewModel>();
    }

    /// <summary>
    /// 视频模型
    /// </summary>
    public class VideoViewModel
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
        /// 小节视频id
        /// </summary>
        public float Price { set; get; }

        /// <summary>
        /// 讲师名字
        /// </summary>
        public string TeacherName { set; get; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string TeacherImgPath { get; set; }

        /// <summary>
        /// 讲师头衔
        /// </summary>
        public string TeacherTitle { set; get; }

        /// <summary>
        /// 点赞数量
        /// </summary>
        public int PraiseCount { set; get; }

        /// <summary>
        /// 是否点赞
        /// </summary>
        public bool IsPraise { set; get; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        public int CollectCount { set; get; }

        /// <summary>
        /// 该用户是否收藏
        /// </summary>
        public bool IsCollect { set; get; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { set; get; }

        /// <summary>
        /// 用户购买该视频的数量
        /// </summary>
        public int BuyCount { set; get; }

        /// <summary>
        /// 是否购买
        /// </summary>
        public bool IsBuy { set; get; }

        /// <summary>
        /// 观看视频的人数
        /// </summary>
        public int WatchingCount { set; get; }

        /// <summary>
        /// 拼接的小节名字
        /// </summary>
        public string SubSctionName { get; set; } = string.Empty;

        /// <summary>
        /// 转化为viewModel
        /// </summary>
        public VideoViewModel GetVideoViewModel(CourseDetailModel model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CourseDetailModel, VideoViewModel>()
                    .ForMember(m => m.ModifyTime, opt => opt.MapFrom(s => s.ModifyTime.ToString("yyyy-MM-dd")))
                    .ForMember(d => d.VideoImgPath, opt => opt.MapFrom(s => PictureHelper.ConcatPicUrl(s.VideoImgPath)))
                    .ForMember(d => d.HighPath, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.CategoryName, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.CourseName, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.ChapterName, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.SectionName, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.TeacherName, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.TeacherImgPath, opt => opt.MapFrom(s => PictureHelper.ConcatPicUrl(s.TeacherImgPath)))
                    .ForMember(d => d.TeacherTitle, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.Lecture, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.SectionDesc, opt => opt.NullSubstitute(""))
                    .ForMember(d => d.IsBuy, opt => opt.MapFrom(s => s.UserBuyCount > 0))
                    .ForMember(d => d.IsCollect, opt => opt.MapFrom(s => s.UserCollectCount > 0))
                    .ForMember(d => d.IsPraise, opt => opt.MapFrom(s => s.UserPraiseCount > 0))
                    );
            var mapper = config.CreateMapper();
            var viewModel = mapper.Map<VideoViewModel>(model);
            viewModel.SubSctionName = $"{model.CourseName}/第{model.ChapterSequence.NumberToChinese()}章/第{model.SectionSequence.NumberToChinese()}节";
            return viewModel;
        }
    }

    /// <summary>
    /// 相关的小节视频
    /// </summary>
    public class RelateVideoViewModel
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
