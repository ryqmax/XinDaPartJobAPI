using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPVIP")]
    [PrimaryKey("Id")]
    public class T_EPVIP
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
        /// 省id 
        /// </summary>
        public string ProvinceId {get;set;}

        /// <summary>
        /// 市id 
        /// </summary>
        public string CityId {get;set;}

        /// <summary>
        /// 会员信息id 
        /// </summary>
        public int VIPInfoId {get;set;}

        /// <summary>
        /// 过期时间，5号24点过期，存的日期就是6号 
        /// </summary>
        public DateTime PassDate {get;set;}

        /// <summary>
        /// 订单id 
        /// </summary>
        public int EPOrderId {get;set;}

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
