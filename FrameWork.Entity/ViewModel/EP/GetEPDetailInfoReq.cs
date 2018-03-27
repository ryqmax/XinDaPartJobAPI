namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetEPDetailInfoReq
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }
        
        /// <summary>
        /// 企业id
        /// </summary>
        public int EPId { get; set; }
    }
}
