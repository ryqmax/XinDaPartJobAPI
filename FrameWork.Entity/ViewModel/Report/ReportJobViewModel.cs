/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                ReportJobViewModel.cs
 *      Description:
 *            ReportJobViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 11:57:11
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
    /// ReportJobRequest
    /// </summary>
    public class ReportJobRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public int JobName { set; get; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EPName { set; get; }

        /// <summary>
        /// 举报原因Id
        /// </summary>
        public List<int> ReasonIds { set; get; }

        /// <summary>
        /// 举报原因内容
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
