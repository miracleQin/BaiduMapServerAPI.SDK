using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationDetailListConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 判断你是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>) && objectType.GetGenericArguments()[0] == typeof(Models.LocationDetail);
        }

        /// <summary>
        /// 从 JSON 中读取
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<LocationDetail> result = null;
            if (reader.TokenType == JsonToken.String && CanConvert(objectType))
            {
                result = new List<LocationDetail>();

                var items = reader.Value.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in items)
                {
                    var vals = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (double.TryParse(vals[0], out double lat) && double.TryParse(vals[1], out double lng))
                        result.Add(new LocationDetail()
                        {
                            Latitude = lat,
                            Longitude = lng
                        });
                }
            }

            return result;
        }

        /// <summary>
        /// 写入 JSON 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && CanConvert(value.GetType()))
            {
                var list = value as List<LocationDetail>;

                writer.WriteValue(string.Join(";", list.Select(s => $"{s.Latitude},{s.Longitude}")));
            }
            else writer.WriteNull();
        }
    }
}
