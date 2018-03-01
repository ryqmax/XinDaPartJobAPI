using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel.ShareVideo
{
    public class SyncByBViewModel
    {
        public SyncByBViewModel()
        {
            //Joined = false;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        /// <param name="aId"></param>
        /// <param name="aName"></param>
        /// <param name="aHeadImg"></param>
        public SyncByBViewModel(bool joined, EnumShareStatus status, string aId, string aName, string aHeadImg, EnumAPlayStatus playStatus, int playTime)
        {
            Joined = joined;
            ShareStatus = status;
            AId = aId;
            AName = aName;
            AHeadImg = aHeadImg;
            APlayStatus = playStatus;
            PlayTime = playTime;
        }

        /// <summary>
        /// 只有在别人已经加入，自己再打开的时候才为false
        /// </summary>
        public bool Joined { get; set; }
        public EnumShareStatus ShareStatus { get; set; }
        public string AId { get; set; }
        public string AName { get; set; }
        public string AHeadImg { get; set; }

        public EnumAPlayStatus APlayStatus { get; set; }

        /// <summary>
        /// 播放时间，s为单位
        /// </summary>
        public int PlayTime { get; set; }
    }
}
