/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetAccountListViewModel.cs
 *      Description:
 *            GetAccountListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 19:39:44
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
    /// <summary>
    /// GetAccountListRequest
    /// </summary>
    public class GetAccountListRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

    }

    public class GetAccountListViewModel
    {
        /// <summary>
        /// 企业logo图片地址
        /// </summary>
        public string Logo { set; get; }

        /// <summary>
        /// 账号id
        /// </summary>
        public int AccountId { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 主账号名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// vip类型
        /// </summary>
        public string VipType { set; get; }

        /// <summary>
        /// 子账号数目
        /// </summary>
        public int AccountCount { set; get; }

        /// <summary>
        /// 子账号列表
        /// </summary>
        public List<EPSubAccount> SubAccountList = new List<EPSubAccount>();

        /// <summary>
        /// 获取对应的模型列表
        /// </summary>
        public GetAccountListViewModel GetViewModels(List<GetAccountListModel> models)
        {
            var viewModel = new GetAccountListViewModel();
            var item = models.FirstOrDefault(m => m.AccountType == 1);
            if (item != null)
            {
                viewModel.Phone = item.Phone ?? string.Empty;
                viewModel.AccountCount = item.VipCount * 4;
                viewModel.AccountId = item.AccountId;
                viewModel.Logo = PictureHelper.ConcatPicUrl(item.Logo);
                viewModel.Name = "主账号";
                viewModel.VipType = item.VipType;
            }
            foreach (var model in models)
            {
                viewModel.SubAccountList.Add(new EPSubAccount
                {
                    AccountId = model.AccountId,
                    Phone = model.Phone ?? string.Empty
                });
            }

            return viewModel;
        }

    }


    public class EPSubAccount
    {
        /// <summary>
        /// 账号id
        /// </summary>
        public int AccountId { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }
    }

}
