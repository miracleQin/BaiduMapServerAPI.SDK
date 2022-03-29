using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 获取枚举名为字符串结果
    /// </summary>
    public sealed class EnumNameAttribute : StringConverterAttribute
    {
        public override string GetString(object value)
        {
            return value == null ? null : value + "";
        }
    }
}
