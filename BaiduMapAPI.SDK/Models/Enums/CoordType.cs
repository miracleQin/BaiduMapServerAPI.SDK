using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 坐标类型
    /// </summary>
    public enum CoordType
    {
        /// <summary>
        /// GPS经纬度
        /// </summary>
        [Description("GPS经纬度")]
        wgs84ll = 1,
        /// <summary>
        /// 国测局经纬度坐标
        /// </summary>
        [Description("国测局经纬度坐标")]
        gcj02ll = 2,
        /// <summary>
        /// 百度经纬度坐标
        /// </summary>
        [Description("百度经纬度坐标")]
        bd09ll = 3,
        /// <summary>
        /// 百度米制坐标
        /// </summary>
        [Description("百度米制坐标")]
        bd09mc = 4,
        /// <summary>
        /// GPS经纬度
        /// </summary>
        [Description("GPS经纬度")]
        wgs84 = 5,
        /// <summary>
        /// 国测局经纬度坐标
        /// </summary>
        [Description("国测局经纬度坐标")]
        gcj02 = 6,
    }
}
