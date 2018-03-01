using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.ShareVideo
{
    public class SyncByAViewModel
    {
        public SyncByAViewModel()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        /// <param name="bId"></param>
        /// <param name="bName"></param>
        /// <param name="bHeadImg"></param>
        public SyncByAViewModel(EnumShareStatus status, string bId, string bName, string bHeadImg)
        {
            this.ShareStatus = status;
            this.BId = bId;
            this.BName = bName;
            this.BHeadImg = bHeadImg;
        }

        public EnumShareStatus ShareStatus { get; set; }
        public string BId { get; set; }
        public string BName { get; set; }
        public string BHeadImg { get; set; }
    }
}
