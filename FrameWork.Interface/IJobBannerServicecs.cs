using System.Collections.Generic;
using FrameWork.Entity.Entity;

namespace FrameWork.Interface
{
    public interface IJobBannerServicecs : IBaseService<T_JobBanner>
    {
        List<T_JobBanner> GetJobBannerList();
    }
}
