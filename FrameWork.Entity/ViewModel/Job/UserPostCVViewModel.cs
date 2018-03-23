/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UserPostCVViewModel.cs
 *      Description:
 *            UserPostCVViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/23 20:29:22
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
    /// UserPostCVRequest
    /// </summary>
    public class UserPostCVRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }
    }
}
