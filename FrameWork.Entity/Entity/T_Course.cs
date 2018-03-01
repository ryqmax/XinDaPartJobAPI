using System;

namespace FrameWork.Entity.Entity
{
    public class T_Course
    {
        
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 课程名称 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 分类Id 
        /// </summary>
        public int CategoryId {get;set;}

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
        /// 创建人id 
        /// </summary>
        public int? CreateUserId {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreateTime {get;set;}

    }
}
