using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 城市置信分列表转换器
    /// </summary>
    public class StatsConfidenceListConverter : Newtonsoft.Json.JsonConverter
    {

        /// <summary>
        /// 判断是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<APIs.RecogAddress.V1.StatsConfidence>);
        }

        /// <summary>
        /// 从 JSON 中读取
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = null;
            if (!string.IsNullOrEmpty(reader.Value + "") && CanConvert(objectType))
            {
                var list = (reader.Value + "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                List<APIs.RecogAddress.V1.StatsConfidence> list_result = new List<APIs.RecogAddress.V1.StatsConfidence>();

                foreach (var item in list)
                {
                    var vals = item.Split(':');
                    APIs.RecogAddress.V1.AdminTypes type;
                    double value;
                    if (Enum.TryParse(vals[0], out type) && double.TryParse(vals[1], out value))
                    {
                        list_result.Add(new APIs.RecogAddress.V1.StatsConfidence()
                        {
                            Type = type,
                            Confidence = value
                        });
                    }

                }

                result = list_result;
            }
            return result;
        }

        /// <summary>
        /// 写入 JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && CanConvert(value.GetType()))
            {
                var list = (List<APIs.RecogAddress.V1.StatsConfidence>)value;

                writer.WriteValue(string.Join(",", list.Select(s => $"{(int)s.Type}:{s.Confidence:0.##}")));
            }
            else writer.WriteNull();
        }
    }
}
