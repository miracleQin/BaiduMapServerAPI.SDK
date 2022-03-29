using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 自定义枚举值转换
    /// </summary>
    public class CustomDescriptionConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 转换值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string GetString(object value)
        {
            string result = null;

            if (value != null)
            {
                var type = GetValueType(value);

                if (type.IsEnum)
                {
                    var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
                    Dictionary<int, object> enumValues = new Dictionary<int, object>();//枚举项的下标值与自定义值
                    foreach (var field in fields)
                    {
                        var enumItem = Enum.Parse(type, field.Name);
                        var description = field.GetCustomAttribute<CustomDescriptionAttribute>();
                        enumValues[(int)enumItem] = description == null ? ((int)enumItem) as object : description.Value;
                    }

                    int val = (int)value;
                    List<object> values = new List<object>();
                    foreach (var kv in enumValues)
                    {
                        if ((val & kv.Key) == kv.Key)
                        {
                            values.Add(kv.Value);
                        }
                    }
                    result = string.Join(",", values);
                }

            }

            return result;
        }

        private static Type GetValueType(object value)
        {
            Type result = value.GetType();

            if (result.IsGenericType && result.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                result = result.GetGenericArguments()[0];
            }

            return result;
        }
    }
}
