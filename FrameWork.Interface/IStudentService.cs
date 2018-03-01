using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Entity.ViewModel.Account;

namespace FrameWork.Interface
{
    public interface IStudentService : IBaseService<T_Student>
    {

        /// <summary>
        /// 获取用户真实姓名
        /// </summary>
        /// <returns></returns>
        T_Student GetStudentByOpenId(string openId);
    }
}
