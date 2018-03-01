using System;
using System.Collections.Generic;
using FrameWork.Entity;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class NewsService : BaseService<T_News>,INewsService
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        public List<NewsModelForList> GetNewsList(int industryId, int currentPage, int pageSize)
        {
            int start = (currentPage - 1) * pageSize + 1;
            int end = currentPage * pageSize;

            string sql = @"
                        
SELECT 
	a.id AS ArticleId,
	a.[Image] AS ArticleImg,
	a.Title AS ArticleTitle,
	a.Summary AS ArticleDesc, --描述
	a.CreateTime AS ArticleCreateTime,
	a.ViewCount AS ArticleBrowsingVolume,
	a.CollectCount AS ArticleCollectionNum,
    -- 总数量
	(SELECT COUNT(id) FROM dbo.T_News b WHERE b.IsDel = 0 AND b.IsUsed = 1 AND b.IndustryId = @industryId) AS TotalCount
FROM
	(
	SELECT
		ROW_NUMBER() OVER (ORDER BY n.CreateTime DESC)rn,
		n.*
	FROM
		dbo.T_News n
	WHERE
		n.IsDel = 0 AND n.IsUsed = 1 		       
		-- AND n.industryId = 1                
		AND n.industryid = @industryId		
	)a
WHERE
	rn BETWEEN @p AND @ps";
            return DbQuestionBank.Fetch<NewsModelForList>(sql, new { p = start, ps = end, industryId });
        }

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public NewsDetailsModel GetArticleDetail(int articleId, int userId)
        {
            string sql = @"
SELECT 
		a.[Id]
      ,[IndustryId]
      ,[Title]
      ,[Image]
      ,[Content]
      ,[Summary]
      ,[ViewCount]
      ,[UpvoteCount]
      ,[CollectCount]
      ,[ShareCount]
      ,[IsUsed]
      ,[IsDel]
      ,[ModifyUserId]
      ,[ModifyTime]
      ,[CreateUserId]
      ,[CreateTime],
	  (SELECT ISNULL((SELECT TOP(1) 1 FROM dbo.T_UserCollectNews WHERE NewsId = @newsId AND UserId = @userId AND IsDel = 0),0)) AS IsCollect,
	  (SELECT ISNULL((SELECT TOP(1) 1 FROM dbo.T_UserGoodNews WHERE NewsId = @newsId AND UserId = @userId AND IsDel = 0),0))  AS IsUpvote
FROM dbo.T_News a
WHERE a.Id = @newsId
UPDATE dbo.T_News SET ViewCount = ViewCount + 1 WHERE Id = @newsId
";
            return DbQuestionBank.Single<NewsDetailsModel>(sql, new { newsId = articleId, userId = userId });
        }

        /// <summary>
        /// 收藏文章
        /// </summary>
        public int CollectNews(int articleId, int userId, bool up)
        {
            // 如果是收藏
            if (up)
            {
                string sql = @"
 IF  NOT EXISTS(SELECT id FROM dbo.T_UserCollectNews WHERE UserId = @userId AND NewsId = @newsId AND IsDel = 0)
BEGIN
	INSERT INTO dbo.T_UserCollectNews
	        ( UserId ,
	          NewsId ,
	          IsDel ,
	          ModifyUserId ,
	          ModifyTime ,
	          CreateUserId ,
	          CreateTime
	        )
	VALUES  ( @userId , -- UserId - int
	          @newsId , -- NewsId - int
	          0 , -- IsDel - bit
	          0 , -- ModifyUserId - int
	          GETDATE() , -- ModifyTime - datetime
	          0 , -- CreateUserId - int
	          GETDATE()  -- CreateTime - datetime
	        )
	UPDATE dbo.T_News SET CollectCount = CollectCount + 1 WHERE ID = @newsId
END
";
                return DbQuestionBank.Execute(sql, new { newsId = articleId, userId = userId });
            }
            else
            {
                // 取消收藏
                string sql = @"
IF EXISTS(SELECT id FROM T_UserCollectNews WHERE UserId = @userId AND NewsId = @newsId AND IsDel = 0)
BEGIN
	UPDATE dbo.T_UserCollectNews SET IsDel = 1 WHERE UserId = @userId AND NewsId = @newsId
    UPDATE dbo.T_News SET CollectCount = CollectCount -1 WHERE Id = @newsId
END
";
                return DbQuestionBank.Execute(sql, new { newsId = articleId, userId = userId });
            }
        }

        /// <summary>
        /// 点赞文章
        /// </summary>
        public int UpvoteNews(int articleId, int userId, bool up)
        {
            // 如果是点赞
            if (up)
            {
                string sql = @"
 IF  NOT EXISTS(SELECT id FROM dbo.T_UserGoodNews WHERE UserId = @userId AND NewsId = @newsId AND IsDel = 0)
BEGIN
	INSERT INTO dbo.T_UserGoodNews
	        ( UserId ,
	          NewsId ,
	          IsDel ,
	          ModifyUserId ,
	          ModifyTime ,
	          CreateUserId ,
	          CreateTime
	        )
	VALUES  ( @userId , -- UserId - int
	          @newsId , -- NewsId - int
	          0 , -- IsDel - bit
	          0 , -- ModifyUserId - int
	          GETDATE() , -- ModifyTime - datetime
	          0 , -- CreateUserId - int
	          GETDATE()  -- CreateTime - datetime
	        )
	UPDATE dbo.T_News SET UpvoteCount = CollectCount + 1 WHERE Id = @newsId
END
";
                return DbQuestionBank.Execute(sql, new {newsId = articleId, userId = userId});
            }
            else
            {
                // 取消点赞
                string sql = @"
IF EXISTS(SELECT id FROM T_UserGoodNews WHERE UserId = @userId AND NewsId = @newsId AND IsDel = 0)
BEGIN
	UPDATE dbo.T_UserGoodNews SET IsDel = 1 WHERE UserId = @userId AND NewsId = @newsId
    UPDATE dbo.T_News SET UpvoteCount = UpvoteCount -1 WHERE Id = @newsId
END

";
                return DbQuestionBank.Execute(sql, new { newsId = articleId, userId = userId });
            }
        }


        /// <summary>
        /// 分享文章
        /// </summary>
        public int ShareNews(int articleId)
        {
            string sql = @" UPDATE dbo.T_News SET ShareCount = ShareCount + 1 WHERE id = @newsId ";
            return DbQuestionBank.Execute(sql, new {newsId = articleId});
        }
    }
}
