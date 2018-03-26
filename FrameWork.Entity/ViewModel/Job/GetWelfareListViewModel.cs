/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetWelfareListViewModel.cs
 *      Description:
 *            GetWelfareListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/26 21:30:14
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
    /// GetWelfareListRequest
    /// </summary>
    public class GetWelfareListRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }
    }

    public class GetWelfareListViewModel
    {
        /// <summary>
        /// 福利id
        /// </summary>
        public int WelfareId { set; get; }

        /// <summary>
        /// 福利名称 
        /// </summary>
        public string WelfareName { get; set; }

        public List<GetWelfareListViewModel> GetViewModels(List<T_EPWelfare> models)
        {
            var viewModels = new List<GetWelfareListViewModel>();
            foreach (var model in models)
            {
                viewModels.Add(new GetWelfareListViewModel
                {
                    WelfareId = model.Id,
                    WelfareName = model.Name ?? string.Empty
                });
            }
            return viewModels;
        }
    }
}
