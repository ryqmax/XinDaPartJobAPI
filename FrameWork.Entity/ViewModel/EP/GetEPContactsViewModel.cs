/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPContactsViewModel.cs
 *      Description:
 *            GetEPContactsViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 08:21:05
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
    /// 获取联系人接口请求参数
    /// </summary>
    public class GetEPContactsRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }
    }

    /// <summary>
    /// GetEPContactsViewModel
    /// </summary>
    public class GetEPContactsViewModel
    {
    }
}
