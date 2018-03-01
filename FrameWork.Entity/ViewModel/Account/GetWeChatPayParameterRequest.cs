using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Account
{
    public class GetWeChatPayParameterRequest
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }
        
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        public string OpenId { set; get; }
    }
}
