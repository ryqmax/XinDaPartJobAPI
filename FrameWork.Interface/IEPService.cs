/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetEPContactsModel.cs
 *      Description:
 *            GetEPContactsModel
 *            企业数据库相关操作
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/20 08:24:36
 *      History:
 ***********************************************************************************/

using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.EP;
using FrameWork.Entity.ViewModel.EP;

namespace FrameWork.Interface
{
    public interface IEPService : IBaseService<T_Enterprise>
    {
        /// <summary>
        /// 获取招聘联系人列表
        /// </summary>
        List<GetEPContactsModel> GetEpContacts(GetEPContactsRequest request);
    }
}
