/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                EPAddressService.cs
 *      Description:
 *            EPAddressService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2018/3/22 12:23:46
 *      History:
 ***********************************************************************************/


using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// EPAddressService
    /// </summary>
    public class EPAddressService : BaseService<T_EPAddress>, IEPAddressService
    {
        /// <summary>
        /// 获取该企业下的所有地址列表
        /// </summary>
        /// <param name="epId">企业id</param>
        /// <param name="type">0.全部，1.兼职，2.全职 </param>
        public List<T_EPAddress> GetAddresseList(int epId, int type)
        {
            var where = "";
            if(type>0)
                where = $" AND Type = {type}";
            var sql = $@";SELECT * FROM dbo.T_EPAddress WHERE EnterpriseId = @epId AND IsDel = 0 {where}";
            return DbPartJob.Fetch<T_EPAddress>(sql, new { epId });
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="addressId">地址id</param>
        public int DelEPAddress(int addressId)
        {
            var sql = @";UPDATE dbo.T_EPAddress SET IsDel = 1 WHERE Id = @addressId";
            return DbPartJob.Execute(sql, new { addressId });
        }
    }
}
