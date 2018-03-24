using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_User")]
    [PrimaryKey("Id")]
    public class T_User
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 微信标识符 
        /// </summary>
        public string WxAccount {get;set;}

        /// <summary>
        /// 微信用户名 
        /// </summary>
        public string WxName {get;set;}

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone {get;set;}

        /// <summary>
        /// 微信头像
        /// </summary>
        public string WxHeadImg { get;set;}

        /// <summary>
        /// 总积分 
        /// </summary>
        public int TotalIntegral {get;set;}

        /// <summary>
        /// 真实姓名 
        /// </summary>
        public string RealName {get;set;}

        /// <summary>
        /// 性别：1.男，2.女 
        /// </summary>
        public byte Sex {get;set;}

        /// <summary>
        /// 出生日期：1992-06 
        /// </summary>
        public DateTime Birthday {get;set;}

        /// <summary>
        /// 现居住地区id，存储值为区id 
        /// </summary>
        public string DicRegionId {get;set;}

        /// <summary>
        /// 户口所在地省id 
        /// </summary>
        public string OriginalProvinceId {get;set;}

        /// <summary>
        /// 户口所在地市id 
        /// </summary>
        public string OriginalCityId {get;set;}

        /// <summary>
        /// 微信头像
        /// </summary>
        public string HeadImg { get;set;}

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
