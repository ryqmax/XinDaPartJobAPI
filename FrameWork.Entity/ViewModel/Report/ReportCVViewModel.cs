/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                ReportCVViewModel.cs
 *      Description:
 *            ReportCVViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/24 21:24:49
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Report
{
    /// <summary>
    /// ReportCVRequest
    /// </summary>
    public class ReportCVRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 兼职简历技能描述
        /// </summary>
        public string SkillDesc { set; get; }

        /// <summary>
        /// 简历类别id字符串，格式/1/2/
        /// </summary>
        public List<int> JobCategoryIds { set; get; }

        /// <summary>
        /// 岗位类别名称字符串，格式：/会计/财务/
        /// </summary>
        public List<string> JobCategoryNames { set; get; }

        /// <summary>
        /// 举报原因Id,格式：/1/2/
        /// </summary>
        public List<int> ReasonIds { set; get; }

        /// <summary>
        /// 举报原因内容，格式:/原因1/原因2/
        /// </summary>
        public List<string> Reasons { set; get; }

        /// <summary>
        /// 说明或凭证
        /// </summary>
        public string Note { set; get; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public List<string> NoteImgUrl { set; get; }

    }
}
