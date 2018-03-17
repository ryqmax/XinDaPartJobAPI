using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.Account;
using FrameWork.Entity.ViewModel.SignIn;

namespace FrameWork.Interface
{
    public interface ISignInService : IBaseService<T_UserSignLog>
    {
        /// <summary>
        /// 获取最近的用户签到记录信息
        /// </summary>
        List<RecentSignInInfo> GetUserRecentSignInInfo(int userId);

        /// <summary>
        /// 获取最近的企业签到记录信息
        /// </summary>
        List<RecentSignInInfo> GetEnterpriseRecentSignInInfo(int enId);

    }
}
