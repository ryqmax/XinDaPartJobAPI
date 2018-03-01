/************************************************************************************
 *      Copyright (C) 2015 yuwei,All Rights Reserved
 *      File:
 *                AssemblyHelper.cs
 *      Description:
 *            AssemblyHelper
 *      Author:
 *                yxw
 *                
 *                
 *      Finish DateTime:
 *                2017/12/4 18:13:35
 *      History:
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FrameWork.Web
{
    /// <summary>
    /// AssemblyHelper
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// 扫描程序集找到实现了某个接口的第一个实例
        /// </summary>
        /// <typeparam name="T">类型名称</typeparam>
        /// <param name="searchpattern">文件名过滤</param>
        /// <returns>实例化接口之后的实例</returns>
        public static T FindTypeByInterface<T>(string searchpattern = "*.dll") where T : class
        {
            var interfaceType = typeof(T);

            var domain = GetBaseDirectory();
            var dllFiles = Directory.GetFiles(domain, searchpattern, SearchOption.TopDirectoryOnly);

            foreach (var dllFileName in dllFiles)
            {
                foreach (Type type in Assembly.LoadFrom(dllFileName).GetLoadableTypes())
                {
                    if (interfaceType != type && interfaceType.IsAssignableFrom(type))
                    {
                        var instance = Activator.CreateInstance(type) as T;
                        return instance;
                    }
                }
            }

            return null;
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        /// <summary>
        /// 得到当前应用程序的根目录
        /// </summary>
        /// <returns></returns>
        public static string GetBaseDirectory()
        {
            var baseDirectory = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;

            if (AppDomain.CurrentDomain.SetupInformation.PrivateBinPath == null)
                baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return baseDirectory;
        }
    }
}
