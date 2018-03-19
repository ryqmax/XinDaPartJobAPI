using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_JobRefresh")]
    [PrimaryKey("Id")]
    public class T_JobRefresh
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 时间间隔，单位：分钟 
        /// </summary>
        public int TimeSpan {get;set;}

        /// <summary>
        /// 预约的开始刷新时间 
        /// </summary>
        public DateTime StartTime {get;set;}

        /// <summary>
        /// 刷新的天数 
        /// </summary>
        public int RefreshDay {get;set;}

        /// <summary>
        /// 预约的截止刷新时间， 
        /// </summary>
        public DateTime EndTime {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public bool IsDel {get;set;}

        /// <summary>
        /// 编辑人id 
        /// </summary>
        public int ModifyUserId {get;set;}

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime ModifyTime {get;set;}

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
