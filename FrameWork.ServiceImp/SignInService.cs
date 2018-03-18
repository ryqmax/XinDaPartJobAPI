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
using FrameWork.Common;
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
        
        public bool UserSignIn(T_UserSignLog userSignLog)
        {
            return Add(userSignLog).ObjToInt()>0;
        }

        public bool EnterpriseSignIn(T_EPSignLog epSignLog)
        {
            return DbPartJob.Insert(epSignLog).ObjToInt() > 0;
        }

        public bool UpdateUserIntegral(int userId, int addValue, string addReason)
        {
            var sql = @"DECLARE @@currentTotalIntegral INT;
                        UPDATE dbo.T_User SET TotalIntegral=TotalIntegral+@addValue
                        WHERE
                        Id=@userId;

                        SELECT @@currentTotalIntegral=TotalIntegral
                        FROM dbo.T_User
                        WHERE
                         Id=@userId;

                        INSERT INTO dbo.T_UserIntegralLog
                                ( UserId ,
                                  AddValue ,
                                  AddReason ,
                                  TotalIntegral ,
                                  IsDel ,
                                  ModifyUserId ,
                                  ModifyTime ,
                                  CreateUserId ,
                                  CreateTime
                                )
                        VALUES  ( @userId , -- UserId - int
                                  @addValue , -- AddValue - int
                                  @addReason , -- AddReason - nvarchar(50)
                                  @@currentTotalIntegral , -- TotalIntegral - int
                                  0 , -- IsDel - bit
                                  @userId , -- ModifyUserId - int
                                  GETDATE() , -- ModifyTime - datetime
                                  @userId , -- CreateUserId - int
                                  GETDATE()  -- CreateTime - datetime
                                );
                        SELECT  1;";
            var sqlResult = 0;
            using (var scope = DbPartJob.GetTransaction())
            {
                try
                {
                    sqlResult=DbPartJob.ExecuteScalar<int>(sql, new { userId, addValue, addReason });
                    scope.Complete();
                }
                catch (Exception e)
                {
                    scope.Dispose();//出错回滚
                }
            }
            return sqlResult > 0;
        }

        public bool UpdateEnterpriseIntegral(int userId, int addValue, string addReason)
        {
            var sql = @"DECLARE @@currentTotalIntegral INT;
                        UPDATE  dbo.T_Enterprise
                        SET     TotalIntegral = TotalIntegral + @addValue
                        WHERE   Id = @userId;
                        SELECT  1;";
            var sqlResult = 0;
            using (var scope = DbPartJob.GetTransaction())
            {
                try
                {
                    sqlResult = DbPartJob.ExecuteScalar<int>(sql, new { userId, addValue, addReason });
                    scope.Complete();
                }
                catch (Exception e)
                {
                    scope.Dispose();//出错回滚
                }
            }
            return sqlResult > 0;
        }
    }
}
