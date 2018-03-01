

namespace FrameWork.Entity.Model.Classmate
{
    public class GetClassmateInfoModel
    {

        /// <summary>
        /// 行业总用户量
        /// </summary>
        public int TotalCount { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImg { set; get; }

        /// <summary>
        /// 用户能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 用户距离
        /// </summary>
        public double Distance { set; get; }

        /// <summary>
        /// 当前正在学习的大类
        /// </summary>
        public string NowCategory { set; get; }

        /// <summary>
        /// 是否给这个用户添加过能量
        /// </summary>
        public bool IsAdd { set; get; }

    }
}
