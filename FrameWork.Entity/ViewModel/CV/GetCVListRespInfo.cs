using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.CV
{
    /// <summary>
    /// 获取岗位列表返回模型
    /// </summary>
    public class GetCVListRespInfo
    {
        public List<CVInfoItem> CVList { get; set; } = new List<CVInfoItem>();

        /// <summary>
        /// 是否结束 
        /// </summary>
        public bool IsEnd { get; set; }
    }

    public class CVInfoItem
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
        public string CVSex { get; set; }

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
        /// 是否为广告 
        /// </summary>
        public bool IsAdvert { get; set; }

        public List<AdListItem> AdList { get; set; } = new List<AdListItem>();
    }

    public class AdListItem
    {
        /// <summary>
        /// 教育培训 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 广告名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 广告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 公司地址 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string Url { get; set; }
    }
}
