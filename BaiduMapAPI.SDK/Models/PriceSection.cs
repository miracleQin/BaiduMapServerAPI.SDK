using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 价格区间
    /// </summary>
    public class PriceSection
    {
        /// <summary>
        /// 最大值
        /// </summary>
        public decimal? Max { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public decimal? Min { get; set; }

        public override string ToString()
        {
            return Min.HasValue || Max.HasValue ? $"{Min},{Max}" : "";
        }
    }
}
