using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Classmate
{
    public class GetClassmateInfoRequest
    {
        /// <summary>
        /// 行业id
        /// </summary>
        public int IndustryId { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int Page { set; get; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { set; get; }
    }


    public class GetClassmateInfoViweModel
    {
        /// <summary>
        /// 行业名称
        /// </summary>
        public string IndustryName { set; get; }

        /// <summary>
        /// 行业总用户量
        /// </summary>
        public int TotalCount { set; get; }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool IsHaveNext { set; get; }

        /// <summary>
        /// 学生列表
        /// </summary>
        public List<StudentItem> StudentList = new List<StudentItem>();
    }

    /// <summary>
    /// 用户列表元素
    /// </summary>
    public class StudentItem
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
        public string Distance { set; get; }

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
