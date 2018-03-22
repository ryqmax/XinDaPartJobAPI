/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetVipListViewModel.cs
 *      Description:
 *            GetVipListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 19:21:16
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
    /// GetVipListRequest
    /// </summary>
    public class GetVipListRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }
    }

    /// <summary>
    /// 视图模型
    /// </summary>
    public class GetVipListViewModel
    {
        /// <summary>
        /// - 
        /// </summary>
        public int VipInfoId { get; set; }

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
        /// 转化为视图模型数据
        /// </summary>
        public List<GetVipListViewModel> GetViewModels(List<T_VIPInfo> models)
        {
            var viewModels = new List<GetVipListViewModel>();
            foreach (var model in models)
            {
                viewModels.Add(new GetVipListViewModel
                {
                    VipInfoId = model.Id,
                    Description = model.Description,
                    Name = model.Name,
                    NewPrice = model.NewPrice,
                    OldPrice = model.OldPrice
                });
            }

            return viewModels;
        }
    }
}
