/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AddEPAddressViewModel.cs
 *      Description:
 *            AddEPAddressViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 13:20:35
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EPAddress
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class AddEPAddressRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

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
    }

    /// <summary>
    /// AddEPAddressViewModel
    /// </summary>
    public class AddEPAddressViewModel
    {
    }
}
