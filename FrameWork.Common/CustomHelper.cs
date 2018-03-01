/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *				CustomHelper.cs
 *      Description:
 *		    自定义工具类
 *      Author:
 *				yangxianwen
 *							
 *      Finish DateTime:
 *				2016年12月08日
 *      History:
 ***********************************************************************************/

using System;
using System.Configuration;

namespace FrameWork.Common
{
    /// <summary>
    /// 处理字符串的值为null的情况下的返回值
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 对传递进来的字符串进行处理
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回空字符串或者非空的值</returns>
        public static string NullOrEmpty(string str)
        {
            //如果字符串为null
            if (string.IsNullOrEmpty(str))
                str = "";
            return str;
        }
    }

    /// <summary>
    /// 常用方法类
    /// </summary>
    public class TollsHelper
    {
        /// <summary>
        /// 判断是否还有下一页
        /// </summary>
        /// <param name="totalNum">总页数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页的条数</param>
        /// <returns>true表示还有下一页</returns>
        public static bool JudgeNextPage(int totalNum, int currentPage, int pageSize)
        {
            int pagenum = 0;
            if (pageSize > 0)
            {
                pagenum = totalNum / pageSize;
                if (totalNum % pageSize > 0)
                    pagenum += 1;
            }
            if (pagenum > currentPage)
                return true;
            return false;
        }
        
    }

    /// <summary>
    /// 数学方法类
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// 计算两个值相除以后的值
        /// </summary>
        /// <param name="divisor">除数</param>
        /// <param name="divide">被除数</param>
        /// <returns>相除以后的结果，保留整数</returns>
        public static int DevideZero(int divisor,int divide)
        {
            var result = 0;
            if (divisor > 0)
                result = divide/divisor;
            return result;
        }
    }

    public class DomainHelper
    {
        private static string head = "http://";
        /// <summary>
        /// 拼接域名地址方法
        /// </summary>
        public static string ConcatDomain(string srcDomain)
        {
            string result;
            if (srcDomain.ToLower().StartsWith("http://"))
            {
                result = srcDomain;
            }
            else
            {
                result= $"{head}{srcDomain}";
            }
            return result;
        }
    }

    /// <summary>
    /// 时间转化为字符串
    /// </summary>
    public class DateTimeHelper
    {
        public static string GetDateTime(DateTime? dateTime)
        {
            var dStr = string.Empty;
            if (dateTime.HasValue)
            {
                dStr = dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return dStr;
        }
    }
}
