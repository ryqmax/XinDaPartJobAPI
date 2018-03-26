/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SaveWelfareViewModel.cs
 *      Description:
 *            SaveWelfareViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/26 21:14:30
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
    /// SaveWelfareRequest
    /// </summary>
    public class SaveWelfareRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 福利名称
        /// </summary>
        public string WelfareName { set; get; }
    }
}
