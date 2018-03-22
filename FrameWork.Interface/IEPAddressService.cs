

using System.Collections.Generic;
using FrameWork.Entity.Entity;

namespace FrameWork.Interface
{
    public interface IEPAddressService:IBaseService<T_EPAddress>
    {
        /// <summary>
        /// 获取该企业下的所有地址列表
        /// </summary>
        /// <param name="epId">企业id</param>
        List<T_EPAddress> GetAddresseList(int epId);

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="addressId">地址id</param>
        int DelEPAddress(int addressId);
    }
}
