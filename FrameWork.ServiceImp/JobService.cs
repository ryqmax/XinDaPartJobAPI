/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                JobService.cs
 *      Description:
 *            JobService
 *      Author:
 *                a-fei
 *                
 *                
 *      Finish DateTime:
 *                2018/03/17 15:37:45
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using FrameWork.Common;
using FrameWork.Common.Models;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Job;
using FrameWork.Entity.ViewModel.Job;
using FrameWork.Entity.ViewModel.SignIn;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// JobService
    /// </summary>
    public class JobService : BaseService<T_Job>, IJobService
    {
        public List<JobInfo> GetJobList(GetJobListReq getJobListReq, string cityId, int ePId)
        {
            int startPage = (getJobListReq.PageSize) * (getJobListReq.Page - 1) + 1;
            int endPage = getJobListReq.Page * getJobListReq.PageSize;


            var where = string.Empty;
            var jobAddressWhere = string.Empty;
            if (getJobListReq.RegionId != 0)
            {
                where += " AND epaddress.AreaId = @areaid";
                jobAddressWhere += " AND epaddress.AreaId = @areaid";
            }
            if (getJobListReq.EmployerRankId > 0)
            {
                where += " AND ep.Level = @level";
            }
            if (getJobListReq.JobTypeId > 0)
            {
                where += " AND job.JobCategoryId = @jobcaid";
            }


            var sql = $@"SELECT  DISTINCT
                                job.Id JobId ,
                                job.RefreshTime
                        INTO    #JobIdTemp
                        FROM    dbo.T_Job job
                                LEFT JOIN dbo.T_Enterprise ep ON job.EnterpriseId = ep.Id
                                LEFT JOIN dbo.T_JobAddress jobaddress ON job.Id = jobaddress.JobId
                                LEFT JOIN dbo.T_EPAddress epaddress ON epaddress.Id = jobaddress.EPAddressId
                                LEFT JOIN dbo.DicRegion dicregion ON epaddress.AreaId = dicregion.Id
                                LEFT JOIN dbo.T_PayWay payway ON payway.Id = job.PayWayId
                        WHERE   job.IsDel = 0
                                AND ep.IsDel = 0        
                                AND jobaddress.IsDel = 0
                                AND epaddress.IsDel = 0
                                AND dicregion.IsDel = 0                                
                                AND payway.IsDel = 0
                                {where}
		                        AND job.Type=@type
		                        AND epaddress.CityId=@cityId;

                        SELECT  *
                        INTO    #JobIdPageTemp
                        FROM    ( SELECT    * ,
					                        COUNT(*) OVER ( ) TotalNum,
                                            ROW_NUMBER() OVER ( ORDER BY RefreshTime DESC ) Num
                                  FROM      #JobIdTemp
                                ) temp
                        WHERE   temp.Num BETWEEN @startPage AND @endPage;

                        SELECT  job.Id JobId ,
                                ep.Id JobEmployerId ,
                                ep.Level JobEmployerLevel ,
                                job.Name JobName ,
                                job.SalaryLower ,
                                job.SalaryUpper ,
                                payway.Unit ,
                                ( CASE WHEN -1 = -1 THEN '不限地点'
                                       ELSE ( SELECT TOP 1
                                                        dicregion.Description
                                              FROM      dbo.T_JobAddress jobaddress
                                                        LEFT JOIN dbo.T_EPAddress epaddress ON epaddress.Id = jobaddress.EPAddressId
                                                        LEFT JOIN dbo.DicRegion dicregion ON epaddress.AreaId = dicregion.Id
                                              WHERE     1 = 1
                                                        AND jobaddress.IsDel = 0
                                                        AND epaddress.IsDel = 0
                                                        AND dicregion.IsDel = 0
                                                        AND job.Id = jobaddress.JobId
                                                        {jobAddressWhere}
                                            )
                                  END ) JobAddress ,
                                job.WorkTime JobTime ,
                                ( SELECT TOP 1
                                            vipinfo.Name
                                  FROM      dbo.T_VIPInfo vipinfo
                                            LEFT JOIN dbo.T_EPVIP epvip ON epvip.VIPInfoId = vipinfo.Id
                                  WHERE     epvip.EnterpriseId = ep.Id
                                            AND vipinfo.IsDel = 0
                                            AND epvip.IsDel = 0
                                  ORDER BY  vipinfo.OldPrice DESC
                                ) JobMember ,
                                ( CASE WHEN ep.Id = @ePId THEN 1
                                       ELSE 0
                                  END ) IsSelf ,
                                job.IsPractice IsPractice ,        
		                        #JobIdPageTemp.TotalNum
                        FROM    dbo.T_Job job
                                LEFT JOIN dbo.T_Enterprise ep ON job.EnterpriseId = ep.Id
                                LEFT JOIN dbo.T_PayWay payway ON payway.Id = job.PayWayId
                                INNER JOIN #JobIdPageTemp ON #JobIdPageTemp.JobId = job.Id;

                        DROP TABLE #JobIdTemp;
                        DROP TABLE #JobIdPageTemp;";
            return DbPartJob.Fetch<JobInfo>(sql, new { type = getJobListReq.Type, areaid = getJobListReq.RegionId, jobcaid = getJobListReq.JobTypeId, level = getJobListReq.EmployerRankId, cityId, startPage, endPage, ePId });
        }

        /// <summary>
        /// 获取兼职岗位详情
        /// </summary>
        public GetPartJobModel GetPartJob(int jobId, int userId)
        {
            var sql = @";
                SELECT
	                j.Id AS JobId,
	                j.Name AS JobName,
	                j.SalaryLower,
	                j.SalaryUpper,
	                ca.Name AS JobCategoryName,
	                pw.Unit AS PayUnit,
	                pw.Name AS PayWay,
	                (SELECT COUNT(1) FROM dbo.T_CVDelivery cd WHERE cd.IsDel = 0 AND cd.JobId = j.Id)ApplyCount,
	                j.ViewCount,
	                ep.Logo AS EPLogo,
	                ep.ShortName AS EPName,
	                j.EnterpriseId,
	                ep.Level AS EPLevel,
	                j.WorkTime,
	                j.OfficeRequire,
	                j.WorkContent,	
	                hm.Name AS EPHiringManagerName,
	                hm.HeadPicUrl AS EPHiringHeadImg,
	                hm.Phone AS EPHiringPhone,
                    (SELECT COUNT(1) FROM dbo.T_CV cv WHERE cv.IsDel = 0 AND cv.Type = j.Type AND cv.Completion >= 80  AND cv.UserId = @userId)CVCount
                FROM
	                dbo.T_Job j
	                LEFT JOIN dbo.T_PayWay pw ON j.PayWayId = pw.Id
	                LEFT JOIN dbo.T_JobCategory ca ON j.JobCategoryId = ca.Id
	                LEFT JOIN dbo.T_Enterprise ep ON j.EnterpriseId = ep.Id
	                LEFT JOIN dbo.T_EPHiringManager hm ON j.EPHiringManagerId = hm.Id
                WHERE
	                j.IsDel = 0 AND pw.IsDel = 0
	                AND ca.IsDel = 0 AND ep.IsDel = 0 
	                AND hm.IsDel = 0 AND j.Id = @jobId";

            return DbPartJob.FirstOrDefault<GetPartJobModel>(sql, new { jobId, userId });
        }

        /// <summary>
        /// 获取该岗位的工作地点列表
        /// </summary>
        public List<T_EPAddress> GetJobAdderssList(int jobId)
        {
            var sql = @";
SELECT 
	ea.*
FROM
	dbo.T_JobAddress ja 
	LEFT JOIN dbo.T_EPAddress ea ON ja.EPAddressId = ea.Id
WHERE
	ja.IsDel = 0 AND ea.IsDel = 0 
	AND ja.JobId = @jobId";

            return DbPartJob.Fetch<T_EPAddress>(sql, new { jobId });
        }

        /// <summary>
        /// 获取该用户可以投递的兼职简历列表
        /// </summary>
        public List<GetUserPostPartCVListModel> GetUserPostPartCVList(int userId)
        {
            var sql = @";
                SELECT  TOP 5
	                cv.Id AS CVId,
	                cv.SkillSummary,
	                u.HeadImg
                FROM
	                dbo.T_CV cv
	                LEFT JOIN dbo.T_User u ON cv.UserId = u.Id
                WHERE
	                cv.IsDel = 0 AND u.IsDel = 0 AND cv.Type = 0
	                AND cv.UserId = @userId AND cv.Completion >= 80
                ";
            return DbPartJob.Fetch<GetUserPostPartCVListModel>(sql, new { userId });
        }

        /// <summary>
        /// 用户投递简历到某个岗位
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="cvId">简历id</param>
        /// <param name="jobId">岗位id</param>
        public int UserPostCV(int userId, int cvId, int jobId)
        {
            var sql = @";
IF NOT EXISTS (SELECT 1 FROM dbo.T_CVDelivery cd WHERE cd.IsDel = 0 AND cd.UserId = @userId  AND cd.CvId = @cvId AND cd.JobId = @jobId)
	BEGIN
	    INSERT
        INTO
        dbo.T_CVDelivery
                ( UserId ,
                  CvId ,
                  JobId ,
                  EnterpriseId ,
                  IsDel ,
                  EPIsDel ,
                  ModifyUserId ,
                  ModifyTime ,
                  CreateUserId ,
                  CreateTime
                )
        VALUES  ( @userId , -- UserId - int
                  @cvId , -- CvId - int
                  @jobId , -- JobId - int
                  (SELECT j.EnterpriseId FROM dbo.T_Job j WHERE j.IsDel = 0 AND j.Id = @jobId) , -- EnterpriseId - int
                  0 , -- IsDel - bit
                  0 , -- EPIsDel - bit
                  0 , -- ModifyUserId - int
                  GETDATE() , -- ModifyTime - datetime
                  0 , -- CreateUserId - int
                  GETDATE()  -- CreateTime - datetime
                )
	END
";
            return DbPartJob.Execute(sql, new { userId, cvId, jobId });
        }

        /// <summary>
        /// 获取全职岗位详情
        /// </summary>
        public GetFullJobModel GetFullJob(int jobId, int userId)
        {
            var sql = @";
                SELECT
	                j.Id AS JobId,
	                j.Name AS JobName,
	                j.SalaryLower,
	                j.SalaryUpper,
	                ca.Name AS JobCategoryName,
	                (SELECT COUNT(1) FROM dbo.T_CVDelivery cd WHERE cd.IsDel = 0 AND cd.JobId = j.Id)ApplyCount,
	                j.ViewCount,
	                ep.Logo AS EPLogo,
	                ep.ShortName AS EPName,
	                j.EnterpriseId,
	                ep.Level AS EPLevel,
	                j.WorkTime,
	                j.OfficeRequire,
	                j.WorkContent,	
	                hm.Name AS EPHiringManagerName,
	                hm.HeadPicUrl AS EPHiringHeadImg,
	                hm.Phone AS EPHiringPhone,
                    ISNULL((SELECT TOP 1 cv.Id FROM dbo.T_CV cv WHERE cv.IsDel = 0 AND cv.Type = j.Type AND cv.Completion >= 80  AND cv.UserId = @userId),0) CVId
                FROM
	                dbo.T_Job j	                
	                LEFT JOIN dbo.T_JobCategory ca ON j.JobCategoryId = ca.Id
	                LEFT JOIN dbo.T_Enterprise ep ON j.EnterpriseId = ep.Id
	                LEFT JOIN dbo.T_EPHiringManager hm ON j.EPHiringManagerId = hm.Id
                WHERE
	                j.IsDel = 0 
	                AND ca.IsDel = 0 AND ep.IsDel = 0 
	                AND hm.IsDel = 0 AND j.Id = @jobId";

            return DbPartJob.FirstOrDefault<GetFullJobModel>(sql, new { jobId, userId });
        }

        /// <summary>
        /// 获取该工作的福利待遇
        /// </summary>
        public List<T_EPWelfare> GetJobWelfareList(int jobId)
        {
            var sql = @";
            SELECT
	            w.*
            FROM
	            dbo.T_JobWelfare jw 
	            LEFT JOIN dbo.T_EPWelfare w ON jw.EPWelfareId = w.Id
            WHERE
	            jw.IsDel = 0 AND w.IsDel = 0 
	            AND jw.JobId = @jobId";

            return DbPartJob.Fetch<T_EPWelfare>(sql, new { jobId });
        }

        /// <summary>
        /// 获取所有的结算方式列表
        /// </summary>
        public List<T_PayWay> GetPayWays()
        {
            var sql = @";SELECT * FROM dbo.T_PayWay WHERE IsDel = 0";

            return DbPartJob.Fetch<T_PayWay>(sql);
        }

        /// <summary>
        /// 获取岗位的预约刷新信息
        /// </summary>
        public GetRefreshInfoModel GetRefreshInfo(int jobId, int epId, string cityId)
        {
            var sql = @";
SELECT
	ev.VIPInfoId,
	ev.PassDate,
	(SELECT TOP 1 jr.StartTime FROM dbo.T_JobRefresh jr WHERE jr.JobId = @jobId AND jr.IsDel = 0)StartTime,
	(SELECT TOP 1 jr.TimeSpan FROM dbo.T_JobRefresh jr WHERE jr.JobId = @jobId AND jr.IsDel = 0)TimeSpan,
	(SELECT TOP 1 jr.RefreshDay FROM dbo.T_JobRefresh jr WHERE jr.JobId = @jobId AND jr.IsDel = 0)RefreshDay,
	(SELECT TOP 1 jr.RefreshCount FROM dbo.T_JobRefresh jr WHERE jr.JobId = @jobId AND jr.IsDel = 0)RefreshCount,
	(SELECT TOP 1 jr.Id FROM dbo.T_JobRefresh jr WHERE jr.JobId = @jobId AND jr.IsDel = 0)RefreshId
FROM
	dbo.T_Enterprise ep
	LEFT JOIN dbo.T_EPVIP ev ON ep.Id = ev.EnterpriseId
WHERE
	ep.IsDel = 0 AND ep.Status = 1
	AND ev.IsDel = 0 AND ev.CityId = @cityId
	AND ep.Id = @epId";

            return DbPartJob.FirstOrDefault<GetRefreshInfoModel>(sql, new { jobId, epId, cityId });

        }

        /// <summary>
        /// 提交刷新信息
        /// </summary>
        public int SubmitRefreshInfo(SubmitRefreshInfoRequest request)
        {
            var startTime = Convert.ToDateTime(request.StartTime);
            var endTime = startTime.AddDays(request.RefreshDay);
            var sql = @";
            IF EXISTS (SELECT 1 FROM dbo.T_JobRefresh WHERE JobId = @JobId AND IsDel = 0)
            BEGIN
               UPDATE
	                    dbo.T_JobRefresh
                    SET
	                    StartTime =@startTime,
	                    TimeSpan=@TimeSpan,
	                    RefreshDay=@RefreshDay,
	                    RefreshCount = @RefreshCount
                    WHERE
	                    JobId = @JobId AND IsDel = 0         
            END
                ELSE
	                BEGIN
                        INSERT
                        INTO
                        dbo.T_JobRefresh
                                ( 
                                  TimeSpan ,
                                  StartTime ,
                                  JobId,
                                  RefreshDay ,RefreshCount,
                                  EndTime ,
                                  IsDel ,
                                  ModifyUserId ,
                                  ModifyTime ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( 
                                  @TimeSpan , -- TimeSpan - int
                                  @startTime ,
                                  @JobId,
                                  @RefreshDay ,@RefreshCount,
                                  @endTime , -- EndTime - smalldatetime
                                  0 , -- IsDel - bit
                                  0 , -- ModifyUserId - int
                                  GETDATE() , -- ModifyTime - datetime
                                  0 , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )
	            END
";
            DbPartJob.Execute(sql, new
            {
                endTime,
                startTime,
                request.JobId,
                request.RefreshDay,
                request.RefreshCount,
                request.TimeSpan
            });
            var qsql = @";SELECT TOP 1 Id FROM dbo.T_JobRefresh WHERE JobId = @JobId AND IsDel = 0";

            return DbPartJob.ExecuteScalar<int>(qsql, new { request.JobId });
        }

        /// <summary>
        /// 新增兼职岗位
        /// </summary>
        public int SubmitPartJob(SubmitPartJobRequest request, RedisModel redisModel, string provinceId)
        {

            if (request.JobId > 0) //更新岗位信息
            {
                var updateSql = @";
                    UPDATE
	                    dbo.T_Job
                    SET
	                    Name =@Name,
	                    JobCategoryId = @JobCategoryId,
	                    PayWayId = @PayWayId,
	                    SalaryLower = @SalaryLower,
                        SalaryUpper=@SalaryUpper ,
	                    WorkTime = @WorkTime,
                        WorkContent = @WorkContent,
                        OfficeRequire  = @OfficeRequire,
	                    EPHiringManagerId = @EPHiringManagerId ,
                        RefreshWay  = @RefreshWay
                    WHERE
	                    Id = @JobId";
                DbPartJob.Execute(updateSql, new
                {
                    request.Name,
                    request.PayWayId,
                    request.SalaryLower,
                    request.SalaryUpper,
                    request.WorkTime,
                    request.WorkContent,
                    request.OfficeRequire,
                    request.EPHiringManagerId,
                    request.RefreshWay,
                    request.JobCategoryId,
                    request.JobId
                });
            }
            else  //插入岗位信息
            {
                var sql = @";
                INSERT
                INTO
                dbo.T_Job
                        ( EnterpriseId ,
                          Type ,
                          Name ,
                          JobCategoryId ,
                          EducationId ,
                          PayWayId ,
                          SalaryLower ,
                          SalaryUpper ,
                          IsPractice ,
                          WorkTime ,
                          WorkContent ,
                          OfficeRequire ,
                          ProvinceId ,
                          CityId ,
                          AreaId ,
                          EPHiringManagerId ,
                          RefreshWay ,
                          RefreshTime ,
                          Status ,
                          ViewCount ,
                          IsRecommand ,
                          IsDel ,
                          ModifyUserId ,
                          ModifyTime ,
                          CreateUserId ,
                          CreateTime
                        )
                VALUES  ( @EPId , -- EnterpriseId - int
                          0 , -- Type - tinyint
                          @Name , -- Name - nvarchar(50)
                          @JobCategoryId , -- JobCategoryId - int
                          0 , -- EducationId - int
                          @PayWayId , -- PayWayId - int
                          @SalaryLower , -- SalaryLower - int
                          @SalaryUpper , -- SalaryUpper - int
                          0 , -- IsPractice - bit
                          @WorkTime , -- WorkTime - nvarchar(200)
                          @WorkContent , -- WorkContent - nvarchar(2000)
                          @OfficeRequire , -- OfficeRequire - nvarchar(2000)
                          @provinceId , -- ProvinceId - varchar(6)
                          @CityId , -- CityId - varchar(6)
                          '' , -- AreaId - varchar(6)
                          @EPHiringManagerId , -- EPHiringManagerId - int
                          @RefreshWay , -- RefreshWay - tinyint
                          GETDATE() , -- RefreshTime - datetime
                          0 , -- Status - tinyint
                          0 , -- ViewCount - int
                          0 , -- IsRecommand - bit
                          0 , -- IsDel - bit
                          @UserId , -- ModifyUserId - int
                          GETDATE() , -- ModifyTime - datetime
                          @UserId , -- CreateUserId - int
                          GETDATE()  -- CreateTime - datetime
                        )
	                SELECT @@@IDENTITY";
                var jobId = DbPartJob.ExecuteScalar<int>(sql, new
                {
                    redisModel.EPId,
                    redisModel.UserId,
                    request.Name,
                    request.PayWayId,
                    request.SalaryLower,
                    request.SalaryUpper,
                    request.WorkTime,
                    request.WorkContent,
                    request.OfficeRequire,
                    provinceId,
                    redisModel.CityId,
                    request.EPHiringManagerId,
                    request.RefreshWay,
                    request.JobCategoryId
                });
                sql = @";UPDATE dbo.T_JobRefresh SET JobId = @jobId WHERE Id = @RefreshId";
                DbPartJob.Execute(sql, new {jobId, request.RefreshId});
                request.JobId = jobId;
            }
            var delSql = @";UPDATE dbo.T_JobAddress SET IsDel = 1 WHERE JobId = @JobId";
            DbPartJob.Execute(delSql, new {request.JobId});//删除原来的工作地点，插入新的工作地点
            foreach (var addrId in request.AddressList)
            {
                var insertSql = @";
                    INSERT
                    INTO
                    dbo.T_JobAddress
                            ( JobId ,
                              EPAddressId ,
                              IsDel ,
                              ModifyUserId ,
                              ModifyTime ,
                              CreateUserId ,
                              CreateTime
                            )
                    VALUES  ( @JobId , -- JobId - int
                              @addrId , -- EPAddressId - int
                              0 , -- IsDel - bit
                              0 , -- ModifyUserId - int
                              GETDATE() , -- ModifyTime - datetime
                              0 , -- CreateUserId - int
                              GETDATE()  -- CreateTime - datetime
                            )";
                DbPartJob.Execute(insertSql, new {request.JobId, addrId});
            }
            return 1;
        }

        /// <summary>
        /// 新增全职岗位
        /// </summary>
        public int SubmitFullJob(SubmitFullJobRequest request, RedisModel redisModel, string provinceId)
        {

            if (request.JobId > 0) //更新岗位信息
            {
                var updateSql = @";
                    UPDATE
	                    dbo.T_Job
                    SET
	                    Name =@Name,
	                    JobCategoryId = @JobCategoryId,
	                    EducationId = @EducationId,
	                    SalaryLower = @SalaryLower,
                        SalaryUpper=@SalaryUpper ,IsPractice=@IsPractice,
	                    WorkTime = @WorkTime,
                        WorkContent = @WorkContent,
                        OfficeRequire  = @OfficeRequire,
	                    EPHiringManagerId = @EPHiringManagerId ,
                        RefreshWay  = @RefreshWay
                    WHERE
	                    Id = @JobId";
                DbPartJob.Execute(updateSql, new
                {
                    request.Name,
                    request.EducationId,
                    request.SalaryLower,
                    request.SalaryUpper,
                    request.IsPractice,
                    request.WorkTime,
                    request.WorkContent,
                    request.OfficeRequire,
                    request.EPHiringManagerId,
                    request.RefreshWay,
                    request.JobCategoryId,
                    request.JobId
                });
            }
            else  //插入岗位信息
            {
                var sql = @";
                INSERT
                INTO
                dbo.T_Job
                        ( EnterpriseId ,
                          Type ,
                          Name ,
                          JobCategoryId ,
                          EducationId ,
                          PayWayId ,
                          SalaryLower ,
                          SalaryUpper ,
                          IsPractice ,
                          WorkTime ,
                          WorkContent ,
                          OfficeRequire ,
                          ProvinceId ,
                          CityId ,
                          AreaId ,
                          EPHiringManagerId ,
                          RefreshWay ,
                          RefreshTime ,
                          Status ,
                          ViewCount ,
                          IsRecommand ,
                          IsDel ,
                          ModifyUserId ,
                          ModifyTime ,
                          CreateUserId ,
                          CreateTime
                        )
                VALUES  ( @EPId , -- EnterpriseId - int
                          1 , -- Type - tinyint
                          @Name , -- Name - nvarchar(50)
                          @JobCategoryId , -- JobCategoryId - int
                          @EducationId , -- EducationId - int
                          0 , -- PayWayId - int
                          @SalaryLower , -- SalaryLower - int
                          @SalaryUpper , -- SalaryUpper - int
                          @IsPractice , -- IsPractice - bit
                          @WorkTime , -- WorkTime - nvarchar(200)
                          @WorkContent , -- WorkContent - nvarchar(2000)
                          @OfficeRequire , -- OfficeRequire - nvarchar(2000)
                          @provinceId , -- ProvinceId - varchar(6)
                          @CityId , -- CityId - varchar(6)
                          '' , -- AreaId - varchar(6)
                          @EPHiringManagerId , -- EPHiringManagerId - int
                          @RefreshWay , -- RefreshWay - tinyint
                          GETDATE() , -- RefreshTime - datetime
                          0 , -- Status - tinyint
                          0 , -- ViewCount - int
                          0 , -- IsRecommand - bit
                          0 , -- IsDel - bit
                          @UserId , -- ModifyUserId - int
                          GETDATE() , -- ModifyTime - datetime
                          @UserId , -- CreateUserId - int
                          GETDATE()  -- CreateTime - datetime
                        )
	                SELECT @@@IDENTITY";
                var jobId = DbPartJob.ExecuteScalar<int>(sql, new
                {
                    redisModel.EPId,
                    redisModel.UserId,
                    request.Name,
                    request.EducationId,
                    request.SalaryLower,
                    request.SalaryUpper,
                    request.IsPractice,
                    request.WorkTime,
                    request.WorkContent,
                    request.OfficeRequire,
                    provinceId,
                    redisModel.CityId,
                    request.EPHiringManagerId,
                    request.RefreshWay,
                    request.JobCategoryId
                });
                sql = @";UPDATE dbo.T_JobRefresh SET JobId = @jobId WHERE Id = @RefreshId";
                DbPartJob.Execute(sql, new { jobId, request.RefreshId });
                request.JobId = jobId;
            }
            var delSql = @";UPDATE dbo.T_JobAddress SET IsDel = 1 WHERE JobId = @JobId";
            DbPartJob.Execute(delSql, new { request.JobId });//删除原来的工作地点，插入新的工作地点
            foreach (var addrId in request.AddressList)
            {
                var insertSql = @";
                    INSERT
                    INTO
                    dbo.T_JobAddress
                            ( JobId ,
                              EPAddressId ,
                              IsDel ,
                              ModifyUserId ,
                              ModifyTime ,
                              CreateUserId ,
                              CreateTime
                            )
                    VALUES  ( @JobId , -- JobId - int
                              @addrId , -- EPAddressId - int
                              0 , -- IsDel - bit
                              0 , -- ModifyUserId - int
                              GETDATE() , -- ModifyTime - datetime
                              0 , -- CreateUserId - int
                              GETDATE()  -- CreateTime - datetime
                            )";
                DbPartJob.Execute(insertSql, new { request.JobId, addrId });
            }

            foreach (var welfareId in request.WelFareList)
            {
                var welfareSql = @";
                                INSERT
                                INTO
                                dbo.T_JobWelfare
                                        ( EPWelfareId ,
                                          JobId ,
                                          IsDel ,
                                          ModifyUserId ,
                                          ModifyTime ,
                                          CreateUserId ,
                                          CreateTime
                                        )
                                VALUES  ( @welfareId , -- EPWelfareId - int
                                          @JobId , -- JobId - int
                                          0 , -- IsDel - bit
                                          0 , -- ModifyUserId - int
                                          GETDATE() , -- ModifyTime - datetime
                                          0 , -- CreateUserId - int
                                          GETDATE()  -- CreateTime - datetime
                                        )";
                DbPartJob.Execute(welfareSql, new {welfareId, request.JobId});
            }
            return 1;
        }
    }
}
