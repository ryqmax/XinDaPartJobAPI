using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("DicGrade")]
    [PrimaryKey("Id")]
    public class DicGrade
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 学历信息id 
        /// </summary>
        public int DicEducationId {get;set;}

        /// <summary>
        /// 简历学位信息 
        /// </summary>
        public string Name {get;set;}

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
