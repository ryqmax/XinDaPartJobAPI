/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                GetUserPostPartCVListModel.cs
 *      Description:
 *            GetUserPostPartCVListModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/23 19:38:03
 *      History:
 ***********************************************************************************/


namespace FrameWork.Entity.Model.Job
{
    /// <summary>
    /// GetUserPostPartCVListModel
    /// </summary>
    public class GetUserPostPartCVListModel
    {
        /// <summary>
        /// 简历id
        /// </summary>
        public int CVId { set; get; }

        /// <summary>
        /// 技能简述
        /// </summary>
        public string SkillSummary { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImg { set; get; }
    }
}
