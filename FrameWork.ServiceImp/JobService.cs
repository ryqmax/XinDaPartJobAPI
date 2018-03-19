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
        public List<JobInfo> GetJobList(GetJobListReq getJobListReq)
        {
            int startPage = (getJobListReq.PageSize) * (getJobListReq.Page - 1) + 1;
            int endPage = getJobListReq.Page * getJobListReq.PageSize;
            var date = DateTime.Now.AddDays(-12).Date;
            var sql = @"SELECT  DISTINCT
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
                                AND dicregion.IsUsed = 1
                                AND payway.IsDel = 0
                                AND epaddress.AreaId = 1
                                AND ep.Level = 1
                                AND job.JobCategoryId = 1
		                        AND job.Type=1
		                        AND job.CityId=1;

                        SELECT  *
                        INTO    #JobIdPageTemp
                        FROM    ( SELECT    * ,
					                        COUNT(*) OVER ( ) TotalNum,
                                            ROW_NUMBER() OVER ( ORDER BY RefreshTime DESC ) Num
                                  FROM      #JobIdTemp
                                ) temp
                        WHERE   temp.Num BETWEEN 1 AND 20;

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
                                                        AND dicregion.IsUsed = 1
                                                        AND job.Id = jobaddress.JobId
                                                        AND epaddress.AreaId = 1
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
                                ( CASE WHEN 1 = ep.Id THEN 1
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
            return DbPartJob.Fetch<JobInfo>(sql, new {date, getJobListReq});
        }
    }
}
