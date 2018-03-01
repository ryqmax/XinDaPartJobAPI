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

namespace FrameWork.Entity
{
    /// <summary>
    /// 新闻内容，用于列表展示
    /// </summary>
    public class NewsModelForList
    {
        public int ArticleId { get; set; }


        public string ArticleImg { get; set; }

        public string ArticleTitle { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string ArticleDesc { get; set; }

        public DateTime ArticleCreateTime { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int ArticleBrowsingVolume { get; set; }

        /// <summary>
        /// 收藏量
        /// </summary>
        public int ArticleCollectionNum { get; set; }

        public int ArticleShareNum { get; set; }

        public int TotalCount { get; set; }
    }
}
