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
using System.ComponentModel;
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

    /// <summary>
    /// 等级信息：0.未认证，1.普通，2.一级雇主，3.二级，4.三级，5.四级，6.五级
    /// </summary>
    public enum JobEmployerLevelEnum
    {
        /// <summary>
        /// 0.未认证
        /// </summary>
        [Description("未认证")]
        NotAuth,

        /// <summary>
        /// 1.普通
        /// </summary>
        [Description("普通")]
        Common,

        /// <summary>
        /// 2、一级雇主
        /// </summary>
        [Description("一级雇主")]
        LevelOne,

        /// <summary>
        /// 3、二级雇主
        /// </summary>
        [Description("二级雇主")]
        LevelTwo,

        /// <summary>
        /// 4、三级雇主
        /// </summary>
        [Description("三级雇主")]
        LevelThree,

        /// <summary>
        /// 5、四级雇主
        /// </summary>
        [Description("四级雇主")]
        LevelFour,

        /// <summary>
        /// 6、五级雇主
        /// </summary>
        [Description("五级雇主")]
        LevelFive
    }
}
