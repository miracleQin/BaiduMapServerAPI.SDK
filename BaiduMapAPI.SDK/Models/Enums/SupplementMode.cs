using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 里程补偿设置
    /// </summary>
    public enum SupplementMode
    {
        /// <summary>
        /// 不补充，中断两点间距离不记入里程
        /// </summary>
        [Description("不补充")]
        no_supplement = 0,

        /// <summary>
        /// 使用直线距离补充
        /// </summary>
        [Description("使用直线距离补充")]
        straight = 1,

        /// <summary>
        /// 使用最短驾车路线距离补充
        /// </summary>
        [Description("使用最短驾车路线距离补充")]
        driving = 2,

        /// <summary>
        /// 使用最短骑行路线距离补充
        /// </summary>
        [Description("使用最短骑行路线距离补充")]
        riding = 3,

        /// <summary>
        /// 使用最短步行路线距离补充
        /// </summary>
        [Description("使用最短步行路线距离补充")]
        walking = 4,
    }
}
