using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_ReportJob")]
    [PrimaryKey("Id")]
    public class T_ReportJob
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 用户类型：1.普通用户，1.企业 
        /// </summary>
        public byte UserType {get;set;}

        /// <summary>
        /// 举报用户id或者举报企业用户id 
        /// </summary>
        public int UserId {get;set;}

        /// <summary>
        /// 企业id，如果举报者是不是企业用户，企业id为0
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 简历id或者岗位id 
        /// </summary>
        public int JobId {get;set;}

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string JobName { get;set;}
     
        /// <summary>
        /// 举报内容，存储方式：/虚假/广告/ 
        /// </summary>
        public string ReportReason { get; set; }

        /// <summary>
        /// 举报原因id，存储方式：/1/2/
        /// </summary>
        public string ReportReasonId { get; set; }

        /// <summary>
        /// 备注说明 
        /// </summary>
        public string Note {get;set;}
        
        /// <summary>
        /// 被举报的企业名字
        /// </summary>
        public string ExposedEPName { get;set;}

        /// <summary>
        /// 被举报的企业id 
        /// </summary>
        public int ExposedEnterpriseId {get;set;}

        /// <summary>
        /// 平台回复内容 
        /// </summary>
        public string Reply {get;set;}

        /// <summary>
        /// 处理状态：0.未处理，1.已证实，2.举报内容不实 
        /// </summary>
        public byte Status {get;set;}

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
