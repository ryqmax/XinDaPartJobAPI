namespace FrameWork.Entity.ViewModel.CV
{
    /// <summary>
    /// 岗位信息
    /// </summary>
    public class CVInfo
    {
        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { get; set; }

        /// <summary>
        /// 简历头像 
        /// </summary>
        public string CVName { get; set; }

        /// <summary>
        /// 简历名称 
        /// </summary>
        public string CVImg { get; set; }

        /// <summary>
        /// 1：男 2:女 
        /// </summary>
        public int CVSex { get; set; }

        /// <summary>
        /// 简历技能 
        /// </summary>
        public string CVWord { get; set; }
        
        /// <summary>
        /// 简历地点 
        /// </summary>
        public string CVPosition { get; set; }

        /// <summary>
        /// 简历时间 
        /// </summary>
        public string CVTime { get; set; }
        
        /// <summary>
        /// 本科 
        /// </summary>
        public string CVSchool { get; set; }

        /// <summary>
        /// 岗位分类 
        /// </summary>
        public string CVJob { get; set; }

        /// <summary>
        /// 推荐指数 
        /// </summary>
        public int RecommendNum { get; set; }

        /// <summary>
        /// 是否为实习 
        /// </summary>
        public bool IsPractice { get; set; }

        /// <summary>
        /// 总条数 
        /// </summary>
        public int TotalNum { get; set; }
    }
}
