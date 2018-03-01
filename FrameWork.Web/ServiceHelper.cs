/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                ServiceHelper.cs
 *      Description:
 *            ServiceHelper
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 17:10:31
 *      History:
 ***********************************************************************************/

using System;
using System.Threading;
using Castle.DynamicProxy;
using FrameWork.Common;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.Web
{
    /// <summary>
    /// 创建service
    /// </summary>
    public class ServiceHelper
    {
        /// <summary>
        /// 暂时使用引用服务方式，可以改造成注入，或使用WCF服务方式
        /// </summary>
        public static ServiceFactory serviceFactory = new RefServiceFactory();

        /// <summary>
        /// 创建服务根据BLL接口
        /// </summary>
        public static T CreateService<T>() where T : class
        {
            var service = serviceFactory.CreateService<T>();

            //拦截，可以写日志....
            var generator = new ProxyGenerator();
            var dynamicProxy = generator.CreateInterfaceProxyWithTargetInterface<T>(
                service, new InvokeInterceptor());

            return dynamicProxy;
        }

        /// <summary>
        /// 只用来创建没有拦截器的logservice
        /// </summary>
        /// <returns></returns>
        public static ILogService CreateLogService()
        {
            var service = serviceFactory.CreateService<ILogService>();

            //拦截，可以写日志....
            var generator = new ProxyGenerator();
            var dynamicProxy = generator.CreateInterfaceProxyWithTargetInterface(service);

            return dynamicProxy;
        }

    }

    /// <summary>
    /// 拦截器
    /// </summary>
    internal class InvokeInterceptor : IInterceptor
    {
        public InvokeInterceptor()
        {
        }
        /// <summary>
        /// 拦截方法
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                var message = new
                {
                    exception = exception.Message,
                    exceptionContext = new
                    {
                        method = invocation.Method.ToString(),
                        arguments = invocation.Arguments,
                        returnValue = invocation.ReturnValue
                    }
                };
                Log4NetHelp.Error(JsonHelper.SerializeObject(message), exception);
                LogHelper.Start(exception, invocation);
                throw;
            }
        }
    }

    /// <summary>
    /// 记录错误日志
    /// </summary>
    internal class LogHelper
    {
        private static readonly ILogService LogService = ServiceHelper.CreateLogService();

        /// <summary>
        /// 记录错误日志到数据库
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="invocation"></param>
        private static void AddEntity(Exception exception, IInvocation invocation)
        {
            var entity = new Log4net
            {
                Date = DateTime.Now,
                Thread = Convert.ToString(Thread.CurrentThread.ManagedThreadId),
                Level = "ERROR",
                Logger = "qingpukaofu",
                Host = IpHelp.GetClientIp(),
                Exception = exception.ToString(),
                Message = $@"MethodName:{invocation.Method} -------------  Arguments: {JsonHelper.SerializeObject(invocation.Arguments)}"
            };

            LogService.Add(entity);
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="invocation"></param>
        public static void Start(Exception exception, IInvocation invocation)
        {
            Action act = () => AddEntity(exception, invocation);
            act.BeginInvoke(null, null);
        }
    }
}
