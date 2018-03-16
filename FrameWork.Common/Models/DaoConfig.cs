namespace FrameWork.Common.Models
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    //[Serializable]
    public class DaoConfig
    {
        public DaoConfig()
        {
        }
        #region 序列化属性
        public string QuestionBank { get; set; }

        #endregion

        #region redis配置

        /// <summary>
        /// 读redis库链接
        /// </summary>
        public string ReadServerConStr { set; get; }

        /// <summary>
        /// redis实例，redis://:r-bp110f905dd32364:
        /// </summary>
        public string RedisExample { set; get; }

        /// <summary>
        /// redis密码
        /// </summary>
        public string RedisPassword { set; get; }

        /// <summary>
        /// 写服务器密码
        /// </summary>
        public string WriteServerConStr { set; get; }

        /// <summary>
        /// 读应用池最大值
        /// </summary>
        public string MaxReadPoolSize { set; get; }

        /// <summary>
        /// 写应用池最大值
        /// </summary>
        public string MaxWritePoolSize { set; get; }

        /// <summary>
        /// 是否自动启动
        /// </summary>
        public string AutoStart { set; get; }

        #endregion

        /// <summary>
        /// js版本号
        /// </summary>
        public string JsVersion { set; get; }

    }
}
