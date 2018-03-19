using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CVDelivery")]
    [PrimaryKey("Id")]
    public class T_CVDelivery
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
        /// 简历id 
        /// </summary>
        public int CvId {get;set;}

        /// <summary>
        /// 岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 企业id 
        /// </summary>
        public int EnterpriseId {get;set;}

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
