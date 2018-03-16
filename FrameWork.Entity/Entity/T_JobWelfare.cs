using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_JobWelfare")]
    [PrimaryKey("Id")]
    public class T_JobWelfare
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 福利id 
        /// </summary>
        public int EPWelfareId {get;set;}

        /// <summary>
        /// 岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public Boolean IsDel {get;set;}

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
