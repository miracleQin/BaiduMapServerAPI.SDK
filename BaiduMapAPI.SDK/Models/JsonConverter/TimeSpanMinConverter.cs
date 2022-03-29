using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 时间类型按分钟转换
    /// </summary>
    public class TimeSpanMinConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            TimeSpan? result = null;

            if (reader.Value != null && reader.TokenType == JsonToken.Integer)
            {
                var value = reader.ReadAsInt32().Value;
                int hours = value / 60;
                int minutes = value % 60;
                result = new TimeSpan(hours, minutes, 0);
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && (value is TimeSpan || value is TimeSpan?))
            {
                int mins = 0;
                if (value is TimeSpan) mins = ((TimeSpan)value).Hours * 60 + ((TimeSpan)value).Minutes;
                else mins = ((TimeSpan?)value).Value.Hours * 60 + ((TimeSpan?)value).Value.Minutes;
                writer.WriteValue(mins);
            }
            else writer.WriteNull();
        }
    }
}
