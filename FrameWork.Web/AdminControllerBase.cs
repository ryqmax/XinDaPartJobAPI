/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AdminControllerBase.cs
 *      Description:
 *            AdminControllerBase
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 14:58:51
 *      History:
 ***********************************************************************************/


using System.Web.Http;
using FrameWork.Interface;
using FrameWork.Web.Handle;

namespace FrameWork.Web
{
    /// <summary>
    /// AdminControllerBase
    /// </summary>
    [ErrorHandle]
    public abstract class AdminControllerBase : ApiController
    {
        /// <summary>
        /// 实例化IAccountService
        /// </summary>
        protected IAccountService AccountService => ServiceHelper.CreateService<IAccountService>();

        /// <summary>
        /// 实例化ISignInService
        /// </summary>
        protected ISignInService SignInService => ServiceHelper.CreateService<ISignInService>();

        /// <summary>
        /// 实例化IDicRegionService
        /// </summary>
        protected IDicRegionService DicRegionService => ServiceHelper.CreateService<IDicRegionService>();

        /// <summary>
        /// 实例化IEPService
        /// </summary>
        protected IEPService EPService => ServiceHelper.CreateService<IEPService>();

        /// <summary>
        /// 实例化IJobService
        /// </summary>
        protected IJobService JobService => ServiceHelper.CreateService<IJobService>();

    }
}