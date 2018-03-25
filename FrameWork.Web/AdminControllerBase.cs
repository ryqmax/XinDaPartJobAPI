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

        /// <summary>
        /// 实例化IEPAddressService
        /// </summary>
        protected IEPAddressService EPAddressService => ServiceHelper.CreateService<IEPAddressService>();

        /// <summary>
        /// 实例化IVIPInfoService
        /// </summary>
        protected IVIPInfoService VIPInfoService => ServiceHelper.CreateService<IVIPInfoService>();

        /// <summary>
        /// 实例化IReportService
        /// </summary>
        protected IReportService ReportService => ServiceHelper.CreateService<IReportService>();

        /// <summary>
        /// 实例化IJobCategoryServicecs
        /// </summary>
        protected IJobCategoryServicecs JobCategoryServicec => ServiceHelper.CreateService<IJobCategoryServicecs>();

        /// <summary>
        /// 实例化IJobBannerServicecs
        /// </summary>
        protected IJobBannerServicecs JobBannerServicec => ServiceHelper.CreateService<IJobBannerServicecs>();

        /// <summary>
        /// 实例化ICVServicecs
        /// </summary>
        protected ICVServicecs CVServicecs => ServiceHelper.CreateService<ICVServicecs>();
    }
}