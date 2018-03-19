using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_CV")]
    [PrimaryKey("Id")]
    public class T_CV
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 求职者用户id 
        /// </summary>
        public int UserId {get;set;}

        /// <summary>
        /// 简历类别：0.兼职，1.全职 
        /// </summary>
        public byte Type {get;set;}

        /// <summary>
        /// 是否是实习 
        /// </summary>
        public bool IsPractice {get;set;}

        /// <summary>
        /// 期望薪资id 
        /// </summary>
        public int DicSalaryId {get;set;}

        /// <summary>
        /// 全职简历个人描述 
        /// </summary>
        public string Desc {get;set;}

        /// <summary>
        /// 工作时间 
        /// </summary>
        public string WorkTime {get;set;}

        /// <summary>
        /// 兼职技能概述 
        /// </summary>
        public string SkillSummary {get;set;}

        /// <summary>
        /// 兼职技能详细描述 
        /// </summary>
        public string SkillDesc {get;set;}

        /// <summary>
        /// 浏览量 
        /// </summary>
        public int ViewCount {get;set;}

        /// <summary>
        /// 通过这个简历联系这个人的数量 
        /// </summary>
        public int ContactCount {get;set;}

        /// <summary>
        /// 面试邀请的数量 
        /// </summary>
        public int InvitationCount {get;set;}

        /// <summary>
        /// 发布简历省id 
        /// </summary>
        public string ProvinceId {get;set;}

        /// <summary>
        /// 发布简历市id 
        /// </summary>
        public string CityId {get;set;}

        /// <summary>
        /// 刷新时间 
        /// </summary>
        public DateTime RefreshTime {get;set;}

        /// <summary>
        /// 推荐指数 
        /// </summary>
        public int? UpCount {get;set;}

        /// <summary>
        /// 上架状态：0.未发布，1.展示中 
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
