/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetUserPostPartCVListViewModel.cs
 *      Description:
 *            GetUserPostPartCVListViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/23 19:36:57
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Model.Job;

namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class GetUserPostPartCVListRequest
    {
        /// <summary>
        /// 用户token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 工作岗位类别名称
        /// </summary>
        public string JobCategoryName { set; get; }
    }

    /// <summary>
    /// GetUserPostPartCVListViewModel
    /// </summary>
    public class GetUserPostPartCVListViewModel
    {

        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { set; get; }

        /// <summary>
        /// 技能简述
        /// </summary>
        public string SkillSummary { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImg { set; get; }

        /// <summary>
        /// 工作岗位类别名称
        /// </summary>
        public string JobCategoryName { set; get; }

        /// <summary>
        /// 视图模型转化
        /// </summary>
        public List<GetUserPostPartCVListViewModel> GetViewModel(List<GetUserPostPartCVListModel> models,string jcName)
        {
            var viewModels = new List<GetUserPostPartCVListViewModel>();
            foreach (var model in models)
            {
                viewModels.Add(new GetUserPostPartCVListViewModel
                {
                    CVId = model.CVId,
                    HeadImg = model.HeadImg,
                    SkillSummary = StringHelper.NullOrEmpty(model.SkillSummary),
                    JobCategoryName = jcName
                });
            }

            return viewModels;
        }
    }
}
