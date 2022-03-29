using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 角度类型
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// 345°- 15°
        /// </summary>
        [Description("345°- 15°")]
        Direction1 = 0,

        /// <summary>
        /// 15°- 45°
        /// </summary>
        [Description("15°- 45°")]
        Direction2 = 1,

        /// <summary>
        /// 45°- 75°
        /// </summary>
        [Description("45°- 75°")]
        Direction3 = 2,

        /// <summary>
        /// 75°- 105°
        /// </summary>
        [Description("75°- 105°")]
        Direction4 = 3,

        /// <summary>
        /// 105°- 135°
        /// </summary>
        [Description("105°- 135°")]
        Direction5 = 4,

        /// <summary>
        /// 135°- 165°
        /// </summary>
        [Description("135°- 165°")]
        Direction6 = 5,

        /// <summary>
        /// 165°- 195°
        /// </summary>
        [Description("165°- 195°")]
        Direction7 = 6,

        /// <summary>
        /// 195°- 225°
        /// </summary>
        [Description("195°- 225°")]
        Direction8 = 7,

        /// <summary>
        /// 225°- 255°
        /// </summary>
        [Description("225°- 255°")]
        Direction9 = 8,

        /// <summary>
        /// 255°- 285°
        /// </summary>
        [Description("255°- 285°")]
        Direction10 = 9,

        /// <summary>
        /// 285°- 315°
        /// </summary>
        [Description("285°- 315°")]
        Direction11 = 10,

        /// <summary>
        /// 315°- 345°
        /// </summary>
        [Description("315°- 345°")]
        Direction12 = 11,
    }
}
