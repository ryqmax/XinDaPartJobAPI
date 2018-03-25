namespace FrameWork.Entity.ViewModel.Job
{
    /// <summary>
    /// 参数
    /// </summary>
    public class ShieldJobReq
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 岗位id
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// 屏蔽天数
        /// </summary>
        public int ShieldDay { get; set; }
    }
}
