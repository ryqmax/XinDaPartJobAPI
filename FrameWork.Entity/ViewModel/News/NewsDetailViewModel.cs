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
using FrameWork.Entity.Entity;

namespace FrameWork.Entity
{
    /// <summary>
    /// 新闻内容，用于列表展示
    /// </summary>
    public class NewsDetailViewModel
    {
        public NewsDetailViewModel(NewsDetailsModel newsFromDb)
        {
            this.ArticleImg = newsFromDb.Image;
            this.ArticleTitle = newsFromDb.Title;
            this.ArticleDesc = newsFromDb.Content;
            this.ArticleCreateTime = newsFromDb.CreateTime.ToString("yyyy-MM-dd");

            this.ArticleBrowsingVolume = newsFromDb.ViewCount;
            this.ArticleCollectionNum = newsFromDb.CollectCount;
            this.ArticleShareNum = newsFromDb.ShareCount;
            this.UpvoteNum = newsFromDb.UpvoteCount;

            this.IsCollect = newsFromDb.IsCollect;
            this.IsUpvote = newsFromDb.IsUpvote;
        }

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

        /// <summary>
        /// 点赞量
        /// </summary>
        public int UpvoteNum { get; set; }

        /// <summary>
        /// 是否已经点赞
        /// </summary>
        public bool IsUpvote { get; set; }

        /// <summary>
        /// 是否已经收藏
        /// </summary>
        public bool IsCollect { get; set; }
    }
}
