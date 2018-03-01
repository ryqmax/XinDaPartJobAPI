using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FrameWork.Common;
using FrameWork.Entity.Entity;

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetUserInfoViewModel
    {
        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别：0.保密，1.男，女 
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 毕业院校 
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 毕业专业 
        /// </summary>
        public string Major { get; set; }

        /// <summary>
        /// 工作单位 
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 职位 
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 微信账户唯一标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 学号
        /// </summary>
        public string StudyNumber { set; get; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { set; get; }

        /// <summary>
        /// 实体转化为
        /// </summary>
        public GetUserInfoViewModel GetViewModel(T_Student model)
        {
            var viewModel = new GetUserInfoViewModel
            {
                UserId = model.Id,
                Company = StringHelper.NullOrEmpty(model.Company),
                Major = StringHelper.NullOrEmpty(model.Major),
                Phone = StringHelper.NullOrEmpty(model.Phone),
                Position = StringHelper.NullOrEmpty(model.Position),
                School = StringHelper.NullOrEmpty(model.School),
                Sex = model.Sex,
                UserName = StringHelper.NullOrEmpty(model.UserName),
                OpenId = StringHelper.NullOrEmpty(model.OpenId),
                StudyNumber = model.StudyNumber ?? string.Empty,
                RealName = model.RealName ?? string.Empty
            };
            return viewModel;
        }
    }
}
