/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetReportReasonRequest.cs
 *      Description:
 *            GetReportReasonRequest
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 12:58:40
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.Report
{
    /// <summary>
    /// GetReportReasonRequest
    /// </summary>
    public class GetReportReasonRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 请求类型，1.简历，2.岗位
        /// </summary>
        public int Type { set; get; }
    }

    /// <summary>
    /// 视图模型
    /// </summary>
    public class GetReportReasonViewModel
    {
        /// <summary>
        /// 原因id
        /// </summary>
        public int ReasonId { set; get; }

        /// <summary>
        /// 举报原因
        /// </summary>
        public string Name { set; get; }


        public List<GetReportReasonViewModel> GetViewModels(List<T_ReportReason> models)
        {
            var viewModels = new List<GetReportReasonViewModel>();
            foreach (var model in models)
            {
                viewModels.Add(new GetReportReasonViewModel
                {
                    ReasonId = model.Id,
                    Name = model.Name ?? string.Empty
                });
            }
            return viewModels;
        }
    }
}
