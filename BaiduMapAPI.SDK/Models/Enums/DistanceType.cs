using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 距离计算方式
    /// </summary>
    public enum DistanceType
    {
        /// <summary>
        /// 直线距离
        /// </summary>
        [Description("直线距离")]
        STRAIGHT=0,

        /// <summary>
        /// 导航距离
        /// </summary>
        [Description("导航距离")]
        TRAVEL=1,
    }
}
