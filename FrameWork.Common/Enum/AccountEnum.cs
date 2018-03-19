/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AccountEnum.cs
 *      Description:
 *            AccountEnum
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 12:54:11
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Common.Enum
{
    /// <summary>
    /// AccountStatus
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// 禁用
        /// </summary>
        NotUsed = 0,

        /// <summary>
        /// 启用
        /// </summary>
        Using = 1,

        /// <summary>
        /// 违规禁用
        /// </summary>
        IllegalNotUsed = 2
    }

    /// <summary>
    /// 企业账号类型
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// 主账号
        /// </summary>
        Main = 1,

        /// <summary>
        /// 子账号
        /// </summary>
        Sub = 2
    }
}
