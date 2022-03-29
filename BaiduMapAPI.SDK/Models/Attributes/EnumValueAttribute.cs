using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 获取枚举值为字符串值
    /// </summary>
    public sealed class EnumValueAttribute : StringConverterAttribute
    {
        public override string GetString(object value)
        {
            return value == null ? null : ((int)value) + "";
        }
    }
}
