/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AccountService.cs
 *      Description:
 *            AccountService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 15:37:45
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Common;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Account;
using FrameWork.Entity.Model.Classmate;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Classmate;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// AccountService
    /// </summary>
    public class AccountService : BaseService<T_User>, IAccountService
    {
        /// <summary>
        /// 登录
        /// </summary>
        public T_User Login(LoginViewModel loginViewModel)
        {
            var sql = @"
                    SELECT
	                    *
                    FROM
	                    T_User
                    WHERE
	                    Name = @Name AND Password = @Password
	                    AND IsDel = 0 AND IsUsed = 1";
            loginViewModel.Password = Encrypt.MD5(loginViewModel.Password);//输入的密码进行加密与数据库进行比对
            return DbQuestionBank.FirstOrDefault<T_User>(sql, new { Name = loginViewModel.UserName, loginViewModel.Password });
        }

    }
}
