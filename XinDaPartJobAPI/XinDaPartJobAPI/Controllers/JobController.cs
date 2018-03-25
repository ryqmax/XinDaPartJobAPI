using System;
using System.Collections.Generic;
using System.Linq;
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

            var jobInfoList = JobService.GetJobList(request, userInfo.CityId, userInfo.EPId);

            //todo:获取广告信息

            var getJobListRespInfoList = new GetJobListRespInfo();

            var firstOrDefualtJobInfo = jobInfoList.FirstOrDefault();
            if (firstOrDefualtJobInfo != null)
            {
                getJobListRespInfoList.IsEnd = !PageHelper.JudgeNextPage(firstOrDefualtJobInfo.TotalNum, request.Page, request.PageSize);
            }

            foreach (var jobInfo in jobInfoList)
            {
                var getJobListRespInfo = new JobInfoList
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
                };
                getJobListRespInfoList.JobInfoList.Add(getJobListRespInfo);
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
        /// 获取首页基础数据
        /// </summary>
        [HttpPost]
        [Route("api/Job/GetIndexBaseData")]
        public object GetIndexBaseData(GetIndexBaseDataReq request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            
            var resultInfo=new GetIndexBaseDataRespInfo();

            //地区数据
            resultInfo.Region = CacheContext.DicRegions.Where(r => !r.IsDel&&r.ParentId==redisModel.CityId).Select(r=>new RegionListItem{RegionId = r.Id,Name = r.Description}).ToList();
            
            //雇主级别数据
            
            foreach (JobEmployerLevelEnum jobEmployerLevel in Enum.GetValues(typeof(JobEmployerLevelEnum)))
            {
                var currentEmployer = new EmployerListItem
                {
                    EmployerId = ((int)jobEmployerLevel).ToString(),
                    Name = EnumHelper.GetDescription(jobEmployerLevel)
                };
                resultInfo.Employer.Add(currentEmployer);
            }

            //岗位类型
            var jobCategoryList = JobCategoryServicec.GetJobCategorieList();
            foreach (var jobCategory in jobCategoryList)
            {
                var currentjobCategory = new JobTypeListItem()
                {
                    JobTypeId = jobCategory.Id.ToString(),
                    Name = jobCategory.Name
                };
                resultInfo.JobType.Add(currentjobCategory);
            }

            //bannner
            var jobBannerList = JobBannerServicec.GetJobBannerList();
            foreach (var jobBanner in jobBannerList)
            {
                var currentjobCategory = new BannerListItem()
                {
                    BannerId = jobBanner.Id.ToString(),
                    ImgUrl = PictureHelper.ConcatPicUrl(jobBanner.PicUrl),
                    BannerUrl = StringHelper.NullOrEmpty(jobBanner.OpenUrl)
                };
                resultInfo.BannerList.Add(currentjobCategory);
            }

            result.Info = resultInfo;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;

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
            //var redisModel = new RedisModel {EPId = 1,UserId = 1,CityId = "3202"};
            var provinceId = CacheContext.DicRegions.FirstOrDefault(r => r.Id == redisModel.CityId)?.ParentId ?? string.Empty;
            JobService.SubmitPartJob(request, redisModel, provinceId);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        [HttpPost]
        [Route("api/Job/ShieldJob")]
        public object ShieldJob(ShieldJobReq request)
        {
            var result = new BaseViewModel()
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            var userInfo = RedisInfoHelper.GetRedisModel(request.Token);

            //根据用户类型进行不同的操作
            var shieldResult = false;
            switch (userInfo.Mark)
            {
                case TokenMarkEnum.User:
                    shieldResult = JobService.UserShieldJob(userInfo.UserId, request.JobId, request.ShieldDay);
                    break;
                case TokenMarkEnum.Enterprise:
                    var b = 0;
                    shieldResult = JobService.EnterpriseShieldJob(userInfo.EPId, request.JobId, request.ShieldDay);
                    break;
            }

            if (shieldResult)
            {
                result.Info = CommonData.SuccessStr;
                result.Message = CommonData.SuccessStr;
                result.ResultCode = CommonData.SuccessCode;
                result.Msg = true;
            }

            return result.ToJson();
        }
    }
}
