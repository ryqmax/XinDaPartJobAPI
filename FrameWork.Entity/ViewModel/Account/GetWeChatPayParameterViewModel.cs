

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetWeChatPayParameterViewModel
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { set; get; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { set; get; }

        /// <summary>
        /// MD5签名
        /// </summary>
        public string PaySign { set; get; }

        /// <summary>
        /// 预支付订单id
        /// </summary>
        public string PrepayId { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { set; get; }

    }
}
