using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPAddress")]
    [PrimaryKey("Id")]
    public class T_EPAddress
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
        /// 地址所属类别：0.全部，1.兼职，2.全职 
        /// </summary>
        public Byte Type {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public Boolean IsDel {get;set;}

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
