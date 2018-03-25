/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetRefreshInfoModel.cs
 *      Description:
 *            GetRefreshInfoModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 16:35:53
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.Model.Job
{
    /// <summary>
    /// GetRefreshInfoModel
    /// </summary>
    public class GetRefreshInfoModel
    {
        /// <summary>
        /// 根据id区分会员等级
        /// </summary>
        public int VIPInfoId { set; get; }

        /// <summary>
        /// 刷新id
        /// </summary>
        public int RefreshId { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime PassDate { set; get; }

        /// <summary>
        /// 预约刷新开始时间
        /// </summary>
        public DateTime? StartTime { set; get; }

        /// <summary>
        /// 时间间隔，单位：分钟
        /// </summary>
        public int TimeSpan { set; get; }

        /// <summary>
        /// 刷新的天数
        /// </summary>
        public int RefreshDay { set; get; }

        /// <summary>
        /// 预定的每天刷新次数
        /// </summary>
        public int RefreshCount { set; get; }

    }
}
