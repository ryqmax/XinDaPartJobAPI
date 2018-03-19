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
    /// 企业默认登录参数
    /// </summary>
    public class EPDefaultLogoutRequest
    {
        /// <summary>
        /// 企业登录令牌
        /// </summary>
        public string Token { set; get; }

    }

    /// <summary>
    /// EPLogoutViewModel
    /// </summary>
    public class EPDefaultLoginViewModel
    {
        /// <summary>
        /// 企业登录令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 是否是主账号
        /// </summary>
        public bool IsMainAccount { set; get; }
    }
}
