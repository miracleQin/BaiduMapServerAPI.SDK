using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 布尔转0或1
    /// </summary>
    public class BoolToNumConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value == null) return null;
            return ((bool?)value).GetValueOrDefault(false) ? "1" : "0";
        }
    }
}
