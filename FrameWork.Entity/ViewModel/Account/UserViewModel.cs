/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                UserViewModel.cs
 *      Description:
 *            UserViewModel
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 16:07:02
 *      History:
 ***********************************************************************************/

using FrameWork.Entity.Entity;
using AutoMapper;

namespace FrameWork.Entity.ViewModel.Account
{
    /// <summary>
    /// UserViewModel
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { set; get; }

        /// <summary>
        /// 实体转化为viewmodel
        /// </summary>
        public UserViewModel ToModel(T_User model)
        {
            //第二种情况，字段不一样
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T_User, UserViewModel>()
                    //.ForMember(d => d.CreateTime, opt => opt.MapFrom(s => s.CreateTime.ToString("yy-MM-dd HH:mm:ss")))//格式转化
                    //.ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Name))//指定字段对应
                    //.ForMember(d => d.Age, opt => opt.Condition(s => s.Age > 0))//指定条件赋值
                    .ForMember(d => d.Email, opt => opt.NullSubstitute("Default Value"))//值为空时默认值
                    .ForMember(d => d.Sex, opt => opt.Ignore())//忽略该字段，不给该字段赋值
            );
            var mapper = config.CreateMapper();
            var viewModel = mapper.Map<UserViewModel>(model);

            return viewModel;
        }
    }
}
