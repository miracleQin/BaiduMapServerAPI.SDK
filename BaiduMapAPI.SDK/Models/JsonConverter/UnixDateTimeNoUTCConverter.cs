using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// JSON Unix 时间戳格式转换器
    /// </summary>
    public class UnixDateTimeNoUTCConverter : Newtonsoft.Json.Converters.UnixDateTimeConverter
    {
        internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        /// <summary>
        /// 写入到 JSON 中
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long num;
            if (value is DateTime)
            {
                

                num = (long)(((DateTime)value) - UnixEpoch).TotalSeconds;
            }
            else
            {
                if (!(value is DateTimeOffset))
                {
                    throw new JsonSerializationException("Expected date object value.");
                }

                num = (long)(((DateTimeOffset)value) - UnixEpoch).TotalSeconds;
            }

            if (num < 0)
            {
                throw new JsonSerializationException("Cannot convert date value that is before Unix epoch of 00:00:00 UTC on 1 January 1970.");
            }

            writer.WriteValue(num);
        }
    }
}
