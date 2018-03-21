/************************************************************************************
 *      Copyright (C) 2017 liwei,All Rights Reserved
 *      File:
 *                EPController.cs
 *      Description:
 *            EPController
 *            企业相关操作
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/19 21:37:12
 *      History:
 ***********************************************************************************/


using System;
using System.IO;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.EP;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// 企业相关
    /// </summary>
    public class EPController : AdminControllerBase
    {
        /// <summary>
        /// 获取招聘联系人列表
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPContacts")]
        public object GetEPContacts(GetEPContactsRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var models = EPService.GetEpContacts(redisModel.EPId);
            var viewModels = new GetEPContactsViewModel().GetvViewModels(models);
            var result = new BaseViewModel
            {
                Info = viewModels,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 保存招聘联系人
        /// </summary>
        [HttpPost]
        [Route("api/EP/SaveEPContacts")]
        public object SaveEPContacts(SaveEPContactsRequest request)
        {
            EPService.SaveEPContacts(request, RedisInfoHelper.GetRedisModel(request.Token).EPId);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 删除招聘联系人
        /// </summary>
        [HttpPost]
        [Route("api/EP/DelEPContacts")]
        public object DelEPContacts(DelEPContactsRequest request)
        {
            EPService.DelEPContacts(request.EPContactsId);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 校验手机号验证码
        /// </summary>
        [HttpPost]
        [Route("api/EP/CheckPhoneCode")]
        public object CheckPhoneCode(CheckPhoneCodeRequest request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            if (string.IsNullOrEmpty(request.VerifyCode))//验证码不能为空
            {
                result.Info = CommonData.CodeNotNULL;
                result.Message = CommonData.CodeNotNULL;
                return result;
            }
            var oldCode = RedisInfoHelper.RedisManager.Getstring(request.Phone);
            if (!string.IsNullOrEmpty(oldCode))//缓存未过期
            {
                oldCode = oldCode.Replace("\"", "");
                if (!oldCode.Equals(request.VerifyCode))//验证码不正确
                {
                    result.Info = CommonData.CodeNotCorrect;
                    result.Message = CommonData.CodeNotCorrect;
                    return result;
                }
            }
            else   //缓存过期
            {
                result.Info = CommonData.CodePassdate;
                result.Message = CommonData.CodePassdate;
                return result;
            }
            result = new BaseViewModel  //验证码正确
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 上传图片接口
        /// </summary>
        [HttpPost]
        [Route("api/EP/UploadImg")]
        public object UploadImg(UploadImgRequest img)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            var uppath = CommonData.TPImageUpPath; //获取图片上传路径
            var savepath = CommonData.TPImageSavePath; //获取图片保存数据库中的路径

            var name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";  //图片命名
            var newFilePath = string.Format(savepath, "userphoto");
            newFilePath += name;
            var filepath = string.Format(uppath, "userphoto");
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath += name;
            var msContent = Convert.FromBase64String(img.Content);
            var fs = new FileStream(filepath, FileMode.Create);
            fs.Write(msContent, 0, (int)msContent.Length);
            fs.Close();
            result.Info = new UploadImgViewModel { ShowUrl = PictureHelper.ConcatPicUrl(newFilePath), SaveUrl = newFilePath };
            return result.ToJson();
        }
    }
}
