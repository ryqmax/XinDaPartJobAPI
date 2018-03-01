

using System.Collections.Generic;

namespace FrameWork.Entity.ViewModel.Classmate
{
    public class GetClassmateNumRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }
    }

    /// <summary>
    /// 返回的数据基类
    /// </summary>
    public class GetClassmateNumViewModel
    {
        /// <summary>
        /// 学员的能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 全站在线总用户量
        /// </summary>
        public int TotalUserCount { set; get; }

        /// <summary>
        /// 学员列表
        /// </summary>
        public List<UserInfo> UserList = new List<UserInfo>();

        /// <summary>
        /// 行业在线用户列表
        /// </summary>
        public List<IndustryItem> IndustryItemList =new List<IndustryItem>();

    }

    /// <summary>
    /// 学员信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 学员id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 学员头像地址
        /// </summary>
        public string UserHeadImg { set; get; }
    }

    /// <summary>
    /// 行业类
    /// </summary>
    public class IndustryItem
    {
        /// <summary>
        /// 行业id
        /// </summary>
        public int IndustryId { set; get; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { set; get; }

        /// <summary>
        /// 行业下的在线用户量
        /// </summary>
        public int IndustryUserCount { set; get; }
    }
}
