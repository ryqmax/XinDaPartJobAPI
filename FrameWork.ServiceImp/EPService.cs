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
            return DbPartJob.FirstOrDefault<T_EPHiringManager>(sql, new {epContactsId});
        }
    }
}
