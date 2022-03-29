using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 结果类型
    /// </summary>
    public enum SearchResultType
    {
        /// <summary>
        /// 城市列表
        /// </summary>
        [Description("城市列表")]
        city_type=0,
        /// <summary>
        /// 普通poi
        /// </summary>
        [Description("普通poi")]
        poi_type = 1,
        /// <summary>
        /// 行政区划数据
        /// </summary>
        [Description("行政区划数据")]
        region_type = 2,
        /// <summary>
        /// 门址数据
        /// </summary>
        [Description("门址数据")]
        address_type = 3,
    }
}
