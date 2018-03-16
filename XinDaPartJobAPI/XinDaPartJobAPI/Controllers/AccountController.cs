using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using XinDaPartJobAPI.Models;
using XinDaPartJobAPI.Providers;
using XinDaPartJobAPI.Results;

namespace XinDaPartJobAPI.Controllers
{
    public class AccountController : AdminControllerBase
    {
        [HttpPost]
        [Route("api/Account/GetUserInfo")]
        public object GetUserInfo(GetUserInfoRequest request)
        {
            var weChatAppId = ConfigurationManager.AppSettings["WeChatAppId"];
            var weChatSecret = ConfigurationManager.AppSettings["WeChatSecret"];
            var url = $@"https://api.weixin.qq.com/sns/jscode2session?appid={weChatAppId}&secret={weChatSecret}&js_code={request.Code}&grant_type=authorization_code";
            var rs = HttpClientHelper.SendMessage(url);
            var openidModel = JObject.Parse(rs).GetValue("openid");
            var result = new BaseViewModel
            {
                Info = CourseConst.FailStr,
                Message = CourseConst.FailStr,
                Msg = false,
                ResultCode = CourseConst.FailCode
            };

            //RedisInfoHelper.RedisManager.Set("test", result.ToJsonStr());
            if (openidModel != null)
            {
                var openid = openidModel.ToString();
                var model = AccountService.GetStudent(openid, request);

                var viewModel = new GetUserInfoViewModel().GetViewModel(model);
                result = new BaseViewModel
                {
                    Info = viewModel,
                    Message = CourseConst.SuccessStr,
                    Msg = true,
                    ResultCode = CourseConst.SuccessCode
                };
            }
            return result.ToJson();
        }

    }
}
