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
using System.Web.Mvc;
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
        /// 课程
        /// </summary>
        protected ICourseService CourseService => ServiceHelper.CreateService<ICourseService>();

        /// <summary>
        /// 资讯
        /// </summary>
        protected INewsService NewsService => ServiceHelper.CreateService<INewsService>();

        /// <summary>
        /// 学生
        /// </summary>
        protected IStudentService StudentService => ServiceHelper.CreateService<IStudentService>();
    }
}