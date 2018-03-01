/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                HtmlHelperExtend.cs
 *      Description:
 *            HtmlHelperExtend
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/5 8:52:19
 *      History:
 ***********************************************************************************/

using System.Web.Mvc;
using FrameWork.Common.ReadSql;

namespace FrameWork.Web.Html
{
    /// <summary>
    /// HtmlHelperExtend
    /// </summary>
    public static class HtmlHelperExtend
    {
        /// <summary>
        /// 给CSS文件或JS文件指定版本号
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="url">CSS或JS路径</param>
        /// <returns></returns>
        public static string GetCssJsUrl(this HtmlHelper helper, string url)
        {
            string version = CachedConfigContext.Current.DaoConfig.JsVersion;
            version = version == null ? "1.0" : version;
            return url += "?v=" + version;
        }

    }
}
