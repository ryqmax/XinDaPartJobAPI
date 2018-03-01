/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                LoginViewModel.cs
 *      Description:
 *            LoginViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 15:01:38
 *      History:
 ***********************************************************************************/


namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { set; get; }
    }
}