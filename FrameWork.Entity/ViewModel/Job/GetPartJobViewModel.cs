/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetPartJobViewModel.cs
 *      Description:
 *            GetPartJobViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 20:43:22
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
    /// 获取兼职岗位参数
    /// </summary>
    public class GetPartJobRequest
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public string JobId { set; get; }
    }

    /// <summary>
    /// GetPartJobViewModel
    /// </summary>
    public class GetPartJobViewModel
    {
    }
}
