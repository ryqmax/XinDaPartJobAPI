/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *				GetWxPayDataModel.cs
 *      Description:
 *		    获取微信二维码参数
 *      Author:
 *				yangxianwen
 *				
 *				
 *      Finish DateTime:
 *				2016年12月29日
 *      History:
 ***********************************************************************************/

namespace FrameWork.Common.ThirdTools.wechatPay
{
    public class GetWxPayDataModel
    {
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Body { set; get; }

        /// <summary>
        /// 附加数据
        /// </summary>
        public string Attach { set; get; }

        /// <summary>
        /// 订单号，接口生成的订单号
        /// </summary>
        public string OutTradeNo { set; get; }

        /// <summary>
        /// 总价格，单位：分
        /// </summary>
        public int TotalFee { set; get; }

        /// <summary>
        /// 交易起始时间
        /// DateTime.Now.ToString("yyyyMMddHHmmss")
        /// </summary>
        public string TimeStart { set; get; }

        /// <summary>
        /// 交易结束时间
        /// DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss")
        /// </summary>
        public string TimeExpire { set; get; }

        /// <summary>
        /// 商品标记
        /// </summary>
        public string GoodsTag { set; get; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { set; get; } = "NATIVE";

        /// <summary>
        /// 商品id
        /// </summary>
        public string ProductId { set; get; }
    }
}
