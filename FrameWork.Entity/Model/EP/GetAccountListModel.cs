/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetAccountListModel.cs
 *      Description:
 *            GetAccountListModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 19:40:29
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.Model.EP
{
    /// <summary>
    /// GetAccountListModel
    /// </summary>
    public class GetAccountListModel
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
        /// 账号类型，1：主账号，2.子账号
        /// </summary>
        public byte AccountType { set; get; }

        /// <summary>
        /// vip类型
        /// </summary>
        public string VipType { set; get; }

        /// <summary>
        /// 有多少个区域的vip，计算对应的子账号数目
        /// </summary>
        public int VipCount { set; get; }
    }
}
