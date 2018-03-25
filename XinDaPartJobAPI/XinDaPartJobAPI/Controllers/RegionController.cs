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

using System.Collections.Generic;
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

            var usedCityList = CacheContext.DicRegions.Where(r => r.IsUsed);
            var cityListInfo=new List<GetCityListViewModel>();

            foreach (var dicRegion in usedCityList)
            {
                var currentGroup = cityListInfo.FirstOrDefault(c => c.FirstLetter.Equals(dicRegion.FirstLetter));
                var currentCityInfo = new CityListItem
                {
                    CityId = dicRegion.Id,
                    CityName = dicRegion.Description
                };
                if (currentGroup!=null)
                {
                    currentGroup.CityList.Add(currentCityInfo);
                }
                else
                {
                    currentGroup = new GetCityListViewModel
                    {
                        FirstLetter = dicRegion.FirstLetter,
                        CityList = new List<CityListItem> {currentCityInfo}
                    };
                    cityListInfo.Add(currentGroup);
                }
            }

            result.Info = cityListInfo.OrderBy(c=>c.FirstLetter);
            result.Message = CommonData.SuccessStr;
            result.ResultCode = CommonData.SuccessCode;
            result.Msg = true;
            return result;
        }

    }
}