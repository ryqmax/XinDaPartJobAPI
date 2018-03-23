/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetPartJobModel.cs
 *      Description:
 *            GetPartJobModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/23 10:22:55
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.Model.Job
{
    /// <summary>
    /// GetPartJobModel
    /// </summary>
    public class GetPartJobModel
    {
        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { set; get; }

        /// <summary>
        /// 岗位名字
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// 工资下限
        /// </summary>
        public int SalaryLower { set; get; }

        /// <summary>
        /// 工资上限
        /// </summary>
        public int SalaryUpper { set; get; }

        /// <summary>
        /// 工作岗位类别名称
        /// </summary>
        public string JobCategoryName { set; get; }

        /// <summary>
        /// 结算单位
        /// </summary>
        public string PayUnit { set; get; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string PayWay { set; get; }

        /// <summary>
        /// 申请数量
        /// </summary>
        public int ApplyCount { set; get; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewCount { set; get; }

        /// <summary>
        /// 企业logo
        /// </summary>
        public string EPLogo { set; get; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EPName { set; get; }

        /// <summary>
        /// 企业id
        /// </summary>
        public int EnterpriseId { set; get; }

        /// <summary>
        /// 等级信息：0.未认证，1.普通，2.一级雇主，3.二级，4.三级，5.四级，6.五级
        /// </summary>
        public byte EPLevel { set; get; }

        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkTime { set; get; }

        /// <summary>
        /// 任职要求
        /// </summary>
        public string OfficeRequire { set; get; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent { set; get; }

        /// <summary>
        /// 招聘联系人姓名
        /// </summary>
        public string EPHiringManagerName { set; get; }

        /// <summary>
        /// 招聘联系人头像
        /// </summary>
        public string EPHiringHeadImg { set; get; }

        /// <summary>
        /// 招聘联系人电话
        /// </summary>
        public string EPHiringPhone { set; get; }

        /// <summary>
        /// 可以投递的简历数量
        /// </summary>
        public int CVCount { set; get; }
    }
}
