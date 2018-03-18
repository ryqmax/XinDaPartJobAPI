
using System.Collections.Generic;
using System.Configuration;

namespace FrameWork.Common.Const
{
    public class CommonData
    {
        public static List<int> SignValueArray = new List<int> {5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60};

        /// <summary>
        /// 获取成功
        /// </summary>
        public static string SuccessStr = "操作成功";

        /// <summary>
        /// 操作失败
        /// </summary>
        public static string FailStr = "操作失败";

        /// <summary>
        /// 短信发送失败提示语
        /// </summary>
        public static string SendFailStr = "发送失败，请联系客服";

        /// <summary>
        /// 成功结果码
        /// </summary>
        public static int SuccessCode = 10000;

        /// <summary>
        /// 失败结果码
        /// </summary>
        public static int FailCode = 20000;

        /// <summary>
        /// 验证码错误提示
        /// </summary>
        public static string CodeNotCorrect = "验证码不正确";

        /// <summary>
        /// Token验证错误
        /// </summary>
        public static string TokenError = "Token验证错误";

        /// <summary>
        /// 发送验证码模板id
        /// </summary>
        public static int TemplateId = int.Parse(ConfigurationManager.AppSettings["templateId"]);

        #region 签到相关
        /// <summary>
        /// 积分原因（签到）
        /// </summary>
        public static string SignIn = "签到";

        /// <summary>
        /// 获取成功
        /// </summary>
        public static string SignInSuccess = "签到成功";

        #endregion

    }
}
