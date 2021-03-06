using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 将日期类型转为 Unix 时间戳
    /// </summary>
    public sealed class ToTimestampAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;

            if (value != null && (value is DateTime || value is DateTime?))
            {
                result = ((DateTime)value).ToTimestamp();
            }

            return result;
        }
    }
}
