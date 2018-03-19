using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;

namespace FrameWork.Interface
{
    public interface IDicRegionService : IBaseService<DicRegion>
    {
        /// <summary>
        /// 获取所有的地区列表
        /// </summary>
        List<DicRegion> GetAlList();
    }
}
