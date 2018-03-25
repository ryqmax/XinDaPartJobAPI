/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetIndexBaseDataRespInfo.cs
 *      Description:
 *            GetIndexBaseDataRespInfo
 *      Author:
 *                a-fei
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 15:07:02
 *      History:
 ***********************************************************************************/

using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// GetCityListViewModel
    /// </summary>
    public class GetIndexBaseDataRespInfo
    {
        public List<RegionListItem> Region { get; set; } = new List<RegionListItem>();
        public List<EmployerListItem> Employer { get; set; } = new List<EmployerListItem>();
        public List<JobTypeListItem> JobType { get; set; } = new List<JobTypeListItem>();
        public List<BannerListItem> BannerList { get; set; } = new List<BannerListItem>();
    }

    public class RegionListItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string RegionId { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

    public class EmployerListItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string EmployerId { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

    public class JobTypeListItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string JobTypeId { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

    public class BannerListItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public string BannerId { get; set; } = string.Empty;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgUrl { get; set; } = string.Empty;

        /// <summary>
        /// 链接地址
        /// </summary>
        public string BannerUrl { get; set; } = string.Empty;
    }
}
