/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                T_ReportReason.cs
 *      Description:
 *            T_ReportReason
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/24 21:17:39
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    /// <summary>
    /// T_ReportReason
    /// </summary>
    [TableName("T_ReportReason")]
    [PrimaryKey("Id")]
    public class T_ReportReason
    {
        /// <summary>
        /// - 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 举报原因所属类型：1.简历，2.岗位
        /// </summary>
        public byte Type { set; get; }

        /// <summary>
        /// 举报原因
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 是否删除 
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 编辑人id 
        /// </summary>
        public int ModifyUserId { get; set; }

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
