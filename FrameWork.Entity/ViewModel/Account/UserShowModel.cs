/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UserShowModel.cs
 *      Description:
 *            UserShowModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 16:09:45
 *      History:
 ***********************************************************************************/

namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// UserShowModel
    /// </summary>
    public class UserShowModel
    {
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; } = "";

        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadImg { get; set; } = "";

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { set; get; }
    }
}
