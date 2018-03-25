using System.Collections.Generic;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Enum;
using FrameWork.Common.Models;
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

            var jobInfoList = JobService.GetJobList(request, userInfo.CityId);

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
                    IsEnd = PageHelper.JudgeNextPage(jobInfo.TotalNum, request.Page, request.PageSize)
                };
                getJobListRespInfoList.Add(getJobListRespInfo);
            }

            result.Info = getJobListRespInfoList;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;

            return result.ToJson();

        }

        /// <summary>
        /// 获取兼职岗位详情
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetPartJob")]
        public object GetPartJob(GetPartJobRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var userId = redisModel.UserId;
            if (redisModel.Mark == TokenMarkEnum.Enterprise)
                userId = 0;
            var model = JobService.GetPartJob(request.JobId, userId);
            var jobAddr = JobService.GetJobAdderssList(request.JobId);
            //TODO:广告列表没有返回
            var viewModel = new GetPartJobViewModel().GetViewModel(model, jobAddr, CacheContext.DicRegions, request);
            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取全职岗位详情
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetFullJob")]
        public object GetFullJob(GetFullJobRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var userId = redisModel.UserId;
            if (redisModel.Mark == TokenMarkEnum.Enterprise)
                userId = 0;
            var model = JobService.GetFullJob(request.JobId, userId);
            var jobAddr = JobService.GetJobAdderssList(request.JobId);
            var welfares = JobService.GetJobWelfareList(request.JobId);

            //TODO:广告列表没有返回
            var viewModel = new GetFullJobViewModel().GetViewModel(model, jobAddr, CacheContext.DicRegions, welfares, request);
            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取用户要投递的兼职简历列表
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetUserPostPartCVList")]
        public object GetUserPostPartCVList(GetUserPostPartCVListRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var userId = 0;
            if (redisModel.Mark == TokenMarkEnum.Enterprise)
                userId = 0;
            var models = JobService.GetUserPostPartCVList(userId);
            var viewModels = new GetUserPostPartCVListViewModel().GetViewModel(models, request.JobCategoryName);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 用户投递简历到某个岗位
        /// </summary>
        [HttpPost]
        [Route("api/Job/UserPostCV")]
        public object UserPostCV(UserPostCVRequest request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var userId = redisModel.UserId;
            if (redisModel.Mark == TokenMarkEnum.Enterprise)
            {
                result = new BaseViewModel
                {
                    Info = CommonData.EPNotPostCV,
                    Message = CommonData.EPNotPostCV,
                    Msg = false,
                    ResultCode = CommonData.FailCode
                };
            }
            JobService.UserPostCV(userId, request.CVId, request.JobId);
            return result;
        }

        /// <summary>
        /// 获取结算方式接口
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetPayWay")]
        public object GetPayWay(GetPayWayRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var models = CacheContext.PayWays;
            var viewModels = new GetPayWayViewModel().GetViewModels(models);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取岗位预约刷新时间
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetRefreshInfo")]
        public object GetRefreshInfo(GetRefreshInfoRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var model = JobService.GetRefreshInfo(request.JobId, redisModel.EPId, redisModel.CityId);
            var viewModel = new GetRefreshInfoViewModel().GetViewModel(model);
            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 提交预约刷新
        /// </summary>
        [HttpPost]
        [Route("api/Job/SubmitRefreshInfo")]
        public object SubmitRefreshInfo(SubmitRefreshInfoRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var id = JobService.SubmitRefreshInfo(request);

            var result = new BaseViewModel
            {
                Info = new SubmitRefreshInfoViewModel { RefreshId = id },
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 发布兼职岗位
        /// </summary>
        [HttpPost]
        [Route("api/Job/SubmitPartJob")]
        public object SubmitPartJob(SubmitPartJobViewModel request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);


            var result = new BaseViewModel
            {
                Info = 1,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

    }
}
