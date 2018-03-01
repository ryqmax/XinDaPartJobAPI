using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_Section")]
    [PrimaryKey("Id", true)]
    public class T_Section
    {
        
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 小节名称 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 章Id 
        /// </summary>
        public int ChapterId {get;set;}

        /// <summary>
        /// 小节简介 
        /// </summary>
        public string Description {get;set;}

        /// <summary>
        /// 顺序号码 
        /// </summary>
        public Double Sequence {get;set;}

        /// <summary>
        /// 被考概率 
        /// </summary>
        public int ExamRate {get;set;}

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
        public int? ModifyUserId {get;set;}

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime? ModifyTime {get;set;}

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int? CreateUserId {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreateTime {get;set;}

    }
}
