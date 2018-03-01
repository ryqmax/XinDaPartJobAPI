/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *				CustomHelper.cs
 *      Description:
 *		    自定义工具类
 *      Author:
 *				yangxianwen
 *							
 *      Finish DateTime:
 *				2016年12月08日
 *      History:
 ***********************************************************************************/

using System;
using System.Configuration;
using System.IO;

namespace FrameWork.Common
{
    public class PictureHelper
    {
        public static string UploadPic(string str)
        {
            //上传图片-----------------------------
            var uppath = ConfigurationManager.AppSettings["TPImageUpPath"]; //获取图片上传路径
            var savepath = ConfigurationManager.AppSettings["TPImageSavePath"]; //获取图片保存数据库中的路径
            var name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png"; //图片名字
            var newFilePath = string.Format(savepath, "MarkingShare"); //图片访问路径,可以通过浏览器访问的地址
            newFilePath += name;
            var filepath = string.Format(uppath, "MarkingShare"); //上传路径
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath += name;
            byte[] msContent = Convert.FromBase64String(str);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            fs.Write(msContent, 0, (int)msContent.Length);
            fs.Close();
            return newFilePath;
        }

        /// <summary>
        /// 拼接图片地址的方法
        /// </summary>
        public static string ConcatPicUrl(string imgUrl)
        {
            var strTpImageHead = ConfigurationManager.AppSettings["TPImageHead"];
            if (!string.IsNullOrEmpty(imgUrl))
                imgUrl = $@"{strTpImageHead}{imgUrl}";
            else
                imgUrl = "";
            return imgUrl;
        }

        /// <summary>
        /// 获取学生的头像地址
        /// </summary>
        public static string GetStudentImg(string imgUrl)
        {
            if (string.IsNullOrEmpty(imgUrl))
                imgUrl = "https://file.nbig.com.cn/default/defaultStudent.png";
            return imgUrl;
        }
    }

}
