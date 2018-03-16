using System;
using PetaPoco;

namespace FrameWork.Entity.Entity
{
    [TableName("T_EPOrder")]
    [PrimaryKey("Id")]
    public class T_EPOrder
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
        /// 商户订单号，接口生成的订单号 
        /// </summary>
        public string OutTradeNo {get;set;}

        /// <summary>
        /// 第三方支付平台生成的订单号 
        /// </summary>
        public string TradeNo {get;set;}

        /// <summary>
        /// 支付金额 
        /// </summary>
        public Decimal Price {get;set;}

        /// <summary>
        /// 购买商品数量 
        /// </summary>
        public int Count {get;set;}

        /// <summary>
        /// 购买的商品类型：0.会员，1.简历，2.广告位 
        /// </summary>
        public Byte Type {get;set;}

        /// <summary>
        /// 购买的商品的id：0.会员id，1.简历id 
        /// </summary>
        public int KeyId {get;set;}

        /// <summary>
        /// 支付状态：0.未支付，1.支付中，2.支付成功，3.支付失败 
        /// </summary>
        public Byte Status {get;set;}

        /// <summary>
        /// 支付备注 
        /// </summary>
        public string Note {get;set;}

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
