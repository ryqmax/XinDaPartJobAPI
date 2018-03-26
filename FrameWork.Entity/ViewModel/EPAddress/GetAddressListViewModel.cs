/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetAddressListViewModel.cs
 *      Description:
 *            GetAddressListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 12:28:55
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.EPAddress
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class GetAddressListRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 地址所属类别：0.全部，1.兼职，2.全职 
        /// </summary>
        public int Type { get; set; }
    }

    /// <summary>
    /// GetAddressListViewModel
    /// </summary>
    public class GetAddressListViewModel
    {
        /// <summary>
        /// - 
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 企业地址 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 经度 
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// 纬度 
        /// </summary>
        public decimal Lat { get; set; }

        /// <summary>
        /// 省名称
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市名称
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区名称 
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 地址所属类别：0.全部，1.兼职，2.全职 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数据库数据模型转化为视图模型返回给请求端
        /// </summary>
        public List<GetAddressListViewModel> GetViewModels(List<T_EPAddress> models, List<DicRegion> regions)
        {
            var viewModels = new List<GetAddressListViewModel>();
            foreach (var model in models)
            {
                viewModels.Add(new GetAddressListViewModel
                {
                    AddressId = model.Id,
                    Address = model.Address ?? string.Empty,
                    Province = regions.FirstOrDefault(r => r.Id == model.ProvinceId)?.Description ?? string.Empty,
                    City = regions.FirstOrDefault(r => r.Id == model.CityId)?.Description ?? string.Empty,
                    Area = regions.FirstOrDefault(r => r.Id == model.AreaId)?.Description ?? string.Empty,
                    Type = model.Type
                });
            }

            return viewModels;
        }

    }
}
