using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class JobBannerServicecs : BaseService<T_JobBanner>, IJobBannerServicecs
    {
        public List<T_JobBanner> GetJobBannerList()
        {
            var sql = @"SELECT  *
                        FROM dbo.T_JobBanner
                        WHERE   IsUsed = 1
                                AND IsDel = 0; ";
            return DbPartJob.Fetch<T_JobBanner>(sql);
        }
    }
}
