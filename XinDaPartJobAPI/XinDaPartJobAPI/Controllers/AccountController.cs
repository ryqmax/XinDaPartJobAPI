using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Common.SmsHelper.Sms;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Web;
using Newtonsoft.Json.Linq;

namespace XinDaPartJobAPI.Controllers
{
    public class AccountController : AdminControllerBase
    {
        /// <summary>
        /// 腾讯云发送短信帮助类
        /// </summary>
        private static readonly SmsSingleSender _smsSingleSender = new SmsSingleSender();

        /// <summary>
        /// 普通用户授权接口
        /// </summary>
        [HttpPost]
        [Route("api/Account/GetUserInfo")]
        public object GetUserInfo(GetUserInfoRequest request)
        {
            var weChatAppId = ConfigurationManager.AppSettings["WeChatAppId"];
            var weChatSecret = ConfigurationManager.AppSettings["WeChatSecret"];
            var url = $@"https://api.weixin.qq.com/sns/jscode2session?appid={weChatAppId}&secret={weChatSecret}&js_code={request.Code}&grant_type=authorization_code";
            var rs = HttpClientHelper.SendMessage(url);
            var openidModel = JObject.Parse(rs).GetValue("openid");
            //var openidModel = "wx123456789";
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            
            if (openidModel != null)
            {
                request.OpenId = openidModel.ToString();
                var model = AccountService.GetUserInfo(request);
                
                var viewModel = new GetUserInfoViewModel().GetViewModel(model);
                viewModel.Token = GetToken(model, request);
                result = new BaseViewModel
                {
                    Info = viewModel,
                    Message = CommonData.SuccessStr,
                    Msg = true,
                    ResultCode = CommonData.SuccessCode
                };
            }
            return result.ToJson();
        }

        /// <summary>
        /// 获取这个用户的token值，并把这个用户相关的信息存到缓存中
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <param name="request">接口参数</param>
        private string GetToken(T_User model, GetUserInfoRequest request)
        {
            var token = GuidHelper.GetPrimarykey();
            var oldToken = RedisInfoHelper.RedisManager.Getstring("uid" + model.Id);
            if (!string.IsNullOrEmpty(oldToken))//如果是重新登录，移除原来的token对应的值
            {
                oldToken = oldToken.Replace("\"", "");
                RedisInfoHelper.RedisManager.Remove(oldToken);
            }
            var rdModel = new RedisModel
            {
                DicRegionId = request.City,
                EPId = 0,
                Mark = TokenMarkEnum.User,
                OpenId = model.WxAccount,
                Token = token,
                UserId = model.Id,
                WxName = model.WxName
            };
            RedisInfoHelper.RedisManager.Set("uid" + model.Id, token,DateTime.Now.AddDays(1));
            RedisInfoHelper.RedisManager.Set(token, rdModel.ToJsonStr(), DateTime.Now.AddDays(1));

            return token;
        }

        /// <summary>
        /// 获取手机号验证码
        /// </summary>
        [HttpPost]
        [Route("api/Account/GetPhoneCode")]
        public object GetPhoneCode(GetPhoneCodeRequest request)
        {
            var code = RedisInfoHelper.RedisManager.Getstring(request.Phone);//缓存中是否已经存在该手机号的验证码
            if (string.IsNullOrEmpty(code))
            {
                var random = new Random();
                code = random.Next(1000, 9999).ToString();
            }
            RedisInfoHelper.RedisManager.Set(request.Phone, code,DateTime.Now.AddMinutes(3));//再次存储验证码到缓存中，防止上次验证码过期，过期时间默认3分钟
            var r = _smsSingleSender.SendWithParam("86", request.Phone, CommonData.TemplateId, new List<string> { code }, "", "", "");
            var result = new BaseViewModel
            {
                Info = r.errmsg,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };

            if (r.result != 0)
            {
                result = new BaseViewModel
                {
                    Info = CommonData.SendFailStr,
                    Message = CommonData.SendFailStr,
                    Msg = false,
                    ResultCode = CommonData.FailCode
                };
            }

            return result.ToJson();
        }

    }
}
