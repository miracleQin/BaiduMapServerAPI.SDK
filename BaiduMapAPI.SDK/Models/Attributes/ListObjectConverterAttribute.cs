using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 列表对象转换器
    /// </summary>
    public class ListObjectConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 分隔符
        /// </summary>
        public string SplitStr { get; private set; }

        public ListObjectConverterAttribute(string SplitStr = "|")
        {
            this.SplitStr = SplitStr;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;

            if (value != null)
            {
                List<string> values = new List<string>();
                var valueType = value.GetType();
                if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var GetEnumeratorMethod = valueType.GetMethod("GetEnumerator");
                    var enumerator = (IEnumerator)GetEnumeratorMethod.Invoke(value, null);

                    while (enumerator.MoveNext())
                    {
                        values.Add(enumerator.Current == null ? "" : enumerator.Current.ToString());
                    }
                    result = string.Join(this.SplitStr, values);
                }
            }

            return result;
        }
    }
}
