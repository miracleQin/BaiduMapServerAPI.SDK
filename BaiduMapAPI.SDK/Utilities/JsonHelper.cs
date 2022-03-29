using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text
{
    /// <summary>
    /// JSON 辅助类
    /// </summary>
    internal static class JsonHelper
    {

        /// <summary>
        /// 将 JSON 字符串转为指定实体
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        internal static TModel FromJson<TModel>(this string json)
        {
            return string.IsNullOrEmpty(json) ? default : Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(json);
        }

        /// <summary>
        /// 将对象转为 Json 字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string ToJson(this object obj)
        {


            return obj == null ? null : Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings() { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
        }
    }
}
