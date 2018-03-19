using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_Enterprise")]
    [PrimaryKey("Id")]
    public class T_Enterprise
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 企业名称 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 企业简称 
        /// </summary>
        public string ShortName {get;set;}

        /// <summary>
        /// 省id 
        /// </summary>
        public string ProvinceId {get;set;}

        /// <summary>
        /// 市id 
        /// </summary>
        public string CityId {get;set;}

        /// <summary>
        /// 区id 
        /// </summary>
        public string AreaId {get;set;}

        /// <summary>
        /// 企业地址 
        /// </summary>
        public string Address {get;set;}

        /// <summary>
        /// 经度 
        /// </summary>
        public decimal? Lng {get;set;}

        /// <summary>
        /// 纬度 
        /// </summary>
        public decimal? Lat {get;set;}

        /// <summary>
        /// 公司简介,格式字符显示的时候过滤 
        /// </summary>
        public string Brief {get;set;}

        /// <summary>
        /// 企业logo图片地址 
        /// </summary>
        public string Logo {get;set;}

        /// <summary>
        /// 企业认证图片 
        /// </summary>
        public string AuthPicUrl {get;set;}

        /// <summary>
        /// 审核状态：0.未提交审核（保存信息），1.审核中，2.审核未通过，3.审核通过 
        /// </summary>
        public byte CheckStatus {get;set;}

        /// <summary>
        /// 审核备注或者审核不通过原因 
        /// </summary>
        public string CheckNote {get;set;}

        /// <summary>
        /// 总积分 
        /// </summary>
        public int TotalIntegral {get;set;}

        /// <summary>
        /// 等级信息：0.未认证，1.普通，2.一级雇主，3.二级，4.三级，5.四级，6.五级 
        /// </summary>
        public byte Level {get;set;}

        /// <summary>
        /// 账号状态：0.会员到期禁用，1.启用，2.违规禁用
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 备注：禁用理由或其他
        /// </summary>
        public string Note { set; get; }

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
