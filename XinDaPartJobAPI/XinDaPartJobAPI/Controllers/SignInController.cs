using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.ViewModel.SignIn;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    public class SignInController : AdminControllerBase
    {
        [HttpPost]
        [Route("api/SignIn/GetSignInInfo")]
        public object GetSignInInfo(GetSignInInfoReq request)
        {
            var result = new GetSignInInfoResp()
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            var userInfo = RedisInfoHelper.GetRedisModel(request.Token);

            var recentSignInInfoList= new List<RecentSignInInfo>();

            //根据用户类型获取最近的签到记录
            switch (userInfo.Mark)
            {
                case TokenMarkEnum.User:
                    recentSignInInfoList = SignInService.GetUserRecentSignInInfo(userInfo.UserId);
                    break;
                case TokenMarkEnum.Enterprise:
                    var b = 0;
                    recentSignInInfoList = SignInService.GetEnterpriseRecentSignInInfo(userInfo.EPId);
                    break;
            }


            var info = new SignInRespInfo();
            info.TodayIsSigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.Date);
            recentSignInInfoList = recentSignInInfoList.OrderByDescending(o => o.SignDate).ToList();

            //判断昨天是否签到
            var lastDaySigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.AddDays(-1).Date);
            if (lastDaySigned)
            {
                foreach (var recentSignInInfo in recentSignInInfoList)
                {
                    var recentSignInInfoItem = new RecentSignInInfoItem
                    {
                        Value = recentSignInInfo.AddValue,
                        IsSigned = true
                    };
                    info.List.Add(recentSignInInfoItem);
                }
            }
            else
            {
                if (info.TodayIsSigned)
                {
                    var recentSignInInfo = recentSignInInfoList.FirstOrDefault(r => r.SignDate == DateTime.Now.Date);
                    var recentSignInInfoItem = new RecentSignInInfoItem
                    {
                        Value = recentSignInInfo.AddValue,
                        IsSigned = true
                    };
                    info.List.Add(recentSignInInfoItem);
                }
            }

            for (var unSignIndex = info.List.Count; unSignIndex < CommonData.SignValueArray.Count; unSignIndex++)
            {
                var recentSignInInfoItem = new RecentSignInInfoItem
                {
                    Value = CommonData.SignValueArray[unSignIndex],
                    IsSigned = false
                };
                info.List.Add(recentSignInInfoItem);
            }

            info.List = info.List.OrderBy(l => l.Value).ToList();

            result.Info = info;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;
            return result.ToJson();
        }
    }
}