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

using System;

namespace FrameWork.Entity.ViewModel
{
    /// <summary>
    /// FreeVideoViewModel
    /// </summary>
    public partial class FreeVideoModel
    {
        /// <summary>
        /// 视频ID
        /// </summary>
        public int VideoId { get; set; }
        /// <summary>
        /// 视频封面图片地址
        /// </summary>
        public string VideoImg { get; set; }

        /// <summary>
        /// 章序号
        /// </summary>
        public int ChapterSequence { get; set; }

        /// <summary>
        /// 节序号
        /// </summary>
        public int SectionSequence { get; set; }


        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// 视频更新时间
        /// </summary>
        public DateTime VideoCreateTime { get; set; }
        /// <summary>
        /// 视频浏览量
        /// </summary>
        public int BrowseCount { get; set; }
        /// <summary>
        /// 大类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 课程Id
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// 章名称
        /// </summary>
        public string ChapterName { get; set; }
        /// <summary>
        /// 节名称
        /// </summary>
        public string SectionName { get; set; }
        /// <summary>
        /// 小节ID
        /// </summary>
        public int SectionId { get; set; }
        /// <summary>
        /// 小节简介
        /// </summary>
        public string SectionDesc { get; set; }
        /// <summary>
        /// 总个数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
