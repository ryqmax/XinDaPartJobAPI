/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPLoginViewModel.cs
 *      Description:
 *            EPLoginViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 12:18:47
 *      History:
 ***********************************************************************************/



namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// 企业登录参数
    /// </summary>
    public class EPLoginRequest
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 微信标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 手机验证码
        /// </summary>
        public string VerifyCode { set; get; }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string City { set; get; }
    }

    /// <summary>
    /// EPLoginViewModel
    /// </summary>
    public class EPLoginViewModel
    {
        /// <summary>
        /// 企业登录令牌
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 是否是主账号
        /// </summary>
        public bool IsMainAccount { set; get; }
    }
}
