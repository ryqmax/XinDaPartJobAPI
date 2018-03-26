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
        List<JobInfo> GetJobList(GetJobListReq getJobListReq, string cityId, int ePId);

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
        /// 用户屏蔽岗位
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="jobId">岗位Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        bool UserShieldJob(int userId, int jobId, int shieldDay);

        /// <param name="epId">企业Id</param>
        /// <param name="jobId">岗位Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        bool EnterpriseShieldJob(int epId, int jobId, int shieldDay);

        /// <summary>
        /// 企业屏蔽岗位
        /// </summary>
        int SubmitPartJob(SubmitPartJobRequest request, RedisModel redisModel,string provinceId);

        /// <summary>
        /// 新增兼职岗位
        /// </summary>
        int SubmitFullJob(SubmitFullJobRequest request, RedisModel redisModel, string provinceId);

        /// <summary>
        /// 保存福利
        /// </summary>
        /// <param name="epId">企业id</param>
        /// <param name="welfareName">福利名称</param>
        int SaveWelfare(int epId, string welfareName);

    }
}
