using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.Account;

namespace FrameWork.Interface
{
    public interface IAccountService : IBaseService<T_User>
    {
        /// <summary>
        /// 登录
        /// </summary>
        T_User GetUserInfo(GetUserInfoRequest request);

    }
}
