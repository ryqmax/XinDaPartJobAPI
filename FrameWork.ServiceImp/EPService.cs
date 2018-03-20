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
        public List<GetEPContactsModel> GetEpContacts(GetEPContactsRequest request)
        {
            var sql = @"";
            return DbPartJob.Fetch<GetEPContactsModel>(sql);
        }
    }
}
