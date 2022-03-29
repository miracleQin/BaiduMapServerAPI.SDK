using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 坐标列表属性转字符串格式转换器
    /// </summary>
    public class LocationListConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 坐标列表属性转字符串格式转换器
        /// </summary>
        /// <param name="spliteChar">分隔字符</param>
        public LocationListConverterAttribute(string spliteChar = "|")
        {
            this.SpliteChar = spliteChar;
        }
        /// <summary>
        /// 分隔字符
        /// </summary>
        public string SpliteChar { get; private set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;
            Type type = null;
            if (value != null && (type = value.GetType()).IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0] == typeof(Models.Location))
            {
                result = string.Join(this.SpliteChar, ((List<Models.Location>)value).Select(s => $"{s.Lat},{s.Lng}"));
            }
            return result;
        }
    }
}
