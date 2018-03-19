namespace FrameWork.Entity.ViewModel.SignIn
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetJobListReq
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 1:兼职 2：全职
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// 雇主等级
        /// </summary>
        public int EmployerRankId { get; set; }

        /// <summary>
        /// 岗位分类Id
        /// </summary>
        public int JobTypeId { get; set; }

        /// <summary>
        /// 当前页面
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 分页长度
        /// </summary>
        public int PageSize { get; set; }
    }
}
