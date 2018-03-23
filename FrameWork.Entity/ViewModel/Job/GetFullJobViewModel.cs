/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetFullJobViewModel.cs
 *      Description:
 *            GetFullJobViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/23 21:13:17
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Job;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// 获取全职岗位详情参数
    /// </summary>
    public class GetFullJobRequest
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

    }

    /// <summary>
    /// GetFullJobViewModel
    /// </summary>
    public class GetFullJobViewModel
    {
        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

        /// <summary>
        /// 岗位名字
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// 工资
        /// </summary>
        public string Salary { set; get; }

        /// <summary>
        /// 工作岗位类别名称
        /// </summary>
        public string JobCategoryName { set; get; }

        /// <summary>
        /// 结算单位
        /// </summary>
        public string PayUnit { set; get; }
        
        /// <summary>
        /// 申请数量
        /// </summary>
        public int ApplyCount { set; get; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewCount { set; get; }

        /// <summary>
        /// 企业logo
        /// </summary>
        public string EPLogo { set; get; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EPName { set; get; }

        /// <summary>
        /// 企业id
        /// </summary>
        public int EnterpriseId { set; get; }

        /// <summary>
        /// 等级信息：0.未认证，1.普通，2.一级雇主，3.二级，4.三级，5.四级，6.五级
        /// </summary>
        public byte EPLevel { set; get; }

        /// <summary>
        /// 等级名称
        /// </summary>
        public string EPLevelName { set; get; }

        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkTime { set; get; }

        /// <summary>
        /// 任职要求
        /// </summary>
        public string OfficeRequire { set; get; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent { set; get; }

        /// <summary>
        /// 招聘联系人姓名
        /// </summary>
        public string EPHiringManagerName { set; get; }

        /// <summary>
        /// 招聘联系人头像
        /// </summary>
        public string EPHiringHeadImg { set; get; }

        /// <summary>
        /// 招聘联系人电话
        /// </summary>
        public string EPHiringPhone { set; get; }

        /// <summary>
        /// 简历id，大于0 则表示简历id，可以投递。等于0则表示不能投递
        /// </summary>
        public int CVId { set; get; }

        /// <summary>
        /// 岗位工作地点列表
        /// </summary>
        public List<FullJobAddress> JobAddressList = new List<FullJobAddress>();

        /// <summary>
        /// 屏蔽列表
        /// </summary>
        public List<FullShieldItem> ShieldList = new List<FullShieldItem>();

        /// <summary>
        /// 福利列表
        /// </summary>
        public List<WelFare> WelFareList = new List<WelFare>();


        public GetFullJobViewModel GetViewModel(GetFullJobModel model, List<T_EPAddress> addrList, List<DicRegion> regions, List<T_EPWelfare> welfares)
        {
            var viewModel = new GetFullJobViewModel
            {
                JobId = model.JobId,
                JobName = StringHelper.NullOrEmpty(model.JobName),
                ApplyCount = model.ApplyCount,
                EnterpriseId = model.EnterpriseId,
                EPHiringHeadImg = PictureHelper.ConcatPicUrl(model.EPHiringHeadImg),
                EPHiringManagerName = StringHelper.NullOrEmpty(model.EPHiringManagerName),
                EPHiringPhone = StringHelper.NullOrEmpty(model.EPHiringPhone),
                EPLevel = model.EPLevel,
                EPLevelName = GetEPLevelName(model.EPLevel),
                EPLogo = PictureHelper.ConcatPicUrl(model.EPLogo),
                EPName = StringHelper.NullOrEmpty(model.EPName),
                JobCategoryName = StringHelper.NullOrEmpty(model.JobCategoryName),
                OfficeRequire = StringHelper.NullOrEmpty(model.OfficeRequire),
                PayUnit = "元/月",
                Salary = $"{model.SalaryLower}-{model.SalaryUpper}",
                ViewCount = model.ViewCount,
                WorkContent = StringHelper.NullOrEmpty(model.WorkContent),
                WorkTime = StringHelper.NullOrEmpty(model.WorkTime),
                CVId = model.CVId 
            };
            foreach (var address in addrList)
            {
                var province = regions.FirstOrDefault(r => r.Id == address.ProvinceId) ?? new DicRegion();
                var city = regions.FirstOrDefault(r => r.Id == address.CityId) ?? new DicRegion();
                var area = regions.FirstOrDefault(r => r.Id == address.AreaId) ?? new DicRegion();
                viewModel.JobAddressList.Add(new FullJobAddress
                {
                    Address = $@"{province.Description} {city.Description} {area.Description}",
                    AddressId = address.Id,
                    Lat = address.Lat ?? 0,
                    Lng = address.Lng ?? 0
                });
            }

            foreach (var welfare in welfares)
            {
                viewModel.WelFareList.Add(new WelFare
                {
                    Name = welfare.Name ?? string.Empty
                });
            }

            viewModel.ShieldList.Add(new FullShieldItem { ShieldTime = 15, ShieldTitle = "此岗位屏蔽十五天" });
            viewModel.ShieldList.Add(new FullShieldItem { ShieldTime = 30, ShieldTitle = "此岗位屏蔽三十天" });
            viewModel.ShieldList.Add(new FullShieldItem { ShieldTime = 90, ShieldTitle = "此岗位屏蔽九十天" });

            return viewModel;
        }

        /// <summary>
        /// 获取雇主等级名称：等级信息：0.未认证，1.普通，2.一级雇主，3.二级，4.三级，5.四级，6.五级
        /// </summary>
        private string GetEPLevelName(byte level)
        {
            string epLevelName;
            switch (level)
            {
                case 0:
                    epLevelName = "未认证雇主";
                    break;
                case 1:
                    epLevelName = "普通雇主";
                    break;
                case 2:
                    epLevelName = "一级雇主";
                    break;
                case 3:
                    epLevelName = "二级雇主";
                    break;
                case 4:
                    epLevelName = "三级雇主";
                    break;
                case 5:
                    epLevelName = "四级雇主";
                    break;
                case 6:
                    epLevelName = "五级雇主";
                    break;
                default:
                    epLevelName = "未认证雇主";
                    break;
            }

            return epLevelName;
        }
    }


    public class WelFare
    {
        /// <summary>
        /// 福利名称 
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 岗位的工作地点
    /// </summary>
    public class FullJobAddress
    {
        /// <summary>
        /// 地点id，-1表示不限地点
        /// </summary>
        public int AddressId { set; get; }

        /// <summary>
        /// 工作地点
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 经度 
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// 纬度 
        /// </summary>
        public decimal Lat { get; set; }
    }

    /// <summary>
    /// 屏蔽元素
    /// </summary>
    public class FullShieldItem
    {
        /// <summary>
        /// 屏蔽时长
        /// </summary>
        public int ShieldTime { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        public string ShieldTitle { set; get; }
    }
}
