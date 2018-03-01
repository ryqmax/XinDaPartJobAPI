using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.Course
{
    public class SubmitVideoCollectionRequest
    {
        /// <summary>
        /// 小节视频id
        /// </summary>
        public int SectionVideoId { set; get; }

        /// <summary>
        /// 类型，1.收藏, 0.取消收藏
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { set; get; }
    }
}
