using FrameWork.Common;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.SignIn
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetSignInInfoRequest
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 微信唯一标识符
        /// </summary>
        public string OpenId { set; get; }
    }
}
