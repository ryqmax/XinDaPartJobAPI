using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetUserInfoRequest
    {
        /// <summary>
        /// 微信账号
        /// </summary>
        public string WeChatAccount { set; get; }
        
        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImg { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { set; get; }

        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName { get; set; }
    }
}
