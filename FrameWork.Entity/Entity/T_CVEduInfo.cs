using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CVEduInfo")]
    [PrimaryKey("Id")]
    public class T_CVEduInfo
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 简历id 
        /// </summary>
        public int CVId {get;set;}

        /// <summary>
        /// 院校名称 
        /// </summary>
        public string SchoolName {get;set;}

        /// <summary>
        /// 专业名称 
        /// </summary>
        public string MajorName {get;set;}

        /// <summary>
        /// 学历id 
        /// </summary>
        public int DicEducationId {get;set;}

        /// <summary>
        /// 学位id 
        /// </summary>
        public int DicGradeId {get;set;}

        /// <summary>
        /// 入学时间 
        /// </summary>
        public DateTime EnterTime {get;set;}

        /// <summary>
        /// 毕业时间 
        /// </summary>
        public DateTime GraduateTime {get;set;}

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
