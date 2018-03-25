/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetPayWayViewModel.cs
 *      Description:
 *            GetPayWayViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 15:49:27
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// GetPayWayRequest
    /// </summary>
    public class GetPayWayRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }
    }

    /// <summary>
    /// 视图模型
    /// </summary>
    public class GetPayWayViewModel
    {
        /// <summary>
        /// 计费方式名称 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 计费单位：元/天 
        /// </summary>
        public string Unit { get; set; }


        public List<GetPayWayViewModel> GetViewModels(List<T_PayWay> models)
        {
            var viewModels = new List<GetPayWayViewModel>();

            return viewModels;
        }
    }
}
