/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SaveEPViewModel.cs
 *      Description:
 *            SaveEPViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/27 18:58:32
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// SaveEPRequest
    /// </summary>
    public class SaveEPRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 公司全称
        /// </summary>
        public string CompanyName { set; get; }

        /// <summary>
        /// 公司简称
        /// </summary>
        public string CompanyShort { set; get; }

        /// <summary>
        /// 企业地址
        /// </summary>
        public string CompanyAddress { set; get; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyDesc { set; get; }

        /// <summary>
        /// 公司logo
        /// </summary>
        public string CompanyLogo { set; get; }

        /// <summary>
        /// 公司实景图片列表
        /// </summary>
        public List<string> CompanyPhotos { set; get; }

        /// <summary>
        /// 公司认证图片
        /// </summary>
        public string AuthPicUrl { set; get; }

        /// <summary>
        /// 经度 
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// 纬度 
        /// </summary>
        public decimal Lat { get; set; }

        /// <summary>
        /// 是否申请认证，如果不认证就保存
        /// </summary>
        public bool IsAuth { set; get; }
    }
}
