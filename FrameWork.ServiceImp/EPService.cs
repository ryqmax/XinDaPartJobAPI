/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPService.cs
 *      Description:
 *            EPService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 08:27:01
 *      History:
 ***********************************************************************************/


using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.EP;
using FrameWork.Entity.ViewModel.EP;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// EPService
    /// </summary>
    public class EPService : BaseService<T_Enterprise>, IEPService
    {
        /// <summary>
        /// 获取招聘联系人列表
        /// </summary>
        public List<T_EPHiringManager> GetEpContacts(int epId)
        {
            var sql = @";SELECT * FROM dbo.T_EPHiringManager WHERE EnterpriseId = @epId AND IsDel = 0";
            return DbPartJob.Fetch<T_EPHiringManager>(sql, new { epId });
        }

        /// <summary>
        /// 删除机构下的招聘联系人
        /// </summary>
        /// <param name="epContactsId">招聘联系人id</param>
        public void DelEPContacts(int epContactsId)
        {
            var sql = @";UPDATE dbo.T_EPHiringManager SET IsDel = 1 WHERE Id = @epContactsId";

            DbPartJob.Execute(sql, new { epContactsId });
        }

        /// <summary>
        /// 保存企业招聘联系人
        /// </summary>
        public void SaveEPContacts(SaveEPContactsRequest request, int epId)
        {
            var sql = @";
IF EXISTS (SELECT * FROM dbo.T_EPAccount WHERE Phone = @Phone AND IsDel = 0)
	BEGIN
	    UPDATE
		dbo.T_EPHiringManager
		SET
			HeadPicUrl = @HeadImg,
			Name = @ContactsName
		WHERE
			Phone = @Phone AND IsDel = 0
	END
ELSE
	BEGIN
	    INSERT
		INTO
        dbo.T_EPHiringManager
                ( EnterpriseId ,
                  Name ,
                  Phone ,
                  HeadPicUrl ,
                  AuthStatus ,
                  IsDel ,
                  ModifyUserId ,
                  ModifyTime ,
                  CreateUserId ,
                  CreateTime
                )
        VALUES  ( @epId , -- EnterpriseId - int
                  @ContactsName , -- Name - nvarchar(50)
                  @Phone , -- Phone - nvarchar(15)
                  @HeadImg , -- HeadPicUrl - nvarchar(255)
                  0 , -- AuthStatus - tinyint
                  0 , -- IsDel - bit
                  0 , -- ModifyUserId - int
                  GETDATE() , -- ModifyTime - datetime
                  0 , -- CreateUserId - int
                  GETDATE()  -- CreateTime - datetime
                )
	END";

            DbPartJob.Execute(sql, new { request.Phone, request.ContactsName, request.HeadImg, epId });
        }

        /// <summary>
        /// 获取联系人详情
        /// </summary>
        public T_EPHiringManager GetEPContactsDetails(int epContactsId)
        {
            var sql = @";SELECT * FROM dbo.T_EPHiringManager WHERE Id = @epContactsId AND IsDel = 0";
            return DbPartJob.FirstOrDefault<T_EPHiringManager>(sql, new { epContactsId });
        }

        /// <summary>
        /// 获取子账号列表
        /// </summary>
        public List<GetAccountListModel> GetAccountList(int epId, string cityId)
        {
            var sql = @";
SELECT
	ep.Logo,
	epa.Id AS AccountId,
	epa.Phone,
	epa.Type AS AccountType,
	(SELECT TOP 1 v.Name FROM dbo.T_EPVIP ev LEFT JOIN dbo.T_VIPInfo v ON ev.VIPInfoId = v.Id WHERE ev.IsDel = 0 AND v.IsDel = 0 AND ev.EnterpriseId = ep.Id AND ev.CityId = @cityId)VipType,
	(SELECT COUNT(1) FROM dbo.T_EPVIP ev LEFT JOIN dbo.T_VIPInfo v ON ev.VIPInfoId = v.Id WHERE ev.IsDel = 0 AND v.IsDel = 0 AND ev.EnterpriseId = @epId )VipCount
FROM
	dbo.T_Enterprise ep 
	LEFT JOIN dbo.T_EPAccount epa ON ep.Id = epa.EnterpriseId
WHERE
	ep.IsDel = 0 AND epa.IsDel = 0
	AND ep.Id = @epId
";
            return DbPartJob.Fetch<GetAccountListModel>(sql, new { epId, cityId });
        }

        /// <summary>
        /// 更新或新增该企业子账号，或者修改主账号手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="epId">企业id</param>
        /// <param name="subAccoundId">账号id</param>
        public int AddOrEditAccount(string phone, int epId, int subAccoundId)
        {
            var checkSql = @";SELECT count(1) FROM dbo.T_EPAccount WHERE Phone = @phone AND IsDel = 0 AND id != @subAccoundId";
            var count = DbPartJob.ExecuteScalar<int>(checkSql, new { phone, subAccoundId });
            if (count > 0)
                return -1;
            var sql = @";
IF EXISTS (SELECT 1 FROM dbo.T_EPAccount WHERE id = @subAccoundId AND IsDel = 0)
	BEGIN
	    UPDATE dbo.T_EPAccount SET Phone = @phone ,ModifyTime = GETDATE() WHERE id = @subAccoundId AND IsDel = 0
	END
ELSE
	BEGIN
	    INSERT
        INTO
        dbo.T_EPAccount
                ( EnterpriseId ,
                  Phone ,
                  PermissionIds ,
                  Type ,
                  Status ,
                  Note ,
                  IsDel ,
                  ModifyUserId ,
                  ModifyTime ,
                  CreateUserId ,
                  CreateTime
                )
        VALUES  ( @epId , -- EnterpriseId - int
                  @phone , -- Phone - nvarchar(15)
                  N'/1/2/3/4/5/6/7/8/9/' , -- PermissionIds - nvarchar(200)
                  2 , -- Type - tinyint
                  1 , -- Status - tinyint
                  N'' , -- Note - nvarchar(500)
                  0 , -- IsDel - bit
                  0 , -- ModifyUserId - int
                  GETDATE() , -- ModifyTime - datetime
                  0 , -- CreateUserId - int
                  GETDATE()  -- CreateTime - datetime
                )
	END";
            return DbPartJob.Execute(sql, new { epId, phone, subAccoundId });
        }

        /// <summary>
        /// 删除子账号
        /// </summary>
        public int DelAccount(int subAccoundId)
        {
            var sql = @";UPDATE dbo.T_EPAccount SET IsDel = 1 WHERE Id = @subAccoundId AND IsDel = 0 AND Type = 2";

            return DbPartJob.Execute(sql, new {subAccoundId});
        }

        /// <summary>
        /// 获取账号实体
        /// </summary>
        /// <param name="accountId">账号id</param>
        public T_EPAccount GetAccount(int accountId)
        {
            var sql = @"SELECT * FROM dbo.T_EPAccount WHERE Id = @accountId";
            return DbPartJob.FirstOrDefault<T_EPAccount>(sql,new { accountId });
        }

        /// <summary>
        /// 获取所有的权限
        /// </summary>
        public List<T_AccountPermission> GetAllPermissions()
        {
            var sql = @"where isdel = 0  AND IsUsed = 1";
            return DbPartJob.Fetch<T_AccountPermission>(sql);
        }
    }
}
