/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AccountService.cs
 *      Description:
 *            AccountService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 15:37:45
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Account;
using FrameWork.Entity.Model.Classmate;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Classmate;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// AccountService
    /// </summary>
    public class AccountService : BaseService<T_User>, IAccountService
    {
        /// <summary>
        /// 登录
        /// </summary>
        public T_User Login(LoginViewModel loginViewModel)
        {
            var sql = @"
                    SELECT
	                    *
                    FROM
	                    T_User
                    WHERE
	                    Name = @Name AND Password = @Password
	                    AND IsDel = 0 AND IsUsed = 1";
            loginViewModel.Password = Encrypt.MD5(loginViewModel.Password);//输入的密码进行加密与数据库进行比对
            return DbQuestionBank.FirstOrDefault<T_User>(sql, new { Name = loginViewModel.UserName, loginViewModel.Password });
        }

        /// <summary>
        /// 获取该微信的用户信息
        /// </summary>
        /// <param name="openId">微信账号</param>
        /// <param name="request">用户参数</param>
        public T_Student GetStudent(string openId, GetUserInfoRequest request)
        {
            var sql = @";
                SELECT
	                Id ,
                    UserName ,
                    Sex ,
                    Phone ,
                    School ,
                    Major ,
                    Company ,
                    Position ,openId,studyNumber,RealName
                FROM
	                dbo.T_Student
                WHERE
	                openId = @openId AND IsDel = 0";
            var insertSql = @";
IF NOT EXISTS (SELECT * FROM dbo.T_Student WHERE openId = @openId AND IsDel = 0)
BEGIN
	INSERT
	INTO
    dbo.T_Student
            ( openId ,
              Description ,
              UserName ,
              Sex ,
              Phone ,
              School ,
              Major ,
              Company ,
              Position ,
              IsUsed ,
              IsDel ,
              ModifyUserId ,
              ModifyTime ,
              CreateTime ,
              CreateUserId,
              HeadImg
            )
    VALUES  ( @openId , -- WeChatAccount - varchar(100)
              '' , -- Description - varchar(200)
              @UserName , -- UserName - nvarchar(50)
              0 , -- Sex - tinyint
              N'' , -- Phone - nvarchar(20)
              N'' , -- School - nvarchar(50)
              N'' , -- Major - nvarchar(50)
              N'' , -- Company - nvarchar(50)
              N'' , -- Position - nvarchar(50)
              1 , -- IsUsed - bit
              0 , -- IsDel - bit
              0 , -- ModifyUserId - int
              GETDATE() , -- ModifyTime - datetime
              GETDATE() , -- CreateTime - datetime
              0,  -- CreateUserId - int
              @HeadImg
            )
END
ELSE
    BEGIN
        UPDATE T_Student set HeadImg = @HeadImg,UserName = @UserName  where openId = @openId;
    END";
            DbQuestionBank.Execute(insertSql, new { openId, request.HeadImg, request.UserName });
            var model = DbQuestionBank.FirstOrDefault<T_Student>(sql, new { openId });
            var studyNumber = model.Id + 10000000;
            var updateNumber = @"UPDATE T_Student set studyNumber = @studyNumber  where openId = @openId;";//更新学号
            DbQuestionBank.Execute(updateNumber, new { openId, studyNumber });
            var updateSql = @"
-- 如果已经在线，更新坐标；否则插入在线表
IF EXISTS (SELECT * FROM dbo.T_UserOnlineRecord WHERE UserId = @Id)
	BEGIN
		UPDATE dbo.T_UserOnlineRecord SET Longitude = @Longitude,Latitude= @Latitude  WHERE UserId = @Id
	END
ELSE
	BEGIN
		INSERT
		INTO
        dbo.T_UserOnlineRecord
                ( UserId ,
                  Type ,
                  IndustryId ,
                  CategoryId ,
                  KeyId ,
                  Longitude ,
                  Latitude ,
                  IsDel ,
                  ModifyUserId ,
                  ModifyTime ,
                  CreateUserId ,
                  CreateTime
                )
        VALUES  ( @Id , -- UserId - int
                  0 , -- Type - tinyint
                  0 , -- IndustryId - int
                  0 , -- CategoryId - int
                  0 , -- KeyId - int
                  @Longitude , -- Longitude - float
                  @Latitude , -- Latitude - float
                  0 , -- IsDel - bit
                  0 , -- ModifyUserId - int
                  GETDATE() , -- ModifyTime - datetime
                  0 , -- CreateUserId - int
                  GETDATE()  -- CreateTime - datetime
                )

	END
    ";
            DbQuestionBank.Execute(updateSql, new { request.Latitude, request.Longitude, model.Id });
            return model;
        }

        /// <summary>
        /// 提交用户信息
        /// </summary>
        public int SubmitUserInfo(SubmitUserInfoRequest request)
        {
            var sql = @";
                    UPDATE
	                    dbo.T_Student
                    SET
	                    RealName = @RealName,
	                    Sex =@Sex,
	                    Phone=@Phone,
	                    School=@School,
	                    Major=@Major,
                        Company = @Company,
	                    Position = @Position
                    WHERE
	                    Id = @UserId";

            return DbQuestionBank.Execute(sql, new
            {
                request.UserId,
                request.RealName,
                request.Major,
                request.Position,
                request.Sex,
                request.School,
                request.Company,
                request.Phone
            });
        }

        //        /// <summary>
        //        /// 我的课程 获取学员用户的课程列表
        //        /// </summary>
        //        public List<GetMyCourseListModel> GetMyCourseList(GetMyCourseListRequest request)
        //        {
        //            var startIndex = (request.Page - 1) * request.PageSize + 1;
        //            var endIndex = request.PageSize * request.Page;

        //            var sql = $@";
        //SELECT
        //	*
        //FROM
        //	(
        //		SELECT
        //			ROW_NUMBER() OVER(ORDER BY sv.Id DESC) rn,
        //			COUNT(1) OVER() TotalCount,
        //			tca.Name AS CategoryName,
        //			tco.Name AS CourseName,
        //			tch.Name AS ChapterName,
        //			s.Name AS SectionName,tch.CourseId,
        //			sv.Id AS SectionVideoId,
        //			sv.VideoImgPath,
        //			tu.RealName AS TeacherName,
        //			sv.SectionId,
        //			(SELECT TOP 1 vh.CreateTime FROM dbo.T_UserVideoHistory vh WHERE vh.IsDel = 0 AND vh.UserId = @UserId AND vh.SectionVideoId = sv.Id ORDER BY vh.Id DESC)LastWatchTime	,
        //			(SELECT TOP 1 bv.CreateTime FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.UserId = @UserId AND bv.SectionVideoId = sv.Id ORDER BY bv.Id DESC)BuyTime,
        //			(SELECT TOP 1 bv.ValidateDay FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.UserId = @UserId AND bv.SectionVideoId = sv.Id ORDER BY bv.Id DESC)ValidateDay
        //		FROM
        //			dbo.T_SectionVideo sv 
        //			LEFT JOIN dbo.T_Section s ON s.Id = sv.SectionId
        //			LEFT JOIN dbo.T_Chapter tch ON s.ChapterId = tch.Id
        //			LEFT JOIN dbo.T_Course tco ON tco.id = tch.CourseId
        //			LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
        //			LEFT JOIN dbo.T_VideoLibrary tv ON tv.Id = sv.VideoLibraryId
        //			LEFT JOIN dbo.T_User tu ON tu.Id = sv.TeacherId
        //		WHERE
        //			sv.IsDel = 0 AND sv.IsUsed = 1
        //			AND s.IsDel = 0 AND s.IsUsed = 1
        //			AND tch.IsDel = 0 AND tch.IsUsed = 1 
        //			AND tco.IsDel = 0 AND tco.IsUsed = 1
        //			AND tca.IsDel = 0 AND tca.IsUsed = 1
        //			AND tv.IsDel = 0 AND tv.IsUsed = 1
        //			AND tu.IsDel = 0 AND tu.IsUsed = 1
        //			AND tca.IndustryId = @IndustryId
        //            AND tu.Id = @UserId

        //	)a
        //WHERE
        //	a.rn BETWEEN {startIndex} AND {endIndex}";
        //            return DbQuestionBank.Fetch<GetMyCourseListModel>(sql, new { request.IndustryId, request.UserId });
        //        }

        /// <summary>
        /// 我的课程 获取学员用户的课程列表
        /// </summary>
        public List<GetMyCourseListModel> GetMyCourseList(GetMyCourseListRequest request)
        {
            var startIndex = (request.Page - 1) * request.PageSize + 1;
            var endIndex = request.PageSize * request.Page;

            var sql = $@";
SELECT
	*
FROM
	(
		SELECT
			ROW_NUMBER() OVER(ORDER BY tubv.CreateTime DESC) rn,
			COUNT(1) OVER() TotalCount,
			tca.Name AS CategoryName,
			tco.Name AS CourseName,
			tch.Name AS ChapterName,
			s.Name AS SectionName,tch.CourseId,
			tubv.SectionVideoId AS SectionVideoId,
			sv.VideoImgPath,
			u.RealName AS TeacherName,
			(SELECT TOP 1 vh.CreateTime FROM dbo.T_UserVideoHistory vh WHERE vh.IsDel = 0 AND vh.UserId = @UserId AND vh.SectionVideoId = tubv.SectionVideoId ORDER BY vh.Id DESC)LastWatchTime	,
			(SELECT TOP 1 bv.CreateTime FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.UserId = @UserId AND bv.SectionVideoId = tubv.SectionVideoId ORDER BY bv.Id DESC)BuyTime,
			(SELECT TOP 1 bv.ValidateDay FROM dbo.T_UserBuyVideo bv WHERE bv.IsDel = 0 AND bv.UserId = @UserId AND bv.SectionVideoId = tubv.SectionVideoId ORDER BY bv.Id DESC)ValidateDay
		FROM
			dbo.T_UserBuyVideo tubv 
            LEFT JOIN dbo.T_SectionVideo sv on tubv.SectionVideoId = sv.Id
			LEFT JOIN dbo.T_Section s ON s.Id = sv.SectionId
			LEFT JOIN dbo.T_Chapter tch ON s.ChapterId = tch.Id
			LEFT JOIN dbo.T_Course tco ON tco.id = tch.CourseId
			LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
			LEFT JOIN dbo.T_VideoLibrary tv ON tv.Id = sv.VideoLibraryId
			LEFT JOIN dbo.T_Student ts ON ts.Id = tubv.UserId
            LEFT JOIN dbo.T_User u ON sv.TeacherId = u.Id
		WHERE
			tubv.IsDel = 0 AND tubv.IsUsed = 1
            AND sv.IsDel = 0 AND sv.IsUsed = 1
			AND s.IsDel = 0 AND s.IsUsed = 1
			AND tch.IsDel = 0 AND tch.IsUsed = 1 
			AND tco.IsDel = 0 AND tco.IsUsed = 1
			AND tca.IsDel = 0 AND tca.IsUsed = 1
			AND tv.IsDel = 0 AND tv.IsUsed = 1
			AND ts.IsDel = 0 AND ts.IsUsed = 1
			AND tca.IndustryId = @IndustryId
            AND ts.Id = @UserId

	)a
WHERE
	a.rn BETWEEN {startIndex} AND {endIndex}";
            return DbQuestionBank.Fetch<GetMyCourseListModel>(sql, new { request.IndustryId, request.UserId });
        }

        /// <summary>
        /// 生成订单并获取小节的信息
        /// </summary>
        public T_SectionVideo GetWeChatPayParameter(GetWeChatPayParameterRequest request, string number)
        {
            var sql = @";
                    INSERT
                    INTO
                    dbo.T_UserOrder
                            ( UserId ,
                              Number ,
                              TotalPrice ,
                              TradeNo ,
                              PayType ,
                              SectionVideoId ,
                              Status ,
                              IsUsed ,
                              IsDel ,
                              ModifyUserId ,
                              ModifyTime ,
                              CreateUserId ,
                              CreateTime
                            )
                    VALUES  ( @UserId , -- UserId - int
                              @number , -- Number - varchar(255)
                              (SELECT TOP 1 Price FROM dbo.T_SectionVideo WHERE Id = @SectionVideoId) , -- TotalPrice - float
                              '' , -- TradeNo - varchar(255)
                              0 , -- PayType - int
                              @SectionVideoId , -- SectionVideoId - int
                              0 , -- Status - int
                              1 , -- IsUsed - bit
                              0 , -- IsDel - bit
                              0 , -- ModifyUserId - int
                              GETDATE() , -- ModifyTime - datetime
                              0 , -- CreateUserId - int
                              GETDATE()  -- CreateTime - datetime
                            )
                    ";
            DbQuestionBank.Execute(sql, new { request.UserId, number, request.SectionVideoId });

            var querySql = @"SELECT TOP 1 * FROM dbo.T_SectionVideo WHERE Id = @SectionVideoId";
            return DbQuestionBank.FirstOrDefault<T_SectionVideo>(querySql, new
            {
                request.SectionVideoId
            });
        }

        /// <summary>
        /// 更新订单状态，把小节和用户关联起来
        /// </summary>
        /// <param name="number">订单编号</param>
        public int UpdateOrderStatus(string number)
        {
            var sql = @";
UPDATE dbo.T_UserOrder SET Status = 1 WHERE Number = @number
INSERT
INTO
dbo.T_UserBuyVideo
        ( UserId ,
          SectionVideoId ,
          ValidateDay ,
          IsUsed ,
          IsDel ,
          CreateTime
        )
VALUES  ( (SELECT TOP 1 o.UserId FROM dbo.T_UserOrder o WHERE Number =  @number  AND IsDel = 0) , -- UserId - int
          (SELECT TOP 1 o.SectionVideoId FROM dbo.T_UserOrder o WHERE Number =  @number  AND IsDel = 0) , -- SectionVideoId - int
          ISNULL( (SELECT
				TOP 1 tc.ValidateDay
			FROM
				dbo.T_Course tc
				LEFT JOIN dbo.T_Chapter tch ON tc.Id = tch.CourseId
				LEFT JOIN dbo.T_Section ts ON tch.Id = ts.ChapterId
				LEFT JOIN dbo.T_SectionVideo sv ON ts.Id = sv.SectionId
			WHERE
				sv.Id in (SELECT TOP 1 o.SectionVideoId FROM dbo.T_UserOrder o WHERE Number = @number  AND IsDel = 0)),0) , -- ValidateDay - int
          1 , -- IsUsed - bit
          0 , -- IsDel - bit
          GETDATE()  -- CreateTime - datetime
        )
UPDATE dbo.T_SectionVideo SET BuyCount = BuyCount + 1 WHERE Id = (SELECT o.SectionVideoId FROM dbo.T_UserOrder o WHERE o.Number = @number AND o.IsDel = 0)";
            return DbQuestionBank.Execute(sql, new { number });
        }

        /// <summary>
        /// 获取用户的能量值
        /// </summary>
        public UserEnergy GetUserEnergy(GetClassmateNumRequest req)
        {
            var sql = @"
                        SELECT
	                        EnergyCount
                        FROM
	                        dbo.T_Student
                        WHERE
	                        Id = @UserId";

            return DbQuestionBank.FirstOrDefault<UserEnergy>(sql, new { req.UserId });
        }

        /// <summary>
        /// 获取给这个用户添加能量的用户列表
        /// </summary>
        public List<UserInfoModel> GetInfoModels(GetClassmateNumRequest req)
        {
            var sql = @"
                   SELECT  TOP 20
	                    a.UserId,
	                    ts.HeadImg AS UserHeadImg
                    FROM
	                    (
		                    SELECT
			                    ROW_NUMBER() OVER(PARTITION BY UserId ORDER BY CreateTime DESC) rn,*
		                    FROM
			                    dbo.T_UserEnergyRecord
		                    WHERE
			                    Type = 1 AND KeyId = @UserId
	                    )a 
	                    LEFT JOIN dbo.T_Student ts ON ts.Id = a.UserId
                    WHERE 
	                    a.rn = 1 AND a.IsDel = 0 
	                    AND ts.IsDel = 0";
            return DbQuestionBank.Fetch<UserInfoModel>(sql, new { req.UserId });
        }

        /// <summary>
        /// 获取行业及行业下的用户数量
        /// </summary>
        public List<IndustryUserCountModel> GetIndustryUserCountModels(GetClassmateNumRequest req)
        {
            var sql = @"
                    SELECT
	                    IndustryId,
	                    COUNT(UserId) IndustryUserCount
                    FROM
	                    dbo.T_UserOnlineRecord
                    WHERE
	                    IsDel = 0 
	                    AND Type != 2 AND UserId != @UserId
                    GROUP BY IndustryId";
            return DbQuestionBank.Fetch<IndustryUserCountModel>(sql, new { req.UserId });
        }

        /// <summary>
        /// 获取某个行业下的所有学生列表
        /// </summary>
        public List<GetClassmateInfoModel> GetClassmateInfoModels(GetClassmateInfoRequest req)
        {
            var startIndex = (req.Page - 1) * req.PageSize + 1;
            var endIndex = req.Page * req.PageSize;

            var sql = $@"
SELECT
	*
FROM
	(
		SELECT
			*,ROW_NUMBER() OVER(ORDER BY a.Distance)rn,
					COUNT(1) OVER() TotalCount
		FROM
			(
				SELECT			
					ti.Name AS IndustryName,
					ur.UserId,
					ts.UserName,
					ts.HeadImg,
					ts.EnergyCount,
					ur.Longitude,
					ur.Latitude,
					6378.138*2*ASIN(SQRT(POWER(SIN(((SELECT TOP 1 vb.Latitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @UserId)*PI()/180-ur.latitude*PI()/180)/2),2)+ COS((SELECT TOP 1 vb.Latitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @UserId)*PI()/180)*COS(ur.latitude*PI()/180)*POWER(SIN(((SELECT TOP 1 vb.Longitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @UserId)*PI()/180-ur.Longitude*PI()/180)/2),2))) AS Distance,
					(SELECT 
							TOP 1 tca.Name
						FROM dbo.T_UserVideoHistory vh 
							LEFT JOIN dbo.T_SectionVideo sv ON vh.SectionVideoId = sv.Id
							LEFT JOIN dbo.T_Section tts ON tts.Id = sv.SectionId
							LEFT JOIN dbo.T_Chapter ttc ON tts.ChapterId = ttc.Id
							LEFT JOIN dbo.T_Course tco ON ttc.CourseId = tco.Id
							LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
						WHERE vh.UserId = ts.Id ORDER BY vh.Id DESC)NowCategory,
					(SELECT
							COUNT(1)
						FROM
							dbo.T_UserEnergyRecord
						WHERE
							UserId = @UserId AND Type = 1 AND KeyId = ts.Id AND AddDate = CONVERT(varchar(100), GETDATE(), 23))IsAdd
				FROM
					dbo.T_UserOnlineRecord ur
					LEFT JOIN dbo.T_Student ts ON ur.UserId = ts.Id
					LEFT JOIN dbo.T_Industry ti ON ti.Id = ur.IndustryId AND ti.IsDel = 0
				WHERE
					ur.IndustryId = @IndustryId AND ur.Type != 2
					AND ur.IsDel = 0 AND ts.IsDel = 0
					 AND ur.UserId != @UserId	
			)a
	)b
WHERE
	b.rn BETWEEN {startIndex} AND {endIndex}";
            return DbQuestionBank.Fetch<GetClassmateInfoModel>(sql, new { req.UserId, req.IndustryId });
        }

        /// <summary>
        /// 给同学加能量
        /// </summary>
        public int AddEnergyValue(AddEnergyValueRequest req)
        {
            var sql = @"
IF NOT EXISTS (SELECT * FROM dbo.T_UserEnergyRecord WHERE AddDate = CONVERT(varchar(100), GETDATE(), 23) AND UserId = 1 AND Type = 1 AND KeyId = 19)
	BEGIN
		INSERT
		INTO
		dbo.T_UserEnergyRecord
				( UserId ,
				  Type ,
				  KeyId ,
				  Count ,
				  UserCurrentBalance ,
				  AddDate ,
				  IsDel ,
				  ModifyUserId ,
				  ModifyTime ,
				  CreateUserId ,
				  CreateTime
				)
		VALUES  ( @UserId , -- UserId - int
				  1 , -- Type - tinyint
				  @ClassmateId , -- KeyId - int
				  5 , -- Count - int
				 (SELECT TOP 1 EnergyCount FROM dbo.T_Student WHERE Id = @ClassmateId)+5 , -- UserCurrentBalance - int
				  GETDATE() , -- AddDate - date
				  0 , -- IsDel - bit
				  0 , -- ModifyUserId - int
				  GETDATE() , -- ModifyTime - datetime
				  0 , -- CreateUserId - int
				  GETDATE()  -- CreateTime - datetime
				)
                --,
				--( 19 , -- UserId - int
				--  0 , -- Type - tinyint
				--  1 , -- KeyId - int
				--  5 , -- Count - int
				-- (SELECT TOP 1 EnergyCount FROM dbo.T_Student WHERE Id = 1)-5 , -- UserCurrentBalance - int
				--  GETDATE() , -- AddDate - date
				--  0 , -- IsDel - bit
				--  0 , -- ModifyUserId - int
				--  GETDATE() , -- ModifyTime - datetime
				--  0 , -- CreateUserId - int
				--  GETDATE()  -- CreateTime - datetime
				--)
		UPDATE dbo.T_Student SET EnergyCount = EnergyCount + 5 WHERE Id = @ClassmateId
        --UPDATE dbo.T_Student SET EnergyCount = EnergyCount - 5 WHERE Id = 1
	END
";
            return DbQuestionBank.Execute(sql, new { req.UserId, req.ClassmateId });
        }

        /// <summary>
        /// 获取给我加能量的同学
        /// </summary>
        public List<GetMyClassmateListModel> GetMyClassmateList(GetMyClassmateListRequest req)
        {
            var startIndex = (req.Page - 1) * req.PageSize + 1;
            var endIndex = req.Page * req.PageSize;
            var sql = $@";
SELECT
	*
FROM
	(
		SELECT
			ROW_NUMBER() OVER(ORDER BY a.CreateTime DESC) rrn,
			COUNT(1) OVER() TotalCount,
			a.UserId,
			ts.UserName,
			ts.EnergyCount,
			ts.HeadImg AS UserHeadImg,
			a.CreateTime,
			(SELECT 
				TOP 1 tca.Name
			FROM dbo.T_UserVideoHistory vh 
				LEFT JOIN dbo.T_SectionVideo sv ON vh.SectionVideoId = sv.Id
				LEFT JOIN dbo.T_Section tts ON tts.Id = sv.SectionId
				LEFT JOIN dbo.T_Chapter ttc ON tts.ChapterId = ttc.Id
				LEFT JOIN dbo.T_Course tco ON ttc.CourseId = tco.Id
				LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
			WHERE vh.UserId = ts.Id ORDER BY vh.Id DESC)NowCategory,
		(SELECT
				COUNT(1)
			FROM
				dbo.T_UserEnergyRecord tur
			WHERE
				tur.UserId = @UserId AND tur.Type = 1 AND tur.KeyId = ts.Id AND AddDate = CONVERT(varchar(100), GETDATE(), 23))IsAdd
		FROM
			(
				SELECT
					ROW_NUMBER() OVER(PARTITION BY UserId ORDER BY CreateTime DESC) rn,uur.*
				FROM
					dbo.T_UserEnergyRecord uur
				WHERE
					uur.Type = 1 AND uur.KeyId = @UserId
			)a 
			LEFT JOIN dbo.T_Student ts ON ts.Id = a.UserId
		WHERE 
			a.rn = 1 AND a.IsDel = 0 
			AND ts.IsDel = 0
	)b
WHERE
	b.rrn BETWEEN {startIndex} AND {endIndex}";
            return DbQuestionBank.Fetch<GetMyClassmateListModel>(sql, new { req.UserId });
        }

        /// <summary>
        /// 获取所有学员的坐标
        /// </summary>
        public List<GetMyClassmateMapDataModel> GetMyClassmateMapData(GetMyClassmateMapDataRequest req)
        {
            var sql = @";
SELECT
	ur.UserId,
	ur.Longitude,
	ur.Latitude
FROM
	dbo.T_UserOnlineRecord ur
	LEFT JOIN dbo.T_Student ts ON ur.UserId = ts.Id
WHERE
	ur.IsDel = 0 AND ts.IsDel = 0 AND ur.Type != 2 AND ur.IndustryId = @IndustryId
	";
            return DbQuestionBank.Fetch<GetMyClassmateMapDataModel>(sql, new { req.IndustryId });
        }

        /// <summary>
        /// 登出小程序
        /// </summary>
        public int Logout(LogoutRequest req)
        {
            var sql = @";
UPDATE 
	dbo.T_UserOnlineRecord
SET 
	Type = 2,KeyId = 0,
	CategoryId = 0,
	IndustryId = 0
WHERE 
	UserId = @UserId AND IsDel = 0";
            return DbQuestionBank.Execute(sql, new { req.UserId });
        }

        /// <summary>
        /// 获取用户的详情
        /// </summary>
        /// <param name="userId">用户id</param>
        public GetMyClassmateDeatilModel GetMyClassmateDeatil(int userId)
        {
            var sql = @";
                SELECT			
					ur.UserId,
					ts.UserName,
					ts.HeadImg AS UserHeadImg,
					ts.EnergyCount,
					ur.Longitude,
					ur.Latitude,
					6378.138*2*ASIN(SQRT(POWER(SIN(((SELECT TOP 1 vb.Latitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @userId)*PI()/180-ur.latitude*PI()/180)/2),2)+ COS((SELECT TOP 1 vb.Latitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @userId)*PI()/180)*COS(ur.latitude*PI()/180)*POWER(SIN(((SELECT TOP 1 vb.Longitude FROM dbo.T_UserOnlineRecord vb WHERE vb.UserId = @userId)*PI()/180-ur.Longitude*PI()/180)/2),2))) AS Distance,
					(SELECT 
							TOP 1 tca.Name
						FROM dbo.T_UserVideoHistory vh 
							LEFT JOIN dbo.T_SectionVideo sv ON vh.SectionVideoId = sv.Id
							LEFT JOIN dbo.T_Section tts ON tts.Id = sv.SectionId
							LEFT JOIN dbo.T_Chapter ttc ON tts.ChapterId = ttc.Id
							LEFT JOIN dbo.T_Course tco ON ttc.CourseId = tco.Id
							LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
						WHERE vh.UserId = ts.Id ORDER BY vh.Id DESC)NowCategory,
					(SELECT
							COUNT(1)
						FROM
							dbo.T_UserEnergyRecord
						WHERE
							UserId = @userId AND Type = 1 AND KeyId = ts.Id AND AddDate = CONVERT(varchar(100), GETDATE(), 23))IsAdd
				FROM
					dbo.T_UserOnlineRecord ur
					LEFT JOIN dbo.T_Student ts ON ur.UserId = ts.Id
				WHERE
					ur.IsDel = 0 AND ts.IsDel = 0
					AND ur.UserId = @userId	";
            return DbQuestionBank.FirstOrDefault<GetMyClassmateDeatilModel>(sql, new { userId });
        }

        /// <summary>
        /// 提交用户经纬度信息
        /// </summary>
        public int SubmitUserPosition(SubmitUserPositionRequest req)
        {
            var sql = @";
IF EXISTS (SELECT 1 FROM dbo.T_UserOnlineRecord WHERE UserId = @UserId AND IsDel = 0)
	BEGIN
		UPDATE dbo.T_UserOnlineRecord SET Longitude = @Longitude ,Latitude = @Latitude WHERE UserId = @UserId AND IsDel = 0
	END
ELSE
	BEGIN
		INSERT
        INTO
        dbo.T_UserOnlineRecord
                ( UserId ,
                  Type ,
                  IndustryId ,
                  CategoryId ,
                  KeyId ,
                  Longitude ,
                  Latitude ,
                  IsDel ,
                  ModifyUserId ,
                  ModifyTime ,
                  CreateUserId ,
                  CreateTime
                )
        VALUES  ( @UserId , -- UserId - int
                  0 , -- Type - tinyint
                  0 , -- IndustryId - int
                  0 , -- CategoryId - int
                  0 , -- KeyId - int
                  @Longitude , -- Longitude - float
                  @Latitude , -- Latitude - float
                  0 , -- IsDel - bit
                  0 , -- ModifyUserId - int
                  GETDATE() , -- ModifyTime - datetime
                  0 , -- CreateUserId - int
                  GETDATE()  -- CreateTime - datetime
                )
	END
    ";

            return DbQuestionBank.Execute(sql, new { req.UserId, req.Longitude, req.Latitude });
        }


        /// <summary>
        /// 获取用户收藏的课程列表
        /// </summary>
        public List<GetUserCollectCourseModel> GetUserCollectCourseList(GetUserCollectRequest request)
        {
            var startIndex = (request.Page - 1) * request.PageSize + 1;
            var endIndex = request.PageSize * request.Page;
            var sql = $@";
                        SELECT
	                        uv.SectionVideoId,
	                        sv.Name AS SectionVideoName,
	                        tco.Name AS CourseName,
	                        tch.Sequence AS ChapterSequence,
	                        ts.Sequence AS SectionSequence,
	                        tca.Name AS CategoryName,
	                        tu.RealName AS TeacherName,
	                        uv.CreateTime ,
	                        sv.IsFree,uv.TotalCount,
	                        sv.VideoImgPath
                        FROM
	                        (
		                        SELECT
			                        ROW_NUMBER() OVER(ORDER BY a.Id DESC) rn,COUNT(1) OVER() TotalCount,
			                        a.Id,a.SectionVideoId,a.CreateTime
		                        FROM
			                        dbo.T_UserCollectionVideo a 
		                        WHERE
			                        a.UserId = @UserId AND a.IsDel = 0
	                        )uv
	                        LEFT JOIN dbo.T_SectionVideo sv ON uv.SectionVideoId = sv.Id AND sv.IsDel = 0 
	                        LEFT JOIN dbo.T_User tu ON sv.TeacherId = tu.Id AND tu.IsDel = 0
	                        LEFT JOIN dbo.T_Section ts ON sv.SectionId = ts.Id 
	                        LEFT JOIN dbo.T_Chapter tch ON ts.ChapterId = tch.Id
	                        LEFT JOIN dbo.T_Course tco ON tch.CourseId = tco.Id
	                        LEFT JOIN dbo.T_Category tca ON tco.CategoryId = tca.Id
                        WHERE
	                        uv.rn BETWEEN {startIndex} AND {endIndex}";
            return DbQuestionBank.Fetch<GetUserCollectCourseModel>(sql, new { request.UserId });
        }

        /// <summary>
        /// 获取用户收藏的资讯列表
        /// </summary>
        public List<GetUserCollectNewsModel> GetUserCollectNewsList(GetUserCollectRequest request)
        {
            var startIndex = (request.Page - 1) * request.PageSize + 1;
            var endIndex = request.PageSize * request.Page;
            var sql = $@";
                    SELECT
	                    a.NewsId,
                        (SELECT title FROM dbo.T_News WHERE Id = a.NewsId) Title,
	                    a.CreateTime,
	                    n.Summary,
                        a.TotalCount,
	                    ti.Name AS IndustryName
                    FROM
	                    (
		                    SELECT
			                    ROW_NUMBER() OVER(ORDER BY cn.Id DESC)rn,COUNT(1) OVER() TotalCount,
			                    *
		                    FROM
			                    dbo.T_UserCollectNews cn
		                    WHERE
			                    cn.UserId = @UserId AND cn.IsDel = 0
	                    )a
	                    LEFT JOIN dbo.T_News n ON a.NewsId = n.Id
	                    LEFT JOIN dbo.T_Industry ti ON n.IndustryId = ti.Id
                    WHERE
	                    a.rn BETWEEN {startIndex} AND {endIndex}";
            var result = DbQuestionBank.Fetch<GetUserCollectNewsModel>(sql, new { request.UserId });
            return result;
        }
    }
}
