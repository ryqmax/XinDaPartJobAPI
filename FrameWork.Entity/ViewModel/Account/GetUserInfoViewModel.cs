using FrameWork.Common;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetUserInfoRequest
    {
        /// <summary>
        /// 微信账号
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImg { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 微信唯一标识符
        /// </summary>
        public string OpenId { set; get; }
    }

    public class GetUserInfoViewModel
    {
        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户标识符 GUID字符串
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 微信账户唯一标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 实体转化为
        /// </summary>
        public GetUserInfoViewModel GetViewModel(T_User model)
        {
            var viewModel = new GetUserInfoViewModel
            {
                UserId = model.Id,
                OpenId = StringHelper.NullOrEmpty(model.WxAccount)
            };
            return viewModel;
        }
    }
}
