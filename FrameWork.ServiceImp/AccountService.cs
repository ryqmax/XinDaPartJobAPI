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

using FrameWork.Common;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.Account;
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
        public T_User GetUserInfo(GetUserInfoRequest request)
        {
            var insertSql = @"
                IF NOT EXISTS (SELECT 1 FROM dbo.T_User WHERE WxAccount = @WxAccount)
	                BEGIN
		                INSERT
		                INTO
		                dbo.T_User
		                        ( WxAccount ,
		                          WxName ,
		                          Phone ,
		                          TotalIntegral ,
		                          RealName ,
		                          Sex ,
		                          Birthday ,
		                          DicRegionId ,
		                          OriginalProvinceId ,
		                          OriginalCityId ,
                                  HeadImg,
		                          IsDel ,
		                          ModifyUserId ,
		                          ModifyTime ,
		                          CreateUserId ,
		                          CreateTime
		                        )
		                VALUES  ( @WxAccount , -- WxAccount - nvarchar(50)
		                          @WxName , -- WxName - nvarchar(50)
		                          N'' , -- Phone - nvarchar(15)
		                          0 , -- TotalIntegral - int
		                          N'' , -- RealName - nvarchar(50)
		                          0 , -- Sex - tinyint
		                          N'' , -- Birthday - nvarchar(20)
		                          '' , -- DicRegionId - varchar(6)
		                          '' , -- OriginalProvinceId - varchar(6)
		                          '' , 
                                  @HeadImg,
		                          0 , -- IsDel - bit
		                          0 , -- ModifyUserId - int
		                          GETDATE() , -- ModifyTime - datetime
		                          0 , -- CreateUserId - int
		                          GETDATE()  -- CreateTime - datetime
		                        )
	                END
                ";
            DbPartJob.Execute(insertSql,new { WxAccount = request.OpenId, WxName=request.UserName,request.HeadImg});
            var sql = @"
                    SELECT
	                    *
                    FROM
	                    T_User
                    WHERE
	                    WxAccount = @WxAccount 
	                    AND IsDel = 0 ";
            return DbPartJob.FirstOrDefault<T_User>(sql,new { WxAccount = request.OpenId });
        }

    }
}
