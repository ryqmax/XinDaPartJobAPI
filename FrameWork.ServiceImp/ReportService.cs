/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                ReportService.cs
 *      Description:
 *            ReportService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/24 21:47:13
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common.Models;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.Report;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// ReportService
    /// </summary>
    public class ReportService : BaseService<T_ReportCV>, IReportService
    {
        /// <summary>
        /// 举报简历接口
        /// </summary>
        public int ReportCV(ReportCVRequest request, RedisModel redisModel)
        {
            var userType = 1;
            if (redisModel.Mark == TokenMarkEnum.Enterprise)
                userType = 2;

            var sql = @";
INSERT
INTO
dbo.T_ReportCV
        ( UserType ,
          UserId ,
          EnterpriseId ,
          CVId ,
          SkillDesc ,
          JobCategoryIds ,
          JobCategoryNames ,
          ReportReasonId ,
          ReportReason ,
          Note ,
          ExposedUserId ,
          ExposedUserName ,
          Reply ,
          Status ,
          IsDel ,
          ModifyUserId ,
          ModifyTime ,
          CreateUserId ,
          CreateTime
        )
VALUES  ( @userType , -- UserType - tinyint
          @UserId , -- UserId - int
          @EPId , -- EnterpriseId - int
          @CVId , -- CVId - int
          @SkillDesc , -- SkillDesc - nvarchar(500)
          @jobCategoryIds , -- JobCategoryIds - varchar(100)
          @jobCategoryNames , -- JobCategoryNames - nvarchar(200)
          @reasonIds , -- ReportReasonId - nvarchar(300)
          @reasons , -- ReportReason - nvarchar(300)
          N'' , -- Note - nvarchar(500)
          (SELECT cv.UserId FROM dbo.T_CV cv WHERE cv.Id = @CVId) , -- ExposedUserId - int
          @UserName , -- ExposedUserName - nvarchar(50)
          @Note , -- Reply - nvarchar(500)
          0 , -- Status - tinyint
          0 , -- IsDel - bit
          0 , -- ModifyUserId - int
          GETDATE() , -- ModifyTime - datetime
          0 , -- CreateUserId - int
          GETDATE()  -- CreateTime - datetime
        )
	SELECT @@@IDENTITY
";
            var jobCategoryIds = $"/{string.Join("/", request.JobCategoryIds)}/";
            var jobCategoryNames = $"/{string.Join("/", request.JobCategoryNames)}/";
            var reasonIds = $"/{string.Join("/", request.ReasonIds)}/";
            var reasons = $"/{string.Join("/", request.Reasons)}/";
            var id = DbPartJob.ExecuteScalar<int>(sql, new
            {
                userType,
                redisModel.UserId,
                redisModel.EPId,
                request.CVId,
                request.SkillDesc,
                jobCategoryIds,
                jobCategoryNames,
                reasonIds,
                reasons,
                request.UserName,
                request.Note
            });
            foreach (var img in request.NoteImgUrl)
            {
                var imgSql = @";
                        INSERT
                        INTO
                        dbo.T_ReportCVImg
                                ( ReportCVId ,
                                  PicUrl ,
                                  IsDel ,
                                  ModifyUserId ,
                                  ModifyTime ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @id , -- ReportCVId - int
                                  @img , -- PicUrl - nvarchar(255)
                                  0 , -- IsDel - bit
                                  0 , -- ModifyUserId - int
                                  GETDATE() , -- ModifyTime - datetime
                                  0 , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                )";
                DbPartJob.Execute(imgSql, new { id, img });
            }
            return id;
        }
    }
}
