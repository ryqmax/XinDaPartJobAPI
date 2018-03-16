using System.Configuration;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
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
            var openidModel = "wx123456789";
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
                request.OpenId = openidModel.ToString();
                var model = AccountService.GetUserInfo(request);

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
