using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{

    /// <summary>
    /// 多个时间戳转换器
    /// </summary>
    public class MultisUnixDateTimeConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value != null && value is List<DateTime>)
                return string.Join(",", ((List<DateTime>)value).Select(s => s.ToTimestamp()));
            else return null;
        }
    }
}
