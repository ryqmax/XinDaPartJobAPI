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
using FrameWork.Common;
using FrameWork.Entity.Entity;

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
        /// <summary>
        /// 联系人id
        /// </summary>
        public int EPContactsId { set; get; }

        /// <summary>
        /// 联系人名字
        /// </summary>
        public string EPContactsName { set; get; }

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 头像地址 
        /// </summary>
        public string HeadPicUrl { get; set; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuth { get; set; }

        /// <summary>
        /// 数据库实体模型转化为视图模型
        /// </summary>
        public List<GetEPContactsViewModel> GetvViewModels(List<T_EPHiringManager> models)
        {
            var viewModels = new List<GetEPContactsViewModel>();
            foreach (var model in models)
            {
                var viewModel = new GetEPContactsViewModel
                {
                    EPContactsId = model.Id,
                    EPContactsName = StringHelper.NullOrEmpty(model.Name),
                    HeadPicUrl = PictureHelper.ConcatPicUrl(model.HeadPicUrl),
                    IsAuth = model.AuthStatus == 1,
                    Phone = StringHelper.NullOrEmpty(model.Phone)
                };
                viewModels.Add(viewModel);
            }

            return viewModels;
        }
    }
}
