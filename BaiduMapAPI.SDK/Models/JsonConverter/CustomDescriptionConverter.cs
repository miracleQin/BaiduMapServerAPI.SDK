using BaiduMapAPI.Models.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models.JsonConverter
{
    /// <summary>
    /// 自定义枚举项转换器
    /// </summary>
    public class CustomDescriptionConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 判断类型是否能转换
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool CanConvert(Type objectType)
        {
            if (objectType != null && (objectType.IsEnum || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(objectType).IsEnum)))
            {
                var enumType = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(objectType) : objectType;

                var fields = enumType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (fields.Length > 0)
                {
                    return fields[0].GetCustomAttribute<CustomDescriptionAttribute>() != null;
                }
            }
            return false;
        }

        /// <summary>
        /// 读取 JSON 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = default;

            if (CanConvert(objectType))
            {
                var enumType = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(objectType) : objectType;

                var fields = enumType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                object value = reader.Value;
                foreach (var field in fields)
                {
                    var description = field.GetCustomAttribute<CustomDescriptionAttribute>();
                    if (value == description.Value)
                    {
                        result = Enum.Parse(enumType, field.Name);
                        break;
                    }
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
            Type objectType;
            if (value != null && CanConvert(objectType = value.GetType()))
            {
                var enumType = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(objectType) : objectType;
                var field = enumType.GetField(value.ToString(), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                var description = field.GetCustomAttribute<CustomDescriptionAttribute>();
                writer.WriteValue(description.Value);
            }
            else writer.WriteNull();
        }
    }
}
