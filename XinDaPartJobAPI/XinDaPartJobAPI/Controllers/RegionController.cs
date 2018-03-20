/************************************************************************************
 *      Copyright (C) 2017 yangxianwen,All Rights Reserved
 *      File:
 *                RegionController.cs
 *      Description:
 *            RegionController
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 21:37:12
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Region;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// RegionController
    /// </summary>
    public class RegionController:AdminControllerBase
    {
        /// <summary>
        /// 获取城市列表
        /// </summary>
        [HttpPost]
        [Route("api/Region/GetCityList")]
        public object GetCityList(GetCityListRequest request)
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