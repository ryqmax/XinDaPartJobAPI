using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_UserShieldCV")]
    [PrimaryKey("Id")]
    public class T_UserShieldCV
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 求职者id 
        /// </summary>
        public int UserId {get;set;}

        /// <summary>
        /// 简历id 
        /// </summary>
        public int CVId {get;set;}

        /// <summary>
        /// 屏蔽时长，单位：天 
        /// </summary>
        public int TimeSpan {get;set;}

        /// <summary>
        /// 截止时间 
        /// </summary>
        public DateTime EndTime {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public bool IsDel {get;set;}

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int CreateUserId {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime {get;set;}

    }
}
