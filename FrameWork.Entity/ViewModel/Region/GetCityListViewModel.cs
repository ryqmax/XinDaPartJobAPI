/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetCityListViewModel.cs
 *      Description:
 *            GetCityListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 21:50:02
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Region
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class GetCityListRequest
    {


    }

    /// <summary>
    /// GetCityListViewModel
    /// </summary>
    public class GetCityListViewModel
    {
        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; } = string.Empty;

        public List<CityListItem> CityList { get; set; }=new List<CityListItem>();
    }

    public class CityListItem
    {
        /// <summary>
        /// 城市Id
        /// </summary>
        public string CityId { get; set; } = string.Empty;

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; } = string.Empty;
    }
}
