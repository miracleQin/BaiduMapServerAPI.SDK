using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 交通方式
    /// </summary>
    public enum TransportMode
    {
        /// <summary>
        /// 自动
        /// </summary>
        [Description("自动")]
        auto = 0,

        /// <summary>
        /// 驾驶
        /// </summary>
        [Description("驾驶")]
        driving = 1,

        /// <summary>
        /// 骑行
        /// </summary>
        [Description("骑行")]
        riding = 2,

        /// <summary>
        /// 步行
        /// </summary>
        [Description("步行")]
        walking = 3,


    }
}
