/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UploadImgViewModel.cs
 *      Description:
 *            UploadImgViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/21 12:30:24
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.EP
{
    /// <summary>
    /// UploadImgRequest
    /// </summary>
    public class UploadImgRequest
    {
        /// <summary>
        /// base64码
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// 返回给调用方的数据
    /// </summary>
    public class UploadImgViewModel
    {
        /// <summary>
        /// 小程序图片展示地址，这个地址只用于展示
        /// </summary>
        public string ShowUrl { set; get; }

        /// <summary>
        /// 保存到数据库的图片地址，接口提交时传递这个值
        /// </summary>
        public string SaveUrl { set; get; }
    }
}
