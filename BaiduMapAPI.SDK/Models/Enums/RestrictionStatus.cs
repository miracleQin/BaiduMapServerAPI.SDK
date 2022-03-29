using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 限行状态
    /// </summary>
    public enum RestrictionStatus
    {
        /// <summary>
        /// 无限行
        /// </summary>
        [Description("无限行")]
        Infinite = 0,

        /// <summary>
        /// 已规避限行， 路线合法
        /// </summary>
        [Description("已规避限行， 路线合法")]
        Circumvented = 1,

        /// <summary>
        /// 无法规避限 行，路线非法
        /// </summary>
        [Description("无法规避限 行，路线非法")]
        CanNotAvoid = 2,
    }
}
