using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 跨城交通方式策略
    /// </summary>
    public enum TransTypeIntercity
    {
        /// <summary>
        /// 火车优先
        /// </summary>
        [Description("火车优先")]
        TrainFirst=0,
        /// <summary>
        /// 飞机优先
        /// </summary>
        [Description("飞机优先")]
        PlaneFirst=1,
        /// <summary>
        /// 巴士优先
        /// </summary>
        [Description("巴士优先")]
        BusFirst=2,
    }
}
