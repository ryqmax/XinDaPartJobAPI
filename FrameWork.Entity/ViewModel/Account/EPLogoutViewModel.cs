/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPLogoutViewModel.cs
 *      Description:
 *            EPLogoutViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 20:28:28
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Account
{

    /// <summary>
    /// 退出企业登录参数
    /// </summary>
    public class EPLogoutRequest
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 微信标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string City { set; get; }

    }

    /// <summary>
    /// EPLogoutViewModel
    /// </summary>
    public class EPLogoutViewModel
    {
        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户标识符 GUID字符串
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 微信账户唯一标识符
        /// </summary>
        public string OpenId { set; get; }
    }
}
