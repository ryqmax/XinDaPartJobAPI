namespace FrameWork.Entity.ViewModel.CV
{
    /// <summary>
    /// 参数
    /// </summary>
    public class ShieldCVReq
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { get; set; }

        /// <summary>
        /// 屏蔽天数
        /// </summary>
        public int ShieldDay { get; set; }
    }
}
