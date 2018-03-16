using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPContractUserLog")]
    [PrimaryKey("Id")]
    public class T_EPContractUserLog
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
        /// 简历Id 
        /// </summary>
        public int CVId {get;set;}

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone {get;set;}

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
