/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPCenterViewModel.cs
 *      Description:
 *            GetEPCenterViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/27 20:55:36
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Model.EP;

namespace FrameWork.Entity.ViewModel.EP
{

    public class GetEPCenterRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }
    }

    /// <summary>
    /// GetEPCenterViewModel
    /// </summary>
    public class GetEPCenterViewModel
    {
        /// <summary>
        /// 企业名字
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 等级信息：1.未认证，2.普通，3.一级雇主，4.二级，5.三级，6.四级，7.五级
        /// </summary>
        public byte Level { set; get; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { set; get; }

        /// <summary>
        /// 总积分
        /// </summary>
        public int TotalIntegral { set; get; }

        /// <summary>
        /// 发布的岗位数量
        /// </summary>
        public int JobCount { set; get; }

        /// <summary>
        /// 智能匹配岗位数量
        /// </summary>
        public int AutoJobCount { set; get; }

        /// <summary>
        /// 账号类型，1：主账号，2.子账号
        /// </summary>
        public byte AccountType { set; get; }

        /// <summary>
        /// 投递简历数量
        /// </summary>
        public int CVCount { set; get; }

        /// <summary>
        /// 购买简历数量
        /// </summary>
        public int BuyCVCount { set; get; }

        /// <summary>
        /// 企业是否认证
        /// </summary>
        public bool EPIsAuth { set; get; }

        /// <summary>
        /// 招聘联系人是否认证
        /// </summary>
        public bool HireIsAuth { set; get; }

        /// <summary>
        /// 子账号  1/4
        /// </summary>
        public string AccountCount { set; get; }

        /// <summary>
        /// 会员信息：年度会员 剩余45天
        /// </summary>
        public string VipInfo { set; get; }

        /// <summary>
        /// 客服电话
        /// </summary>
        public string ServicePhone { set; get; }

        public GetEPCenterViewModel GetViewModel(GetEPCenterModel model)
        {
            var passDate = model.VipPassDate ?? DateTime.Now;
            var leftDays = (int) (passDate.Date - DateTime.Now).TotalDays;
            if (leftDays < 0)
                leftDays = 0;
            var viewModel = new GetEPCenterViewModel
            {
                Name = model.Name ?? string.Empty,
                AccountCount = $"{model.AccountCount}/{model.AccountMax}",
                AutoJobCount = model.AutoJobCount,
                BuyCVCount = model.BuyCVCount,
                CVCount = model.CVCount,
                EPIsAuth = model.Level > 0,
                HireIsAuth = model.HTotalCount == model.AuthCount,
                JobCount = model.JobCount,
                Level = model.Level,
                Logo = PictureHelper.ConcatPicUrl(model.Logo),
                TotalIntegral = model.TotalIntegral,
                VipInfo = $"{model.VipName ?? string.Empty} 剩余{leftDays}天",
                AccountType = model.AccountType,
                ServicePhone = "400-161-6661"
            };
            if (string.IsNullOrEmpty(model.VipName))
            {
                viewModel.ServicePhone = string.Empty;
                viewModel.VipInfo = string.Empty;
            }
            
            return viewModel;
        }
    }
}
