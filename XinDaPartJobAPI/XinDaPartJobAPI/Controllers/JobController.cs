using System.Collections.Generic;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Enum;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Job;
using FrameWork.Entity.ViewModel.SignIn;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    public class JobController : AdminControllerBase
    {
        [HttpPost]
        [Route("api/Job/GetJobList")]
        public object GetJobList(GetJobListReq request)
        {
            var result = new BaseViewModel()
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            var userInfo = RedisInfoHelper.GetRedisModel(request.Token);

            var jobInfoList = JobService.GetJobList(request, userInfo.DicRegionId);

            //todo:获取广告信息

            var getJobListRespInfoList = new List<GetJobListRespInfo>();
            foreach (var jobInfo in jobInfoList)
            {
                var getJobListRespInfo = new GetJobListRespInfo
                {
                    JobId = jobInfo.JobId,
                    JobEmployerId = jobInfo.JobEmployerId,
                    JobEmployerName = EnumHelper.GetDescription(jobInfo.JobEmployerLevel),
                    JobName = jobInfo.JobName,
                    JobPay = $"{jobInfo.SalaryLower}-{jobInfo.SalaryUpper}",
                    JobPayUnit = jobInfo.Unit,
                    JobAddress = jobInfo.JobAddress,
                    JobTime = jobInfo.JobTime,
                    JobMember = jobInfo.JobMember,
                    IsSelf = jobInfo.IsSelf,
                    IsAdvert = false,
                    IsPractice = jobInfo.IsPractice,
                    IsEnd = PageHelper.JudgeNextPage(jobInfo.TotalNum,request.Page,request.PageSize)
                };
                getJobListRespInfoList.Add(getJobListRespInfo);
            }

            result.Info = getJobListRespInfoList;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;

            return result.ToJson();

        }
    }
}
