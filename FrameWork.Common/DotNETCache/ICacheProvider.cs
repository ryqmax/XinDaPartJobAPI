using System;

namespace FrameWork.Common.DotNETCache
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove);
        void Remove(string key);
        void Clear(string keyRegex);
    }
}
