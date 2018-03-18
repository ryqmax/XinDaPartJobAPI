using System;
using System.Collections.Generic;
using System.Linq;
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
                    recentSignInInfoList = SignInService.GetEnterpriseRecentSignInInfo(userInfo.EPId, userInfo.UserId);
                    break;
            }


            var info = new SignInRespInfo();
            info.TodayIsSigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.Date);
            recentSignInInfoList = recentSignInInfoList.OrderByDescending(o => o.SignDate).ToList();

            //判断昨天是否签到
            var lastDaySigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.AddDays(-1).Date);

            if (lastDaySigned)
            {
                var currentDate = DateTime.Now.AddDays(-1).Date;
                if (info.TodayIsSigned)
                {
                    currentDate = DateTime.Now.Date;
                }

                foreach (var recentSignInInfo in recentSignInInfoList)
                {
                    if (recentSignInInfo.SignDate != currentDate)
                    {
                        break;
                    }
                    info.TotalValue += recentSignInInfo.AddValue;
                    var recentSignInInfoItem = new RecentSignInInfoItem
                    {
                        Value = recentSignInInfo.AddValue,
                        IsSigned = true
                    };
                    info.List.Add(recentSignInInfoItem);
                    currentDate = currentDate.AddDays(-1);
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
                    info.TotalValue = recentSignInInfo.AddValue;
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

        [HttpPost]
        [Route("api/SignIn/SignIn")]
        public object SignIn(SignInReq request)
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

            List<RecentSignInInfo> recentSignInInfoList;

            bool todayIsSigned;
            bool lastDaySigned;
            int currentValue;
            bool signInResult;
            int totalIntegral;
            //根据用户类型获取最近的签到记录
            switch (userInfo.Mark)
            {
                case TokenMarkEnum.User:
                    recentSignInInfoList = SignInService.GetUserRecentSignInInfo(userInfo.UserId);
                    //判断今天有没有签到
                    todayIsSigned=recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.Date);
                    if (todayIsSigned)
                    {
                        result.Info = CommonData.SignInSuccess;
                        result.Message = CommonData.SignInSuccess;
                        result.ResultCode = CommonData.SuccessCode;
                        result.Msg = true;
                        return result.ToJson();
                    }

                    //判断昨天是否签到
                    lastDaySigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.AddDays(-1).Date);
                   
                    if (lastDaySigned)
                    {
                        var lastDaySignInInfo = recentSignInInfoList.FirstOrDefault(r => r.SignDate == DateTime.Now.AddDays(-1).Date);
                        var lastIndex = CommonData.SignValueArray.IndexOf(lastDaySignInInfo.AddValue);
                        currentValue = lastIndex + 1 < CommonData.SignValueArray.Count ? CommonData.SignValueArray[lastIndex + 1] : CommonData.SignValueArray[0];
                        totalIntegral = lastDaySignInInfo.TotalIntegral + currentValue;
                    }
                    else
                    {
                        currentValue = CommonData.SignValueArray[0];
                        totalIntegral = CommonData.SignValueArray[0];
                    }

                    var userSignIn = new T_UserSignLog
                    {
                        UserId = userInfo.UserId,
                        SignDate = DateTime.Now.Date,
                        AddValue = currentValue,
                        TotalIntegral = totalIntegral,
                        IsDel = false,
                        ModifyUserId = userInfo.UserId,
                        ModifyTime = DateTime.Now,
                        CreateUserId = userInfo.UserId,
                        CreateTime = DateTime.Now
                    };

                    //插入积分记录表
                    signInResult = SignInService.UserSignIn(userSignIn);
                    //更新用户积分
                    SignInService.UpdateUserIntegral(userInfo.UserId, currentValue, CommonData.SignIn);
                    if (signInResult)
                    {
                        result.Info = CommonData.SignInSuccess;
                        result.Message = CommonData.SignInSuccess;
                        result.ResultCode = CommonData.SuccessCode;
                        result.Msg = true;
                        return result.ToJson();
                    }

                    break;
                case TokenMarkEnum.Enterprise:
                    var b = 0;
                    recentSignInInfoList = SignInService.GetEnterpriseRecentSignInInfo(userInfo.EPId, userInfo.UserId);

                    //判断今天有没有签到
                    todayIsSigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.Date);
                    if (todayIsSigned)
                    {
                        result.Info = CommonData.SignInSuccess;
                        result.Message = CommonData.SignInSuccess;
                        result.ResultCode = CommonData.SuccessCode;
                        result.Msg = true;
                        return result.ToJson();
                    }

                    //判断昨天是否签到
                    lastDaySigned = recentSignInInfoList.Exists(r => r.SignDate == DateTime.Now.AddDays(-1).Date);

                    if (lastDaySigned)
                    {
                        var lastDaySignInInfo = recentSignInInfoList.FirstOrDefault(r => r.SignDate == DateTime.Now.AddDays(-1).Date);
                        var lastIndex = CommonData.SignValueArray.IndexOf(lastDaySignInInfo.AddValue);
                        currentValue = lastIndex + 1 < CommonData.SignValueArray.Count ? CommonData.SignValueArray[lastIndex + 1] : CommonData.SignValueArray[0];
                        totalIntegral = lastDaySignInInfo.TotalIntegral + currentValue;
                    }
                    else
                    {
                        currentValue = CommonData.SignValueArray[0];
                        totalIntegral = CommonData.SignValueArray[0];
                    }

                    var enterpriseSignIn = new T_EPSignLog
                    {
                        EnterpriseId = userInfo.EPId,
                        UserId = userInfo.UserId,
                        SignDate = DateTime.Now.Date,
                        AddValue = currentValue,
                        TotalIntegral = totalIntegral,
                        IsDel = false,
                        ModifyUserId = userInfo.UserId,
                        ModifyTime = DateTime.Now,
                        CreateUserId = userInfo.UserId,
                        CreateTime = DateTime.Now
                    };

                    //插入积分记录表
                    signInResult = SignInService.EnterpriseSignIn(enterpriseSignIn);
                    //更新企业积分
                    SignInService.UpdateEnterpriseIntegral(userInfo.EPId, currentValue, CommonData.SignIn);
                    if (signInResult)
                    {
                        result.Info = CommonData.SignInSuccess;
                        result.Message = CommonData.SignInSuccess;
                        result.ResultCode = CommonData.SuccessCode;
                        result.Msg = true;
                        return result.ToJson();
                    }
                    break;
            }
            return result.ToJson();

        }
    }
}