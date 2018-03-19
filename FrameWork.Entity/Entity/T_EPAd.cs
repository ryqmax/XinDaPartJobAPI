using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPAd")]
    [PrimaryKey("Id")]
    public class T_EPAd
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string ActionUrl {get;set;}

        /// <summary>
        /// 企业id 
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 广告id 
        /// </summary>
        public int AdId {get;set;}

        /// <summary>
        /// 过期时间 
        /// </summary>
        public DateTime PassDate {get;set;}

        /// <summary>
        /// 是否启用 
        /// </summary>
        public bool IsUsed {get;set;}

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
