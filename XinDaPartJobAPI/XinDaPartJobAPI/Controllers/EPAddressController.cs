/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPAddressController.cs
 *      Description:
 *            EPAddressController
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 12:27:20
 *      History:
 ***********************************************************************************/

using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.EPAddress;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// EPAddressController
    /// </summary>
    public class EPAddressController : AdminControllerBase
    {
        /// <summary>
        /// 获取企业的所有地址列表
        /// </summary>
        [HttpPost]
        [Route("api/EPAddress/GetAddressList")]
        public object GetAddressList(GetAddressListRequest request)
        {
            //var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var regions = CacheContext.DicRegions;
            var models = EPAddressService.GetAddresseList(1);
            var viewModels = new GetAddressListViewModel().GetViewModels(models, regions);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }
    }
}