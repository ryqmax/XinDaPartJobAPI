using System;
using System.Configuration;
using System.IO;
using FrameWork.Common.Models;

namespace FrameWork.Common.ReadSql
{
    public class CachedConfigContext 
    {
        /// <summary>
        /// 重写基类的取配置，加入缓存机制
        /// </summary>
        public T Get<T>(string index = null) where T :  new()
        {
            //var fileName = this.GetConfigFileName<T>(index);
            var value = GetConfigFile<T>(index);
            return value;
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        private T GetConfigFile<T>(string index = null) where T : new()
        {
            var result = new T();

            var fileName = this.GetConfigFileName<T>(index);
            var content = GetConfig(fileName);
            if (content == null)
            {
                SaveConfig(fileName, string.Empty);
            }
            else if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    result = (T)SerializationHelper.XmlDeserialize(typeof(T), content);
                }
                catch
                {
                    result = new T();
                }
            }

            return result;
        }

        /// <summary>
        /// 项目路径
        /// </summary>
        private readonly string _configFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        public string GetConfig(string fileName)
        {
            if (!Directory.Exists(_configFolder))
                Directory.CreateDirectory(_configFolder);

            var configPath = GetFilePath(fileName);
            if (!File.Exists(configPath))
                return null;
            else
                return File.ReadAllText(configPath);
        }

        public void SaveConfig(string fileName, string content)
        {
            var configPath = GetFilePath(fileName);
            File.WriteAllText(configPath, content);
        }

        /// <summary>
        /// 获取该文件的路径
        /// </summary>
        /// <param name="fileName">文件名字</param>
        /// <returns>返回文件在项目里面的项目路径</returns>
        public string GetFilePath(string fileName)
        {
            var configPath = string.Format(@"{0}\{1}.xml", _configFolder, fileName);
            return configPath;
        }

        /// <summary>
        /// 根据web.config的配置信息读取文件
        /// </summary>
        public string GetConfigFileName<T>(string index = null)
        {
            var fileName = typeof(T).Name;
            if (!string.IsNullOrEmpty(index))
                fileName = string.Format("{0}_{1}", fileName, index);
            return fileName;
        }

        /// <summary>
        /// 单利模式
        /// </summary>
        public static CachedConfigContext Current = new CachedConfigContext();

        /// <summary>
        /// 实例化对象，提供访问数据库的对象
        /// </summary>
        public DaoConfig DaoConfig
        {
            get
            {
                return Get<DaoConfig>(ConfigurationManager.AppSettings["publishType"]);
            }
        }

        public CacheConfig CacheConfig
        {
            get
            {
                return this.Get<CacheConfig>();
            }
        }

    }
}
