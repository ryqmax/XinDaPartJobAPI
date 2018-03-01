using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace FrameWork.Common.ThirdTools.wechatPay
{
    public class NativePay
    {
        /**
        * 生成扫描支付模式一URL
        * @param productId 商品ID
        * @return 模式一URL
        */
        public string GetPrePayUrl(string productId)
        {
            Log.Info(this.GetType().ToString(), "Native pay mode 1 url is producing...");

            WxPayData data = new WxPayData();
            data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
            data.SetValue("mch_id", WxPayConfig.MCHID);//商户号
            data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("product_id", productId);//商品ID
            data.SetValue("sign", data.MakeSign());//签名
            string str = ToUrlParams(data.GetValues());//转换为URL串
            string url = "weixin://wxpay/bizpayurl?" + str;

            Log.Info(this.GetType().ToString(), "Get native pay mode 1 url : " + url);
            return url;
        }

        /**
        * 生成直接支付url，支付url有效期为2小时,模式二
        * @param productId 商品ID
        * @return 模式二URL
        */
        public string GetPayUrl(string productId)
        {
            Log.Info(this.GetType().ToString(), "Native pay mode 2 url is producing...");

            WxPayData data = new WxPayData();
            data.SetValue("body", "test");//商品描述
            data.SetValue("attach", "test");//附加数据
            data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串
            data.SetValue("total_fee", 1);//总金额
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
            data.SetValue("goods_tag", "jjj");//商品标记
            data.SetValue("trade_type", "NATIVE");//交易类型
            data.SetValue("product_id", productId);//商品ID

            WxPayData result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
            string url = result.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

            Log.Info(this.GetType().ToString(), "Get native pay mode 2 url : " + url);
            return url;
        }

        /// <summary>
        /// 生成直接支付url，支付url有效期为2小时,模式二
        /// 微信支付统一下单后的返回数据
        /// 模式二
        /// </summary>
        /// <returns>数据里面有prepay_id和二维码链接code_url</returns>
        public WxPayData GetWxPayData(GetWxPayDataModel model)
        {
            WxPayData data = new WxPayData();
            data.SetValue("body", model.Body);//商品描述
            data.SetValue("attach", model.Attach);//附加数据
            data.SetValue("out_trade_no", model.OutTradeNo);//随机字符串
            data.SetValue("total_fee", model.TotalFee);//总金额
            data.SetValue("time_start", model.TimeStart);//交易起始时间
            data.SetValue("time_expire", model.TimeExpire);//交易结束时间
            data.SetValue("goods_tag", model.GoodsTag);//商品标记
            data.SetValue("trade_type", model.TradeType);//交易类型
            data.SetValue("product_id", model.ProductId);//商品ID

            WxPayData result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
            return result;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="codeUrl">微信返回的二维码图片地址</param>
        /// <param name="filePath">二维码图片存放的地址</param>
        public void MakeQrCode(string codeUrl,string filePath)
        {
            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder
            {
                QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M,
                QRCodeVersion = 0,
                QRCodeScale = 4
            };
            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(codeUrl, Encoding.Default);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            image.Save(filePath, ImageFormat.Jpeg);
        }


        /**
      *  
      * 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数，
      * 微信浏览器调起JSAPI时的输入参数格式如下：
      * {
      *   "appId" : "wx2421b1c4370ec43b",     //公众号名称，由商户传入     
      *   "timeStamp":" 1395712654",         //时间戳，自1970年以来的秒数     
      *   "nonceStr" : "e61463f8efa94090b1f366cccfbbb444", //随机串     
      *   "package" : "prepay_id=u802345jgfjsdfgsdg888",     
      *   "signType" : "MD5",         //微信签名方式:    
      *   "paySign" : "70EA570631E4BB79628FBCA90534C63FF7FADD89" //微信签名 
      * }
      * @return string 微信浏览器调起JSAPI时的输入参数，json格式可以直接做参数用
      * 更详细的说明请参考网页端调起支付API：http://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_7
      * 
      */
        /// <summary>
        /// 获取json参数返回给前端使用
        /// </summary>
        /// <param name="data">统一下单之后的返回数据</param>
        /// <returns>json参数串，返回给前端使用</returns>
        public string GetJsApiParameters(WxPayData data)
        {
            Log.Debug(this.GetType().ToString(), "JsApiPay::GetJsApiParam is processing...");

            WxPayData jsApiParam = new WxPayData();
            jsApiParam.SetValue("appId", data.GetValue("appid"));
            jsApiParam.SetValue("timeStamp", WxPayApi.GenerateTimeStamp());
            jsApiParam.SetValue("nonceStr", WxPayApi.GenerateNonceStr());
            jsApiParam.SetValue("package", "prepay_id=" + data.GetValue("prepay_id"));
            jsApiParam.SetValue("signType", "MD5");
            jsApiParam.SetValue("paySign", jsApiParam.MakeSign());

            string parameters = jsApiParam.ToJson();

            Log.Debug(this.GetType().ToString(), "Get jsApiParam : " + parameters);
            return parameters;
        }



        /**
        * 参数数组转换为url格式
        * @param map 参数名与参数值的映射表
        * @return URL字符串
        */
        private string ToUrlParams(SortedDictionary<string, object> map)
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in map)
            {
                buff += pair.Key + "=" + pair.Value + "&";
            }
            buff = buff.Trim('&');
            return buff;
        }
    }
}