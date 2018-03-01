using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Course;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Course;

namespace FrameWork.Interface
{
    /// <summary>
    /// 课程相关
    /// </summary>
    public interface ICourseService:IBaseService<T_Course>
    {
        /// <summary>
        /// 获取首页免费视频列表
        /// </summary>
        /// <returns></returns>
        List<FreeVideoModel> GetFreeVidioList(int industryId, int currentPage, int pageSize);
        /// <summary>
        /// 获取轮播图
        /// </summary>
        List<T_Banner> GetBannerList();

        /// <summary>
        /// 获取该行业下的付费课程
        /// </summary>
        /// <param name="industryId">行业id</param>
        List<CourseModel> GetCourseModelList(int industryId);

        /// <summary>
        /// 获取付费课程下的新闻列表
        /// </summary>
        /// <param name="industryId">行业id</param>
        List<CourseNewsModel> GetNewsModels(int industryId);

        /// <summary>
        /// 获取该行业下的付费小节视频列表
        /// </summary>
        /// <param name="industryId">行业id</param>
        /// <param name="userId">用户id</param>
        List<CourseVideoModel> GetCourseVideoModelList(int industryId, int userId);

        /// <summary>
        /// 获取视频详情
        /// </summary>
        /// <param name="sectionVideoId">小节视频id</param>
        /// <param name="userId">用户id</param>
        CourseDetailModel GetCourseDetailModel(int sectionVideoId, int userId);

        /// <summary>
        /// 获取该小节视频的相关小节视频
        /// </summary>
        /// <param name="sectionVideoId">小节视频id</param>
        List<RelateVideoModel> GetRelateVideoModelList(int sectionVideoId);

        /// <summary>
        /// 点赞或取消点赞
        /// </summary>
        int SubmitVideoUpvote(SubmitVideoUpvoteRequest request);

        /// <summary>
        /// 收藏或取消收藏
        /// </summary>
        int SubmitVideoCollection(SubmitVideoCollectionRequest request);

        /// <summary>
        /// 提交视频进度
        /// </summary>
        int SubmitVideoProgress(SubmitVideoProgressRequest request);

        /// <summary>
        /// 获取该课程下的章节列表
        /// </summary>
        List<GetCourseMenuListModel> GetCourseMenuList(GetCourseMenuListRequest request);

        /// <summary>
        /// 获取讲师的课程
        /// </summary>
        List<GetTeacherDetailModel> GetTeacherCourseModel(GetTeacherDetailRequest request);

        /// <summary>
        /// 获取小节的详情
        /// </summary>
        List<GetSectionDetailModel> GetSectionDetail(GetSectionDetailRequest request);

        /// <summary>
        /// 更新小节视频的浏览量字段
        /// </summary>
        int UpdateSectionVideoBrowseCount(UpdateSectionVideoBrowseCountRequest request);

        /// <summary>
        /// 获取全部的行业列表
        /// </summary>
        List<T_Industry> GetAllIndustryList();

        /// <summary>
        /// 获取某个行业信息
        /// </summary>
        /// <param name="id">行业id</param>
        T_Industry GetiIndustry(int id);

        int temp();
    }
}
