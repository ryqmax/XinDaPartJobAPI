
namespace FrameWork.Entity.Model.Classmate
{
    public class GetMyClassmateDeatilModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserHeadImg { set; get; }

        /// <summary>
        /// 正在学习的大类
        /// </summary>
        public string NowCategory { set; get; }

        /// <summary>
        /// 是否已经
        /// </summary>
        public bool IsAdd { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { set; get; }

        /// <summary>
        /// 距离
        /// </summary>
        public double Distance { set; get; }

    }
}
