

using System.Collections.Generic;
using AutoMapper;
using FrameWork.Common;
using FrameWork.Entity.Model.Course;

namespace FrameWork.Entity.ViewModel.Course
{

    public class TeacherDetailViewModel
    {
        /// <summary>
        /// 讲师描述
        /// </summary>
        public string TeacherDesc { set; get; }

        /// <summary>
        /// 讲师描述图片
        /// </summary>
        public string TeacherDescImgPath { set; get; }

        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsEnd { set; get; }

        /// <summary>
        /// 付费课程列表
        /// </summary>
        public List<GetTeacherDetailViewModel> CourseList = new List<GetTeacherDetailViewModel>();

    }

    public class GetTeacherDetailViewModel
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
        /// 包含章节顺序的名称
        /// </summary>
        public string SubSectionName { get; set; }

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
        public string ModifyTime { set; get; }

        /// <summary>
        /// 是否购买
        /// </summary>
        public bool IsBuy { set; get; }

        /// <summary>
        /// 获取讲师课程列表信息
        /// </summary>
        public List<GetTeacherDetailViewModel> GetViewModel(List<GetTeacherDetailModel> models)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetTeacherDetailModel, GetTeacherDetailViewModel>()
                .ForMember(d => d.ModifyTime, opt => opt.MapFrom(s => s.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.VideoImgPath, opt => opt.MapFrom(s => PictureHelper.ConcatPicUrl(s.VideoImgPath)))
                .ForMember(d => d.IsBuy, opt => opt.MapFrom(s => s.UserBuyCount > 0))
                .ForMember(d=>d.SubSectionName, opt=>opt.MapFrom(s => $"{s.CourseName}/第{s.ChapterSequence.NumberToChinese()}章/第{s.SectionSequence.NumberToChinese()}节"))
            );
            var mapper = config.CreateMapper();
            return mapper.Map<List<GetTeacherDetailViewModel>>(models);
        }

    }
}
