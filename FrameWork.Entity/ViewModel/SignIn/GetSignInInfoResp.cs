using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.SignIn
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetSignInInfoResp:BaseViewModel
    {
        
    }

    public class SignInRespInfo
    {
        /// <summary>
        /// 今天是否已经签到
        /// </summary>
        public bool TodayIsSigned { get; set; }

        /// <summary>
        /// 用户签到获取的总的积分
        /// </summary>
        public int TotalValue { get; set; }

        /// <summary>
        /// 签到列表
        /// </summary>
        public List<RecentSignInInfoItem> List { get; set; }=new List<RecentSignInInfoItem>();
    }

    public class RecentSignInInfoItem
    {
        /// <summary>
        /// 加积分的值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 是否已经签到
        /// </summary>
        public bool IsSigned { get; set; }
    }
}
