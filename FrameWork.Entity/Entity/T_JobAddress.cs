using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_JobAddress")]
    [PrimaryKey("Id")]
    public class T_JobAddress
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 兼职获取全职岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 工作地点id 
        /// </summary>
        public int EPAddressId {get;set;}

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
