using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_ReportCV")]
    [PrimaryKey("Id")]
    public class T_ReportCV
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
        /// 举报者id 
        /// </summary>
        public int UserId {get;set;}

        /// <summary>
        /// 用户名字或企业名字 
        /// </summary>
        public string UserName {get;set;}

        /// <summary>
        /// 企业id 
        /// </summary>
        public int EnterpriseId {get;set;}

        /// <summary>
        /// 简历id 
        /// </summary>
        public int CVId {get;set;}

        /// <summary>
        /// 技能描述 
        /// </summary>
        public string SkillDesc {get;set;}

        /// <summary>
        /// 岗位类别id，存储方式：/1/3/ 
        /// </summary>
        public string JobCategoryIds {get;set;}

        /// <summary>
        /// 岗位类别名字，存储方式：/教育/网站/ 
        /// </summary>
        public string JobCategoryNames {get;set;}

        /// <summary>
        /// 举报内容，存储方式：/虚假/广告/ 
        /// </summary>
        public string ReportReason { get;set;}

        /// <summary>
        /// 举报原因id，存储方式：/1/2/
        /// </summary>
        public string ReportReasonId { get;set;}

        /// <summary>
        /// 备注说明 
        /// </summary>
        public string Note {get;set;}

        /// <summary>
        /// 被举报用户类型：1.普通用户，1.企业 
        /// </summary>
        public byte ExposedUserType {get;set;}

        /// <summary>
        /// 被举报用户id或者被举报企业id 
        /// </summary>
        public int ExposedUserId {get;set;}

        /// <summary>
        /// 被举报的用户名字或企业名字 
        /// </summary>
        public string ExposedUserName {get;set;}

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
