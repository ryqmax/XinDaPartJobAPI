using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPShieldJob")]
    [PrimaryKey("Id")]
    public class T_EPShieldJob
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 企业id 
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 岗位id 
        /// </summary>
        public int JobId {get;set;}

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
