/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPAddressController.cs
 *      Description:
 *            EPAddressController
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 12:27:20
 *      History:
 ***********************************************************************************/

using System;
using System.Linq;
using System.Web.Http;
using FrameWork.Common;
using FrameWork.Common.Const;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel;
using FrameWork.Entity.ViewModel.EPAddress;
using FrameWork.Web;

namespace XinDaPartJobAPI.Controllers
{
    /// <summary>
    /// EPAddressController
    /// </summary>
    public class EPAddressController : AdminControllerBase
    {
        /// <summary>
        /// 获取企业的所有地址列表
        /// </summary>
        [HttpPost]
        [Route("api/EPAddress/GetAddressList")]
        public object GetAddressList(GetAddressListRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var regions = CacheContext.DicRegions;
            var models = EPAddressService.GetAddresseList(redisModel.EPId, request.Type);
            var viewModels = new GetAddressListViewModel().GetViewModels(models, regions, request.Type);
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
        /// 新增地址，根据类型区分兼职、全职、全部
        /// </summary>
        [HttpPost]
        [Route("api/EPAddress/AddEPAddress")]
        public object AddEPAddress(AddEPAddressRequest request)
        {
            var redisModel = RedisInfoHelper.GetRedisModel(request.Token);
            var regions = CacheContext.DicRegions;
            CheckAddress(request);
            var model = new T_EPAddress
            {
                Id = 0,
                Address = request.Address,
                ProvinceId = regions.FirstOrDefault(r => r.Description.Contains(request.Province) && r.ParentId == null)?.Id,
                Type = (byte)request.Type,
                CreateTime = DateTime.Now,
                CreateUserId = redisModel.UserId,
                EnterpriseId = redisModel.EPId,
                IsDel = false,
                Lat = request.Lat,
                Lng = request.Lng,
                ModifyTime = DateTime.Now,
                ModifyUserId = redisModel.UserId
            };
            model.CityId = regions.FirstOrDefault(r => r.Description.Contains(request.City) && r.ParentId == model.ProvinceId)?.Id;
            model.AreaId = regions.FirstOrDefault(r => r.Description.Contains(request.Area) && r.ParentId == model.CityId)?.Id;
            EPAddressService.Add(model);
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
        /// 传递过来的是全地址
        /// </summary>
        private void CheckAddress(AddEPAddressRequest request)
        {
            var addrPros = request.Address.Split('省');
            if (addrPros.Length > 1)
            {
                request.Province = addrPros[0];
                var addrCitys = addrPros[1].Split('市');
                if (addrCitys.Length > 1)
                {
                    request.City = addrCitys[0];
                    var addrAreas = addrCitys[1].Split('区');
                    if (addrAreas.Length > 1)
                    {
                        request.Area = addrAreas[0];
                        request.Address = addrAreas[1];
                    }
                    else
                    {
                        addrAreas = addrCitys[1].Split('县');
                        if (addrAreas.Length > 1)
                        {
                            request.Area = addrAreas[0];
                            request.Address = addrAreas[1];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        [HttpPost]
        [Route("api/EPAddress/DelEPAddress")]
        public object DelEPAddress(DelEPAddressRequest request)
        {
            EPAddressService.DelEPAddress(request.AddressId);
            var result = new BaseViewModel
            {
                Info = CommonData.SuccessStr,
                Message = CommonData.SuccessStr,
                Msg = true,
                ResultCode = CommonData.SuccessCode
            };
            return result;
        }

    }
}