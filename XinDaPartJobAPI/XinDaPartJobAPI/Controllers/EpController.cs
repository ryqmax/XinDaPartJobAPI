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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Common.Models;
using FrameWork.Entity.Entity;
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
        /// 获取联系人详情
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPContactsDetails")]
        public object GetEPContactsDetails(GetEPContactsDetailsRequest request)
        {
            var model = EPService.GetEPContactsDetails(request.EPContactsId);
            var viewModel = new GetEPContactsDetailsViewModel().GetViewModel(model);
            var result = new BaseViewModel
            {
                Info = viewModel,
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
        public object UploadImg()
        {
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };

            var runTime = (HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime");
            var maxRequestLength = (runTime.MaxRequestLength) * 1024;
            if (HttpContext.Current.Request.ContentLength > maxRequestLength)
            {
                throw new Exception();
            }
            var file = HttpContext.Current.Request.Files[0];
            if (file == null)
            {
                throw new Exception();
            }
            var uppath = CommonData.TPImageUpPath; //获取图片上传路径
            var savepath = CommonData.TPImageSavePath; //获取图片保存数据库中的路径

            var name = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";  //图片命名
            var newFilePath = string.Format(savepath, "userphoto");
            newFilePath += name;
            var filepath = string.Format(uppath, "userphoto");
            {
                #region 保存图片
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                filepath += name;
                var bmp = new Bitmap(file.InputStream);
                var newbmp = new Bitmap(bmp);
                newbmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                #endregion
            }
            //var filepath = string.Format(uppath, "userphoto");
            //if (!Directory.Exists(filepath))
            //{
            //    Directory.CreateDirectory(filepath);
            //}
            //filepath += name;
            //var msContent = Convert.FromBase64String(img.Content);
            //var fs = new FileStream(filepath, FileMode.Create);
            //fs.Write(msContent, 0, (int)msContent.Length);
            //fs.Close();
            result.Info = new UploadImgViewModel { ShowUrl = PictureHelper.ConcatPicUrl(newFilePath), SaveUrl = newFilePath };
            return result.ToJson();
        }

        /// <summary>
        /// 获取子账号列表
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetAccountList")]
        public object GetAccountList(GetAccountListRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var models = EPService.GetAccountList(redisModel.EPId, redisModel.CityId);
            var viewModel = new GetAccountListViewModel().GetViewModels(models);
            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 新增或修改子账号，修改主账号手机号
        /// </summary>
        [HttpPost]
        [Route("api/EP/AddOrEditAccount")]
        public object AddOrEditAccount(AddOrEditAccountRequest request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            if (!redisModel.IsMainAccount)//如果不是主账号，没有权限修改
            {
                result.Info = CommonData.NoAuth;
                result.Message = CommonData.NoAuth;
                return result;
            }
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

            var res = EPService.AddOrEditAccount(request.Phone, redisModel.EPId, request.SubAccoundId);
            if (res < 0)
            {
                result.Info = CommonData.PhoneHasBind;
                result.Message = CommonData.PhoneHasBind;
                return result;
            }
            result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 注销子账号
        /// </summary>
        [HttpPost]
        [Route("api/EP/DelAccount")]
        public object DelAccount(DelAccountRequest request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            if (!redisModel.IsMainAccount)//如果不是主账号，没有权限修改
            {
                result.Info = CommonData.NoAuth;
                result.Message = CommonData.NoAuth;
                return result;
            }
            EPService.DelAccount(request.SubAccoundId);
            result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取子账号权限
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetAccountPermission")]
        public object GetAccountPermission(GetAccountPermissionRequest request)
        {
            var model = EPService.GetAccount(request.SubAccoundId);
            var allPermissins = EPService.GetAllPermissions();
            var viewModels = new GetAccountPermissionViewModel().GetViewModel(allPermissins, model);
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
        /// 保存子账号权限
        /// </summary>
        [HttpPost]
        [Route("api/EP/SaveAccountPermission")]
        public object SaveAccountPermission(SaveAccountPermissionRequest request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            if (!redisModel.IsMainAccount)//如果不是主账号，没有权限修改
            {
                result.Info = CommonData.NoAuth;
                result.Message = CommonData.NoAuth;
                return result;
            }
            var model = EPService.GetAccount(request.SubAccoundId);
            if (model != null)
            {
                model.PermissionIds = model.PermissionIds ?? "/";
                if (request.IsUsed)//启用该权限
                {
                    if (!model.PermissionIds.Contains(request.MenuId + ""))//不包含该权限
                    {
                        model.PermissionIds = $"{model.PermissionIds }{ request.MenuId  }/";
                    }
                }
                else  //禁用该权限
                {
                    if (model.PermissionIds.Contains(request.MenuId + ""))//包含该权限
                    {
                        model.PermissionIds = model.PermissionIds.Replace(request.MenuId + "/", "");
                    }
                }
                EPService.UpdateAccountPer(model.Id, model.PermissionIds);
            }
            result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取企业详情
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPDetailInfo")]
        public object GetEPDetailInfo(GetEPDetailInfoReq request)
        {
            var result = new BaseViewModel
            {
                Info = CommonData.FailStr,
                Message = CommonData.FailStr,
                Msg = false,
                ResultCode = CommonData.FailCode
            };
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var epDetailInfo = EPService.GetEpDetailInfoById(redisModel.EPId);
            var getEPDetailInfoRespInfo = new GetEPDetailInfoRespInfo
            {
                CompanyId = epDetailInfo.CompanyId,
                CompanyEmployerId = (int)epDetailInfo.CompanyEmployerId,
                CompanyEmployerName = epDetailInfo.CompanyEmployerName,
                CompanyName = epDetailInfo.CompanyName,
                CompanyAddress = epDetailInfo.CompanyAddress,
                CompanyFullName = epDetailInfo.CompanyFullName,
                CompanyDesc = epDetailInfo.CompanyDesc
            };

            //获取企业发布的岗位列表
            var epJobList = EPService.GetEpJobListById(redisModel.EPId);
            getEPDetailInfoRespInfo.JobList = epJobList;
            //获取企业的实景图片列表
            var epImgList = EPService.GetEpImgListById(redisModel.EPId);
            getEPDetailInfoRespInfo.CompanyImgList = epImgList;

            result = new BaseViewModel
            {
                Info = getEPDetailInfoRespInfo,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 保存企业信息,认证企业
        /// </summary>
        [HttpPost]
        [Route("api/EP/SaveEP")]
        public object SaveEP(SaveEPRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            //var redisModel = new RedisModel { EPId = 7, UserId = 1 };
            var regionModel = RegionHelper.CheckAddress(request.CompanyAddress);
            var regions = CacheContext.DicRegions;
            regionModel.ProvinceId = regions.FirstOrDefault(r => r.Description.Contains(regionModel.Province) && r.ParentId == null)?.Id ?? string.Empty;
            regionModel.CityId = regions.FirstOrDefault(r => r.Description.Contains(regionModel.City) && r.ParentId == regionModel.ProvinceId)?.Id ?? string.Empty;
            regionModel.AreaId = regions.FirstOrDefault(r => r.Description.Contains(regionModel.Area) && r.ParentId == regionModel.CityId)?.Id ?? string.Empty;
            if (string.IsNullOrEmpty(request.AuthPicUrl))//认证图片为空，不能认证
                request.IsAuth = false;
            EPService.SaveEP(redisModel, request, regionModel);
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
        /// 获取企业认证信息
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPAuth")]
        public object GetEPAuth(GetEPAuthRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            //var redisModel = new RedisModel { EPId = 7, UserId = 1 };
            var regions = CacheContext.DicRegions;
            var model = EPService.GetEnterprise(redisModel.EPId);
            var imgs = EPService.GetBgImgs(redisModel.EPId);
            var viewModel = new GetEPAuthViewModel().GetViewModel(model, regions, imgs);

            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

        /// <summary>
        /// 获取企业中心信息
        /// </summary>
        [HttpPost]
        [Route("api/EP/GetEPCenter")]
        public object GetEPCenter(GetEPCenterRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            //var redisModel = new RedisModel { EPId = 1, UserId = 1, CityId = "3202" };
            var model = EPService.GetEPCenter(redisModel);
            var viewModel = new GetEPCenterViewModel().GetViewModel(model);
            var result = new BaseViewModel
            {
                Info = viewModel,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }
    }
}
