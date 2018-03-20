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
using FrameWork.Entity.Model.Account;
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
            DbPartJob.Execute(insertSql, new { WxAccount = request.OpenId, WxName = request.UserName, request.HeadImg });
            var sql = @"
                    SELECT
	                    *
                    FROM
	                    T_User
                    WHERE
	                    WxAccount = @WxAccount 
	                    AND IsDel = 0 ";
            return DbPartJob.FirstOrDefault<T_User>(sql, new { WxAccount = request.OpenId });
        }

        /// <summary>
        /// 企业登录
        /// </summary>
        public EPLoginModel EpLogin(EPLoginRequest request)
        {
            var sql = @";
                SELECT
	                epa.Type,
	                ep.Status  AS EPStatus,
	                epa.Status AS EPAStatus
                FROM
	                dbo.T_Enterprise ep
	                LEFT JOIN dbo.T_EPAccount epa ON ep.Id = epa.EnterpriseId
                WHERE
	                ep.IsDel = 0 
	                AND epa.IsDel = 0 
	                AND epa.Phone = @Phone";
            return DbPartJob.FirstOrDefault<EPLoginModel>(sql, new { request.Phone });
        }

        /// <summary>
        /// 把未与机构绑定的手机号插入到数据库
        /// </summary>
        public void EPLoginForInsert(EPLoginRequest request)
        {
            var sql = @";
DECLARE @@epid INT
DECLARE @@epaid INT

INSERT
INTO
dbo.T_Enterprise
        ( Name ,
          ShortName ,
          ProvinceId ,
          CityId ,
          AreaId ,
          Address ,
          Lng ,
          Lat ,
          Brief ,
          Logo ,
          AuthPicUrl ,
          CheckStatus ,
          CheckNote ,
          TotalIntegral ,
          Level ,
          Status ,
          IsDel ,
          ModifyUserId ,
          ModifyTime ,
          CreateUserId ,
          CreateTime
        )
VALUES  ( N'' , -- Name - nvarchar(100)
          N'' , -- ShortName - nvarchar(40)
          '' , -- ProvinceId - varchar(6)
          '' , -- CityId - varchar(6)
          '' , -- AreaId - varchar(6)
          N'' , -- Address - nvarchar(60)
          NULL , -- Lng - decimal
          NULL , -- Lat - decimal
          N'' , -- Brief - nvarchar(320)
          N'' , -- Logo - nvarchar(255)
          N'' , -- AuthPicUrl - nvarchar(255)
          0 , -- CheckStatus - tinyint
          N'' , -- CheckNote - nvarchar(300)
          0 , -- TotalIntegral - int
          0 , -- Level - tinyint
          1 , -- Status - bit
          0 , -- IsDel - bit
          0 , -- ModifyUserId - int
          GETDATE() , -- ModifyTime - datetime
          0 , -- CreateUserId - int
          GETDATE()  -- CreateTime - datetime
        )

	SET @@epid = @@@IDENTITY
	SET @@epaid = ISNULL((SELECT Id FROM dbo.T_EPAccount WHERE Phone = @Phone AND IsDel = 0),0)
	IF(@@epaid=0)
		BEGIN
		    INSERT
			INTO
			dbo.T_EPAccount
					( EnterpriseId ,
					  Phone ,
					  PermissionIds ,
					  Type ,
					  Status ,
					  IsDel ,
					  ModifyUserId ,
					  ModifyTime ,
					  CreateUserId ,
					  CreateTime
					)
			VALUES  ( @@epid , -- EnterpriseId - int
					  @Phone, -- Phone - nvarchar(15)
					  NULL , -- PermissionIds - nvarchar(200)
					  1 , -- Type - tinyint
					  1 , -- IsUsed - bit
					  0 , -- IsDel - bit
					  0 , -- ModifyUserId - int
					  GETDATE() , -- ModifyTime - datetime
					  0 , -- CreateUserId - int
					  GETDATE()  -- CreateTime - datetime
					)
			SET @@epaid = @@@IDENTITY
		END
	UPDATE dbo.T_Enterprise SET CreateUserId = @@epaid,ModifyUserId = @@epaid WHERE Id = @@epid";
            DbPartJob.Execute(sql, new { request.Phone });
        }

        /// <summary>
        /// 根据openid获取对应用户的信息
        /// </summary>
        public T_User GetUserByOpenId(string openId)
        {
            var sql = @";
                SELECT
	                *
                FROM
	                dbo.T_User
                WHERE
	                IsDel = 0 AND WxAccount = @openId";
            return DbPartJob.FirstOrDefault<T_User>(sql, new {openId});
        }
    }
}
