using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_Banner")]
    [PrimaryKey("Id", true)]
    public class T_Banner
    {
        
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 图片地址 
        /// </summary>
        public string ImgPath {get;set;}

        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string ActionUrl {get;set;}

        /// <summary>
        /// 序号 
        /// </summary>
        public Double Sequence {get;set;}

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
        public int? ModifyUserId {get;set;}

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime? ModifyTime {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreateTime {get;set;}

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int? CreateUserId {get;set;}

    }
}
