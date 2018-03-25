/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SubmitPartJobViewModel.cs
 *      Description:
 *            SubmitPartJobViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 17:45:02
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// SubmitPartJobViewModel
    /// </summary>
    public class SubmitPartJobViewModel
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 岗位类别id
        /// </summary>
        public int JobCategoryId { set; get; }

        /// <summary>
        /// 结算方式id
        /// </summary>
        public int PayWayId { set; get; }

        /// <summary>
        /// 薪资下限 
        /// </summary>
        public int SalaryLower { get; set; }

        /// <summary>
        /// 薪资上限 
        /// </summary>
        public int SalaryUpper { get; set; }

        /// <summary>
        /// 工作时间：单双休 
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// 工作内容，限制1000字，但是包括一些HTML转义字符 
        /// </summary>
        public string WorkContent { get; set; }

        /// <summary>
        /// 任职要求，限制1000字，但是包括一些HTML转义字符 
        /// </summary>
        public string OfficeRequire { get; set; }

        /// <summary>
        /// 地址id列表
        /// </summary>
        public List<int> AddressList { set; get; }

        /// <summary>
        /// 招聘联系人id 
        /// </summary>
        public int EPHiringManagerId { get; set; }

        /// <summary>
        /// 刷新方式：0.不刷新，1.智能刷新，2.预约刷新
        /// </summary>
        public int RefreshWay { get; set; }

        /// <summary>
        /// 预约刷新id
        /// </summary>
        public int RefreshId { get; set; }
    }
}
