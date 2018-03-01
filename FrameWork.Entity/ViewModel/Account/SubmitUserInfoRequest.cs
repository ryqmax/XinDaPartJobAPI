

namespace FrameWork.Entity.ViewModel.Account
{
    public class SubmitUserInfoRequest
    {
        /// <summary>
        /// 学员用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别：0.保密，1.男，女 
        /// </summary>
        public string Sex { get; set; }

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
        /// 职位 
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 手机验证码
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

    }
}
