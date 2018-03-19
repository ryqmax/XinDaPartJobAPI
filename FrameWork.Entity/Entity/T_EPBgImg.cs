using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPBgImg")]
    [PrimaryKey("Id")]
    public class T_EPBgImg
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
        /// 背景图片地址 
        /// </summary>
        public string PicUrl {get;set;}

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
