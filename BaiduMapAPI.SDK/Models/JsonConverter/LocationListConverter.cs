using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 坐标列表转换器
    /// </summary>
    public class LocationListConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>) && objectType.GetGenericArguments()[0] == typeof(Models.Location))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 从JSON中读取
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = null;
            if (reader.TokenType == JsonToken.String)
            {
                result = new List<Models.Location>();
                var values = (reader.Value + "").Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var value in values)
                {
                    ((List<Models.Location>)result).Add(new Location(value));
                }
            }
            return result;
        }

        /// <summary>
        /// 写入到JSON中
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) writer.WriteNull();
            else
            {
                writer.WriteValue(string.Join(";", ((List<Models.Location>)value).Select(s => $"{s.Lng},{s.Lat}")));
            }
        }
    }
}
