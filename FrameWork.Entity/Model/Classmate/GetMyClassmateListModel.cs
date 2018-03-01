
using System;

namespace FrameWork.Entity.Model.Classmate
{
    public class GetMyClassmateListModel
    {
        /// <summary>
        /// 总记录数
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
        /// 能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserHeadImg { set; get; }
        
        /// <summary>
        /// 添加能量的时间
        /// </summary>
        public DateTime CreateTime { set; get; }

        /// <summary>
        /// 正在学习的大类
        /// </summary>
        public string NowCategory { set; get; }

        /// <summary>
        /// 是否已经
        /// </summary>
        public bool IsAdd { set; get; }

    }
}
