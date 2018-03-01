using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Course
{
    public class SubmitVideoProgressRequest
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
        /// 是否结束
        /// </summary>
        public bool IsFinished { set; get; }

        /// <summary>
        /// 视频进度。单位：秒
        /// </summary>
        public int Progress { set; get; }
    }
}
