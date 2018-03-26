using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.CV;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    public class CVController : AdminControllerBase
    {
        [HttpPost]
        [Route("api/CV/ShieldCV")]
        public object ShieldCV(ShieldCVReq request)
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
                    shieldResult = CVServicecs.UserShieldCV(userInfo.UserId, request.CVId, request.ShieldDay);
                    break;
                case TokenMarkEnum.Enterprise:
                    var b = 0;
                    shieldResult = CVServicecs.EnterpriseShieldCV(userInfo.EPId, request.CVId, request.ShieldDay);
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
