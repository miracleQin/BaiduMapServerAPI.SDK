using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 交通路况评价
    /// </summary>
    public enum TrafficCondition
    {
        /// <summary>
        /// 无路况
        /// </summary>
        [Description("无路况")]
        None = 0,

        /// <summary>
        /// 畅通
        /// </summary>
        [Description("畅通")]
        Unblocked = 1,

        /// <summary>
        /// 缓行
        /// </summary>
        [Description("缓行")]
        Slowly = 2,

        /// <summary>
        /// 拥堵
        /// </summary>
        [Description("拥堵")]
        TrafficJam = 3,

        /// <summary>
        /// 严重拥堵
        /// </summary>
        [Description("严重拥堵")]
        TrafficCongestion = 4,
    }
}
