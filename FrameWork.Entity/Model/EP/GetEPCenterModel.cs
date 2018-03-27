/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPCenterModel.cs
 *      Description:
 *            GetEPCenterModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/27 20:56:22
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.Model.EP
{
    /// <summary>
    /// GetEPCenterModel
    /// </summary>
    public class GetEPCenterModel
    {
        /// <summary>
        /// 企业名字
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 等级信息：1.未认证，2.普通，3.一级雇主，4.二级，5.三级，6.四级，7.五级
        /// </summary>
        public byte Level { set; get; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { set; get; }

        /// <summary>
        /// 总积分
        /// </summary>
        public int TotalIntegral { set; get; }
        
        /// <summary>
        /// 发布的岗位数量
        /// </summary>
        public int JobCount { set; get; }

        /// <summary>
        /// 智能匹配岗位数量
        /// </summary>
        public int AutoJobCount { set; get; }

        /// <summary>
        /// 账号类型，1：主账号，2.子账号
        /// </summary>
        public byte AccountType { set; get; }

        /// <summary>
        /// 投递简历数量
        /// </summary>
        public int CVCount { set; get; }

        /// <summary>
        /// 购买简历数量
        /// </summary>
        public int BuyCVCount { set; get; }

        /// <summary>
        /// 招聘联系人认证的数量
        /// </summary>
        public int AuthCount { set; get; }

        /// <summary>
        /// 招聘联系人总数量
        /// </summary>
        public int HTotalCount { set; get; }

        /// <summary>
        /// 子账号最大数量
        /// </summary>
        public int AccountMax { set; get; }

        /// <summary>
        /// 现在开通的子账号数量
        /// </summary>
        public int AccountCount { set; get; }

        /// <summary>
        /// VipName
        /// </summary>
        public string VipName { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? VipPassDate { set; get; }
    }
}
