
namespace FrameWork.Entity.Model.Classmate
{
    public class UserEnergy
    {
        /// <summary>
        /// 学员的能量值
        /// </summary>
        public int EnergyCount { set; get; }
    }

    /// <summary>
    /// 学员信息
    /// </summary>
    public class UserInfoModel
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
    /// 行业及其行业下的用户数量
    /// </summary>
    public class IndustryUserCountModel
    {
        /// <summary>
        /// 行业id
        /// </summary>
        public int IndustryId { set; get; }

        /// <summary>
        /// 行业下的在线用户量
        /// </summary>
        public int IndustryUserCount { set; get; }
    }
}
