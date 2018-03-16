using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CVUpLog")]
    [PrimaryKey("Id")]
    public class T_CVUpLog
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
        /// 推荐日期 
        /// </summary>
        public DateTime Upday {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public Boolean IsDel {get;set;}

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
