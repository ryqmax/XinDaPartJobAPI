using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.News
{
    /// <summary>
    /// 收藏资讯的接口
    /// </summary>
    public class CollectNewsRequest
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public bool IsCollect { get; set; }//收藏或者取消收藏
    }
}
