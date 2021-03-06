using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 枚举列表转换器
    /// </summary>
    public class EnumListConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 枚举列表转换器
        /// </summary>
        public EnumListConverter()
        {
            this.IdentityID = Guid.NewGuid();
        }
        /// <summary>
        /// 实例化对象标识
        /// </summary>
        public Guid IdentityID { get; private set; }
        /// <summary>
        /// 枚举类型
        /// </summary>
        private Type tagType;
        /// <summary>
        /// 枚举项
        /// </summary>
        private Dictionary<int, string> Options { get; set; } = new Dictionary<int, string>();

        /// <summary>
        /// 判断是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            bool result = false;


            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>))
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

                result = true;
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

            if (reader.TokenType == JsonToken.String)
            {
                this.CanConvert(objectType);
                var constructor = objectType.GetConstructor(new Type[0]);
                result = constructor.Invoke(null);
                var addMethod = objectType.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);

                var values = (reader.Value + "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var value in values)
                {
                    var kv = Options.FirstOrDefault(s => s.Key + "" == value);
                    addMethod.Invoke(result, new object[] { Enum.Parse(tagType, kv.Value) });
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
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (CanConvert(value.GetType()))
            {
                var getEnumeratorMethod = value.GetType().GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);
                var enumerator = (System.Collections.IEnumerator)getEnumeratorMethod.Invoke(value, null);


                List<int> tmp = new List<int>();


                while (enumerator.MoveNext())
                    tmp.Add((int)enumerator.Current);

                writer.WriteValue(string.Join(",", tmp));
            }
            else writer.WriteNull();
        }
    }
}
