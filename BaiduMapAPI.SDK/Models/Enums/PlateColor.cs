using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 车牌颜色类型
    /// </summary>
    public enum PlateColor
    {
        /// <summary>
        /// 蓝色
        /// </summary>
        [Description("蓝色")]
        Blue = 0,

        /// <summary>
        /// 黄
        /// </summary>
        [Description("黄")]
        Yellow = 1,

        /// <summary>
        /// 黑
        /// </summary>
        [Description("黑")]
        Black = 2,

        /// <summary>
        /// 白
        /// </summary>
        [Description("白")]
        White = 3,

        /// <summary>
        /// 绿
        /// </summary>
        [Description("绿")]
        Green = 4,
    }
}
