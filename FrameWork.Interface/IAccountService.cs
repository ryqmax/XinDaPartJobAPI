using FrameWork.Entity.Entity;
using FrameWork.Entity.Model.Account;
using FrameWork.Entity.ViewModel.Account;

namespace FrameWork.Interface
{
    public interface IAccountService : IBaseService<T_User>
    {
        /// <summary>
        /// 登录
        /// </summary>
        T_User GetUserInfo(GetUserInfoRequest request);

        /// <summary>
        /// 企业登录
        /// </summary>
        EPLoginModel EpLogin(EPLoginRequest request);

        /// <summary>
        /// 把未与机构绑定的手机号插入到数据库
        /// </summary>
        void EPLoginForInsert(EPLoginRequest request);
    }
}
