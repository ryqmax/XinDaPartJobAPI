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
            var sql = @";UPDATE dbo.T_EPAccount SET IsDel = 1 WHERE Id = @epContactsId";

            DbPartJob.Execute(sql, new { epContactsId });
        }
    }
}
