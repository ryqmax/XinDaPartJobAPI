using System.Collections.Generic;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    public class JobCategoryServicecs : BaseService<T_JobCategory>, IJobCategoryServicecs
    {
        public List<T_JobCategory> GetJobCategorieList()
        {
            var sql = @"SELECT  *
                        FROM dbo.T_JobCategory
                        WHERE   IsUsed = 1
                                AND IsDel = 0; ";
            return DbPartJob.Fetch<T_JobCategory>(sql);
        }
    }
}
