using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 去噪力度
    /// </summary>
    public enum DenoiseGrade
    {
        /// <summary>
        /// 不去噪
        /// </summary>
        [Description("不去噪")]
        leve0 = 0,
        /// <summary>
        /// 系统默认去噪
        /// </summary>
        [Description("系统默认去噪")]
        leve1 = 1,
        /// <summary>
        /// 系统默认去噪
        /// <para>同时去除定位精度低于500的轨迹点，相当于保留GPS定位点、大部分Wi-Fi定位点和精度较高的基站定位点</para>
        /// </summary>
        [Description("系统默认去噪")]
        leve2 = 2,
        /// <summary>
        /// 系统默认去噪
        /// <para>同时去除定位精度低于100的轨迹点，相当于保留GPS定位点和大部分Wi-Fi定位点</para>
        /// </summary>
        [Description("系统默认去噪")]
        leve3 = 3,
        /// <summary>
        /// 系统默认去噪
        /// <para>同时去除定位精度低于50的轨迹点，相当于保留GPS定位点和精度较高的Wi-Fi定位点</para>
        /// </summary>
        [Description("系统默认去噪")]
        leve4 = 4,
        /// <summary>
        /// 系统默认去噪
        /// <para>同时去除定位精度低于20的轨迹点，相当于仅保留GPS定位点</para>
        /// </summary>
        [Description("系统默认去噪")]
        leve5 = 5,
    }
}
