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

        /// <summary>
        /// 用户签到
        /// </summary>
        bool UserSignIn(T_UserSignLog userSignLog);

        /// <summary>
        /// 企业签到
        /// </summary>
        bool EnterpriseSignIn(T_EPSignLog epSignLog);

        /// <summary>
        /// 更新用户积分
        /// </summary>
        bool UpdateUserIntegral(int userId, int addValue, string addReason);

        /// <summary>
        /// 更新企业积分
        /// </summary>
        bool UpdateEnterpriseIntegral(int userId, int addValue, string addReason);
    }
}
