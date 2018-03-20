using System;
using System.Collections.Generic;
using FrameWork.Common.Enum;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// 获取岗位列表返回模型
    /// </summary>
    public class GetJobListRespInfo
    {
        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// 企业id 
        /// </summary>
        public int JobEmployerId { get; set; }

        /// <summary>
        /// 雇主级别（一级雇主）
        /// </summary>
        public string JobEmployerName { get; set; }

        /// <summary>
        /// 岗位名称 
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 薪资（100-150） 
        /// </summary>
        public string JobPay { get; set; }

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
        /// 是否是自己的企业发布 
        /// </summary>
        public bool IsSelf { get; set; }


        /// <summary>
        /// 是否为广告 
        /// </summary>
        public bool IsAdvert { get; set; }

        public List<AdListItem> AdList { get; set; }=new List<AdListItem>();

        /// <summary>
        /// 是否为实习 
        /// </summary>
        public bool IsPractice { get; set; }

        /// <summary>
        /// 是否结束 
        /// </summary>
        public bool IsEnd { get; set; }
    }

    public class AdListItem
    {
        /// <summary>
        /// 教育培训 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 广告名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 广告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 公司地址 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string Url { get; set; }
    }
}
