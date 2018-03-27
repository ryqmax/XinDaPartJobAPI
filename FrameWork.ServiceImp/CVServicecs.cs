using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.CV;
using FrameWork.Entity.ViewModel.Job;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class CVServicecs : BaseService<T_UserShieldCV>, ICVServicecs
    {
        /// <summary>
        /// 用户屏蔽简历
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        public bool UserShieldCV(int userId, int cVId, int shieldDay)
        {
            var sql = @"INSERT dbo.T_UserShieldCV
                                ( UserId ,
                                  CVId ,
                                  TimeSpan ,
                                  EndTime ,
                                  IsDel ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @userId , -- UserId - int
                                  @cVId , -- CVId - int
                                  @shieldDay , -- TimeSpan - int
                                  GETDATE() , -- EndTime - date
                                  0 , -- IsDel - bit
                                  @userId , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )";
            return DbPartJob.Execute(sql,new{userId,cVId,shieldDay})>0;
        }

        /// <summary>
        /// 企业屏蔽简历
        /// </summary>
        /// <param name="epId">企业Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        public bool EnterpriseShieldCV(int epId, int cVId, int shieldDay)
        {
            var sql = @"INSERT dbo.T_EPShieldCV
                                ( EnterpriseId ,
                                  CVId ,
                                  TimeSpan ,
                                  EndTime ,
                                  IsDel ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @epId , -- EnterpriseId - int
                                  @cVId , -- CVId - int
                                  @shieldDay , -- TimeSpan - int
                                  GETDATE() , -- EndTime - date
                                  0 , -- IsDel - bit
                                  @epId , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )";
            return DbPartJob.Execute(sql, new { epId, cVId, shieldDay }) > 0;
        }

        public List<JobInfo> GetCVList(GetCVReq getJobListReq, string cityId, int ePId)
        {
            int startPage = (getJobListReq.PageSize) * (getJobListReq.Page - 1) + 1;
            int endPage = getJobListReq.Page * getJobListReq.PageSize;


            var where = string.Empty;
            var jobAddressWhere = string.Empty;
            if (getJobListReq.RegionId != 0)
            {
                if (getJobListReq.RegionId == -1)
                {
                    where += " AND jobaddress.EPAddressId = @areaid";
                    jobAddressWhere += " AND jobaddress.EPAddressId = @areaid";
                }
                else
                {
                    where += " AND epaddress.AreaId = @areaid";
                    jobAddressWhere += " AND epaddress.AreaId = @areaid";
                }
            }
            if (getJobListReq.EducationId > 0)
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
                                LEFT JOIN dbo.T_EPAddress epaddress ON epaddress.Id = jobaddress.EPAddressId AND epaddress.IsDel = 0
                                LEFT JOIN dbo.DicRegion dicregion ON epaddress.AreaId = dicregion.Id AND dicregion.IsDel = 0   
                                LEFT JOIN dbo.T_PayWay payway ON payway.Id = job.PayWayId
                        WHERE   job.IsDel = 0
                                AND ep.IsDel = 0        
                                AND jobaddress.IsDel = 0   
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
                                ( CASE WHEN ( SELECT TOP 1
                                                        jobaddress.EPAddressId
                                              FROM      dbo.T_JobAddress jobaddress
                                                        LEFT JOIN dbo.T_EPAddress epaddress ON epaddress.Id = jobaddress.EPAddressId AND epaddress.IsDel = 0
                                                        LEFT JOIN dbo.DicRegion dicregion ON epaddress.AreaId = dicregion.Id AND dicregion.IsDel = 0
                                              WHERE     1 = 1
                                                        AND jobaddress.IsDel = 0                                                        
                                                        AND job.Id = jobaddress.JobId
                                                        {jobAddressWhere}
                                            ) = -1 THEN '不限地点'
                                       ELSE ( SELECT TOP 1
                                                        dicregion.Description
                                              FROM      dbo.T_JobAddress jobaddress
                                                        LEFT JOIN dbo.T_EPAddress epaddress ON epaddress.Id = jobaddress.EPAddressId AND epaddress.IsDel = 0
                                                        LEFT JOIN dbo.DicRegion dicregion ON epaddress.AreaId = dicregion.Id AND dicregion.IsDel = 0
                                              WHERE     1 = 1
                                                        AND jobaddress.IsDel = 0                                                        
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
            return DbPartJob.Fetch<JobInfo>(sql, new { type = getJobListReq.Type, areaid = getJobListReq.RegionId, jobcaid = getJobListReq.JobTypeId, level = getJobListReq.EducationId, cityId, startPage, endPage, ePId });
        }
    }
}
