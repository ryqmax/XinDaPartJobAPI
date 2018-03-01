using System;

namespace FrameWork.Common
{
    public class GuidHelper
    {
        /// <summary>
        /// 生成数据库主键值
        /// </summary>
        /// <returns></returns>
        public static string GetPrimarykey()
        {
            return Guid.NewGuid().ToString("N").ToLower();
        }
        /// <summary>
        /// 获取唯一编码
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
