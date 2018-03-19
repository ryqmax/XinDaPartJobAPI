/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                DicRegionService.cs
 *      Description:
 *            DicRegionService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 20:01:52
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
    /// DicRegionService
    /// </summary>
    public class DicRegionService : BaseService<DicRegion>,IDicRegionService
    {
        /// <summary>
        /// 获取所有的地区列表
        /// </summary>
        public List<DicRegion> GetAlList()
        {
            var sql = @"where 1 = 1";
            return DbPartJob.Fetch<DicRegion>(sql);
        }
    }
}
