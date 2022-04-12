using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 出发时间区间转换器
    /// </summary>
    public class TransitDepartureTimeConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;

            if (value != null)
            {
                var model = (APIs.Direction.V2.TransitDepartureTime)value;

                if (model.Start.HasValue)
                {
                    result = model.Start.Value.ToString(@"hh\:mm");
                    if (model.End.HasValue)
                        result += "-" + model.End.Value.ToString(@"hh\:mm");
                }
            }

            return result;
        }
    }
}
