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
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

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
