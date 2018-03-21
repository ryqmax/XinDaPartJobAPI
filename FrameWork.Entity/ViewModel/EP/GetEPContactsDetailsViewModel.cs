/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPContactsDetailsViewModel.cs
 *      Description:
 *            GetEPContactsDetailsViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 20:04:41
 *      History:
 ***********************************************************************************/


using System;
using FrameWork.Common;
using FrameWork.Common.Enum;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// GetEPContactsDetailsViewModel
    /// </summary>
    public class GetEPContactsDetailsRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 联系人id
        /// </summary>
        public int EPContactsId { set; get; }

    }

    public class GetEPContactsDetailsViewModel
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
        /// 小程序图片展示地址，这个地址只用于展示
        /// </summary>
        public string ShowUrl { set; get; }

        /// <summary>
        /// 保存到数据库的图片地址，接口提交时传递这个值
        /// </summary>
        public string SaveUrl { set; get; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuth { get; set; }

        /// <summary>
        /// 数据模型转化
        /// </summary>
        public GetEPContactsDetailsViewModel GetViewModel(T_EPHiringManager model)
        {
            var viewModel = new GetEPContactsDetailsViewModel
            {
                EPContactsId = model.Id,
                EPContactsName = StringHelper.NullOrEmpty(model.Name),
                IsAuth = model.AuthStatus == (byte)AuthStatus.Auth,
                Phone = StringHelper.NullOrEmpty(Phone),
                SaveUrl = model.HeadPicUrl ?? string.Empty,
                ShowUrl = PictureHelper.ConcatPicUrl(model.HeadPicUrl)
            };
            return viewModel;
        }
    }
}
