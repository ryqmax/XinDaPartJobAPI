using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Enum;
using FrameWork.Entity.ViewModel;
using Newtonsoft.Json;
using System.Linq;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// 验证签名，token，参数是否为空    ----时间戳名称：TimeStamp  签名名称：Sign 固定字符串暂定为：（加密固定字符串 经md5加密）abfdb3f36565ecb7d944303845392592
    /// </summary>
    public class RequestHandler : DelegatingHandler
    {
        /// <summary>  
        /// 拦截请求  
        /// </summary>  
        /// <param name="request">请求</param>  
        /// <param name="cancellationToken">用于发送取消操作信号</param>  
        /// <returns></returns>  
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
#if DEBUG
            return await base.SendAsync(request, cancellationToken);//调试时打开注释
#endif
            //获取路由值
            var requesPath = request.RequestUri.AbsolutePath.Split('/');

            //做一些其他安全验证工作，比如Token验证，签名验证  在此共分为3步。

            #region 验证参数是否为空

            var controllerName = requesPath[2];
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                var controllerPath = declaringType.Namespace + "." + controllerName + "Controller";
                var controllerType = Type.GetType(controllerPath);
                if (controllerType == null)
                {
                    return ReturnHelper(CommonData.ActionNameErrorCode, CommonData.ActionNameError);
                }
                var methodName = requesPath.Last();
                var isHaveParam = IsHaveParam(controllerType, methodName);
            
                if (!isHaveParam)//不需要参数，直接返回true
                {
                    return await base.SendAsync(request, cancellationToken);
                }
            }

            #endregion

            #region 验证token
            var methodType = request.Method;
            if (methodType.Method == "POST")
            {
                var tokenModel = JsonConvert.DeserializeObject<TokenModel>(request.Content.ReadAsStringAsync().Result);
                var token = tokenModel.Token;

                if (!string.IsNullOrEmpty(token) && !TokenIseffective(tokenModel.Token))
                {
                    return ReturnHelper(CommonData.TokenErrorCode, CommonData.TokenError);
                }
            }
            else
            {
                var paramGet = request.RequestUri;    //Get请求
                if (!string.IsNullOrEmpty(paramGet.Query) && paramGet.Query.ToLower().Contains("token"))
                {
                    var getTokenStrings = paramGet.Query.Split('&');
                    if (!CheckToken(getTokenStrings))
                    {
                        return ReturnHelper(CommonData.TokenErrorCode, CommonData.TokenError);
                    }
                }
            }

            #endregion
            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// 判断所调用的方法是否需要参数
        /// </summary>
        /// <param name="controllerType">controller类型</param>
        /// <param name="methodName">方法名称</param>
        private bool IsHaveParam(Type controllerType, string methodName)
        {
            var method = controllerType.GetMethod(methodName);
            if (method == null || method.GetParameters().Length <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证Token是否有效及其正确
        /// </summary>
        private bool CheckToken(string[] getTokenStrings)
        {
            var token = "";
            var mark = false;
            //获取UserId
            for (var i = 0; i < getTokenStrings.Length; i++)
            {
                if (getTokenStrings[i].ToLower().Contains("token"))
                {
                    token = getTokenStrings[i].Split('=')[1];
                    break;
                }
            }
            if (!string.IsNullOrEmpty(token))
            {
                if (TokenIseffective(token))
                    mark= true;
            }
            //参数中没有UserId,则不需要验证
            return mark;
        }

        /// <summary>
        /// 判断token是否有效
        /// </summary>
        /// <param name="token">登录令牌</param>
        private bool TokenIseffective(string token)
        {
            var mark = false;
            if (!string.IsNullOrEmpty(token))
            {
                var model = RedisInfoHelper.GetRedisModel(token);
                mark = model.Mark > 0;
            }
            return mark;
        }

        /// <summary>
        /// 返回错误消息帮助方法
        /// </summary>
        private HttpResponseMessage ReturnHelper(int errorCode, string message)
        {
            return new BaseViewModel
            {
                Msg = false,
                ResultCode = errorCode,
                Message = message,
                Info = string.Empty
            }.ToJson();
        }
    }
}
