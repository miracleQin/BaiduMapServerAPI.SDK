using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 价格区间格式转换
    /// </summary>
    public class PriceSectionConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value == null) return null;
            var ps = (PriceSection)value;
            return ps.Max.HasValue || ps.Min.HasValue ? $"{ps.Min},{ps.Max}" : null;
        }
    }
}
