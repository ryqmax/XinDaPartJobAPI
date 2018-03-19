/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPLoginModel.cs
 *      Description:
 *            EPLoginModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 12:18:35
 *      History:
 ***********************************************************************************/


namespace FrameWork.Entity.Model.Account
{
    /// <summary>
    /// EPLoginModel
    /// </summary>
    public class EPLoginModel
    {
        /// <summary>
        /// 账号类型，1：主账号，2.子账号
        /// </summary>
        public byte Type { set; get; }
    }
}
