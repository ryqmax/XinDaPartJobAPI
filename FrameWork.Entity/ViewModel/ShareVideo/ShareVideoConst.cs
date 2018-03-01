using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Entity.ViewModel
{
    /// <summary>
    /// 链接存在的状态
    /// </summary>
    public enum EnumShareStatus
    {
        AWaiting = 1, //分享出去后A等待
        Connectted = 2,

        //AWaitingB5Sec = 3,//用不到
        //BWaitingA5Sec = 4,//用不到
        Closed = 5
    }

    /// <summary>
    /// A播放状态
    /// </summary>
    public enum EnumAPlayStatus
    {
        Normal = 1,//正常
        Quick = 2,//快进
        Stop = 3//停止
    }
}
