/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPAuthViewModel.cs
 *      Description:
 *            GetEPAuthViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/27 19:57:12
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
    /// GetEPAuthRequest
    /// </summary>
    public class GetEPAuthRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

    }

    public class GetEPAuthViewModel
    {
        /// <summary>
        /// 公司全称
        /// </summary>
        public string CompanyName { set; get; }

        /// <summary>
        /// 公司简称
        /// </summary>
        public string CompanyShort { set; get; }

        /// <summary>
        /// 企业地址
        /// </summary>
        public string CompanyAddress { set; get; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyDesc { set; get; }

        /// <summary>
        /// 公司logo
        /// </summary>
        public string CompanyLogo { set; get; }

        /// <summary>
        /// 公司实景图片列表
        /// </summary>
        public List<string> CompanyPhotos = new List<string>();

        /// <summary>
        /// 公司认证图片
        /// </summary>
        public string AuthPicUrl { set; get; }

        /// <summary>
        /// 经度 
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// 纬度 
        /// </summary>
        public decimal Lat { get; set; }

        /// <summary>
        /// 审核状态：0.未提交审核（保存信息），1.审核中，2.审核未通过，3.审核通过 
        /// </summary>
        public int CheckStatus { get; set; }

        /// <summary>
        /// 审核备注或者审核不通过原因 
        /// </summary>
        public string CheckNote { get; set; }

        /// <summary>
        /// 完成度
        /// </summary>
        public int Finished { set; get; }

        public GetEPAuthViewModel GetViewModel(T_Enterprise model, List<DicRegion> regions, List<T_EPBgImg> imgs)
        {
            var province = regions.FirstOrDefault(r => r.Id == model.ProvinceId)?.Description ?? string.Empty;
            var city = regions.FirstOrDefault(r => r.Id == model.CityId)?.Description ?? string.Empty;
            var area = regions.FirstOrDefault(r => r.Id == model.AreaId)?.Description ?? string.Empty;

            var viewModel = new GetEPAuthViewModel
            {
                CompanyName = model.Name ?? string.Empty,
                CompanyDesc = model.Brief ?? string.Empty,
                CompanyShort = model.ShortName ?? string.Empty,
                Lng = model.Lng ?? 0,
                Lat = model.Lat ?? 0,
                AuthPicUrl = PictureHelper.ConcatPicUrl(model.AuthPicUrl),
                CompanyLogo = PictureHelper.ConcatPicUrl(model.Logo),
                CompanyAddress = $"{province}{city}{area}{model.Address ?? string.Empty}",
                CheckStatus = model.CheckStatus,
                CheckNote = model.CheckNote ?? string.Empty
            };
            foreach (var img in imgs)
            {
                viewModel.CompanyPhotos.Add(PictureHelper.ConcatPicUrl(img.PicUrl));
            }
            var count = 0;
            if (!string.IsNullOrEmpty(viewModel.CompanyName))
                count++;
            if (!string.IsNullOrEmpty(viewModel.CompanyDesc))
                count++;
            if (!string.IsNullOrEmpty(viewModel.CompanyShort))
                count++;
            if (!string.IsNullOrEmpty(viewModel.AuthPicUrl))
                count++;
            if (!string.IsNullOrEmpty(viewModel.CompanyLogo))
                count++;
            if (!string.IsNullOrEmpty(viewModel.CompanyAddress))
                count++;
            if (viewModel.CompanyPhotos.Any())
                count++;
            if (count == 7)
                viewModel.Finished = 100;
            else if (count == 0)
                viewModel.Finished = 0;
            else
            {
                viewModel.Finished = 100 / 7 * count;
            }
            return viewModel;
        }
    }
}
