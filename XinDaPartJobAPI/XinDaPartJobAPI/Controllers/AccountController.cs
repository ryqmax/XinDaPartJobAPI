using System;
using System.Configuration;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Web;
using Newtonsoft.Json.Linq;

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
            //var url = $@"https://api.weixin.qq.com/sns/jscode2session?appid={weChatAppId}&secret={weChatSecret}&js_code={request.Code}&grant_type=authorization_code";
            //var rs = HttpClientHelper.SendMessage(url);
            //var openidModel = JObject.Parse(rs).GetValue("openid");
            var openidModel = "wx123456789";
            var result = new BaseViewModel
            {
                Info = CourseConst.FailStr,
                Message = CourseConst.FailStr,
                Msg = false,
                ResultCode = CourseConst.FailCode
            };
            
            if (openidModel != null)
            {
                request.OpenId = openidModel.ToString();
                var model = AccountService.GetUserInfo(request);
                
                var viewModel = new GetUserInfoViewModel().GetViewModel(model);
                viewModel.Token = GetToken(model);
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

        /// <summary>
        /// 获取这个用户的token值，并把这个用户相关的信息存到缓存中
        /// </summary>
        /// <param name="model">用户信息实体</param>
        private string GetToken(T_User model)
        {
            var token = GuidHelper.GetPrimarykey();
            var oldToken = RedisInfoHelper.RedisManager.Getstring("uid" + model.Id);
            oldToken = oldToken.Replace("\"", "");
            if (!string.IsNullOrEmpty(oldToken))//如果是重新登录，移除原来的token对应的值
            {
                RedisInfoHelper.RedisManager.Remove(oldToken);
            }
            var rdModel = new RedisModel
            {
                DicRegionId = "1",
                EPId = 0,
                Mark = 1,
                OpenId = model.WxAccount,
                Token = token,
                UserId = model.Id,
                WxName = model.WxName
            };
            RedisInfoHelper.RedisManager.Set("uid" + model.Id, token,DateTime.Now.AddDays(1));
            RedisInfoHelper.RedisManager.Set(token, rdModel.ToJsonStr(), DateTime.Now.AddDays(1));

            //var rdStr = RedisInfoHelper.RedisManager.Getstring(token);
            //var m = rdStr.ToTheObject<RedisModel>();

            return token;
        }
    }
}
