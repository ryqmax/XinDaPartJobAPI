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

using FrameWork.Common;

namespace FrameWork.Entity.ViewModel.Course
{
    /// <summary>
    /// FreeVideoViewModel
    /// </summary>
    public partial class FreeVideoViewModel
    {
        public FreeVideoViewModel(FreeVideoModel video)
        {

            VideoId = video.VideoId;
            if (string.IsNullOrEmpty(video.VideoUrl))
            {
                VideoUrl = "http://1255590113.vod2.myqcloud.com/7ecfd7c7vodtransgzp1255590113/615dea714564972818902926622/v.f230.m3u8";
            }
            else
            {
                VideoUrl = video.VideoUrl;
            }
            
            VideoImg = PictureHelper.ConcatPicUrl(video.VideoImg);
            VideoCreateTime = video.VideoCreateTime.ToString("yyyy-MM-dd");
            CourseId = video.CourseId;

            VideoBrowsingVolume = video.BrowseCount;
            CategoryName = video.CategoryName;
            CourseName = video.CourseName;
            //ChapterName =video.ChapterName;
            SectionName = video.SectionName;
            SubSctionName = $"{CourseName}/第{video.ChapterSequence.NumberToChinese()}章/第{video.SectionSequence.NumberToChinese()}节";//显示会计/第几章/第几节
            SectionId = video.SectionId;
            SectionDesc = video.SectionDesc;
            TotalCount = video.TotalCount;
        }

        /// <summary>
        /// 视频ID
        /// </summary>
        public int VideoId { get; set; }

        /// <summary>
        /// 视频封面图片地址
        /// </summary>
        public string VideoImg { get; set; }

        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// 视频创建时间
        /// </summary>
        public string VideoCreateTime { get; set; }

        /// <summary>
        /// 视频浏览量
        /// </summary>
        public int VideoBrowsingVolume { get; set; }

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
        /// 章名称--后来修改，只显示“第一章”，三个汉字
        /// </summary>
        //public string ChapterName { get; set; } = string.Empty;

        /// <summary>
        /// 节名称，只显示“第一章”，三个汉字
        /// </summary>
        public string SectionName { get; set; } = string.Empty;

        public string SubSctionName { get; set; } = string.Empty;
        /// <summary>
        /// 小节ID
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// 小节简介
        /// </summary>
        public string SectionDesc { get; set; } = string.Empty;

        /// <summary>
        /// 总个数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
