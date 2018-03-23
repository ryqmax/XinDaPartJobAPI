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
        public List<JobInfo> GetJobList(GetJobListReq getJobListReq, string cityId)
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
		                        AND job.CityId=@cityId;

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
                                ( CASE WHEN ep.Id = 1 THEN 1
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
            return DbPartJob.Fetch<JobInfo>(sql, new { type = getJobListReq.Type, areaid = getJobListReq.RegionId, jobcaid = getJobListReq.JobTypeId, level = getJobListReq.EmployerRankId, cityId, startPage, endPage });
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
    }
}
