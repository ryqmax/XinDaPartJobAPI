/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                CommonEnum.cs
 *      Description:
 *            CommonEnum
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/18 14:42:32
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
    /// CommonEnum
    /// </summary>
    public enum CommonEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        OpraterSuccess = 10000,

        /// <summary>
        /// 操作失败
        /// </summary>
        OpraterError = 20000,

        /// <summary>
        /// Token验证错误
        /// </summary>
        TokenError = 20001
    }
}
