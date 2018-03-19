using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CVPracExp")]
    [PrimaryKey("Id")]
    public class T_CVPracExp
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
        /// 公司名字 
        /// </summary>
        public string EPName {get;set;}

        /// <summary>
        /// 入职时间 
        /// </summary>
        public DateTime EntryTime {get;set;}

        /// <summary>
        /// 离职时间 
        /// </summary>
        public DateTime QuitTime {get;set;}

        /// <summary>
        /// 岗位名称 
        /// </summary>
        public string JobName {get;set;}

        /// <summary>
        /// 月薪资下限 
        /// </summary>
        public int LowSalary {get;set;}

        /// <summary>
        /// 月薪资上限 
        /// </summary>
        public int UpSalary {get;set;}

        /// <summary>
        /// 工作描述 
        /// </summary>
        public string Description {get;set;}

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
