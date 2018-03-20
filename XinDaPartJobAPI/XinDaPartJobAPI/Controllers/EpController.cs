/************************************************************************************
 *      Copyright (C) 2017 liwei,All Rights Reserved
 *      File:
 *                EPController.cs
 *      Description:
 *            EPController
 *            企业相关操作
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 21:37:12
 *      History:
 ***********************************************************************************/


using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.EP;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// 企业相关
    /// </summary>
    public class EPController : AdminControllerBase
    {
        /// <summary>
        /// 获取招聘联系人列表
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPContacts")]
        public object GetEPContacts(GetEPContactsRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var models = EPService.GetEpContacts(redisModel.EPId);
            var viewModels = new GetEPContactsViewModel().GetvViewModels(models);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 删除招聘联系人
        /// </summary>
        [HttpPost]
        [Route("api/EP/DelEPContacts")]
        public object DelEPContacts(DelEPContactsViewModel request)
        {
            EPService.DelEPContacts(request.EPContactsId);
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
        /// 保存招聘联系人手机号
        /// 1.如果数据库已经存在
        /// </summary>
        [HttpPost]
        [Route("api/EP/SaveEPContactsPhone")]
        public object SaveEPContactsPhone(DelEPContactsViewModel request)
        {
            EPService.DelEPContacts(request.EPContactsId);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

    }
}
