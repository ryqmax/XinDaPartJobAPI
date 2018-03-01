using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using System.Web.Mvc;
using FrameWork.Common;
using FrameWork.Common.Const;

namespace FrameWork.Web.Handle
{
    /// <summary>
    /// 处理错误信息
    /// </summary>
    public class ErrorHandleAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            // 错误处理
            base.OnException(filterContext);
            filterContext.Response = GetResponse();
            var email = new Email
            {
                mailSubject = "错误信息",
                mailBody = $"参数：{GetExceptionMessage(filterContext)}\r\n 异常内容：{filterContext.Exception.ToJson()}",
                isbodyHtml = false,
                mailToArray = ConfigurationManager.AppSettings["recevier"].Split(','),
                mailCcArray = ConfigurationManager.AppSettings["recevier"].Split(',')
            };
            email.Send();
        }

        private string GetExceptionMessage(HttpActionExecutedContext actionExecutedContext)
        {
            var session = System.Web.HttpContext.Current.Session;
            var request = System.Web.HttpContext.Current.Request;
            var guid = System.Guid.NewGuid().ToString();
            var task = actionExecutedContext.ActionContext.Request.Content.ReadAsStreamAsync();
            var content = string.Empty;
            try
            {
                var sm = task.Result;
                if (sm != null)
                {
                    sm.Seek(0, SeekOrigin.Begin);
                    int len = (int)sm.Length;
                    byte[] inputByts = new byte[len];
                    sm.Read(inputByts, 0, len);
                    sm.Close();
                    content = Encoding.UTF8.GetString(inputByts);
                    sm.Close();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            string sessionId = session == null ? "" : session.SessionID;
            string pars = string.Format("error：\r\n id = {3};\r\n sessionId = {0};\r\n url = {1};\r\n contentType = {4};\r\n content = {2};"
                , sessionId
                , request.RawUrl
                , content
                , guid
                , request.ContentType);

            return pars;
        }

        private HttpResponseMessage GetResponse()
        {
            return JsonHelper.ToJson(new
            {
                Info = CourseConst.FailStr,
                Message = CourseConst.FailStr,
                Msg = false,
                ResultCode = CourseConst.FailCode
            });
        }
    }
}
