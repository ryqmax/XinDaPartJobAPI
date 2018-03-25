using System.Collections.Generic;
using FrameWork.Common.Models;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Job;
using FrameWork.Entity.ViewModel.Job;
using FrameWork.Entity.ViewModel.SignIn;

namespace FrameWork.Interface
{
    public interface IJobService : IBaseService<T_Job>
    {
        /// <summary>
        /// 获取岗位列表
        /// </summary>
        List<JobInfo> GetJobList(GetJobListReq getJobListReq, string cityId);

        /// <summary>
        /// 获取兼职岗位详情
        /// </summary>
        GetPartJobModel GetPartJob(int jobId, int userId);

        /// <summary>
        /// 获取该岗位的工作地点列表
        /// </summary>
        List<T_EPAddress> GetJobAdderssList(int jobId);

        /// <summary>
        /// 获取该用户可以投递的兼职简历列表
        /// </summary>
        List<GetUserPostPartCVListModel> GetUserPostPartCVList(int userId);

        /// <summary>
        /// 用户投递简历到某个岗位
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="cvId">简历id</param>
        /// <param name="jobId">岗位id</param>
        int UserPostCV(int userId, int cvId, int jobId);

        /// <summary>
        /// 获取全职岗位详情
        /// </summary>
        GetFullJobModel GetFullJob(int jobId, int userId);

        /// <summary>
        /// 获取该工作的福利待遇
        /// </summary>
        List<T_EPWelfare> GetJobWelfareList(int jobId);

        /// <summary>
        /// 获取所有的结算方式列表
        /// </summary>
        List<T_PayWay> GetPayWays();

        /// <summary>
        /// 获取岗位的预约刷新信息
        /// </summary>
        GetRefreshInfoModel GetRefreshInfo(int jobId, int epId, string cityId);

        /// <summary>
        /// 提交刷新信息
        /// </summary>
        int SubmitRefreshInfo(SubmitRefreshInfoRequest request);

        /// <summary>
        /// 新增兼职岗位
        /// </summary>
        int SubmitPartJob(SubmitPartJobViewModel request, RedisModel redisModel,string provinceId);
    }
}
