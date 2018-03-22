/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                VipController.cs
 *      Description:
 *            VipController
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 19:19:36
 *      History:
 ***********************************************************************************/

using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Vip;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// VipController
    /// </summary>
    public class VipController:AdminControllerBase
    {
        /// <summary>
        /// 获取会员列表
        /// </summary>
        [HttpPost]
        [Route("api/Vip/GetVipList")]
        public object GetVipList(GetVipListRequest request)
        {
            var models = VIPInfoService.GetVipInfoList();
            var viewModels = new GetVipListViewModel().GetViewModels(models);
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