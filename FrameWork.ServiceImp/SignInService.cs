/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                SignInService.cs
 *      Description:
 *            SignInService
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
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.SignIn;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// AccountService
    /// </summary>
    public class SignInService : BaseService<T_UserSignLog>, ISignInService
    {
        public List<RecentSignInInfo> GetUserRecentSignInInfo(int userId)
        {
            var date = DateTime.Now.AddDays(-12).Date;
            var sql = @"SELECT [Id]
                          ,[UserId]
                          ,[SignDate]
                          ,[AddValue]
                          ,[TotalIntegral]
                          ,[IsDel]
                          ,[ModifyUserId]
                          ,[ModifyTime]
                          ,[CreateUserId]
                          ,[CreateTime]
                      FROM [TestPartJob].[dbo].[T_UserSignLog]
                      WHERE
	                    IsDel=0
	                    AND SignDate>=@date";
            return DbPartJob.Fetch<RecentSignInInfo>(sql, new {date});
        }

        public List<RecentSignInInfo> GetEnterpriseRecentSignInInfo(int enId)
        {
            var date = DateTime.Now.AddDays(-12).Date;
            var sql = @"SELECT [Id]
                          ,[EnterpriseId]
                          ,[UserId]
                          ,[SignDate]
                          ,[AddValue]
                          ,[TotalIntegral]
                          ,[IsDel]
                          ,[ModifyUserId]
                          ,[ModifyTime]
                          ,[CreateUserId]
                          ,[CreateTime]
                      FROM [TestPartJob].[dbo].[T_EPSignLog]
                      WHERE
	                    IsDel=0
	                    AND SignDate>=@date";
            return DbPartJob.Fetch<RecentSignInInfo>(sql, new { date });
        }
    }
}
