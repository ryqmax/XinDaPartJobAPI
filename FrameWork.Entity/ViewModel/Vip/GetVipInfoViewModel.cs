/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetVipInfoViewModel.cs
 *      Description:
 *            GetVipInfoViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 19:42:36
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.Vip
{
    /// <summary>
    /// 获取vip详情参数
    /// </summary>
    public class GetVipInfoRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 会员信息id
        /// </summary>
        public int VipInfoId { get; set; }
    }

    /// <summary>
    /// GetVipInfoViewModel
    /// </summary>
    public class GetVipInfoViewModel
    {
        /// <summary>
        /// 会员名称：年度会员，半年会员，季度会员，月度会员 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 会员描述：有效期一年 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 原价 
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 现价 
        /// </summary>
        public decimal NewPrice { get; set; }

        /// <summary>
        /// 子账号添加数量
        /// </summary>
        public int AccountCount { get; set; }

        /// <summary>
        /// 每个岗位可以添加的地址数量 
        /// </summary>
        public int AddressPerJob { get; set; }

        /// <summary>
        /// 每天职位刷新次数限制 
        /// </summary>
        public int JobRefreshPerDayCount { get; set; }

        /// <summary>
        /// 可以获得的积分 
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        /// 客服帮助
        /// </summary>
        public string Kfbz { set; get; }

        /// <summary>
        /// 岗位推荐
        /// </summary>
        public string Gwtj { set; get; }

        /// <summary>
        /// 职位发布，多少钱一个
        /// </summary>
        public int Zwfb { set; get; }

        /// <summary>
        /// 简历下载，多少钱一个
        /// </summary>
        public int Jlxz { set; get; }

        /// <summary>
        /// 职位刷新,多少钱一次
        /// </summary>
        public int Zwsx { set; get; }

        /// <summary>
        /// 视图模型转化
        /// </summary>
        public GetVipInfoViewModel GetViewModel(T_VIPInfo model)
        {
            var viewModel = new GetVipInfoViewModel
            {
                AccountCount = model.AccountCount,
                AddressPerJob = model.AddressPerJob,
                Description = model.Description,
                OldPrice = model.OldPrice,
                Name = model.Name,
                NewPrice = model.NewPrice,
                Gwtj = "全网/市",
                Kfbz = "专线",
                Integral = (int)model.NewPrice * 10,
                JobRefreshPerDayCount = model.JobRefreshPerDayCount,
                Jlxz = 0,
                Zwfb = 0,
                Zwsx = 0
            };

            return viewModel;
        }
    }
}
