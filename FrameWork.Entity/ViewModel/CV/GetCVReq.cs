namespace FrameWork.Entity.ViewModel.CV
{
    /// <summary>
    /// 参数
    /// </summary>
    public class GetCVReq
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
        /// 学历层次Id
        /// </summary>
        public int EducationId { get; set; }

        /// <summary>
        /// 岗位分类Id
        /// </summary>
        public int JobTypeId { get; set; }

        /// <summary>
        /// 1：男2：女3：不限
        /// </summary>
        public int JobSex { get; set; }

        /// <summary>
        /// 0：时间排序 1：女3：不限
        /// </summary>
        public int Sort { get; set; }

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
