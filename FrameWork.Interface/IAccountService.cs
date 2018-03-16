using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Account;
using FrameWork.Entity.Model.Classmate;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.Classmate;

namespace FrameWork.Interface
{
    public interface IAccountService : IBaseService<T_User>
    {
        /// <summary>
        /// 登录
        /// </summary>
        T_User Login(LoginViewModel loginViewModel);

    }
}
