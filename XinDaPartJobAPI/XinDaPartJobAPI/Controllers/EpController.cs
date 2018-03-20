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
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            return result;
        }
    }
}
