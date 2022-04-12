using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 矩形区域转换器
    /// </summary>
    public class BoundsConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value == null) return null;
            var b = (Bound)value;

            return $"{b.TopLeft.Lat},{b.TopLeft.Lng},{b.BottonRight.Lat},{b.BottonRight.Lng}";
        }
    }
}
