using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 纯数字类型的日期时间转换
    /// </summary>
    public class DatetimeNumberConverter : Newtonsoft.Json.JsonConverter
    {

        /// <summary>
        /// 判断是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
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

            if (reader.TokenType == JsonToken.String && this.CanConvert(objectType))
            {
                var value = reader.Value + "";
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "^\\d{14}$"))
                {
                    string pattarn = @"^([0-9]{4})([0-9]{2})([0-9]{2})(([0-9]{2})([0-9]{2})([0-9]{2}))?$";
                    value = System.Text.RegularExpressions.Regex.Replace(value, pattarn, "$1-$2-$3 $5:$6:$7");

                    if (DateTime.TryParse(value, out DateTime datetime))
                        result = datetime;
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
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && CanConvert(value.GetType()))
            {
                DateTime result = (DateTime)value;

                writer.WriteValue(result.ToString("yyyyMMddhhmmss"));
            }
            else writer.WriteNull();
        }
    }
}
