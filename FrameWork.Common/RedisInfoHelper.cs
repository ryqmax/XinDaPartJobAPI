using System;
using System.Configuration;
using FrameWork.Common.ReadSql;
using Newtonsoft.Json;
using Plugins.Redis;

namespace FrameWork.Common
{
    public class RedisInfoHelper
    {
        /// <summary>
        /// 对外提供可以访问redis缓存的实例
        /// </summary>
        public static RedisManager RedisManager { set; get; }

        /// <summary>
        /// 静态构造函数，初始化各种参数
        /// </summary>
        static RedisInfoHelper()
        {
            var readServerConStr = CachedConfigContext.Current.DaoConfig.ReadServerConStr;
            var redisExample = CachedConfigContext.Current.DaoConfig.RedisExample;
            var redisPassword = CachedConfigContext.Current.DaoConfig.RedisPassword;
            var writeServerConStr = CachedConfigContext.Current.DaoConfig.WriteServerConStr;
            var maxReadPoolSize = Convert.ToInt32(CachedConfigContext.Current.DaoConfig.MaxReadPoolSize);
            var maxWritePoolSize = Convert.ToInt32(CachedConfigContext.Current.DaoConfig.MaxWritePoolSize);
            var autoStart = Convert.ToBoolean(CachedConfigContext.Current.DaoConfig.AutoStart);
            string[] readeServers = { redisExample + redisPassword + "@" + readServerConStr };
            string[] writeServers = { redisExample + redisPassword + "@" + writeServerConStr };
            RedisManager = new RedisManager(readeServers, writeServers, maxWritePoolSize, maxReadPoolSize, autoStart);

            //根据配置切换redis的数据库
            var publishType = ConfigurationManager.AppSettings["publishType"];
            if (!string.IsNullOrEmpty(publishType))
            {
                switch (publishType)
                {
                    case "test":
                        RedisManager.ChangeDb(1);
                        break;
                    case "dev":
                        RedisManager.ChangeDb(2);
                        break;
                }
            }
        }

        /// <summary>
        /// 获取对应key的值
        /// 如果缓存里没有，则取数据然后缓存起来
        /// </summary> 
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="getRealData">缓存值的获取方法</param>
        /// <param name="passDateMinutes">过期时长，单位：分钟，默认30分钟</param>
        /// <returns>返回对应key的值value</returns>
        public static T Get<T>(string key, Func<T> getRealData, int passDateMinutes = 30)
        {
            var data = default(T);
            var cacheData = RedisManager.Getstring(key);

            if (cacheData == null)
            {
                data = getRealData();

                if (data != null)
                {
                    var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore//忽略实体中实体，不再序列化里面包含的实体
                    });
                    var dt = DateTime.Now.AddMinutes(passDateMinutes);
                    RedisManager.Set(key, json, dt);
                }
            }
            else
            {
                var obj = JsonConvert.DeserializeObject(cacheData);//反序列化为object
                data = JsonConvert.DeserializeObject<T>(obj.ToString());//再反序列化为所需要的实体
            }

            return data;
        }
    }
}