using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    public class LocationListConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>) && objectType.GetGenericArguments()[0] == typeof(Models.Location))
            {
                return true;
            }
            return false;
        }

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

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null) writer.WriteNull();
            else
            {
                writer.WriteValue(string.Join(";", ((List<Models.Location>)value).Select(s => s.ToString())));
            }
        }
    }
}
