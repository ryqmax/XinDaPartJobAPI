/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                ReportController.cs
 *      Description:
 *            举报相关
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/24 21:23:40
 *      History:
 ***********************************************************************************/


using System.Linq;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Report;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// ReportController
    /// </summary>
    public class ReportController : AdminControllerBase
    {
        /// <summary>
        /// 举报简历
        /// </summary>
        [HttpPost]
        [Route("api/Report/ReportCV")]
        public object ReportCV(ReportCVRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            ReportService.ReportCV(request, redisModel);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 举报岗位接口
        /// </summary>
        [HttpPost]
        [Route("api/Report/ReportJob")]
        public object ReportJob(ReportJobRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            ReportService.ReportJob(request, redisModel);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取举报原因列表
        /// </summary>
        [HttpPost]
        [Route("api/Report/GetReportReason")]
        public object GetReportReason(GetReportReasonRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var models = CacheContext.ReportReasons.Where(r => r.Type == request.Type).ToList();
            var viewModels = new GetReportReasonViewModel().GetViewModels(models);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }


    }
}