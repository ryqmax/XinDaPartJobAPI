using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_Job")]
    [PrimaryKey("Id")]
    public class T_Job
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
        /// 简历类别：0.兼职，1.全职 
        /// </summary>
        public byte Type {get;set;}

        /// <summary>
        /// 全职岗位名称 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 岗位类别id 
        /// </summary>
        public int JobCategoryId {get;set;}

        /// <summary>
        /// 学历id 
        /// </summary>
        public int EducationId {get;set;}

        /// <summary>
        /// 结算方式id 
        /// </summary>
        public int PayWayId {get;set;}

        /// <summary>
        /// 薪资下限 
        /// </summary>
        public int SalaryLower {get;set;}

        /// <summary>
        /// 薪资上限 
        /// </summary>
        public int SalaryUpper {get;set;}

        /// <summary>
        /// 是否是实习 
        /// </summary>
        public bool IsPractice {get;set;}

        /// <summary>
        /// 工作时间：单双休 
        /// </summary>
        public string WorkTime {get;set;}

        /// <summary>
        /// 工作内容，限制1000字，但是包括一些HTML转义字符 
        /// </summary>
        public string WorkContent {get;set;}

        /// <summary>
        /// 任职要求，限制1000字，但是包括一些HTML转义字符 
        /// </summary>
        public string OfficeRequire {get;set;}

        /// <summary>
        /// 发布岗位省id 
        /// </summary>
        public string ProvinceId {get;set;}

        /// <summary>
        /// 发布岗位市id 
        /// </summary>
        public string CityId {get;set;}

        /// <summary>
        /// 招聘联系人id 
        /// </summary>
        public int EPHiringManagerId {get;set;}

        /// <summary>
        /// 刷新方式：0.智能刷新，1.预约刷新 
        /// </summary>
        public byte RefreshWay {get;set;}

        /// <summary>
        /// 刷新时间 
        /// </summary>
        public DateTime RefreshTime {get;set;}

        /// <summary>
        /// 职位状态：0.未发布，1.展示中，2.系统退回,请修改，3.已下架 
        /// </summary>
        public byte Status {get;set;}

        /// <summary>
        /// 浏览量 
        /// </summary>
        public int ViewCount {get;set;}

        /// <summary>
        /// 是否被推荐 
        /// </summary>
        public bool IsRecommand {get;set;}

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
