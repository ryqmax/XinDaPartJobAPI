using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Course
{
    public class SubmitVideoUpvoteRequest
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 类型，1.点赞, 0.取消点赞
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }
    }
}
