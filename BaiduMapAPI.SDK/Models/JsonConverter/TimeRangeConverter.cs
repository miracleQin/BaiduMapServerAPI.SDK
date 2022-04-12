using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 时间范围转换器
    /// </summary>
    public class TimeRangeConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 正则格式
        /// </summary>
        public string Pattern { get; private set; }

        /// <summary>
        /// 时间范围转换器
        /// </summary>
        public TimeRangeConverter()
        {
            this.Pattern = @"^(?<start>[0-9]{1,2}\:[0-9]{1,2}\:[0-9]{1,2}),(?<end>[0-9]{1,2}\:[0-9]{1,2}\:[0-9]{1,2})$";
        }

        /// <summary>
        /// 判断是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(YingYan.V3.FrequentRoute.TimeRange);
        }

        /// <summary>
        /// 从 JSON 取值
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            YingYan.V3.FrequentRoute.TimeRange result = null;

            if (reader.Value != null)
            {
                var input = reader.Value.ToString();

                if (System.Text.RegularExpressions.Regex.IsMatch(input, Pattern))
                {
                    var matches = System.Text.RegularExpressions.Regex.Matches(input, Pattern);
                    TimeSpan start, end;
                    if (TimeSpan.TryParse(matches[0].Value, out start) && TimeSpan.TryParse(matches[1].Value, out end))
                        result = new YingYan.V3.FrequentRoute.TimeRange()
                        {
                            Start = start,
                            End = end
                        };
                }
            }

            return result;
        }

        /// <summary>
        /// 将值转成 JSON
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && CanConvert(value.GetType()))
            {
                YingYan.V3.FrequentRoute.TimeRange data = value as YingYan.V3.FrequentRoute.TimeRange;

                writer.WriteValue($"{data.Start.Value:HH:mm:ss},{data.End.Value:HH:mm:ss}");
            }
            else writer.WriteNull();
        }
    }
}
