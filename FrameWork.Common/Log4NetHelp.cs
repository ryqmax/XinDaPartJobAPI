using System;
using log4net;

namespace FrameWork.Common
{
    public class Log4NetHelp
    {
        #region 变量定义
      
        //ILog对象
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        //信息模板
        //private const string _ConversionPattern = "%n【记录时间】%date%n【描述】%message%n";
        #endregion

        #region 封装Log4net
        public static void Debug(object message)
        {
          
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }
        public static void Debug(object message, Exception ex)
        {
          
            if (log.IsDebugEnabled)
            {
                log.Debug(message, ex);
            }
        }
        public static void DebugFormat(string format, params object[] args)
        {
           
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(format, args);
            }
        }
        public static void Error(object message)
        {
           
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }
        public static void Error(object message, Exception ex)
        {
           
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }
        public static void ErrorFormat(string format, params object[] args)
        {
           
            if (log.IsErrorEnabled)
            {
                log.ErrorFormat(format, args);
            }
        }
        public static void Fatal(object message)
        {
          
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
        }
        public static void Fatal(object message, Exception ex)
        {
          
            if (log.IsFatalEnabled)
            {
                log.Fatal(message, ex);
            }
        }
        public static void FatalFormat(string format, params object[] args)
        {
           
            if (log.IsFatalEnabled)
            {
                log.FatalFormat(format, args);
            }
        }
        public static void Info(object message)
        {
          
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        public static void Info(object message, Exception ex)
        {
          
            if (log.IsInfoEnabled)
            {
                log.Info(message, ex);
            }
        }
        public static void InfoFormat(string format, params object[] args)
        {
            
            if (log.IsInfoEnabled)
            {
                log.InfoFormat(format, args);
            }
        }
        public static void Warn(object message)
        {
           
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
        }
        public static void Warn(object message, Exception ex)
        {
            
            if (log.IsWarnEnabled)
            {
                log.Warn(message, ex);
            }
        }
        public static void WarnFormat(string format, params object[] args)
        {
           
            if (log.IsWarnEnabled)
            {
                log.WarnFormat(format, args);
            }
        }
        #endregion

        #region 定义常规应用程序中未处理的异常信息记录方式
        public static void LoadUnhandledException()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler
 ((sender, e) =>
 {
     log.Fatal("未处理的异常", e.ExceptionObject as Exception);
 });
        }
        #endregion
    }
}