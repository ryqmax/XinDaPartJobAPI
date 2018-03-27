﻿using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.CV;
using FrameWork.Entity.ViewModel.Job;

namespace FrameWork.Interface
{
    public interface ICVServicecs : IBaseService<T_UserShieldCV>
    {
        /// <summary>
        /// 用户屏蔽简历
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        bool UserShieldCV(int userId, int cVId, int shieldDay);

        /// <summary>
        /// 企业屏蔽简历
        /// </summary>
        /// <param name="epId">企业Id</param>
        /// <param name="cVId">简历Id</param>
        /// <param name="shieldDay">屏蔽天数</param>
        bool EnterpriseShieldCV(int epId, int cVId, int shieldDay);

        
        /// <summary>
        /// 获取简历列表
        /// </summary>
        List<CVInfo> GetCVList(GetCVReq getCvReq);
    }
}
