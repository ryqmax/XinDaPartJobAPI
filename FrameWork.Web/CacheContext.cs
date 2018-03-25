/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                CacheContext.cs
 *      Description:
 *            CacheContext
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 20:10:36
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.DotNETCache;
using FrameWork.Entity.Entity;
using FrameWork.ServiceImp;

namespace FrameWork.Web
{
    /// <summary>
    /// CacheContext
    /// </summary>
    public class CacheContext
    {
        /// <summary>
        /// 所有的城市地区列表
        /// </summary>
        public static List<DicRegion> DicRegions
        {
            get { return CacheHelper.Get(CommonData.RegionRedisCache, () => new DicRegionService().GetAlList()); }
        }

        /// <summary>
        /// 字典存储
        /// </summary>
        public static Dictionary<string, DicRegion> TeacherDicForManagement
        {
            get
            {
                return DicRegions.ToDictionary(d=>d.Id);
            }
        }
    }
}
