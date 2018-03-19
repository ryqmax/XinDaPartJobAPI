using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel;
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
#if DEBUG
            userInfo.UserId = 1;
            userInfo.EPId = 1;
#endif
            var jobInfoList = JobService.GetJobList(request);

           
            return result.ToJson();

        }
    }
}
