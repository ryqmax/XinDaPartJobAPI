
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FrameWork.Common.Models
{
    public class CommonEnum
    {
    }

    /// <summary>
    /// 身份标志，0.缓存失效，1.求职者，2.企业
    /// </summary>
    public enum TokenMarkEnum
    {
        /// <summary>
        /// 0.缓存失效
        /// </summary>
        [Description("缓存失效")]
        CacheInvalid,
        /// <summary>
        /// 1.求职者
        /// </summary>
        [Description("求职者")]
        User,
        /// <summary>
        /// 2.企业
        /// </summary>
        [Description("企业")]
        Enterprise
    }
}
