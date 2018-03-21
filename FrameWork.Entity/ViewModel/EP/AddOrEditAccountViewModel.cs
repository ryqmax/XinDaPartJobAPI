/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AddOrEditAccountViewModel.cs
 *      Description:
 *            AddOrEditAccountViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 20:02:03
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// AddOrEditAccountViewModel
    /// </summary>
    public class AddOrEditAccountViewModel
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { set; get; }

        /// <summary>
        /// 子账号id
        /// </summary>
        public int SubAccoundId { set; get; }
    }
}
