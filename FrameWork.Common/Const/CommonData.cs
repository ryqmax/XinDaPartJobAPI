
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
        /// token值错误码
        /// </summary>
        public static int TokenErrorCode = 20001;

        /// <summary>
        /// 方法名不存在
        /// </summary>
        public static int ActionNameErrorCode = 20002;

        /// <summary>
        /// 验证码错误提示
        /// </summary>
        public static string CodeNotCorrect = "验证码不正确";

        /// <summary>
        /// 验证码不能为空
        /// </summary>
        public static string CodeNotNULL = "验证码不能为空";

        /// <summary>
        /// 验证码已经过期，请重新获取
        /// </summary>
        public static string CodePassdate = "验证码已经过期，请重新获取";

        /// <summary>
        /// Token验证错误
        /// </summary>
        public static string TokenError = "Token验证错误";

        /// <summary>
        /// 方法名不存在
        /// </summary>
        public static string ActionNameError = "方法名不存在";

        /// <summary>
        /// 没有权限调用使用该功能
        /// </summary>
        public static string NoAuth = "没有权限调用使用该功能";

        /// <summary>
        /// 手机号已被绑定，请更换其他手机号
        /// </summary>
        public static string PhoneHasBind = "手机号已被绑定，请更换其他手机号";


        #region 企业登录

        /// <summary>
        /// 账号异常不能登录
        /// </summary>
        public static string AccountException = "账号异常不能登录";

        /// <summary>
        /// 会员到期不能登录
        /// </summary>
        public static string AccountPassdate = "会员到期不能登录";

        #endregion

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
        
        /// <summary>
        /// 缓存所有的城市列表key
        /// </summary>
        public static string RegionRedisCache = "allRegions";

        /// <summary>
        /// 保存路径
        /// </summary>
        public static string TPImageSavePath = ConfigurationManager.AppSettings["TPImageSavePath"];

        /// <summary>
        /// 上传路径
        /// </summary>
        public static string TPImageUpPath = ConfigurationManager.AppSettings["TPImageUpPath"];

    }
}
