/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                LogService.cs
 *      Description:
 *            LogService
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 19:02:44
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Entity.Entity;
using FrameWork.Interface;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// LogService
    /// </summary>
    public class StudentService : BaseService<T_Student>,IStudentService
    {
        /// <summary>
        /// 获取用户真实姓名
        /// </summary>
        public T_Student GetStudentByOpenId(string openId)
        {
            // todo
            //var stu = new T_Student();
            //stu.HeadImg = openId;
            //stu.UserName = openId;
            //stu.Id = 1;
            //return stu;
            return DbQuestionBank.Single<T_Student>("WHERE IsDel = 0 AND OpenId = @0", openId);
        }
    }
}
