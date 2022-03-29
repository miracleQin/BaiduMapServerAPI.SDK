using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// Unix 时间戳转换器
    /// </summary>
    public class UnixDateTimeConverterAttribute : StringConverterAttribute
    {
        public override string GetString(object value)
        {
            var dt = value as DateTime?;
            return dt.ToTimestamp();
        }
    }
}
