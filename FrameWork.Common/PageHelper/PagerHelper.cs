using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Routing;
using App.Common.PageHelper;

namespace Common.PageHelper
{
    public static class PagerHelper
    {
        //默认页面显示10行
        public static int DEFAULT_PAGE_SIZE = 6;
        //默认显示第一页
        public static int DEFAULT_SHOW_PAGE = 1;
        
        /// <summary>
        /// 返回分页的起始行,从第0行开始
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static int BeginIndex(PagerInfo pagerInfo)
        {
            int beginIndex = 0;
            //如果页码小于等于1，则默认企业行为第0行
            if (pagerInfo.CurrentPageIndex <= 1)
            {
                beginIndex = 0;
            }
            else
            {
                //如果页面大小小于等于0， 则默认取缺省页面大小
                if(pagerInfo.PageSize <= 0)
                {
                    pagerInfo.PageSize = DEFAULT_PAGE_SIZE;
                }
                beginIndex = (pagerInfo.CurrentPageIndex - 1) * pagerInfo.PageSize;
            }

            return beginIndex;
        }

        /// <summary>
        /// 返回分页的终止行
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static int EndIndex(PagerInfo pagerInfo)
        {
            int endIndex = 0;
            //如果页码小于等于0，则默认企业行为第0行
            if (pagerInfo.CurrentPageIndex <= 0)
            {
                endIndex = 0;
            }
            else if(pagerInfo.RecordCount <= 0)
            {
                endIndex = 0;
            }
            else
            {
                //如果页面大小小于等于0， 则默认取缺省页面大小
                if (pagerInfo.PageSize <= 0)
                {
                    pagerInfo.PageSize = DEFAULT_PAGE_SIZE;
                }
                endIndex = (pagerInfo.CurrentPageIndex) * pagerInfo.PageSize - 1;
                //如果终止行大于数据总行数，则返回总行数
                if(endIndex + 1 > pagerInfo.RecordCount)
                {
                    endIndex = pagerInfo.RecordCount - 1;
                }
            }

            return endIndex;
        }

        /// <summary>
        /// 当最后一页行数不足页码大小时，取数据库数据仍然取页面大小个，dapper会自动计算返回需要值
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static int RecordNum(PagerInfo pagerInfo)
        {
            int recordNum = DEFAULT_PAGE_SIZE;

            return recordNum;
        }

        
        /// <summary>
        /// 获取普通分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static string GetNormalPage(int currentPageIndex, int pageSize, int recordCount,PageMode mode)
        {
            int pageCount = (recordCount%pageSize ==0?recordCount/pageSize:recordCount/pageSize+1);
            StringBuilder url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath+"?page={0}");
            NameValueCollection collection = HttpContext.Current.Request.QueryString;
            string[] keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToLower() != "page")
                    url.AppendFormat("&{0}={1}", keys[i], collection[keys[i]]);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><td>");
            sb.AppendFormat("总共{0}条记录,共{1}页,当前第{2}页&nbsp;&nbsp;", recordCount, pageCount, currentPageIndex);
            if (currentPageIndex == 1)
                sb.Append("<span>首页</span>&nbsp;");
            else
            {
                string url1 = string.Format(url.ToString(), 1);
                sb.AppendFormat("<span><a href={0}>首页</a></span>&nbsp;", url1);
            }
            if (currentPageIndex > 1)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex - 1);
                sb.AppendFormat("<span><a href={0}>上一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span>上一页</span>&nbsp;");
            if(mode == PageMode.Numeric)
                sb.Append(GetNumericPage(currentPageIndex,pageSize,recordCount,pageCount,url.ToString()));
            if (currentPageIndex < pageCount)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex+1);
                sb.AppendFormat("<span><a href={0}>下一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span>下一页</span>&nbsp;");

            if (currentPageIndex == pageCount)
                sb.Append("<span>末页</span>&nbsp;");
            else
            {
                string url1 = string.Format(url.ToString(), pageCount);
                sb.AppendFormat("<span><a href={0}>末页</a></span>&nbsp;", url1);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取数字分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetNumericPage(int currentPageIndex, int pageSize, int recordCount, int pageCount,string url)
        {
            int k = currentPageIndex / 10;
            int m = currentPageIndex % 10;
            StringBuilder sb = new StringBuilder();
            if (currentPageIndex / 10 == pageCount / 10)
            {
                if (m == 0)
                {
                    k--;
                    m = 10;
                }
                else
                    m = pageCount%10;
            }
            else
                m = 10;
            for (int i = k * 10 + 1; i <= k * 10 + m; i++)
            {
                if (i == currentPageIndex)
                    sb.AppendFormat("<span><font color=red><b>{0}</b></font></span>&nbsp;", i);
                else
                {
                    string url1 = string.Format(url.ToString(), i);
                    sb.AppendFormat("<span><a href={0}>{1}</a></span>&nbsp;",url1, i);
                }
            }
            
            return sb.ToString();
        }
    }


    /// <summary>
    /// 分页模式
    /// </summary>
    public enum PageMode
    {
        /// <summary>
        /// 普通分页模式
        /// </summary>
        Normal,
        /// <summary>
        /// 普通分页加数字分页
        /// </summary>
        Numeric
    }
}
