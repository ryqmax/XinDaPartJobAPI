


using System.Collections.Generic;
using FrameWork.Entity.Entity;

namespace FrameWork.Interface
{
    public interface IVIPInfoService:IBaseService<T_VIPInfo>
    {
        /// <summary>
        /// 获取所有的会员信息
        /// </summary>
        List<T_VIPInfo> GetVipInfoList();

        /// <summary>
        /// 获取vip信息详情
        /// </summary>
        T_VIPInfo GetVipInfo(int vipInfoId);
    }
}
