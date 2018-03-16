/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                RedisModel.cs
 *      Description:
 *            RedisModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/16 17:02:47
 *      History:
 ***********************************************************************************/


namespace FrameWork.Common.Models
{
    /// <summary>
    /// RedisModel
    /// </summary>
    public class RedisModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 企业id
        /// </summary>
        public int EPId { set; get; }

        /// <summary>
        /// 用户标识符 GUID字符串
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 微信账户唯一标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 微信用户名 
        /// </summary>
        public string WxName { get; set; }

        /// <summary>
        /// 当前所在地区id
        /// </summary>
        public string DicRegionId { get; set; }

        /// <summary>
        /// 身份标志，0.缓存失效，1.求职者，2.企业
        /// </summary>
        public int Mark { set; get; }
    }
}
