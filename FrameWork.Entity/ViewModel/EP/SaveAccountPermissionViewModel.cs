/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SaveAccountPermissionViewModel.cs
 *      Description:
 *            SaveAccountPermissionViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 22:12:24
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
    /// SaveAccountPermissionRequest
    /// </summary>
    public class SaveAccountPermissionRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 子账号id
        /// </summary>
        public int SubAccoundId { set; get; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { set; get; }

        /// <summary>
        /// 启用或禁用权限
        /// </summary>
        public bool IsUsed { set; get; }
    }
}
