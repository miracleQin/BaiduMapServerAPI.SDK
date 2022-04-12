using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 与运算枚举转换器
    /// </summary>
    public class FlagEnumConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 与运算枚举转换器
        /// </summary>
        public FlagEnumConverter()
        {
            this.IdentityID = Guid.NewGuid();
        }
        /// <summary>
        /// 实例化对象唯一标识
        /// </summary>
        public Guid IdentityID { get; private set; }
        private Type tagType;
        private Dictionary<int, string> Options { get; set; } = new Dictionary<int, string>();

        /// <summary>
        /// 判断是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            bool result = false;


            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                tagType = objectType.GetGenericArguments()[0];
            }
            else tagType = objectType;

            if (tagType.IsEnum)
            {
                var fields = tagType.GetFields(BindingFlags.Static | BindingFlags.Public);

                foreach (var field in fields)
                {
                    var number = (int)Enum.Parse(tagType, field.Name);
                    Options[number] = field.Name;
                }

                result = !Options.Keys.Any(s => s < 1 || (s != 1 && ((s & s - 1) != 0)));
            }

            return result;
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

            if (reader.TokenType == JsonToken.StartArray)
            {
                List<string> names = new List<string>();
                this.CanConvert(objectType);
                int value = 0;
                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                {
                    names.Add(reader.Value + "");
                    var kv = Options.FirstOrDefault(s => s.Value == reader.Value + "");
                    value += kv.Key;
                }

                result = Enum.Parse(tagType, value.ToString());


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
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (CanConvert(value.GetType()))
            {
                int num = (int)value;
                //List<string> result = new List<string>();
                writer.WriteStartArray();
                foreach (var key in Options.Keys)
                {
                    if ((num & key) == key)
                    {
                        writer.WriteValue(Options[key]);
                        //result.Add(Options[key]);
                    }
                }

                writer.WriteEndArray();
                //writer.WriteValue(result.ToArray());
            }
            else writer.WriteNull();
        }
    }
}
