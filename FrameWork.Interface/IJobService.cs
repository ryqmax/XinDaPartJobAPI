using System.Collections.Generic;
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
    }
}
