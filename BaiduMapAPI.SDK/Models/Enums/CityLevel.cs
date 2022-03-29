using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 城市所在级别
    /// </summary>
    public enum CityLevel
    {
        /// <summary>
        /// 国家
        /// </summary>
        [Description("国家")]
        country=0,
        /// <summary>
        /// 省
        /// </summary>
        [Description("省")]
        province = 1,
        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        city = 2,
        /// <summary>
        /// 区/县
        /// </summary>
        [Description("区/县")]
        district = 3,
        /// <summary>
        /// 乡/镇
        /// </summary>
        [Description("乡/镇")]
        town = 4,

    }
}
