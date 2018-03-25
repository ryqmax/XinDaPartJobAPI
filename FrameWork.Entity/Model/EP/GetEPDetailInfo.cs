/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPDetailInfo.cs
 *      Description:
 *            GetEPDetailInfo
 *      Author:
 *                a-fei
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 19:40:29
 *      History:
 ***********************************************************************************/


using FrameWork.Common.Enum;

namespace FrameWork.Entity.Model.EP
{
    /// <summary>
    /// GetEPDetailInfo
    /// </summary>
    public class GetEPDetailInfo
    {
        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyId { set; get; }

        /// <summary>
        /// 公司等级Id
        /// </summary>
        public JobEmployerLevelEnum CompanyEmployerId { set; get; }

        /// <summary>
        /// 公司等级名称：四级雇主
        /// </summary>
        public string CompanyEmployerName {
            get
            {
                var result = string.Empty;
                result = EnumHelper.GetDescription(CompanyEmployerId);
                return result;
            }
        }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { set; get; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { set; get; }

        /// <summary>
        /// 公司全称
        /// </summary>
        public string CompanyFullName { set; get; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyDesc { set; get; }
    }
}
