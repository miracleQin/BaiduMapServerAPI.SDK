using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 矩形坐标转换器(左下右上)
    /// </summary>
    public class BoundInfoConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式的数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;

            if (value != null && value is APIs.Traffic.V1.BoundInfo)
            {
                var bound = value as APIs.Traffic.V1.BoundInfo;
                result = $"{bound.LeftBottom.Lat},{bound.LeftBottom.Lng};{bound.RightTop.Lat},{bound.RightTop.Lng}";
            }

            return result;
        }
    }
}
