using System;
using FrameWork.Common.Enum;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// 岗位信息
    /// </summary>
    public class JobInfo
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
        /// 雇主级别Id 
        /// </summary>
        public JobEmployerLevelEnum JobEmployerLevel { get; set; }

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
        /// 计费单位
        /// </summary>
        public string Unit { get; set; }

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
        /// 是否为实习 
        /// </summary>
        public bool IsPractice { get; set; }

        /// <summary>
        /// 总条数 
        /// </summary>
        public int TotalNum { get; set; }
    }
}
