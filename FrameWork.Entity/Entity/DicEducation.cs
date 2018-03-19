using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("DicEducation")]
    [PrimaryKey("Id")]
    public class DicEducation
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 学历名字，中专，专科，本科，硕士 
        /// </summary>
        public string Name {get;set;}

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
