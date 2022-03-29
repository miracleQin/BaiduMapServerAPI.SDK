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
        public override string GetString(object value)
        {
            if (value == null) return null;
            return ((bool?)value).GetValueOrDefault(false) ? "1" : "0";
        }
    }
}
