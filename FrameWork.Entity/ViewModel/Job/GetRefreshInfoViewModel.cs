/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetRefreshInfoViewModel.cs
 *      Description:
 *            GetRefreshInfoViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 16:17:26
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Model.Job;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// GetRefreshInfoRequest
    /// </summary>
    public class GetRefreshInfoRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }
    }

    public class GetRefreshInfoViewModel
    {
        /// <summary>
        /// 刷新开始时间:1992-03
        /// </summary>
        public string StartTime { set; get; }

        /// <summary>
        /// 时间间隔，单位：分钟.如果是0，说明没有设置预约刷新
        /// </summary>
        public int TimeSpan { set; get; }

        /// <summary>
        /// 刷新天数,如果是0，说明没有设置预约刷新
        /// </summary>
        public int RefreshDay { set; get; }

        /// <summary>
        /// 最大刷新天数
        /// </summary>
        public int MaxRefreshDay { set; get; }

        /// <summary>
        /// 刷新次数, 如果是0，说明没有设置预约刷新
        /// </summary>
        public int RefreshCount { set; get; }

        /// <summary>
        /// 最多刷新次数
        /// </summary>
        public int MaxRefreshCount { set; get; }

        /// <summary>
        /// 视图模型转化
        /// </summary>
        public GetRefreshInfoViewModel GetViewModel(GetRefreshInfoModel model)
        {
            var viewModel = new GetRefreshInfoViewModel
            {
                StartTime = model.StartTime?.ToString("yyyy-MM")??string.Empty,
                MaxRefreshCount = GetMaxCount(model.VIPInfoId),
                MaxRefreshDay = (int)(model.PassDate - DateTime.Now).TotalDays,
                RefreshCount = model.RefreshCount,
                RefreshDay = model.RefreshDay,
                TimeSpan = model.TimeSpan
            };
            return viewModel;
        }

        /// <summary>
        /// 根据vip等级获取最大刷新次数
        /// </summary>
        private int GetMaxCount(int vipId)
        {
            var res = 0;
            switch (vipId)
            {
                case 1:
                    res = 12;
                    break;
                case 2:
                    res = 9;
                    break;
                case 3:
                    res = 6;
                    break;
                case 4:
                    res = 3;
                    break;
            }

            return res;
        }
    }
}
