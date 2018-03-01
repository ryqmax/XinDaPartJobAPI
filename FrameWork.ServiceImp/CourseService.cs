using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Course;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Course;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class CourseService : BaseService<T_Course>, ICourseService
    {
        /// <summary>
        /// 获取首页免费视频列表
        /// </summary>
        /// <returns></returns>
        public List<FreeVideoModel> GetFreeVidioList(int industryId, int currentPage, int pageSize)
        {
            // return new List<FreeVideoViewModel>();
            int start = (currentPage - 1) * pageSize + 1;
            int end = currentPage * pageSize;

            string sql = @"
                        SELECT 
	                        *, 
                            -- 总数量
	                        (
	                        SELECT
		                        COUNT(*)
	                        FROM
		                        T_SectionVideo sv
		                        LEFT JOIN dbo.T_Section s ON sv.SectionId = s.Id
		                        LEFT JOIN dbo.T_Chapter c ON s.ChapterId = c.Id
		                        LEFT JOIN dbo.T_Course course ON course.Id = c.CourseId
		                        LEFT JOIN dbo.T_Category ca ON course.CategoryId = ca.Id
		                        LEFT JOIN dbo.T_Industry i ON ca.IndustryId = i.Id
	                        WHERE
		                        sv.IsDel = 0 AND sv.IsUsed = 1 
		                        AND  s.IsDel = 0 AND s.IsUsed = 1 
		                        AND  c.IsDel = 0 AND c.IsUsed = 1 
		                        AND  course.IsDel = 0 AND course.IsUsed = 1 
		                        AND  ca.IsDel = 0 AND ca.IsUsed = 1 
		                        AND  i.IsDel = 0 AND i.IsUsed = 1 
                                AND  SV.IsFree = 1
		                        AND i.Id = @industryId				
	                        ) AS TotalCount
                        FROM
	                        (
	                        SELECT
		                        ROW_NUMBER() OVER (ORDER BY sv.CreateTime)rn,
                                s.Description AS SectionDesc,
		                        sv.Id AS VideoId,
		                        sv.VideoImgPath AS VideoImg,
                                c.Sequence AS ChapterSequence, --章序号
                                s.Sequence AS SectionSequence, ---接续好
		                        tv.HighPath AS VideoUrl,
		                        sv.CreateTime,
		                        sv.BrowseCount, 
		                        sv.SectionId AS SectionId,
		                        s.Name AS SectionName,
                                c.Name AS ChapterName,
                                course.Id AS CourseId,
		                        course.Name AS CourseName,
		                        ca.Name AS CategoryName
	                        FROM
		                        T_SectionVideo sv
		                        LEFT JOIN dbo.T_Section s ON sv.SectionId = s.Id
		                        LEFT JOIN dbo.T_Chapter c ON s.ChapterId = c.Id
		                        LEFT JOIN dbo.T_Course course ON course.Id = c.CourseId
		                        LEFT JOIN dbo.T_Category ca ON course.CategoryId = ca.Id
		                        LEFT JOIN dbo.T_Industry i ON ca.IndustryId = i.Id
                                LEFT JOIN dbo.T_VideoLibrary tv ON sv.VideoLibraryId = tv.Id
	                        WHERE
		                        sv.IsDel = 0 AND sv.IsUsed = 1 
		                        AND  s.IsDel = 0 AND s.IsUsed = 1 
		                        AND  c.IsDel = 0 AND c.IsUsed = 1 
		                        AND  course.IsDel = 0 AND course.IsUsed = 1 
		                        AND  ca.IsDel = 0 AND ca.IsUsed = 1 
		                        AND  i.IsDel = 0 AND i.IsUsed = 1 
                                AND  tv.IsDel = 0 AND tv.IsUsed = 1 
                                AND  SV.IsFree = 1
		                        AND i.Id = @industryId		
	                        )a
                        WHERE
	                        1=1
	                        AND rn BETWEEN @p AND @ps";
            return DbQuestionBank.Fetch<FreeVideoModel>(sql, new { p = start, ps = end, industryId });
        }

        /// <summary>
        /// 获取轮播图
        /// </summary>
        public List<T_Banner> GetBannerList()
        {
            var sql = @"
            SELECT 
	               TOP 3 Id ,
                   ImgPath ,
                   ActionUrl ,
                   Sequence ,
                   IsUsed ,
                   IsDel ,
                   ModifyUserId ,
                   ModifyTime ,
                   CreateTime ,
                   CreateUserId
            FROM dbo.T_Banner WHERE IsDel = 0 AND IsUsed = 1 ORDER BY Sequence DESC";
            return DbQuestionBank.Fetch<T_Banner>(sql);
        }

        /// <summary>
        /// 获取该行业下的付费课程
        /// </summary>
        /// <param name="industryId">行业id</param>
        public List<CourseModel> GetCourseModelList(int industryId)
        {
            var sql = @";
                SELECT
                    a.CategoryId ,
                    a.CategoryName ,
                    a.CourseId ,
                    a.CourseName,
                    a.Image
                FROM
	                (
		                SELECT
			                ROW_NUMBER() OVER(PARTITION BY tco.CategoryId ORDER BY tco.CreateTime)rn,
			                tco.CategoryId,
			                tc.Name AS CategoryName,	
			                tco.Id AS CourseId,
			                tco.Name AS CourseName,tco.Image
		                FROM
			                dbo.T_Category tc
			                LEFT JOIN dbo.T_Course tco ON tc.Id = tco.CategoryId
		                WHERE
			                tc.IndustryId = @industryId
			                AND tc.IsDel = 0 AND tc.IsUsed = 1
			                AND tco.IsDel = 0 AND tco.IsUsed = 1
	                )a
                WHERE
	                a.rn < 21";
            return DbQuestionBank.Fetch<CourseModel>(sql, new { industryId });

        }

        /// <summary>
        /// 获取付费课程下的新闻列表
        /// </summary>
        /// <param name="industryId">行业id</param>
        public List<CourseNewsModel> GetNewsModels(int industryId)
        {
            var sql = @";
                    SELECT
	                    TOP 5
	                    Id AS NewsId,
	                    Title 
                    FROM
	                    dbo.T_News
                    WHERE
	                    IndustryId = @industryId
	                    AND IsDel = 0 AND IsUsed = 1
                    ORDER BY Id DESC";
            return DbQuestionBank.Fetch<CourseNewsModel>(sql, new { industryId });
        }

        /// <summary>
        /// 获取该行业下的付费小节视频列表
        /// </summary>
        /// <param name="industryId">行业id</param>
        /// <param name="userId">用户id</param>
        public List<CourseVideoModel> GetCourseVideoModelList(int industryId,int userId)
        {
            var sql = @";
SELECT
	TOP 5
	sv.Id AS SectionVideoId,
	sv.VideoImgPath,
	tv.HighPath,tc.CourseId,
	sv.ModifyTime,
	sv.BrowseCount,
	tca.Name AS CategoryName,
	tco.Name AS CourseName,
	tc.Name AS ChapterName,
	s.Name AS SectionName,
	sv.SectionId,
    s.[Description] AS SectionDesc,tc.Sequence AS ChapterSequence,s.Sequence AS SectionSequence,
    (SELECT COUNT(1) FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.SectionVideoId = sv.Id AND bv.UserId = @userId )UserBuyCount	
FROM
	dbo.T_SectionVideo sv
	LEFT JOIN dbo.T_Section s ON sv.SectionId = s.Id
	LEFT JOIN dbo.T_Chapter tc ON s.ChapterId = tc.Id
	LEFT JOIN dbo.T_Course tco ON tc.CourseId = tco.Id
	LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
	LEFT JOIN dbo.T_VideoLibrary tv ON sv.VideoLibraryId = tv.Id
WHERE
	sv.IsDel = 0 AND sv.IsUsed = 1 AND sv.IsFree = 0
	AND s.IsDel = 0 AND s.IsUsed = 1
	AND tc.IsDel = 0 AND tc.IsUsed = 1
	AND tco.IsDel = 0 AND tco.IsUsed = 1
	AND tca.IsDel = 0 AND tca.IsUsed = 1
	AND tv.IsDel = 0 AND tv.IsUsed = 1
	AND tca.IndustryId = @industryId
ORDER BY sv.BrowseCount DESC";
            return DbQuestionBank.Fetch<CourseVideoModel>(sql, new { industryId , userId });
        }

        /// <summary>
        /// 获取视频详情
        /// </summary>
        /// <param name="sectionVideoId">小节视频id</param>
        /// <param name="userId">用户id</param>
        public CourseDetailModel GetCourseDetailModel(int sectionVideoId, int userId)
        {
            var sql = @";
                SELECT
	                sv.Id AS SectionVideoId,
	                sv.VideoImgPath,
	                tv.HighPath,
	                sv.ModifyTime,
	                sv.BrowseCount,
	                tca.Name AS CategoryName,
	                tco.Name AS CourseName,
	                tc.Name AS ChapterName,
	                s.Name AS SectionName,
	                sv.SectionId,
	                sv.Lecture,sv.Price,
	                sv.TeacherId,tc.CourseId,tc.Sequence AS ChapterSequence,s.Sequence AS SectionSequence,
	                (SELECT u.RealName FROM dbo.T_User u WHERE u.Id = sv.TeacherId)TeacherName,
	                (SELECT u.Title FROM dbo.T_User u WHERE u.Id = sv.TeacherId)TeacherTitle,
                    (SELECT u.ImgPath FROM dbo.T_User u WHERE u.Id = sv.TeacherId)TeacherImgPath,
	                s.[Description] AS SectionDesc,
	                sv.PraiseCount,
                    (SELECT COUNT(1) FROM dbo.T_UserPraiseVideo pv WHERE pv.UserId = 1 AND pv.SectionVideoId = sv.Id AND pv.IsDel = 0)UserPraiseCount,
	                (SELECT COUNT(1) FROM dbo.T_UserCollectionVideo uv WHERE uv.SectionVideoId = sv.Id AND uv.IsDel = 0 )CollectCount,
                    (SELECT COUNT(1) FROM dbo.T_UserCollectionVideo uv WHERE uv.SectionVideoId = sv.Id AND uv.IsDel = 0 AND uv.UserId = @userId)UserCollectCount,
					sv.IsFree,
					(SELECT COUNT(1) FROM dbo.T_UserBuyVideo ub WHERE ub.UserId = @userId AND ub.IsDel = 0 AND ub.SectionVideoId = sv.Id)UserBuyCount,
					(SELECT COUNT(1) FROM dbo.T_UserBuyVideo ub WHERE ub.IsDel = 0 AND ub.SectionVideoId = sv.Id AND ub.IsDel = 0)BuyCount,
                    (SELECT COUNT(1) FROM T_UserViewVideo vv WHERE vv.IsDel = 0 AND vv.SectionVideoId = sv.Id AND vv.[Status] = 0)WatchingCount
                FROM
	                dbo.T_SectionVideo sv
	                LEFT JOIN dbo.T_Section s ON sv.SectionId = s.Id
	                LEFT JOIN dbo.T_Chapter tc ON s.ChapterId = tc.Id
	                LEFT JOIN dbo.T_Course tco ON tc.CourseId = tco.Id
	                LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
	                LEFT JOIN dbo.T_VideoLibrary tv ON sv.VideoLibraryId = tv.Id
                WHERE
	                sv.IsDel = 0 AND sv.IsUsed = 1 
	                AND s.IsDel = 0 AND s.IsUsed = 1
	                AND tc.IsDel = 0 AND tc.IsUsed = 1
	                AND tco.IsDel = 0 AND tco.IsUsed = 1
	                AND tca.IsDel = 0 AND tca.IsUsed = 1
	                AND tv.IsDel = 0 AND tv.IsUsed = 1
	                AND sv.Id = @sectionVideoId ";
            var model = DbQuestionBank.FirstOrDefault<CourseDetailModel>(sql, new { sectionVideoId, userId });
            //更新在线记录表
            var updateSql = @"
UPDATE 
	dbo.T_UserOnlineRecord
SET 
	Type = 1,
    KeyId = @sectionVideoId,
	CategoryId = (SELECT TOP 1 tc.CategoryId FROM dbo.T_Course tc WHERE tc.Id = @CourseId),
	IndustryId = (SELECT TOP 1 tca.IndustryId FROM dbo.T_Category tca LEFT JOIN dbo.T_Course tco ON tca.Id = tco.CategoryId WHERE tco.Id = @CourseId AND tco.IsDel = 0 AND tca.IsDel = 0)
WHERE 
	UserId = @userId AND T_UserOnlineRecord.IsDel = 0";
            DbQuestionBank.Execute(updateSql, new {sectionVideoId, userId, model.CourseId});

            return model;
        }

        /// <summary>
        /// 获取该小节视频的相关小节视频
        /// </summary>
        /// <param name="sectionVideoId">小节视频id</param>
        public List<RelateVideoModel> GetRelateVideoModelList(int sectionVideoId)
        {
            var sql = @";
SELECT
	sv.Id AS SectionVideoId,
	sv.Name AS SectionVideoName,
    sv.VideoImgPath
FROM
	dbo.T_RelatedSectionVideo r
	LEFT JOIN dbo.T_SectionVideo sv ON r.RelatedSectionVideoId = sv.Id
WHERE
	r.IsDel = 0 AND r.IsUsed = 1
	AND sv.IsDel = 0 AND sv.IsUsed = 1
	AND r.SectionVideoId = @sectionVideoId";
            return DbQuestionBank.Fetch<RelateVideoModel>(sql, new { sectionVideoId });
        }

        /// <summary>
        /// 点赞或取消点赞
        /// </summary>
        public int SubmitVideoUpvote(SubmitVideoUpvoteRequest request)
        {
            var sql = @";
            UPDATE dbo.T_SectionVideo SET PraiseCount = PraiseCount - 1 WHERE Id = @SectionVideoId
            UPDATE dbo.T_UserPraiseVideo SET IsDel = 1 WHERE UserId = @UserId AND IsDel = 1 AND SectionVideoId = @SectionVideoId";
            if (request.Type == 1)
            {
                sql = @";
IF NOT EXISTS (SELECT * FROM dbo.T_UserPraiseVideo WHERE UserId = @UserId AND SectionVideoId = @SectionVideoId AND IsDel = 0)
	BEGIN
		INSERT
        INTO
        dbo.T_UserPraiseVideo
                ( UserId ,
                    SectionVideoId ,
                    IsUsed ,
                    IsDel ,
                    CreateTime
                )
        VALUES  ( @UserId , -- UserId - int
                    @SectionVideoId  , -- SectionVideoId - int
                    1 , -- IsUsed - bit
                    0 , -- IsDel - bit
                    GETDATE()  -- CreateTime - datetime
                )
	END
UPDATE dbo.T_SectionVideo SET PraiseCount = PraiseCount + 1 WHERE Id = @SectionVideoId
                    ";
            }
            return DbQuestionBank.Execute(sql, new { request.SectionVideoId, request.UserId });
        }

        /// <summary>
        /// 收藏或取消收藏
        /// </summary>
        public int SubmitVideoCollection(SubmitVideoCollectionRequest request)
        {
            var sql = @";
            UPDATE dbo.T_UserCollectionVideo SET IsDel = 1 WHERE UserId = @UserId AND IsDel = 0 AND SectionVideoId = @SectionVideoId";
            if (request.Type == 1)
            {
                sql = @";
IF NOT EXISTS (SELECT * FROM dbo.T_UserCollectionVideo WHERE UserId = @UserId AND SectionVideoId = @SectionVideoId AND IsDel = 0)
	BEGIN
		INSERT
        INTO
        dbo.T_UserCollectionVideo
                ( UserId ,
                    SectionVideoId ,
                    IsUsed ,
                    IsDel ,
                    CreateTime
                )
        VALUES  ( @UserId , -- UserId - int
                  @SectionVideoId  , -- SectionVideoId - int
                  1 , -- IsUsed - bit
                  0 , -- IsDel - bit
                  GETDATE()  -- CreateTime - datetime
                )
	END
    
                  ";
            }
            return DbQuestionBank.Execute(sql, new { request.SectionVideoId, request.UserId });
        }

        /// <summary>
        /// 提交视频进度
        /// </summary>
        public int SubmitVideoProgress(SubmitVideoProgressRequest request)
        {
            var sql = @";
            INSERT
            INTO
            dbo.T_UserVideoHistory
                    ( UserId ,
                      SectionVideoId ,
                      Duration ,
                      IsFinished ,
                      IsUsed ,
                      IsDel ,
                      ModifyUserId ,
                      ModifyTime ,
                      CreateUserId ,
                      CreateTime
                    )
            VALUES  ( @UserId , -- UserId - int
                      @SectionVideoId , -- SectionVideoId - int
                      @Progress , -- Duration - int
                      @IsFinished , -- IsFinished - bit
                      1 , -- IsUsed - bit
                      0 , -- IsDel - bit
                      0 , -- ModifyUserId - int
                      GETDATE() , -- ModifyTime - datetime
                      0 , -- CreateUserId - int
                      GETDATE()  -- CreateTime - datetime
                    );
-- 更新用户在线表
UPDATE 
	dbo.T_UserOnlineRecord
SET 
	Type = 0,KeyId = 0,
	CategoryId = 0,
	IndustryId = 0
WHERE 
	UserId = @UserId AND IsDel = 0";

            return DbQuestionBank.Execute(sql, new
            {
                request.IsFinished,
                request.Progress,
                request.SectionVideoId,
                request.UserId
            });
        }

        /// <summary>
        /// 获取该课程下的章节列表
        /// </summary>
        public List<GetCourseMenuListModel> GetCourseMenuList(GetCourseMenuListRequest request)
        {
            var sql = @";
                SELECT
	                tco.Name AS CourseName,
	                tca.Name AS CategoryName,
	                tch.Name AS ChapterName,
	                tch.id AS ChapterId,
                    tch.Sequence AS ChapterSequence,
	                ts.Id AS SectionId,
                    ts.Sequence AS SectionSequence,
	                ts.Name AS SectionName,
	                ts.ExamRate
                FROM
	                dbo.T_Course tco
	                LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
	                LEFT JOIN dbo.T_Chapter tch ON tco.Id = tch.CourseId AND tch.IsDel = 0 AND tch.IsUsed = 1
	                LEFT JOIN dbo.T_Section ts ON tch.id = ts.ChapterId AND ts.IsDel = 0 AND ts.IsUsed = 1
                WHERE
	                tco.IsDel = 0 AND tco.IsUsed = 1
	                AND tca.IsDel = 0 AND tca.IsUsed = 1     
	                AND tco.Id = @CourseId
                ORDER BY tch.Sequence
                 ";
            return DbQuestionBank.Fetch<GetCourseMenuListModel>(sql, new { request.CourseId });
        }

        /// <summary>
        /// 获取讲师的课程
        /// </summary>
        public List<GetTeacherDetailModel> GetTeacherCourseModel(GetTeacherDetailRequest request)
        {
            var startIndex = (request.Page - 1) * request.PageSize + 1;
            var endIndex = request.Page * request.PageSize;
            var sql = $@";
                SELECT
	                *
                FROM
	                (
		                SELECT
			                ROW_NUMBER() OVER(ORDER BY sv.ModifyTime DESC) rn,
							COUNT(1) OVER() TotalCount,
			                tca.Name AS CategoryName,
                            tco.Id AS CourseId,
			                tco.Name AS CourseName,
			                s.ChapterId,
			                tch.Name AS ChapterName,
			                sv.SectionId,
			                s.Name AS SectionName,
			                s.Description AS SectionDesc,
			                sv.Id AS SectionVideoId,
                            tch.Sequence AS ChapterSequence,
                            s.Sequence AS SectionSequence,
			                sv.VideoImgPath,
			                tv.HighPath,
			                sv.BrowseCount,
			                sv.ModifyTime,
							tu.[Desc] AS TeacherDesc,
                            (SELECT COUNT(1) FROM dbo.T_UserBuyVideo ub WHERE ub.UserId = @UserId AND ub.IsDel = 0 AND ub.SectionVideoId = sv.Id)UserBuyCount,
							tu.DescImgPath AS TeacherDescImgPath
		                FROM
			                dbo.T_SectionVideo sv 
			                LEFT JOIN dbo.T_Section s ON s.Id = sv.SectionId
			                LEFT JOIN dbo.T_Chapter tch ON s.ChapterId = tch.Id
			                LEFT JOIN dbo.T_Course tco ON tco.id = tch.CourseId
			                LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
			                LEFT JOIN dbo.T_VideoLibrary tv ON tv.Id = sv.VideoLibraryId
							LEFT JOIN dbo.T_User tu ON tu.id = sv.TeacherId
		                WHERE
			                sv.IsDel = 0 AND sv.IsUsed = 1
			                AND s.IsDel = 0 AND s.IsUsed = 1
			                AND tch.IsDel = 0 AND tch.IsUsed = 1 
			                AND tco.IsDel = 0 AND tco.IsUsed = 1
			                AND tca.IsDel = 0 AND tca.IsUsed = 1
			                AND tv.IsDel = 0 AND tv.IsUsed = 1
							AND tu.IsDel = 0 AND tu.IsUsed = 1
			                AND sv.TeacherId = @TeacherId AND sv.IsFree = @IsFree
	                )a
                WHERE
	                a.rn BETWEEN {startIndex} AND {endIndex}";
            return DbQuestionBank.Fetch<GetTeacherDetailModel>(sql, new { request.TeacherId, request.IsFree,request.UserId });

        }

        /// <summary>
        /// 获取小节的详情
        /// </summary>
        public List<GetSectionDetailModel> GetSectionDetail(GetSectionDetailRequest request)
        {
            var sql = @";
        SELECT
			tca.Name AS CategoryName,
            tco.Id AS CourseId,
			tco.Name AS CourseName,
			tch.Name AS ChapterName,
			s.Name AS SectionName,
			sv.Id AS SectionVideoId,
			sv.VideoImgPath,
            sv.IsFree,
			tv.HighPath,
			sv.BrowseCount,
			sv.ModifyTime,
			sv.TeacherId,
			tu.RealName AS TeacherName,
			tu.ImgPath AS TeacherImg,
			tu.Title AS TeacherTitle,
			sv.Price,
			sv.SectionId,tch.Sequence AS ChapterSequence,s.Sequence AS SectionSequence,
			s.Description AS SectionDesc,
			(SELECT COUNT(1) FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.SectionVideoId = sv.Id)BuyCount,
            (SELECT COUNT(1) FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.SectionVideoId = sv.Id AND bv.UserId = @UserId )UserBuyCount	
		FROM
			dbo.T_SectionVideo sv 
			LEFT JOIN dbo.T_Section s ON s.Id = sv.SectionId
			LEFT JOIN dbo.T_Chapter tch ON s.ChapterId = tch.Id
			LEFT JOIN dbo.T_Course tco ON tco.id = tch.CourseId
			LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
			LEFT JOIN dbo.T_VideoLibrary tv ON tv.Id = sv.VideoLibraryId
			LEFT JOIN dbo.T_User tu ON tu.Id = sv.TeacherId
		WHERE
			sv.IsDel = 0 AND sv.IsUsed = 1
			AND s.IsDel = 0 AND s.IsUsed = 1
			AND tch.IsDel = 0 AND tch.IsUsed = 1 
			AND tco.IsDel = 0 AND tco.IsUsed = 1
			AND tca.IsDel = 0 AND tca.IsUsed = 1
			AND tv.IsDel = 0 AND tv.IsUsed = 1
			AND tu.IsDel = 0 AND tu.IsUsed = 1
			AND sv.SectionId = @SectionId";
            return DbQuestionBank.Fetch<GetSectionDetailModel>(sql, new { request.SectionId ,request.UserId});

        }

        /// <summary>
        /// 更新小节视频的浏览量字段
        /// </summary>
        public int UpdateSectionVideoBrowseCount(UpdateSectionVideoBrowseCountRequest request)
        {
            var sql = @";UPDATE dbo.T_SectionVideo SET BrowseCount = BrowseCount + 1 WHERE Id = @SectionVideoId";
            return DbQuestionBank.Execute(sql, new {request.SectionVideoId});
        }

        /// <summary>
        /// 获取全部的行业列表
        /// </summary>
        public List<T_Industry> GetAllIndustryList()
        {
            var sql = @"SELECT Id ,
                           Name ,
                           IsUsed ,
                           IsDel ,
                           ModifyUserId ,
                           ModifyTime ,
                           CreateUserId ,
                           CreateTime FROM dbo.T_Industry WHERE IsDel = 0 AND IsUsed = 1";
            return DbQuestionBank.Fetch<T_Industry>(sql);
        }

        /// <summary>
        /// 获取某个行业信息
        /// </summary>
        /// <param name="id">行业id</param>
        public T_Industry GetiIndustry(int id)
        {
            var sql = @"SELECT Id ,
                           Name ,
                           IsUsed ,
                           IsDel ,
                           ModifyUserId ,
                           ModifyTime ,
                           CreateUserId ,
                           CreateTime FROM dbo.T_Industry WHERE IsDel = 0 AND IsUsed = 1 AND id = @id";
            return DbQuestionBank.FirstOrDefault<T_Industry>(sql, new {id});
        }

        public int temp()
        {
            var sql = @"SELECT * FROM dbo.T_Section";
            var sList = DbQuestionBank.Fetch<T_Section>(sql);
            var random = new Random();
            foreach (var section in sList)
            {
                section.ExamRate = random.Next(30,80);
                DbQuestionBank.Update(section);
            }


            return 0;
        }

    }
}
