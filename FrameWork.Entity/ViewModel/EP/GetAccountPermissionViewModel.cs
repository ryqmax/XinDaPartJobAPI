/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetAccountPermissionViewModel.cs
 *      Description:
 *            GetAccountPermissionViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 20:51:01
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// GetAccountPermissionRequest
    /// </summary>
    public class GetAccountPermissionRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 子账号id
        /// </summary>
        public int SubAccoundId { set; get; }
    }

    /// <summary>
    /// 视图模型
    /// </summary>
    public class GetAccountPermissionViewModel
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { set; get; }

        /// <summary>
        /// 菜单名字
        /// </summary>
        public string MenuName { set; get; }

        /// <summary>
        /// 是否拥有这个权限
        /// </summary>
        public bool IsUsed { set; get; }


        public List<GetAccountPermissionViewModel> GetViewModel(List<T_AccountPermission> allPermissions, T_EPAccount model)
        {
            var viewModels = new List<GetAccountPermissionViewModel>();
            var accountPerm = model.PermissionIds?.Split(',').ToList() ?? new List<string>();
            foreach (var permission in allPermissions)
            {
                viewModels.Add(new GetAccountPermissionViewModel
                {
                    MenuId = permission.Id,
                    MenuName = permission.Name,
                    IsUsed = accountPerm.Contains(permission.Id + "")
                });
            }

            return viewModels;
        }
    }
}
