/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPDetailInfoRespInfo.cs
 *      Description:
 *            GetEPDetailInfoRespInfo
 *      Author:
 *                a-fei
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 19:40:29
 *      History:
 ***********************************************************************************/


using System.Collections.Generic;
using FrameWork.Common;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// GetEPDetailInfoRespInfo
    /// </summary>
    public class GetEPDetailInfoRespInfo
    {
        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { set; get; }

        /// <summary>
        /// 公司等级Id
        /// </summary>
        public int CompanyEmployerId { set; get; }

        /// <summary>
        /// 公司等级名称：四级雇主
        /// </summary>
        public string CompanyEmployerName { set; get; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { set; get; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { set; get; }

        /// <summary>
        /// 公司全称
        /// </summary>
        public string CompanyFullName { set; get; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyDesc { set; get; }

        /// <summary>
        /// 公司实景列表
        /// </summary>
        public List<CompanyImgListItem> CompanyImgList { set; get; } = new List<CompanyImgListItem>();

        /// <summary>
        /// 岗位列表（全职+兼职）
        /// </summary>
        public List<JobListItem> JobList { set; get; } = new List<JobListItem>();
    }

    public class CompanyImgListItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        private string _Url;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url
        {
            get { return PictureHelper.ConcatPicUrl(_Url); }
            set { _Url = value; }
        }
    }

    public class JobListItem
    {
        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// 岗位分类：1：兼职；2：全职
        /// </summary>
        public int JobType { get; set; }

        /// <summary>
        /// 岗位名称 
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 薪资下限 
        /// </summary>
        public int SalaryLower { get; set; }

        /// <summary>
        /// 薪资上限 
        /// </summary>
        public int SalaryUpper { get; set; }

        /// <summary>
        /// 薪资（100-150） 
        /// </summary>
        public string JobPay {
            get { return $"{SalaryLower}-{SalaryUpper}"; }
        }

        /// <summary>
        /// 计费单位
        /// </summary>
        public string JobPayUnit { get; set; }

        /// <summary>
        /// 工作地点 
        /// </summary>
        public string JobAddress { get; set; }

        /// <summary>
        /// 工作时间 
        /// </summary>
        public string JobTime { get; set; }

        /// <summary>
        /// 会员级别 
        /// </summary>
        public string JobMember { get; set; }

        /// <summary>
        /// 是否为实习 
        /// </summary>
        public bool IsPractice { get; set; }
    }
}
