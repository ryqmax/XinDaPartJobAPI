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
    public class ReportService:BaseService<T_ReportCV>,IReportService
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
          UserName ,
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
          N'' , -- UserName - nvarchar(50)
          0 , -- EnterpriseId - int
          0 , -- CVId - int
          N'' , -- SkillDesc - nvarchar(500)
          '' , -- JobCategoryIds - varchar(100)
          N'' , -- JobCategoryNames - nvarchar(200)
          N'' , -- ReportReasonId - nvarchar(300)
          N'' , -- ReportReason - nvarchar(300)
          N'' , -- Note - nvarchar(500)
          (SELECT cv.UserId FROM dbo.T_CV cv WHERE cv.Id = @cvId) , -- ExposedUserId - int
          (SELECT TOP 1 u.RealName FROM dbo.T_CV cv LEFT JOIN dbo.T_User u ON cv.UserId = u.Id WHERE cv.Id = @cvId) , -- ExposedUserName - nvarchar(50)
          N'' , -- Reply - nvarchar(500)
          0 , -- Status - tinyint
          NULL , -- IsDel - bit
          0 , -- ModifyUserId - int
          GETDATE() , -- ModifyTime - datetime
          0 , -- CreateUserId - int
          GETDATE()  -- CreateTime - datetime
        )";

            return 1;
        }
    }
}
