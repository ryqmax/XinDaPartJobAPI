using System.Collections.Generic;
using FrameWork.Entity.Entity;

namespace FrameWork.Interface
{
    public interface IJobCategoryServicecs : IBaseService<T_JobCategory>
    {
        List<T_JobCategory> GetJobCategorieList();
    }
}
