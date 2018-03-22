/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                VIPInfoService.cs
 *      Description:
 *            VIPInfoService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 19:25:20
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// VIPInfoService
    /// </summary>
    public class VIPInfoService:BaseService<T_VIPInfo>,IVIPInfoService
    {
        /// <summary>
        /// 获取所有的会员信息
        /// </summary>
        public List<T_VIPInfo> GetVipInfoList()
        {
            var sql = @"SELECT * FROM dbo.T_VIPInfo WHERE IsDel = 0 ORDER BY Seq ";
            return DbPartJob.Fetch<T_VIPInfo>(sql);
        }
    }
}
