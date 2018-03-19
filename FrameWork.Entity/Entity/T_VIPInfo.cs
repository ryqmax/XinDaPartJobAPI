using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_VIPInfo")]
    [PrimaryKey("Id")]
    public class T_VIPInfo
    {
        
        /// <summary>
        /// - 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 会员名称：年度会员，半年会员，季度会员，月度会员 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 会员描述：有效期一年 
        /// </summary>
        public string Description {get;set;}

        /// <summary>
        /// 序号 
        /// </summary>
        public double Seq {get;set;}

        /// <summary>
        /// 原价 
        /// </summary>
        public decimal OldPrice {get;set;}

        /// <summary>
        /// 现价 
        /// </summary>
        public decimal NewPrice {get;set;}

        /// <summary>
        /// 子账号数量上限 
        /// </summary>
        public int AccountCount {get;set;}

        /// <summary>
        /// 每个岗位可以添加的地址数量 
        /// </summary>
        public int AddressPerJob {get;set;}

        /// <summary>
        /// 每天职位刷新次数限制 
        /// </summary>
        public int JobRefreshPerDayCount {get;set;}

        /// <summary>
        /// 可以获得的积分 
        /// </summary>
        public int Integral {get;set;}

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
