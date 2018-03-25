/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                DistanceHelper.cs
 *      Description:
 *            DistanceHelper
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/25 15:34:03
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Common
{
    /// <summary>
    /// DistanceHelper
    /// </summary>
    public class DistanceHelper
    {
        /// <summary>
        /// 地球半径
        /// </summary>
        private const double EARTH_RADIUS = 6378137;

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static string GetDistance(decimal lat1, decimal lng1, decimal lat2, decimal lng2)
        {
            var radLat1 = Rad(lat1);
            var radLng1 = Rad(lng1);
            var radLat2 = Rad(lat2);
            var radLng2 = Rad(lng2);
            var a = radLat1 - radLat2;
            var b = radLng1 - radLng2;
            var result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            string distance;
            if (result > 100)
            {
                distance = $"{Math.Ceiling(result * 10 / 1000)}km";
            }
            else
            {
                distance = $"{(int)result}m";
            }
            return distance;
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        private static double Rad(decimal d)
        {
            return (double)d * Math.PI / 180d;
        }
    }
}
