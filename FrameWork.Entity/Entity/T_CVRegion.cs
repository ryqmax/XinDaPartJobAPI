using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CVRegion")]
    [PrimaryKey("Id")]
    public class T_CVRegion
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 地区id 
        /// </summary>
        public string DicRegionId {get;set;}

        /// <summary>
        /// 简历id 
        /// </summary>
        public int CVId {get;set;}

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
