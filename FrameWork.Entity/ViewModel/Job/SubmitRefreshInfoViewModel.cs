/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SubmitRefreshInfoViewModel.cs
 *      Description:
 *            SubmitRefreshInfoViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 16:57:50
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// SubmitRefreshInfoRequest
    /// </summary>
    public class SubmitRefreshInfoRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

        /// <summary>
        /// 刷新开始时间:03月26日 00:00
        /// </summary>
        public string StartTime { set; get; }

        /// <summary>
        /// 时间间隔，单位：分钟
        /// </summary>
        public int TimeSpan { set; get; }

        /// <summary>
        /// 刷新天数
        /// </summary>
        public int RefreshDay { set; get; }

        /// <summary>
        /// 刷新次数, 如果是0，说明没有设置预约刷新
        /// </summary>
        public int RefreshCount { set; get; }
    }

    public class SubmitRefreshInfoViewModel
    {
        /// <summary>
        /// 刷新id，如果id为0则新增
        /// </summary>
        public int RefreshId { set; get; }
    }
}
