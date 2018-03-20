/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SaveEPContactsViewModel.cs
 *      Description:
 *            SaveEPContactsViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 22:13:36
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
    /// SaveEPContactsViewModel
    /// </summary>
    public class SaveEPContactsRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 联系人名字
        /// </summary>
        public string ContactsName { set; get; }

        /// <summary>
        /// 头像地址,相对地址
        /// </summary>
        public string HeadImg { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }
    }
}
