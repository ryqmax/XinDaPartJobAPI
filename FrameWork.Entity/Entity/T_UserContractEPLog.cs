using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_UserContractEPLog")]
    [PrimaryKey("Id")]
    public class T_UserContractEPLog
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 用户id 
        /// </summary>
        public int UserId {get;set;}

        /// <summary>
        /// 岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone {get;set;}

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
