using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPWelfare")]
    [PrimaryKey("Id")]
    public class T_EPWelfare
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 企业id，如果为0则说明是平台的 
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 福利名称 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 是否启用 
        /// </summary>
        public Boolean IsUsed {get;set;}

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
