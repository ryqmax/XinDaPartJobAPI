using System;

namespace FrameWork.Entity.Entity
{
    public class T_Student
    {
        
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id {get;set;}
        
        /// <summary>
        /// 自己介绍 
        /// </summary>
        public string Description {get;set;}

        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName {get;set;}

        /// <summary>
        /// 性别：0.保密，1.男，女 
        /// </summary>
        public Byte Sex {get;set;}

        /// <summary>
        /// 手机号 
        /// </summary>
        public string Phone {get;set;}

        /// <summary>
        /// 毕业院校 
        /// </summary>
        public string School {get;set;}

        /// <summary>
        /// 毕业专业 
        /// </summary>
        public string Major {get;set;}

        /// <summary>
        /// 工作单位 
        /// </summary>
        public string Company {get;set;}

        /// <summary>
        /// 职位 
        /// </summary>
        public string Position {get;set;}

        /// <summary>
        /// 微信账户唯一标识符
        /// </summary>
        public string OpenId { set; get; }

        /// <summary>
        /// 学号
        /// </summary>
        public string StudyNumber { set; get; }

        /// <summary>
        /// 学生头像
        /// </summary>
        public string HeadImg { set; get; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { set; get; }

        /// <summary>
        /// 学生能量值
        /// </summary>
        public int EnergyCount { set; get; }

        /// <summary>
        /// 是否启用 
        /// </summary>
        public Boolean IsUsed {get;set;}

        /// <summary>
        /// 是否删除 
        /// </summary>
        public Boolean IsDel {get;set;}

        /// <summary>
        /// 编辑人id 
        /// </summary>
        public int ModifyUserId {get;set;}

        /// <summary>
        /// 编辑时间 
        /// </summary>
        public DateTime ModifyTime {get;set;}

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime CreateTime {get;set;}

        /// <summary>
        /// 创建人id 
        /// </summary>
        public int CreateUserId {get;set;}

    }
}
