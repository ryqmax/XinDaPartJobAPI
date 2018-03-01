using System;

namespace FrameWork.Common.ThirdTools.wechatPay
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}