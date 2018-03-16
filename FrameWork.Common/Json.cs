using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace FrameWork.Common
{
    public static class Json
    {
        public static object ToJson(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// 转成json对象
        /// </summary>
        public static HttpResponseMessage ToJson(this object obj)
        {
            return JsonHelper.ToJson(obj);
        }

        /// <summary>
        /// 转成json字符串
        /// </summary>
        public static string ToJsonStr(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string json)
        {
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 从redis缓存获取出来的json字符串转化为指定的实体
        /// </summary>
        public static T ToTheObject<T>(this string json)
        {
            if (json == null)
                return default(T);
            var jsonObj = JsonConvert.DeserializeObject(json);
            return JsonConvert.DeserializeObject<T>(jsonObj.ToString());
        }

        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<List<T>>(json);
        }
        public static DataTable ToTable(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<DataTable>(json);
        }
        public static JObject ToJObject(this string json)
        {
            return json == null ? JObject.Parse("{}") : JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}
