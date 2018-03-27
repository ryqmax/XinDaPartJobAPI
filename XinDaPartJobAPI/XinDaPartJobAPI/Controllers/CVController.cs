using System.Linq;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.CV;
using FrameWork.Entity.ViewModel.Job;
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

        /// <summary>
        /// 获取简历列表
        /// </summary>
        [HttpPost]
        [Route("api/CV/GetCVList")]
        public object GetCVList(GetCVReq request)
        {
            var result = new BaseViewModel()
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            var userInfo = RedisInfoHelper.GetRedisModel(request.Token);

            var cvInfoList = CVServicecs.GetCVList(request);

            //todo:获取广告信息

            var getCVListRespInfoList = new GetCVListRespInfo();

            var firstOrDefualtCVInfo = cvInfoList.FirstOrDefault();
            if (firstOrDefualtCVInfo != null)
            {
                getCVListRespInfoList.IsEnd = !PageHelper.JudgeNextPage(firstOrDefualtCVInfo.TotalNum, request.Page, request.PageSize);
            }

            foreach (var cvInfo in cvInfoList)
            {
                var cvInfoItem = new CVInfoItem
                {
                    CVId = cvInfo.CVId,
                    CVImg = PictureHelper.ConcatPicUrl(cvInfo.CVImg),
                    CVName = cvInfo.CVName,
                    CVSex = cvInfo.CVSex==1?"男":"女",
                    CVWord = cvInfo.CVWord,
                    CVPosition = cvInfo.CVPosition,
                    CVTime = cvInfo.CVTime,
                    CVSchool = cvInfo.CVSchool,
                    CVJob = cvInfo.CVJob,
                    RecommendNum = cvInfo.RecommendNum,
                    IsPractice = cvInfo.IsPractice,
                    IsAdvert = false,
                };
                getCVListRespInfoList.CVList.Add(cvInfoItem);
            }

            result.Info = CommonData.SuccessStr;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;

            return result.ToJson();
        }
    }
}
