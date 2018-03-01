/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UserShowModel.cs
 *      Description:
 *            UserShowModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 16:09:45
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;

namespace FrameWork.Entity
{
    /// <summary>
    /// 新闻内容，用于列表展示
    /// </summary>
    public class NewsListViewModel
    {
        public NewsListViewModel()
        {
            List = new List<NewsListInResult>();
        }
        public bool IsEnd { get; set; }
        public List<NewsListInResult> List { get; set; }
    }

    public class NewsListInResult
    {
        public int ArticleId { get; set; }


        public string ArticleImg { get; set; }

        public string ArticleTitle { get; set; }
        public string ArticleDesc { get; set; }

        public string ArticleCreateTime { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int ArticleBrowsingVolume { get; set; }

        /// <summary>
        /// 收藏量
        /// </summary>
        public int ArticleCollectionNum { get; set; }

        public int ArticleShareNum { get; set; }
    }
}
