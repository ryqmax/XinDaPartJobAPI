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

using System.Linq;
using System.Web.Http;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
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
        public object GetCityList()
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };

            var cityList = CacheContext.DicRegions.Select(r => new GetCityListViewModel {CityId = r.Id, CityName = r.Description});

            result.Info = cityList;
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;
            return result;
        }

    }
}