using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 枚举值列表
    /// </summary>
    public class EnumListConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 取值模式
        /// </summary>
        public enum GetValueMethod
        {
            /// <summary>
            /// 枚举名
            /// </summary>
            [Description("枚举名")]
            FieldName = 0,

            /// <summary>
            /// 枚举值
            /// </summary>
            [Description("枚举值")]
            FieldValue = 1,
        }

        private GetValueMethod getValueMethod;
        private string splitChar;
        Func<object, object> getter;

        /// <summary>
        /// 枚举值列表转换器
        /// </summary>
        /// <param name="getValueMethod">枚举取值模式</param>
        /// <param name="splitChar">拼接字符串</param>
        public EnumListConverterAttribute(GetValueMethod getValueMethod, string splitChar = ",")
        {
            this.getValueMethod = getValueMethod;
            this.splitChar = string.IsNullOrEmpty(splitChar) ? "," : splitChar;

            if (this.getValueMethod == GetValueMethod.FieldValue)
                getter = ValueGetter;
            else getter = NameGetter;
        }

        public override string GetString(object value)
        {
            string result = null;
            if (value != null)
            {
                var type = value.GetType();
                Type enumType;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && (enumType = type.GetGenericArguments()[0]).IsEnum)
                {
                    List<object> enumValues = new List<object>();

                    var GetEnumeratorMethod = type.GetMethod("GetEnumerator");
                    var enumerator = (IEnumerator)GetEnumeratorMethod.Invoke(value, null);

                    while (enumerator.MoveNext())
                    {
                        enumValues.Add(getter(enumerator.Current));
                    }


                    result = string.Join(this.splitChar, enumValues);
                }

            }
            return result;
        }

        private static object ValueGetter(object field)
        {
            return (int)field;
        }
        private static object NameGetter(object field)
        {
            return field.ToString();
        }

    }
}
