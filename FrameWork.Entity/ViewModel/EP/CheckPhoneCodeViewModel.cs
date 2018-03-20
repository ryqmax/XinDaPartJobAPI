/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                CheckPhoneCode.cs
 *      Description:
 *            CheckPhoneCode
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 21:39:01
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
    /// CheckPhoneCode
    /// </summary>
    public class CheckPhoneCodeViewModel
    {
        /// <summary>
        /// 企业令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 手机验证码
        /// </summary>
        public string VerifyCode { set; get; }

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone { get; set; }
    }
}
