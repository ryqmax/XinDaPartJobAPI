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

        public List<CVInfo> GetCVList(GetCVReq getCvReq)
        {
            int startPage = (getCvReq.PageSize) * (getCvReq.Page - 1) + 1;
            int endPage = getCvReq.Page * getCvReq.PageSize;


            var where = string.Empty;
            var order = "RefreshTime";
            var cvAdrressWhere = string.Empty;
            var cvSexWhere = string.Empty;
            if (getCvReq.RegionId != 0)
            {
                if (getCvReq.RegionId == -1)
                {
                    where += " AND cvregion.DicRegionId = @areaid";
                    cvAdrressWhere += " AND cvregion.DicRegionId = @areaid";
                }
                else
                {
                    where += " AND cvregion.DicRegionId= @areaid";
                    cvAdrressWhere += " AND cvregion.DicRegionId= @areaid";
                }
            }
            if (getCvReq.EducationId > 0)
            {
                where += " AND cveduinfo.DicEducationId = @eduid";
            }
            if (getCvReq.JobTypeId > 0)
            {
                where += " AND cvcategory.JobCategoryId    = @jobcaid";
            }

            if (getCvReq.Type == 2)
            {
                if (getCvReq.Sort == 1)
                {
                    order = "UpCount";
                }
            }
            else
            {
                if (getCvReq.JobSex > 0)
                {
                    cvSexWhere = " AND tuser.Sex=@sex ";
                }
            }



            var sql = $@"SELECT  DISTINCT
                                cv.Id CVId ,
                                cv.RefreshTime,
								cv.UpCount 
								INTO #CVIdTemp                       
                        FROM    dbo.T_CV cv
                                LEFT JOIN dbo.T_CVRegion cvregion ON cvregion.CVId = cv.Id                               
                                LEFT JOIN dbo.DicRegion dicregion ON cvregion.DicRegionId = dicregion.Id AND dicregion.IsDel = 0
                                LEFT JOIN dbo.T_CVEduInfo cveduinfo ON cv.Id = cveduinfo.CVId
								LEFT JOIN dbo.DicEducation diceducation ON diceducation.Id = cveduinfo.DicEducationId
								LEFT JOIN dbo.DicGrade dicgrade ON dicgrade.Id = cveduinfo.DicGradeId AND dicgrade.IsDel = 0 
								LEFT JOIN dbo.T_CVCategory cvcategory ON cvcategory.CVId = cv.Id AND cvcategory.IsDel=0
								LEFT JOIN dbo.T_JobCategory jobcategory ON cvcategory.JobCategoryId = jobcategory.Id AND jobcategory.IsDel=0
                        WHERE 1=1   
								AND  cv.IsDel = 0						
                                AND cvregion.IsDel = 0 
                                AND cveduinfo.IsDel = 0
                                AND diceducation.IsDel = 0
                                {where}
                                {cvSexWhere}
		                        AND cv.Type=@type

                        SELECT  *
                        INTO    #CVIdPageTemp
                        FROM    ( SELECT    * ,
					                        COUNT(*) OVER ( ) TotalNum,
                                            ROW_NUMBER() OVER ( ORDER BY {order} DESC ) Num
                                  FROM      #CVIdTemp
                                ) temp
                        WHERE   temp.Num BETWEEN @startPage AND @endPage;

                        SELECT  cv.Id CVId,
                                tuser.HeadImg CVImg ,
                                tuser.RealName CVName ,
                                tuser.Sex CVSex ,
                                cv.SkillSummary CVWord ,
                               ( CASE WHEN ( SELECT TOP 1
                                                        cvregion.DicRegionId
                                              FROM      dbo.T_CVRegion cvregion
                                                        LEFT JOIN dbo.DicRegion dicregion ON cvregion.DicRegionId = dicregion.Id AND dicregion.IsDel = 0
                                              WHERE     1 = 1
                                                        AND cvregion.IsDel = 0                                                        
                                                        AND cvregion.CVId = cv.Id
                                                        {cvAdrressWhere}
                                            ) = -1 THEN '不限地点'
                                       ELSE ( SELECT TOP 1
                                                        dicregion.Description
                                              FROM      dbo.T_CVRegion cvregion
                                                        LEFT JOIN dbo.DicRegion dicregion ON cvregion.DicRegionId = dicregion.Id AND dicregion.IsDel = 0                                                        
                                              WHERE     1 = 1
                                                        AND cvregion.IsDel = 0
                                                        AND cvregion.CVId = cv.Id
                                                        {cvAdrressWhere}
                                            )
                                  END ) CVPosition,
                                cv.WorkTime CVTime,
                                (SELECT TOP 1
                                            diceducation.Name
                                  FROM      dbo.T_CVEduInfo cveduinfo 
											LEFT JOIN dbo.DicEducation diceducation ON diceducation.Id = cveduinfo.DicEducationId											
                                  WHERE     1=1
                                            AND cveduinfo.IsDel = 0
                                            AND diceducation.IsDel = 0
											AND cveduinfo.CVId = cv.Id                                  
								)CVSchool,
								(SELECT TOP 1
										jobcategory.Name 
									FROM dbo.T_CVCategory cvcategory 
										LEFT JOIN dbo.T_JobCategory jobcategory ON cvcategory.JobCategoryId = jobcategory.Id AND jobcategory.IsDel=0
									WHERE 1=1
										AND  cvcategory.CVId = cv.Id AND cvcategory.IsDel=0
								) CVJob,
								cv.UpCount RecommendNum,
                                cv.IsPractice IsPractice ,                                
		                        #CVIdPageTemp.TotalNum
                        FROM    dbo.T_CV cv
								LEFT JOIN dbo.T_User tuser ON cv.UserId = tuser.Id
                                INNER JOIN #CVIdPageTemp ON #CVIdPageTemp.CVId = cv.Id;

                        DROP TABLE #CVIdTemp;
                        DROP TABLE #CVIdPageTemp;";
            return DbPartJob.Fetch<CVInfo>(sql, new { type = getCvReq.Type, areaid = getCvReq.RegionId, jobcaid = getCvReq.JobTypeId, eduid = getCvReq.EducationId, cityId, startPage, endPage, ePId,sex=getCvReq.JobSex });
        }
    }
}
