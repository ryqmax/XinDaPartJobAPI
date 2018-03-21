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
        List<T_EPHiringManager> GetEpContacts(int epId);

        /// <summary>
        /// 删除机构下的招聘联系人
        /// </summary>
        /// <param name="epContactsId">招聘联系人id</param>
        void DelEPContacts(int epContactsId);

        /// <summary>
        /// 保存企业招聘联系人
        /// </summary>
        void SaveEPContacts(SaveEPContactsRequest request, int epId);

        /// <summary>
        /// 获取联系人详情
        /// </summary>
        T_EPHiringManager GetEPContactsDetails(int epContactsId);

        /// <summary>
        /// 获取子账号列表
        /// </summary>
        List<GetAccountListModel> GetAccountList(int epId, string cityId);

        /// <summary>
        /// 更新或新增该企业子账号，或者修改主账号手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="epId">企业id</param>
        /// <param name="subAccoundId">账号id</param>
        int AddOrEditAccount(string phone, int epId,int subAccoundId);
    }
}
